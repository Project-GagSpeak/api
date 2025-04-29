using GagspeakAPI.Data;
using GagspeakAPI.Data;
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
    public int AffectedLayer { get; init; } = -1;
    public GagType PreviousGag { get; init; } = GagType.None;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}

[MessagePackObject(keyAsPropertyName: true)]
public record CallbackRestrictionDataDto(UserData User, UserData Enactor, ActiveRestriction NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public int AffectedLayer { get; init; } = -1;
    public Guid PreviousRestriction { get; init; } = Guid.Empty;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackRestraintDataDto(UserData User, UserData Enactor, CharaActiveRestraint NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public Guid PreviousRestraint { get; init; } = Guid.Empty;
    public byte PreviousLayers { get; init; } = 0b00000;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}


[MessagePackObject(keyAsPropertyName: true)] // Should not need an update type for this, just track latest data and last interacted.
public record CallbackCursedLootDto(UserData User, IEnumerable<Guid> NewActiveItems, LightCursedItem InteractedLoot) : UserDto(User);

[MessagePackObject(keyAsPropertyName: true)]
public record CallbackToyboxDataDto(UserData User, UserData Enactor, CharaToyboxData NewData, DataUpdateType Type, UpdateDir Direction) : UserDto(User)
{
    public Guid InteractedIdentifier { get; init; } = Guid.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record CallbackAliasGlobalUpdateDto(UserData User, AliasTrigger NewData) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackAliasPairUpdateDto(UserData User, AliasTrigger NewData) : UserDto(User);


[MessagePackObject(keyAsPropertyName: true)]
public record CallbackLightStorageDto(UserData User, UserData Enactor, CharaLightStorageData LightStorage, UpdateDir Direction) : UserDto(User);
