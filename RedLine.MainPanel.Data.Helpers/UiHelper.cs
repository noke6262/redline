using System;
using System.Drawing;
using RedLine.MainPanel.Models.UI;

namespace RedLine.MainPanel.Data.Helpers;

public static class UiHelper
{
	public static Rectangle FullRectangle(Size S, bool Subtract)
	{
		if (Subtract)
		{
			return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
		}
		return new Rectangle(0, 0, S.Width, S.Height);
	}

	public static Color GreyColor(uint G)
	{
		return Color.FromArgb((int)G, (int)G, (int)G);
	}

	public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
	{
		SizeF sizeF = G.MeasureString(T, F);
		using SolidBrush brush = new SolidBrush(C);
		G.DrawString(T, F, brush, new Point(R.Width / 2 - (int)(sizeF.Width / 2f), R.Height / 2 - (int)(sizeF.Height / 2f)));
	}

	public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Brush B)
	{
		G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
		G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
		G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
		G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
		G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
		G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
		G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
	}

	public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Pen PP)
	{
		G.DrawArc(PP, R.X, R.Y, Curve, Curve, 180, 90);
		G.DrawLine(PP, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
		G.DrawArc(PP, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
		G.DrawLine(PP, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
		G.DrawLine(PP, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
		G.DrawLine(PP, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
		G.DrawArc(PP, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
		G.DrawArc(PP, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
	}

	public static void DrawTriangle(Graphics G, Rectangle Rect, Direction D, Color C)
	{
		int num = Rect.Width / 2;
		int num2 = Rect.Height / 2;
		Point point = Point.Empty;
		Point point2 = Point.Empty;
		Point point3 = Point.Empty;
		switch (D)
		{
		case Direction.Up:
			point = new Point(Rect.Left + num, Rect.Top);
			point2 = new Point(Rect.Left, Rect.Bottom);
			point3 = new Point(Rect.Right, Rect.Bottom);
			break;
		case Direction.Down:
			point = new Point(Rect.Left + num, Rect.Bottom);
			point2 = new Point(Rect.Left, Rect.Top);
			point3 = new Point(Rect.Right, Rect.Top);
			break;
		case Direction.Left:
			point = new Point(Rect.Left, Rect.Top + num2);
			point2 = new Point(Rect.Right, Rect.Top);
			point3 = new Point(Rect.Right, Rect.Bottom);
			break;
		case Direction.Right:
			point = new Point(Rect.Right, Rect.Top + num2);
			point2 = new Point(Rect.Left, Rect.Bottom);
			point3 = new Point(Rect.Left, Rect.Top);
			break;
		}
		using SolidBrush brush = new SolidBrush(C);
		G.FillPolygon(brush, new Point[3] { point, point2, point3 });
	}

	public static Color ColorFromHex(string Hex)
	{
		return ColorTranslator.FromHtml("#" + Hex);
	}
}
