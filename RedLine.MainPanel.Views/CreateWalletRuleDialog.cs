using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using MetroSet_UI.Enums;
using Microsoft.VisualBasic;
using RedLine.MainPanel.Data.Extensions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class CreateWalletRuleDialog : Form
{
	[CompilerGenerated]
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object object_2;

	private object object_3;

	private object logContextMenu;

	private object copyToolStripMenuItem;

	private object object_4;

	private object m_a;

	private object m_b;

	private object m_c;

	private object d;

	private object m_e;

	private object f;

	private object label3;

	private object label5;

	private object editWalletsRulesListBox;

	private object removeDirBtn;

	private object addNewDirBtn;

	public WalletConfig Config
	{
		[CompilerGenerated]
		get
		{
			return (WalletConfig)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public CreateWalletRuleDialog()
	{
		InitializeComponent();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		LoadConfigs();
	}

	public void PrintArgs()
	{
		((ListBox)editWalletsRulesListBox).Items.Clear();
		ListBox.ObjectCollection items = ((ListBox)editWalletsRulesListBox).Items;
		List<FileScannerArg> scannerArgs = Config.ScannerArgs;
		object obj;
		if (scannerArgs == null)
		{
			obj = null;
		}
		else
		{
			IEnumerable<string> enumerable = scannerArgs.Select((FileScannerArg x) => x.Directory);
			if (enumerable == null)
			{
				obj = null;
			}
			else
			{
				obj = enumerable.ToArray();
				if (obj != null)
				{
					goto IL_0067;
				}
			}
		}
		obj = new string[0];
		goto IL_0067;
		IL_0067:
		object[] items2 = (object[])obj;
		items.AddRange(items2);
	}

	public void LoadConfigs()
	{
		Config = new WalletConfig();
		Config.ScannerArgs = new List<FileScannerArg>();
	}

	private void closeBtn_Click(object sender, object e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void CreateWalletRuleDialog_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void a_Click(object sender, object e)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(((AnimaTextBox)d).Text))
			{
				MessageBox.Show(this, "Enter a name of rule");
			}
			else if (!string.IsNullOrWhiteSpace(((AnimaTextBox)f).Text))
			{
				List<FileScannerArg> scannerArgs = Config.ScannerArgs;
				if (scannerArgs != null && scannerArgs.Count == 0)
				{
					MessageBox.Show(this, "Add directories to search");
					return;
				}
				Config.Name = ((AnimaTextBox)d).Text;
				Config.RootDir = ((AnimaTextBox)f).Text;
				base.DialogResult = DialogResult.OK;
				Close();
			}
			else
			{
				MessageBox.Show(this, "Enter a root directory of rule");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void CreateWalletRuleDialog_Load(object sender, object e)
	{
	}

	private void a(object sender, object e)
	{
	}

	private void b(object sender, object e)
	{
	}

	private void c(object sender, object e)
	{
		try
		{
			FileScannerArg fileScannerArg = RequestScannerArgUI();
			if (fileScannerArg != null)
			{
				Config.ScannerArgs.Add(fileScannerArg);
				PrintArgs();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	public FileScannerArg RequestScannerArgUI()
	{
		string text = Interaction.InputBox("Enter a search directory:", "First step", null);
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		string text2 = Interaction.InputBox("Enter a mask of file:", "Second step", null);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			string text3 = Interaction.InputBox("Use recursive search? Enter True/False", "Second step", null);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				if (text3 != "True" && text3 != "False")
				{
					return null;
				}
				return new FileScannerArg
				{
					Directory = text,
					Pattern = text2,
					Recoursive = (text3 == "True")
				};
			}
			return null;
		}
		return null;
	}

	private void e(object sender, object e)
	{
		try
		{
			if (((ListBox)editWalletsRulesListBox).SelectedItems.Count == 0)
			{
				MessageBox.Show(this, "Select directory to remove");
				return;
			}
			Config.ScannerArgs.RemoveAt(((ListControl)editWalletsRulesListBox).SelectedIndex);
			PrintArgs();
			MessageBox.Show(this, "Successfully removed");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_1 != null)
		{
			((IDisposable)object_1).Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		this.object_1 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.CreateWalletRuleDialog));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_1);
		this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.m_a = (object)new MetroSetButton();
		this.m_b = new System.Windows.Forms.Label();
		this.m_c = (object)new MetroSetDivider();
		this.d = (object)new AnimaTextBox();
		this.m_e = new System.Windows.Forms.Label();
		this.f = (object)new AnimaTextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.editWalletsRulesListBox = new System.Windows.Forms.ListBox();
		this.removeDirBtn = (object)new MetroSetButton();
		this.addNewDirBtn = (object)new MetroSetButton();
		this.object_4 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_1);
		this.object_3 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_1);
		this.object_2 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_1);
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		((System.Windows.Forms.Control)this.logContextMenu).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.object_4).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_2).BeginInit();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(306, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 2;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(262, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Wallet Grabber Configurator";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(283, 4);
		((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
		((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
		((System.Windows.Forms.Control)this.closeBtn).Text = "X";
		((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
		((System.Windows.Forms.ToolStrip)this.logContextMenu).Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { (System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem });
		((System.Windows.Forms.Control)this.logContextMenu).Name = "logContextMenu";
		((System.Windows.Forms.Control)this.logContextMenu).Size = new System.Drawing.Size(103, 26);
		((System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem).Name = "copyToolStripMenuItem";
		((System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem).Size = new System.Drawing.Size(102, 22);
		((System.Windows.Forms.ToolStripItem)this.copyToolStripMenuItem).Text = "Copy";
		((MetroSetButton)this.m_a).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.m_a).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.m_a).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.m_a).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.m_a).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a).Location = new System.Drawing.Point(94, 407);
		((System.Windows.Forms.Control)this.m_a).Name = "addRuleBtn";
		((MetroSetButton)this.m_a).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.m_a).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a).Size = new System.Drawing.Size(119, 20);
		((MetroSetButton)this.m_a).Style = (Style)0;
		((MetroSetButton)this.m_a).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a).TabIndex = 23;
		((System.Windows.Forms.Control)this.m_a).Text = "Save wallet rule";
		((MetroSetButton)this.m_a).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.m_a).Click += new System.EventHandler(a_Click);
		((System.Windows.Forms.Control)this.m_b).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_b).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.m_b).Location = new System.Drawing.Point(12, 38);
		((System.Windows.Forms.Control)this.m_b).Name = "label1";
		((System.Windows.Forms.Control)this.m_b).Size = new System.Drawing.Size(284, 20);
		((System.Windows.Forms.Control)this.m_b).TabIndex = 131;
		((System.Windows.Forms.Control)this.m_b).Text = "Create new rule";
		((System.Windows.Forms.Label)this.m_b).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.m_c).Location = new System.Drawing.Point(0, 393);
		((System.Windows.Forms.Control)this.m_c).Name = "metroSetDivider1";
		((MetroSetDivider)this.m_c).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.m_c).Size = new System.Drawing.Size(306, 4);
		((MetroSetDivider)this.m_c).Style = (Style)1;
		((MetroSetDivider)this.m_c).StyleManager = null;
		((System.Windows.Forms.Control)this.m_c).TabIndex = 133;
		((System.Windows.Forms.Control)this.m_c).Text = "metroSetDivider1";
		((MetroSetDivider)this.m_c).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.m_c).ThemeName = "MetroDark";
		((MetroSetDivider)this.m_c).Thickness = 1;
		((AnimaTextBox)this.d).Dark = false;
		((System.Windows.Forms.Control)this.d).Location = new System.Drawing.Point(56, 64);
		((AnimaTextBox)this.d).MaxLength = 32767;
		((AnimaTextBox)this.d).MultiLine = false;
		((System.Windows.Forms.Control)this.d).Name = "editRuleNameTb";
		((AnimaTextBox)this.d).Numeric = false;
		((AnimaTextBox)this.d).ReadOnly = false;
		((System.Windows.Forms.Control)this.d).Size = new System.Drawing.Size(240, 23);
		((System.Windows.Forms.Control)this.d).TabIndex = 145;
		((AnimaTextBox)this.d).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.m_e).AutoSize = true;
		((System.Windows.Forms.Control)this.m_e).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_e).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.m_e).Location = new System.Drawing.Point(9, 67);
		((System.Windows.Forms.Control)this.m_e).Name = "label8";
		((System.Windows.Forms.Control)this.m_e).Size = new System.Drawing.Size(42, 15);
		((System.Windows.Forms.Control)this.m_e).TabIndex = 144;
		((System.Windows.Forms.Control)this.m_e).Text = "Name:";
		((AnimaTextBox)this.f).Dark = false;
		((System.Windows.Forms.Control)this.f).Location = new System.Drawing.Point(66, 102);
		((AnimaTextBox)this.f).MaxLength = 32767;
		((AnimaTextBox)this.f).MultiLine = false;
		((System.Windows.Forms.Control)this.f).Name = "editRuleRootDirTb";
		((AnimaTextBox)this.f).Numeric = false;
		((AnimaTextBox)this.f).ReadOnly = false;
		((System.Windows.Forms.Control)this.f).Size = new System.Drawing.Size(230, 23);
		((System.Windows.Forms.Control)this.f).TabIndex = 147;
		((AnimaTextBox)this.f).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label3).AutoSize = true;
		((System.Windows.Forms.Control)this.label3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label3).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label3).Location = new System.Drawing.Point(10, 106);
		((System.Windows.Forms.Control)this.label3).Name = "label3";
		((System.Windows.Forms.Control)this.label3).Size = new System.Drawing.Size(50, 15);
		((System.Windows.Forms.Control)this.label3).TabIndex = 146;
		((System.Windows.Forms.Control)this.label3).Text = "RootDir:";
		((System.Windows.Forms.Control)this.label5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label5).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label5).Location = new System.Drawing.Point(12, 130);
		((System.Windows.Forms.Control)this.label5).Name = "label5";
		((System.Windows.Forms.Control)this.label5).Size = new System.Drawing.Size(284, 20);
		((System.Windows.Forms.Control)this.label5).TabIndex = 149;
		((System.Windows.Forms.Control)this.label5).Text = "Search directories";
		((System.Windows.Forms.Label)this.label5).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.editWalletsRulesListBox).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.editWalletsRulesListBox).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.editWalletsRulesListBox).ItemHeight = 18;
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Location = new System.Drawing.Point(12, 155);
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Name = "editWalletsRulesListBox";
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Size = new System.Drawing.Size(284, 200);
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).TabIndex = 150;
		((MetroSetButton)this.removeDirBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeDirBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.removeDirBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.removeDirBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.removeDirBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeDirBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.removeDirBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeDirBtn).Location = new System.Drawing.Point(211, 361);
		((System.Windows.Forms.Control)this.removeDirBtn).Name = "removeDirBtn";
		((MetroSetButton)this.removeDirBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeDirBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.removeDirBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.removeDirBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeDirBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.removeDirBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.removeDirBtn).Size = new System.Drawing.Size(84, 20);
		((MetroSetButton)this.removeDirBtn).Style = (Style)0;
		((MetroSetButton)this.removeDirBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.removeDirBtn).TabIndex = 151;
		((System.Windows.Forms.Control)this.removeDirBtn).Text = "Remove dir";
		((MetroSetButton)this.removeDirBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.removeDirBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.removeDirBtn).Click += new System.EventHandler(e);
		((MetroSetButton)this.addNewDirBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addNewDirBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.addNewDirBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.addNewDirBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.addNewDirBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addNewDirBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.addNewDirBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addNewDirBtn).Location = new System.Drawing.Point(12, 361);
		((System.Windows.Forms.Control)this.addNewDirBtn).Name = "addNewDirBtn";
		((MetroSetButton)this.addNewDirBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addNewDirBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.addNewDirBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.addNewDirBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addNewDirBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.addNewDirBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.addNewDirBtn).Size = new System.Drawing.Size(67, 20);
		((MetroSetButton)this.addNewDirBtn).Style = (Style)0;
		((MetroSetButton)this.addNewDirBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.addNewDirBtn).TabIndex = 154;
		((System.Windows.Forms.Control)this.addNewDirBtn).Text = "Add dir";
		((MetroSetButton)this.addNewDirBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.addNewDirBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.addNewDirBtn).Click += new System.EventHandler(c);
		((System.Windows.Forms.BindingSource)this.object_4).DataSource = typeof(RedLine.SharedModels.CreditCard);
		((System.Windows.Forms.BindingSource)this.object_3).DataSource = typeof(RedLine.SharedModels.LoginPair);
		((System.Windows.Forms.BindingSource)this.object_2).DataSource = typeof(RedLine.SharedModels.Credentials);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(306, 439);
		base.Controls.Add((System.Windows.Forms.Control)this.addNewDirBtn);
		base.Controls.Add((System.Windows.Forms.Control)this.removeDirBtn);
		base.Controls.Add((System.Windows.Forms.Control)this.editWalletsRulesListBox);
		base.Controls.Add((System.Windows.Forms.Control)this.label5);
		base.Controls.Add((System.Windows.Forms.Control)this.f);
		base.Controls.Add((System.Windows.Forms.Control)this.label3);
		base.Controls.Add((System.Windows.Forms.Control)this.d);
		base.Controls.Add((System.Windows.Forms.Control)this.m_e);
		base.Controls.Add((System.Windows.Forms.Control)this.m_c);
		base.Controls.Add((System.Windows.Forms.Control)this.m_b);
		base.Controls.Add((System.Windows.Forms.Control)this.m_a);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "CreateWalletRuleDialog";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "RedLine | Wallet Grabber Configurator";
		base.Load += new System.EventHandler(CreateWalletRuleDialog_Load);
		base.Paint += new System.Windows.Forms.PaintEventHandler(CreateWalletRuleDialog_Paint);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		((System.Windows.Forms.Control)this.logContextMenu).ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.object_4).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_2).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
