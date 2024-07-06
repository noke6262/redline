using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.Passport;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Types;

[JsonObject(/*Could not decode attribute arguments.*/)]
public class Message
{
	[CompilerGenerated]
	private IntPtr intptr_0;

	[CompilerGenerated]
	private object object_0;

	[CompilerGenerated]
	private object object_1;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private object object_2;

	[CompilerGenerated]
	private object object_3;

	[CompilerGenerated]
	private object object_4;

	[CompilerGenerated]
	private IntPtr intptr_1;

	[CompilerGenerated]
	private object object_5;

	[CompilerGenerated]
	private object object_6;

	[CompilerGenerated]
	private DateTime? a;

	[CompilerGenerated]
	private object b;

	[CompilerGenerated]
	private object c;

	[CompilerGenerated]
	private DateTime? d;

	[CompilerGenerated]
	private object e;

	[CompilerGenerated]
	private object f;

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

	[CompilerGenerated]
	private object object_19;

	[CompilerGenerated]
	private object object_20;

	[CompilerGenerated]
	private object object_21;

	[CompilerGenerated]
	private object object_22;

	[CompilerGenerated]
	private object object_23;

	[CompilerGenerated]
	private object object_24;

	[CompilerGenerated]
	private object object_25;

	[CompilerGenerated]
	private object object_26;

	[CompilerGenerated]
	private object object_27;

	[CompilerGenerated]
	private object object_28;

	[CompilerGenerated]
	private IntPtr intptr_2;

	[CompilerGenerated]
	private IntPtr intptr_3;

	[CompilerGenerated]
	private IntPtr intptr_4;

	[CompilerGenerated]
	private IntPtr intptr_5;

	[CompilerGenerated]
	private object object_29;

	[CompilerGenerated]
	private long long_0;

	[CompilerGenerated]
	private long long_1;

	[CompilerGenerated]
	private object object_30;

	[CompilerGenerated]
	private object object_31;

	[CompilerGenerated]
	private object object_32;

	[CompilerGenerated]
	private object object_33;

	[CompilerGenerated]
	private object object_34;

	[CompilerGenerated]
	private object object_35;

	[CompilerGenerated]
	private object object_36;

	[CompilerGenerated]
	private object object_37;

	[CompilerGenerated]
	private object object_38;

	[CompilerGenerated]
	private object object_39;

	[CompilerGenerated]
	private object object_40;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int MessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_0;
		}
		[CompilerGenerated]
		set
		{
			intptr_0 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User From
	{
		[CompilerGenerated]
		get
		{
			return (User)object_0;
		}
		[CompilerGenerated]
		set
		{
			object_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Chat SenderChat
	{
		[CompilerGenerated]
		get
		{
			return (Chat)object_1;
		}
		[CompilerGenerated]
		set
		{
			object_1 = value;
		}
	}

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime Date
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Chat Chat
	{
		[CompilerGenerated]
		get
		{
			return (Chat)object_2;
		}
		[CompilerGenerated]
		set
		{
			object_2 = value;
		}
	}

	[Obsolete("Check ForwardFrom and ForwardFromChat properties instead")]
	public bool IsForwarded => ForwardFrom != null;

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User ForwardFrom
	{
		[CompilerGenerated]
		get
		{
			return (User)object_3;
		}
		[CompilerGenerated]
		set
		{
			object_3 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Chat ForwardFromChat
	{
		[CompilerGenerated]
		get
		{
			return (Chat)object_4;
		}
		[CompilerGenerated]
		set
		{
			object_4 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public int ForwardFromMessageId
	{
		[CompilerGenerated]
		get
		{
			return (int)(nint)intptr_1;
		}
		[CompilerGenerated]
		set
		{
			intptr_1 = (IntPtr)value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string ForwardSignature
	{
		[CompilerGenerated]
		get
		{
			return (string)object_5;
		}
		[CompilerGenerated]
		set
		{
			object_5 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string ForwardSenderName
	{
		[CompilerGenerated]
		get
		{
			return (string)object_6;
		}
		[CompilerGenerated]
		set
		{
			object_6 = value;
		}
	}

	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public DateTime? ForwardDate
	{
		[CompilerGenerated]
		get
		{
			return a;
		}
		[CompilerGenerated]
		set
		{
			a = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message ReplyToMessage
	{
		[CompilerGenerated]
		get
		{
			return (Message)b;
		}
		[CompilerGenerated]
		set
		{
			b = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User ViaBot
	{
		[CompilerGenerated]
		get
		{
			return (User)c;
		}
		[CompilerGenerated]
		set
		{
			c = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	[JsonConverter(typeof(UnixDateTimeConverter))]
	public DateTime? EditDate
	{
		[CompilerGenerated]
		get
		{
			return d;
		}
		[CompilerGenerated]
		set
		{
			d = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string MediaGroupId
	{
		[CompilerGenerated]
		get
		{
			return (string)e;
		}
		[CompilerGenerated]
		set
		{
			e = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string AuthorSignature
	{
		[CompilerGenerated]
		get
		{
			return (string)f;
		}
		[CompilerGenerated]
		set
		{
			f = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Text
	{
		[CompilerGenerated]
		get
		{
			return (string)object_7;
		}
		[CompilerGenerated]
		set
		{
			object_7 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MessageEntity[] Entities
	{
		[CompilerGenerated]
		get
		{
			return (MessageEntity[])object_8;
		}
		[CompilerGenerated]
		set
		{
			object_8 = value;
		}
	}

	public IEnumerable<string> EntityValues => Entities?.Select((Func<MessageEntity, string>)((object entity) => Text.Substring(((MessageEntity)entity).Offset, ((MessageEntity)entity).Length)));

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MessageEntity[] CaptionEntities
	{
		[CompilerGenerated]
		get
		{
			return (MessageEntity[])object_9;
		}
		[CompilerGenerated]
		set
		{
			object_9 = value;
		}
	}

	public IEnumerable<string> CaptionEntityValues => CaptionEntities?.Select((Func<MessageEntity, string>)((object entity) => Caption.Substring(((MessageEntity)entity).Offset, ((MessageEntity)entity).Length)));

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Audio Audio
	{
		[CompilerGenerated]
		get
		{
			return (Audio)object_10;
		}
		[CompilerGenerated]
		set
		{
			object_10 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Document Document
	{
		[CompilerGenerated]
		get
		{
			return (Document)object_11;
		}
		[CompilerGenerated]
		set
		{
			object_11 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Animation Animation
	{
		[CompilerGenerated]
		get
		{
			return (Animation)object_12;
		}
		[CompilerGenerated]
		set
		{
			object_12 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Game Game
	{
		[CompilerGenerated]
		get
		{
			return (Game)object_13;
		}
		[CompilerGenerated]
		set
		{
			object_13 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PhotoSize[] Photo
	{
		[CompilerGenerated]
		get
		{
			return (PhotoSize[])object_14;
		}
		[CompilerGenerated]
		set
		{
			object_14 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Sticker Sticker
	{
		[CompilerGenerated]
		get
		{
			return (Sticker)object_15;
		}
		[CompilerGenerated]
		set
		{
			object_15 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Video Video
	{
		[CompilerGenerated]
		get
		{
			return (Video)object_16;
		}
		[CompilerGenerated]
		set
		{
			object_16 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Voice Voice
	{
		[CompilerGenerated]
		get
		{
			return (Voice)object_17;
		}
		[CompilerGenerated]
		set
		{
			object_17 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public VideoNote VideoNote
	{
		[CompilerGenerated]
		get
		{
			return (VideoNote)object_18;
		}
		[CompilerGenerated]
		set
		{
			object_18 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string Caption
	{
		[CompilerGenerated]
		get
		{
			return (string)object_19;
		}
		[CompilerGenerated]
		set
		{
			object_19 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Contact Contact
	{
		[CompilerGenerated]
		get
		{
			return (Contact)object_20;
		}
		[CompilerGenerated]
		set
		{
			object_20 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Location Location
	{
		[CompilerGenerated]
		get
		{
			return (Location)object_21;
		}
		[CompilerGenerated]
		set
		{
			object_21 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Venue Venue
	{
		[CompilerGenerated]
		get
		{
			return (Venue)object_22;
		}
		[CompilerGenerated]
		set
		{
			object_22 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Poll Poll
	{
		[CompilerGenerated]
		get
		{
			return (Poll)object_23;
		}
		[CompilerGenerated]
		set
		{
			object_23 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Dice Dice
	{
		[CompilerGenerated]
		get
		{
			return (Dice)object_24;
		}
		[CompilerGenerated]
		set
		{
			object_24 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User[] NewChatMembers
	{
		[CompilerGenerated]
		get
		{
			return (User[])object_25;
		}
		[CompilerGenerated]
		set
		{
			object_25 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public User LeftChatMember
	{
		[CompilerGenerated]
		get
		{
			return (User)object_26;
		}
		[CompilerGenerated]
		set
		{
			object_26 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string NewChatTitle
	{
		[CompilerGenerated]
		get
		{
			return (string)object_27;
		}
		[CompilerGenerated]
		set
		{
			object_27 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PhotoSize[] NewChatPhoto
	{
		[CompilerGenerated]
		get
		{
			return (PhotoSize[])object_28;
		}
		[CompilerGenerated]
		set
		{
			object_28 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool DeleteChatPhoto
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_2 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_2 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool GroupChatCreated
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_3 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_3 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool SupergroupChatCreated
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_4 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_4 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public bool ChannelChatCreated
	{
		[CompilerGenerated]
		get
		{
			return (byte)(nint)intptr_5 != 0;
		}
		[CompilerGenerated]
		set
		{
			intptr_5 = (IntPtr)(value ? 1 : 0);
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public MessageAutoDeleteTimerChanged MessageAutoDeleteTimerChanged
	{
		[CompilerGenerated]
		get
		{
			return (MessageAutoDeleteTimerChanged)object_29;
		}
		[CompilerGenerated]
		set
		{
			object_29 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public long MigrateToChatId
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public long MigrateFromChatId
	{
		[CompilerGenerated]
		get
		{
			return long_1;
		}
		[CompilerGenerated]
		set
		{
			long_1 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Message PinnedMessage
	{
		[CompilerGenerated]
		get
		{
			return (Message)object_30;
		}
		[CompilerGenerated]
		set
		{
			object_30 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public Invoice Invoice
	{
		[CompilerGenerated]
		get
		{
			return (Invoice)object_31;
		}
		[CompilerGenerated]
		set
		{
			object_31 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public SuccessfulPayment SuccessfulPayment
	{
		[CompilerGenerated]
		get
		{
			return (SuccessfulPayment)object_32;
		}
		[CompilerGenerated]
		set
		{
			object_32 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public string ConnectedWebsite
	{
		[CompilerGenerated]
		get
		{
			return (string)object_33;
		}
		[CompilerGenerated]
		set
		{
			object_33 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public PassportData PassportData
	{
		[CompilerGenerated]
		get
		{
			return (PassportData)object_34;
		}
		[CompilerGenerated]
		set
		{
			object_34 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public ProximityAlertTriggered ProximityAlertTriggered
	{
		[CompilerGenerated]
		get
		{
			return (ProximityAlertTriggered)object_35;
		}
		[CompilerGenerated]
		set
		{
			object_35 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public VoiceChatScheduled VoiceChatScheduled
	{
		[CompilerGenerated]
		get
		{
			return (VoiceChatScheduled)object_36;
		}
		[CompilerGenerated]
		set
		{
			object_36 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public VoiceChatStarted VoiceChatStarted
	{
		[CompilerGenerated]
		get
		{
			return (VoiceChatStarted)object_37;
		}
		[CompilerGenerated]
		set
		{
			object_37 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public VoiceChatEnded VoiceChatEnded
	{
		[CompilerGenerated]
		get
		{
			return (VoiceChatEnded)object_38;
		}
		[CompilerGenerated]
		set
		{
			object_38 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public VoiceChatParticipantsInvited VoiceChatParticipantsInvited
	{
		[CompilerGenerated]
		get
		{
			return (VoiceChatParticipantsInvited)object_39;
		}
		[CompilerGenerated]
		set
		{
			object_39 = value;
		}
	}

	[JsonProperty(/*Could not decode attribute arguments.*/)]
	public InlineKeyboardMarkup ReplyMarkup
	{
		[CompilerGenerated]
		get
		{
			return (InlineKeyboardMarkup)object_40;
		}
		[CompilerGenerated]
		set
		{
			object_40 = value;
		}
	}

	public MessageType Type
	{
		get
		{
			if (Audio != null)
			{
				return MessageType.Audio;
			}
			if (Animation != null)
			{
				return MessageType.Animation;
			}
			if (Document == null)
			{
				if (Game == null)
				{
					if (Photo != null)
					{
						return MessageType.Photo;
					}
					if (Sticker != null)
					{
						return MessageType.Sticker;
					}
					if (Video != null)
					{
						return MessageType.Video;
					}
					if (Voice == null)
					{
						if (Contact != null)
						{
							return MessageType.Contact;
						}
						if (Venue == null)
						{
							if (Location != null)
							{
								return MessageType.Location;
							}
							if (Text == null)
							{
								if (Invoice != null)
								{
									return MessageType.Invoice;
								}
								if (SuccessfulPayment == null)
								{
									if (ProximityAlertTriggered == null)
									{
										if (VoiceChatScheduled == null)
										{
											if (VoiceChatStarted == null)
											{
												if (VoiceChatEnded != null)
												{
													return MessageType.VoiceChatEnded;
												}
												if (VoiceChatParticipantsInvited == null)
												{
													if (VideoNote == null)
													{
														if (ConnectedWebsite != null)
														{
															return MessageType.WebsiteConnected;
														}
														User[] newChatMembers = NewChatMembers;
														if (newChatMembers != null && newChatMembers.Any())
														{
															return MessageType.ChatMembersAdded;
														}
														if (!(LeftChatMember != null))
														{
															if (NewChatTitle == null)
															{
																if (NewChatPhoto == null)
																{
																	if (PinnedMessage == null)
																	{
																		if (!DeleteChatPhoto)
																		{
																			if (!GroupChatCreated)
																			{
																				if (SupergroupChatCreated)
																				{
																					return MessageType.SupergroupCreated;
																				}
																				if (!ChannelChatCreated)
																				{
																					if (MessageAutoDeleteTimerChanged == null)
																					{
																						if (MigrateFromChatId != 0L)
																						{
																							return MessageType.MigratedFromGroup;
																						}
																						if (MigrateToChatId == 0L)
																						{
																							if (Poll == null)
																							{
																								if (Dice != null)
																								{
																									return MessageType.Dice;
																								}
																								return MessageType.Unknown;
																							}
																							return MessageType.Poll;
																						}
																						return MessageType.MigratedToSupergroup;
																					}
																					return MessageType.MessageAutoDeleteTimerChanged;
																				}
																				return MessageType.ChannelCreated;
																			}
																			return MessageType.GroupCreated;
																		}
																		return MessageType.ChatPhotoDeleted;
																	}
																	return MessageType.MessagePinned;
																}
																return MessageType.ChatPhotoChanged;
															}
															return MessageType.ChatTitleChanged;
														}
														return MessageType.ChatMemberLeft;
													}
													return MessageType.VideoNote;
												}
												return MessageType.VoiceChatParticipantsInvited;
											}
											return MessageType.VoiceChatStarted;
										}
										return MessageType.VoiceChatScheduled;
									}
									return MessageType.ProximityAlertTriggered;
								}
								return MessageType.SuccessfulPayment;
							}
							return MessageType.Text;
						}
						return MessageType.Venue;
					}
					return MessageType.Voice;
				}
				return MessageType.Game;
			}
			return MessageType.Document;
		}
	}

	[CompilerGenerated]
	private object method_0(object entity)
	{
		return Text.Substring(((MessageEntity)entity).Offset, ((MessageEntity)entity).Length);
	}

	[CompilerGenerated]
	private object method_1(object entity)
	{
		return Caption.Substring(((MessageEntity)entity).Offset, ((MessageEntity)entity).Length);
	}
}
