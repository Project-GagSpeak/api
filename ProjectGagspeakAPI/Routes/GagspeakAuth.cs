namespace Gagspeak.API.Routes;

// no purpose yet but likely will later???
public class GagspeakVibe
{
    public const string Vibe = "/vibe"; // the authentication path.
    public const string Vibe_CreateConnection = "createVibeConnection"; // establish a socket connection ???? very WIP
    public static Uri VibeFullPath(Uri baseUri) => new Uri(baseUri, Vibe + "/" + Vibe_CreateConnection);
}
