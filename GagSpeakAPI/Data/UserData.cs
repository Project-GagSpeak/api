using MessagePack;

namespace Gagspeak.API.Data;

/// <summary>
/// the record storing the User Data information.
/// <para> Data consists of a UID, registered as their personal Key, and an Alias (nickname) </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, string? Alias = null)
{
    [IgnoreMember]
    public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;
}