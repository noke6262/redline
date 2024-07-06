using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Core;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.Data.Helpers;
using RedLine.MainPanel.Models;
using RedLine.MainPanel.Models.Communication;

namespace RedLine.MainPanel.Views;

public class AuthFrm : Form
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public bool result;

		public string login;

		public string password;

		public AuthFrm _003C_003E4__this;

		internal void method_0()
		{
			try
			{
				_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_1
				{
					CS_0024_003C_003E8__locals1 = this
				};
				if (AssemblyProtection.EthernetConnected())
				{
					CS_0024_003C_003E8__locals0.textResult = string.Empty;
					GenericService.Use(delegate(IMainServer server)
					{
						StringTool.GenerateKeys(out var key, out var iv);
						if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
						{
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
						}
						else
						{
							long millis = CurrentMillis.Millis;
							string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.login}");
							string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.password}");
							string arg3 = StringTool.Set(millis.ToString());
							CS_0024_003C_003E8__locals0.textResult = server.Connect(arg, arg2, arg3).Result;
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.textResult))
							{
								string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
								if (!string.IsNullOrWhiteSpace(header))
								{
									if (Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), CS_0024_003C_003E8__locals0.textResult))
									{
										string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(CS_0024_003C_003E8__locals0.textResult), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
										if (array[0] == "ResultTrue" && long.TryParse(array[1], out var num) && array[2] == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.login && Math.Abs(num - millis) < 900000L && Math.Abs(CurrentMillis.Millis - millis) < 900000L)
										{
											string text = array[3];
											if (!string.IsNullOrWhiteSpace(text))
											{
												ProfileSettings.Token = text;
												CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = true;
											}
											else
											{
												CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
											}
										}
									}
								}
								else
								{
									CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
								}
							}
							else
							{
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals1.result = false;
							}
						}
					}, firstRun: true);
				}
				else
				{
					MessageBox.Show(_003C_003E4__this, "Check ethernet connection and try again");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		internal void method_1()
		{
			_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_2
			{
				CS_0024_003C_003E8__locals2 = this,
				tries = 0
			};
			Exception ex = null;
			while (CS_0024_003C_003E8__locals0.tries < 3)
			{
				Task.Delay(TimeSpan.FromMinutes(3.0)).Wait();
				try
				{
					CS_0024_003C_003E8__locals0.tries++;
					GenericService.Use(delegate(IMainServer server)
					{
						StringTool.GenerateKeys(out var key, out var iv);
						if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
						{
							EventLog.WriteEntry("Panel.exe", "Connection lost. Can't init key", EventLogEntryType.Error);
						}
						else
						{
							long millis = CurrentMillis.Millis;
							string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.login}");
							string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.password}");
							string arg3 = StringTool.Set(millis.ToString());
							string text = server.Connect(arg, arg2, arg3).Result;
							if (string.IsNullOrWhiteSpace(text))
							{
								EventLog.WriteEntry("Panel.exe", "Connection lost. Empty response", EventLogEntryType.Error);
							}
							else
							{
								string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
								if (!string.IsNullOrWhiteSpace(header))
								{
									if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), text))
									{
										EventLog.WriteEntry("Panel.exe", "Connection lost. Server", EventLogEntryType.Error);
									}
									else
									{
										string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(text), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
										if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var num) || !(array[2] == CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals2.login))
										{
											EventLog.WriteEntry("Panel.exe", "Connection lost. Parts", EventLogEntryType.Error);
										}
										else if (Math.Abs(num - millis) < 900000L && Math.Abs(CurrentMillis.Millis - millis) < 900000L)
										{
											string text2 = array[3];
											if (!string.IsNullOrWhiteSpace(text2))
											{
												CS_0024_003C_003E8__locals0.tries = 0;
												ProfileSettings.Token = text2;
											}
											else
											{
												EventLog.WriteEntry("Panel.exe", "Connection lost. Cant find a token", EventLogEntryType.Error);
											}
										}
										else
										{
											EventLog.WriteEntry("Panel.exe", "Connection lost. Mills", EventLogEntryType.Error);
										}
									}
								}
								else
								{
									EventLog.WriteEntry("Panel.exe", "Connection lost. Cant find a security token.", EventLogEntryType.Error);
								}
							}
						}
					});
				}
				catch (Exception ex2)
				{
					CS_0024_003C_003E8__locals0.tries++;
					EventLog.WriteEntry("Panel.exe", "Connection error. " + ex2.Message, EventLogEntryType.Error);
					if (ex2.Message.Contains("security issue"))
					{
						Process.GetCurrentProcess().Kill();
					}
					ex = ex2;
				}
			}
			EventLog.WriteEntry("Panel.exe", "Connection lost. " + ex.Message, EventLogEntryType.Error);
			Process.GetCurrentProcess().Kill();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public string textResult;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal void method_0(IMainServer server)
		{
			StringTool.GenerateKeys(out var key, out var iv);
			if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
			{
				CS_0024_003C_003E8__locals1.result = false;
				return;
			}
			long millis = CurrentMillis.Millis;
			string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals1.login}");
			string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals1.password}");
			string arg3 = StringTool.Set(millis.ToString());
			textResult = server.Connect(arg, arg2, arg3).Result;
			if (!string.IsNullOrWhiteSpace(textResult))
			{
				string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
				if (!string.IsNullOrWhiteSpace(header))
				{
					if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), textResult))
					{
						return;
					}
					string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(textResult), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
					if (array[0] == "ResultTrue" && long.TryParse(array[1], out var result) && array[2] == CS_0024_003C_003E8__locals1.login && Math.Abs(result - millis) < 900000L && Math.Abs(CurrentMillis.Millis - millis) < 900000L)
					{
						string text = array[3];
						if (!string.IsNullOrWhiteSpace(text))
						{
							ProfileSettings.Token = text;
							CS_0024_003C_003E8__locals1.result = true;
						}
						else
						{
							CS_0024_003C_003E8__locals1.result = false;
						}
					}
				}
				else
				{
					CS_0024_003C_003E8__locals1.result = false;
				}
			}
			else
			{
				CS_0024_003C_003E8__locals1.result = false;
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public int tries;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals2;

		internal void method_0(IMainServer server)
		{
			StringTool.GenerateKeys(out var key, out var iv);
			if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
			{
				EventLog.WriteEntry("Panel.exe", "Connection lost. Can't init key", EventLogEntryType.Error);
				return;
			}
			long millis = CurrentMillis.Millis;
			string arg = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals2.login}");
			string arg2 = StringTool.Set($"{millis}[A]{CS_0024_003C_003E8__locals2.password}");
			string arg3 = StringTool.Set(millis.ToString());
			string result = server.Connect(arg, arg2, arg3).Result;
			if (string.IsNullOrWhiteSpace(result))
			{
				EventLog.WriteEntry("Panel.exe", "Connection lost. Empty response", EventLogEntryType.Error);
				return;
			}
			string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
			if (!string.IsNullOrWhiteSpace(header))
			{
				if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), result))
				{
					EventLog.WriteEntry("Panel.exe", "Connection lost. Server", EventLogEntryType.Error);
					return;
				}
				string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(result), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
				if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var result2) || !(array[2] == CS_0024_003C_003E8__locals2.login))
				{
					EventLog.WriteEntry("Panel.exe", "Connection lost. Parts", EventLogEntryType.Error);
				}
				else if (Math.Abs(result2 - millis) < 900000L && Math.Abs(CurrentMillis.Millis - millis) < 900000L)
				{
					string text = array[3];
					if (!string.IsNullOrWhiteSpace(text))
					{
						tries = 0;
						ProfileSettings.Token = text;
					}
					else
					{
						EventLog.WriteEntry("Panel.exe", "Connection lost. Cant find a token", EventLogEntryType.Error);
					}
				}
				else
				{
					EventLog.WriteEntry("Panel.exe", "Connection lost. Mills", EventLogEntryType.Error);
				}
			}
			else
			{
				EventLog.WriteEntry("Panel.exe", "Connection lost. Cant find a security token.", EventLogEntryType.Error);
			}
		}
	}

	private object object_0;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object signInBtn;

	private object passwordLbl;

	private object loginLbl;

	private object loginTb;

	private object passwordTb;

	private object connectingLbl;

	public AuthFrm()
	{
		InitializeComponent();
		this.AllowDraggBy((Control)topHeader);
		try
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs != null && commandLineArgs.Length == 5 && commandLineArgs[1] == "auth")
			{
				((AnimaTextBox)loginTb).Text = DPAPI.Unprotect(commandLineArgs[2], DataProtectionScope.CurrentUser, "0x31242");
				((AnimaTextBox)passwordTb).Text = DPAPI.Unprotect(commandLineArgs[3], DataProtectionScope.CurrentUser, "0x31242");
				SignIn();
			}
		}
		catch
		{
		}
	}

	private void AuthFrm_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void closeBtn_Click(object sender, object e)
	{
		Close();
	}

	public async void SignIn()
	{
		try
		{
			object CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
			((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0)._003C_003E4__this = this;
			((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).login = ((AnimaTextBox)loginTb).Text;
			((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).password = ((AnimaTextBox)passwordTb).Text;
			if (string.IsNullOrWhiteSpace(((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).login))
			{
				MessageBox.Show(this, "Please, enter a login");
				return;
			}
			if (string.IsNullOrWhiteSpace(((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).password))
			{
				MessageBox.Show(this, "Please, enter a password");
				return;
			}
			if (!(await Task.Factory.StartNew(() => AssemblyProtection.EthernetConnected())))
			{
				MessageBox.Show(this, "Check ethernet connection and try again");
				return;
			}
			((Control)signInBtn).Visible = false;
			((Control)connectingLbl).Visible = true;
			((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).result = false;
			await Task.Factory.StartNew(delegate
			{
				try
				{
					_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_2 = (_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0;
					if (AssemblyProtection.EthernetConnected())
					{
						string textResult = string.Empty;
						GenericService.Use(delegate(IMainServer server)
						{
							StringTool.GenerateKeys(out var key2, out var iv2);
							if (!server.Init(StringTool.Set(Convert.ToBase64String(key2)), StringTool.Set(Convert.ToBase64String(iv2))).Result)
							{
								_003C_003Ec__DisplayClass4_2.result = false;
							}
							else
							{
								long millis2 = CurrentMillis.Millis;
								string arg4 = StringTool.Set($"{millis2}[A]{_003C_003Ec__DisplayClass4_2.login}");
								string arg5 = StringTool.Set($"{millis2}[A]{_003C_003Ec__DisplayClass4_2.password}");
								string arg6 = StringTool.Set(millis2.ToString());
								textResult = server.Connect(arg4, arg5, arg6).Result;
								if (!string.IsNullOrWhiteSpace(textResult))
								{
									string header2 = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
									if (!string.IsNullOrWhiteSpace(header2))
									{
										if (Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header2), key2, iv2), textResult))
										{
											string[] array2 = StringTool.Get(StringTool.Get(Convert.FromBase64String(textResult), key2, iv2)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
											if (array2[0] == "ResultTrue" && long.TryParse(array2[1], out var result3) && array2[2] == _003C_003Ec__DisplayClass4_2.login && Math.Abs(result3 - millis2) < 900000L && Math.Abs(CurrentMillis.Millis - millis2) < 900000L)
											{
												string text2 = array2[3];
												if (!string.IsNullOrWhiteSpace(text2))
												{
													ProfileSettings.Token = text2;
													_003C_003Ec__DisplayClass4_2.result = true;
												}
												else
												{
													_003C_003Ec__DisplayClass4_2.result = false;
												}
											}
										}
									}
									else
									{
										_003C_003Ec__DisplayClass4_2.result = false;
									}
								}
								else
								{
									_003C_003Ec__DisplayClass4_2.result = false;
								}
							}
						}, firstRun: true);
					}
					else
					{
						MessageBox.Show(((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0)._003C_003E4__this, "Check ethernet connection and try again");
					}
				}
				catch (Exception ex4)
				{
					MessageBox.Show(ex4.Message);
				}
			});
			((Control)connectingLbl).Visible = false;
			((Control)signInBtn).Visible = true;
			if (!((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).result)
			{
				MessageBox.Show(this, "Unable to log in with this login and password. Try again.");
				ProfileSettings.Login = string.Empty;
				ProfileSettings.Password = string.Empty;
				return;
			}
			Task.Run(delegate
			{
				_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_ = (_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0;
				int tries = 0;
				Exception ex2 = null;
				while (tries < 3)
				{
					Task.Delay(TimeSpan.FromMinutes(3.0)).Wait();
					try
					{
						tries++;
						GenericService.Use(delegate(IMainServer server)
						{
							StringTool.GenerateKeys(out var key, out var iv);
							if (!server.Init(StringTool.Set(Convert.ToBase64String(key)), StringTool.Set(Convert.ToBase64String(iv))).Result)
							{
								EventLog.WriteEntry("Panel.exe", "Connection lost. Can't init key", EventLogEntryType.Error);
							}
							else
							{
								long millis = CurrentMillis.Millis;
								string arg = StringTool.Set($"{millis}[A]{_003C_003Ec__DisplayClass4_.login}");
								string arg2 = StringTool.Set($"{millis}[A]{_003C_003Ec__DisplayClass4_.password}");
								string arg3 = StringTool.Set(millis.ToString());
								string result = server.Connect(arg, arg2, arg3).Result;
								if (string.IsNullOrWhiteSpace(result))
								{
									EventLog.WriteEntry("Panel.exe", "Connection lost. Empty response", EventLogEntryType.Error);
								}
								else
								{
									string header = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>("X-Token", "WCF");
									if (!string.IsNullOrWhiteSpace(header))
									{
										if (!Encryptor.ValidateServer(StringTool.Get(Convert.FromBase64String(header), key, iv), result))
										{
											EventLog.WriteEntry("Panel.exe", "Connection lost. Server", EventLogEntryType.Error);
										}
										else
										{
											string[] array = StringTool.Get(StringTool.Get(Convert.FromBase64String(result), key, iv)).Split(new string[1] { "[B]" }, StringSplitOptions.RemoveEmptyEntries);
											if (!(array[0] == "ResultTrue") || !long.TryParse(array[1], out var result2) || !(array[2] == _003C_003Ec__DisplayClass4_.login))
											{
												EventLog.WriteEntry("Panel.exe", "Connection lost. Parts", EventLogEntryType.Error);
											}
											else if (Math.Abs(result2 - millis) < 900000L && Math.Abs(CurrentMillis.Millis - millis) < 900000L)
											{
												string text = array[3];
												if (!string.IsNullOrWhiteSpace(text))
												{
													tries = 0;
													ProfileSettings.Token = text;
												}
												else
												{
													EventLog.WriteEntry("Panel.exe", "Connection lost. Cant find a token", EventLogEntryType.Error);
												}
											}
											else
											{
												EventLog.WriteEntry("Panel.exe", "Connection lost. Mills", EventLogEntryType.Error);
											}
										}
									}
									else
									{
										EventLog.WriteEntry("Panel.exe", "Connection lost. Cant find a security token.", EventLogEntryType.Error);
									}
								}
							}
						});
					}
					catch (Exception ex3)
					{
						tries++;
						EventLog.WriteEntry("Panel.exe", "Connection error. " + ex3.Message, EventLogEntryType.Error);
						if (ex3.Message.Contains("security issue"))
						{
							Process.GetCurrentProcess().Kill();
						}
						ex2 = ex3;
					}
				}
				EventLog.WriteEntry("Panel.exe", "Connection lost. " + ex2.Message, EventLogEntryType.Error);
				Process.GetCurrentProcess().Kill();
			});
			base.DialogResult = DialogResult.OK;
			ProfileSettings.Login = ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).login;
			ProfileSettings.Password = ((_003C_003Ec__DisplayClass4_0)CS_0024_003C_003E8__locals0).password;
			Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private async void signInBtn_Click(object sender, object e)
	{
		SignIn();
	}

	private void method_0(object sender, object e)
	{
		if (((KeyEventArgs)e).KeyCode == Keys.Return)
		{
			SignIn();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_0 != null)
		{
			((IDisposable)object_0).Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.AuthFrm));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.signInBtn = new System.Windows.Forms.Button();
		this.passwordLbl = (object)new MetroSetLabel();
		this.loginLbl = (object)new MetroSetLabel();
		this.passwordTb = (object)new AnimaTextBox();
		this.loginTb = (object)new AnimaTextBox();
		this.connectingLbl = (object)new MetroSetLabel();
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(547, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 4;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(115, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Log In";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(524, 4);
		((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
		((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
		((System.Windows.Forms.Control)this.closeBtn).Text = "X";
		((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
		((System.Windows.Forms.Control)this.signInBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.signInBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.signInBtn).FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		((System.Windows.Forms.Control)this.signInBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((System.Windows.Forms.Control)this.signInBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.signInBtn).Location = new System.Drawing.Point(234, 161);
		((System.Windows.Forms.Control)this.signInBtn).Name = "signInBtn";
		((System.Windows.Forms.Control)this.signInBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.signInBtn).TabIndex = 13;
		((System.Windows.Forms.Control)this.signInBtn).Text = "Sign in";
		((System.Windows.Forms.ButtonBase)this.signInBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.signInBtn).Click += new System.EventHandler(signInBtn_Click);
		((System.Windows.Forms.Control)this.passwordLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((System.Windows.Forms.Control)this.passwordLbl).Location = new System.Drawing.Point(42, 99);
		((System.Windows.Forms.Control)this.passwordLbl).Name = "passwordLbl";
		((System.Windows.Forms.Control)this.passwordLbl).Size = new System.Drawing.Size(100, 23);
		((MetroSetLabel)this.passwordLbl).Style = (Style)1;
		((MetroSetLabel)this.passwordLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.passwordLbl).TabIndex = 10;
		((System.Windows.Forms.Control)this.passwordLbl).Text = "Password:";
		((MetroSetLabel)this.passwordLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.passwordLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.loginLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((System.Windows.Forms.Control)this.loginLbl).Location = new System.Drawing.Point(42, 43);
		((System.Windows.Forms.Control)this.loginLbl).Name = "loginLbl";
		((System.Windows.Forms.Control)this.loginLbl).Size = new System.Drawing.Size(100, 23);
		((MetroSetLabel)this.loginLbl).Style = (Style)1;
		((MetroSetLabel)this.loginLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.loginLbl).TabIndex = 9;
		((System.Windows.Forms.Control)this.loginLbl).Text = "Login:";
		((MetroSetLabel)this.loginLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.loginLbl).ThemeName = "MetroDark";
		((AnimaTextBox)this.passwordTb).Dark = false;
		((System.Windows.Forms.Control)this.passwordTb).Location = new System.Drawing.Point(42, 122);
		((AnimaTextBox)this.passwordTb).MaxLength = 32767;
		((AnimaTextBox)this.passwordTb).MultiLine = false;
		((System.Windows.Forms.Control)this.passwordTb).Name = "passwordTb";
		((AnimaTextBox)this.passwordTb).Numeric = false;
		((AnimaTextBox)this.passwordTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.passwordTb).Size = new System.Drawing.Size(479, 23);
		((System.Windows.Forms.Control)this.passwordTb).TabIndex = 32;
		((AnimaTextBox)this.passwordTb).UseSystemPasswordChar = true;
		((AnimaTextBox)this.loginTb).Dark = false;
		((System.Windows.Forms.Control)this.loginTb).Location = new System.Drawing.Point(42, 69);
		((AnimaTextBox)this.loginTb).MaxLength = 32767;
		((AnimaTextBox)this.loginTb).MultiLine = false;
		((System.Windows.Forms.Control)this.loginTb).Name = "loginTb";
		((AnimaTextBox)this.loginTb).Numeric = false;
		((AnimaTextBox)this.loginTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.loginTb).Size = new System.Drawing.Size(479, 23);
		((System.Windows.Forms.Control)this.loginTb).TabIndex = 31;
		((AnimaTextBox)this.loginTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.connectingLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((System.Windows.Forms.Control)this.connectingLbl).Location = new System.Drawing.Point(234, 163);
		((System.Windows.Forms.Control)this.connectingLbl).Name = "connectingLbl";
		((System.Windows.Forms.Control)this.connectingLbl).Size = new System.Drawing.Size(88, 23);
		((MetroSetLabel)this.connectingLbl).Style = (Style)1;
		((MetroSetLabel)this.connectingLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.connectingLbl).TabIndex = 33;
		((System.Windows.Forms.Control)this.connectingLbl).Text = "Connecting..";
		((MetroSetLabel)this.connectingLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.connectingLbl).ThemeName = "MetroDark";
		((System.Windows.Forms.Control)this.connectingLbl).Visible = false;
		base.AcceptButton = (System.Windows.Forms.IButtonControl)this.signInBtn;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(547, 200);
		base.Controls.Add((System.Windows.Forms.Control)this.connectingLbl);
		base.Controls.Add((System.Windows.Forms.Control)this.passwordTb);
		base.Controls.Add((System.Windows.Forms.Control)this.loginTb);
		base.Controls.Add((System.Windows.Forms.Control)this.signInBtn);
		base.Controls.Add((System.Windows.Forms.Control)this.passwordLbl);
		base.Controls.Add((System.Windows.Forms.Control)this.loginLbl);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "AuthFrm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "RedLine | Log In";
		base.Paint += new System.Windows.Forms.PaintEventHandler(AuthFrm_Paint);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		base.ResumeLayout(false);
	}
}
