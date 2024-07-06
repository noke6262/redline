using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using RedLine.MainPanel.Data.Helpers;

namespace RedLine.MainPanel.Data.UI;

public class AetherTabControl : TabControl
{
	private IntPtr intptr_0 = (IntPtr)1;

	private object object_0;

	private Rectangle rectangle_0;

	private SizeF sizeF_0;

	private SizeF sizeF_1;

	[CompilerGenerated]
	private IntPtr intptr_1;

	public bool UpperText
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

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams obj = base.CreateParams;
			obj.ExStyle |= 33554432;
			return obj;
		}
	}

	public AetherTabControl()
	{
		DoubleBuffered = true;
		base.Alignment = TabAlignment.Left;
		base.SizeMode = TabSizeMode.Fixed;
		base.ItemSize = new Size(40, 190);
		Dock = DockStyle.Fill;
	}

	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		SetStyle(ControlStyles.UserPaint, value: true);
	}

	protected override void OnControlAdded(ControlEventArgs e)
	{
		base.OnControlAdded(e);
		e.Control.BackColor = Color.FromArgb(52, 56, 67);
		e.Control.ForeColor = UiHelper.ColorFromHex("343843");
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		object_0 = e.Graphics;
		((Graphics)object_0).SmoothingMode = SmoothingMode.HighSpeed;
		((Graphics)object_0).TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		base.OnPaint(e);
		((Graphics)object_0).Clear(UiHelper.ColorFromHex("343843"));
		for (int i = 0; i <= base.TabPages.Count - 1; i++)
		{
			rectangle_0 = GetTabRect(i);
			if (base.SelectedIndex == i)
			{
				using SolidBrush brush = new SolidBrush(UiHelper.ColorFromHex("3A3E49"));
				((Graphics)object_0).FillRectangle((Brush)brush, new Rectangle(rectangle_0.X - 4, rectangle_0.Y + 1, rectangle_0.Width + 6, rectangle_0.Height));
			}
			using (SolidBrush brush2 = new SolidBrush(UiHelper.ColorFromHex("737E8A")))
			{
				if (UpperText)
				{
					using Font font = new Font("Segoe UI", 7.75f, FontStyle.Bold);
					((Graphics)object_0).DrawString(base.TabPages[i].Text.ToUpper(), font, (Brush)brush2, (PointF)new Point(rectangle_0.X + 50, rectangle_0.Y + 13));
				}
				else
				{
					using Font font2 = new Font("Segoe UI semibold", 9f);
					((Graphics)object_0).DrawString(base.TabPages[i].Text, font2, (Brush)brush2, (PointF)new Point(rectangle_0.X + 50, rectangle_0.Y + 11));
				}
			}
			if (base.TabPages[i].Tag != null)
			{
				if (UpperText)
				{
					using Font font3 = new Font("Segoe UI", 7.75f, FontStyle.Bold);
					sizeF_0 = ((Graphics)object_0).MeasureString(base.TabPages[i].Text, font3);
				}
				else
				{
					using Font font4 = new Font("Segoe UI semibold", 9f);
					sizeF_0 = ((Graphics)object_0).MeasureString(base.TabPages[i].Text, font4);
				}
				using (Font font5 = new Font("Segoe UI", 9f))
				{
					sizeF_1 = ((Graphics)object_0).MeasureString(base.TabPages[i].Tag.ToString(), font5);
				}
				if (!string.IsNullOrWhiteSpace(base.TabPages[i].Tag.ToString()))
				{
					using SolidBrush brush3 = new SolidBrush(UiHelper.ColorFromHex("B63A1B"));
					using Pen pP = new Pen(UiHelper.ColorFromHex("B63A1B"));
					using SolidBrush brush4 = new SolidBrush(UiHelper.ColorFromHex("F5F6EB"));
					((Graphics)object_0).FillRectangle((Brush)brush3, new Rectangle(rectangle_0.X + (int)sizeF_0.Width + 72, rectangle_0.Y + 12, (int)sizeF_1.Width + 5, 15));
					UiHelper.DrawRoundRect((Graphics)object_0, new Rectangle(rectangle_0.X + (int)sizeF_0.Width + 72, rectangle_0.Y + 12, (int)sizeF_1.Width + 5, 15), 3, pP);
					if (int.TryParse(base.TabPages[i].Tag.ToString(), out var _))
					{
						using Font font6 = new Font("Segoe UI", 8f, FontStyle.Bold);
						((Graphics)object_0).DrawString(base.TabPages[i].Tag.ToString(), font6, (Brush)brush4, (PointF)new Point(rectangle_0.X + (int)sizeF_0.Width + 75, rectangle_0.Y + 13));
					}
					else
					{
						using Font font7 = new Font("Segoe UI", 7f, FontStyle.Bold);
						((Graphics)object_0).DrawString(base.TabPages[i].Tag.ToString().ToUpper(), font7, (Brush)brush4, (PointF)new Point(rectangle_0.X + (int)sizeF_0.Width + 75, rectangle_0.Y + 13));
					}
				}
			}
			if (i != 0)
			{
				using Pen pen = new Pen(UiHelper.ColorFromHex("3B3D49"));
				using Pen pen2 = new Pen(UiHelper.ColorFromHex("2F323C"));
				((Graphics)object_0).DrawLine(pen, new Point(rectangle_0.X - 4, rectangle_0.Y + 1), new Point(rectangle_0.Width + 4, rectangle_0.Y + 1));
				((Graphics)object_0).DrawLine(pen2, new Point(rectangle_0.X - 4, rectangle_0.Y + 2), new Point(rectangle_0.Width + 4, rectangle_0.Y + 2));
			}
			if (base.ImageList != null && base.TabPages[i].ImageIndex >= 0)
			{
				((Graphics)object_0).DrawImage(base.ImageList.Images[base.TabPages[i].ImageIndex], new Rectangle(rectangle_0.X + 18, rectangle_0.Y + (rectangle_0.Height / 2 - 8), 16, 16));
			}
		}
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen3 = new Pen(Color.Red, 3f);
		e.Graphics.DrawRectangle(pen3, 0, 0, num, num2);
	}
}
