using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
[Union(0, typeof(TextAction))]
[Union(1, typeof(GagAction))]
[Union(2, typeof(RestrictionAction))]
[Union(3, typeof(RestraintAction))]
[Union(4, typeof(MoodleAction))]
[Union(5, typeof(PiShockAction))]
[Union(6, typeof(SexToyAction))]
public abstract record InvokableGsAction : IComparable<InvokableGsAction>
{
    public abstract InvokableActionType ActionType { get; }

    public virtual bool Equals(InvokableGsAction? other)
        => other is not null && ActionType == other.ActionType;

    public override int GetHashCode() => (int)ActionType;

    public int CompareTo(InvokableGsAction? other)
        => other is null ? 1 : ActionType.CompareTo(other.ActionType);
}

[MessagePackObject(keyAsPropertyName: true)]
public record TextAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.TextOutput;
    public string OutputCommand { get; set; } = string.Empty;
    public TextAction() { }
    public TextAction(TextAction other) : base(other) 
        => OutputCommand = other.OutputCommand;
}

[MessagePackObject(keyAsPropertyName: true)]
public record GagAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.Gag;
    public int LayerIdx { get; set; } = -1; // -1 means pick any available.
    public NewState NewState { get; set; } = NewState.Enabled;
    public GagType GagType { get; set; } = GagType.BallGag;
    public Padlocks Padlock { get; set; } = Padlocks.None;
    public TimeSpan LowerBound { get; set; } = TimeSpan.Zero;
    public TimeSpan UpperBound { get; set; } = TimeSpan.Zero;
    public GagAction() { }
    public GagAction(GagAction other) : base(other) 
        => (NewState, GagType, Padlock) = (other.NewState, other.GagType, other.Padlock);
}

[MessagePackObject(keyAsPropertyName: true)]
public record RestrictionAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.Restriction;
    public int LayerIdx { get; set; } = -1; // -1 means pick any available.
    public NewState NewState { get; set; } = NewState.Enabled;
    public Guid RestrictionId { get; set; } = Guid.Empty;
    public Padlocks Padlock { get; set; } = Padlocks.None;
    public TimeSpan LowerBound { get; set; } = TimeSpan.Zero;
    public TimeSpan UpperBound { get; set; } = TimeSpan.Zero;
    public RestrictionAction() { }
    public RestrictionAction(RestrictionAction other) : base(other) 
        => (NewState, Padlock, RestrictionId) = (other.NewState, other.Padlock, other.RestrictionId);
}

[MessagePackObject(keyAsPropertyName: true)]
public record RestraintAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.Restraint;
    public NewState NewState { get; set; } = NewState.Enabled;
    public Guid RestrictionId { get; set; } = Guid.Empty;
    public Padlocks Padlock { get; set; } = Padlocks.None;
    public TimeSpan LowerBound { get; set; } = TimeSpan.Zero;
    public TimeSpan UpperBound { get; set; } = TimeSpan.Zero;
    public RestraintAction() { }
    public RestraintAction(RestraintAction other) : base(other) 
        => (NewState, Padlock, RestrictionId) = (other.NewState, other.Padlock, other.RestrictionId);
}

[MessagePackObject(keyAsPropertyName: true)]
public record MoodleAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.Moodle;
    public Moodle MoodleItem { get; set; } = new Moodle();
    public MoodleAction()
    { }
    public MoodleAction(MoodleAction other) : base(other) 
        => MoodleItem = other.MoodleItem;

    public bool IsValid => MoodleItem.Id != Guid.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PiShockAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.ShockCollar;
    public ShockAction ShockInstruction { get; set; } = new ShockAction();
    public PiShockAction() { }
    public PiShockAction(PiShockAction other) : base(other)
        => ShockInstruction = new ShockAction()
        {
            OpCode = other.ShockInstruction.OpCode,
            Intensity = other.ShockInstruction.Intensity,
            Duration = other.ShockInstruction.Duration
        };
}

[MessagePackObject(keyAsPropertyName: true)]
public record SexToyAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.SexToy;
    public TimeSpan StartAfter { get; set; } = TimeSpan.Zero;
    public TimeSpan EndAfter { get; set; } = TimeSpan.Zero;
    // This below is all temporary since the main toy functionality is not setup yet.
    public ToyActionType ActionKind { get; set; } = ToyActionType.Vibration;
    public Guid PatternId { get; set; } = Guid.Empty;
    public int Intensity { get; set; } = 0;
    public SexToyAction() { }
    public SexToyAction(SexToyAction other) : base(other)
    {
        StartAfter = other.StartAfter;
        EndAfter = other.EndAfter;
        PatternId = other.PatternId;
        Intensity = other.Intensity;
    }
}


