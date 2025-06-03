using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     Sends out a shock collar instruction to the target <paramref name="User"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ShockCollarAction(UserData User, int OpCode, int Intensity, int Duration);
