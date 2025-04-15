using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record UserGlobalPermChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedPermission, UpdateDir Direction) : UserDto(User)
{
    public override string ToString()
    {
        return "UserGlobalPermChangeDto { " + $"User = {User.UID}, Enactor = {Enactor.UID}, ChangedPermission = [{ChangedPermission.Key}, {ChangedPermission.Value}], Direction = {Direction}" + " }";
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairPermChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedPermission, UpdateDir Direction) : UserDto(User)
{
    public override string ToString()
    {
        return "UserPairPermChangeDto { " + $"User = {User.UID}, Enactor = {Enactor.UID}, ChangedPermission = [{ChangedPermission.Key}, {ChangedPermission.Value}], Direction = {Direction}" + " }";
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairAccessChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedAccessPermission, UpdateDir Direction) : UserDto(User)
{
    public override string ToString()
    {
        return "UserPairAccessChangeDto { " + $"User = {User.UID}, Enactor = {Enactor.UID}, ChangedAccessPermission = [{ChangedAccessPermission.Key}, {ChangedAccessPermission.Value}], Direction = {Direction}" + " }";
    }
}
