using MessagePack;

namespace Gagspeak.API.Data;

/// <summary> Record storing the UserData record. This is seperate from the User model in the database.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, string? Alias = null)
{
    [IgnoreMember]
    public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;
}