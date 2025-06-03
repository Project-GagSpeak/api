using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Updates one of <paramref name="Target"/>'s UserPairPermission values.
/// </summary>
/// <param name="Target"> The Kinkster that the UserPairPermission was changed for. </param>
/// <param name="NewPermValue"> The Permission Name, and new value for it. </param>
/// <param name="Enactor"> The Kinkster that performed this act. Useful when updating another Kinkster's Permissions, to know who did it. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record SingleChangeUnique(UserData Target, KeyValuePair<string, object> NewPerm, UpdateDir Direction, UserData Enactor) : KinksterBase(Target)
{
    public override string ToString() => $"SingleChangeUniquePerm: " +
        $"[Target Kinkster -> {User.AliasOrUID}, Changed Unique Permission -> {NewPerm.Key} to {NewPerm.Value}, Enacted by {Enactor.AliasOrUID}]";
}
