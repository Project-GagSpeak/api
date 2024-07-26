using GagspeakAPI.Data.Character;
using MessagePack;
using global::GagspeakAPI.Data;
using GagspeakAPI.Data.VibeServer;
using GagspeakAPI.Dto.User;

namespace GagspeakAPI.Dto.Toybox;

/// <summary>
/// Sends basic information about a user's connected Device.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaDeviceInfoMessageDto(PrivateRoomUser User, string RoomName, string Devicename, 
    string DeviceDisplayName, Dictionary<VibrateType, int> MotorsAndTypes);