using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Helpers;

public static class SafeHelper
{
	public static async Task<User> SafeGetMe(this TelegramBotClient bot, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.GetMeAsync(cancellationToken);
				if (!((User)obj != null))
				{
					break;
				}
				return (User)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(500);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (User)obj;
	}

	public static async Task<Message> SafeEditMessageText(this TelegramBotClient bot, ChatId chatId, int messageId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.EditMessageTextAsync(chatId, messageId, text, parseMode, entities, disableWebPagePreview, replyMarkup, cancellationToken);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(500);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Chat> SafeGetChat(this TelegramBotClient bot, ChatId chatId, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.GetChatAsync(chatId, cancellationToken);
				if (obj != null)
				{
					return (Chat)obj;
				}
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(500);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Chat)obj;
	}

	public static async void SafeDeleteMessage(this TelegramBotClient bot, ChatId chatId, int messageId, CancellationToken cancellationToken = default(CancellationToken))
	{
		while (true)
		{
			try
			{
				await bot.DeleteMessageAsync(chatId, messageId, cancellationToken);
				break;
			}
			catch (HttpRequestException ex)
			{
				if (!ex.Message.Contains("429"))
				{
					break;
				}
				await Task.Delay(500);
			}
			catch
			{
				break;
			}
		}
	}

	public static async void SafePinChatMessage(this TelegramBotClient bot, ChatId chatId, int messageId, bool disableNotification = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		while (true)
		{
			try
			{
				await bot.PinChatMessageAsync(chatId, messageId, disableNotification, cancellationToken);
				break;
			}
			catch (HttpRequestException ex)
			{
				if (!ex.Message.Contains("429"))
				{
					break;
				}
				await Task.Delay(1000);
			}
			catch
			{
				break;
			}
		}
	}

	public static async Task<Message[]> SafeSendMediaGroup(this TelegramBotClient bot, ChatId chatId, IEnumerable<IAlbumInputMedia> media, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendMediaGroupAsync(media, chatId, disableNotification, replyToMessageId, allowSendingWithoutReply, cancellationToken);
				if (obj == null)
				{
					break;
				}
				return (Message[])obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message[])obj;
	}

	public static async Task<Message> SafeSendVideoNote(this TelegramBotClient bot, ChatId chatId, InputTelegramFile videoNote, int duration = 0, int length = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendVideoNoteAsync(chatId, videoNote, duration, length, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken, thumb);
				if (obj != null)
				{
					return (Message)obj;
				}
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendPoll(this TelegramBotClient bot, ChatId chatId, string question, IEnumerable<string> options, string explantation = null, ParseMode explantationParseMode = ParseMode.Default, MessageEntity[] explantationsEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, bool isAnonymous = true, PollType pollType = PollType.Regular, bool allowMultipleAnswers = false, int correctOptionId = 0, int openPeriod = 0, DateTime closeDate = default(DateTime), bool isClosed = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendPollAsync(chatId, question, options, explantation, explantationParseMode, explantationsEntities, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, isAnonymous, pollType, allowMultipleAnswers, correctOptionId, openPeriod, closeDate, isClosed, cancellationToken);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendVideo(this TelegramBotClient bot, ChatId chatId, InputOnlineFile video, int duration = 0, int width = 0, int height = 0, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool supportsStreaming = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendVideoAsync(chatId, video, duration, width, height, caption, parseMode, captionEntities, supportsStreaming, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken, thumb);
				if (obj != null)
				{
					return (Message)obj;
				}
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendAnimation(this TelegramBotClient bot, ChatId chatId, InputOnlineFile voice, int duration = 0, int width = 0, int height = 0, InputMedia thumb = null, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendAnimationAsync(chatId, voice, duration, width, height, thumb, caption, parseMode, captionEntities, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendVoice(this TelegramBotClient bot, ChatId chatId, InputOnlineFile voice, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, int duration = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendVoiceAsync(chatId, voice, caption, parseMode, captionEntities, duration, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendAudio(this TelegramBotClient bot, ChatId chatId, InputOnlineFile audio, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, int duration = 0, string performer = null, string title = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendAudioAsync(chatId, audio, caption, parseMode, captionEntities, duration, performer, title, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken, thumb);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendPhoto(this TelegramBotClient bot, ChatId chatId, InputOnlineFile photo, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendPhotoAsync(chatId, photo, caption, parseMode, captionEntities, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> SafeSendDocument(this TelegramBotClient bot, ChatId chatId, InputOnlineFile document, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableContentTypeDetection = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null)
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SendDocumentAsync(chatId, document, caption, parseMode, captionEntities, disableContentTypeDetection, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken, thumb);
				if (obj == null)
				{
					break;
				}
				return (Message)obj;
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<Message> PreSafeSendTextMessage(this TelegramBotClient bot, ChatId chatId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.SafeSendTextMessage(chatId, text, parseMode, entities, disableWebPagePreview, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken);
				if (obj != null)
				{
					return (Message)obj;
				}
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}

	public static async Task<MessageId> SafeCopyMessage(this TelegramBotClient bot, ChatId chatId, ChatId fromChatId, int messageId, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.CopyMessageAsync(chatId, fromChatId, messageId, caption, parseMode, captionEntities, disableNotification, replyToMessageId, allowSendingWithoutReply, replyMarkup, cancellationToken);
				if (obj != null)
				{
					return (MessageId)obj;
				}
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (MessageId)obj;
	}

	public static async Task<Message> SafeForwardMessage(this TelegramBotClient bot, ChatId chatId, ChatId fromChatId, int messageId, bool disableNotification = false, CancellationToken cancellationToken = default(CancellationToken))
	{
		object obj = null;
		while (true)
		{
			try
			{
				obj = await bot.ForwardMessageAsync(chatId, fromChatId, messageId, disableNotification, cancellationToken);
				if (obj != null)
				{
					return (Message)obj;
				}
			}
			catch (HttpRequestException ex)
			{
				if (ex.Message.Contains("429"))
				{
					await Task.Delay(1000);
					continue;
				}
			}
			catch
			{
			}
			break;
		}
		return (Message)obj;
	}
}
