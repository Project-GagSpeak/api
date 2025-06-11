namespace GagspeakAPI.Data.Struct;

public readonly struct EmoteState(string uid, ushort id, byte cpose, bool devotional) : IEquatable<EmoteState>
{
    public string UID { get; init; } = uid;
    public ushort EmoteID { get; init; } = id;
    public byte CyclePoseByte { get; init; } = cpose;
    public bool Devotional { get; init; } = devotional;

    public static EmoteState Empty => new(string.Empty, 0, 0, false);
    public static EmoteState FromString(string emoteStr)
    {
        if (string.IsNullOrEmpty(emoteStr))
            return Empty;
        // Handle valid case.
        var parts = emoteStr.Split('|');
        return new(parts[0], ushort.Parse(parts[1]), byte.Parse(parts[2]), parts.Length > 3);
    }
    public bool Equals(EmoteState other)
        => UID == other.UID 
        && EmoteID == other.EmoteID 
        && CyclePoseByte == other.CyclePoseByte 
        && Devotional == other.Devotional;

    public override bool Equals(object? obj)
        => obj is EmoteState other && Equals(other);

    public override int GetHashCode()
        => HashCode.Combine(UID, EmoteID, CyclePoseByte, Devotional);

    public static bool operator ==(EmoteState left, EmoteState right) => left.Equals(right);
    public static bool operator !=(EmoteState left, EmoteState right) => !left.Equals(right);
}

