namespace GagspeakAPI.Enums;

public enum DisconnectIntent : sbyte
{
    Normal      = 0,
    Unexpected  = 1,
    Reload      = 2,
    Logout      = 3,
    Shutdown    = 4,
}
