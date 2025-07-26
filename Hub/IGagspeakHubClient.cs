using GagspeakAPI.Data;
using GagspeakAPI.Dto.VibeRoom;
using GagspeakAPI.Enums;
using GagspeakAPI.Network;

namespace GagspeakAPI.Hub;

/// <summary> All OnCallback actions. </summary>
public interface IGagspeakHubClient : IGagspeakHub
{
    // General server messages
    void OnServerMessage(Action<MessageSeverity, string> act);
    void OnHardReconnectMessage(Action<MessageSeverity, string, ServerState> act);
    void OnServerInfo(Action<ServerInfoResponse> act);

    // Pairing and requests
    void OnAddClientPair(Action<KinksterPair> act);
    void OnRemoveClientPair(Action<KinksterBase> act);
    void OnAddPairRequest(Action<KinksterRequestEntry> act);
    void OnRemovePairRequest(Action<KinksterRequestEntry> act);

    // Moodle updates
    void OnApplyMoodlesByGuid(Action<MoodlesApplierById> act);
    void OnApplyMoodlesByStatus(Action<MoodlesApplierByStatus> act);
    void OnRemoveMoodles(Action<MoodlesRemoval> act);
    void OnClearMoodles(Action<KinksterBase> act);

    // Permission updates
    void OnBulkChangeAll(Action<BulkChangeAll> act);
    void OnBulkChangeGlobal(Action<BulkChangeGlobal> act);
    void OnBulkChangeUnique(Action<BulkChangeUnique> act);
    void OnSingleChangeGlobal(Action<SingleChangeGlobal> act);
    void OnDoubleChangeGlobal(Action<DoubleChangeGlobal> act);
    void OnSingleChangeUnique(Action<SingleChangeUnique> act);
    void OnSingleChangeAccess(Action<SingleChangeAccess> act);

    // Own or pair data updates
    void OnKinksterUpdateComposite(Action<KinksterUpdateComposite> act);
    void OnKinksterUpdateIpc(Action<KinksterUpdateIpc> act);
    void OnKinksterUpdateActiveGag(Action<KinksterUpdateActiveGag> act);
    void OnKinksterUpdateActiveRestriction(Action<KinksterUpdateActiveRestriction> act);
    void OnKinksterUpdateActiveRestraint(Action<KinksterUpdateActiveRestraint> act);
    void OnKinksterUpdateActiveCursedLoot(Action<KinksterUpdateActiveCursedLoot> act);
    void OnKinksterUpdateAliasGlobal(Action<KinksterUpdateAliasGlobal> act);
    void OnKinksterUpdateAliasUnique(Action<KinksterUpdateAliasUnique> act);
    void OnKinksterUpdateActivePattern(Action<KinksterUpdateActivePattern> act);
    void OnKinksterUpdateActiveAlarms(Action<KinksterUpdateActiveAlarms> act);
    void OnKinksterUpdateActiveTriggers(Action<KinksterUpdateActiveTriggers> act);
    void OnListenerName(Action<UserData, string> act);
    void OnShockInstruction(Action<ShockCollarAction> act);
    void OnHypnoticEffect(Action<HypnoticAction> act);
    void OnConfineToAddress(Action<ConfineByAddress> act);
    void OnImprisonAtPosition(Action<ImprisonAtPosition> act);

    // Kinkster updates
    void OnKinksterNewGagData(Action<KinksterNewGagData> act);
    void OnKinksterNewRestrictionData(Action<KinksterNewRestrictionData> act);
    void OnKinksterNewRestraintData(Action<KinksterNewRestraintData> act);
    void OnKinksterNewLootData(Action<KinksterNewLootData> act);
    void OnKinksterNewPatternData(Action<KinksterNewPatternData> act);
    void OnKinksterNewAlarmData(Action<KinksterNewAlarmData> act);
    void OnKinksterNewTriggerData(Action<KinksterNewTriggerData> act);
    void OnKinksterNewAllowances(Action<KinksterNewAllowances> act);

    // Chat and status
    void OnChatMessageGlobal(Action<ChatMessageGlobal> act);
    void OnKinksterOffline(Action<KinksterBase> act);
    void OnKinksterOnline(Action<OnlineKinkster> act);
    void OnProfileUpdated(Action<KinksterBase> act);
    void OnShowVerification(Action<VerificationCode> act);

    // Room events
    void OnRoomJoin(Action<RoomParticipant> act);
    void OnRoomLeave(Action<UserData> act);
    void OnRoomAddInvite(Action<RoomInvite> act);
    void OnRoomHostChanged(Action<UserData> act);
    void OnRoomDeviceUpdate(Action<UserData, ToyInfo> act);
    void OnRoomIncDataStream(Action<ToyDataStreamResponse> act);
    void OnRoomAccessGranted(Action<UserData> act);
    void OnRoomAccessRevoked(Action<UserData> act);
    void OnRoomChatMessage(Action<UserData, string> act);
}
