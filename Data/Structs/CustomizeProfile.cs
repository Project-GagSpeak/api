namespace GagspeakAPI.Data.Struct;
public record struct CustomizeProfile : IEquatable<CustomizeProfile>
{
    public Guid ProfileGuid { get; set; } = Guid.Empty;
    public int Priority { get; set; } = 0;
    public string ProfileName { get; set; } = string.Empty;
    public CustomizeProfile(Guid uniqueId, int priority, string profileName = "")
    {
        ProfileGuid = uniqueId;
        Priority = priority;
        ProfileName = profileName;
    }

    public static CustomizeProfile Empty => new CustomizeProfile(Guid.Empty, 0);

    public void SetPriority(int priority)
        => Priority = (priority < 0) ? 0 : priority;

    public bool Equals(CustomizeProfile other)
        => ProfileGuid.Equals(other.ProfileGuid);

    public override int GetHashCode()
        => ProfileGuid.GetHashCode() ^ Priority.GetHashCode();
}
