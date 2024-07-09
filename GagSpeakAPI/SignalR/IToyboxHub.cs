using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Dto.Connection;
using GagSpeak.API.Dto.Permissions;
using GagSpeak.API.Dto.Toybox;
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

    Task<ToyboxConnectionDto> GetToyboxConnectionDto(); // Get the connection details of the client to the serve
    /************ CALLBACKS ***************/
    Task Client_ReceiveToyboxServerMessage(MessageSeverity messageSeverity, string message);

    // method to update a clients vibrator intensity.
    Task Client_UpdateIntensity(UpdateIntensityDto dto);

    /************** CALLERS **********/
    Task UpdateIntensity(UpdateIntensityDto dto); // updates intensity to UID's in DTO. Sent real-time updates


    // feature creep ideas:
    // - Making use of the paths hub context, groups can be created as "rooms" that people can make for controlling groups of people.
    // - These rooms can be named by identifications that users define to create a room. Any room with no users in it will be deleted, or when no activity in them has elapsed.
    // - Rooms can optionally be publicly visible, allowing people to enter them as sort of "kink rooms" for people to browse.
    // - In the future, a chat space could potentially be added as things expand, allowing for more social interaction between users.
}
