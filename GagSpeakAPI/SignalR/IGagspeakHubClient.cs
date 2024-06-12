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
     void Client_ReceiveServerMessage(Action<MessageSeverity, string> act); // send message to client
     void Client_UpdateSystemInfo(Action<SystemInfoDto> act); // update client with the system info
     void Client_UserAddClientPair(Action<UserPairDto> act); // once a pair is bidirectional, send to the client the userpairDto as validation
     void Client_UserRemoveClientPair(Action<UserDto> act); // if either end of a bidirectional pair removes one another, remove the pairing.
     void Client_UserSendOffline(Action<UserDto> act); // send to a client that one of their paired users is offline
     void Client_UserSendOnline(Action<OnlineUserIdentDto> act); // send to a client that one of their paired users is online
     // there was a update pair permissions here, maybe repurpose it for a update to userdata permissions later?
     void Client_UserUpdateProfile(Action<UserDto> act); // send to a client that one of their paired users has updated their profile
}