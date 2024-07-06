using System;
using System.Runtime.CompilerServices;

namespace RedLine.MainPanel.Models.BTC;

public class TxRef
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
	private DateTime dateTime_0;

	[CompilerGenerated]
	private IntPtr intptr_6;

	[CompilerGenerated]
	private bool? nullable_0;

	[CompilerGenerated]
	private object a;

	public string tx_hash
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

	public int block_height
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

	public int tx_input_n
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

	public int tx_output_n
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

	public int value
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

	public int ref_balance
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

	public int confirmations
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

	public DateTime confirmed
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

	public bool double_spend
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

	public bool? spent
	{
		[CompilerGenerated]
		get
		{
			return nullable_0;
		}
		[CompilerGenerated]
		set
		{
			nullable_0 = value;
		}
	}

	public string spent_by
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
