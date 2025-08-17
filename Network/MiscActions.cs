using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     Sends a specific Hypnotic effect to another user for a set duration. <para />
///     The <paramref name="base64Image"/> can contain a custom image string, but should not be allowed unless granted.
/// </summary>
/// <remarks> <paramref name="User"/> is the target when sent, the enactor when received. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record HypnoticAction(UserData User, int Duration, HypnoticEffect Effect, string? base64Image = null) : KinksterBase(User);

/// <summary> 
///     Sends out a shock collar instruction to the target <paramref name="User"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ShockCollarAction(UserData User, int OpCode, int Intensity, int Duration) : KinksterBase(User);