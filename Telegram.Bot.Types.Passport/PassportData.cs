using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types.Passport;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class PassportData
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public EncryptedPassportElement[] Data
	{
		[CompilerGenerated]
		get
		{
			return (EncryptedPassportElement[])object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public EncryptedCredentials Credentials
	{
		[CompilerGenerated]
		get
		{
			return (EncryptedCredentials)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}
}
