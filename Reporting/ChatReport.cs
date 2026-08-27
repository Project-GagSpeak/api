using MessagePack;
using GagspeakAPI.Chat;
using GagspeakAPI.User;

namespace GagspeakAPI.Reporting;

/// <summary>
///   For when we need to report another user for misconduct of chat usage.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ChatReport(UserData User, ChatlogId Chatlog, string MessageId, string Reason) : UserDto(User);
