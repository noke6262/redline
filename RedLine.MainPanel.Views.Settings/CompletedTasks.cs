using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RedLine.MainPanel.Views.Settings;

[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
[CompilerGenerated]
internal sealed class CompletedTasks : ApplicationSettingsBase
{
	private static object object_0 = (CompletedTasks)SettingsBase.Synchronized(new CompletedTasks());

	public static CompletedTasks Default => (CompletedTasks)object_0;

	[UserScopedSetting]
	[DebuggerNonUserCode]
	public StringCollection Completed
	{
		get
		{
			return (StringCollection)this["Completed"];
		}
		set
		{
			this["Completed"] = value;
		}
	}
}
