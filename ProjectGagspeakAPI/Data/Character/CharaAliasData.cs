using GagspeakAPI.Data;
using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaAliasData
{
    public bool HasNameStored { get; set; } = false;
    public string ListenerName { get; set; } = string.Empty;
    public List<AliasTrigger> AliasList { get; set; } = new List<AliasTrigger>();

    [IgnoreMember]
    public string ExtractedListenerName => HasNameStored ? ListenerName : "Not Yet Listening!";
}

[MessagePackObject(keyAsPropertyName: true)]
public record AliasTrigger
{
    public Guid Identifier { get; set; } = Guid.NewGuid();
    public bool Enabled { get; set; } = false;
    public string Label { get; set; } = string.Empty;

    /// <summary> The input command that triggers the output command </summary>
    public string InputCommand { get; set; } = string.Empty;

    /// <summary> Stores executions with unique types. </summary>
    public Dictionary<InvokableActionType, InvokableGsAction> Executions { get; set; } = new();

    public AliasTrigger() { }

    public AliasTrigger(AliasTrigger other, bool keepId)
    {
        Identifier = keepId ? other.Identifier : Guid.NewGuid();
        Enabled = other.Enabled;
        Label = other.Label;
        InputCommand = other.InputCommand;
        Executions = other.Executions.ToDictionary(x => x.Key, x => x.Value);
    }

    /// <summary> Useful for combos displaying new kinds of actions that can be added. </summary>
    public IEnumerable<InvokableActionType> UnregisteredTypes()
        => Enum.GetValues<InvokableActionType>().Except(Executions.Keys).Except(new[] { InvokableActionType.SexToy });

    /// <summary> Useful for knowing if any singular type is already present in the dictionary. </summary>
    public bool HasActionType(InvokableActionType actionType) => Executions.ContainsKey(actionType);

    /// <summary> Appends the action to the dictionary. A helper function. </summary>
    public void AddActionForType(InvokableActionType type)
    {
        Executions[type] = type switch
        {
            InvokableActionType.TextOutput => new TextAction(),
            InvokableActionType.Gag => new GagAction(),
            InvokableActionType.Restraint => new RestraintAction(),
            InvokableActionType.Moodle => new MoodleAction(),
            InvokableActionType.ShockCollar => new PiShockAction(),
            InvokableActionType.SexToy => new SexToyAction(),
            _ => throw new Exception("Invalid Execution Type")
        };
    }
}
