using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto;
using Gagspeak.API.Dto.User;

namespace Gagspeak.API.SignalR;

/// <summary>
/// the interface for the GagspeakHubClient
/// <para>
/// Because this interface inherets from the IGagspeakHub,
/// it will have all the methods from the IGagspeakHub
/// </para>
/// </summary>
public interface IGagspeakHubClient : IGagspeakHub
{
    void OnReceiveServerMessage(Action<MessageSeverity, string> act);

    void OnUpdateSystemInfo(Action<SystemInfoDto> act);
}