using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record UserGlobalPermChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedPermission, UpdateDir Direction) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record UserPairPermChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedPermission, UpdateDir Direction) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record UserPairAccessChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedAccessPermission, UpdateDir Direction) : UserDto(User);
