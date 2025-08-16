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
public record KinksterRequest(UserData User, UserData Target, string Message, DateTime CreationTime) : KinksterBase(User)
{
    public bool IsExpired() => DateTime.Now - CreationTime > TimeSpan.FromDays(3);
}

// preliminary
/// <summary>
///     A request to establish a collar connection between two kinksters. <para />
///     
///     The Sender MUST be the person that will become the collared Kinkster's Owner, 
///     and the reciever MUST be the kinkster that will be collared. <para />
///     
///     If the reciever accepts the request, they should accept it with the collar 
///     they want to have, which becomes the collar restriction. <para />
///     
///     If at any point the item is removed from storage and cannot be found, the collar and bond are removed. <para />
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CollarRequest(UserData User, UserData Target, string PreferredInitialWriting, DateTime CreationTime) : KinksterBase(User)
{
    // Once the collar is applied to the target, they will be able to change these aspects of the collar.
    public CollarAccess InitialTargetAccess { get; set; } = CollarAccess.Visuals;

    // What components of the collar the owner is allowed to modify after the collar is applied.
    public CollarAccess OwnerAccess { get; set; } = CollarAccess.AllButWriting;


    public bool IsExpired() => DateTime.Now - CreationTime > TimeSpan.FromHours(8);
};
