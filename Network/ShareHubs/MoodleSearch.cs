using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Basic Search Request.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SearchBase(string Input, string[] Tags, HubFilter Filter, HubDirection Order);
