using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class ShockAction
{
    public ShockMode OpCode { get; set; } = ShockMode.Beep;
    public int Duration { get; set; } = 0;
    public int Intensity { get; set; } = 0;

    // This accounts for PiShock's quirky API.
    public float GetDurationFloat()
    {
        return Duration switch
        {
            > 15 and < 100 => 0f, // Invalid range
            >= 100 and <= 15000 => Duration / 1000f, // Milliseconds to seconds
            _ => Duration // Assume seconds
        };
    }

    // This accounts for PiShock's quirky API.
    public void SetDuration(float newStrength)
    {
        // Produce the full seconds, or milliseconds count.
        Duration = (newStrength >= 1f && newStrength % 1 == 0f)
            ? (int)newStrength // Whole seconds
            : (int)(newStrength * 1000); // Fractional => milliseconds
    }
}
