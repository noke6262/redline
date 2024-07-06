using System;
using RedLine.MainPanel.Models.DB;
using RedLine.SharedModels;

namespace RedLine.MainPanel.Data.Controllers;

public class TasksDb : ProtoDb<RemoteTask, int>
{
	public TasksDb()
		: this((RemoteTask x) => x.ID, "RemoteTasks")
	{
	}

	public TasksDb(Func<RemoteTask, int> keySelector, string Name)
		: base(keySelector, Name)
	{
	}
}
