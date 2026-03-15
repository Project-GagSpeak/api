using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LociStatusStruct
{
    public int Version { get; init; }
    public Guid GUID { get; init; }
    public uint IconID { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string CustomVFXPath { get; init; }
    public long ExpireTicks { get; init; }
    public byte Type { get; init; }
    public int Stacks { get; init; }
    public int StackSteps { get; init; }
    public int StackToChain { get; init; }
    public uint Modifiers { get; init; }
    public Guid ChainedGUID { get; init; }
    public byte ChainType { get; init; }
    public int ChainTrigger { get; init; }
    public string Applier { get; init; }
    public string Dispeller { get; init; }
}
