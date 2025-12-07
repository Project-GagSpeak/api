using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterMoodlesDataFull(UserData User, UserData Enactor, CharaMoodleData NewData) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterMoodlesSM(UserData User, UserData Enactor, string DataString, List<MoodlesStatusInfo> DataInfo) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterMoodlesStatuses(UserData User, UserData Enactor, List<MoodlesStatusInfo> Statuses) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterMoodlesPresets(UserData User, UserData Enactor, List<MoodlePresetInfo> Presets) : KinksterBase(User);
