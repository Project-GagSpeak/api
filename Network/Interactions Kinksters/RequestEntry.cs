using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record ActiveRequests(List<KinksterRequest> KinksterRequests, List<CollarRequest> CollarRequests);

/// <summary>
///     Contains information about a Kinkster Request between 2 people.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterRequest(UserData User, UserData Target, RequestDetails Details, DateTime CreatedAt) : KinksterBase(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(3) - (DateTime.UtcNow - CreatedAt);
    public bool IsExpired() => DateTime.UtcNow - CreatedAt > TimeSpan.FromDays(3);
}

/// <summary>
///     Various details about a request. Useful for filtering requests and such.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestDetails(bool IsTemp, string PreferredNick, string Message);


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
