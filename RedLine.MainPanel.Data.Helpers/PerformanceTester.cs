using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RedLine.MainPanel.Data.Helpers;

public class PerformanceTester
{
	private object object_0;

	[CompilerGenerated]
	private readonly object object_1;

	public int GoodRequests;

	public int BadRequests;

	private DateTime dateTime_0;

	public Func<bool> Func
	{
		[CompilerGenerated]
		get
		{
			return (Func<bool>)object_1;
		}
	}

	public PerformanceTester(Func<bool> func)
	{
		object_1 = func;
	}

	public void Start(int countOfThreads, DateTime dateTimeEnd)
	{
		BadRequests = 0;
		GoodRequests = 0;
		dateTime_0 = dateTimeEnd;
		object_0 = new List<Thread>();
		for (int i = 0; i < countOfThreads; i++)
		{
			((List<Thread>)object_0).Add(new Thread(PefrormanceTest)
			{
				IsBackground = true,
				Priority = ThreadPriority.Highest
			});
		}
		foreach (Thread item in (List<Thread>)object_0)
		{
			item.Start();
		}
		foreach (Thread item2 in (List<Thread>)object_0)
		{
			item2.Join();
		}
	}

	public void PefrormanceTest()
	{
		while (DateTime.Now < dateTime_0)
		{
			try
			{
				if (Func())
				{
					GoodRequests++;
				}
				else
				{
					BadRequests++;
				}
			}
			catch
			{
				BadRequests++;
			}
		}
	}
}
