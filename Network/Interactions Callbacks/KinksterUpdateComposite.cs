using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Composite Data of the <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster that the Composite Data is for. </param>
/// <param name="WasSafeword"> If this update was due to a safeword or not. </param>
/// <remarks> 
///     This should only be sent on connection and after safeword.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateComposite(UserData User, CharaCompositeData Data, bool WasSafeword) : KinksterBase(User);
