using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Client updated their Allowances for <paramref name="Module"/> with a new list of <paramref name="AllowedUids"/>.
///     The updated list is nessisary to know which clients pairs can apply apply with Hardcore Traits.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientAllowances(List<UserData> Recipients, GagspeakModule Module, string[] AllowedUids);
