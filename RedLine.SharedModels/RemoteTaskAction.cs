using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity15", Namespace = "Entity")]
public enum RemoteTaskAction
{
	[EnumMember(Value = "0")]
	Download,
	[EnumMember(Value = "1")]
	RunPE,
	[EnumMember(Value = "2")]
	DownloadAndEx,
	[EnumMember(Value = "3")]
	OpenLink,
	[EnumMember(Value = "4")]
	Cmd
}
