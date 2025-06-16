using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> 
///     Only sent to people once when they login, or after a safeword. 
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaCompositeData
{
    public CharaActiveGags Gags { get; set; } = new();
    public CharaActiveRestrictions Restrictions { get; set; } = new();
    public CharaActiveRestraint Restraint { get; set; } = new();
    public List<Guid> ActiveCursedItems { get; set; } = new();
    public AliasStorage GlobalAliasData { get; set; } = new();
    public Dictionary<string, NamedAliasStorage> PairAliasData { get; set; } = new();
    public CharaToyboxData ToyboxData { get; set; } = new();
    public CharaLightStorageData LightStorageData { get; set; } = new();
}
