using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace RedLine.MainPanel.Properties;

[DebuggerNonUserCode]
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[CompilerGenerated]
internal class Resources
{
	private static object object_0;

	private static object object_1;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (object_0 == null)
			{
				object_0 = new ResourceManager("RedLine.MainPanel.Properties.Resources", typeof(Resources).Assembly);
			}
			return (ResourceManager)object_0;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		set
		{
			object_1 = value;
		}
	}

	internal static Bitmap _250_x_250 => (Bitmap)ResourceManager.GetObject("250-x-250", (CultureInfo)object_1);

	internal static byte[] blob1 => (byte[])ResourceManager.GetObject("blob1", (CultureInfo)object_1);

	internal static Bitmap icons8_cookies_80 => (Bitmap)ResourceManager.GetObject("icons8-cookies-80", (CultureInfo)object_1);

	internal static Bitmap icons8_password_100 => (Bitmap)ResourceManager.GetObject("icons8-password-100", (CultureInfo)object_1);

	internal static Bitmap icons8_spreadsheet_file_64 => (Bitmap)ResourceManager.GetObject("icons8-spreadsheet-file-64", (CultureInfo)object_1);

	internal static Bitmap logotype_dyncheck_com_beta => (Bitmap)ResourceManager.GetObject("logotype_dyncheck_com_beta", (CultureInfo)object_1);

	internal static Bitmap redline_250x500 => (Bitmap)ResourceManager.GetObject("redline-250x500", (CultureInfo)object_1);

	internal static Bitmap redline_no_address => (Bitmap)ResourceManager.GetObject("redline-no-address", (CultureInfo)object_1);

	internal static Bitmap small => (Bitmap)ResourceManager.GetObject("small", (CultureInfo)object_1);

	internal static Bitmap telegram => (Bitmap)ResourceManager.GetObject("telegram", (CultureInfo)object_1);

	internal Resources()
	{
	}
}
