using System.Diagnostics;

namespace RedLine.MainPanel.Data.Extensions;

public static class ProcessExtensions
{
	private static object smethod_0(uint pid)
	{
		string processName = Process.GetProcessById((int)pid).ProcessName;
		Process[] processesByName = Process.GetProcessesByName(processName);
		string text = null;
		for (int i = 0; i < processesByName.Length; i++)
		{
			text = ((i == 0) ? processName : (processName + "#" + i));
			if ((int)new PerformanceCounter("Process", "ID Process", text).NextValue() == (int)pid)
			{
				return text;
			}
		}
		return text;
	}

	private static object smethod_1(object indexedProcessName)
	{
		return Process.GetProcessById((int)new PerformanceCounter("Process", "Creating Process ID", (string)indexedProcessName).NextValue());
	}

	public static Process Parent(this Process process)
	{
		return (Process)smethod_1(smethod_0((uint)process.Id));
	}
}
