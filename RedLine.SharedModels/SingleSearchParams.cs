using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace RedLine.SharedModels;

public class SingleSearchParams
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private object object_4;

	[CompilerGenerated]
	private object object_5;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private DateTime dateTime_1;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr a;

	[CompilerGenerated]
	private IntPtr b;

	[CompilerGenerated]
	private IntPtr c;

	[CompilerGenerated]
	private IntPtr d;

	[CompilerGenerated]
	private IntPtr e;

	[CompilerGenerated]
	private IntPtr f;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private IntPtr intptr_3 = (IntPtr)(-1);

	[CompilerGenerated]
	private IntPtr intptr_4 = (IntPtr)(-1);

	[CompilerGenerated]
	private object object_6;

	[CompilerGenerated]
	private object object_7;

	[CompilerGenerated]
	private object object_8;

	[CompilerGenerated]
	private IntPtr intptr_5;

	[CompilerGenerated]
	private object object_9;

	[CompilerGenerated]
	private IntPtr intptr_6;

	[CompilerGenerated]
	private IntPtr intptr_7;

	[CompilerGenerated]
	private IntPtr intptr_8;

	[CompilerGenerated]
	private IntPtr intptr_9;

	[CompilerGenerated]
	private IntPtr intptr_10;

	[CompilerGenerated]
	private IntPtr intptr_11;

	public string Country
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

	public string BuildID
	{
		[CompilerGenerated]
		get
		{
			return (string)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public string OS
	{
		[CompilerGenerated]
		get
		{
			return (string)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	public string PasswordDomain
	{
		[CompilerGenerated]
		get
		{
			return (string)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	public string CookieDomain
	{
		[CompilerGenerated]
		get
		{
			return (string)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	public string FilesToSearch
	{
		[CompilerGenerated]
		get
		{
			return (string)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	public DateTime LogFrom
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public DateTime LogTo
	{
		[CompilerGenerated]
		get
		{
			return dateTime_1;
		}
		[CompilerGenerated]
		set
		{
			dateTime_1 = value;
		}
	}

	public bool ContainsCCs
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

	public bool ContainsAFs
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_1 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool ContainsFTPs
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)a != 0;
		}
		[CompilerGenerated]
		set
		{
			a = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool ContainsFiles
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)b != 0;
		}
		[CompilerGenerated]
		set
		{
			b = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool ContainsWallets
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)c != 0;
		}
		[CompilerGenerated]
		set
		{
			c = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool ContainsTelegram
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)d != 0;
		}
		[CompilerGenerated]
		set
		{
			d = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool ContainsSteam
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)e != 0;
		}
		[CompilerGenerated]
		set
		{
			e = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool SkipCookies
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)f != 0;
		}
		[CompilerGenerated]
		set
		{
			f = (IntPtr)(value ? 1 : 0);
		}
	}

	public bool SkipPasswords
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_2 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)(value ? 1 : 0);
		}
	}

	public int PasswordsMoreThan
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_3;
		}
		[CompilerGenerated]
		set
		{
			intptr_3 = (IntPtr)value;
		}
	}

	public int CookiesMoreThan
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_4;
		}
		[CompilerGenerated]
		set
		{
			intptr_4 = (IntPtr)value;
		}
	}

	[JsonIgnore]
	public string Comment
	{
		[CompilerGenerated]
		get
		{
			return (string)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	[JsonIgnore]
	public string SkipComment
	{
		[CompilerGenerated]
		get
		{
			return (string)object_7;
		}
		[CompilerGenerated]
		set
		{
			object_7 = value;
		}
	}

	[JsonIgnore]
	public string SetComment
	{
		[CompilerGenerated]
		get
		{
			return (string)object_8;
		}
		[CompilerGenerated]
		set
		{
			object_8 = value;
		}
	}

	[JsonIgnore]
	public bool SaveAccounts
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_5 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_5 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonIgnore]
	public string SavingFormat
	{
		[CompilerGenerated]
		get
		{
			return (string)object_9;
		}
		[CompilerGenerated]
		set
		{
			object_9 = value;
		}
	}

	[JsonIgnore]
	public bool RefreshDD
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_6 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_6 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonIgnore]
	public bool SkipChecked
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_7 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_7 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonIgnore]
	public bool RemoveEmptyLogs
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_8 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_8 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonIgnore]
	public bool RemoveCheckedLogs
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_9 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_9 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonIgnore]
	public bool SaveFtps
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_10 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_10 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonIgnore]
	public bool SaveDisordTokens
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_11 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_11 = (IntPtr)(value ? 1 : 0);
		}
	}
}
