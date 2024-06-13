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
     const int ApiVersion = 1;               // First version of the API
     const string Path  = "/gagspeak";       // Path to the API on the hosted server

     Task<bool> CheckClientHealth();         // Check if the client is healthy

     /* ----------------- Task methods called upon by server and sent to clients ----------------- */
     Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message); // send message to client
     Task Client_UpdateSystemInfo(SystemInfoDto systemInfo); // update client with the system info
     Task Client_UserAddClientPair(UserPairDto dto); // once a pair is bidirectional, send to the client the userpairDto as validation
     Task Client_UserRemoveClientPair(UserDto dto); // if either end of a bidirectional pair removes one another, remove the pairing.
     Task Client_UserSendOffline(UserDto dto); // send to a client that one of their paired users is offline
     Task Client_UserSendOnline(OnlineUserIdentDto dto); // send to a client that one of their paired users is online
     // there was a update pair permissions here, maybe repurpose it for a update to userdata permissions later?
     Task Client_UserUpdateProfile(UserDto dto); // send to a client that one of their paired users has updated their profile


     /* ----------------- Task for grabbing a users current connectionDto ----------------- */
     Task<ConnectionDto> GetConnectionDto(); // Get the connection details of the client to the server


     /* ----------------- Task methods called upon by clients and sent to the server ----------------- */
     Task UserAddPair(UserDto user); // add another user as a pair to the users paired list
     Task UserDelete(); // delete this users account from the servers database
     Task<List<OnlineUserIdentDto>> UserGetOnlinePairs(); // get the current online users paired with this client
     Task<List<UserPairDto>> UserGetPairedClients(); // get the current paired users of this client
     Task<UserProfileDto> UserGetProfile(UserDto dto); // get the profile of another user (could be self too?)
     Task UserPushData(UserCharaDataMessageDto dto); // push clients character data to the server
     Task UserRemovePair(UserDto userDto); // remove a user from the paired list of the client
     Task UserSetProfile(UserProfileDto userMiniProfile); // set the profile of the client
}