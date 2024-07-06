using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedLine.MainPanel.Data.Controllers;
using RedLine.MainPanel.DbControllers;
using RedLine.MainPanel.Models;
using RedLine.MainPanel.Properties;
using WindowsFirewallHelper;

namespace RedLine.MainPanel.Views;

public class SplashFrm : Form
{
	private object object_0;

	private object splashImage;

	public SplashFrm()
	{
		InitializeComponent();
	}

	private async void SplashFrm_Load(object sender, object e)
	{
		ServiceSettings serviceSettings = new ServiceSettings();
		serviceSettings.LoadSettings();
		bool flag = CheckExistPortRule(serviceSettings.Port);
		bool flag2 = CheckExistPortRule(serviceSettings.GuestPort);
		string text = "Do you want to open port(s): ";
		if (!flag)
		{
			text = text + serviceSettings.Port + ",";
		}
		if (!flag2)
		{
			text += serviceSettings.GuestPort;
		}
		_ = text.TrimEnd(',') + "?";
		if (!flag || !flag2)
		{
			string text2 = string.Empty;
			if (!flag)
			{
				text2 = (AddPort(serviceSettings.Port) ? (text2 + $"Firewall rule for Port {serviceSettings.Port} is created." + Environment.NewLine) : (text2 + $"Can't open port {serviceSettings.Port}." + Environment.NewLine));
			}
			if (!flag2)
			{
				if (!AddPort(serviceSettings.GuestPort))
				{
					_ = text2 + $"Can't open port {serviceSettings.GuestPort}." + Environment.NewLine;
				}
				else
				{
					_ = text2 + $"Firewall rule for Port {serviceSettings.GuestPort} is created." + Environment.NewLine;
				}
			}
		}
		await Task.Delay(4500);
		_ = LazyLoader<UserLogsDb>.Instance.DbInstance;
		Close();
	}

	public bool AddPort(int port)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			IRule val = FirewallManager.Instance.CreatePortRule(FirewallManager.Instance.GetProfile().Type, "RedRule_" + port, (FirewallAction)1, (ushort)port, FirewallProtocol.TCP);
			val.IsEnable = true;
			val.Direction = (FirewallDirection)0;
			FirewallManager.Instance.Rules.Add(val);
			return CheckExistPortRule(port);
		}
		catch (Exception)
		{
		}
		return false;
	}

	public bool CheckExistPortRule(int port)
	{
		try
		{
			foreach (IRule rule in FirewallManager.Instance.Rules)
			{
				if ((rule.LocalPorts?.Any() ?? (rule.Protocol == FirewallProtocol.Any)) && rule.LocalPorts.Any((ushort x) => x == port))
				{
					return true;
				}
			}
		}
		catch (Exception)
		{
		}
		return false;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedLine.MainPanel.Views.SplashFrm));
		this.splashImage = new System.Windows.Forms.PictureBox();
		((System.ComponentModel.ISupportInitialize)this.splashImage).BeginInit();
		base.SuspendLayout();
		((System.Windows.Forms.Control)this.splashImage).Dock = System.Windows.Forms.DockStyle.Fill;
		((System.Windows.Forms.PictureBox)this.splashImage).Image = RedLine.MainPanel.Properties.Resources.redline_no_address;
		((System.Windows.Forms.Control)this.splashImage).Location = new System.Drawing.Point(0, 0);
		((System.Windows.Forms.Control)this.splashImage).Name = "splashImage";
		((System.Windows.Forms.Control)this.splashImage).Size = new System.Drawing.Size(500, 250);
		((System.Windows.Forms.PictureBox)this.splashImage).SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		((System.Windows.Forms.PictureBox)this.splashImage).TabIndex = 0;
		((System.Windows.Forms.PictureBox)this.splashImage).TabStop = false;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(500, 250);
		base.Controls.Add((System.Windows.Forms.Control)this.splashImage);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "SplashFrm";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "SplashFrm";
		base.Load += new System.EventHandler(SplashFrm_Load);
		((System.ComponentModel.ISupportInitialize)this.splashImage).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
