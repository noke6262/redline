using System;
using System.Runtime.CompilerServices;
using RedLine.MainPanel.Models.DB;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Data.Controllers;

public class UserLogsDb : PagedProtoDb<UserLog, int>
{
	public UserLogsDb()
		: this("Data", (Func<UserLog, int>)((UserLog x) => x.ID), (OnLoadItem<UserLog>)smethod_0, (OnUnloadItem<UserLog>)smethod_1)
	{
	}

	private unsafe static void smethod_0(IntPtr log)
	{
		((UserLog*)log)->Credentials = new Credentials();
		((UserLog*)log)->Screenshot = new byte[0];
	}

	private unsafe static void smethod_1(IntPtr log)
	{
		System.Runtime.CompilerServices.Unsafe.Write((void*)log, default(UserLog));
	}

	public UserLogsDb(string name, Func<UserLog, int> keySelector, OnLoadItem<UserLog> itemLoadAction = null, OnUnloadItem<UserLog> itemUnloadAction = null)
		: base(name, keySelector, itemLoadAction, itemUnloadAction)
	{
	}
}
