using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Sends the GUID's for the Kinkster to apply from their moodle list.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodleId(UserData User, IEnumerable<Guid> Ids, bool IsPresets, bool LockIds) : KinksterBase(User);

/// <summary>
///     Sends a set of MoodleStatusInfo tuples to the target kinkster for them to apply.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyMoodleStatus(UserData User, IEnumerable<MoodlesStatusInfo> Statuses, bool LockIds) : KinksterBase(User);

/// <summary>
///     The Moodle GUID's that should be removed from the target kinkster.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RemoveMoodleId(UserData User, IEnumerable<Guid> Ids) : KinksterBase(User);
