using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Sends the GUID's for the Kinkster to apply from their loci data.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyLociDataById(UserData User, IEnumerable<Guid> Ids, bool IsPresets, bool LockIds) : KinksterBase(User);

/// <summary>
///     Sends a set of LociStatusStruct tuples to the target kinkster for them to apply.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ApplyLociStatus(UserData User, IEnumerable<LociStatusStruct> Statuses, bool LockIds) : KinksterBase(User);

/// <summary>
///     The Loci status GUID's that should be removed from the target kinkster.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RemoveLociData(UserData User, IEnumerable<Guid> Ids) : KinksterBase(User);
