using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class Moodle
{
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

[MessagePackObject(keyAsPropertyName: true)]
public class MoodlePreset : Moodle
{
    public IEnumerable<Guid> StatusIds { get; internal set; } = Enumerable.Empty<Guid>();

    public MoodlePreset()
        : base()
    { }

    public MoodlePreset(MoodlePreset other)
        => (Id, StatusIds) = (other.Id, other.StatusIds);

    public MoodlePreset(Guid id, IEnumerable<Guid> statusIds)
        => (Id, StatusIds) = (id, statusIds);

    public void UpdatePreset(Guid newId, IEnumerable<Guid> newStatusIds)
        => (Id, StatusIds) = (newId, newStatusIds);
}
