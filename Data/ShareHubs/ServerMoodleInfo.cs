using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> Generic Pattern Info retrieved from search results. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ServerDataLociStatus
{
    /// <summary> The Author of this server's Loci </summary>
    public string Author = string.Empty;

    /// <summary> The tags for an associated LociStatus on the server. </summary>
    public HashSet<string> Tags = new HashSet<string>();

    /// <summary> The fetched status in LociStatusStruct format. </summary>
    public LociStatusStruct Status = new LociStatusStruct();

    /// <summary> How many likes does this have? </summary>
    public int Likes = 0;

    /// <summary> If we have liked the Loci. </summary>
    public bool HasLiked = false;
}
