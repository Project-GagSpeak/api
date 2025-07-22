using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> Updated ActivePattern GUID </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActivePattern(List<UserData> Recipients, Guid ActivePattern, DataUpdateType Type);

/// <summary> Updated Active Alarm List GUID </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveAlarms(List<UserData> Recipients, List<Guid> ActiveAlarms, Guid ChangedItem, DataUpdateType Type);

/// <summary> Updated ActivePattern GUID </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveTriggers(List<UserData> Recipients, List<Guid> ActiveTriggers, Guid ChangedItem, DataUpdateType Type);

/// <summary>
///     When a pattern is created, modified, or removed, push its new data to the <paramref name="Recipients"/> 
///     for caching. If <paramref name="LightItem"/> is null, it is assumed the item is to be removed.
/// </summary>
public record PushClientDataChangePattern(List<UserData> Recipients, Guid ItemId, LightPattern? LightItem);

/// <summary>
///     When a alarm is created, modified, or removed, push its new data to the <paramref name="Recipients"/> 
///     for caching. If <paramref name="LightItem"/> is null, it is assumed the item is to be removed.
/// </summary>
public record PushClientDataChangeAlarm(List<UserData> Recipients, Guid ItemId, LightAlarm? LightItem);

/// <summary>
///     When a trigger is created, modified, or removed, push its new data to the <paramref name="Recipients"/> 
///     for caching. If <paramref name="LightItem"/> is null, it is assumed the item is to be removed.
/// </summary>
public record PushClientDataChangeTrigger(List<UserData> Recipients, Guid ItemId, LightTrigger? LightItem);
