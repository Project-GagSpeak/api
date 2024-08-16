using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// DTO for handling updating self's IPC data.
/// <para><b>User == The user Updated (should be client caller)</b></para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaAliasDataDto(UserData User, CharacterAliasData AliasData, DataUpdateKind UpdateKind) : UserDto(User);
