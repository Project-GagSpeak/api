using MessagePack;

namespace GagspeakAPI.Data.Character;

[MessagePackObject(keyAsPropertyName: true)]
public record CharaOrdersData
{
    /// <summary>
    /// The list of orders that are currently active.
    /// </summary>
    public HashSet<Guid> ActiveOrders { get; set; } = new HashSet<Guid>();
}
