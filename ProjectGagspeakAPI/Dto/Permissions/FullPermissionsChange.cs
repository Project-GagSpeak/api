using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.Permissions;
using MessagePack;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> ONLY CALLED BY SELF </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkUpdatePermsGlobalDto(
    UserData User,
    UserData Enactor,
    UserGlobalPermissions GlobalPermissions,
    UpdateDir Direction
    ) : UserDto(User);


/// <summary> ONLY CALLED BY SELF </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkUpdatePermsUniqueDto(
    UserData User,
    UserData Enactor,
    UserPairPermissions UniquePerms,
    UserEditAccessPermissions UniqueAccessPerms,
    UpdateDir Direction
    ) : UserDto(User);


/// <summary> ONLY CALLED BY SELF </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkUpdatePermsAllDto(
    UserData User,
    UserData Enactor,
    UserGlobalPermissions GlobalPermissions,
    UserPairPermissions PairPermissions,
    UserEditAccessPermissions EditAccessPermissions,
    UpdateDir Direction
    ) : UserDto(User);
