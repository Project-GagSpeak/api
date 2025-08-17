using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///    The Updated RestrictionItem Data for a Kinkster Pair, that will be sent to all pairs.
/// </summary>
/// <param name="Target"> The Kinkster that the update is for. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterActiveCollar(UserData Target, DataUpdateType Type) : KinksterBase(Target)
{
    public Guid CollarId { get; init; } = Guid.Empty;
    public List<string> OwnerUIDs { get; init; } = new List<string>();
    public byte Dye1 { get; init; } = 0;
    public byte Dye2 { get; init; } = 0;
    public MoodlesStatusInfo Moodle { get; init; } = new();
    public string Writing { get; init; } = string.Empty;
    // Move these to respective global/kinkster pair permission tables if it is easier there.
    public CollarAccess EditAccess { get; init; } = CollarAccess.None;
    public CollarAccess OwnerEditAccess { get; init; } = CollarAccess.None;
}
