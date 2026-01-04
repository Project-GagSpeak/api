namespace GagspeakAPI.Data;

// Reflects a MyStatus Moodle from Moodles.
// Prone to version errors i guess so dont use if we dont need to or something.
public sealed record MoodleStatus
{
    public int         IconID        { get; init; } = 0;
    public string      Title         { get; init; } = string.Empty;
    public string      Description   { get; init; } = string.Empty;
    public string      CustomFXPath  { get; init; } = string.Empty;

    public StatusType  Type           { get; init; } = StatusType.Positive;
    public Modifiers   Modifiers      { get; init; } = Modifiers.None;

    public int         Stacks         { get; init; } = 1;
    public int         StackSteps     { get; init; } = 0;

    public Guid         ChainedStatus { get; init; } = Guid.Empty;
    public ChainTrigger ChainTrigger { get; init; } = ChainTrigger.Dispel;

    public string       Applier        { get; init; } = string.Empty;
    public string       Dispeller      { get; init; } = string.Empty;

    public int          Days           { get; init; } = 0;
    public int          Hours          { get; init; } = 0;
    public int          Minutes        { get; init; } = 0;
    public int          Seconds        { get; init; } = 0;

    public bool         NoExpire       { get; init; } = false;
    public bool         AsPermanent    { get; init; } = false;
}
