using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcDataFull(List<UserData> Recipients, CharaIPCData NewData);


[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcStatusManager(List<UserData> Recipients, string DataString, List<MoodlesStatusInfo> DataInfo);


[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcStatuses(List<UserData> Recipients, List<MoodlesStatusInfo> Statuses);


[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcPresets(List<UserData> Recipients, List<MoodlePresetInfo> Presets);


