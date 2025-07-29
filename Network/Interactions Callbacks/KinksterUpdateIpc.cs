using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcDataFull(UserData User, UserData Enactor, CharaIPCData NewData) : KinksterBase(User);


[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcStatusManager(UserData User, UserData Enactor, string DataString, List<MoodlesStatusInfo> DataInfo) : KinksterBase(User);


[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcStatuses(UserData User, UserData Enactor, List<MoodlesStatusInfo> Statuses) : KinksterBase(User);


[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcPresets(UserData User, UserData Enactor, List<MoodlePresetInfo> Presets) : KinksterBase(User);