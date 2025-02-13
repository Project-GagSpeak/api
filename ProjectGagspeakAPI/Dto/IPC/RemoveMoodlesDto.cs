using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.IPC;

/// <summary>
/// Notifies the RecipientUser to removes the listed Moodles from their status manager.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RemoveMoodlesDto(UserData User, List<Guid> Statuses) : UserDto(User);
