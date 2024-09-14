using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public class PiShockPermissions
{
    public bool AllowShocks { get; set; } = false;
    public bool AllowVibrations { get; set; } = false;
    public bool AllowBeeps { get; set; } = false;
    public int MaxIntensity { get; set; } = -1;
    public int MaxDuration { get; set; } = -1;

    public TimeSpan GetTimespanFromDuration()
    {
        if (MaxDuration > 15 && MaxDuration < 100)
        {
            return TimeSpan.Zero; // invalid range.
        }
        else if (MaxDuration >= 100 && MaxDuration <= 15000)
        {
            return TimeSpan.FromMilliseconds(MaxDuration); // convert to milliseconds
        }
        else
        {
            return TimeSpan.FromSeconds(MaxDuration); // convert to seconds
        }
    }
}
