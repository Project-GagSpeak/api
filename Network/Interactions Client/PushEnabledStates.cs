using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Sent to the client's pairs when the enabled state / visuals of item is changed.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushItemEnabledState(List<UserData> Recipients, GSModule Module, Guid ItemId, bool NewState);

/// <inheritdoc cref="PushItemEnabledState"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushGagEnabledState(List<UserData> Recipients, GagType Gag, bool NewState);

/// <inheritdoc cref="PushItemEnabledState"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushToyEnabledState(List<UserData> Recipients, ToyBrandName Toy, bool NewState);

/// <inheritdoc cref="PushItemEnabledState"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushItemEnabledStates(List<UserData> Recipients, GSModule Module, List<Guid> ActiveItems, bool NewState);

/// <inheritdoc cref="PushItemEnabledState"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushGagEnabledStates(List<UserData> Recipients, List<GagType> ActiveGags, bool NewState);

/// <inheritdoc cref="PushItemEnabledState"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushToyEnabledStates(List<UserData> Recipients, List<ToyBrandName> ActiveToys, bool NewState);
