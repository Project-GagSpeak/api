using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data.Interfaces;
public abstract record InvokableGsAction : IComparable<InvokableGsAction>
{
    public abstract InvokableActionType ActionType { get; }

    public virtual bool Equals(InvokableGsAction? other)
        => other is not null && ActionType == other.ActionType;

    public override int GetHashCode() => (int)ActionType;

    public int CompareTo(InvokableGsAction? other)
        => other is null ? 1 : ActionType.CompareTo(other.ActionType);
}


public record TextAction : InvokableGsAction
{
    public override InvokableActionType ActionType => InvokableActionType.TextOutput;
    public string OutputCommand { get; set; } = string.Empty;
    public TextAction() { }
    public TextAction(TextAction other) : base(other) 
        => OutputCommand = other.OutputCommand;
}

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
    public List<DeviceAction> DeviceActions { get; set; } = new List<DeviceAction>();
    public SexToyAction() { }
    public SexToyAction(SexToyAction other) : base(other)
    {
        StartAfter = other.StartAfter;
        EndAfter = other.EndAfter;
        DeviceActions = other.DeviceActions.Select(x => new DeviceAction(x)).ToList();
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeviceActionPattern : DeviceAction
{
    public override DeviceActionType Action => DeviceActionType.Pattern;
    public Guid PatternId { get; set; }

    public DeviceActionPattern() { }
    public DeviceActionPattern(DeviceActionPattern other) : base(other)
        => PatternId = other.PatternId;
}

[MessagePackObject(keyAsPropertyName: true)]
public class DeviceAction
{
    public virtual DeviceActionType Action { get; set; } = DeviceActionType.Vibration;
    public AffectedDevice[] AffectedDevices { get; set; } = [];

    public DeviceAction() { }
    public DeviceAction(DeviceAction other)
    {
        Action = other.Action;
        AffectedDevices = other.AffectedDevices.Select(x => new AffectedDevice(x.Name, x.AccessedMotors)).ToArray();
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public record AffectedDevice(string Name, IEnumerable<int> AccessedMotors);


