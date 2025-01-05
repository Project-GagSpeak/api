using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record LightTrigger
{
    /// <summary> 
    /// The Identifier of the trigger.
    /// </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary>
    /// The priority this trigger has over others doing the same thing.
    /// </summary>
    public int Priority { get; set; } = 0;

    /// <summary> 
    /// The name of the trigger. 
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The description of the trigger.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary> 
    /// The type of trigger it is. 
    /// </summary>
    public TriggerKind Type { get; set; } = TriggerKind.SpellAction;

    /// <summary> 
    /// The Action done when trigger is fired. 
    /// </summary>
    public ActionExecutionType ActionOnTrigger { get; set; } = ActionExecutionType.SexToy;
}
