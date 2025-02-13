using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> The primary record used to represent a kinkster. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, string? Alias = null, CkSupporterTier? Tier = CkSupporterTier.NoRole, DateTime? CreatedOn = null)
{
    [IgnoreMember]
    public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;
}
