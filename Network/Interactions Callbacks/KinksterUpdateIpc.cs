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



[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcData(UserData User, CharaIpcDataFull NewData) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcDataLight(UserData User, CharaIpcLight NewData) : KinksterBase(User);

// The most frequently changed IPC data is pulled out into its own group to avoid sending excess data that can be handled seperately.
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcManipulations(UserData User, string ModManipulations) : KinksterBase(User);

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterIpcGlamourer(UserData User, string ActorBase64) : KinksterBase(User);
