using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Distributed to others whenever something with an alias trigger changes. <para />
///     The recipients will be the UID's that were whitelisted for the AliasTrigger. <para />
///     If <paramref name="NewData"/> is null, assume the AliasTrigger was removed.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeAlias(List<UserData> Recipients, Guid AliasId, AliasTrigger? NewData);

// TODO: Make this generic for any module!
/// <summary>
///     Pushes a single AliasTrigger state change to recipients, providing its new state. <para />
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientAliasState(List<UserData> Recipients, Guid AliasId, bool NewState);

/// <summary>
///     Distributes to all kinksters the current aliases enabled by their GUID. <para />
///     If a recipient doesnt have an ID provided, assume the alias is not shared with them. <para />
///     This allows the recipient to perform bulk interactions.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveAliases(List<UserData> Recipients, List<Guid> ActiveItems);

