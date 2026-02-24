using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     Modifies the enabled state. Item of another Kinkstera Kinkster Pair's active Pattern, then syncs the update with that kinksters pairs. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterEnabledState(UserData Target, GSModule Module, Guid ItemId, bool NewState)
{
    public override string ToString()
        => $"EnabledStateUpdate: [Target -> {Target.AliasOrUID}, Module -> {Module}, ItemId -> {ItemId}, NewState -> {NewState}]";
}

[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterEnabledStates(UserData Target, GSModule Module, List<Guid> Items, bool NewState)
{
    public override string ToString()
        => $"EnabledStatesUpdate: [Target -> {Target.AliasOrUID}, Module -> {Module}, ItemIds -> {string.Join(", ", Items)}, NewState -> {NewState}]"; 
}