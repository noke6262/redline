using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Helpers;

public class InlineCalendar
{
	private class InlineDate
	{
		[CompilerGenerated]
		private object object_0;

		[CompilerGenerated]
		private object object_1;

		public string Value
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

		public string Data
		{
			[CompilerGenerated]
			get
			{
				return (string)object_1;
			}
			[CompilerGenerated]
			set
			{
				object_1 = value;
			}
		}

		public static InlineDate Default => new InlineDate();

		public InlineDate(string value = " ", string data = "null")
		{
			Value = value;
			Data = data;
		}
	}

	public unsafe static bool TryGetDate(CallbackQueryEventArgs e, string key, out DateTime date)
	{
		date = DateTime.MinValue;
		string s = default(string);
		if (smethod_0(e.CallbackQuery.Data, key, (nint)(&s)) == 0 || !DateTime.TryParse(s, out date))
		{
			return false;
		}
		return true;
	}

	public static InlineKeyboardMarkup Create(DateTime date, string dateKey, string changeKey)
	{
		string text = "";
		if (date.Month == 1)
		{
			text = $"Январь {date.Year}";
		}
		else if (date.Month == 2)
		{
			text = $"Февраль {date.Year}";
		}
		else if (date.Month != 3)
		{
			if (date.Month == 4)
			{
				text = $"Апрель {date.Year}";
			}
			else if (date.Month != 5)
			{
				if (date.Month != 6)
				{
					if (date.Month != 7)
					{
						if (date.Month == 8)
						{
							text = $"Август {date.Year}";
						}
						else if (date.Month == 9)
						{
							text = $"Сентябрь {date.Year}";
						}
						else if (date.Month != 10)
						{
							if (date.Month != 11)
							{
								if (date.Month == 12)
								{
									text = $"Декабрь {date.Year}";
								}
							}
							else
							{
								text = $"Ноябрь {date.Year}";
							}
						}
						else
						{
							text = $"Октябрь {date.Year}";
						}
					}
					else
					{
						text = $"Июль {date.Year}";
					}
				}
				else
				{
					text = $"Июнь {date.Year}";
				}
			}
			else
			{
				text = $"Май {date.Year}";
			}
		}
		else
		{
			text = $"Март {date.Year}";
		}
		DateTime dateTime = new DateTime(date.Year, date.Month, 1);
		int num = DateTime.DaysInMonth(date.Year, date.Month);
		int num2 = (int)((dateTime.DayOfWeek == DayOfWeek.Sunday) ? ((DayOfWeek)7) : dateTime.DayOfWeek);
		Dictionary<int, InlineDate> dictionary = new Dictionary<int, InlineDate>();
		if (num2 - 1 > 0)
		{
			for (int i = 1; i < num2; i++)
			{
				dictionary.Add(i, InlineDate.Default);
			}
		}
		for (int j = num2; j <= num + num2 - 1; j++)
		{
			dictionary.Add(j, new InlineDate($"{((j - 1 == 0) ? j : (j - num2 + 1))}", new DateTime(date.Year, date.Month, (j - 1 == 0) ? j : (j - num2 + 1)).ToShortDateString()));
		}
		for (int k = num + num2; k <= 42; k++)
		{
			dictionary.Add(k, InlineDate.Default);
		}
		InlineKeyboard inlineKeyboard = new InlineKeyboard();
		inlineKeyboard.Add(text, "null");
		inlineKeyboard.Add(inlineKeyboard.Callback(" Пн ", "null"), inlineKeyboard.Callback(" Вт ", "null"), inlineKeyboard.Callback(" Ср ", "null"), inlineKeyboard.Callback(" Чт ", "null"), inlineKeyboard.Callback(" Пт ", "null"), inlineKeyboard.Callback(" Сб ", "null"), inlineKeyboard.Callback(" Вс ", "null"));
		inlineKeyboard.Add(inlineKeyboard.Callback(dictionary[1].Value, "/" + dateKey + " " + dictionary[1].Data), inlineKeyboard.Callback(dictionary[2].Value, "/" + dateKey + " " + dictionary[2].Data), inlineKeyboard.Callback(dictionary[3].Value, "/" + dateKey + " " + dictionary[3].Data), inlineKeyboard.Callback(dictionary[4].Value, "/" + dateKey + " " + dictionary[4].Data), inlineKeyboard.Callback(dictionary[5].Value, "/" + dateKey + " " + dictionary[5].Data), inlineKeyboard.Callback(dictionary[6].Value, "/" + dateKey + " " + dictionary[6].Data), inlineKeyboard.Callback(dictionary[7].Value, "/" + dateKey + " " + dictionary[7].Data));
		inlineKeyboard.Add(inlineKeyboard.Callback(dictionary[8].Value, "/" + dateKey + " " + dictionary[8].Data), inlineKeyboard.Callback(dictionary[9].Value, "/" + dateKey + " " + dictionary[9].Data), inlineKeyboard.Callback(dictionary[10].Value, "/" + dateKey + " " + dictionary[10].Data), inlineKeyboard.Callback(dictionary[11].Value, "/" + dateKey + " " + dictionary[11].Data), inlineKeyboard.Callback(dictionary[12].Value, "/" + dateKey + " " + dictionary[12].Data), inlineKeyboard.Callback(dictionary[13].Value, "/" + dateKey + " " + dictionary[13].Data), inlineKeyboard.Callback(dictionary[14].Value, "/" + dateKey + " " + dictionary[14].Data));
		inlineKeyboard.Add(inlineKeyboard.Callback(dictionary[15].Value, "/" + dateKey + " " + dictionary[15].Data), inlineKeyboard.Callback(dictionary[16].Value, "/" + dateKey + " " + dictionary[16].Data), inlineKeyboard.Callback(dictionary[17].Value, "/" + dateKey + " " + dictionary[17].Data), inlineKeyboard.Callback(dictionary[18].Value, "/" + dateKey + " " + dictionary[18].Data), inlineKeyboard.Callback(dictionary[19].Value, "/" + dateKey + " " + dictionary[19].Data), inlineKeyboard.Callback(dictionary[20].Value, "/" + dateKey + " " + dictionary[20].Data), inlineKeyboard.Callback(dictionary[21].Value, "/" + dateKey + " " + dictionary[21].Data));
		inlineKeyboard.Add(inlineKeyboard.Callback(dictionary[22].Value, "/" + dateKey + " " + dictionary[22].Data), inlineKeyboard.Callback(dictionary[23].Value, "/" + dateKey + " " + dictionary[23].Data), inlineKeyboard.Callback(dictionary[24].Value, "/" + dateKey + " " + dictionary[24].Data), inlineKeyboard.Callback(dictionary[25].Value, "/" + dateKey + " " + dictionary[25].Data), inlineKeyboard.Callback(dictionary[26].Value, "/" + dateKey + " " + dictionary[26].Data), inlineKeyboard.Callback(dictionary[27].Value, "/" + dateKey + " " + dictionary[27].Data), inlineKeyboard.Callback(dictionary[28].Value, "/" + dateKey + " " + dictionary[28].Data));
		if (dictionary[29].Data != "null")
		{
			inlineKeyboard.Add(inlineKeyboard.Callback(dictionary[29].Value, "/" + dateKey + " " + dictionary[29].Data), inlineKeyboard.Callback(dictionary[30].Value, "/" + dateKey + " " + dictionary[30].Data), inlineKeyboard.Callback(dictionary[31].Value, "/" + dateKey + " " + dictionary[31].Data), inlineKeyboard.Callback(dictionary[32].Value, "/" + dateKey + " " + dictionary[32].Data), inlineKeyboard.Callback(dictionary[33].Value, "/" + dateKey + " " + dictionary[33].Data), inlineKeyboard.Callback(dictionary[34].Value, "/" + dateKey + " " + dictionary[34].Data), inlineKeyboard.Callback(dictionary[35].Value, "/" + dateKey + " " + dictionary[35].Data));
		}
		if (dictionary[36].Data != "null")
		{
			inlineKeyboard.Add(inlineKeyboard.Callback(dictionary[36].Value, "/" + dateKey + " " + dictionary[36].Data), inlineKeyboard.Callback(dictionary[37].Value, "/" + dateKey + " " + dictionary[37].Data), inlineKeyboard.Callback(dictionary[38].Value, "/" + dateKey + " " + dictionary[38].Data), inlineKeyboard.Callback(dictionary[39].Value, "/" + dateKey + " " + dictionary[39].Data), inlineKeyboard.Callback(dictionary[40].Value, "/" + dateKey + " " + dictionary[40].Data), inlineKeyboard.Callback(dictionary[41].Value, "/" + dateKey + " " + dictionary[41].Data), inlineKeyboard.Callback(dictionary[42].Value, "/" + dateKey + " " + dictionary[42].Data));
		}
		inlineKeyboard.Add(inlineKeyboard.Callback("<", $"/{changeKey} {date.AddMonths(-1):dd.MM.yyyy}"), inlineKeyboard.Callback(" ", "null"), inlineKeyboard.Callback(">", $"/{changeKey} {date.AddMonths(1):dd.MM.yyyy}"));
		return inlineKeyboard;
	}

	private unsafe static uint smethod_0(object text, object key, [Out] IntPtr value)
	{
		System.Runtime.CompilerServices.Unsafe.Write((void*)value, ((string)text).StartsWith("/" + (string)key + " ") ? ((string)text).Substring(("/" + (string)key + " ").Length) : null);
		return (System.Runtime.CompilerServices.Unsafe.Read<object>((void*)value) != null) ? 1u : 0u;
	}
}
