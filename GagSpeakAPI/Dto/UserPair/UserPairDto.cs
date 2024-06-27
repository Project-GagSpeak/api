using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Data.Permissions;
using MessagePack;

namespace GagSpeak.API.Dto.UserPair;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User, IndividualPairStatus IndividualPairStatus,
    UserGlobalPermissions ownGlobalPerms,
    UserPairPermissions ownPairPerms,
    UserEditAccessPermissions ownEditAccessPerms,
    UserGlobalPermissions otherGlobalPerms,
    UserPairPermissions otherPairPerms,
    UserEditAccessPermissions otherEditAccessPerms
    ) : UserDto(User)
{
    public UserGlobalPermissions OwnGlobalPerms { get; set; } = ownGlobalPerms;
    public UserPairPermissions OwnPairPerms { get; set; } = ownPairPerms;
    public UserEditAccessPermissions OwnEditAccessPerms { get; set; } = ownEditAccessPerms;
    public UserGlobalPermissions OtherGlobalPerms { get; set; } = otherGlobalPerms;
    public UserPairPermissions OtherPairPerms { get; set; } = otherPairPerms;
    public UserEditAccessPermissions OtherEditAccessPerms { get; set; } = otherEditAccessPerms;
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;

}