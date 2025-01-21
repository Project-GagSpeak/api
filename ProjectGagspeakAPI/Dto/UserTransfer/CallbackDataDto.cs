using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCompositeDataDto(UserData User, CharaCompositeData CompositeData, bool WasSafeword) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserIpcDataDto(UserData User, UserData Enactor, CharaIPCData NewData, IpcUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    // Method is called frequently, so likely do not include additional data.
}


[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserGagDataDto(UserData User, UserData Enactor, CharaGagData NewData, GagUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public GagLayer AffectedLayer { get; init; } = GagLayer.UnderLayer;
    public GagType PreviousGag { get; init; } = GagType.None;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
    public GagSlot AffectedSlot() => NewData.GagSlots[(int)AffectedLayer];
}


[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserRestraintDataDto(UserData User, UserData Enactor, CharaActiveSetData NewData, WardrobeUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public Guid RestraintModified { get; init; } = Guid.Empty;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}


[MessagePackObject(keyAsPropertyName: true)] // Should not need an update type for this, just track latest data and last interacted.
public record OnlineUserCursedLootDataDto(UserData User, List<Guid> NewActiveItems) : UserDto(User)
{
    // List should already be in its updated state with this item.
    public Guid LastInteractedItem { get; init; } = Guid.Empty;
}


[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserOrdersDataDto(UserData User, UserData Enactor, CharaOrdersData NewData, OrdersUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    // Nothing internal for Orders yet...
}


[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserAliasDataDto(UserData User, UserData Enactor, CharaAliasData NewData, PuppeteerUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    // Nothing internal for Aliases yet...
}


[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserToyboxDataDto(UserData User, UserData Enactor, CharaToyboxData NewData, ToyboxUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public Guid InteractedIdentifier { get; init; } = Guid.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserStorageUpdateDto(UserData User, UserData Enactor, CharaStorageData LightStorage, UpdateDir Direction) : UserDto(User);
