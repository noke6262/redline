using System;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types.InputFiles;

[JsonObject(/*Could not decode attribute arguments.*/)]
[JsonConverter(typeof(InputFileConverter))]
public class InputOnlineFile : InputTelegramFile
{
	[CompilerGenerated]
	private object object_3;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Url
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
		[CompilerGenerated]
		protected set
		{
			object_3 = value;
		}
	}

	public override FileType FileType
	{
		get
		{
			if (base.Content != null)
			{
				return FileType.Stream;
			}
			if (base.FileId != null)
			{
				return FileType.Id;
			}
			if (Url == null)
			{
				throw new InvalidOperationException("Not a valid InputFile");
			}
			return FileType.Url;
		}
	}

	public InputOnlineFile(Stream content)
		: this(content, null)
	{
	}

	public InputOnlineFile(Stream content, string fileName)
	{
		base.Content = content;
		base.FileName = fileName;
	}

	public InputOnlineFile(string value)
	{
		if (Uri.TryCreate(value, UriKind.Absolute, out var _))
		{
			Url = value;
		}
		else
		{
			base.FileId = value;
		}
	}

	public InputOnlineFile(Uri url)
	{
		Url = url.AbsoluteUri;
	}

	public static implicit operator InputOnlineFile(Stream stream)
	{
		if (stream != null)
		{
			return new InputOnlineFile(stream);
		}
		return null;
	}

	public static implicit operator InputOnlineFile(string value)
	{
		if (value != null)
		{
			return new InputOnlineFile(value);
		}
		return null;
	}
}
