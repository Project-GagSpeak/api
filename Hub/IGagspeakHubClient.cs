using GagspeakAPI.Chat;
using GagspeakAPI.Connection;
using GagspeakAPI.Dto.VibeRoom;
using GagspeakAPI.Enums;
using GagspeakAPI.Network;
using GagspeakAPI.User;
using SundouleiaAPI.Reporting;

namespace GagspeakAPI.Hub;

/// <summary> All OnCallback actions. </summary>
public interface IGagspeakHubClient : IGagspeakHub
{
    #region Callbacks (Connection Responses)
    void OnServerMessage(Action<MessageSeverity, string> act);
    void OnHardReconnectMessage(Action<MessageSeverity, string, ServerState> act);
    void OnUserFlaggedForReport(Action<ReportKind, string> act);
    void OnReputationInfo(Action<UserReputation, string> act);
    void OnServerInfo(Action<ServerInfoResponse> act);
    #endregion

    #region Callbacks (Pairs/Requests)
    void OnAddPair(Action<KinksterPair> act);
    void OnRemovePair(Action<UserDto> act);
    void OnPersistPair(Action<UserDto> act);
    void OnAddPairRequest(Action<KinksterRequest> act);
    void OnRemovePairRequest(Action<KinksterRequest> act);
    void OnAddCollarRequest(Action<CollarRequest> act);
    void OnRemoveCollarRequest(Action<CollarRequest> act);
    #endregion

    #region Callbacks (Locis)
    void OnLociDataUpdated(Action<LociDataUpdate> act);
    void OnLociStatusesUpdate(Action<LociStatusesUpdate> act);
    void OnLociPresetsUpdate(Action<LociPresetsUpdate> act);
    void OnLociStatusModified(Action<LociStatusModified> act);
    void OnLociPresetModified(Action<LociPresetModified> act);
    void OnLociApplyDataById(Action<ApplyLociDataById> act);
    void OnLociApplyStatus(Action<ApplyLociStatus> act);
    void OnLociRemoveData(Action<RemoveLociData> act);
    void OnLociClearData(Action<UserDto> act);
    #endregion

    #region Callbacks (Permissions)
    void OnBulkChangeGlobal(Action<BulkChangeGlobal> act);
    void OnBulkChangeUnique(Action<BulkChangeUnique> act);
    void OnSingleChangeGlobal(Action<SingleChangeGlobal> act);
    void OnSingleChangeUnique(Action<SingleChangeUnique> act);
    void OnSingleChangeAccess(Action<SingleChangeAccess> act);
    void OnStateChangeHardcore(Action<HardcoreStateChange> act);
    #endregion

    #region Callbacks (Data Updates)
    void OnKinksterUpdateComposite(Action<KinksterUpdateComposite> act);
    void OnKinksterUpdateActiveGag(Action<KinksterUpdateActiveGag> act);
    void OnKinksterUpdateActiveRestriction(Action<KinksterUpdateActiveRestriction> act);
    void OnKinksterUpdateActiveRestraint(Action<KinksterUpdateActiveRestraint> act);
    void OnKinksterUpdateActiveCollar(Action<KinksterUpdateActiveCollar> act);
    void OnKinksterChangeEnabledItem(Action<KinksterChangeEnabledItem> act);
    void OnKinksterChangeEnabledGag(Action<KinksterChangeEnabledGag> act);
    void OnKinksterChangeEnabledToy(Action<KinksterChangeEnabledToy> act);
    void OnKinksterChangeEnabledItems(Action<KinksterChangeEnabledItems> act);
    void OnKinksterChangeEnabledGags(Action<KinksterChangeEnabledGags> act);
    void OnKinksterChangeEnabledToys(Action<KinksterChangeEnabledToys> act);
    void OnListenerName(Action<SendNameAction> act);
    void OnShockInstruction(Action<ShockCollarAction> act);
    void OnHypnoticEffect(Action<HypnoticAction> act);
    #endregion

    #region Callbacks (Light Storage Updates)
    void OnKinksterNewGagData(Action<KinksterNewGagData> act);
    void OnKinksterNewRestrictionData(Action<KinksterNewRestrictionData> act);
    void OnKinksterNewRestraintData(Action<KinksterNewRestraintData> act);
    void OnKinksterNewCollarData(Action<KinksterNewCollarData> act);
    void OnKinksterNewLootData(Action<KinksterNewLootData> act);
    void OnKinksterNewAliasData(Action<KinksterNewAliasData> act);
    void OnKinksterNewPatternData(Action<KinksterNewPatternData> act);
    void OnKinksterNewAlarmData(Action<KinksterNewAlarmData> act);
    void OnKinksterNewTriggerData(Action<KinksterNewTriggerData> act);
    #endregion

    #region Callbacks (UserState / Misc.)
    void OnKinksterOnline(Action<OnlineKinkster> act);
    void OnKinksterOffline(Action<UserDto> act);
    void OnUserVanityUpdated(Action<UserDto> act);
    void OnUserProfileUpdated(Action<UserDto> act);
    void OnShowVerification(Action<VerificationCode> act);
    void OnChatMessageReceived(Action<ChatlogMessage> act);
    #endregion

    #region VibeRooms
    void OnRoomJoin(Action<RoomParticipant> act);
    void OnRoomLeave(Action<UserData> act);
    void OnRoomAddInvite(Action<RoomInvite> act);
    void OnRoomHostChanged(Action<UserData> act);
    void OnRoomDeviceUpdate(Action<UserData, ToyInfo> act);
    void OnRoomIncDataStream(Action<ToyDataStreamResponse> act);
    void OnRoomAccessGranted(Action<UserData> act);
    void OnRoomAccessRevoked(Action<UserData> act);
    void OnRoomChatMessage(Action<UserData, string> act);
    #endregion
}
