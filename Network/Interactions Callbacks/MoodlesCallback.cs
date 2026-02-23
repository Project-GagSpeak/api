using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesDataUpdate(UserData User, MoodleData NewData) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesSMUpdate(UserData User, string DataString, List<MoodlesStatusInfo> DataInfo) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesStatusesUpdate(UserData User, List<MoodlesStatusInfo> Statuses) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesPresetsUpdate(UserData User, List<MoodlePresetInfo> Presets) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesStatusModified(UserData User, MoodlesStatusInfo Status, bool Deleted) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record MoodlesPresetModified(UserData User, MoodlePresetInfo Preset, bool Deleted) : KinksterBase(User);
