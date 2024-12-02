using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record ShockTriggerAction
{
    public ShockMode OpCode { get; set; } = ShockMode.Beep; // OpCode (beep by default)
    public int Duration { get; set; } = 0; // duration of action
    public int Intensity { get; set; } = 0; // intensity of action (0-100)
}

