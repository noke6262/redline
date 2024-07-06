using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Telegram.Bot.Types;

namespace Telegram.Bot.Exceptions;

internal static class ApiExceptionParser
{
	private static readonly object object_0 = new IApiExceptionInfo<ApiRequestException>[17]
	{
		new BadRequestExceptionInfo<ChatNotFoundException>("chat not found"),
		new BadRequestExceptionInfo<UserNotFoundException>("user not found"),
		new BadRequestExceptionInfo<InvalidUserIdException>("USER_ID_INVALID"),
		new BadRequestExceptionInfo<InvalidQueryIdException>("QUERY_ID_INVALID"),
		new BadRequestExceptionInfo<InvalidStickerSetNameException>("sticker set name invalid"),
		new BadRequestExceptionInfo<InvalidStickerEmojisException>("invalid sticker emojis"),
		new BadRequestExceptionInfo<InvalidStickerDimensionsException>("STICKER_PNG_DIMENSIONS"),
		new BadRequestExceptionInfo<StickerSetNameExistsException>("sticker set name is already occupied"),
		new BadRequestExceptionInfo<StickerSetNotModifiedException>("STICKERSET_NOT_MODIFIED"),
		new BadRequestExceptionInfo<InvalidGameShortNameException>("GAME_SHORTNAME_INVALID"),
		new BadRequestExceptionInfo<InvalidGameShortNameException>("game_short_name is empty"),
		new BadRequestExceptionInfo<InvalidGameShortNameException>("wrong game short name specified"),
		new BadRequestExceptionInfo<ContactRequestException>("phone number can be requested in a private chats only"),
		new ForbiddenExceptionInfo<ChatNotInitiatedException>("bot can't initiate conversation with a user"),
		new BadRequestExceptionInfo<InvalidParameterException>("\\w{3,} Request: invalid (?<param>[\\w|\\s]+)$"),
		new BadRequestExceptionInfo<InvalidParameterException>("\\w{3,} Request: (?<param>[\\w|\\s]+) invalid$"),
		new BadRequestExceptionInfo<MessageIsNotModifiedException>("message is not modified")
	};

	public static ApiRequestException Parse<T>(ApiResponse<T> apiResponse)
	{
		IApiExceptionInfo<ApiRequestException> apiExceptionInfo = ((IEnumerable<IApiExceptionInfo<ApiRequestException>>)object_0).FirstOrDefault((IApiExceptionInfo<ApiRequestException> info) => Regex.IsMatch(apiResponse.Description, info.ErrorMessageRegex));
		if (apiExceptionInfo == null)
		{
			return new ApiRequestException(apiResponse.Description, apiResponse.ErrorCode, apiResponse.Parameters);
		}
		string text;
		if (apiExceptionInfo.ErrorCode != 400)
		{
			text = (string)smethod_1(apiResponse.Description);
			return Activator.CreateInstance(apiExceptionInfo.Type, text) as ApiRequestException;
		}
		text = (string)smethod_0(apiResponse.Description);
		if (!(apiExceptionInfo.Type == typeof(InvalidParameterException)))
		{
			return Activator.CreateInstance(apiExceptionInfo.Type, text) as ApiRequestException;
		}
		return new InvalidParameterException(Regex.Match(apiResponse.Description, apiExceptionInfo.ErrorMessageRegex).Groups["param"].Value, text);
	}

	private static object smethod_0(object message)
	{
		return smethod_2(message, "Bad Request: ");
	}

	private static object smethod_1(object message)
	{
		return smethod_2(message, "Forbidden: ");
	}

	private static object smethod_2(object message, object description)
	{
		if (message != null && ((string)message).IndexOf((string)description) == 0)
		{
			message = ((string)message).Substring(((string)description).Length);
		}
		return message;
	}
}
