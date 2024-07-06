using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RedLine.MainPanel.Data.UI;

[ToolboxBitmap(typeof(Button))]
public class AnimatedButton : Button
{
	private object object_0;

	private object object_1 = global::_003CModule_003E.smethod_6<int[]>(-902085065);

	private IntPtr intptr_0 = (IntPtr)45;

	private object object_2;

	private object object_3;

	private IntPtr intptr_1;

	public AnimatedButton()
	{
		DoubleBuffered = true;
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		object_0 = e.Graphics;
		((Graphics)object_0).Clear(BackColor);
		using (Pen pen = new Pen(Color.FromArgb(((int[])object_1)[0], ((int[])object_1)[1], ((int[])object_1)[2])))
		{
			((Graphics)object_0).DrawRectangle(pen, new Rectangle(0, 0, base.Width - 1, base.Height - 1));
		}
		TextRenderer.DrawText(e.Graphics, Text, Font, new Point(base.Width + 3, base.Height / 2), ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
	}

	public void Animate()
	{
		object_2 = new Thread(method_0)
		{
			IsBackground = true,
			ApartmentState = ApartmentState.STA
		};
		((Thread)object_2).Start();
	}

	public void UnSelect()
	{
		object_3 = new Thread(method_1)
		{
			IsBackground = true,
			ApartmentState = ApartmentState.STA
		};
		((Thread)object_3).Start();
	}

	private void method_0()
	{
		while (intptr_1 != (IntPtr)0)
		{
			Thread.Sleep(5);
		}
		while (((int[])object_1)[2] < 204 && intptr_1 == (IntPtr)0)
		{
			((int[])object_1)[1]++;
			((int[])object_1)[2] += 2;
			Invalidate();
			Thread.Sleep(5);
		}
	}

	private void method_1()
	{
		intptr_1 = (IntPtr)1;
		while (((int[])object_1)[2] > (nint)intptr_0)
		{
			((int[])object_1)[1]--;
			((int[])object_1)[2] -= 2;
			Invalidate();
			Thread.Sleep(5);
		}
		intptr_1 = (IntPtr)0;
	}
}
