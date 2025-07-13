using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Composition Record for Search request for patterns.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PatternSearch(string Input, string[] Tags, HubFilter Filter, HubDirection Order)
    : SearchBase(Input, Tags, Filter, Order)
{
    // Optional Search Filters.
    public DurationLength Duration { get; set; } = DurationLength.Any;
    public ToyBrandName Toy { get; set; } = ToyBrandName.Unknown;
    public ToyMotor Motor { get; set; } = ToyMotor.Unknown;
}
