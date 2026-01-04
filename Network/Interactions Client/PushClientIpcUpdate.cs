using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesFull(List<UserData> Recipients, MoodleData NewData);

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesSM(List<UserData> Recipients, string DataString, List<MoodlesStatusInfo> DataInfo);

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesStatuses(List<UserData> Recipients, List<MoodlesStatusInfo> Statuses);

[MessagePackObject(keyAsPropertyName: true)]
public record PushMoodlesPresets(List<UserData> Recipients, List<MoodlePresetInfo> Presets);
