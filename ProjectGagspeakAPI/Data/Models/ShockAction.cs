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

[Union(0, typeof(MoodlePresetApi))]
[Union(1, typeof(MoodleStatusApi))]
public interface IMoodleApi { }


[MessagePackObject(keyAsPropertyName: true)]
public record MoodlePresetApi(MoodlePresetInfo Preset, IEnumerable<MoodlesStatusInfo> Statuses) : IMoodleApi;


[MessagePackObject(keyAsPropertyName: true)]
public record MoodleStatusApi(MoodlesStatusInfo Status) : IMoodleApi;
