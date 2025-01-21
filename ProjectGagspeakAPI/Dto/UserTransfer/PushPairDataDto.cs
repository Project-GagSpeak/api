using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;


[MessagePackObject(keyAsPropertyName: true)]
public record PushPairGagDataUpdateDto(UserData Recipient, GagUpdateType Type) : UserDto(Recipient)
{
    public GagLayer Layer { get; init; } = GagLayer.UnderLayer;
    public GagType Gag { get; init; } = GagType.None;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushPairRestraintDataUpdateDto(UserData Recipient, WardrobeUpdateType Type) : UserDto(Recipient)
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushPairOrdersDataUpdateDto(UserData Recipient, OrdersUpdateType Type) : UserDto(Recipient)
{
    /* Nothing Internal Yet */
}


[MessagePackObject(keyAsPropertyName: true)] // should only EVER be called for a name change purpose, reject otherwise.
public record PushPairAliasDataUpdateDto(UserData Recipient, CharaAliasData LastAliasData, PuppeteerUpdateType Type) : UserDto(Recipient)
{
    /* Nothing Internal Yet */
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushPairToyboxDataUpdateDto(UserData Recipient, CharaToyboxData LastToyboxData, ToyboxUpdateType Type) : UserDto(Recipient)
{
    public Guid AffectedIdentifier { get; init; } = Guid.Empty;
}

