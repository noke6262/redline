using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RedLine.MainPanel.Models;

public class PageController<T>
{
	private int _pageSize;

	private int _currentPage;

	private List<BindingList<T>> _pages;

	public ItemsCountChangedEventHandler OnCountChanged;

	public ChangePageEventHandler OnPageChanged;

	public int PageSize => _pageSize;

	public List<BindingList<T>> Pages
	{
		get
		{
			return _pages;
		}
		set
		{
			_pages = value;
		}
	}

	public int PagesCount { get; set; }

	public int CurrentPage
	{
		get
		{
			return _currentPage;
		}
		set
		{
			_currentPage = value;
			OnPageChanged?.Invoke(value);
		}
	}

	public PageController(int pageSize)
	{
		_pageSize = pageSize;
		_pages = new List<BindingList<T>>();
		_pages.Add(new BindingList<T>());
	}

	public void FillData(IList<T> itemsSet)
	{
		for (int i = 0; i < itemsSet.Count; i++)
		{
			AddToEnd(itemsSet[i]);
		}
		OnCountChanged?.Invoke(itemsSet.Count);
	}

	public void UpdatePages(int currentPage, IList<T> itemsSet)
	{
		for (int i = currentPage; i < _pages.Count; i++)
		{
			_pages[i].Clear();
		}
		for (int j = currentPage * _pageSize; j < itemsSet.Count; j++)
		{
			if (Pages[currentPage].Count < _pageSize)
			{
				Pages[currentPage].Add(itemsSet[j]);
				continue;
			}
			currentPage++;
			if (currentPage >= Pages.Count)
			{
				AddToEnd(itemsSet[j]);
			}
			else
			{
				Pages[currentPage].Add(itemsSet[j]);
			}
		}
		OnCountChanged?.Invoke(itemsSet.Count);
	}

	public void AddToEnd(T item)
	{
		if (_pages[_pages.Count - 1].Count >= _pageSize)
		{
			_pages.Add(new BindingList<T>
			{
				AllowEdit = true,
				AllowNew = true,
				AllowRemove = true,
				RaiseListChangedEvents = true
			});
		}
		_pages[_pages.Count - 1].Add(item);
	}

	public void RemoveByIndex(int index)
	{
		if (index < _pageSize)
		{
			Pages[0].RemoveAt(index);
			Pages[0].ResetItem(index);
		}
		else
		{
			int result;
			int index2 = Math.DivRem(index, _pageSize, out result);
			Pages[index2].RemoveAt(result);
			Pages[index2].ResetItem(index);
		}
	}

	public void UpdateByIndex(int index, T item)
	{
		int result;
		int index2 = Math.DivRem(index, _pageSize, out result);
		Pages[index2][result] = item;
		Pages[index2].ResetItem(result);
	}

	public void Clear()
	{
		_pages = new List<BindingList<T>>();
		_pages.Add(new BindingList<T>
		{
			AllowEdit = true,
			AllowNew = true,
			AllowRemove = true,
			RaiseListChangedEvents = true
		});
		ChangeCount(0);
		PagesCount = 1;
	}

	public void ChangeCount(int count)
	{
		OnCountChanged?.Invoke(count);
	}
}
