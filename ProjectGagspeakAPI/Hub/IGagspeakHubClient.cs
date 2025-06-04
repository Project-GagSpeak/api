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
    void OnSingleChangeUnique(Action<SingleChangeUnique> act);
    void OnSingleChangeAccess(Action<SingleChangeAccess> act);

    // Own or pair data updates
    void OnKinksterUpdateComposite(Action<KinksterUpdateComposite> act);
    void OnKinksterUpdateIpc(Action<KinksterUpdateIpc> act);
    void OnKinksterUpdateGagSlot(Action<KinksterUpdateGagSlot> act);
    void OnKinksterUpdateRestriction(Action<KinksterUpdateRestriction> act);
    void OnKinksterUpdateRestraint(Action<KinksterUpdateRestraint> act);
    void OnKinksterUpdateCursedLoot(Action<KinksterUpdateCursedLoot> act);
    void OnKinksterUpdateAliasGlobal(Action<KinksterUpdateAliasGlobal> act);
    void OnKinksterUpdateAliasUnique(Action<KinksterUpdateAliasUnique> act);
    void OnKinksterUpdateToybox(Action<KinksterUpdateToybox> act);
    void OnKinksterUpdateLightStorage(Action<KinksterUpdateLightStorage> act);
    void OnListenerName(Action<UserData, string> act);
    void OnShockInstruction(Action<ShockCollarAction> act);

    // Chat and status
    void OnChatMessageGlobal(Action<ChatMessageGlobal> act);
    void OnKinksterOffline(Action<KinksterBase> act);
    void OnKinksterOnline(Action<OnlineKinkster> act);
    void OnProfileUpdated(Action<KinksterBase> act);
    void OnShowVerification(Action<VerificationCode> act);

    // Room events
    void OnRoomJoin(Action<RoomParticipant> act);
    void OnRoomLeave(Action<RoomParticipant> act);
    void OnRoomDeviceUpdate(Action<UserData, ToyInfo> act);
    void OnRoomIncDataStream(Action<ToyDataStreamResponse> act);
    void OnRoomAccessGranted(Action<UserData> act);
    void OnRoomAccessRevoked(Action<UserData> act);
    void OnRoomChatMessage(Action<UserData, string> act);
}
