using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Data Transfer Object for an online user. 
/// </summary>
/// <param name="User">The UserData object containing the UID</param>
/// <param name="Ident">The Identity of the online user, hashed for security. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineKinkster(UserData User, string Ident) : KinksterBase(User);
