using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;
using System.Numerics;

namespace GagspeakAPI.Network;


/// <summary> 
///     Sends a spesific Hypnotic effect to another user for a set duration.
/// </summary>
/// <remarks> <paramref name="User"/> is the target when sent, the enactor when recieved. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record HypnoticAction(UserData User, int Duration, HypnoticEffect Effect);

/// <summary>
///     Forces the recieving kinkster to remain locked away at a spesific address.
/// </summary>
/// <remarks> <paramref name="User"/> is target when made in a server call, and the enactor on callback. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record ForcedStayByAddress(UserData User, AddressBookEntryTuple SpesificAddress) : KinksterBase(User);

/// <summary>
///     Forces the recieving kinkster to remain locked in their current position, 
///     unallowed to stray a set distance (in yalms) from it. [Think of a Cage]
/// </summary>
/// <remarks> <paramref name="User"/> is target when made in a server call, and the enactor on callback. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record ImprisonAtPosition(UserData User, Vector3 Position, float MaxRadiusAllowed) : KinksterBase(User);
