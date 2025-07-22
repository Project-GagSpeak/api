using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> Modifies a Kinkster Pair's active Pattern, then syncs the update with that kinksters pairs. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterActivePattern(UserData Target, Guid ActivePattern, DataUpdateType Type);

/// <summary> Modifies a Kinkster Pair's active Alarms, then syncs the update with that kinksters pairs. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterActiveAlarms(UserData Target, List<Guid> ActiveAlarms, Guid ChangedItem, DataUpdateType Type);

/// <summary> Modifies a Kinkster Pair's active Triggers, then syncs the update with that kinksters pairs. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterActiveTriggers(UserData Target, List<Guid> ActiveTriggers, Guid ChangedItem, DataUpdateType Type);
