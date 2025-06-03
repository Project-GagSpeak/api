using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Contains information about a Kinkster Request between 2 people.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterRequest(UserData User, UserData Target, string Message, DateTime CreationTime) : KinksterBase(User)
{
    public bool IsExpired() => DateTime.Now - CreationTime > TimeSpan.FromDays(3);
}
