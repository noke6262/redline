using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class User : IEquatable<User>
{
	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private bool? nullable_0;

	[CompilerGenerated]
	private bool? nullable_1;

	[CompilerGenerated]
	private bool? nullable_2;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public long Id
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool IsBot
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string FirstName
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string LastName
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

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Username
	{
		[CompilerGenerated]
		get
		{
			return (string)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string LanguageCode
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanJoinGroups
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? CanReadAllGroupMessages
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool? SupportsInlineQueries
	{
		[CompilerGenerated]
		get
		{
			return nullable_2;
		}
		[CompilerGenerated]
		set
		{
			nullable_2 = value;
		}
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as User);
	}

	public bool Equals(User other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Id == other.Id && IsBot == other.IsBot && FirstName == other.FirstName && LastName == other.LastName && Username == other.Username && LanguageCode == other.LanguageCode && CanJoinGroups == other.CanJoinGroups && CanReadAllGroupMessages == other.CanReadAllGroupMessages)
		{
			return SupportsInlineQueries == other.SupportsInlineQueries;
		}
		return false;
	}

	public static bool operator ==(User lhs, User rhs)
	{
		return lhs?.Equals(rhs) ?? ((object)rhs == null);
	}

	public static bool operator !=(User lhs, User rhs)
	{
		return !(lhs == rhs);
	}

	public override int GetHashCode()
	{
		return (int)((((((((((((((((Id * 397L) ^ IsBot.GetHashCode()) * 397L) ^ (FirstName?.GetHashCode() ?? 0)) * 397L) ^ (LastName?.GetHashCode() ?? 0)) * 397L) ^ (Username?.GetHashCode() ?? 0)) * 397L) ^ (LanguageCode?.GetHashCode() ?? 0)) * 397L) ^ (CanJoinGroups?.GetHashCode() ?? 0)) * 397L) ^ (CanReadAllGroupMessages?.GetHashCode() ?? 0)) * 397L) ^ (SupportsInlineQueries?.GetHashCode() ?? 0));
	}

	public override string ToString()
	{
		return ((Username == null) ? (FirstName + LastName?.Insert(0, " ")) : ("@" + Username)) + $" ({Id})";
	}
}
