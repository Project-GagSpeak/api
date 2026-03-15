using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The <paramref name="User"/>'s GagData changed for <paramref name="GagType"/>. If null, remove from cache.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewGagData(UserData User, GagType GagType, LightGag? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Gag: {GagType} | Removed: {NewData is null}";
}

/// <summary>
///     A <paramref name="User"/>'s Collar data was updated, now caching <paramref name="NewData"/>.
///     If null, the callback implies the Collar was removed.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewCollarData(UserData User, LightCollar? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <summary>
///     An update for <paramref name="User"/>, one of the stored Items.
///     This is received whenever the Item is modified, created, or deleted.
/// </summary>
/// <remarks> If <paramref name="NewData"/> is null, implies the <paramref name="ItemId"/> was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewRestrictionData(UserData User, Guid ItemId, LightRestriction? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <inheritdoc cref="KinksterNewRestrictionData"/>"
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewRestraintData(UserData User, Guid ItemId, LightRestraint? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <inheritdoc cref="KinksterNewRestrictionData"/>"
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewLootData(UserData User, Guid ItemId, LightCursedLoot? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <inheritdoc cref="KinksterNewRestrictionData"/>"
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewAliasData(UserData User, Guid ItemId, GagspeakAlias? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <inheritdoc cref="KinksterNewRestrictionData"/>"
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewPatternData(UserData User, Guid ItemId, LightPattern? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <inheritdoc cref="KinksterNewRestrictionData"/>"
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewAlarmData(UserData User, Guid ItemId, LightAlarm? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}

/// <inheritdoc cref="KinksterNewRestrictionData"/>"
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewTriggerData(UserData User, Guid ItemId, LightTrigger? NewData) : KinksterBase(User)
{
    public override string ToString() => $"NewData: [User: {User.AliasOrUID} | Id: {ItemId} | Updated: {(NewData is null ? "UNK" : NewData.Label)}";
}
