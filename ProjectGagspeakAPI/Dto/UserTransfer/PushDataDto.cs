using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record PushCompositeDataMessageDto(List<UserData> Recipients, CharaCompositeData CompositeData, bool WasSafeword);


[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcDataUpdateDto(List<UserData> Recipients, CharaIPCData IpcData, IpcUpdateType Type) 
{
    /* Nothing Internal Yet */
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushGagDataUpdateDto(List<UserData> Recipients, GagUpdateType Type)
{
    // Any of these are only set if they are the new change.
    public GagLayer Layer { get; init; } = GagLayer.UnderLayer;
    public GagType Gag { get; init; } = GagType.None;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushRestraintDataUpdateDto(List<UserData> Recipients, WardrobeUpdateType Type)
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushCursedLootDataUpdateDto(List<UserData> Recipients, List<Guid> ActiveItems)
{
    public Guid LootIdInteracted { get; init; } = Guid.Empty; // The Cursed Item being applied or removed.
    public GagLayer Layer { get; init; } = GagLayer.UnderLayer; // layer cursed loot is applied to. (if gag)
    public GagType GagType { get; init; } = GagType.None; // padlock applied to the cursed loot. (if gag)
    public DateTimeOffset ReleaseTime { get; init; } = DateTimeOffset.MinValue; // Time the cursed loot is released. (if Gag)

    public bool IsCursedGag() => GagType != GagType.None;
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushOrdersDataUpdateDto(List<UserData> Recipients, OrdersUpdateType Type)
{
    /* Nothing Internal Yet */
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushAliasDataUpdateDto(UserData RecipientUser, CharaAliasData AliasData, PuppeteerUpdateType Type)
{
    /* Nothing Internal Yet */
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushToyboxDataUpdateDto(List<UserData> Recipients, CharaToyboxData LatestActiveItems, ToyboxUpdateType Type)
{
    public Guid AffectedIdentifier { get; init; } = Guid.Empty;
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushLightStorageMessageDto(List<UserData> Recipients, CharaStorageData LightStorage);




