using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Data.Character;

[MessagePackObject(keyAsPropertyName: true)]
public class CharaCompositeData
{
    public CharaActiveGags Gags { get; set; } = new();
    public CharaActiveRestrictions Restrictions { get; set; } = new();
    public CharaActiveRestraint Restraint { get; set; } = new();
    public List<Guid> CursedItems { get; set; } = new();
    public Dictionary<string, CharaAliasData> AliasData { get; set; } = new();
    public CharaToyboxData ToyboxData { get; set; } = new();
    public CharaLightStorageData LightStorageData { get; set; } = new();
}

// Dummy Filler.
[MessagePackObject]
public class CharaOrdersData() { }
