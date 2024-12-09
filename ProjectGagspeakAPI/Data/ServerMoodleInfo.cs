using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Generic Pattern Info retrieved from search results.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ServerMoodleInfo
{
    /// <summary>
    /// How many likes does this have?
    /// </summary>
    public int Likes = 0;

    /// <summary>
    /// If we have liked the Moodle.
    /// </summary>
    public bool HasLikedMoodle = false;

    /// <summary>
    /// The Author of this server's Moodle
    /// </summary>
    public string Author = string.Empty;

    /// <summary>
    /// The tags for an associated MoodleStatus on the server.
    /// </summary>
    public List<string> Tags = new List<string>();


    /// <summary>
    /// The fetched status in MoodleStatusInfo format.
    /// </summary>
    public MoodlesStatusInfo MoodleStatus = new MoodlesStatusInfo();
}
