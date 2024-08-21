using MessagePack;

namespace ProjectGagspeakAPI.Data.VibeServer;

[MessagePackObject(keyAsPropertyName: true)]
public record AlarmInfo
{
    /// <summary> if the alarm is currently active. </summary>
    public bool Enabled { get; set; } = false;

    /// <summary> The name of the alarm. </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary> The time the alarm was set. (In UTC Format) </summary>
    public DateTimeOffset SetTimeUTC { get; set; } = DateTimeOffset.MinValue;

    /// <summary> The Pattern that plays when the alarm goes off. </summary>
    public string PatternToPlay { get; set; } = string.Empty;

    /// <summary> How long the pattern is played for. </summary>
    public TimeSpan PatternDuration { get; set; } = TimeSpan.Zero;

    /// <summary> What days of the week does that pattern go off? </summary>
    public List<DayOfWeek> RepeatFrequency { get; set; } = [];
}
