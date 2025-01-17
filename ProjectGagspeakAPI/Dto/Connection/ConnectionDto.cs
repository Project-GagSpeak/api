using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// Requested by a client who has just connected to the server and wishes to fetch 
/// their information from the database to have it returned to them.
/// <para>
/// This DTO is used to return the current client version, the server's version, 
/// and also the users globally set permissions, along with their appearance data.
/// (Other additional data may be included by should be not stored in the DB to prevent bloat)
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionDto(UserData User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0); // The current version of the client
    public int ServerVersion { get; set; } // The version of the gagspeak server

    // Generic serverside data for the user.
    public UserGlobalPermissions UserGlobalPermissions { get; set; } = new(); // The user's global permissions
    public CharaAppearanceData GagData { get; set; } = new(); // The user's gag appearance data
    public CharaActiveSetData ActiveRestraintData { get; set; } = new(); // The user's active state data
    public List<PublishedPattern> PublishedPatterns { get; set; } = new();
    public List<PublishedMoodle> PublishedMoodles { get; set; } = new();
    public List<string> ActiveAccountUidList { get; set; } = new();
    public string UserAchievements { get; set; } = string.Empty; // The user's achievements
}
