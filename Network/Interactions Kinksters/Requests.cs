using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.User;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///   The User we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateRequest(UserData User, bool IsTemp, string Message) : UserDto(User);

/// <summary> 
///   The Kinkster we wish to send a request to, and what writing & permissions we wish to set.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateCollarRequest(UserData User, string InitialWriting, CollarAccess UserAccess, CollarAccess OwnerAccess) : UserDto(User);

/// <summary>
///   Contains information about a Kinkster Request between 2 people.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterRequest(UserData User, UserData Target, bool IsTemp, string Message, DateTime CreatedAt) : UserDto(User)
{
    public TimeSpan TimeLeft() => TimeSpan.FromDays(3) - (DateTime.UtcNow - CreatedAt);
    public bool IsExpired() => DateTime.UtcNow - CreatedAt > TimeSpan.FromDays(3);
}

/// <summary>
///   Very basic request response packet. Includes if the responder desires 
///   to forcibly accept the request as temporary, or permanent.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestResponse(UserData User, bool AsTemp) : UserDto(User);

/// <summary>
///   List variant of <see cref="RequestResponse"/>.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RequestResponses(List<RequestResponse> Responses);


/// <summary>
///   Kinkster's accept collar requests with this, establishing the setup for collar ownership and binding. <para />
///   The Collar, if already present or active, will not be provided, and instead null.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CollarResponse(UserData User, LightCollar? ChosenCollar = null) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record ActiveRequests(List<KinksterRequest> KinksterRequests, List<CollarRequest> CollarRequests);


/// <summary>
///   A request to establish a collar connection between two kinksters. <para />
///   
///   The Sender MUST be the person that will become the collared Kinkster's Owner, 
///   and the receiver MUST be the kinkster that will be collared. <para />
///   
///   If the receiver accepts the request, they should accept it with the collar 
///   they want to have, which becomes the collar restriction. <para />
///   
///   If at any point the item is removed from storage and cannot be found, the collar and bond are removed. <para />
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CollarRequest(UserData User, UserData Target, string Writing, DateTime CreationTime, CollarAccess TargetAccess, CollarAccess OwnerAccess) : UserDto(User)
{
    public DateTimeOffset ExpireTime() => CreationTime.AddHours(8);
    public TimeSpan TimeLeft() => TimeSpan.FromHours(8) - (DateTime.UtcNow - CreationTime);
    public bool IsExpired() => DateTime.Now - CreationTime > TimeSpan.FromHours(8);
}
