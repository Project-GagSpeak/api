using GagspeakAPI.Dto;
using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.IPC;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.Toybox;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Dto.UserPair;
using GagspeakAPI.Enums;

namespace GagspeakAPI.SignalR;

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
    void OnReceiveServerMessage(Action<MessageSeverity, string> act);
    void OnReceiveHardReconnectMessage(Action<MessageSeverity, string, ServerState> act);
    void OnUpdateSystemInfo(Action<SystemInfoDto> act);
    void OnUserAddClientPair(Action<UserPairDto> act);
    void OnUserRemoveClientPair(Action<UserDto> act);
    void OnUserAddPairRequest(Action<UserPairRequestDto> act);
    void OnUserRemovePairRequest(Action<UserPairRequestDto> act);
    
    void OnUpdateUserIndividualPairStatusDto(Action<UserIndividualPairStatusDto> act); // pair status update

    void OnUserApplyMoodlesByGuid(Action<ApplyMoodlesByGuidDto> act);
    void OnUserApplyMoodlesByStatus(Action<ApplyMoodlesByStatusDto> act);
    void OnUserRemoveMoodles(Action<RemoveMoodlesDto> act);
    void OnUserClearMoodles(Action<UserDto> act);

    void OnUserUpdateAllPerms(Action<UserPairUpdateAllPermsDto> act);
    void OnUserUpdateAllGlobalPerms(Action<UserPairUpdateAllGlobalPermsDto> act);
    void OnUserUpdateAllUniquePerms(Action<UserPairUpdateAllUniqueDto> act);
    void OnUserUpdatePairPermsGlobal(Action<UserGlobalPermChangeDto> act);
    void OnUserUpdatePairPerms(Action<UserPairPermChangeDto> act);
    void OnUserUpdatePairPermAccess(Action<UserPairAccessChangeDto> act);

    void OnUserReceiveDataComposite(Action<OnlineUserCompositeDataDto> act);
    void OnUserReceiveDataIpc(Action<OnlineUserIpcDataDto> act);
    void OnUserReceiveDataAppearance(Action<OnlineUserGagDataDto> act);
    void OnUserReceiveDataWardrobe(Action<OnlineUserRestraintDataDto> act);
    void OnUserReceiveDataOrders(Action<OnlineUserOrdersDataDto> act);
    void OnUserReceiveDataAlias(Action<OnlineUserAliasDataDto> act);
    void OnUserReceiveDataToybox(Action<OnlineUserToyboxDataDto> act);
    void OnUserReceiveLightStorage(Action<OnlineUserStorageUpdateDto> act);

    void OnUserReceiveShockInstruction(Action<ShockCollarActionDto> act);
    void OnGlobalChatMessage(Action<GlobalChatMessageDto> act);
    void OnUserSendOffline(Action<UserDto> act);
    void OnUserSendOnline(Action<OnlineUserIdentDto> act);
    void OnUserUpdateProfile(Action<UserDto> act);
    void OnDisplayVerificationPopup(Action<VerificationDto> act);
}
