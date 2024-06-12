using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using MessagePack;

namespace Gagspeak.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User, IndividualPairStatus IndividualPairStatus/*, UserPermissions OwnPermissions, UserPermissions OtherPermissions*/) : UserDto(User)
{
/*    public UserPermissions OwnPermissions { get; set; } = OwnPermissions;
    public UserPermissions OtherPermissions { get; set; } = OtherPermissions;*/
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
}