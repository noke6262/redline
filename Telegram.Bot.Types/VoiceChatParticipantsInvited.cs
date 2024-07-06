using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class VoiceChatParticipantsInvited
{
	[CompilerGenerated]
	private object object_0;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User[] Users
	{
		[CompilerGenerated]
		get
		{
			return (User[])object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}
}
