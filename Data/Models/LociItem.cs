using MessagePack;

namespace GagspeakAPI.Data;

public enum LociType
{
    Status = 0,
    Preset = 1,
    Tuple = 2
}

[MessagePackObject(keyAsPropertyName: true)]
public class LociItem
{
    public virtual LociType Type => LociType.Status;
    public Guid Id { get; set; } = Guid.Empty;

    public LociItem()
    { }

    public LociItem(LociItem other)
        => Id = other.Id;

    public LociItem(Guid id)
        => Id = id;

    public void UpdateId(Guid newId)
        => Id = newId;

    public override bool Equals(object? obj) 
        => obj is LociItem other && Id.Equals(other.Id);

    public override int GetHashCode()
        => Id.GetHashCode();
}

[MessagePackObject(keyAsPropertyName: true )]
public class LociTuple : LociItem
{
    public override LociType Type => LociType.Tuple;
    public LociStatusStruct Tuple { get; set; } = new();
    public LociTuple()
        : base()
    { }

    public LociTuple(LociTuple other)
        => (Id, Tuple) = (other.Id, other.Tuple);

    public LociTuple(LociStatusStruct tuple)
        => UpdateTuple(tuple.GUID, tuple);

    public void UpdateTuple(Guid newId, LociStatusStruct newTuple)
        => (Id, Tuple) = (newId, newTuple);
}

[MessagePackObject(keyAsPropertyName: true)]
public class LociPreset : LociItem
{
    public override LociType Type => LociType.Preset;
    public List<Guid> StatusIds { get; set; } = new List<Guid>();

    public LociPreset()
        : base()
    { }

    public LociPreset(LociPreset other)
        => (Id, StatusIds) = (other.Id, other.StatusIds);

    public LociPreset(Guid id, IEnumerable<Guid> statusIds)
        => (Id, StatusIds) = (id, statusIds.ToList());

    public void UpdatePreset(Guid newId, IEnumerable<Guid> newStatusIds)
        => (Id, StatusIds) = (newId, newStatusIds.ToList());
}
