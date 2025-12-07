using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     An update for <paramref name="User"/>, one of a Paired Kinksters Alias Data for the Client.
///     This is received whenever an Alias item is modified, created, or deleted, specifically for this Kinkster Pair.
/// </summary>
/// <remarks> If <paramref name="NewData"/> is null, implies the <paramref name="AliasId"/> was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateAliasUnique(UserData User, Guid AliasId, AliasTrigger? NewData) : KinksterBase(User)
{
    public override string ToString()
        => $"UniqueAliasUpdate: [Target -> {User.AliasOrUID}, AliasId -> {AliasId}, Updated Trigger [{(NewData is null ? "UNK" : NewData.Label)}";
}

