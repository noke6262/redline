using System;

namespace Telegram.Bot.Types;

public class InputMediaPhoto : InputMediaBase, IAlbumInputMedia, IInputMedia
{
	[Obsolete("Use the other overload of this constructor with required parameter instead.")]
	public InputMediaPhoto()
	{
		base.Type = "photo";
	}

	public InputMediaPhoto(InputMedia media)
	{
		base.Type = "photo";
		base.Media = media;
	}
}
