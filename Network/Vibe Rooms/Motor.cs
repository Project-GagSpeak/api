using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

// Idk how viable this is in the long run but whatever, better vibe structure coming soon anyways.
[MessagePackObject]
public record struct Motor(int StepCount)
{
    [Key(0)] public int Steps { get; init; } = StepCount;

    [IgnoreMember]
    public double Interval => Steps > 0 ? 1.0 / Steps : 0;
}
