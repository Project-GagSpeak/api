using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class HypnoticEffect
{
    /// <summary> How fast the hypnotic image spins. </summary>
    public float SpinSpeed { get; set; } = 1f;

    /// <summary> What Tint color is applied to the hypnotic image. (Defaults to White) </summary>
    public uint TintColor { get; set; } = 0xFFFFFFFF;

    /// <summary> What Attributes the hypnotic display should have. </summary>
    public HypnoAttributes Attributes { get; set; } = HypnoAttributes.TextIsSequential;

    /// <summary> What Tint color is applied to the displayed text, if any. (Defaults to Purple) </summary>
    public uint TextColor { get; set; } = 0xFFFF00FF;

    /// <summary> What various text strings should we show at the center of the spiral. </summary>
    public string[] DisplayWords { get; set; } = [];

    /// <summary> How frequently do we cycle through the display words. </summary>
    public float TextCycleSpeed { get; set; } = 1f;
}
