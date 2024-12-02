using GagspeakAPI.Data;
using GagspeakAPI.Data.IPC;
using GagspeakAPI.Enums;
using GagspeakAPI.Extensions;
using MessagePack;

namespace GagspeakAPI.Data.Interfaces;


public interface IExecutableAction
{
    /// <summary>
    /// The Identifier of the item with an executable action.
    /// </summary>
    public Guid Identifier { get; set; }

    /// <summary>
    /// If the item with the executable action kind is enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// The Priority of the item with the executable action kind.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The Data for the preferrred executable action kind.
    /// </summary>
    public IActionGS ExecutableAction { get; set; }
}

[Union(0, typeof(TextAction))]
[Union(1, typeof(GagAction))]
[Union(2, typeof(RestraintAction))]
[Union(3, typeof(MoodleAction))]
[Union(4, typeof(PiShockAction))]
[Union(5, typeof(SexToyAction))]
public interface IActionGS
{
    public ActionExecutionType ExecutionType { get; }

    public IActionGS DeepClone();
}

[MessagePackObject(keyAsPropertyName: true)]
public class TextAction : IActionGS
{
    public ActionExecutionType ExecutionType => ActionExecutionType.TextOutput;

    /// <summary>
    /// The text to output.
    /// </summary>
    public string OutputCommand { get; set; } = string.Empty;

    public IActionGS DeepClone()
    {
        return new TextAction
        {
            OutputCommand = OutputCommand
        };
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class GagAction : IActionGS
{
    public ActionExecutionType ExecutionType => ActionExecutionType.Gag;

    /// <summary>
    /// The Type of Gag.
    /// </summary>
    public GagType GagType { get; set; } = GagType.BallGag;

    /// <summary>
    /// The new state of the gag.
    /// </summary>
    public NewState NewState { get; set; } = NewState.Enabled;

    public IActionGS DeepClone()
    {
        return new GagAction
        {
            GagType = GagType,
            NewState = NewState
        };
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class RestraintAction : IActionGS
{
    public ActionExecutionType ExecutionType => ActionExecutionType.Restraint;
    /// <summary>
    /// The new state of the restraint
    /// </summary>
    public NewState NewState { get; set; } = NewState.Enabled;
    /// <summary>
    /// The Identifier of the restraint set.
    /// </summary>
    public Guid OutputIdentifier { get; set; } = Guid.Empty;

    public IActionGS DeepClone()
    {
        return new RestraintAction
        {
            NewState = NewState,
            OutputIdentifier = OutputIdentifier
        };
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class MoodleAction : IActionGS
{
    public ActionExecutionType ExecutionType => ActionExecutionType.Moodle;

    /// <summary>
    /// If a status or preset.
    /// </summary>
    public IpcToggleType MoodleType { get; set; } = IpcToggleType.MoodlesStatus;

    /// <summary>
    /// Can represent a status or preset id.
    /// </summary>
    public Guid Identifier { get; set; } = Guid.Empty;

    public IActionGS DeepClone()
    {
        return new MoodleAction
        {
            MoodleType = MoodleType,
            Identifier = Identifier,
        };
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class PiShockAction : IActionGS
{
    public ActionExecutionType ExecutionType => ActionExecutionType.ShockCollar;
    /// <summary>
    /// The Shock Instruction to execute.
    /// </summary>
    public ShockTriggerAction ShockInstruction { get; set; } = new ShockTriggerAction();

    public IActionGS DeepClone()
    {
        return new PiShockAction
        {
            ShockInstruction = new ShockTriggerAction()
            {
                OpCode = ShockInstruction.OpCode,
                Intensity = ShockInstruction.Intensity,
                Duration = ShockInstruction.Duration
            }
        };
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class SexToyAction : IActionGS
{
    public ActionExecutionType ExecutionType => ActionExecutionType.SexToy;

    public TimeSpan StartAfter { get; set; } = TimeSpan.Zero;
    public TimeSpan EndAfter { get; set; } = TimeSpan.Zero;

    public List<DeviceTriggerAction> TriggerAction { get; set; } = new List<DeviceTriggerAction>();

    public IActionGS DeepClone()
    {
        return new SexToyAction()
        {
            StartAfter = StartAfter,
            EndAfter = EndAfter,
            TriggerAction = TriggerAction
        };
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public record DeviceTriggerAction
{
    public string DeviceName { get; init; }
    public bool Vibrate { get; set; } = false;
    public bool Rotate { get; set; } = false;
    public int VibrateMotorCount { get; init; }
    public int RotateMotorCount { get; init; }
    public List<MotorAction> VibrateActions { get; set; } = new List<MotorAction>();
    public List<MotorAction> RotateActions { get; set; } = new List<MotorAction>();
    // Can add linear and oscillation actions here later if anyone actually needs them. But I doubt it.
    public DeviceTriggerAction(string Name = "Wildcard Device", int vibeCount = 0, int MotorCount = 0)
    {
        DeviceName = Name;
        VibrateMotorCount = vibeCount;
        RotateMotorCount = MotorCount;
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public record MotorAction
{
    public MotorAction(uint motorIndex = 0)
    {
        MotorIndex = motorIndex;
    }

    public uint MotorIndex { get; init; } = 0;

    // the type of action being executed
    public TriggerActionType ExecuteType { get; set; } = TriggerActionType.Vibration;

    // ONLY USED WHEN TYPE IS VIBRATION
    public byte Intensity { get; set; } = 0;

    // ONLY USED WHEN TYPE IS PATTERN
    public Guid PatternIdentifier { get; set; } = Guid.Empty;
    // (if we want to start at a certain point in the pattern.)
    public TimeSpan StartPoint { get; set; } = TimeSpan.Zero;
}


