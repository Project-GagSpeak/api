namespace GagspeakAPI.Hub;

/// <summary> Generic Return Codes for API calls. </summary>
/// <remarks> Value can be null or nonexistant. </remarks>
public record HubResponse(GagSpeakApiEc ErrorCode);


/// <summary> Generic Return Codes for API calls. </summary>
/// <remarks> Value can be null or nonexistant. </remarks>
public record HubResponse<T>(GagSpeakApiEc ErrorCode) : HubResponse(ErrorCode)
{
    public T? Value { get; set; }
}
