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

public class PassViewer : Form
{
	[CompilerGenerated]
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object passwordsListView;

	private object object_2;

	private object hostDataGridViewTextBoxColumn;

	private object loginDataGridViewTextBoxColumn;

	private object passwordDataGridViewTextBoxColumn;

	private object m_a;

	private object b;

	private object m_c;

	private object m_d;

	private object e;

	private object f;

	private object searchTb;

	private BindingList<LoginPair> Logins
	{
		[CompilerGenerated]
		get
		{
			return (BindingList<LoginPair>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public PassViewer(BindingList<LoginPair> _pairs)
	{
		c();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		Logins = _pairs;
		((DataGridView)passwordsListView).DataSource = Logins;
	}

	private void closeBtn_Click(object sender, object e)
	{
		Logins = null;
		Close();
	}

	private void c_Click(object sender, object e)
	{
		LoginPair selectedItem = (LoginPair)((DataGridView)passwordsListView).SelectedRows[0].DataBoundItem;
		Thread thread = new Thread((ThreadStart)delegate
		{
			Clipboard.SetText("Host: " + selectedItem.Host + "\nLogin: " + selectedItem.Login + "\nPassword: " + selectedItem.Password, TextDataFormat.Text);
		});
		thread.ApartmentState = ApartmentState.STA;
		thread.IsBackground = true;
		thread.Start();
		MessageBox.Show(this, "Successfully saved to clipboard");
	}

	private void b_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((DataGridView)passwordsListView).SelectedRows.Count == 0;
	}

	private void d_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchTb).Text))
		{
			return;
		}
		BindingList<LoginPair> bindingList = new BindingList<LoginPair>();
		foreach (LoginPair login in Logins)
		{
			if (login.Host.Contains(((AnimaTextBox)searchTb).Text))
			{
				bindingList.Add(login);
			}
		}
		((DataGridView)passwordsListView).DataSource = bindingList;
	}

	private void method_0(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchTb).Text))
		{
			((DataGridView)passwordsListView).DataSource = Logins;
		}
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void PassViewer_Paint(object sender, object e)
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
					BindingList<LoginPair> bindingList = ((DataGridView)passwordsListView).DataSource as BindingList<LoginPair>;
					foreach (LoginPair item in bindingList)
					{
						stringBuilder.Append("URL: ").Append(item.Host).Append(Environment.NewLine)
							.Append("Username: ")
							.Append(item.Login)
							.Append(Environment.NewLine)
							.Append("Password: ")
							.Append(item.Password)
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		object_1 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(PassViewer));
		topHeader = new Panel();
		mainTitle = new Label();
		closeBtn = new Label();
		passwordsListView = new DataGridView();
		hostDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		loginDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		passwordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		b = new ContextMenuStrip((IContainer)object_1);
		this.m_c = new ToolStripMenuItem();
		this.m_a = new BindingSource((IContainer)object_1);
		this.m_d = (object)new MetroSetButton();
		e = new Label();
		object_2 = new BindingSource((IContainer)object_1);
		f = (object)new MetroSetButton();
		searchTb = (object)new AnimaTextBox();
		((Control)topHeader).SuspendLayout();
		((ISupportInitialize)passwordsListView).BeginInit();
		((Control)b).SuspendLayout();
		((ISupportInitialize)this.m_a).BeginInit();
		((ISupportInitialize)object_2).BeginInit();
		SuspendLayout();
		((Control)topHeader).BackColor = Color.FromArgb(52, 56, 67);
		((Control)topHeader).Controls.Add((Control)mainTitle);
		((Control)topHeader).Controls.Add((Control)closeBtn);
		((Control)topHeader).Dock = DockStyle.Top;
		((Control)topHeader).ForeColor = Color.Silver;
		((Control)topHeader).Location = new Point(0, 0);
		((Control)topHeader).Name = "topHeader";
		((Control)topHeader).Size = new Size(680, 30);
		((Control)topHeader).TabIndex = 2;
		((Control)topHeader).Paint += topHeader_Paint;
		((Control)mainTitle).AutoSize = true;
		((Control)mainTitle).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)mainTitle).ForeColor = Color.Red;
		((Control)mainTitle).Location = new Point(3, 4);
		((Control)mainTitle).Name = "mainTitle";
		((Control)mainTitle).Size = new Size(184, 20);
		((Control)mainTitle).TabIndex = 2;
		((Control)mainTitle).Text = "RedLine | Password Viewer";
		((Control)closeBtn).AutoSize = true;
		((Control)closeBtn).Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		((Control)closeBtn).ForeColor = Color.White;
		((Control)closeBtn).Location = new Point(657, 4);
		((Control)closeBtn).Name = "closeBtn";
		((Control)closeBtn).Size = new Size(20, 21);
		((Control)closeBtn).TabIndex = 1;
		((Control)closeBtn).Text = "X";
		((Control)closeBtn).Click += closeBtn_Click;
		((DataGridView)passwordsListView).AllowUserToAddRows = false;
		((DataGridView)passwordsListView).AllowUserToDeleteRows = false;
		((DataGridView)passwordsListView).AllowUserToResizeColumns = false;
		((DataGridView)passwordsListView).AllowUserToResizeRows = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.Silver;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		((DataGridView)passwordsListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		((DataGridView)passwordsListView).AutoGenerateColumns = false;
		((DataGridView)passwordsListView).BackgroundColor = Color.FromArgb(52, 56, 67);
		((DataGridView)passwordsListView).BorderStyle = BorderStyle.None;
		((DataGridView)passwordsListView).CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
		((DataGridView)passwordsListView).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		((DataGridView)passwordsListView).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.Silver;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		((DataGridView)passwordsListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		((DataGridView)passwordsListView).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((DataGridView)passwordsListView).Columns.AddRange((DataGridViewColumn)hostDataGridViewTextBoxColumn, (DataGridViewColumn)loginDataGridViewTextBoxColumn, (DataGridViewColumn)passwordDataGridViewTextBoxColumn);
		((Control)passwordsListView).ContextMenuStrip = (ContextMenuStrip)b;
		((DataGridView)passwordsListView).DataSource = this.m_a;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		((DataGridView)passwordsListView).DefaultCellStyle = dataGridViewCellStyle3;
		((DataGridView)passwordsListView).EditMode = DataGridViewEditMode.EditOnEnter;
		((DataGridView)passwordsListView).EnableHeadersVisualStyles = false;
		((DataGridView)passwordsListView).GridColor = Color.FromArgb(52, 60, 67);
		((Control)passwordsListView).Location = new Point(15, 36);
		((DataGridView)passwordsListView).MultiSelect = false;
		((Control)passwordsListView).Name = "passwordsListView";
		((DataGridView)passwordsListView).ReadOnly = true;
		((DataGridView)passwordsListView).RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		((DataGridView)passwordsListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		((DataGridView)passwordsListView).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle5.ForeColor = Color.Silver;
		((DataGridView)passwordsListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
		((DataGridView)passwordsListView).RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)passwordsListView).RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(52, 56, 67);
		((DataGridView)passwordsListView).RowTemplate.DefaultCellStyle.ForeColor = Color.Silver;
		((DataGridView)passwordsListView).ScrollBars = ScrollBars.Vertical;
		((DataGridView)passwordsListView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)passwordsListView).ShowEditingIcon = false;
		((Control)passwordsListView).Size = new Size(656, 548);
		((Control)passwordsListView).TabIndex = 16;
		((DataGridViewColumn)hostDataGridViewTextBoxColumn).DataPropertyName = "Host";
		((DataGridViewColumn)hostDataGridViewTextBoxColumn).HeaderText = "Host";
		((DataGridViewColumn)hostDataGridViewTextBoxColumn).MinimumWidth = 200;
		((DataGridViewColumn)hostDataGridViewTextBoxColumn).Name = "hostDataGridViewTextBoxColumn";
		((DataGridViewBand)hostDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewBand)hostDataGridViewTextBoxColumn).Resizable = DataGridViewTriState.False;
		((DataGridViewColumn)hostDataGridViewTextBoxColumn).Width = 200;
		((DataGridViewColumn)loginDataGridViewTextBoxColumn).DataPropertyName = "Login";
		((DataGridViewColumn)loginDataGridViewTextBoxColumn).HeaderText = "Login";
		((DataGridViewColumn)loginDataGridViewTextBoxColumn).MinimumWidth = 200;
		((DataGridViewColumn)loginDataGridViewTextBoxColumn).Name = "loginDataGridViewTextBoxColumn";
		((DataGridViewBand)loginDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewBand)loginDataGridViewTextBoxColumn).Resizable = DataGridViewTriState.False;
		((DataGridViewColumn)loginDataGridViewTextBoxColumn).Width = 200;
		((DataGridViewColumn)passwordDataGridViewTextBoxColumn).DataPropertyName = "Password";
		((DataGridViewColumn)passwordDataGridViewTextBoxColumn).HeaderText = "Password";
		((DataGridViewColumn)passwordDataGridViewTextBoxColumn).MinimumWidth = 200;
		((DataGridViewColumn)passwordDataGridViewTextBoxColumn).Name = "passwordDataGridViewTextBoxColumn";
		((DataGridViewBand)passwordDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewBand)passwordDataGridViewTextBoxColumn).Resizable = DataGridViewTriState.False;
		((DataGridViewColumn)passwordDataGridViewTextBoxColumn).Width = 200;
		((ToolStrip)b).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)this.m_c });
		((Control)b).Name = "logContextMenu";
		((Control)b).Size = new Size(103, 26);
		((ToolStripDropDown)b).Opening += b_Opening;
		((ToolStripItem)this.m_c).Name = "copyToolStripMenuItem";
		((ToolStripItem)this.m_c).Size = new Size(102, 22);
		((ToolStripItem)this.m_c).Text = "Copy";
		((ToolStripItem)this.m_c).Click += c_Click;
		((BindingSource)this.m_a).DataSource = typeof(LoginPair);
		((MetroSetButton)this.m_d).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_d).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_d).DisabledForeColor = Color.Gray;
		((Control)this.m_d).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_d).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_d).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_d).HoverTextColor = Color.White;
		((Control)this.m_d).Location = new Point(557, 615);
		((Control)this.m_d).Name = "clearBtn";
		((MetroSetButton)this.m_d).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_d).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_d).NormalTextColor = Color.White;
		((MetroSetButton)this.m_d).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_d).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_d).PressTextColor = Color.White;
		((Control)this.m_d).Size = new Size(102, 20);
		((MetroSetButton)this.m_d).Style = (Style)0;
		((MetroSetButton)this.m_d).StyleManager = null;
		((Control)this.m_d).TabIndex = 18;
		((Control)this.m_d).Text = "Search";
		((MetroSetButton)this.m_d).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_d).ThemeName = "MetroLite";
		((Control)this.m_d).Click += d_Click;
		((Control)e).AutoSize = true;
		((Control)e).Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)e).ForeColor = Color.White;
		((Control)e).Location = new Point(36, 595);
		((Control)e).Name = "label1";
		((Control)e).Size = new Size(72, 15);
		((Control)e).TabIndex = 20;
		((Control)e).Text = "Enter a host:";
		((BindingSource)object_2).DataSource = typeof(Credentials);
		((MetroSetButton)f).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)f).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)f).DisabledForeColor = Color.Gray;
		((Control)f).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)f).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)f).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)f).HoverTextColor = Color.White;
		((Control)f).Location = new Point(557, 590);
		((Control)f).Name = "saveBtn";
		((MetroSetButton)f).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)f).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)f).NormalTextColor = Color.White;
		((MetroSetButton)f).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)f).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)f).PressTextColor = Color.White;
		((Control)f).Size = new Size(102, 20);
		((MetroSetButton)f).Style = (Style)0;
		((MetroSetButton)f).StyleManager = null;
		((Control)f).TabIndex = 22;
		((Control)f).Text = "Save list";
		((MetroSetButton)f).ThemeAuthor = "Narwin";
		((MetroSetButton)f).ThemeName = "MetroLite";
		((Control)f).Click += a;
		((AnimaTextBox)searchTb).Dark = false;
		((Control)searchTb).Location = new Point(34, 613);
		((AnimaTextBox)searchTb).MaxLength = 32767;
		((AnimaTextBox)searchTb).MultiLine = false;
		((Control)searchTb).Name = "searchTb";
		((AnimaTextBox)searchTb).Numeric = false;
		((AnimaTextBox)searchTb).ReadOnly = false;
		((Control)searchTb).Size = new Size(517, 23);
		((Control)searchTb).TabIndex = 32;
		((AnimaTextBox)searchTb).UseSystemPasswordChar = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(52, 56, 67);
		base.ClientSize = new Size(680, 647);
		base.Controls.Add((Control)searchTb);
		base.Controls.Add((Control)f);
		base.Controls.Add((Control)e);
		base.Controls.Add((Control)this.m_d);
		base.Controls.Add((Control)passwordsListView);
		base.Controls.Add((Control)topHeader);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "PassViewer";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "PassViewer";
		base.Paint += PassViewer_Paint;
		((Control)topHeader).ResumeLayout(performLayout: false);
		((Control)topHeader).PerformLayout();
		((ISupportInitialize)passwordsListView).EndInit();
		((Control)b).ResumeLayout(performLayout: false);
		((ISupportInitialize)this.m_a).EndInit();
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
			BindingList<LoginPair> bindingList = ((DataGridView)passwordsListView).DataSource as BindingList<LoginPair>;
			foreach (LoginPair item in bindingList)
			{
				stringBuilder.Append("URL: ").Append(item.Host).Append(Environment.NewLine)
					.Append("Username: ")
					.Append(item.Login)
					.Append(Environment.NewLine)
					.Append("Password: ")
					.Append(item.Password)
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
