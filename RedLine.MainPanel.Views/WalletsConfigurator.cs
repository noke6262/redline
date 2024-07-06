using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using MetroSet_UI.Enums;
using Microsoft.VisualBasic;
using RedLine.MainPanel.Data.Extensions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class WalletsConfigurator : Form
{
	private object object_0 = new WalletConfigsDb();

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

	private object c;

	private object m_d;

	private object m_e;

	private object f;

	private object label8;

	private object editRuleRootDirTb;

	private object label3;

	private object label5;

	private object editWalletsRulesListBox;

	private object metroSetButton1;

	private object metroSetButton2;

	private object metroSetButton3;

	private object metroSetButton4;

	private object metroSetButton5;

	private object defaultRulesBtn;

	public WalletsConfigurator()
	{
		InitializeComponent();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		LoadConfigs();
	}

	public void LoadConfigs()
	{
		lock (WalletConfigsDb.RootLocker)
		{
			((AnimaTextBox)f).Text = string.Empty;
			((AnimaTextBox)editRuleRootDirTb).Text = string.Empty;
			((ListBox)editWalletsRulesListBox).Items.Clear();
			((WalletConfigsDb)object_0).LoadSettings();
			((ListBox)this.m_b).Items.Clear();
			ListBox.ObjectCollection items = ((ListBox)this.m_b).Items;
			IEnumerable<string> enumerable = ((WalletConfigsDb)object_0).walletSettings.Select((WalletConfig x) => x.Name);
			object obj;
			if (enumerable == null)
			{
				obj = null;
			}
			else
			{
				obj = enumerable.ToArray();
				if (obj != null)
				{
					goto IL_00ab;
				}
			}
			obj = new string[0];
			goto IL_00ab;
			IL_00ab:
			object[] items2 = (object[])obj;
			items.AddRange(items2);
		}
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

	private void WalletsConfigurator_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void a_Click(object sender, object e)
	{
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void WalletsConfigurator_Load(object sender, object e)
	{
	}

	private void b_SelectedIndexChanged(object sender, object e)
	{
		int selectedIndex = ((ListControl)this.m_b).SelectedIndex;
		if (selectedIndex <= -1)
		{
			return;
		}
		lock (WalletConfigsDb.RootLocker)
		{
			((AnimaTextBox)f).Text = ((WalletConfigsDb)object_0).walletSettings[selectedIndex].Name;
			((AnimaTextBox)editRuleRootDirTb).Text = ((WalletConfigsDb)object_0).walletSettings[selectedIndex].RootDir;
			((ListBox)editWalletsRulesListBox).Items.Clear();
			ListBox.ObjectCollection items = ((ListBox)editWalletsRulesListBox).Items;
			List<FileScannerArg> scannerArgs = ((WalletConfigsDb)object_0).walletSettings[selectedIndex].ScannerArgs;
			object obj;
			if (scannerArgs == null)
			{
				obj = null;
			}
			else
			{
				IEnumerable<string> enumerable = scannerArgs.Select((FileScannerArg x) => x.Directory + "(" + x.Pattern + ")");
				if (enumerable == null)
				{
					obj = null;
				}
				else
				{
					obj = enumerable.ToArray();
					if (obj != null)
					{
						goto IL_00d7;
					}
				}
			}
			obj = new string[0];
			goto IL_00d7;
			IL_00d7:
			object[] items2 = (object[])obj;
			items.AddRange(items2);
		}
	}

	private void metroSetButton5_Click(object sender, object e)
	{
		try
		{
			if (((ListBox)this.m_b).SelectedItems.Count == 0)
			{
				MessageBox.Show(this, "Select wallet rule to remove");
				return;
			}
			lock (WalletConfigsDb.RootLocker)
			{
				((WalletConfigsDb)object_0).walletSettings.RemoveAt(((ListControl)this.m_b).SelectedIndex);
				((WalletConfigsDb)object_0).SaveSettings();
			}
			LoadConfigs();
			MessageBox.Show(this, "Successfully removed");
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void defaultRulesBtn_Click(object sender, object e)
	{
		try
		{
			if (MessageBox.Show(this, "Are you sure you want to restore default settings?", "Verification", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				lock (WalletConfigsDb.RootLocker)
				{
					((WalletConfigsDb)object_0).SetDefault();
					((WalletConfigsDb)object_0).SaveSettings();
				}
				LoadConfigs();
				MessageBox.Show(this, "Successfully restored to default settings");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void a(object sender, object e)
	{
		try
		{
			CreateWalletRuleDialog newRuleDialog = new CreateWalletRuleDialog();
			if (newRuleDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			if (!((WalletConfigsDb)object_0).walletSettings.Any((WalletConfig x) => x.Name == newRuleDialog.Config.Name))
			{
				lock (WalletConfigsDb.RootLocker)
				{
					((WalletConfigsDb)object_0).walletSettings.Add(newRuleDialog.Config);
					((WalletConfigsDb)object_0).SaveSettings();
				}
				LoadConfigs();
				MessageBox.Show(this, "Successfully added");
			}
			else
			{
				MessageBox.Show(this, "Rule with same name already exist in list");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	private void b(object sender, object e)
	{
		try
		{
			FileScannerArg fileScannerArg = RequestScannerArgUI();
			if (fileScannerArg == null)
			{
				return;
			}
			lock (WalletConfigsDb.RootLocker)
			{
				if (((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].ScannerArgs == null)
				{
					((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].ScannerArgs = new List<FileScannerArg>();
				}
				((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].ScannerArgs.Add(fileScannerArg);
			}
			((ListBox)editWalletsRulesListBox).Items.Clear();
			ListBox.ObjectCollection items = ((ListBox)editWalletsRulesListBox).Items;
			List<FileScannerArg> scannerArgs = ((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].ScannerArgs;
			object obj;
			if (scannerArgs == null)
			{
				obj = null;
			}
			else
			{
				IEnumerable<string> enumerable = scannerArgs.Select((FileScannerArg x) => x.Directory + "(" + x.Pattern + ")");
				if (enumerable == null)
				{
					obj = null;
				}
				else
				{
					obj = enumerable.ToArray();
					if (obj != null)
					{
						goto IL_0112;
					}
				}
			}
			obj = new string[0];
			goto IL_0112;
			IL_0112:
			object[] items2 = (object[])obj;
			items.AddRange(items2);
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
			if (string.IsNullOrWhiteSpace(text2))
			{
				return null;
			}
			if (!(text3 != "True") || !(text3 != "False"))
			{
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

	private void d(object sender, object e)
	{
		try
		{
			if (((ListControl)this.m_b).SelectedIndex <= -1)
			{
				return;
			}
			if (!string.IsNullOrWhiteSpace(((AnimaTextBox)f).Text))
			{
				if (!string.IsNullOrWhiteSpace(((AnimaTextBox)editRuleRootDirTb).Text))
				{
					List<FileScannerArg> scannerArgs = ((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].ScannerArgs;
					if (scannerArgs != null && scannerArgs.Count == 0)
					{
						MessageBox.Show(this, "Add directories to search");
						return;
					}
					((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].Name = ((AnimaTextBox)f).Text;
					((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].RootDir = ((AnimaTextBox)editRuleRootDirTb).Text;
					lock (WalletConfigsDb.RootLocker)
					{
						((WalletConfigsDb)object_0).SaveSettings();
						LoadConfigs();
					}
					MessageBox.Show(this, "Successfully saved rule");
				}
				else
				{
					MessageBox.Show(this, "Enter a root directory of rule");
				}
			}
			else
			{
				MessageBox.Show(this, "Enter a name of rule");
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
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
			((WalletConfigsDb)object_0).walletSettings[((ListControl)this.m_b).SelectedIndex].ScannerArgs.RemoveAt(((ListControl)editWalletsRulesListBox).SelectedIndex);
			((ListBox)editWalletsRulesListBox).Items.RemoveAt(((ListControl)editWalletsRulesListBox).SelectedIndex);
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
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		this.object_1 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.WalletsConfigurator));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_1);
		this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.m_a = (object)new MetroSetButton();
		this.m_b = new System.Windows.Forms.ListBox();
		this.c = new System.Windows.Forms.Label();
		this.m_d = new System.Windows.Forms.Label();
		this.m_e = (object)new MetroSetDivider();
		this.f = (object)new AnimaTextBox();
		this.label8 = new System.Windows.Forms.Label();
		this.editRuleRootDirTb = (object)new AnimaTextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.editWalletsRulesListBox = new System.Windows.Forms.ListBox();
		this.metroSetButton1 = (object)new MetroSetButton();
		this.metroSetButton2 = (object)new MetroSetButton();
		this.metroSetButton3 = (object)new MetroSetButton();
		this.metroSetButton4 = (object)new MetroSetButton();
		this.metroSetButton5 = (object)new MetroSetButton();
		this.defaultRulesBtn = (object)new MetroSetButton();
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
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(596, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 2;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(263, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Wallet Grabber Configurator";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(566, 4);
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
		((System.Windows.Forms.Control)this.m_a).Location = new System.Drawing.Point(246, 405);
		((System.Windows.Forms.Control)this.m_a).Name = "saveBtn";
		((MetroSetButton)this.m_a).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.m_a).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.m_a).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.m_a).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.m_a).Size = new System.Drawing.Size(102, 20);
		((MetroSetButton)this.m_a).Style = (Style)0;
		((MetroSetButton)this.m_a).StyleManager = null;
		((System.Windows.Forms.Control)this.m_a).TabIndex = 23;
		((System.Windows.Forms.Control)this.m_a).Text = "OK";
		((MetroSetButton)this.m_a).ThemeAuthor = "Narwin";
		((MetroSetButton)this.m_a).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.m_a).Click += new System.EventHandler(a_Click);
		((System.Windows.Forms.Control)this.m_b).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.ListBox)this.m_b).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		((System.Windows.Forms.Control)this.m_b).Cursor = System.Windows.Forms.Cursors.Default;
		((System.Windows.Forms.Control)this.m_b).Font = new System.Drawing.Font("Consolas", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_b).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.ListBox)this.m_b).HorizontalScrollbar = true;
		((System.Windows.Forms.ListBox)this.m_b).ItemHeight = 18;
		((System.Windows.Forms.Control)this.m_b).Location = new System.Drawing.Point(12, 64);
		((System.Windows.Forms.Control)this.m_b).Name = "walletsRulesListBox";
		((System.Windows.Forms.Control)this.m_b).Size = new System.Drawing.Size(281, 290);
		((System.Windows.Forms.Control)this.m_b).TabIndex = 129;
		((System.Windows.Forms.ListBox)this.m_b).SelectedIndexChanged += new System.EventHandler(b_SelectedIndexChanged);
		((System.Windows.Forms.Control)this.c).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.c).Location = new System.Drawing.Point(12, 37);
		((System.Windows.Forms.Control)this.c).Name = "label51";
		((System.Windows.Forms.Control)this.c).Size = new System.Drawing.Size(281, 20);
		((System.Windows.Forms.Control)this.c).TabIndex = 130;
		((System.Windows.Forms.Control)this.c).Text = "Wallet Rules";
		((System.Windows.Forms.Label)this.c).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.m_d).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.m_d).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.m_d).Location = new System.Drawing.Point(302, 37);
		((System.Windows.Forms.Control)this.m_d).Name = "label1";
		((System.Windows.Forms.Control)this.m_d).Size = new System.Drawing.Size(284, 20);
		((System.Windows.Forms.Control)this.m_d).TabIndex = 131;
		((System.Windows.Forms.Control)this.m_d).Text = "Edit Rule";
		((System.Windows.Forms.Label)this.m_d).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		((System.Windows.Forms.Control)this.m_e).Location = new System.Drawing.Point(0, 386);
		((System.Windows.Forms.Control)this.m_e).Name = "metroSetDivider1";
		((MetroSetDivider)this.m_e).Orientation = (DividerStyle)0;
		((System.Windows.Forms.Control)this.m_e).Size = new System.Drawing.Size(596, 4);
		((MetroSetDivider)this.m_e).Style = (Style)1;
		((MetroSetDivider)this.m_e).StyleManager = null;
		((System.Windows.Forms.Control)this.m_e).TabIndex = 133;
		((System.Windows.Forms.Control)this.m_e).Text = "metroSetDivider1";
		((MetroSetDivider)this.m_e).ThemeAuthor = "Narwin";
		((MetroSetDivider)this.m_e).ThemeName = "MetroDark";
		((MetroSetDivider)this.m_e).Thickness = 1;
		((AnimaTextBox)this.f).Dark = false;
		((System.Windows.Forms.Control)this.f).Location = new System.Drawing.Point(346, 63);
		((AnimaTextBox)this.f).MaxLength = 32767;
		((AnimaTextBox)this.f).MultiLine = false;
		((System.Windows.Forms.Control)this.f).Name = "editRuleNameTb";
		((AnimaTextBox)this.f).Numeric = false;
		((AnimaTextBox)this.f).ReadOnly = false;
		((System.Windows.Forms.Control)this.f).Size = new System.Drawing.Size(240, 23);
		((System.Windows.Forms.Control)this.f).TabIndex = 145;
		((AnimaTextBox)this.f).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label8).AutoSize = true;
		((System.Windows.Forms.Control)this.label8).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label8).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label8).Location = new System.Drawing.Point(299, 66);
		((System.Windows.Forms.Control)this.label8).Name = "label8";
		((System.Windows.Forms.Control)this.label8).Size = new System.Drawing.Size(42, 15);
		((System.Windows.Forms.Control)this.label8).TabIndex = 144;
		((System.Windows.Forms.Control)this.label8).Text = "Name:";
		((AnimaTextBox)this.editRuleRootDirTb).Dark = false;
		((System.Windows.Forms.Control)this.editRuleRootDirTb).Location = new System.Drawing.Point(356, 101);
		((AnimaTextBox)this.editRuleRootDirTb).MaxLength = 32767;
		((AnimaTextBox)this.editRuleRootDirTb).MultiLine = false;
		((System.Windows.Forms.Control)this.editRuleRootDirTb).Name = "editRuleRootDirTb";
		((AnimaTextBox)this.editRuleRootDirTb).Numeric = false;
		((AnimaTextBox)this.editRuleRootDirTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.editRuleRootDirTb).Size = new System.Drawing.Size(230, 23);
		((System.Windows.Forms.Control)this.editRuleRootDirTb).TabIndex = 147;
		((AnimaTextBox)this.editRuleRootDirTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.label3).AutoSize = true;
		((System.Windows.Forms.Control)this.label3).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label3).ForeColor = System.Drawing.Color.FromArgb(170, 170, 170);
		((System.Windows.Forms.Control)this.label3).Location = new System.Drawing.Point(300, 105);
		((System.Windows.Forms.Control)this.label3).Name = "label3";
		((System.Windows.Forms.Control)this.label3).Size = new System.Drawing.Size(50, 15);
		((System.Windows.Forms.Control)this.label3).TabIndex = 146;
		((System.Windows.Forms.Control)this.label3).Text = "RootDir:";
		((System.Windows.Forms.Control)this.label5).Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label5).ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
		((System.Windows.Forms.Control)this.label5).Location = new System.Drawing.Point(302, 129);
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
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Location = new System.Drawing.Point(302, 154);
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Name = "editWalletsRulesListBox";
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).Size = new System.Drawing.Size(284, 200);
		((System.Windows.Forms.Control)this.editWalletsRulesListBox).TabIndex = 150;
		((MetroSetButton)this.metroSetButton1).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton1).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton1).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton1).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton1).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton1).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton1).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton1).Location = new System.Drawing.Point(502, 360);
		((System.Windows.Forms.Control)this.metroSetButton1).Name = "metroSetButton1";
		((MetroSetButton)this.metroSetButton1).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton1).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton1).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton1).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton1).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton1).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton1).Size = new System.Drawing.Size(84, 20);
		((MetroSetButton)this.metroSetButton1).Style = (Style)0;
		((MetroSetButton)this.metroSetButton1).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton1).TabIndex = 151;
		((System.Windows.Forms.Control)this.metroSetButton1).Text = "Remove dir";
		((MetroSetButton)this.metroSetButton1).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton1).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton1).Click += new System.EventHandler(e);
		((MetroSetButton)this.metroSetButton2).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton2).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton2).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton2).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton2).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton2).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton2).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton2).Location = new System.Drawing.Point(12, 360);
		((System.Windows.Forms.Control)this.metroSetButton2).Name = "metroSetButton2";
		((MetroSetButton)this.metroSetButton2).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton2).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton2).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton2).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton2).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton2).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton2).Size = new System.Drawing.Size(65, 20);
		((MetroSetButton)this.metroSetButton2).Style = (Style)0;
		((MetroSetButton)this.metroSetButton2).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton2).TabIndex = 152;
		((System.Windows.Forms.Control)this.metroSetButton2).Text = "Add rule";
		((MetroSetButton)this.metroSetButton2).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton2).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton2).Click += new System.EventHandler(a);
		((MetroSetButton)this.metroSetButton3).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton3).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton3).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton3).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton3).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton3).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton3).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton3).Location = new System.Drawing.Point(302, 360);
		((System.Windows.Forms.Control)this.metroSetButton3).Name = "metroSetButton3";
		((MetroSetButton)this.metroSetButton3).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton3).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton3).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton3).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton3).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton3).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton3).Size = new System.Drawing.Size(119, 20);
		((MetroSetButton)this.metroSetButton3).Style = (Style)0;
		((MetroSetButton)this.metroSetButton3).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton3).TabIndex = 153;
		((System.Windows.Forms.Control)this.metroSetButton3).Text = "Save changes";
		((MetroSetButton)this.metroSetButton3).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton3).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton3).Click += new System.EventHandler(d);
		((MetroSetButton)this.metroSetButton4).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton4).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton4).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton4).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton4).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton4).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton4).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton4).Location = new System.Drawing.Point(427, 360);
		((System.Windows.Forms.Control)this.metroSetButton4).Name = "metroSetButton4";
		((MetroSetButton)this.metroSetButton4).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton4).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton4).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton4).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton4).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton4).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton4).Size = new System.Drawing.Size(67, 20);
		((MetroSetButton)this.metroSetButton4).Style = (Style)0;
		((MetroSetButton)this.metroSetButton4).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton4).TabIndex = 154;
		((System.Windows.Forms.Control)this.metroSetButton4).Text = "Add dir";
		((MetroSetButton)this.metroSetButton4).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton4).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton4).Click += new System.EventHandler(b);
		((MetroSetButton)this.metroSetButton5).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton5).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.metroSetButton5).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.metroSetButton5).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.metroSetButton5).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton5).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.metroSetButton5).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton5).Location = new System.Drawing.Point(102, 360);
		((System.Windows.Forms.Control)this.metroSetButton5).Name = "metroSetButton5";
		((MetroSetButton)this.metroSetButton5).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton5).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.metroSetButton5).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.metroSetButton5).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton5).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.metroSetButton5).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.metroSetButton5).Size = new System.Drawing.Size(84, 20);
		((MetroSetButton)this.metroSetButton5).Style = (Style)0;
		((MetroSetButton)this.metroSetButton5).StyleManager = null;
		((System.Windows.Forms.Control)this.metroSetButton5).TabIndex = 155;
		((System.Windows.Forms.Control)this.metroSetButton5).Text = "Remove rule";
		((MetroSetButton)this.metroSetButton5).ThemeAuthor = "Narwin";
		((MetroSetButton)this.metroSetButton5).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.metroSetButton5).Click += new System.EventHandler(metroSetButton5_Click);
		((MetroSetButton)this.defaultRulesBtn).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.defaultRulesBtn).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.defaultRulesBtn).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.defaultRulesBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.defaultRulesBtn).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.defaultRulesBtn).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.defaultRulesBtn).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.defaultRulesBtn).Location = new System.Drawing.Point(209, 360);
		((System.Windows.Forms.Control)this.defaultRulesBtn).Name = "defaultRulesBtn";
		((MetroSetButton)this.defaultRulesBtn).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.defaultRulesBtn).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.defaultRulesBtn).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.defaultRulesBtn).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.defaultRulesBtn).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.defaultRulesBtn).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.defaultRulesBtn).Size = new System.Drawing.Size(84, 20);
		((MetroSetButton)this.defaultRulesBtn).Style = (Style)0;
		((MetroSetButton)this.defaultRulesBtn).StyleManager = null;
		((System.Windows.Forms.Control)this.defaultRulesBtn).TabIndex = 156;
		((System.Windows.Forms.Control)this.defaultRulesBtn).Text = "Default rules";
		((MetroSetButton)this.defaultRulesBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)this.defaultRulesBtn).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.defaultRulesBtn).Click += new System.EventHandler(defaultRulesBtn_Click);
		((System.Windows.Forms.BindingSource)this.object_4).DataSource = typeof(RedLine.SharedModels.CreditCard);
		((System.Windows.Forms.BindingSource)this.object_3).DataSource = typeof(RedLine.SharedModels.LoginPair);
		((System.Windows.Forms.BindingSource)this.object_2).DataSource = typeof(RedLine.SharedModels.Credentials);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(596, 439);
		base.Controls.Add((System.Windows.Forms.Control)this.defaultRulesBtn);
		base.Controls.Add((System.Windows.Forms.Control)this.metroSetButton5);
		base.Controls.Add((System.Windows.Forms.Control)this.metroSetButton4);
		base.Controls.Add((System.Windows.Forms.Control)this.metroSetButton3);
		base.Controls.Add((System.Windows.Forms.Control)this.metroSetButton2);
		base.Controls.Add((System.Windows.Forms.Control)this.metroSetButton1);
		base.Controls.Add((System.Windows.Forms.Control)this.editWalletsRulesListBox);
		base.Controls.Add((System.Windows.Forms.Control)this.label5);
		base.Controls.Add((System.Windows.Forms.Control)this.editRuleRootDirTb);
		base.Controls.Add((System.Windows.Forms.Control)this.label3);
		base.Controls.Add((System.Windows.Forms.Control)this.f);
		base.Controls.Add((System.Windows.Forms.Control)this.label8);
		base.Controls.Add((System.Windows.Forms.Control)this.m_e);
		base.Controls.Add((System.Windows.Forms.Control)this.m_d);
		base.Controls.Add((System.Windows.Forms.Control)this.c);
		base.Controls.Add((System.Windows.Forms.Control)this.m_b);
		base.Controls.Add((System.Windows.Forms.Control)this.m_a);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "WalletsConfigurator";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Meta | Wallet Grabber Configurator";
		base.Load += new System.EventHandler(WalletsConfigurator_Load);
		base.Paint += new System.Windows.Forms.PaintEventHandler(WalletsConfigurator_Paint);
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
