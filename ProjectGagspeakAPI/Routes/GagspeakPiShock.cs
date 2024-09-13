namespace GagspeakAPI.Routes;

public class GagspeakPiShock
{
    public const string BaseUri = "https://do.pishock.com/api";
    public const string PiShock_GetInfo = "/GetShockerInfo"; 
    public const string PiShock_Execute = "/apioperate";
    public static Uri GetInfoPath() => new Uri(new Uri(BaseUri), PiShock_GetInfo);
    public static Uri ExecuteOperationPath() => new Uri(new Uri(BaseUri), PiShock_Execute);
}
