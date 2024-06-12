namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class PairPairSpecificConfigToybox
{
     public bool CanChangeToyState { get; set; }   // if the client pair can turn your toy on and off.
     public bool IntensityControl { get; set; }    // if the client pair can control the intensity of your toy.
     public bool CanUsePatterns { get; set; }      // if the client pair can use patterns on your toy.
     public bool CanUseTriggers { get; set; }      // if the client pair can use triggers on your toy.
}