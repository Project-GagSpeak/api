using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record PushCompositeDataMessageDto(List<UserData> Recipients, CharaCompositeData CompositeData, bool WasSafeword);


[MessagePackObject(keyAsPropertyName: true)]
public record PushIpcDataUpdateDto(List<UserData> Recipients, CharaIPCData IpcData, DataUpdateType Type) 
{
    /* Nothing Internal Yet */
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushGagDataUpdateDto(List<UserData> Recipients, DataUpdateType Type)
{
    // Any of these are only set if they are the new change.
    public GagLayer Layer { get; init; } = GagLayer.UnderLayer;
    public GagType Gag { get; init; } = GagType.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushRestrictionDataUpdateDto(List<UserData> Recipients, DataUpdateType Type)
{
    public int AffectedIndex { get; init; } = -1;
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushRestraintDataUpdateDto(List<UserData> Recipients, DataUpdateType Type)
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public byte LayersBitfield { get; init; } = 0b00000;
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
public record PushOrdersDataUpdateDto(List<UserData> Recipients, DataUpdateType Type)
{
    /* Nothing Internal Yet */
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushAliasDataUpdateDto(UserData RecipientUser, CharaAliasData AliasData, DataUpdateType Type)
{
    /* Nothing Internal Yet */
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushToyboxDataUpdateDto(List<UserData> Recipients, CharaToyboxData LatestActiveItems, DataUpdateType Type)
{
    public Guid AffectedIdentifier { get; init; } = Guid.Empty;
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushLightStorageMessageDto(List<UserData> Recipients, CharaLightStorageData LightStorage);
