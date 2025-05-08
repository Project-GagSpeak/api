using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public class ShockAction
{
    public ShockMode OpCode { get; set; } = ShockMode.Beep;
    public int Duration { get; set; } = 0;
    public int Intensity { get; set; } = 0;
}
