using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public class PiShockPermissions
{
    public bool AllowShocks { get; init; }
    public bool AllowVibrations { get; init; }
    public bool AllowBeeps { get; init; }
    public int MaxIntensity { get; init; }
    public TimeSpan MaxShockDuration { get; init; }

    public PiShockPermissions(bool shocks, bool vibrations, bool beeps, int intensityLimit, int durationLimit)
    {
        AllowShocks = shocks;
        AllowVibrations = vibrations;
        AllowBeeps = beeps;
        MaxIntensity = intensityLimit;
        MaxShockDuration = GetTimespanFromDuration(durationLimit);
    }

    private TimeSpan GetTimespanFromDuration(int duration)
    {
        if (duration > 15 && duration < 100)
        {
            return TimeSpan.Zero; // invalid range.
        }
        else if (duration >= 100 && duration <= 15000)
        {
            return TimeSpan.FromMilliseconds(duration); // convert to milliseconds
        }
        else
        {
            return TimeSpan.FromSeconds(duration); // convert to seconds
        }
    }
}
