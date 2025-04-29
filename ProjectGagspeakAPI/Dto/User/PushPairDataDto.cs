using GagspeakAPI.Data;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;


[MessagePackObject(keyAsPropertyName: true)]
public record PushPairGagDataUpdateDto(UserData Recipient, DataUpdateType Type) : UserDto(Recipient), IPadlockable
{
    public int Layer { get; init; } = -1;
    public GagType Gag { get; init; } = GagType.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string PadlockAssigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushPairRestrictionDataUpdateDto(UserData Recipient, DataUpdateType Type) : UserDto(Recipient), IPadlockable
{
    public int Layer { get; init; } = -1;
    public Guid RestrictionId { get; init; } = Guid.Empty;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string PadlockAssigner { get; init; } = string.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushPairRestraintDataUpdateDto(UserData Recipient, DataUpdateType Type) : UserDto(Recipient), IPadlockable
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public byte LayersBitfield { get; init; } = 0b00000;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string PadlockAssigner { get; init; } = string.Empty;
}


[MessagePackObject(keyAsPropertyName: true)]
public record PushPairOrdersDataUpdateDto(UserData Recipient, DataUpdateType Type) : UserDto(Recipient);


[MessagePackObject(keyAsPropertyName: true)]
public record PushPairToyboxDataUpdateDto(UserData Recipient, CharaToyboxData LastToyboxData, DataUpdateType Type) : UserDto(Recipient)
{
    public Guid AffectedIdentifier { get; init; } = Guid.Empty;
}

