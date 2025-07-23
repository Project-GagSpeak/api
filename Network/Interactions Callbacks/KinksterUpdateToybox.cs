using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> Updated ActivePattern GUID </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActivePattern(UserData User, UserData Enactor, Guid ActivePattern, DataUpdateType Type);

/// <summary> Updated Active Alarm List GUID </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveAlarms(UserData User, UserData Enactor, List<Guid> ActiveAlarms, Guid ChangedItem, DataUpdateType Type);

/// <summary> Updated ActivePattern GUID </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveTriggers(UserData User, UserData Enactor, List<Guid> ActiveTriggers, Guid ChangedItem, DataUpdateType Type);

/// <summary>
///     Callback informing a Pattern's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewPatternData(UserData User, Guid ItemId, LightPattern? LightItem) : KinksterBase(User);

/// <summary>
///     Callback informing a Alarm's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewAlarmData(UserData User, Guid ItemId, LightAlarm? LightItem) : KinksterBase(User);

/// <summary>
///     Callback informing a Toybox's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewTriggerData(UserData User, Guid ItemId, LightTrigger? LightItem) : KinksterBase(User);

