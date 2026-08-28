using GagspeakAPI.Chat;
using MessagePack;

namespace GagspeakAPI.User;

/// <summary>
///   Reflects the main information of a Sundouleia user. <para />
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserData(
    string UID,
    string? Alias = null,
    string? VanityName = null,
    uint? Color = null,
    uint? GlowColor = null,
    CkVanityTier Tier = CkVanityTier.NoRole,
    DateTime? CreatedOn = null)
{
    [IgnoreMember] public string AliasOrUID => Alias ?? UID;
    [IgnoreMember] public string VanityOrAnonName => VanityName ?? AnonName;
    [IgnoreMember] public string AnonName => "Kinkster-" + UID[^4..];
    [IgnoreMember] public string AnonTag => UID[^4..];
}

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalChatMember(UserData User, ChatFlags Flags) : UserDto(User);
