using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedLine.MainPanel.Models;

public class StatisticDb
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private IntPtr intptr_3;

	[CompilerGenerated]
	private IntPtr intptr_4;

	[CompilerGenerated]
	private IntPtr intptr_5;

	[CompilerGenerated]
	private IntPtr intptr_6;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object object_2;

	public int Passwords
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)value;
		}
	}

	public int Cookies
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_1;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)value;
		}
	}

	public int AutoFills
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_2;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)value;
		}
	}

	public int CreditCards
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_3;
		}
		[CompilerGenerated]
		set
		{
			intptr_3 = (IntPtr)value;
		}
	}

	public int Files
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_4;
		}
		[CompilerGenerated]
		set
		{
			intptr_4 = (IntPtr)value;
		}
	}

	public int FTPs
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_5;
		}
		[CompilerGenerated]
		set
		{
			intptr_5 = (IntPtr)value;
		}
	}

	public int ColdWallets
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_6;
		}
		[CompilerGenerated]
		set
		{
			intptr_6 = (IntPtr)value;
		}
	}

	public List<string> OS
	{
		[CompilerGenerated]
		get
		{
			return (List<string>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public List<string> Country
	{
		[CompilerGenerated]
		get
		{
			return (List<string>)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public List<string> AVs
	{
		[CompilerGenerated]
		get
		{
			return (List<string>)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonIgnore]
	private string SettingsFile => "stats.json";

	public void LoadSettings()
	{
		try
		{
			if (File.Exists(SettingsFile))
			{
				string text = File.ReadAllText(SettingsFile);
				if (string.IsNullOrWhiteSpace(text))
				{
					SetDefault();
					return;
				}
				StatisticDb statisticDb = ((JToken)JObject.Parse(text)).ToObject<StatisticDb>();
				AutoFills = statisticDb.AutoFills;
				AVs = statisticDb.AVs;
				ColdWallets = statisticDb.ColdWallets;
				Cookies = statisticDb.Cookies;
				Country = statisticDb.Country;
				CreditCards = statisticDb.CreditCards;
				Files = statisticDb.Files;
				FTPs = statisticDb.FTPs;
				OS = statisticDb.OS;
				Passwords = statisticDb.Passwords;
			}
			else
			{
				SetDefault();
				SaveSettings();
			}
		}
		catch
		{
			SetDefault();
			SaveSettings();
		}
	}

	public void SaveSettings()
	{
		string contents = JsonConvert.SerializeObject((object)this, (Formatting)1);
		File.WriteAllText(SettingsFile, contents);
	}

	public void SetDefault()
	{
		AutoFills = 0;
		Passwords = 0;
		ColdWallets = 0;
		Cookies = 0;
		CreditCards = 0;
		Files = 0;
		FTPs = 0;
		OS = new List<string>();
		AVs = new List<string>();
		Country = new List<string>();
	}
}
