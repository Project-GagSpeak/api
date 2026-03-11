using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record LociDataUpdate(UserData User, CachedLociData Data) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusesUpdate(UserData User, List<LociStatusInfo> Statuses) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetsUpdate(UserData User, List<LociPresetInfo> Presets) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusModified(UserData User, LociStatusInfo Status, bool Deleted) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetModified(UserData User, LociPresetInfo Preset, bool Deleted) : KinksterBase(User);
