namespace GagspeakAPI.Profiles;

/// <summary>
///   The contents of a UserProfile outside validations and ImageData.
/// </summary>
public class UserProfileV1 : IEquatable<UserProfileV1>
{
    public int Version { get; set; } = 1;
    public string DisplayName { get; set; } = string.Empty;
    public string Pronouns { get; set; } = string.Empty;
    // Orientation?
    public RoleLean RoleLean { get; set; } = RoleLean.None;
    public List<string> Kinks { get; set; } = [];
    public string Description { get; set; } = string.Empty;
    public UserProfileTheme Theme { get; set; } = new();

    public bool Equals(UserProfileV1? other)
    {
        // Fast paths
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        // Compare value types and strings
        return Version == other.Version &&
               DisplayName == other.DisplayName &&
               Pronouns == other.Pronouns &&
               RoleLean == other.RoleLean &&
               Description == other.Description &&
               // Compare List contents, not memory references
               Kinks.SequenceEqual(other.Kinks) &&
               // Compare the nested object
               Theme.Equals(other.Theme);
    }

    public override bool Equals(object? obj)
        => Equals(obj as UserProfileV1);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Version);
        hash.Add(DisplayName);
        hash.Add(Pronouns);
        hash.Add(Description);
        hash.Add(Kinks.Count);
        hash.Add(Theme);
        return hash.ToHashCode();
    }
}