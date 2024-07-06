using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using RedLine.MainPanel.LogExt;

namespace RedLine.MainPanel.Data.Extensions;

public static class CollectionExt
{
	public static Dictionary<TKey, long> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		Dictionary<TKey, long> dictionary = new Dictionary<TKey, long>();
		foreach (TSource item in source)
		{
			TKey val = keySelector(item);
			if (val != null)
			{
				if (!dictionary.ContainsKey(val))
				{
					dictionary[val] = 0L;
				}
				dictionary[val]++;
			}
		}
		return dictionary;
	}

	public static Dictionary<TKey, List<TValue>> SelectBy<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
	{
		Dictionary<TKey, List<TValue>> dictionary = new Dictionary<TKey, List<TValue>>();
		foreach (TSource item2 in source)
		{
			TKey key = keySelector(item2);
			TValue item = valueSelector(item2);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, new List<TValue>());
			}
			dictionary[key].Add(item);
		}
		return dictionary;
	}

	public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
	{
		foreach (T item in items)
		{
			action(item);
		}
	}

	public static void Add<T>(this IList<T> items, IEnumerable<T> items2)
	{
		foreach (T item in items2)
		{
			items.Add(item);
		}
	}

	public static string GetValue(this NameValueCollection collection, string key, string def = null)
	{
		string text = "";
		if (collection.HasKey(key))
		{
			text = collection.Get(key);
			if (!text.IsNullOrEmpty())
			{
				return text;
			}
		}
		return def;
	}

	public static bool HasKey(this NameValueCollection queryString, string key)
	{
		if (queryString != null && !key.IsNullOrEmpty() && queryString.AllKeys.Contains(key))
		{
			queryString.Get(key);
			return true;
		}
		return false;
	}

	public static bool IsGratherThanZero<T>(this IEnumerable<T> collection)
	{
		return collection.IsGratherThan(0);
	}

	public static bool IsGratherThan<T>(this IEnumerable<T> collection, int count)
	{
		if (collection == null)
		{
			return false;
		}
		return collection.Count() > count;
	}

	public static TModel SingleOrNew<TModel>(this List<TModel> collection)
	{
		TModel val = collection.SingleOrDefault();
		if (val == null)
		{
			return Activator.CreateInstance<TModel>();
		}
		return val;
	}

	public static TModel SingleOrNew<TModel>(this List<TModel> collection, Func<TModel, bool> predicate)
	{
		TModel val = collection.SingleOrDefault(predicate);
		if (val == null)
		{
			return Activator.CreateInstance<TModel>();
		}
		return val;
	}

	public static TModel SingleOrNew<TModel>(this IEnumerable<TModel> collection, Func<TModel, bool> predicate)
	{
		TModel val = collection.SingleOrDefault(predicate);
		if (val == null)
		{
			return Activator.CreateInstance<TModel>();
		}
		return val;
	}

	public static TModel FirstOrNew<TModel>(this List<TModel> collection)
	{
		TModel val = collection.FirstOrDefault();
		if (val == null)
		{
			return Activator.CreateInstance<TModel>();
		}
		return val;
	}

	public static TModel FirstOrNew<TModel>(this IEnumerable<TModel> collection)
	{
		TModel val = collection.FirstOrDefault();
		if (val != null)
		{
			return val;
		}
		return Activator.CreateInstance<TModel>();
	}

	public static TModel FirstOrNew<TModel>(this List<TModel> collection, Func<TModel, bool> predicate)
	{
		TModel val = collection.FirstOrDefault(predicate);
		if (val != null)
		{
			return val;
		}
		return Activator.CreateInstance<TModel>();
	}

	public static TModel FirstOrNew<TModel>(this IEnumerable<TModel> collection, Func<TModel, bool> predicate)
	{
		TModel val = collection.FirstOrDefault(predicate);
		if (val == null)
		{
			return Activator.CreateInstance<TModel>();
		}
		return val;
	}

	public static List<TModel> AddOnEmpty<TModel>(this List<TModel> collection)
	{
		if (collection.Count().Equals(0))
		{
			collection.Add(Activator.CreateInstance<TModel>());
		}
		return collection;
	}

	public static DataSet ToDataSet<TModel>(this IList<TModel> collection)
	{
		DataSet dataSet = new DataSet();
		PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TModel));
		DataTable dataTable = new DataTable();
		foreach (PropertyDescriptor item in properties)
		{
			dataTable.Columns.Add(item.Name, Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType);
		}
		foreach (TModel item2 in collection)
		{
			DataRow dataRow = dataTable.NewRow();
			foreach (PropertyDescriptor item3 in properties)
			{
				dataRow[item3.Name] = item3.GetValue(item2) ?? DBNull.Value;
			}
			dataTable.Rows.Add(dataRow);
		}
		dataSet.Tables.Add(dataTable);
		return dataSet;
	}

	public static void AddIfNotContains<T>(this IList<T> collection, T value)
	{
		if (value != null && !collection.Contains(value))
		{
			collection.Add(value);
		}
	}

	public static void AddRangeIfNotContains<T>(this IList<T> collection, IEnumerable<T> values)
	{
		if (values == null)
		{
			return;
		}
		foreach (T value in values)
		{
			collection.AddIfNotContains(value);
		}
	}

	public static void AddIfTrueAndNotContains<T>(this IList<T> collection, T value, bool flag)
	{
		if (value != null && flag)
		{
			collection.AddIfNotContains(value);
		}
	}

	public static int IndexOf<T>(this IList<T> collection, Func<T, bool> predicate)
	{
		int result = 0;
		if (collection == null)
		{
			return result;
		}
		T val = collection.SingleOrDefault(predicate);
		if (val != null)
		{
			result = collection.IndexOf(val);
		}
		return result;
	}
}
