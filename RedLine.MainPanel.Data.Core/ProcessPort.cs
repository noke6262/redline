using System;

namespace RedLine.MainPanel.Data.Core;

public class ProcessPort
{
	private object object_0 = string.Empty;

	private IntPtr intptr_0;

	private object object_1 = string.Empty;

	private IntPtr intptr_1;

	public string ProcessPortDescription => $"{object_0} ({object_1} port {(int)(nint)intptr_1} pid {(int)(nint)intptr_0})";

	public string ProcessName => (string)object_0;

	public int ProcessId => (int)(nint)intptr_0;

	public string Protocol => (string)object_1;

	public int PortNumber => (int)(nint)intptr_1;

	internal ProcessPort(string ProcessName, int ProcessId, string Protocol, int PortNumber)
	{
		object_0 = ProcessName;
		intptr_0 = (IntPtr)ProcessId;
		object_1 = Protocol;
		intptr_1 = (IntPtr)PortNumber;
	}
}
