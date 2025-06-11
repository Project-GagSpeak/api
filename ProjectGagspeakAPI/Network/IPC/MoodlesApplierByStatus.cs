using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Sends a set of MoodleStatusInfo tuples to the target kinkster for them to apply.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesApplierByStatus(UserData Target, IEnumerable<MoodlesStatusInfo> Statuses, MoodleType Type) : KinksterBase(Target);
