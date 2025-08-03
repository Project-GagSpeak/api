using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Data;

// May want to do something more than simply hold the GUID's for active states, but that is
// more of a future consideration. Only mentioning this because updating guid lists implies
// requiring the end user to compare the previous lists to the new one to get what was added or removed.
// but we don't yet know what implications that will have.
/// <summary> 
///     Only sent to people once when they login, or after a safeword. 
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaCompositeActiveData
{
    public CharaActiveGags Gags { get; set; } = new();
    public CharaActiveRestrictions Restrictions { get; set; } = new();
    public CharaActiveRestraint Restraint { get; set; } = new();
    public List<Guid> ActiveCursedItems { get; set; } = new();
    public AliasStorage GlobalAliasData { get; set; } = new();
    public Dictionary<string, NamedAliasStorage> PairAliasData { get; set; } = new();
    public List<ToyBrandName> ValidToys { get; set; } = new();
    public Guid ActivePattern { get; set; } = Guid.Empty;
    public List<Guid> ActiveAlarms { get; set; } = new();
    public List<Guid> ActiveTriggers { get; set; } = new();
    public CharaLightStorageData LightStorageData { get; set; } = new();
}
