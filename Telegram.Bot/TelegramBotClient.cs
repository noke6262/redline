using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Requests;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot;

public class TelegramBotClient : ITelegramBotClient
{
	[CompilerGenerated]
	private readonly long long_0;

	[CompilerGenerated]
	private object object_0;

	private static readonly object object_1 = new Update[0];

	private const string string_0 = "";

	private const string string_1 = "";

	private readonly object object_2;

	private readonly object object_3;

	private readonly object object_4;

	[CompilerGenerated]
	private IntPtr intptr_0;

	private object object_5;

	[CompilerGenerated]
	private IntPtr a;

	[CompilerGenerated]
	private object b;

	[CompilerGenerated]
	private object c;

	[CompilerGenerated]
	private object d;

	[CompilerGenerated]
	private object e;

	[CompilerGenerated]
	private object f;

	[CompilerGenerated]
	private object object_6;

	[CompilerGenerated]
	private object object_7;

	[CompilerGenerated]
	private object object_8;

	[CompilerGenerated]
	private object object_9;

	[CompilerGenerated]
	private object object_10;

	[CompilerGenerated]
	private object object_11;

	[CompilerGenerated]
	private object object_12;

	[CompilerGenerated]
	private object object_13;

	[CompilerGenerated]
	private object object_14;

	[CompilerGenerated]
	private object object_15;

	[CompilerGenerated]
	private object object_16;

	[CompilerGenerated]
	private object object_17;

	[CompilerGenerated]
	private object object_18;

	public long BotId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
	}

	public string BotUsername
	{
		[CompilerGenerated]
		get
		{
			return (string)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	public TimeSpan Timeout
	{
		get
		{
			return ((HttpClient)object_4).Timeout;
		}
		set
		{
			((HttpClient)object_4).Timeout = value;
		}
	}

	public bool IsReceiving
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_0 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)(value ? 1 : 0);
		}
	}

	public int MessageOffset
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)a;
		}
		[CompilerGenerated]
		set
		{
			a = (IntPtr)value;
		}
	}

	public event EventHandler<ApiRequestEventArgs> MakingApiRequest
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ApiRequestEventArgs> eventHandler = (EventHandler<ApiRequestEventArgs>)b;
			EventHandler<ApiRequestEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ApiRequestEventArgs> value2 = (EventHandler<ApiRequestEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ApiRequestEventArgs>>(ref b), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ApiRequestEventArgs> eventHandler = (EventHandler<ApiRequestEventArgs>)b;
			EventHandler<ApiRequestEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ApiRequestEventArgs> value2 = (EventHandler<ApiRequestEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ApiRequestEventArgs>>(ref b), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ApiResponseEventArgs> ApiResponseReceived
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ApiResponseEventArgs> eventHandler = (EventHandler<ApiResponseEventArgs>)c;
			EventHandler<ApiResponseEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ApiResponseEventArgs> value2 = (EventHandler<ApiResponseEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ApiResponseEventArgs>>(ref c), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ApiResponseEventArgs> eventHandler = (EventHandler<ApiResponseEventArgs>)c;
			EventHandler<ApiResponseEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ApiResponseEventArgs> value2 = (EventHandler<ApiResponseEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ApiResponseEventArgs>>(ref c), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<UpdateEventArgs> OnUpdate
	{
		[CompilerGenerated]
		add
		{
			EventHandler<UpdateEventArgs> eventHandler = (EventHandler<UpdateEventArgs>)d;
			EventHandler<UpdateEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<UpdateEventArgs> value2 = (EventHandler<UpdateEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<UpdateEventArgs>>(ref d), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<UpdateEventArgs> eventHandler = (EventHandler<UpdateEventArgs>)d;
			EventHandler<UpdateEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<UpdateEventArgs> value2 = (EventHandler<UpdateEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<UpdateEventArgs>>(ref d), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<MessageEventArgs> OnMessage
	{
		[CompilerGenerated]
		add
		{
			EventHandler<MessageEventArgs> eventHandler = (EventHandler<MessageEventArgs>)e;
			EventHandler<MessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MessageEventArgs> value2 = (EventHandler<MessageEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<MessageEventArgs>>(ref e), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<MessageEventArgs> eventHandler = (EventHandler<MessageEventArgs>)e;
			EventHandler<MessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MessageEventArgs> value2 = (EventHandler<MessageEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<MessageEventArgs>>(ref e), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<PollEventArgs> OnPoll
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PollEventArgs> eventHandler = (EventHandler<PollEventArgs>)f;
			EventHandler<PollEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PollEventArgs> value2 = (EventHandler<PollEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<PollEventArgs>>(ref f), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PollEventArgs> eventHandler = (EventHandler<PollEventArgs>)f;
			EventHandler<PollEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PollEventArgs> value2 = (EventHandler<PollEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<PollEventArgs>>(ref f), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<PollAnswerEventArgs> OnPollAnswer
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PollAnswerEventArgs> eventHandler = (EventHandler<PollAnswerEventArgs>)object_6;
			EventHandler<PollAnswerEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PollAnswerEventArgs> value2 = (EventHandler<PollAnswerEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<PollAnswerEventArgs>>(ref object_6), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PollAnswerEventArgs> eventHandler = (EventHandler<PollAnswerEventArgs>)object_6;
			EventHandler<PollAnswerEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PollAnswerEventArgs> value2 = (EventHandler<PollAnswerEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<PollAnswerEventArgs>>(ref object_6), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<MyChatMemberUpdatedEventArgs> OnMyChatMemberUpdated
	{
		[CompilerGenerated]
		add
		{
			EventHandler<MyChatMemberUpdatedEventArgs> eventHandler = (EventHandler<MyChatMemberUpdatedEventArgs>)object_7;
			EventHandler<MyChatMemberUpdatedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MyChatMemberUpdatedEventArgs> value2 = (EventHandler<MyChatMemberUpdatedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<MyChatMemberUpdatedEventArgs>>(ref object_7), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<MyChatMemberUpdatedEventArgs> eventHandler = (EventHandler<MyChatMemberUpdatedEventArgs>)object_7;
			EventHandler<MyChatMemberUpdatedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MyChatMemberUpdatedEventArgs> value2 = (EventHandler<MyChatMemberUpdatedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<MyChatMemberUpdatedEventArgs>>(ref object_7), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ChatMemberUpdatedEventArgs> OnChatMemberUpdated
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ChatMemberUpdatedEventArgs> eventHandler = (EventHandler<ChatMemberUpdatedEventArgs>)object_8;
			EventHandler<ChatMemberUpdatedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChatMemberUpdatedEventArgs> value2 = (EventHandler<ChatMemberUpdatedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChatMemberUpdatedEventArgs>>(ref object_8), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ChatMemberUpdatedEventArgs> eventHandler = (EventHandler<ChatMemberUpdatedEventArgs>)object_8;
			EventHandler<ChatMemberUpdatedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChatMemberUpdatedEventArgs> value2 = (EventHandler<ChatMemberUpdatedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChatMemberUpdatedEventArgs>>(ref object_8), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ChannelPostEventArgs> OnChannelPost
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ChannelPostEventArgs> eventHandler = (EventHandler<ChannelPostEventArgs>)object_9;
			EventHandler<ChannelPostEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChannelPostEventArgs> value2 = (EventHandler<ChannelPostEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChannelPostEventArgs>>(ref object_9), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ChannelPostEventArgs> eventHandler = (EventHandler<ChannelPostEventArgs>)object_9;
			EventHandler<ChannelPostEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChannelPostEventArgs> value2 = (EventHandler<ChannelPostEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChannelPostEventArgs>>(ref object_9), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ChannelPostEventArgs> OnChannelPostEdited
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ChannelPostEventArgs> eventHandler = (EventHandler<ChannelPostEventArgs>)object_10;
			EventHandler<ChannelPostEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChannelPostEventArgs> value2 = (EventHandler<ChannelPostEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChannelPostEventArgs>>(ref object_10), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ChannelPostEventArgs> eventHandler = (EventHandler<ChannelPostEventArgs>)object_10;
			EventHandler<ChannelPostEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChannelPostEventArgs> value2 = (EventHandler<ChannelPostEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChannelPostEventArgs>>(ref object_10), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<PreCheckoutQueryEventArgs> OnPreCheckoutQuery
	{
		[CompilerGenerated]
		add
		{
			EventHandler<PreCheckoutQueryEventArgs> eventHandler = (EventHandler<PreCheckoutQueryEventArgs>)object_11;
			EventHandler<PreCheckoutQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PreCheckoutQueryEventArgs> value2 = (EventHandler<PreCheckoutQueryEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<PreCheckoutQueryEventArgs>>(ref object_11), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<PreCheckoutQueryEventArgs> eventHandler = (EventHandler<PreCheckoutQueryEventArgs>)object_11;
			EventHandler<PreCheckoutQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<PreCheckoutQueryEventArgs> value2 = (EventHandler<PreCheckoutQueryEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<PreCheckoutQueryEventArgs>>(ref object_11), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ShippingQueryEventArgs> OnShippingQuery
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ShippingQueryEventArgs> eventHandler = (EventHandler<ShippingQueryEventArgs>)object_12;
			EventHandler<ShippingQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ShippingQueryEventArgs> value2 = (EventHandler<ShippingQueryEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ShippingQueryEventArgs>>(ref object_12), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ShippingQueryEventArgs> eventHandler = (EventHandler<ShippingQueryEventArgs>)object_12;
			EventHandler<ShippingQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ShippingQueryEventArgs> value2 = (EventHandler<ShippingQueryEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ShippingQueryEventArgs>>(ref object_12), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<MessageEventArgs> OnMessageEdited
	{
		[CompilerGenerated]
		add
		{
			EventHandler<MessageEventArgs> eventHandler = (EventHandler<MessageEventArgs>)object_13;
			EventHandler<MessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MessageEventArgs> value2 = (EventHandler<MessageEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<MessageEventArgs>>(ref object_13), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<MessageEventArgs> eventHandler = (EventHandler<MessageEventArgs>)object_13;
			EventHandler<MessageEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MessageEventArgs> value2 = (EventHandler<MessageEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<MessageEventArgs>>(ref object_13), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<InlineQueryEventArgs> OnInlineQuery
	{
		[CompilerGenerated]
		add
		{
			EventHandler<InlineQueryEventArgs> eventHandler = (EventHandler<InlineQueryEventArgs>)object_14;
			EventHandler<InlineQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<InlineQueryEventArgs> value2 = (EventHandler<InlineQueryEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<InlineQueryEventArgs>>(ref object_14), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<InlineQueryEventArgs> eventHandler = (EventHandler<InlineQueryEventArgs>)object_14;
			EventHandler<InlineQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<InlineQueryEventArgs> value2 = (EventHandler<InlineQueryEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<InlineQueryEventArgs>>(ref object_14), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ChosenInlineResultEventArgs> OnInlineResultChosen
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ChosenInlineResultEventArgs> eventHandler = (EventHandler<ChosenInlineResultEventArgs>)object_15;
			EventHandler<ChosenInlineResultEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChosenInlineResultEventArgs> value2 = (EventHandler<ChosenInlineResultEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChosenInlineResultEventArgs>>(ref object_15), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ChosenInlineResultEventArgs> eventHandler = (EventHandler<ChosenInlineResultEventArgs>)object_15;
			EventHandler<ChosenInlineResultEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ChosenInlineResultEventArgs> value2 = (EventHandler<ChosenInlineResultEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ChosenInlineResultEventArgs>>(ref object_15), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<CallbackQueryEventArgs> OnCallbackQuery
	{
		[CompilerGenerated]
		add
		{
			EventHandler<CallbackQueryEventArgs> eventHandler = (EventHandler<CallbackQueryEventArgs>)object_16;
			EventHandler<CallbackQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<CallbackQueryEventArgs> value2 = (EventHandler<CallbackQueryEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<CallbackQueryEventArgs>>(ref object_16), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<CallbackQueryEventArgs> eventHandler = (EventHandler<CallbackQueryEventArgs>)object_16;
			EventHandler<CallbackQueryEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<CallbackQueryEventArgs> value2 = (EventHandler<CallbackQueryEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<CallbackQueryEventArgs>>(ref object_16), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ReceiveErrorEventArgs> OnReceiveError
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ReceiveErrorEventArgs> eventHandler = (EventHandler<ReceiveErrorEventArgs>)object_17;
			EventHandler<ReceiveErrorEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ReceiveErrorEventArgs> value2 = (EventHandler<ReceiveErrorEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ReceiveErrorEventArgs>>(ref object_17), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ReceiveErrorEventArgs> eventHandler = (EventHandler<ReceiveErrorEventArgs>)object_17;
			EventHandler<ReceiveErrorEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ReceiveErrorEventArgs> value2 = (EventHandler<ReceiveErrorEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ReceiveErrorEventArgs>>(ref object_17), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<ReceiveGeneralErrorEventArgs> OnReceiveGeneralError
	{
		[CompilerGenerated]
		add
		{
			EventHandler<ReceiveGeneralErrorEventArgs> eventHandler = (EventHandler<ReceiveGeneralErrorEventArgs>)object_18;
			EventHandler<ReceiveGeneralErrorEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ReceiveGeneralErrorEventArgs> value2 = (EventHandler<ReceiveGeneralErrorEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ReceiveGeneralErrorEventArgs>>(ref object_18), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<ReceiveGeneralErrorEventArgs> eventHandler = (EventHandler<ReceiveGeneralErrorEventArgs>)object_18;
			EventHandler<ReceiveGeneralErrorEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ReceiveGeneralErrorEventArgs> value2 = (EventHandler<ReceiveGeneralErrorEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref System.Runtime.CompilerServices.Unsafe.As<object, EventHandler<ReceiveGeneralErrorEventArgs>>(ref object_18), value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void OnUpdateReceived(UpdateEventArgs e)
	{
		((EventHandler<UpdateEventArgs>)d)?.Invoke((object)this, e);
		switch (e.Update.Type)
		{
		case UpdateType.Message:
			((EventHandler<MessageEventArgs>)this.e)?.Invoke((object)this, (MessageEventArgs)e);
			break;
		case UpdateType.InlineQuery:
			((EventHandler<InlineQueryEventArgs>)object_14)?.Invoke((object)this, (InlineQueryEventArgs)e);
			break;
		case UpdateType.ChosenInlineResult:
			((EventHandler<ChosenInlineResultEventArgs>)object_15)?.Invoke((object)this, (ChosenInlineResultEventArgs)e);
			break;
		case UpdateType.CallbackQuery:
			((EventHandler<CallbackQueryEventArgs>)object_16)?.Invoke((object)this, (CallbackQueryEventArgs)e);
			break;
		case UpdateType.EditedMessage:
			((EventHandler<MessageEventArgs>)object_13)?.Invoke((object)this, (MessageEventArgs)e);
			break;
		case UpdateType.ChannelPost:
			((EventHandler<ChannelPostEventArgs>)object_9)?.Invoke((object)this, (ChannelPostEventArgs)e);
			break;
		case UpdateType.EditedChannelPost:
			((EventHandler<ChannelPostEventArgs>)object_10)?.Invoke((object)this, (ChannelPostEventArgs)e);
			break;
		case UpdateType.ShippingQuery:
			((EventHandler<ShippingQueryEventArgs>)object_12)?.Invoke((object)this, (ShippingQueryEventArgs)e);
			break;
		case UpdateType.PreCheckoutQuery:
			((EventHandler<PreCheckoutQueryEventArgs>)object_11)?.Invoke((object)this, (PreCheckoutQueryEventArgs)e);
			break;
		case UpdateType.Poll:
			((EventHandler<PollEventArgs>)f)?.Invoke((object)this, (PollEventArgs)e);
			break;
		case UpdateType.PollAnswer:
			((EventHandler<PollAnswerEventArgs>)object_6)?.Invoke((object)this, (PollAnswerEventArgs)e);
			break;
		case UpdateType.MyChatMemberUpdated:
			((EventHandler<MyChatMemberUpdatedEventArgs>)object_7)?.Invoke((object)this, (MyChatMemberUpdatedEventArgs)e);
			break;
		case UpdateType.ChatMemberUpdated:
			((EventHandler<ChatMemberUpdatedEventArgs>)object_8)?.Invoke((object)this, (ChatMemberUpdatedEventArgs)e);
			break;
		}
	}

	public TelegramBotClient(string token, HttpClient httpClient = null)
	{
		object_3 = token ?? throw new ArgumentNullException("token");
		string[] array = ((string)object_3).Split(new char[1] { ':' });
		if (array.Length > 1 && long.TryParse(array[0], out var result))
		{
			long_0 = result;
			object_2 = "https://api.telegram.org/bot" + (string)object_3 + "/";
			object_4 = httpClient ?? new HttpClient();
			return;
		}
		throw new ArgumentException("Invalid format. A valid token looks like \"1234567:4TT8bAc8GHUspu3ERYn-KGcvsvGB9u_n4ddy\".", "token");
	}

	public TelegramBotClient(string token, IWebProxy webProxy)
	{
		object_3 = token ?? throw new ArgumentNullException("token");
		if (!long.TryParse(((string)object_3).Split(new char[1] { ':' })[0], out var result))
		{
			throw new ArgumentException("Invalid format. A valid token looks like \"1234567:4TT8bAc8GHUspu3ERYn-KGcvsvGB9u_n4ddy\".", "token");
		}
		long_0 = result;
		object_2 = "https://api.telegram.org/bot" + (string)object_3 + "/";
		HttpClientHandler handler = new HttpClientHandler
		{
			Proxy = webProxy,
			UseProxy = true
		};
		object_4 = new HttpClient(handler);
	}

	public async Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
	{
		string requestUri = (string)object_2 + request.MethodName;
		HttpRequestMessage httpRequestMessage = new HttpRequestMessage(request.Method, requestUri)
		{
			Content = request.ToHttpContent()
		};
		ApiRequestEventArgs reqDataArgs = new ApiRequestEventArgs
		{
			MethodName = request.MethodName,
			HttpContent = httpRequestMessage.Content
		};
		((EventHandler<ApiRequestEventArgs>)b)?.Invoke((object)this, reqDataArgs);
		HttpResponseMessage httpResponse;
		try
		{
			httpResponse = await ((HttpMessageInvoker)object_4).SendAsync(httpRequestMessage, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (TaskCanceledException innerException)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				throw;
			}
			throw new ApiRequestException("Request timed out", 408, innerException);
		}
		HttpStatusCode actualResponseStatusCode = httpResponse.StatusCode;
		string text = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
		((EventHandler<ApiResponseEventArgs>)c)?.Invoke((object)this, new ApiResponseEventArgs
		{
			ResponseMessage = httpResponse,
			ApiRequestEventArgs = reqDataArgs
		});
		switch (actualResponseStatusCode)
		{
		case HttpStatusCode.Conflict:
			if (!string.IsNullOrWhiteSpace(text))
			{
				break;
			}
			goto default;
		case HttpStatusCode.BadRequest:
			if (!string.IsNullOrWhiteSpace(text))
			{
				break;
			}
			goto default;
		case HttpStatusCode.Forbidden:
			if (!string.IsNullOrWhiteSpace(text))
			{
				break;
			}
			goto default;
		default:
			httpResponse.EnsureSuccessStatusCode();
			break;
		case HttpStatusCode.OK:
		case HttpStatusCode.Unauthorized:
			break;
		}
		ApiResponse<TResponse> apiResponse = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(text) ?? new ApiResponse<TResponse>
		{
			Ok = false,
			Description = "No response received"
		};
		if (apiResponse.Ok)
		{
			return apiResponse.Result;
		}
		throw ApiExceptionParser.Parse(apiResponse);
	}

	public async Task<bool> TestApiAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		try
		{
			await GetMeAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return true;
		}
		catch (ApiRequestException ex) when (ex.Telegram_002EBot_002EExceptions_002EApiRequestException_002EErrorCode == 401)
		{
			return false;
		}
	}

	public void StartReceiving(UpdateType[] allowedUpdates = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		SetSsl();
		object_5 = new CancellationTokenSource();
		cancellationToken.Register(delegate
		{
			((CancellationTokenSource)object_5).Cancel();
		});
		method_0(allowedUpdates, ((CancellationTokenSource)object_5).Token);
	}

	public void SetSsl()
	{
		ServicePointManager.Expect100Continue = true;
		ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
	}

	public InputOnlineFile GetInputImage(Image image)
	{
		MemoryStream memoryStream = new MemoryStream();
		if (image.Width <= 1280 && image.Height <= 720)
		{
			image.Save(memoryStream, ImageFormat.Png);
		}
		else
		{
			int num = image.Width / 1280;
			int num2 = image.Height / 720;
			int width = ((image.Width >= image.Height) ? (image.Width / num) : (image.Width / num2));
			int height = ((image.Width >= image.Height) ? (image.Height / num) : (image.Height / num2));
			new Bitmap(image, new Size(width, height)).Save(memoryStream, ImageFormat.Png);
		}
		memoryStream.Position = 0L;
		return new InputOnlineFile(memoryStream);
	}

	public InputOnlineFile GetInputFile(string path, out FileStream stream)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open);
		InputOnlineFile result = new InputOnlineFile(fileStream, Path.GetFileName(path));
		stream = fileStream;
		return result;
	}

	private async void method_0(object allowedUpdates, CancellationToken cancellationToken = default(CancellationToken))
	{
		IsReceiving = true;
		while (!cancellationToken.IsCancellationRequested)
		{
			int timeout = Convert.ToInt32(Timeout.TotalSeconds);
			object obj = object_1;
			try
			{
				obj = await GetUpdatesAsync(MessageOffset, 0, timeout, (IEnumerable<UpdateType>)allowedUpdates, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
			}
			catch (ApiRequestException ex2)
			{
				((EventHandler<ReceiveErrorEventArgs>)object_17)?.Invoke((object)this, (ReceiveErrorEventArgs)ex2);
			}
			catch (Exception ex3)
			{
				((EventHandler<ReceiveGeneralErrorEventArgs>)object_18)?.Invoke((object)this, (ReceiveGeneralErrorEventArgs)ex3);
			}
			try
			{
				Update[] array = (Update[])obj;
				foreach (Update update in array)
				{
					OnUpdateReceived(new UpdateEventArgs(update));
					MessageOffset = update.Id + 1;
				}
			}
			catch
			{
				IsReceiving = false;
				throw;
			}
		}
		IsReceiving = false;
	}

	public void StopReceiving()
	{
		try
		{
			((CancellationTokenSource)object_5).Cancel();
		}
		catch (WebException)
		{
		}
		catch (TaskCanceledException)
		{
		}
	}

	public Task<Update[]> GetUpdatesAsync(int offset = 0, int limit = 0, int timeout = 0, IEnumerable<UpdateType> allowedUpdates = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetUpdatesRequest
		{
			Offset = offset,
			Limit = limit,
			Timeout = timeout,
			AllowedUpdates = allowedUpdates
		}, cancellationToken);
	}

	public Task SetWebhookAsync(string url, InputFileStream certificate = null, string ipAddress = null, int maxConnections = 0, IEnumerable<UpdateType> allowedUpdates = null, bool dropPendingUpdates = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetWebhookRequest(url, certificate)
		{
			IpAddress = ipAddress,
			MaxConnections = maxConnections,
			AllowedUpdates = allowedUpdates,
			DropPendingUpdates = dropPendingUpdates
		}, cancellationToken);
	}

	public Task DeleteWebhookAsync(bool dropPendingUpdates = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new DeleteWebhookRequest
		{
			DropPendingUpdates = dropPendingUpdates
		}, cancellationToken);
	}

	public Task<WebhookInfo> GetWebhookInfoAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetWebhookInfoRequest(), cancellationToken);
	}

	public Task<User> GetMeAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetMeRequest(), cancellationToken);
	}

	public Task LogOutAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new LogOutRequest(), cancellationToken);
	}

	public Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new CloseRequest(), cancellationToken);
	}

	public Task<Message> SafeSendTextMessage(ChatId chatId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendMessageRequest(chatId, text)
		{
			ParseMode = parseMode,
			Entities = entities,
			DisableWebPagePreview = disableWebPagePreview,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> ForwardMessageAsync(ChatId chatId, ChatId fromChatId, int messageId, bool disableNotification = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new ForwardMessageRequest(chatId, fromChatId, messageId)
		{
			DisableNotification = disableNotification
		}, cancellationToken);
	}

	public Task<MessageId> CopyMessageAsync(ChatId chatId, ChatId fromChatId, int messageId, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new CopyMessageRequest(chatId, fromChatId, messageId)
		{
			Caption = caption,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			DisableNotification = disableNotification,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendPhotoAsync(ChatId chatId, InputOnlineFile photo, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendPhotoRequest(chatId, photo)
		{
			Caption = caption,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			DisableNotification = disableNotification,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendAudioAsync(ChatId chatId, InputOnlineFile audio, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, int duration = 0, string performer = null, string title = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		return MakeRequestAsync(new SendAudioRequest(chatId, audio)
		{
			Caption = caption,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			Duration = duration,
			Performer = performer,
			Title = title,
			Thumb = thumb,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendDocumentAsync(ChatId chatId, InputOnlineFile document, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableContentTypeDetection = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		return MakeRequestAsync(new SendDocumentRequest(chatId, document)
		{
			Caption = caption,
			Thumb = thumb,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			DisableContentTypeDetection = disableContentTypeDetection,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendStickerAsync(ChatId chatId, InputOnlineFile sticker, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendStickerRequest(chatId, sticker)
		{
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendVideoAsync(ChatId chatId, InputOnlineFile video, int duration = 0, int width = 0, int height = 0, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool supportsStreaming = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		return MakeRequestAsync(new SendVideoRequest(chatId, video)
		{
			Duration = duration,
			Width = width,
			Height = height,
			Thumb = thumb,
			Caption = caption,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			SupportsStreaming = supportsStreaming,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendAnimationAsync(ChatId chatId, InputOnlineFile animation, int duration = 0, int width = 0, int height = 0, InputMedia thumb = null, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendAnimationRequest(chatId, animation)
		{
			Duration = duration,
			Width = width,
			Height = height,
			Thumb = thumb,
			Caption = caption,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendVoiceAsync(ChatId chatId, InputOnlineFile voice, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, int duration = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendVoiceRequest(chatId, voice)
		{
			Caption = caption,
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			Duration = duration,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendVideoNoteAsync(ChatId chatId, InputTelegramFile videoNote, int duration = 0, int length = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		return MakeRequestAsync(new SendVideoNoteRequest(chatId, videoNote)
		{
			Duration = duration,
			Length = length,
			Thumb = thumb,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message[]> SendMediaGroupAsync(ChatId chatId, IEnumerable<InputMediaBase> media, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		IAlbumInputMedia[] media2 = (from m in media
			select m as IAlbumInputMedia into m
			where m != null
			select m).ToArray();
		return MakeRequestAsync(new SendMediaGroupRequest(chatId, media2)
		{
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply
		}, cancellationToken);
	}

	public Task<Message[]> SendMediaGroupAsync(IEnumerable<IAlbumInputMedia> inputMedia, ChatId chatId, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendMediaGroupRequest(chatId, inputMedia)
		{
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply
		}, cancellationToken);
	}

	public Task<Message> SendLocationAsync(ChatId chatId, float latitude, float longitude, float horizontalAccuracy = 0f, int livePeriod = 0, int heading = 0, int proximityAlertRadius = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendLocationRequest(chatId, latitude, longitude)
		{
			HorizontalAccuracy = horizontalAccuracy,
			LivePeriod = livePeriod,
			Heading = heading,
			ProximityAlertRadius = proximityAlertRadius,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendVenueAsync(ChatId chatId, float latitude, float longitude, string title, string address, string foursquareId = null, string foursquareType = null, string googlePlaceId = null, string googlePlaceType = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendVenueRequest(chatId, latitude, longitude, title, address)
		{
			FoursquareId = foursquareId,
			FoursquareType = foursquareType,
			GooglePlaceId = googlePlaceId,
			GooglePlaceType = googlePlaceType,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendContactAsync(ChatId chatId, string phoneNumber, string firstName, string lastName = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), string vCard = null)
	{
		return MakeRequestAsync(new SendContactRequest(chatId, phoneNumber, firstName)
		{
			LastName = lastName,
			Vcard = vCard,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SendPollAsync(ChatId chatId, string question, IEnumerable<string> options, string explanation = null, ParseMode explanationParseMode = ParseMode.Default, MessageEntity[] explanationEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, bool isAnonymous = true, PollType type = PollType.Regular, bool allowsMultipleAnswers = false, int correctOptionId = 0, int openPeriod = 0, DateTime closeDate = default(DateTime), bool isClosed = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendPollRequest(chatId, question, options)
		{
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup,
			IsAnonymous = isAnonymous,
			Type = type,
			Explanation = explanation,
			ExplanationParseMode = explanationParseMode,
			ExplanationEntities = explanationEntities,
			AllowsMultipleAnswers = allowsMultipleAnswers,
			CorrectOptionId = correctOptionId,
			OpenPeriod = openPeriod,
			CloseDate = closeDate,
			IsClosed = isClosed
		}, cancellationToken);
	}

	public Task<Message> SendDiceAsync(ChatId chatId, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), Emoji? emoji = null)
	{
		return MakeRequestAsync(new SendDiceRequest(chatId)
		{
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup,
			Emoji = emoji
		}, cancellationToken);
	}

	public Task SendChatActionAsync(ChatId chatId, ChatAction chatAction, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendChatActionRequest(chatId, chatAction), cancellationToken);
	}

	public Task<UserProfilePhotos> GetUserProfilePhotosAsync(long userId, int offset = 0, int limit = 0, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetUserProfilePhotosRequest(userId)
		{
			Offset = offset,
			Limit = limit
		}, cancellationToken);
	}

	public Task<Telegram.Bot.Types.File> GetFileAsync(string fileId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetFileRequest(fileId), cancellationToken);
	}

	[Obsolete("This method will be removed in next major release. Use its overload instead.")]
	public async Task<Stream> DownloadFileAsync(string filePath, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = new MemoryStream();
		await DownloadFileAsync(filePath, (Stream)obj, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return (Stream)obj;
	}

	public async Task DownloadFileAsync(string filePath, Stream destination, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (!string.IsNullOrWhiteSpace(filePath) && filePath.Length >= 2)
		{
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			Uri requestUri = new Uri("https://api.telegram.org/file/bot" + (string)object_3 + "/" + filePath);
			HttpResponseMessage httpResponseMessage = await ((HttpClient)object_4).GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			httpResponseMessage.EnsureSuccessStatusCode();
			object obj = httpResponseMessage;
			try
			{
				await httpResponseMessage.Content.CopyToAsync(destination).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
			return;
		}
		throw new ArgumentException("Invalid file path", "filePath");
	}

	public async Task<Telegram.Bot.Types.File> GetInfoAndDownloadFileAsync(string fileId, Stream destination, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = await GetFileAsync(fileId, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		await DownloadFileAsync(((Telegram.Bot.Types.File)obj).FilePath, destination, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		return (Telegram.Bot.Types.File)obj;
	}

	public async Task<bool> DownloadFileAsync(string fileId, string path)
	{
		try
		{
			FileStream destination;
			object obj = (destination = System.IO.File.OpenWrite(path));
			try
			{
				await GetInfoAndDownloadFileAsync(fileId, destination);
				return true;
			}
			finally
			{
				((IDisposable)obj)?.Dispose();
			}
		}
		catch
		{
			return false;
		}
	}

	public Task KickChatMemberAsync(ChatId chatId, long userId, DateTime untilDate = default(DateTime), bool revokeMessages = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new KickChatMemberRequest(chatId, userId)
		{
			UntilDate = untilDate,
			RevokeMessages = revokeMessages
		}, cancellationToken);
	}

	public Task LeaveChatAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new LeaveChatRequest(chatId), cancellationToken);
	}

	public Task UnbanChatMemberAsync(ChatId chatId, long userId, bool onlyIfBanned = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new UnbanChatMemberRequest(chatId, userId)
		{
			OnlyIfBanned = onlyIfBanned
		}, cancellationToken);
	}

	public Task<Chat> GetChatAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetChatRequest(chatId), cancellationToken);
	}

	public Task<ChatMember[]> GetChatAdministratorsAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetChatAdministratorsRequest(chatId), cancellationToken);
	}

	public Task<int> GetChatMembersCountAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetChatMembersCountRequest(chatId), cancellationToken);
	}

	public Task<ChatMember> GetChatMemberAsync(ChatId chatId, long userId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetChatMemberRequest(chatId, userId), cancellationToken);
	}

	public Task AnswerCallbackQueryAsync(string callbackQueryId, string text = null, bool showAlert = false, string url = null, int cacheTime = 0, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AnswerCallbackQueryRequest(callbackQueryId)
		{
			Text = text,
			ShowAlert = showAlert,
			Url = url,
			CacheTime = cacheTime
		}, cancellationToken);
	}

	public Task RestrictChatMemberAsync(ChatId chatId, long userId, ChatPermissions permissions, DateTime untilDate = default(DateTime), CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new RestrictChatMemberRequest(chatId, userId, permissions)
		{
			UntilDate = untilDate
		}, cancellationToken);
	}

	public Task PromoteChatMemberAsync(ChatId chatId, long userId, bool? isAnonymous = null, bool? canManageChat = null, bool? canChangeInfo = null, bool? canPostMessages = null, bool? canEditMessages = null, bool? canDeleteMessages = null, bool? canManageVoiceChats = null, bool? canInviteUsers = null, bool? canRestrictMembers = null, bool? canPinMessages = null, bool? canPromoteMembers = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new PromoteChatMemberRequest(chatId, userId)
		{
			IsAnonymous = isAnonymous,
			CanManageChat = canManageChat,
			CanChangeInfo = canChangeInfo,
			CanPostMessages = canPostMessages,
			CanEditMessages = canEditMessages,
			CanDeleteMessages = canDeleteMessages,
			CanManageVoiceChats = canManageVoiceChats,
			CanInviteUsers = canInviteUsers,
			CanRestrictMembers = canRestrictMembers,
			CanPinMessages = canPinMessages,
			CanPromoteMembers = canPromoteMembers
		}, cancellationToken);
	}

	public Task SetChatAdministratorCustomTitleAsync(ChatId chatId, long userId, string customTitle, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetChatAdministratorCustomTitleRequest(chatId, userId, customTitle), cancellationToken);
	}

	public Task SetChatPermissionsAsync(ChatId chatId, ChatPermissions permissions, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetChatPermissionsRequest(chatId, permissions), cancellationToken);
	}

	public Task<BotCommand[]> GetMyCommandsAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetMyCommandsRequest(), cancellationToken);
	}

	public Task SetMyCommandsAsync(IEnumerable<BotCommand> commands, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetMyCommandsRequest(commands), cancellationToken);
	}

	public Task<Message> StopMessageLiveLocationAsync(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new StopMessageLiveLocationRequest(chatId, messageId)
		{
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task StopMessageLiveLocationAsync(string inlineMessageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new StopInlineMessageLiveLocationRequest(inlineMessageId)
		{
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> EditMessageTextAsync(ChatId chatId, int messageId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditMessageTextRequest(chatId, messageId, text)
		{
			ParseMode = parseMode,
			Entities = entities,
			DisableWebPagePreview = disableWebPagePreview,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task EditMessageTextAsync(string inlineMessageId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditInlineMessageTextRequest(inlineMessageId, text)
		{
			DisableWebPagePreview = disableWebPagePreview,
			ReplyMarkup = replyMarkup,
			ParseMode = parseMode,
			Entities = entities
		}, cancellationToken);
	}

	public Task<Message> EditMessageCaptionAsync(ChatId chatId, int messageId, string caption, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditMessageCaptionRequest(chatId, messageId, caption)
		{
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task EditMessageCaptionAsync(string inlineMessageId, string caption, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditInlineMessageCaptionRequest(inlineMessageId, caption)
		{
			ParseMode = parseMode,
			CaptionEntities = captionEntities,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> EditMessageMediaAsync(ChatId chatId, int messageId, InputMediaBase media, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditMessageMediaRequest(chatId, messageId, media)
		{
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task EditMessageMediaAsync(string inlineMessageId, InputMediaBase media, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditInlineMessageMediaRequest(inlineMessageId, media)
		{
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> EditMessageReplyMarkupAsync(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditMessageReplyMarkupRequest(chatId, messageId, replyMarkup), cancellationToken);
	}

	public Task EditMessageReplyMarkupAsync(string inlineMessageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditInlineMessageReplyMarkupRequest(inlineMessageId, replyMarkup), cancellationToken);
	}

	public Task<Message> EditMessageLiveLocationAsync(ChatId chatId, int messageId, float latitude, float longitude, float horizontalAccuracy = 0f, int heading = 0, int proximityAlertRadius = 0, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditMessageLiveLocationRequest(chatId, messageId, latitude, longitude)
		{
			HorizontalAccuracy = horizontalAccuracy,
			Heading = heading,
			ProximityAlertRadius = proximityAlertRadius,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task EditMessageLiveLocationAsync(string inlineMessageId, float latitude, float longitude, float horizontalAccuracy = 0f, int heading = 0, int proximityAlertRadius = 0, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditInlineMessageLiveLocationRequest(inlineMessageId, latitude, longitude)
		{
			HorizontalAccuracy = horizontalAccuracy,
			Heading = heading,
			ProximityAlertRadius = proximityAlertRadius,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Poll> StopPollAsync(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new StopPollRequest(chatId, messageId)
		{
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task DeleteMessageAsync(ChatId chatId, int messageId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new DeleteMessageRequest(chatId, messageId), cancellationToken);
	}

	public Task AnswerInlineQueryAsync(string inlineQueryId, IEnumerable<InlineQueryResultBase> results, int? cacheTime = null, bool isPersonal = false, string nextOffset = null, string switchPmText = null, string switchPmParameter = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AnswerInlineQueryRequest(inlineQueryId, results)
		{
			CacheTime = cacheTime,
			IsPersonal = isPersonal,
			NextOffset = nextOffset,
			SwitchPmText = switchPmText,
			SwitchPmParameter = switchPmParameter
		}, cancellationToken);
	}

	public Task<Message> SendInvoiceAsync(int chatId, string title, string description, string payload, string providerToken, string currency, IEnumerable<LabeledPrice> prices, int maxTipAmount = 0, int[] suggestedTipAmounts = null, string startParameter = null, string providerData = null, string photoUrl = null, int photoSize = 0, int photoWidth = 0, int photoHeight = 0, bool needName = false, bool needPhoneNumber = false, bool needEmail = false, bool needShippingAddress = false, bool isFlexible = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), bool sendPhoneNumberToProvider = false, bool sendEmailToProvider = false)
	{
		return MakeRequestAsync(new SendInvoiceRequest(chatId, title, description, payload, providerToken, currency, prices)
		{
			MaxTipAmount = maxTipAmount,
			SuggestedTipAmounts = suggestedTipAmounts,
			StartParameter = startParameter,
			ProviderData = providerData,
			PhotoUrl = photoUrl,
			PhotoSize = photoSize,
			PhotoWidth = photoWidth,
			PhotoHeight = photoHeight,
			NeedName = needName,
			NeedPhoneNumber = needPhoneNumber,
			NeedEmail = needEmail,
			NeedShippingAddress = needShippingAddress,
			SendPhoneNumberToProvider = sendPhoneNumberToProvider,
			SendEmailToProvider = sendEmailToProvider,
			IsFlexible = isFlexible,
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task AnswerShippingQueryAsync(string shippingQueryId, IEnumerable<ShippingOption> shippingOptions, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AnswerShippingQueryRequest(shippingQueryId, shippingOptions), cancellationToken);
	}

	public Task AnswerShippingQueryAsync(string shippingQueryId, string errorMessage, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AnswerShippingQueryRequest(shippingQueryId, errorMessage), cancellationToken);
	}

	public Task AnswerPreCheckoutQueryAsync(string preCheckoutQueryId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AnswerPreCheckoutQueryRequest(preCheckoutQueryId), cancellationToken);
	}

	public Task AnswerPreCheckoutQueryAsync(string preCheckoutQueryId, string errorMessage, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AnswerPreCheckoutQueryRequest(preCheckoutQueryId, errorMessage), cancellationToken);
	}

	public Task<Message> SendGameAsync(long chatId, string gameShortName, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SendGameRequest(chatId, gameShortName)
		{
			DisableNotification = disableNotification,
			ReplyToMessageId = replyToMessageId,
			AllowSendingWithoutReply = allowSendingWithoutReply,
			ReplyMarkup = replyMarkup
		}, cancellationToken);
	}

	public Task<Message> SetGameScoreAsync(long userId, int score, long chatId, int messageId, bool force = false, bool disableEditMessage = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetGameScoreRequest(userId, score, chatId, messageId)
		{
			Force = force,
			DisableEditMessage = disableEditMessage
		}, cancellationToken);
	}

	public Task SetGameScoreAsync(long userId, int score, string inlineMessageId, bool force = false, bool disableEditMessage = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetInlineGameScoreRequest(userId, score, inlineMessageId)
		{
			Force = force,
			DisableEditMessage = disableEditMessage
		}, cancellationToken);
	}

	public Task<GameHighScore[]> GetGameHighScoresAsync(long userId, long chatId, int messageId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetGameHighScoresRequest(userId, chatId, messageId), cancellationToken);
	}

	public Task<GameHighScore[]> GetGameHighScoresAsync(long userId, string inlineMessageId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetInlineGameHighScoresRequest(userId, inlineMessageId), cancellationToken);
	}

	public Task<string> ExportChatInviteLinkAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new ExportChatInviteLinkRequest(chatId), cancellationToken);
	}

	public Task<ChatInviteLink> CreateChatInviteLinkAsync(ChatId chatId, DateTime expireDate = default(DateTime), int memberLimit = 0, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new CreateChatInviteLinkRequest(chatId)
		{
			ExpireDate = expireDate,
			MemberLimit = memberLimit
		}, cancellationToken);
	}

	public Task<ChatInviteLink> EditChatInviteLinkAsync(ChatId chatId, string inviteLink, DateTime expireDate = default(DateTime), int memberLimit = 0, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new EditChatInviteLinkRequest(chatId, inviteLink)
		{
			ExpireDate = expireDate,
			MemberLimit = memberLimit
		}, cancellationToken);
	}

	public Task<ChatInviteLink> RevokeChatInviteLinkAsync(ChatId chatId, string inviteLink, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new RevokeChatInviteLinkRequest(chatId, inviteLink), cancellationToken);
	}

	public Task SetChatPhotoAsync(ChatId chatId, InputFileStream photo, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetChatPhotoRequest(chatId, photo), cancellationToken);
	}

	public Task DeleteChatPhotoAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new DeleteChatPhotoRequest(chatId), cancellationToken);
	}

	public Task SetChatTitleAsync(ChatId chatId, string title, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetChatTitleRequest(chatId, title), cancellationToken);
	}

	public Task SetChatDescriptionAsync(ChatId chatId, string description = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetChatDescriptionRequest(chatId, description), cancellationToken);
	}

	public Task PinChatMessageAsync(ChatId chatId, int messageId, bool disableNotification = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new PinChatMessageRequest(chatId, messageId)
		{
			DisableNotification = disableNotification
		}, cancellationToken);
	}

	public Task UnpinChatMessageAsync(ChatId chatId, int messageId = 0, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new UnpinChatMessageRequest(chatId)
		{
			MessageId = messageId
		}, cancellationToken);
	}

	public Task UnpinAllChatMessagesAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new UnpinAllChatMessagesRequest(chatId), cancellationToken);
	}

	public Task SetChatStickerSetAsync(ChatId chatId, string stickerSetName, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetChatStickerSetRequest(chatId, stickerSetName), cancellationToken);
	}

	public Task DeleteChatStickerSetAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new DeleteChatStickerSetRequest(chatId), cancellationToken);
	}

	public Task<StickerSet> GetStickerSetAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new GetStickerSetRequest(name), cancellationToken);
	}

	public Task<Telegram.Bot.Types.File> UploadStickerFileAsync(long userId, InputFileStream pngSticker, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new UploadStickerFileRequest(userId, pngSticker), cancellationToken);
	}

	public Task CreateNewStickerSetAsync(long userId, string name, string title, InputOnlineFile pngSticker, string emojis, bool isMasks = false, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new CreateNewStickerSetRequest(userId, name, title, pngSticker, emojis)
		{
			ContainsMasks = isMasks,
			MaskPosition = maskPosition
		}, cancellationToken);
	}

	public Task AddStickerToSetAsync(long userId, string name, InputOnlineFile pngSticker, string emojis, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AddStickerToSetRequest(userId, name, pngSticker, emojis)
		{
			MaskPosition = maskPosition
		}, cancellationToken);
	}

	public Task CreateNewAnimatedStickerSetAsync(long userId, string name, string title, InputFileStream tgsSticker, string emojis, bool isMasks = false, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new CreateNewAnimatedStickerSetRequest(userId, name, title, tgsSticker, emojis)
		{
			ContainsMasks = isMasks,
			MaskPosition = maskPosition
		}, cancellationToken);
	}

	public Task AddAnimatedStickerToSetAsync(long userId, string name, InputFileStream tgsSticker, string emojis, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new AddAnimatedStickerToSetRequest(userId, name, tgsSticker, emojis)
		{
			MaskPosition = maskPosition
		}, cancellationToken);
	}

	public Task SetStickerPositionInSetAsync(string sticker, int position, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetStickerPositionInSetRequest(sticker, position), cancellationToken);
	}

	public Task DeleteStickerFromSetAsync(string sticker, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new DeleteStickerFromSetRequest(sticker), cancellationToken);
	}

	public Task SetStickerSetThumbAsync(string name, long userId, InputOnlineFile thumb = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return MakeRequestAsync(new SetStickerSetThumbRequest(name, userId, thumb), cancellationToken);
	}

	[CompilerGenerated]
	private void method_1()
	{
		((CancellationTokenSource)object_5).Cancel();
	}
}
