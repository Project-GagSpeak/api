namespace GagspeakAPI.Hub;

public static class HubResponseBuilder
{
    // Success.
    public static HubResponse Yippee() => new(GagSpeakApiEc.Success);
    public static HubResponse<T> Yippee<T>(T value) => new(GagSpeakApiEc.Success) { Value = value };
    
    // Fail.
    public static HubResponse AwDangIt(GagSpeakApiEc error) => new(error);
    public static HubResponse<T> AwDangIt<T>(GagSpeakApiEc error) => new(error) { Value = default };
    public static HubResponse<T> AwDangIt<T>(GagSpeakApiEc error, T value) => new(error) { Value = value };
}
