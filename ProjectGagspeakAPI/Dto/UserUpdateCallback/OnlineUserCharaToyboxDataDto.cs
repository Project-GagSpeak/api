using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// DTO for handling updated to a pair or self's Toybox data.
/// <para><b>User == The user Updated (can be client caller or other pair)</b></para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaToyboxDataDto(UserData User, UserData Enactor, CharaToyboxData ToyboxInfo, ToyboxUpdateType Type, UpdateDir Direction) : UserDto(User);
