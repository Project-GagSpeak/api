using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.User;

/// <summary> 
///   Sends a specific Hypnotic effect to another user for a set duration. <para />
///   The <paramref name="base64Image"/> can contain a custom image string, but should not be allowed unless granted.
/// </summary>
/// <remarks> <paramref name="User"/> is the target when sent, the enactor when received. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record HypnoticAction(UserData User, DateTimeOffset ExpireTime, HypnoticEffect Effect, string? base64Image = null) : UserDto(User);

/// <summary> 
///   Sends out a shock collar instruction to the target <paramref name="User"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ShockCollarAction(UserData User, int OpCode, int Intensity, int Duration) : UserDto(User);

/// <summary>
///   Sends a small dto of your nameworld to another kinkster. Use with those you trust. <para />
///   After this is sent once, it is not sent again in any other server calls, nor is it stored anywhere
///   except the recipients config files.
/// </summary>
/// <param name="User"> The recipient that will recieve this message. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record SendNameAction(UserData User, string Name) : UserDto(User);
