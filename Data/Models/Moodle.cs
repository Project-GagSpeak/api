using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class Moodle
{
    public virtual MoodleType Type => MoodleType.Status;
    public Guid Id { get; internal set; } = Guid.Empty;

    public Moodle()
    { }

    public Moodle(Moodle other)
        => Id = other.Id;

    public Moodle(Guid id)
        => Id = id;

    public void UpdateId(Guid newId)
        => Id = newId;

    public override bool Equals(object? obj) 
        => obj is Moodle other && Id.Equals(other.Id);

    public override int GetHashCode()
        => Id.GetHashCode();
}

[MessagePackObject(keyAsPropertyName: true )]
public class MoodleTuple : Moodle
{
    public override MoodleType Type => MoodleType.Tuple;
    public MoodlesStatusInfo Tuple { get; internal set; } = new();
    public MoodleTuple()
        : base()
    { }

    public MoodleTuple(MoodleTuple other)
        => (Id, Tuple) = (other.Id, other.Tuple);

    public MoodleTuple(MoodlesStatusInfo tuple)
        => UpdateTuple(tuple.GUID, tuple);

    public void UpdateTuple(Guid newId, MoodlesStatusInfo newTuple)
        => (Id, Tuple) = (newId, newTuple);
}

[MessagePackObject(keyAsPropertyName: true)]
public class MoodlePreset : Moodle
{
    public override MoodleType Type => MoodleType.Preset;
    public List<Guid> StatusIds { get; internal set; } = new List<Guid>();

    public MoodlePreset()
        : base()
    { }

    public MoodlePreset(MoodlePreset other)
        => (Id, StatusIds) = (other.Id, other.StatusIds);

    public MoodlePreset(Guid id, IEnumerable<Guid> statusIds)
        => (Id, StatusIds) = (id, statusIds.ToList());

    public void UpdatePreset(Guid newId, IEnumerable<Guid> newStatusIds)
        => (Id, StatusIds) = (newId, newStatusIds.ToList());
}
