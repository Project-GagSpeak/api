using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> 
///     The primary record used to represent a kinkster. <para />
///     In an ideal world, Verified would be required, but that would pose issues on server end I think? <para />
///     For now, it is likely best to only pass verified when nessisary for things the client side needs.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(string UID, bool? Verified = false, string? Alias = null, CkSupporterTier? Tier = CkSupporterTier.NoRole, DateTime? CreatedOn = null)
{
    [IgnoreMember]
    public string AliasOrUID => string.IsNullOrWhiteSpace(Alias) ? UID : Alias;
}
