using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Received whenever a paired <paramref name="User"/> updates their <paramref name="AllowedUids"/> for a <paramref name="Module"/>.
///     The updated list is nessisary to know what items the client has permission to apply with Hardcore Traits.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewAllowances(UserData User, GagspeakModule Module, string[] AllowedUids) : KinksterBase(User)
{
    public override string ToString() => $"{User} changed allowances for Module: {Module}";
}
