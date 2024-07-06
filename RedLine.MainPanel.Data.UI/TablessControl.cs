using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RedLine.MainPanel.Data.UI;

[ToolboxBitmap(typeof(TabControl))]
public class TablessControl : TabControl
{
	private IntPtr intptr_0;

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(false)]
	public bool HideTabs
	{
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		set
		{
			if (intptr_0 != (IntPtr)(value ? 1 : 0))
			{
				intptr_0 = (IntPtr)(value ? 1 : 0);
				if (value)
				{
					Multiline = true;
				}
				UpdateStyles();
			}
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	public new bool Multiline
	{
		get
		{
			if (HideTabs)
			{
				return true;
			}
			return base.Multiline;
		}
		set
		{
			if (HideTabs)
			{
				base.Multiline = true;
			}
			else
			{
				base.Multiline = value;
			}
		}
	}

	public override Rectangle DisplayRectangle
	{
		get
		{
			if (HideTabs)
			{
				return new Rectangle(0, 0, base.Width, base.Height);
			}
			int num = ((base.Alignment <= TabAlignment.Bottom) ? base.ItemSize.Height : base.ItemSize.Width);
			int num2 = ((base.Appearance == TabAppearance.Normal) ? (5 + num * base.RowCount) : ((3 + num) * base.RowCount));
			return base.Alignment switch
			{
				TabAlignment.Bottom => new Rectangle(4, 4, base.Width - 8, base.Height - num2 - 4), 
				TabAlignment.Left => new Rectangle(num2, 4, base.Width - num2 - 4, base.Height - 8), 
				TabAlignment.Right => new Rectangle(4, 4, base.Width - num2 - 4, base.Height - 8), 
				_ => new Rectangle(4, num2, base.Width - 8, base.Height - num2 - 4), 
			};
		}
	}
}
