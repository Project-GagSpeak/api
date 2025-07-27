using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;
using System.Numerics;

namespace GagspeakAPI.Network;


/// <summary> 
///     Sends a spesific Hypnotic effect to another user for a set duration. <para />
///     The <paramref name="base64Image"/> can contain a custom image string, but should not be allowed unless granted.
/// </summary>
/// <remarks> <paramref name="User"/> is the target when sent, the enactor when recieved. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record HypnoticAction(UserData User, int Duration, HypnoticEffect Effect, string? base64Image = null) : KinksterBase(User);

/// <summary>
///     Forces the recieving kinkster to remain locked away at a spesific address. (nullable)
/// </summary>
/// <remarks> <paramref name="User"/> is target when made in a server call, and the enactor on callback. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record ConfineByAddress(UserData User, AddressBookEntryTuple SpesificAddress) : KinksterBase(User);

/// <summary>
///     Forces the recieving kinkster to remain locked in their current position, 
///     unallowed to stray a set distance (in yalms) from it. [Think of a Cage]
/// </summary>
/// <remarks> <paramref name="User"/> is target when made in a server call, and the enactor on callback. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record ImprisonAtPosition(UserData User, SerializableVector3 Position, float MaxRadiusAllowed) : KinksterBase(User);
