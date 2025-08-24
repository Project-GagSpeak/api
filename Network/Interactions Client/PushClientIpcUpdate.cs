using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesFull(List<UserData> Recipients, CharaMoodleData NewData);

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesSM(List<UserData> Recipients, string DataString, List<MoodlesStatusInfo> DataInfo);

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesStatuses(List<UserData> Recipients, List<MoodlesStatusInfo> Statuses);

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesPresets(List<UserData> Recipients, List<MoodlePresetInfo> Presets);


// For actual IPC.
[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcFull(List<UserData> Recipients, CharaIpcDataFull NewData);

[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcSingle(List<UserData> Recipients, DataSyncKind Type, string Data)
{
    public override string ToString() => $"To ({Recipients.Count}) recipients, Type: {Type}";
}
