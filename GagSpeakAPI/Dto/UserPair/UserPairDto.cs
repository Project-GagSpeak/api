using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Data.CharacterData;
using MessagePack;

namespace GagSpeak.API.Dto.UserPair;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User, IndividualPairStatus IndividualPairStatus,
    UserPermissionsComposite OwnPermissionsComposite, UserPermissionsEditAccessComposite OwnEditAccessPermissions,
    UserPermissionsComposite OtherPermissionsComposite, UserPermissionsEditAccessComposite OtherEditAccessPermissions
    ) : UserDto(User)
{
    public UserPermissionsComposite OwnPermissionsComposite { get; set; } = OwnPermissionsComposite;
    public UserPermissionsEditAccessComposite OwnEditAccessPermissions { get; set; } = OwnEditAccessPermissions;
    public UserPermissionsComposite OtherPermissionsComposite { get; set; } = OtherPermissionsComposite;
    public UserPermissionsEditAccessComposite OtherEditAccessPermissions { get; set; } = OtherEditAccessPermissions;
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;

}