namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class UserPermissionsToybox
{
    public bool ChangeToyState { get; set; }   // if the client pair can turn your toy on and off.
    public bool CanControlIntensity { get; set; }    // if the client pair can control the intensity of your toy.
    public bool VibratorAlarms { get; set; } // if the client pair can set alarms on your toy.
    public bool CanUseRealtimeVibeRemote { get; set; } // if the client pair can use the realtime vibe remote on your toy.
    public bool CanExecutePatterns { get; set; }      // if the client pair can use patterns on your toy.
    public bool CanExecuteTriggers { get; set; }      // if the client pair can use triggers on your toy.
    public bool CanCreateTriggers { get; set; }       // if the client pair can create triggers on your toy.
    public bool CanSendTriggers { get; set; }         // if the client pair can send triggers to your toy.
}