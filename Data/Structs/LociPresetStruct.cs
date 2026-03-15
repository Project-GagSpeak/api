using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LociPresetStruct
{
    public int Version { get; init; }
    public Guid GUID { get; init; }
    public List<Guid> Statuses { get; init; }
    public byte ApplicationType { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
}
