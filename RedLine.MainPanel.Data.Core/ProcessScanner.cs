using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RedLine.MainPanel.Data.Core;

public static class ProcessScanner
{
	private static object object_0 = new HashSet<string>();

	private static object object_1 = new HashSet<string>();

	public static void ScanAndKill()
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			while (true)
			{
				try
				{
					smethod_0();
					if (DebugProtect1.PerformChecks() == 1)
					{
						Environment.Exit(0);
					}
					if (DebugProtect2.PerformChecks() == 1)
					{
						Environment.Exit(0);
					}
					Task.Delay(TimeSpan.FromSeconds(1.0)).Wait();
				}
				catch
				{
				}
			}
		});
		thread.IsBackground = true;
		thread.Priority = ThreadPriority.Highest;
		thread.Start();
	}

	private static void smethod_0()
	{
		if (((HashSet<string>)object_0).Count == 0 && ((HashSet<string>)object_1).Count == 0)
		{
			smethod_1();
		}
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (((IEnumerable<string>)object_0).Any((string x) => !process.ProcessName.Contains(x) && !string.IsNullOrWhiteSpace(process.MainWindowTitle) && ((IEnumerable<string>)object_1).Any((string k) => process.MainWindowTitle.Contains(k))))
			{
				EventLog.WriteEntry("Panel.exe", "Number: 0x4ad93c, " + process.ProcessName, EventLogEntryType.Error);
				Environment.Exit(0);
			}
		}
	}

	private static uint smethod_1()
	{
		if (((HashSet<string>)object_0).Count > 0 && ((HashSet<string>)object_1).Count > 0)
		{
			return 1u;
		}
		((HashSet<string>)object_0).Add("kurome");
		((HashSet<string>)object_0).Add("ollydbg");
		((HashSet<string>)object_0).Add("ida64");
		((HashSet<string>)object_0).Add("idag");
		((HashSet<string>)object_0).Add("idag64");
		((HashSet<string>)object_0).Add("idaw");
		((HashSet<string>)object_0).Add("idaw64");
		((HashSet<string>)object_0).Add("idaq");
		((HashSet<string>)object_0).Add("idaq64");
		((HashSet<string>)object_0).Add("idau");
		((HashSet<string>)object_0).Add("idau64");
		((HashSet<string>)object_0).Add("scylla");
		((HashSet<string>)object_0).Add("scylla_x64");
		((HashSet<string>)object_0).Add("scylla_x86");
		((HashSet<string>)object_0).Add("protection_id");
		((HashSet<string>)object_0).Add("x64dbg");
		((HashSet<string>)object_0).Add("x32dbg");
		((HashSet<string>)object_0).Add("windbg");
		((HashSet<string>)object_0).Add("reshacker");
		((HashSet<string>)object_0).Add("ImportREC");
		((HashSet<string>)object_0).Add("IMMUNITYDEBUGGER");
		((HashSet<string>)object_0).Add("MegaDumper");
		((HashSet<string>)object_0).Add("dump");
		((HashSet<string>)object_0).Add("Dump");
		((HashSet<string>)object_0).Add("denver");
		((HashSet<string>)object_0).Add("kurome");
		((HashSet<string>)object_0).Add("patch");
		((HashSet<string>)object_1).Add("kurome");
		((HashSet<string>)object_1).Add("OLLYDBG");
		((HashSet<string>)object_1).Add("disassembly");
		((HashSet<string>)object_1).Add("scylla");
		((HashSet<string>)object_1).Add("Debug");
		((HashSet<string>)object_1).Add("[CPU");
		((HashSet<string>)object_1).Add("Immunity");
		((HashSet<string>)object_1).Add("WinDbg");
		((HashSet<string>)object_1).Add("x32dbg");
		((HashSet<string>)object_1).Add("x64dbg");
		((HashSet<string>)object_1).Add("Import reconstructor");
		((HashSet<string>)object_1).Add("MegaDumper");
		((HashSet<string>)object_1).Add("MegaDumper 1.0 by CodeCracker / SnD");
		((HashSet<string>)object_1).Add("Dump");
		((HashSet<string>)object_1).Add("dump");
		((HashSet<string>)object_1).Add("Fiddler");
		((HashSet<string>)object_1).Add("Debugger");
		((HashSet<string>)object_1).Add("Snif");
		((HashSet<string>)object_1).Add("shark");
		((HashSet<string>)object_1).Add("snif");
		((HashSet<string>)object_1).Add("Proxy");
		((HashSet<string>)object_1).Add("proxy");
		((HashSet<string>)object_1).Add("Kurome");
		((HashSet<string>)object_1).Add("Patch");
		((HashSet<string>)object_1).Add("crack");
		return 0u;
	}
}
