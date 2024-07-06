using System;
using RedLine.MainPanel.Models.DB;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Data.Controllers;

public class GuestLinksDb : ProtoDb<GuestLink, string>
{
	public GuestLinksDb()
		: this((GuestLink x) => x.ID, "GuestLinks")
	{
	}

	public GuestLinksDb(Func<GuestLink, string> keySelector, string Name)
		: base(keySelector, Name)
	{
	}
}
