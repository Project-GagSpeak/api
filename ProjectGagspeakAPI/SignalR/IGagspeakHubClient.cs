using GagspeakAPI.Data;
using GagspeakAPI.Dto;
using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.IPC;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Dto.UserPair;
using GagspeakAPI.Dto.VibeRoom;
using GagspeakAPI.Enums;

namespace GagspeakAPI.SignalR;

/// <summary> All OnCallback actions. </summary>
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

    void OnUserApplyMoodlesByGuid(Action<ApplyMoodlesByGuidDto> act);
    void OnUserApplyMoodlesByStatus(Action<ApplyMoodlesByStatusDto> act);
    void OnUserRemoveMoodles(Action<RemoveMoodlesDto> act);
    void OnUserClearMoodles(Action<UserDto> act);

    void OnUserUpdateAllPerms(Action<BulkUpdatePermsAllDto> act);
    void OnUserUpdateAllGlobalPerms(Action<BulkUpdatePermsGlobalDto> act);
    void OnUserUpdateAllUniquePerms(Action<BulkUpdatePermsUniqueDto> act);
    void OnUserUpdatePairPermsGlobal(Action<UserGlobalPermChangeDto> act);
    void OnUserUpdatePairPerms(Action<UserPairPermChangeDto> act);
    void OnUserUpdatePairPermAccess(Action<UserPairAccessChangeDto> act);

    void OnUserReceiveDataComposite(Action<OnlineUserCompositeDataDto> act);
    void OnUserReceiveDataIpc(Action<CallbackIpcDataDto> act);
    void OnUserReceiveDataGags(Action<CallbackGagDataDto> act);
    void OnUserReceiveDataRestrictions(Action<CallbackRestrictionDataDto> act);
    void OnUserReceiveDataRestraint(Action<CallbackRestraintDataDto> act);
    void OnUserReceiveDataCursedLoot(Action<CallbackCursedLootDto> act);
    void OnUserReceiveDataOrders(Action<CallbackOrdersDataDto> act);
    void OnUserReceiveDataAlias(Action<CallbackAliasDataDto> act);
    void OnUserReceiveDataToybox(Action<CallbackToyboxDataDto> act);
    void OnUserReceiveLightStorage(Action<CallbackLightStorageDto> act);

    void OnUserReceiveShockInstruction(Action<ShockCollarActionDto> act);

    void OnRoomJoin(Action<VibeRoomKinksterFullDto> act);
    void OnRoomLeave(Action<VibeRoomKinksterFullDto> act);
    void OnRoomReceiveDeviceUpdate(Action<UserData, DeviceInfo> act);
    void OnRoomReceiveDataStream(Action<SexToyDataStreamCallbackDto> act);
    void OnRoomUserAccessGranted(Action<UserData> act);
    void OnRoomUserAccessRevoked(Action<UserData> act);
    void OnRoomReceiveChatMessage(Action<UserData, string> act);

    void OnGlobalChatMessage(Action<GlobalChatMessageDto> act);
    void OnUserSendOffline(Action<UserDto> act);
    void OnUserSendOnline(Action<OnlineUserIdentDto> act);
    void OnUserUpdateProfile(Action<UserDto> act);
    void OnDisplayVerificationPopup(Action<VerificationDto> act);
}
