using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Callback for when a <paramref name="User"/>'s <paramref name="ItemId"/> from 
///     one of their <paramref name="Module"/>s storage updates its <b>Enabled / Visuals</b> state.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterChangeEnabledItem(UserData User, UserData Enactor, GSModule Module, Guid ItemId, bool NewState);

/// <summary>
///     Callback for when a <paramref name="User"/>'s <paramref name="Gag"/> updates its <b>Enabled</b> state.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterChangeEnabledGag(UserData User, GagType Gag, bool NewState);

/// <summary>
///     Callback for when a <paramref name="User"/>'s <paramref name="Toy"/> updates its <b>Enabled</b> state.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterChangeEnabledToy(UserData User, ToyBrandName Toy, bool NewState);

/// <summary>
///     When a <paramref name="User"/>s active items for a <paramref name="Module"/> in bulk. <para /> 
///     The diff between cached previous and <paramref name="ActiveItems"/> lets you identify removed items.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterChangeEnabledItems(UserData User, UserData Enactor, GSModule Module, List<Guid> ActiveItems, bool NewState);

/// <summary>
///     When a <paramref name="User"/>s active Gag states update in bulk. <para /> 
///     The diff between cached previous and <paramref name="ActiveGags"/> lets you identify removed items.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterChangeEnabledGags(UserData User, List<GagType> ActiveGags, bool NewState);

/// <summary>
///     When a <paramref name="User"/>s active Toy states update in bulk. <para /> 
///     The diff between cached previous and <paramref name="ActiveToys"/> lets you identify removed items.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterChangeEnabledToys(UserData User, List<ToyBrandName> ActiveToys, bool NewState);
