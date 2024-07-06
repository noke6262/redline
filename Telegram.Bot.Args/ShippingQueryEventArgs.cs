using System;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;

namespace Telegram.Bot.Args;

public class ShippingQueryEventArgs : EventArgs
{
	[CompilerGenerated]
	private object object_0;

	public ShippingQuery ShippingQuery
	{
		[CompilerGenerated]
		get
		{
			return (ShippingQuery)object_0;
		}
		[CompilerGenerated]
		private set
		{
			object_0 = value;
		}
	}

	internal ShippingQueryEventArgs(Update update)
	{
		ShippingQuery = update.ShippingQuery;
	}

	internal ShippingQueryEventArgs(ShippingQuery shippingQuery)
	{
		ShippingQuery = shippingQuery;
	}

	public static implicit operator ShippingQueryEventArgs(UpdateEventArgs e)
	{
		return new ShippingQueryEventArgs(e.Update);
	}
}
