using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Dto.Connection;
using GagSpeak.API.Dto.Permissions;
using GagSpeak.API.Dto.Toybox;
using GagSpeak.API.Dto.UserPair;

namespace Gagspeak.API.SignalR;

/// <summary>
/// 
/// The interface for the GagspeakHubClient
/// 
/// <para>
/// 
/// Because this interface inherits from the IGagspeakHub,
/// it will have all the methods from the IGagspeakHub
/// 
/// </para>
/// </summary>
public interface IGagspeakHubClient : IGagspeakHub
{
    // to view function purposes, be sure to inspect the IGagspeakHub interface class comments.
    void OnReceiveServerMessage(Action<MessageSeverity, string> act); // send message to client
    void OnUpdateSystemInfo(Action<SystemInfoDto> act); // update client with the system info
    void OnUserAddClientPair(Action<UserPairDto> act); // once a pair is bidirectional, send to the client the userpairDto as validation
    void OnUserRemoveClientPair(Action<UserDto> act); // if either end of a bidirectional pair removes one another, remove the pairing.
    void OnUpdateUserIndividualPairStatusDto(Action<UserIndividualPairStatusDto> act); // pair status update

    void OnUserUpdateSelfPairPermsGlobal(Action<UserGlobalPermChangeDto> act); // pair global permission
    void OnUserUpdateSelfPairPerms(Action<UserPairPermChangeDto> act); // pair permission update
    void OnUserUpdateSelfPairPermAccess(Action<UserPairAccessChangeDto> act); // pair permission access update
    void OnUserUpdateOtherAllPairPerms(Action<UserPairUpdateAllPermsDto> act); // pair permission all update
    void OnUserUpdateOtherPairPermsGlobal(Action<UserGlobalPermChangeDto> act); // pair permission global update
    void OnUserUpdateOtherPairPerms(Action<UserPairPermChangeDto> act); // pair permission update
    void OnUserUpdateOtherPairPermAccess(Action<UserPairAccessChangeDto> act); // pair permission access update

    void OnUserReceiveCharacterDataComposite(Action<OnlineUserCharaCompositeDataDto> act); // send to a client that one of their paired users has updated their character data (composite)
    void OnUserReceiveCharacterDataIpc(Action<OnlineUserCharaIpcDataDto> act); // send to a client that one of their paired users has updated their character data (ipc)
    void OnUserReceiveCharacterDataAppearance(Action<OnlineUserCharaAppearanceDataDto> act); // send to a client that one of their paired users has updated their character data (appearance)
    void OnUserReceiveCharacterDataWardrobe(Action<OnlineUserCharaWardrobeDataDto> act); // send to a client that one of their paired users has updated their character data (wardrobe)
    void OnUserReceiveCharacterDataAlias(Action<OnlineUserCharaAliasDataDto> act); // send to a client that one of their paired users has updated their character data (alias)
    void OnUserReceiveCharacterDataPattern(Action<OnlineUserCharaPatternDataDto> act); // send to a client that one of their paired users has updated their character data (pattern)

    void OnUserSendOffline(Action<UserDto> act); // send to a client that one of their paired users is offline
    void OnUserSendOnline(Action<OnlineUserIdentDto> act); // send to a client that one of their paired users is online
    void OnUserUpdateProfile(Action<UserDto> act); // send to a client that one of their paired users has updated their profile
    void OnDisplayVerificationPopup(Action<VerificationDto> act); // send to a client to display a verification popup
}
