using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using MessagePack;

namespace Gagspeak.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User, IndividualPairStatus IndividualPairStatus) : UserDto(User)
{
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
}