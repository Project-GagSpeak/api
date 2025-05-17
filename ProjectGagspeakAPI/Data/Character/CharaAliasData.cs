using GagspeakAPI.Data.Interfaces;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class PairAliasStorage : SortedList<string, NamedAliasStorage>
{
    public PairAliasStorage()
    { }

    // Helpful for config read-write
    public PairAliasStorage(SortedList<string, NamedAliasStorage> init) 
        : base(init) 
    { }

    public bool NameIsStored(string key) => this.TryGetValue(key, out var res) && !string.IsNullOrEmpty(res.StoredNameWorld);
}

[MessagePackObject(keyAsPropertyName: true)]
public class NamedAliasStorage
{
    public string StoredNameWorld { get; set; } = string.Empty;
    public AliasStorage Storage { get; set; } = new AliasStorage();

    [IgnoreMember]
    public string ExtractedListenerName => string.IsNullOrEmpty(StoredNameWorld) ? "Not Yet Listening!" : StoredNameWorld;
}

// This can double as a use for a GlobalAliasStorage.
[MessagePackObject(keyAsPropertyName: true)]
public class AliasStorage : List<AliasTrigger>, IEditableStorage<AliasTrigger>
{
    public AliasStorage()
    { }

    public AliasStorage(IEnumerable<AliasTrigger> init)
        : base(init)
    { }

    public bool TryApplyChanges(AliasTrigger oldItem, AliasTrigger changedItem)
    {
        if (changedItem is null)
            return false;

        oldItem.ApplyChanges(changedItem);
        return true;
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public class AliasTrigger : IEditableStorageItem<AliasTrigger>
{
    /// <summary> Unique identifier for the trigger. </summary>
    public Guid Identifier { get; set; } = Guid.NewGuid();

    /// <summary> Whether the trigger is enabled or not. </summary>
    public bool Enabled { get; set; } = false;

    /// <summary> The label for the trigger. </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary> The input command that triggers the output command </summary>
    public string InputCommand { get; set; } = string.Empty;

    /// <summary> Stores Actions with unique types. </summary>
    public HashSet<InvokableGsAction> Actions { get; set; } = new HashSet<InvokableGsAction>() { new TextAction() };

    public AliasTrigger() 
    { }

    public AliasTrigger(AliasTrigger other, bool keepId)
    {
        Identifier = keepId ? other.Identifier : Guid.NewGuid();
        ApplyChanges(other);
    }

    public AliasTrigger Clone(bool keepId = false)
        => new AliasTrigger(this, keepId);

    public void ApplyChanges(AliasTrigger changedItem)
    {
        Enabled = changedItem.Enabled;
        Label = changedItem.Label;
        InputCommand = changedItem.InputCommand;
        Actions = changedItem.Actions.ToHashSet();
    }
}
