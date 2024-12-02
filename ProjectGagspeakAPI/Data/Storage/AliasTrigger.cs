using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Stores a list of alias triggers. This is intended to be applied once for each player in your whitelist.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AliasTrigger
{
    /// <summary>
    /// The unique identifier for the alias trigger
    /// </summary>
    public Guid AliasIdentifier { get; set; } = Guid.NewGuid();

    public bool Enabled { get; set; } = false;
    public string Name { get; set; } = string.Empty;

    /// <summary> 
    /// The input command that triggers the output command 
    /// </summary>
    public string InputCommand { get; set; } = string.Empty;

    /// <summary>
    /// Stores executions with unique types.
    /// </summary>
    public Dictionary<ActionExecutionType, IActionGS> Executions { get; set; } = new();


    public string GetTextOutput()
    {
        if (Executions.TryGetValue(ActionExecutionType.TextOutput, out IActionGS? action))
            return (action as TextAction)?.OutputCommand ?? string.Empty;
        // we failed, return empty.
        return string.Empty;
    }

    /// <summary>
    /// Useful for knowing what actions are already added.
    /// </summary>
    public IEnumerable<ActionExecutionType> CurrentTypes() => Executions.Keys;

    /// <summary>
    /// Useful for combos displaying new kinds of actions that can be added.
    /// </summary>
    public IEnumerable<ActionExecutionType> UnregisteredTypes() 
        => Enum.GetValues<ActionExecutionType>().Except(Executions.Keys).Except(new[] { ActionExecutionType.SexToy });

    /// <summary>
    /// Useful for knowing if any singular type is already present in the dictionary.
    /// </summary>
    public bool HasActionType(ActionExecutionType actionType) => Executions.ContainsKey(actionType);

    /// <summary>
    /// Appends the action to the dictionary. A helper function.
    /// </summary>
    public void AddActionForType(ActionExecutionType type)
    {
        Executions[type] = type switch
        {
            ActionExecutionType.TextOutput => new TextAction(),
            ActionExecutionType.Gag => new GagAction(),
            ActionExecutionType.Restraint => new RestraintAction(),
            ActionExecutionType.Moodle => new MoodleAction(),
            ActionExecutionType.ShockCollar => new PiShockAction(),
            ActionExecutionType.SexToy => new SexToyAction(),
            _ => throw new Exception("Invalid Execution Type")
        };
    }


}
