using GagspeakAPI.Data;
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

    public bool Equals(ChatlogId other)
        => ChatId == other.ChatId;

    public override int GetHashCode()
        => ChatId?.GetHashCode() ?? 0;
}

/// <summary> A Message stored on the server holding nessisary info for recovery between sessions. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct ChatlogMessage(ChatlogId ChatID, string MsgId, DateTime TimeSentUTC, UserData Sender, string Message, byte[] Contents)
{
    public ushort GlobalChatFlags { get; init; } = 0;
}

/// <summary> The contents of a sent chat message. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct SentMessage(ChatlogId ChatID, UserData Sender, string Message, byte[] Contents)
{
    public ushort GlobalChatFlags { get; init; } = 0;
}

[MessagePackObject(keyAsPropertyName: true)]
public record ChatHistoryRequest(ChatlogId Id, int total = 250);


