using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Dto.Connection;
using GagSpeak.API.Dto.Permissions;
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
    void OnUserUpdateSelfPairPermsComposite(Action<UserPairPermissionsDto> act); // pair permission composite update
    void OnUserUpdateSelfPairPermsGlobal(Action<UserGlobalPermissionsDto> act); // pair permission global update
    void OnUserUpdateSelfPairPermsGeneral(Action<UserPermissionsGeneralDto> act); // pair permission general update
    void OnUserUpdateSelfPairPermsWardrobe(Action<UserPermissionsWardrobeDto> act); // pair permission wardrobe update
    void OnUserUpdateSelfPairPermsPuppeteer(Action<UserPermissionsPuppeteerDto> act); // pair permission puppeteer update
    void OnUserUpdateSelfPairPermsMoodles(Action<UserPermissionsMoodlesDto> act); // pair permission moodles update
    void OnUserUpdateSelfPairPermsToybox(Action<UserPermissionsToyboxDto> act); // pair permission toybox update
    void OnUserUpdateSelfPairPermsHardcore(Action<UserPermissionsHardcoreDto> act); // pair permission hardcore update
    void OnUserUpdateOtherPairPermsComposite(Action<UserPairPermissionsDto> act); // pair permission composite update
    void OnUserUpdateOtherPairPermsGlobal(Action<UserGlobalPermissionsDto> act); // pair permission global update
    void OnUserUpdateOtherPairPermsGeneral(Action<UserPermissionsGeneralDto> act); // pair permission general update
    void OnUserUpdateOtherPairPermsWardrobe(Action<UserPermissionsWardrobeDto> act); // pair permission wardrobe update
    void OnUserUpdateOtherPairPermsPuppeteer(Action<UserPermissionsPuppeteerDto> act); // pair permission puppeteer update
    void OnUserUpdateOtherPairPermsMoodles(Action<UserPermissionsMoodlesDto> act); // pair permission moodles update
    void OnUserUpdateOtherPairPermsToybox(Action<UserPermissionsToyboxDto> act); // pair permission toybox update
    void OnUserUpdateOtherPairPermsHardcore(Action<UserPermissionsHardcoreDto> act); // pair permission hardcore update
    void OnUserReceiveCharacterData(Action<OnlineUserCharaCompositeDataDto> act); // send to a client that one of their paired users has updated their character data (i think?)
    void OnUserSendOffline(Action<UserDto> act); // send to a client that one of their paired users is offline
    void OnUserSendOnline(Action<OnlineUserIdentDto> act); // send to a client that one of their paired users is online
    void OnUserUpdateProfile(Action<UserDto> act); // send to a client that one of their paired users has updated their profile
    void OnDisplayVerificationPopup(Action<VerificationDto> act); // send to a client to display a verification popup
}
