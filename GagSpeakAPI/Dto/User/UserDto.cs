using Gagspeak.API.Data;
using MessagePack;

namespace Gagspeak.API.Dto.User;

/// <summary>
/// a datatransfer object that stores the user data information.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);