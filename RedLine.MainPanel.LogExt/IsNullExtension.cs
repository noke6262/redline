using System;
using System.Collections.Generic;
using System.Linq;

namespace RedLine.MainPanel.LogExt;

public static class IsNullExtension
{
	public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
	{
		return from x in items.GroupBy(property)
			select x.First();
	}

	public static bool IsNotNull<T>(this T data)
	{
		return data != null;
	}

	public static string IsNull(this string value, string defaultValue)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return value;
		}
		return defaultValue;
	}

	public static bool IsNullOrEmpty(this string str)
	{
		return string.IsNullOrEmpty(str);
	}

	public static string IsNotNullConcatRight(this string str, params string[] concat)
	{
		if (str.IsNullOrEmpty())
		{
			return str;
		}
		List<string> list = concat.ToList();
		list.Add(str);
		return string.Concat(list.ToArray());
	}

	public static string IsNotNullConcatLeft(this string str, params string[] concat)
	{
		if (str.IsNullOrEmpty())
		{
			return str;
		}
		List<string> list = concat.ToList();
		list.Insert(0, str);
		return string.Concat(list.ToArray());
	}

	public static bool IsNull(this bool? value, bool def)
	{
		if (value.HasValue)
		{
			return value.Value;
		}
		return def;
	}

	public static T IsNull<T>(this T value) where T : class
	{
		if (value == null)
		{
			return Activator.CreateInstance<T>();
		}
		return value;
	}

	public static T IsNull<T>(this T value, T def) where T : class
	{
		if (value != null)
		{
			return value;
		}
		if (def == null)
		{
			return Activator.CreateInstance<T>();
		}
		return def;
	}

	public static int IsNull(this int? value, int def)
	{
		if (value.HasValue)
		{
			return value.Value;
		}
		return def;
	}

	public static long IsNull(this long? value, long def)
	{
		if (value.HasValue)
		{
			return value.Value;
		}
		return def;
	}

	public static double IsNull(this double? value, double def)
	{
		if (value.HasValue)
		{
			return value.Value;
		}
		return def;
	}

	public static DateTime IsNull(this DateTime? value, DateTime def)
	{
		if (value.HasValue)
		{
			return value.Value;
		}
		return def;
	}

	public static Guid IsNull(this Guid? value, Guid def)
	{
		if (value.HasValue)
		{
			return value.Value;
		}
		return def;
	}
}
