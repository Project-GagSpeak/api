namespace GagspeakAPI.Data;

/// <summary>
///     Defines the level of stimulation the item inflicts.
/// </summary>
/// <remarks> This will be replaced later with a stimulation monitor. </remarks>
public enum Stimulation : byte
{
    None    = 0x00,
    Light   = 0x01,
    Mild    = 0x02,
    Heavy   = 0x04,

    Any = Light | Mild | Heavy,
}
