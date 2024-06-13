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
     void OnReceiveServerMessage(Action<MessageSeverity, string> act); // send message to client
     void OnUpdateSystemInfo(Action<SystemInfoDto> act); // update client with the system info
     void OnUserAddClientPair(Action<UserPairDto> act); // once a pair is bidirectional, send to the client the userpairDto as validation
     void OnUserRemoveClientPair(Action<UserDto> act); // if either end of a bidirectional pair removes one another, remove the pairing.
     void OnUpdateUserIndividualPairStatusDto(Action<UserIndividualPairStatusDto> act); // updates user with a pair status dto they have w/ another user
     void OnUserReceiveCharacterData(Action<OnlineUserCharaDataDto> act); // send to a client that one of their paired users has updated their character data (i think?)
     void OnUserSendOffline(Action<UserDto> act); // send to a client that one of their paired users is offline
     void OnUserSendOnline(Action<OnlineUserIdentDto> act); // send to a client that one of their paired users is online
     // there was a update pair permissions here, maybe repurpose it for a update to userdata permissions later?
     void OnUserUpdateProfile(Action<UserDto> act); // send to a client that one of their paired users has updated their profile
}