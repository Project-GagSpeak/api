namespace GagspeakAPI.Data;

public interface IThresholdContainer
{
    /// <summary> The LOWEST value in the threshold range </summary>
    public int ThresholdMinValue { get; set; }

    /// <summary> The HIGHEST value in the threshold range </summary>
    public int ThresholdMaxValue { get; set; }
}

