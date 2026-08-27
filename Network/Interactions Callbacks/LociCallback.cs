using GagspeakAPI.Data;
using GagspeakAPI.User;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record LociDataUpdate(UserData User, LociContainerData Data) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusesUpdate(UserData User, List<LociStatusStruct> Statuses) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetsUpdate(UserData User, List<LociPresetStruct> Presets) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusModified(UserData User, LociStatusStruct Status, bool Deleted) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record LociPresetModified(UserData User, LociPresetStruct Preset, bool Deleted) : UserDto(User);
