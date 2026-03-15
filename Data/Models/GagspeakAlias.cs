using MessagePack;

namespace GagspeakAPI.Data;

// DTO Variant
[MessagePackObject(keyAsPropertyName: true)]
public class GagspeakAlias
{
    public Guid Identifier { get; set; } = Guid.NewGuid();
    public bool Enabled { get; set; } = false;
    public string Label { get; set; } = string.Empty;
    public bool IgnoreCase { get; set; } = false;
    public string InputCommand { get; set; } = string.Empty;
    public HashSet<InvokableGsAction> Actions { get; set; } = new HashSet<InvokableGsAction>();
    public HashSet<string> WhitelistedUIDs { get; set; } = new HashSet<string>();

    public bool CanView(string uid) => WhitelistedUIDs.Count is 0 || WhitelistedUIDs.Contains(uid);
}
