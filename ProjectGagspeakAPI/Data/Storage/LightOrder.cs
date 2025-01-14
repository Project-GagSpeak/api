using GagspeakAPI.Data.Struct;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record LightOrder
{
    /// <summary> 
    /// The Identifier of the order. 
    /// </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary> 
    /// The name given to the order. 
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    /// The description of the order.
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    /// The time the order must be complete by before failure.
    /// </summary>
    public DateTimeOffset SetTimeUTC { get; set; } = DateTimeOffset.MinValue;
}
