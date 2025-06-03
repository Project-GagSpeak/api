using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Sends the GUID's for the Kinkster to apply from their moodle list.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesApplierById(UserData Target, IEnumerable<Guid> Ids, MoodleType Type) : KinksterBase(Target);
