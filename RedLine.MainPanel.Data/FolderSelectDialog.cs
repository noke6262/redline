using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace RedLine.MainPanel.Data;

public class FolderSelectDialog
{
	private struct ShowDialogResult
	{
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private string string_0;

		public bool Result
		{
			[CompilerGenerated]
			get
			{
				return bool_0;
			}
			[CompilerGenerated]
			set
			{
				bool_0 = value;
			}
		}

		public string FileName
		{
			[CompilerGenerated]
			get
			{
				return string_0;
			}
			[CompilerGenerated]
			set
			{
				string_0 = value;
			}
		}
	}

	private static class VistaDialog
	{
		private const string string_0 = "";

		private const BindingFlags bindingFlags_0 = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private static readonly object object_0 = typeof(FileDialog).Assembly;

		private static readonly object object_1 = ((Assembly)object_0).GetType("System.Windows.Forms.FileDialogNative+IFileDialog");

		private static readonly object object_2 = typeof(OpenFileDialog).GetMethod("CreateVistaDialog", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		private static readonly object object_3 = typeof(OpenFileDialog).GetMethod("OnBeforeVistaDialog", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		private static readonly object object_4 = typeof(FileDialog).GetMethod("GetOptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		private static readonly object object_5 = ((Type)object_1).GetMethod("SetOptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		private static readonly uint uint_0 = (uint)((Assembly)object_0).GetType("System.Windows.Forms.FileDialogNative+FOS").GetField("FOS_PICKFOLDERS").GetValue(null);

		private static readonly object object_6 = ((Assembly)object_0).GetType("System.Windows.Forms.FileDialog+VistaDialogEvents").GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(FileDialog) }, null);

		private static readonly object a = ((Type)object_1).GetMethod("Advise");

		private static readonly object b = ((Type)object_1).GetMethod("Unadvise");

		private static readonly object c = ((Type)object_1).GetMethod("Show");

		public static ShowDialogResult Show(IntPtr ownerHandle, string initialDirectory, string title)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				AddExtension = false,
				CheckFileExists = false,
				DereferenceLinks = true,
				Filter = "Folders|\n",
				InitialDirectory = initialDirectory,
				Multiselect = false,
				Title = title
			};
			object obj = ((MethodBase)object_2).Invoke((object)openFileDialog, new object[0]);
			((MethodBase)object_3).Invoke((object)openFileDialog, new object[1] { obj });
			((MethodBase)object_5).Invoke(obj, new object[1] { (uint)((MethodBase)object_4).Invoke((object)openFileDialog, new object[0]) | uint_0 });
			object[] array = new object[2]
			{
				((ConstructorInfo)object_6).Invoke(new object[1] { openFileDialog }),
				0u
			};
			((MethodBase)a).Invoke(obj, array);
			try
			{
				int num = (int)((MethodBase)c).Invoke(obj, new object[1] { ownerHandle });
				ShowDialogResult result = default(ShowDialogResult);
				result.Result = num == 0;
				result.FileName = openFileDialog.FileName;
				return result;
			}
			finally
			{
				((MethodBase)b).Invoke(obj, new object[1] { array[1] });
			}
		}
	}

	private class WindowWrapper : IWin32Window
	{
		private readonly IntPtr intptr_0;

		public IntPtr Handle => intptr_0;

		public WindowWrapper(IntPtr handle)
		{
			intptr_0 = handle;
		}
	}

	private object object_0;

	private object object_1;

	private object object_2 = "";

	public string InitialDirectory
	{
		get
		{
			if (!string.IsNullOrEmpty((string)object_0))
			{
				return (string)object_0;
			}
			return Environment.CurrentDirectory;
		}
		set
		{
			object_0 = value;
		}
	}

	public string Title
	{
		get
		{
			return (string)(object_1 ?? "Select a folder");
		}
		set
		{
			object_1 = value;
		}
	}

	public string FileName => (string)object_2;

	public bool Show()
	{
		return Show(IntPtr.Zero);
	}

	public bool Show(IntPtr hWndOwner)
	{
		ShowDialogResult showDialogResult = ((Environment.OSVersion.Version.Major >= 6) ? VistaDialog.Show(hWndOwner, InitialDirectory, Title) : smethod_0(hWndOwner, InitialDirectory, Title));
		object_2 = showDialogResult.FileName;
		return showDialogResult.Result;
	}

	private static ShowDialogResult smethod_0(IntPtr ownerHandle, object initialDirectory, object title)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = (string)title,
			SelectedPath = (string)initialDirectory,
			ShowNewFolderButton = false
		};
		ShowDialogResult result = default(ShowDialogResult);
		if (folderBrowserDialog.ShowDialog(new WindowWrapper(ownerHandle)) == DialogResult.OK)
		{
			result.Result = true;
			result.FileName = folderBrowserDialog.SelectedPath;
		}
		return result;
	}
}
