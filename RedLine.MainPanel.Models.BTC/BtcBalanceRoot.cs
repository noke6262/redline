using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RedLine.MainPanel.Models.BTC;

public class BtcBalanceRoot
{
	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private IntPtr intptr_3;

	[CompilerGenerated]
	private IntPtr intptr_4;

	[CompilerGenerated]
	private IntPtr intptr_5;

	[CompilerGenerated]
	private IntPtr intptr_6;

	[CompilerGenerated]
	private IntPtr intptr_7;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private object a;

	public string address
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

	public int total_received
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)value;
		}
	}

	public int total_sent
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_1;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)value;
		}
	}

	public int balance
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_2;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)value;
		}
	}

	public int unconfirmed_balance
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

	public int final_balance
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

	public int n_tx
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_5;
		}
		[CompilerGenerated]
		set
		{
			intptr_5 = (IntPtr)value;
		}
	}

	public int unconfirmed_n_tx
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_6;
		}
		[CompilerGenerated]
		set
		{
			intptr_6 = (IntPtr)value;
		}
	}

	public int final_n_tx
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_7;
		}
		[CompilerGenerated]
		set
		{
			intptr_7 = (IntPtr)value;
		}
	}

	public List<TxRef> txrefs
	{
		[CompilerGenerated]
		get
		{
			return (List<TxRef>)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	public string tx_url
	{
		[CompilerGenerated]
		get
		{
			return (string)a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}
}
