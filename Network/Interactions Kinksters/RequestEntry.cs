using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Comparer;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record ActiveRequests(List<KinksterPairRequest> KinksterRequests, List<CollarRequest> CollarRequests);

/// <summary>
///     Contains information about a Kinkster Request between 2 people.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterPairRequest(UserData User, UserData Target, string Message, DateTime CreationTime) : KinksterBase(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(3) - (DateTime.UtcNow - CreationTime);
    public bool IsExpired() => DateTime.Now - CreationTime > TimeSpan.FromDays(3);
}

/// <summary>
///     A request to establish a collar connection between two kinksters. <para />
///     
///     The Sender MUST be the person that will become the collared Kinkster's Owner, 
///     and the receiver MUST be the kinkster that will be collared. <para />
///     
///     If the receiver accepts the request, they should accept it with the collar 
///     they want to have, which becomes the collar restriction. <para />
///     
///     If at any point the item is removed from storage and cannot be found, the collar and bond are removed. <para />
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CollarRequest(UserData User, UserData Target, string Writing, DateTime CreationTime, CollarAccess TargetAccess, CollarAccess OwnerAccess) : KinksterBase(User)
{
    public DateTimeOffset ExpireTime() => CreationTime.AddHours(8);
    public TimeSpan TimeLeft() => TimeSpan.FromHours(8) - (DateTime.UtcNow - CreationTime);
    public bool IsExpired() => DateTime.Now - CreationTime > TimeSpan.FromHours(8);
}
