using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCompositeDataDto(UserData User, CharaCompositeData CompositeData, bool WasSafeword) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackIpcDataDto(UserData User, UserData Enactor, CharaIPCData NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackGagDataDto(UserData User, UserData Enactor, ActiveGagSlot NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public GagLayer AffectedSlot { get; init; } = GagLayer.UnderLayer;
    public GagType PreviousGag { get; init; } = GagType.None;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}

[MessagePackObject(keyAsPropertyName: true)]
public record CallbackRestrictionDataDto(UserData User, UserData Enactor, ActiveRestriction NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public int AffectedIndex { get; init; } = -1;
    public Guid PreviousRestriction { get; init; } = Guid.Empty;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackRestraintDataDto(UserData User, UserData Enactor, CharaActiveRestraint NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public Guid PreviousRestraint { get; init; } = Guid.Empty;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}


[MessagePackObject(keyAsPropertyName: true)] // Should not need an update type for this, just track latest data and last interacted.
public record CallbackCursedLootDto(UserData User, List<Guid> NewActiveItems) : UserDto(User)
{
    public Guid LastInteractedItem { get; init; } = Guid.Empty;
    public DateTimeOffset ReleaseTime { get; init; } = DateTimeOffset.MinValue;
}


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackOrdersDataDto(UserData User, UserData Enactor, CharaOrdersData NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    // Nothing internal for Orders yet...
}


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackAliasDataDto(UserData User, UserData Enactor, CharaAliasData NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    // Nothing internal for Aliases yet...
}


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackToyboxDataDto(UserData User, UserData Enactor, CharaToyboxData NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public Guid InteractedIdentifier { get; init; } = Guid.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record CallbackLightStorageDto(UserData User, UserData Enactor, CharaLightStorageData LightStorage, UpdateDir Direction) : UserDto(User);
