using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using MessagePack;

namespace Gagspeak.API.Dto.User;

/// <summary>
/// Used primarily to transfer a user's pair status to another connected user.
/// <para>
/// Split into only transferring pair status for the sake of it being a message frequently transferred.
/// </para>
/// </summary>
/// <param name="User"></param>
/// <param name="IndividualPairStatus"></param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserIndividualPairStatusDto(UserData User, IndividualPairStatus IndividualPairStatus) : UserDto(User);