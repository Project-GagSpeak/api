using GagspeakAPI.User;
using MessagePack;

namespace GagspeakAPI.Chat;

/// <summary>
///   The Chatlog Identifier, and the type of chat it's for.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogId(GsChatKind Kind, string ChatId) : IEquatable<ChatlogId>
{
    public static readonly ChatlogId Invalid = new(GsChatKind.Direct, string.Empty);
    public static readonly ChatlogId GlobalChat = new(GsChatKind.Global, "GlobalChat");
    public bool Equals(ChatlogId other)
        => ChatId == other.ChatId;

    public override int GetHashCode()
        => ChatId?.GetHashCode() ?? 0;
}

/// <summary> A Message stored on the server holding nessisary info for recovery between sessions. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogMessage(ChatlogId Chatlog, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, byte[] Contents, bool LegacyId)
{
<<<<<<< HEAD
    public ChatFlags Flags { get; init; } = ChatFlags.AllowProfileViewing | ChatFlags.UseDisplayName | ChatFlags.AllowRequests;
=======
    public ChatFlags Flags { get; init; } = ChatFlags.None;
>>>>>>> 528d79460fab78dbe4bb75ff48838d539815cc5e

    [IgnoreMember] public string KinksterTag => LegacyId ? Sender.UID[^3..] : Sender.UID[^4..];
}

/// <summary> The contents of a sent chat message. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SentMessage(ChatlogId ChatID, UserData Sender, string Message, byte[] Contents, bool LegacyId, ChatFlags Flags);

// Internally, prevent over 100 from being polled. Global chat will always pull 200.
[MessagePackObject(keyAsPropertyName: true)]
public record ChatHistoryRequest(List<UserData> DMs, bool FetchGlobal, int total = 50);

// All associated chats, along with global chat.
[MessagePackObject(keyAsPropertyName: true)]
public record ChatHistoryResult(Dictionary<ChatlogId, List<ChatlogMessage>> ChatHistory);




