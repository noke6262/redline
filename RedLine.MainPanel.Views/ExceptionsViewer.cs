using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RedLine.MainPanel.Data.Extensions;

namespace RedLine.MainPanel.Views;

public class ExceptionsViewer : Form
{
	private object object_0;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object label1;

	private object notificationTb;

	public ExceptionsViewer(List<string> _pairs)
	{
		InitializeComponent();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		string text = string.Empty;
		foreach (string _pair in _pairs)
		{
			text = text + _pair + Environment.NewLine + Environment.NewLine;
		}
		((Control)notificationTb).Text = text;
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void ExceptionsViewer_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void label1_Click(object sender, object e)
	{
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.ExceptionsViewer));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.notificationTb = new System.Windows.Forms.RichTextBox();
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.label1);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(800, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 3;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(190, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | ExceptionsViewer";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(1042, 3);
		((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
		((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
		((System.Windows.Forms.Control)this.closeBtn).Text = "X";
		((System.Windows.Forms.Control)this.label1).AutoSize = true;
		((System.Windows.Forms.Control)this.label1).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.label1).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.label1).Location = new System.Drawing.Point(777, 4);
		((System.Windows.Forms.Control)this.label1).Name = "label1";
		((System.Windows.Forms.Control)this.label1).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.label1).TabIndex = 4;
		((System.Windows.Forms.Control)this.label1).Text = "X";
		((System.Windows.Forms.Control)this.label1).Click += new System.EventHandler(label1_Click);
		((System.Windows.Forms.Control)this.notificationTb).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.TextBoxBase)this.notificationTb).BorderStyle = System.Windows.Forms.BorderStyle.None;
		((System.Windows.Forms.Control)this.notificationTb).Dock = System.Windows.Forms.DockStyle.Fill;
		((System.Windows.Forms.Control)this.notificationTb).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.notificationTb).Location = new System.Drawing.Point(0, 30);
		((System.Windows.Forms.Control)this.notificationTb).Name = "notificationTb";
		((System.Windows.Forms.TextBoxBase)this.notificationTb).ReadOnly = true;
		((System.Windows.Forms.RichTextBox)this.notificationTb).ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		((System.Windows.Forms.Control)this.notificationTb).Size = new System.Drawing.Size(800, 420);
		((System.Windows.Forms.Control)this.notificationTb).TabIndex = 4;
		((System.Windows.Forms.Control)this.notificationTb).Text = "";
		((System.Windows.Forms.TextBoxBase)this.notificationTb).WordWrap = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(800, 450);
		base.Controls.Add((System.Windows.Forms.Control)this.notificationTb);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "ExceptionsViewer";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "RedLine | ExceptionsViewer";
		base.Paint += new System.Windows.Forms.PaintEventHandler(ExceptionsViewer_Paint);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		base.ResumeLayout(false);
	}
}
