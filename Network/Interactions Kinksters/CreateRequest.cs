using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     The Kinkster we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateKinksterRequest(UserData User, string Message) : KinksterBase(User);

/// <summary> 
///     The Kinkster we wish to send a request to, and what writing & permissions we wish to set.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateCollarRequest(UserData User, string InitialWriting, CollarAccess UserAccess, CollarAccess OwnerAccess) : KinksterBase(User);

/// <summary>
///     Kinkster's accept collar requests with this, establishing the setup for collar ownership and binding. <para />
///     The Collar, if already present or active, will not be provided, and instead null.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AcceptCollarRequest(UserData User, LightCollar? ChosenCollar = null) : KinksterBase(User);