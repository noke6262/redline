using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Requests.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot;

public interface ITelegramBotClient
{
	long BotId { get; }

	string BotUsername { get; set; }

	TimeSpan Timeout { get; set; }

	bool IsReceiving { get; }

	int MessageOffset { get; set; }

	event EventHandler<ApiRequestEventArgs> MakingApiRequest;

	event EventHandler<ApiResponseEventArgs> ApiResponseReceived;

	event EventHandler<UpdateEventArgs> OnUpdate;

	event EventHandler<MessageEventArgs> OnMessage;

	event EventHandler<MessageEventArgs> OnMessageEdited;

	event EventHandler<InlineQueryEventArgs> OnInlineQuery;

	event EventHandler<ChosenInlineResultEventArgs> OnInlineResultChosen;

	event EventHandler<CallbackQueryEventArgs> OnCallbackQuery;

	event EventHandler<ReceiveErrorEventArgs> OnReceiveError;

	event EventHandler<ReceiveGeneralErrorEventArgs> OnReceiveGeneralError;

	Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken));

	Task<bool> TestApiAsync(CancellationToken cancellationToken = default(CancellationToken));

	void StartReceiving(UpdateType[] allowedUpdates = null, CancellationToken cancellationToken = default(CancellationToken));

	void StopReceiving();

	Task<Update[]> GetUpdatesAsync(int offset = 0, int limit = 0, int timeout = 0, IEnumerable<UpdateType> allowedUpdates = null, CancellationToken cancellationToken = default(CancellationToken));

	Task SetWebhookAsync(string url, InputFileStream certificate = null, string ipAddress = null, int maxConnections = 0, IEnumerable<UpdateType> allowedUpdates = null, bool dropPendingUpdates = false, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteWebhookAsync(bool dropPendingUpdates = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<WebhookInfo> GetWebhookInfoAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<User> GetMeAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task LogOutAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SafeSendTextMessage(ChatId chatId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> ForwardMessageAsync(ChatId chatId, ChatId fromChatId, int messageId, bool disableNotification = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<MessageId> CopyMessageAsync(ChatId chatId, ChatId fromChatId, int messageId, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendPhotoAsync(ChatId chatId, InputOnlineFile photo, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendAudioAsync(ChatId chatId, InputOnlineFile audio, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, int duration = 0, string performer = null, string title = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null);

	Task<Message> SendDocumentAsync(ChatId chatId, InputOnlineFile document, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableContentTypeDetection = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null);

	Task<Message> SendStickerAsync(ChatId chatId, InputOnlineFile sticker, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendVideoAsync(ChatId chatId, InputOnlineFile video, int duration = 0, int width = 0, int height = 0, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool supportsStreaming = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null);

	Task<Message> SendAnimationAsync(ChatId chatId, InputOnlineFile animation, int duration = 0, int width = 0, int height = 0, InputMedia thumb = null, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendVoiceAsync(ChatId chatId, InputOnlineFile voice, string caption = null, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, int duration = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendVideoNoteAsync(ChatId chatId, InputTelegramFile videoNote, int duration = 0, int length = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), InputMedia thumb = null);

	[Obsolete("Use the other overload of this method instead. Only photo and video input types are allowed.")]
	Task<Message[]> SendMediaGroupAsync(ChatId chatId, IEnumerable<InputMediaBase> media, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message[]> SendMediaGroupAsync(IEnumerable<IAlbumInputMedia> inputMedia, ChatId chatId, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendLocationAsync(ChatId chatId, float latitude, float longitude, float horizontalAccuracy = 0f, int livePeriod = 0, int heading = 0, int proximityAlertRadius = 0, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendVenueAsync(ChatId chatId, float latitude, float longitude, string title, string address, string foursquareId = null, string foursquareType = null, string googlePlaceId = null, string googlePlaceType = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendContactAsync(ChatId chatId, string phoneNumber, string firstName, string lastName = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), string vCard = null);

	Task<Message> SendPollAsync(ChatId chatId, string question, IEnumerable<string> options, string explanation = null, ParseMode explanationParseMode = ParseMode.Default, MessageEntity[] explanationEntities = null, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, bool isAnonymous = true, PollType type = PollType.Regular, bool allowsMultipleAnswers = false, int correctOptionId = 0, int openPeriod = 0, DateTime closeDate = default(DateTime), bool isClosed = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendDiceAsync(ChatId chatId, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, IReplyMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), Emoji? emoji = null);

	Task SendChatActionAsync(ChatId chatId, ChatAction chatAction, CancellationToken cancellationToken = default(CancellationToken));

	Task<UserProfilePhotos> GetUserProfilePhotosAsync(long userId, int offset = 0, int limit = 0, CancellationToken cancellationToken = default(CancellationToken));

	Task<Telegram.Bot.Types.File> GetFileAsync(string fileId, CancellationToken cancellationToken = default(CancellationToken));

	[Obsolete("This method will be removed in next major release. Use its overload instead.")]
	Task<Stream> DownloadFileAsync(string filePath, CancellationToken cancellationToken = default(CancellationToken));

	Task DownloadFileAsync(string filePath, Stream destination, CancellationToken cancellationToken = default(CancellationToken));

	Task<Telegram.Bot.Types.File> GetInfoAndDownloadFileAsync(string fileId, Stream destination, CancellationToken cancellationToken = default(CancellationToken));

	Task KickChatMemberAsync(ChatId chatId, long userId, DateTime untilDate = default(DateTime), bool revokeMessages = false, CancellationToken cancellationToken = default(CancellationToken));

	Task LeaveChatAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task UnbanChatMemberAsync(ChatId chatId, long userId, bool onlyIfBanned = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<Chat> GetChatAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ChatMember[]> GetChatAdministratorsAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task<int> GetChatMembersCountAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ChatMember> GetChatMemberAsync(ChatId chatId, long userId, CancellationToken cancellationToken = default(CancellationToken));

	Task AnswerCallbackQueryAsync(string callbackQueryId, string text = null, bool showAlert = false, string url = null, int cacheTime = 0, CancellationToken cancellationToken = default(CancellationToken));

	Task RestrictChatMemberAsync(ChatId chatId, long userId, ChatPermissions permissions, DateTime untilDate = default(DateTime), CancellationToken cancellationToken = default(CancellationToken));

	Task PromoteChatMemberAsync(ChatId chatId, long userId, bool? isAnonymous = null, bool? canManageChat = null, bool? canChangeInfo = null, bool? canPostMessages = null, bool? canEditMessages = null, bool? canDeleteMessages = null, bool? canManageVoiceChats = null, bool? canInviteUsers = null, bool? canRestrictMembers = null, bool? canPinMessages = null, bool? canPromoteMembers = null, CancellationToken cancellationToken = default(CancellationToken));

	Task SetChatAdministratorCustomTitleAsync(ChatId chatId, long userId, string customTitle, CancellationToken cancellationToken = default(CancellationToken));

	Task SetChatPermissionsAsync(ChatId chatId, ChatPermissions permissions, CancellationToken cancellationToken = default(CancellationToken));

	Task<BotCommand[]> GetMyCommandsAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task SetMyCommandsAsync(IEnumerable<BotCommand> commands, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> EditMessageTextAsync(ChatId chatId, int messageId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task EditMessageTextAsync(string inlineMessageId, string text, ParseMode parseMode = ParseMode.Default, MessageEntity[] entities = null, bool disableWebPagePreview = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> StopMessageLiveLocationAsync(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task StopMessageLiveLocationAsync(string inlineMessageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> EditMessageCaptionAsync(ChatId chatId, int messageId, string caption, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task EditMessageCaptionAsync(string inlineMessageId, string caption, ParseMode parseMode = ParseMode.Default, MessageEntity[] captionEntities = null, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> EditMessageMediaAsync(ChatId chatId, int messageId, InputMediaBase media, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task EditMessageMediaAsync(string inlineMessageId, InputMediaBase media, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> EditMessageReplyMarkupAsync(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task EditMessageReplyMarkupAsync(string inlineMessageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> EditMessageLiveLocationAsync(ChatId chatId, int messageId, float latitude, float longitude, float horizontalAccuracy = 0f, int heading = 0, int proximityAlertRadius = 0, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task EditMessageLiveLocationAsync(string inlineMessageId, float latitude, float longitude, float horizontalAccuracy = 0f, int heading = 0, int proximityAlertRadius = 0, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Poll> StopPollAsync(ChatId chatId, int messageId, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteMessageAsync(ChatId chatId, int messageId, CancellationToken cancellationToken = default(CancellationToken));

	Task AnswerInlineQueryAsync(string inlineQueryId, IEnumerable<InlineQueryResultBase> results, int? cacheTime = null, bool isPersonal = false, string nextOffset = null, string switchPmText = null, string switchPmParameter = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendInvoiceAsync(int chatId, string title, string description, string payload, string providerToken, string currency, IEnumerable<LabeledPrice> prices, int maxTipAmount = 0, int[] suggestedTipAmounts = null, string startParameter = null, string providerData = null, string photoUrl = null, int photoSize = 0, int photoWidth = 0, int photoHeight = 0, bool needName = false, bool needPhoneNumber = false, bool needEmail = false, bool needShippingAddress = false, bool isFlexible = false, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken), bool sendPhoneNumberToProvider = false, bool sendEmailToProvider = false);

	Task AnswerShippingQueryAsync(string shippingQueryId, IEnumerable<ShippingOption> shippingOptions, CancellationToken cancellationToken = default(CancellationToken));

	Task AnswerShippingQueryAsync(string shippingQueryId, string errorMessage, CancellationToken cancellationToken = default(CancellationToken));

	Task AnswerPreCheckoutQueryAsync(string preCheckoutQueryId, CancellationToken cancellationToken = default(CancellationToken));

	Task AnswerPreCheckoutQueryAsync(string preCheckoutQueryId, string errorMessage, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SendGameAsync(long chatId, string gameShortName, bool disableNotification = false, int replyToMessageId = 0, bool allowSendingWithoutReply = false, InlineKeyboardMarkup replyMarkup = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<Message> SetGameScoreAsync(long userId, int score, long chatId, int messageId, bool force = false, bool disableEditMessage = false, CancellationToken cancellationToken = default(CancellationToken));

	Task SetGameScoreAsync(long userId, int score, string inlineMessageId, bool force = false, bool disableEditMessage = false, CancellationToken cancellationToken = default(CancellationToken));

	Task<GameHighScore[]> GetGameHighScoresAsync(long userId, long chatId, int messageId, CancellationToken cancellationToken = default(CancellationToken));

	Task<GameHighScore[]> GetGameHighScoresAsync(long userId, string inlineMessageId, CancellationToken cancellationToken = default(CancellationToken));

	Task<StickerSet> GetStickerSetAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

	Task<Telegram.Bot.Types.File> UploadStickerFileAsync(long userId, InputFileStream pngSticker, CancellationToken cancellationToken = default(CancellationToken));

	Task CreateNewStickerSetAsync(long userId, string name, string title, InputOnlineFile pngSticker, string emojis, bool isMasks = false, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken));

	Task AddStickerToSetAsync(long userId, string name, InputOnlineFile pngSticker, string emojis, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken));

	Task CreateNewAnimatedStickerSetAsync(long userId, string name, string title, InputFileStream tgsSticker, string emojis, bool isMasks = false, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken));

	Task AddAnimatedStickerToSetAsync(long userId, string name, InputFileStream tgsSticker, string emojis, MaskPosition maskPosition = null, CancellationToken cancellationToken = default(CancellationToken));

	Task SetStickerPositionInSetAsync(string sticker, int position, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteStickerFromSetAsync(string sticker, CancellationToken cancellationToken = default(CancellationToken));

	Task SetStickerSetThumbAsync(string name, long userId, InputOnlineFile thumb = null, CancellationToken cancellationToken = default(CancellationToken));

	Task<string> ExportChatInviteLinkAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task<ChatInviteLink> CreateChatInviteLinkAsync(ChatId chatId, DateTime expireDate = default(DateTime), int memberLimit = 0, CancellationToken cancellationToken = default(CancellationToken));

	Task<ChatInviteLink> EditChatInviteLinkAsync(ChatId chatId, string inviteLink, DateTime expireDate = default(DateTime), int memberLimit = 0, CancellationToken cancellationToken = default(CancellationToken));

	Task<ChatInviteLink> RevokeChatInviteLinkAsync(ChatId chatId, string inviteLink, CancellationToken cancellationToken = default(CancellationToken));

	Task SetChatPhotoAsync(ChatId chatId, InputFileStream photo, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteChatPhotoAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task SetChatTitleAsync(ChatId chatId, string title, CancellationToken cancellationToken = default(CancellationToken));

	Task SetChatDescriptionAsync(ChatId chatId, string description = null, CancellationToken cancellationToken = default(CancellationToken));

	Task PinChatMessageAsync(ChatId chatId, int messageId, bool disableNotification = false, CancellationToken cancellationToken = default(CancellationToken));

	Task UnpinChatMessageAsync(ChatId chatId, int messageId = 0, CancellationToken cancellationToken = default(CancellationToken));

	Task UnpinAllChatMessagesAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));

	Task SetChatStickerSetAsync(ChatId chatId, string stickerSetName, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteChatStickerSetAsync(ChatId chatId, CancellationToken cancellationToken = default(CancellationToken));
}
