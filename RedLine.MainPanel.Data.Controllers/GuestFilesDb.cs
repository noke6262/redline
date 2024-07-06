using System;
using RedLine.MainPanel.Models.DB;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Data.Controllers;

public class GuestFilesDb : ProtoDb<GuestFile, int>
{
	public GuestFilesDb()
		: this((GuestFile x) => x.ID, "GuestFiles")
	{
	}

	public GuestFilesDb(Func<GuestFile, int> keySelector, string Name)
		: base(keySelector, Name)
	{
	}
}
