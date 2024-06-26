namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class UserPermissionsPuppeteer
{
    public string TriggerPhrase { get; set; }    // the end char that is the right enclosing bracket character for commands.
    public char StartChar { get; set; }          // the start char that is the left enclosing bracket character for commands.
    public char EndChar { get; set; }            // the end char that is the right enclosing bracket character for commands.
    public bool AllowSitRequests { get; set; }   // if the client pair can request to sit on you.
    public bool AllowMotionRequests { get; set; } // if the client pair can request to move you.
    public bool AllowAllRequests { get; set; }   // if the client pair can request to do anything.
}