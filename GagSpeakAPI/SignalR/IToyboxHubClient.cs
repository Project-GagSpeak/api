using Gagspeak.API.Data.Enum;
using GagSpeak.API.Dto.Connection;

namespace Gagspeak.API.SignalR;

/// <summary> The interface for the ToyboxHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IToyboxHubClient : IToyboxHub
{
    void OnReceiveToyboxServerMessage(Action<MessageSeverity, string> act); // send message to client
    void OnUpdateIntensity(Action<SystemInfoDto> act); // update client with the system info
}
