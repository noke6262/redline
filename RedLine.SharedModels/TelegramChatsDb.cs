using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedLine.SharedModels;

public class TelegramChatsDb
{
	public object RootLocker = new object();

	public List<TelegramChatSettings> chatsSettings = new List<TelegramChatSettings>();

	private string SettingsFile => "telegramChatsSettings.json";

	public void LoadSettings()
	{
		try
		{
			if (File.Exists(SettingsFile))
			{
				string text = File.ReadAllText(SettingsFile);
				if (!string.IsNullOrWhiteSpace(text))
				{
					JArray val = JArray.Parse(text);
					chatsSettings = ((JToken)val).ToObject<List<TelegramChatSettings>>();
				}
			}
			else
			{
				SaveSettings();
			}
		}
		catch
		{
			SaveSettings();
		}
	}

	public void SaveSettings()
	{
		string contents = JsonConvert.SerializeObject((object)chatsSettings, (Formatting)1);
		File.WriteAllText(SettingsFile, contents);
	}
}
