using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Moodle GUID's that should be removed from the target kinkster.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesRemoval(UserData Target, List<Guid> StatusIds) : KinksterBase(Target);
