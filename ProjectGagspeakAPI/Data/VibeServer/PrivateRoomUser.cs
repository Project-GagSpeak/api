using GagspeakAPI.Data;
using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Data.VibeServer;

/// <summary>
/// Contains the record DTO for a userpair of the client.
/// 
/// <para>
/// 
/// Clients global permissions are not stored on initialization as they are not needed
/// and are stored in the player character manager.
/// 
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PrivateRoomUser(string UserUID, string ChatAlias, bool ActiveInRoom, bool vibeAccess);
