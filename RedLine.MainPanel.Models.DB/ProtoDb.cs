using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using ProtoBuf;

namespace RedLine.MainPanel.Models.DB;

public class ProtoDb<TItem, TKey> : DbController<TItem> where TItem : new()
{
	private Func<TItem, TKey> _keySelector;

	public override int RedLine_002EMainPanel_002EModels_002EDB_002EDbController_003CTItem_003E_002ECount
	{
		get
		{
			try
			{
				lock (base.DataBaseLock)
				{
					return Directory.GetFiles(base.DataBaseDir).Length;
				}
			}
			catch
			{
				return 0;
			}
		}
	}

	public ProtoDb(Func<TItem, TKey> keySelector, string Name)
		: base(Name)
	{
		_keySelector = keySelector ?? throw new ArgumentNullException("keySelector");
		IEnumerable<TItem> enumerable = LoadDB();
		object obj;
		if (enumerable == null)
		{
			obj = null;
		}
		else
		{
			obj = enumerable.ToList();
			if (obj != null)
			{
				goto IL_0039;
			}
		}
		obj = new List<TItem>();
		goto IL_0039;
		IL_0039:
		base.DbInstance = new BindingList<TItem>((IList<TItem>)obj);
	}

	public override void ClearDb()
	{
		lock (base.DataBaseLock)
		{
			if (Directory.Exists(base.DataBaseDir))
			{
				Directory.Delete(base.DataBaseDir, recursive: true);
				base.DbInstance.Clear();
			}
		}
	}

	public override IEnumerable<TItem> LoadDB()
	{
		List<TItem> list = new List<TItem>();
		lock (base.DataBaseLock)
		{
			if (Directory.Exists(base.DataBaseDir))
			{
				string[] files = Directory.GetFiles(base.DataBaseDir);
				foreach (string path in files)
				{
					try
					{
						FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
						TItem item = Serializer.DeserializeWithLengthPrefix<TItem>((Stream)fileStream, (PrefixStyle)1, 1);
						list.Add(item);
						fileStream.Close();
						fileStream.Dispose();
					}
					catch
					{
					}
				}
			}
		}
		return list.OrderBy(_keySelector);
	}

	public override void Save(TItem item)
	{
		if (!Directory.Exists(base.DataBaseDir))
		{
			Directory.CreateDirectory(base.DataBaseDir);
		}
		using FileStream fileStream = File.Open(Path.Combine(base.DataBaseDir, string.Concat(_keySelector(item), ".dat")), FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
		Serializer.SerializeWithLengthPrefix<TItem>((Stream)fileStream, item, (PrefixStyle)1, 1);
	}

	public override TItem Find(Predicate<TItem> predicate)
	{
		TItem[] array = new TItem[0];
		lock (base.DataBaseLock)
		{
			array = base.DbInstance.ToArray();
		}
		return Array.Find(array, predicate);
	}

	public override void Delete(Predicate<TItem> predicate)
	{
		if (Directory.Exists(base.DataBaseDir))
		{
			int num = FindIndex(predicate);
			TKey val = _keySelector(base.DbInstance[num]);
			File.Delete(Path.Combine(base.DataBaseDir, string.Concat(val, ".dat")));
			lock (base.DataBaseLock)
			{
				base.DbInstance.RemoveAt(num);
			}
			base.DbInstance.ResetItem(num);
		}
	}

	public override int FindIndex(Predicate<TItem> predicate)
	{
		TItem[] array = new TItem[0];
		lock (base.DataBaseLock)
		{
			array = base.DbInstance.ToArray();
		}
		return Array.FindIndex(array, predicate);
	}

	public override TItem LoadBody(object key)
	{
		try
		{
			if (!Directory.Exists(base.DataBaseDir))
			{
				return new TItem();
			}
			string path = Path.Combine(base.DataBaseDir, string.Concat(key, ".dat"));
			if (File.Exists(path))
			{
				lock (base.DataBaseLock)
				{
					using FileStream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
					return Serializer.DeserializeWithLengthPrefix<TItem>((Stream)fileStream, (PrefixStyle)1, 1);
				}
			}
			return new TItem();
		}
		catch (Exception)
		{
		}
		return new TItem();
	}
}
