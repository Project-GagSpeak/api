using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated Composite Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="WasSafeword"> If this update was due to a safeword or not. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientCompositeUpdate(List<UserData> Recipients, CharaCompositeActiveData NewData, bool WasSafeword);

/// <summary>
///     When a Collar is created, modified, or removed, push its new data to the <paramref name="Recipients"/> for caching. <para />
///     If <paramref name="LightItem"/> is null, it is assumed the item is to be removed. <para />  
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeCollar(List<UserData> Recipients, LightCollar? NewData);

/// <summary>
///     Pushed to the clients <paramref name="Recipients"/> after changing their 
///     <paramref name="GagType"/>'s data, sending the updated <paramref name="NewData"/>. <para />
///     If null, assume it was removed or deleted.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeGag(List<UserData> Recipients, GagType GagType, LightGag? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeRestriction(List<UserData> Recipients, Guid ItemId, LightRestriction? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeRestraint(List<UserData> Recipients, Guid ItemId, LightRestraint? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeLoot(List<UserData> Recipients, Guid ItemId, LightCursedLoot? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeAlias(List<UserData> Recipients, Guid ItemId, GagspeakAlias? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangePattern(List<UserData> Recipients, Guid ItemId, LightPattern? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeAlarm(List<UserData> Recipients, Guid ItemId, LightAlarm? NewData);

/// <inheritdoc cref="PushClientDataChangeGag"/>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeTrigger(List<UserData> Recipients, Guid ItemId, LightTrigger? NewData);
