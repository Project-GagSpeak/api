using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto;
using Gagspeak.API.Dto.User;

namespace Gagspeak.API.SignalR;

/// <summary>
/// the interface for the GagspeakHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 1; // First version of the API
    const string Path  = "/gagspeak"; // Path to the API on the hosted server

    Task<bool> CheckClientHealth(); // Check if the client is healthy
    Task<ConnectionDto> GetConnectionDto(); // Get the connection details of the client to the server


    // some client actions send to the server
    Task Client_RecieveServerMessage(MessageSeverity messageSeverity, string message); // Recieve a message from the server
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo); // Update the system information of the client
    // Task Client_User_AddClientPair(UserPairDto dto); // Add a sucessful whitelist pairing to the user's client list



    // some user impacted actions
    //Task UserAddWhitelistedPlayer(UserDto user); // Add a player to the user's whitelist.
    //Task UserRemoveWhitelistedPlayer(UserDto user); // Remove a player from the user's whitelist.
    //Task UserDelete(); // Delete the user's account.
    //Task<UserProfileDto> UserGetProfile(UserDto user); // Get the profile of a user by their userDto.
    //Task UserSetProfile(UserProfileDto userProfile); // Set or update the user's profile.
}