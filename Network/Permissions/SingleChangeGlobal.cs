using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;
using System.Text;

namespace GagspeakAPI.Network;

/// <summary>
///     Updates one of <paramref name="Target"/>'s GlobalPermission values.
/// </summary>
/// <param name="Target"> The Kinkster that the GlobalPermission was changed for. </param>
/// <param name="Enactor"> The Kinkster that performed this act. Useful when updating another Kinkster's Permissions, to know who did it. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record SingleChangeGlobal(UserData Target, KeyValuePair<string, object> NewPerm, UserData Enactor) : KinksterBase(Target)
{
    public override string ToString() => $"SingleChangeGlobal: " +
        $"[Target Kinkster -> {User.AliasOrUID}, Changed Permission -> {NewPerm.Key} to {NewPerm.Value}, Enacted by {Enactor.AliasOrUID}]";
}