using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace RedLine.MainPanel.Models.DB;

public abstract class DbController<T>
{
	private BindingList<T> _dbInstance;

	public string DataBaseDir { get; protected set; }

	public object DataBaseLock { get; } = new object();


	public BindingList<T> DbInstance
	{
		get
		{
			return _dbInstance;
		}
		set
		{
			_dbInstance = value;
		}
	}

	public abstract int RedLine_002EMainPanel_002EModels_002EDB_002EDbController_003CTItem_003E_002ECount { get; }

	protected DbController(string Name)
	{
		DataBaseDir = Path.Combine(Directory.GetCurrentDirectory(), Name ?? throw new ArgumentNullException("Name"));
	}

	public abstract T LoadBody(object key);

	public abstract T Find(Predicate<T> predicate);

	public abstract void Delete(Predicate<T> predicate);

	public abstract int FindIndex(Predicate<T> predicate);

	public abstract void Save(T item);

	public abstract void ClearDb();

	public abstract IEnumerable<T> LoadDB();
}
