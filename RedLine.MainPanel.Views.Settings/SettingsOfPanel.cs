using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RedLine.MainPanel.Views.Settings;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
internal sealed class SettingsOfPanel : ApplicationSettingsBase
{
	private static object object_0 = (SettingsOfPanel)SettingsBase.Synchronized(new SettingsOfPanel());

	public static SettingsOfPanel Default => (SettingsOfPanel)object_0;

	[UserScopedSetting]
	[DefaultSettingValue("")]
	[DebuggerNonUserCode]
	public string ServerIP
	{
		get
		{
			return (string)this["ServerIP"];
		}
		set
		{
			this["ServerIP"] = value;
		}
	}
}
