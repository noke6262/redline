using Newtonsoft.Json;

namespace RedLine.MainPanel.Data.Extensions;

public static class JsonExt
{
	public static T FromJSON<T>(this string @this)
	{
		try
		{
			return JsonConvert.DeserializeObject<T>(@this);
		}
		catch
		{
			return default(T);
		}
	}

	public static string ToJSON(this object @this)
	{
		return JsonConvert.SerializeObject(@this, (Formatting)1);
	}
}
