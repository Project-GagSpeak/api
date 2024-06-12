using Gagspeak.API.Data;
using MessagePack;

namespace Gagspeak.API.Dto.User;

/// <summary>
/// Datatransfer object that stores the UserData.
/// <para> The UserData consists of the users UID or their AliasUID.</para>
/// <para> This is SEPERATE from the User class defined for the database. </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);