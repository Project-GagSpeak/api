using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// DTO for handling the updating of our own data to our online user pairs.
/// </summary>
/// <param name="Recipients">The recipients of the update.</param>
/// <param name="AppearanceData">The appearance data to update.</param>
/// <param name="UpdatedLayer">The layer affected by the change.</param>
/// <param name="Type">What kind of updae interaction is occuring.</param>
/// <param name="PreviousLock">The Previous lock before the change. Used for unlock helpers.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaAppearanceDataMessageDto(
    List<UserData> Recipients, 
    CharaAppearanceData AppearanceData,
    GagLayer UpdatedLayer,
    GagUpdateType Type,
    Padlocks PreviousLock);

