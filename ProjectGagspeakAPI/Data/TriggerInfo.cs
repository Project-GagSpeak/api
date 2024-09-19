using GagspeakAPI.Enums;
using MessagePack;

namespace ProjectGagspeakAPI.Data;

/// <summary>
/// This outlines the basic overview of a set trigger the client has.
/// <para> 
/// Much of the information provided is obscured for data storage
/// efficiency, and information about what the trigger does should be
/// provided in the description for the best clarity.
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record TriggerInfo
{
    /// <summary> if the trigger is currently active. </summary>
    public bool Enabled { get; set; } = false;

    /// <summary> Unique Identifier for the trigger. </summary>
    public Guid Identifier { get; set; } = Guid.Empty;

    /// <summary> The name of the trigger. </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary> The description of the trigger. </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary> The type of trigger it is. </summary>
    public TriggerKind Type { get; set; } = TriggerKind.Chat;

    /// <summary> Who has access to use the trigger. </summary>
    public List<string> CanViewAndToggleTrigger { get; set; } = [];
}
