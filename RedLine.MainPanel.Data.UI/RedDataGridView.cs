using System.Drawing;
using System.Windows.Forms;

namespace RedLine.MainPanel.Data.UI;

public class RedDataGridView : DataGridView
{
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		int num = 30;
		for (int i = 0; i < base.ColumnCount; i++)
		{
			DataGridViewColumn dataGridViewColumn = base.Columns[i];
			if (!dataGridViewColumn.Visible)
			{
				continue;
			}
			Graphics graphics = e.Graphics;
			using (Pen pen = new Pen(Color.FromArgb(240, 39, 58), 3f))
			{
				float num2 = graphics.MeasureString(dataGridViewColumn.HeaderText, base.DefaultCellStyle.Font, 0, StringFormat.GenericTypographic).Width;
				float num3 = ((float)dataGridViewColumn.Width - num2) / 2f;
				float num4 = (float)num + num3;
				if (!(dataGridViewColumn.ValueType == typeof(bool)))
				{
					graphics.DrawLine(pen, new PointF(num4, 37f), new PointF(num4 + num2, 37f));
				}
				else
				{
					graphics.DrawLine(pen, new PointF(num4 + 10f, 37f), new PointF(num4 + num2 + 10f, 37f));
				}
			}
			num += dataGridViewColumn.Width + dataGridViewColumn.DividerWidth;
		}
	}
}
