using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterToyboxData
{
    // Gets the GUID we interacted with in our transaction. This is used for easily locating the change in our data.
    public Guid TransactionId { get; set; } = Guid.Empty;

    // Properties specific to pattern info
    public List<PatternDto> PatternList { get; set; } = new();

    // Properties specific to alarm info
    public List<AlarmDto> AlarmList { get; set; } = new();

    // properties specific to trigger info
    public List<TriggerDto> TriggerList { get; set; } = new();
}

[MessagePackObject(keyAsPropertyName: true)]
public record PatternDto
{
    /// <summary> The Identifier of the Pattern set. </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary> If the alarm is currently on or off. </summary>
    public bool Enabled { get; set; } = false;

    /// <summary> The name given to the restraint set. </summary>
    public string Name = string.Empty;

    /// <summary> The duration of the pattern </summary>
    public TimeSpan Duration = TimeSpan.Zero;

    /// <summary> If the pattern should loop </summary>
    public bool ShouldLoop = false;
}

[MessagePackObject(keyAsPropertyName: true)]
public record AlarmDto
{
    /// <summary> The Identifier of the alarm set. </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary> If the alarm is currently on or off. </summary>
    public bool Enabled { get; set; } = false;

    /// <summary> The name given to the alarm. </summary>
    public string Name = string.Empty;

    /// <summary>  The time the alarm will go off. (In UTC Format) </summary>
    public DateTimeOffset SetTimeUTC { get; set; } = DateTimeOffset.MinValue;

    /// <summary> References the name that this pattern plays. </summary>
    public string PatternThatPlays { get; set; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record TriggerDto
{
    /// <summary> The Identifier of the trigger. </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary> if the trigger is currently active. </summary>
    public bool Enabled { get; set; } = false;

    /// <summary> The name of the trigger. </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary> The type of trigger it is. </summary>
    public TriggerKind Type { get; set; } = TriggerKind.Chat;

    /// <summary> The Action done when trigger is fired. </summary>
    public TriggerActionKind ActionOnTrigger { get; set; } = TriggerActionKind.SexToy;
}
