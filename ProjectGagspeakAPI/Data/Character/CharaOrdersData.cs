using GagspeakAPI.Enums;
using GagspeakAPI.Data.Interfaces;
using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// Represents character appearance data including multiple gag slots.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CharaOrdersData
{
    /// <summary>
    /// The list of orders that are currently active.
    /// </summary>
    public HashSet<Guid> ActiveOrders { get; set; } = new HashSet<Guid>();
}
