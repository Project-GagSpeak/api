using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Dto.Connection;
using GagSpeak.API.Dto.Permissions;
using GagSpeak.API.Dto.UserPair;

namespace Gagspeak.API.SignalR;

/// <summary> The interface for the GagspeakHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 1;               // First version of the API
    const string Path = "/gagspeak";       // Path to the API on the hosted server

    Task<bool> CheckClientHealth();         // Check if the client is healthy

    /* ----------------- Task methods called upon by server and sent to clients ----------------- */


    // is used by the server to send a message to the respective client based on client caller context.
    // Often for notifications but can also be used to inform a user about a task or send a global warning.
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message);


    // updates a client with the servers current system information
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo);


    // sends a message to the client requesting them to add a userPair to their pair manager list.
    Task Client_UserAddClientPair(UserPairDto dto);


    // sent whenever a player should be removed from a clients pair manager. (Account deletion or they removed this client from their list)
    Task Client_UserRemoveClientPair(UserDto dto);


    // let's the client receive the updated state of another paired user's indidivual pair status.
    Task Client_UpdateUserIndividualPairStatusDto(UserIndividualPairStatusDto dto);


    // is sent to a client who should be informed of another paired user's login, along with their latest character data.
    Task Client_UserReceiveCharacterData(OnlineUserCharaDataDto dataDto);


    // is sent to a client who should be informed of another paired user's logout.
    Task Client_UserSendOffline(UserDto dto); 


    // Informs a client that one of their added pairs has gone online and is now connected to the server.
    // Contains information UserData and Identification. no CharacterData
    Task Client_UserSendOnline(OnlineUserIdentDto dto);


    // Informs a client whenever another paired user's profile has been updated.
    Task Client_UserUpdateProfile(UserDto dto);


    // The popup that is sent to the respective client for a verification code display once they accept the prompt from the discord bot.
    Task Client_DisplayVerificationPopup(VerificationDto dto);


    /* ----------------- Task for grabbing a users current connectionDto ----------------- */
    Task<ConnectionDto> GetConnectionDto(); // Get the connection details of the client to the server


    /* ----------------- Task methods called upon by clients and sent to the server ----------------- */
    Task UserAddPair(UserDto user); // add another user as a pair to the users paired list
    Task UserDelete(); // delete this users account from the servers database
    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs(); // get the current online users paired with this client
    Task<List<UserPairDto>> UserGetPairedClients(); // get the current paired users of this client
    Task<UserProfileDto> UserGetProfile(UserDto dto); // get the profile of another user (could be self too?)
    Task UserPushData(UserCharaCompositeDataMessageDto dto); // push clients character data to the server
    Task UserRemovePair(UserDto userDto); // remove a user from the paired list of the client
    Task UserSetProfile(UserProfileDto userMiniProfile); // set the profile of the client
}
