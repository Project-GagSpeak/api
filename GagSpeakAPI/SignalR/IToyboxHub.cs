using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Dto.Connection;
using GagSpeak.API.Dto.Permissions;
using GagSpeak.API.Dto.UserPair;

namespace Gagspeak.API.SignalR;

/// <summary> The interface for the ToyboxHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IToyboxHub
{
    const string Path = "/toybox";       // Path to the API on the hosted server

    Task<ToyboxConnectionDto> GetConnectionDto(); // Get the connection details of the client to the serve
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message);

    // method to update a clients vibrator intensity.
    Task Client_UpdateIntensity(UserDto user, byte intensity);

}