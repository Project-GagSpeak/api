namespace GagspeakAPI.Network;

/// <summary>
///     Flags that define the Vibe Room's properties.
/// </summary>
[Flags]
public enum VibeRoomFlags
{
    None = 0x00,
    Public = 0x01,
    PasswordProtected = 0x02
}
