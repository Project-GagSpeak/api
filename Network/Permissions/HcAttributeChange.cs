using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.Network;

// It's ok to do full data here since it makes it both similar and is called the least out of anything.
public record HardcoreStateChange(UserData Target, HardcoreState NewData, HcAttribute Changed, UserData Enactor) : KinksterBase(Target)
{
    public override string ToString() => $"HcStateChange: [Target -> {User.AliasOrUID}, Changed Attribute -> ({Changed})] Enactor: {Enactor.AliasOrUID}";
}

public record HardcoreAttributeExpired(HcAttribute Attribute, UserData Enactor)
{
    public override string ToString() => $"Hardcore Attribute Expired: [Attribute -> {Attribute}] Fake Enactor: {Enactor.AliasOrUID}";
}
