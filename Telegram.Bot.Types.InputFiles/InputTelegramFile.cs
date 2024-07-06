using System;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Telegram.Bot.Converters;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types.InputFiles;

[JsonObject(/*Could not decode attribute arguments.*/)]
[JsonConverter(typeof(InputFileConverter))]
public class InputTelegramFile : InputFileStream
{
	[CompilerGenerated]
	private object object_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string FileId
	{
		[CompilerGenerated]
		get
		{
			return (string)object_2;
		}
		[CompilerGenerated]
		protected set
		{
			object_2 = value;
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
			if (FileId == null)
			{
				throw new InvalidOperationException("Not a valid Input File");
			}
			return FileType.Id;
		}
	}

	protected InputTelegramFile()
	{
	}

	public InputTelegramFile(Stream content)
		: this(content, null)
	{
	}

	public InputTelegramFile(Stream content, string fileName)
	{
		base.Content = content;
		base.FileName = fileName;
	}

	public InputTelegramFile(string fileId)
	{
		FileId = fileId;
	}

	public static implicit operator InputTelegramFile(Stream stream)
	{
		if (stream != null)
		{
			return new InputTelegramFile(stream);
		}
		return null;
	}

	public static implicit operator InputTelegramFile(string fileId)
	{
		if (fileId != null)
		{
			return new InputTelegramFile(fileId);
		}
		return null;
	}
}
