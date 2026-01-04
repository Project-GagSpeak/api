using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

// It's ok to do full data here since it makes it both similar and is called the least out of anything.
[MessagePackObject(keyAsPropertyName: true)]
public record HardcoreStateChange(UserData Target, HardcoreStatus NewData, HcAttribute Changed, UserData Enactor) : KinksterBase(Target)
{
    public override string ToString() => $"HcStateChange: [Target -> {User.AliasOrUID}, Changed Attribute -> ({Changed})] Enactor: {Enactor.AliasOrUID}";
}

[MessagePackObject(keyAsPropertyName: true)]
public record HardcoreAttributeExpired(HcAttribute Attribute, UserData Enactor)
{
    public override string ToString() => $"Hardcore Attribute Expired: [Attribute -> {Attribute}] Fake Enactor: {Enactor.AliasOrUID}";
}
