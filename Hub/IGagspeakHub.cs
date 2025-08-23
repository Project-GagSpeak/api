using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Dto.Sharehub;
using GagspeakAPI.Dto.VibeRoom;
using GagspeakAPI.Enums;
using GagspeakAPI.Network;

namespace GagspeakAPI.Hub;

/// <summary> 
/// The interface for the GagspeakHub
/// <para> This interface is the server end of the SignalR calls made by the client. </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 15;
    const string Path = "/gagspeak";

    Task<bool> CheckMainClientHealth();
    Task<ConnectionResponse> GetConnectionResponse();
    Task<LobbyAndHubInfoResponse> GetShareHubAndLobbyInfo();

    #region Callbacks
    Task Callback_ServerMessage(MessageSeverity messageSeverity, string message);
    Task Callback_HardReconnectMessage(MessageSeverity messageSeverity, string message, ServerState state);
    Task Callback_ServerInfo(ServerInfoResponse info);

    // sends to a connected user to add the specified user to their pair list
    Task Callback_AddClientPair(KinksterPair dto);
    Task Callback_RemoveClientPair(KinksterBase dto);
    Task Callback_AddPairRequest(KinksterPairRequest dto);
    Task Callback_RemovePairRequest(KinksterPairRequest dto);
    Task Callback_AddCollarRequest(CollarOwnershipRequest dto);
    Task Callback_RemoveCollarRequest(CollarOwnershipRequest dto);

    // ---- Callbacks to update IPC.
    Task Callback_SetKinksterIpcData(KinksterIpcData dto);
    Task Callback_SetKinksterIpcLight(KinksterIpcDataLight dto);
    Task Callback_SetKinksterIpcManipulations(KinksterIpcManipulations dto);
    Task Callback_SetKinksterIpcGlamourer(KinksterIpcGlamourer dto);
    Task Callback_SetKinksterMoodlesFull(KinksterMoodlesDataFull dto);
    Task Callback_SetKinksterMoodlesSM(KinksterMoodlesSM dto);
    Task Callback_SetKinksterMoodlesStatuses(KinksterMoodlesStatuses dto);
    Task Callback_SetKinksterMoodlesPresets(KinksterMoodlesPresets dto);
    Task Callback_ApplyMoodlesByGuid(MoodlesApplierById dto);
    Task Callback_ApplyMoodlesByStatus(MoodlesApplierByStatus dto);
    Task Callback_RemoveMoodles(MoodlesRemoval dto);
    Task Callback_ClearMoodles(KinksterBase dto);

    // ---- Callbacks to update permissions.
    Task Callback_BulkChangeGlobal(BulkChangeGlobal dto);
    Task Callback_BulkChangeUnique(BulkChangeUnique dto);
    Task Callback_SingleChangeGlobal(SingleChangeGlobal dto);
    Task Callback_SingleChangeUnique(SingleChangeUnique dto);
    Task Callback_SingleChangeAccess(SingleChangeAccess dto);
    Task Callback_StateChangeHardcore(HardcoreStateChange dto); // reject if for hypnosis, too much data for DB.

    // ---- Callbacks for Kinkster Active State updates.
    Task Callback_KinksterUpdateComposite(KinksterUpdateComposite dto);
    Task Callback_KinksterUpdateActiveGag(KinksterUpdateActiveGag dto);
    Task Callback_KinksterUpdateActiveRestriction(KinksterUpdateActiveRestriction dto);
    Task Callback_KinksterUpdateActiveRestraint(KinksterUpdateActiveRestraint dto);
    Task Callback_KinksterUpdateActiveCollar(KinksterUpdateActiveCollar dto);
    Task Callback_KinksterUpdateActiveCursedLoot(KinksterUpdateActiveCursedLoot dto);
    Task Callback_KinksterUpdateAliasGlobal(KinksterUpdateAliasGlobal dto);
    Task Callback_KinksterUpdateAliasUnique(KinksterUpdateAliasUnique dto);
    Task Callback_KinksterUpdateValidToys(KinksterUpdateValidToys dto);
    Task Callback_KinksterUpdateActivePattern(KinksterUpdateActivePattern dto);
    Task Callback_KinksterUpdateActiveAlarms(KinksterUpdateActiveAlarms dto);
    Task Callback_KinksterUpdateActiveTriggers(KinksterUpdateActiveTriggers dto);
    Task Callback_ListenerName(UserData user, string name);
    Task Callback_ShockInstruction(ShockCollarAction dto);
    Task Callback_HypnoticEffect(HypnoticAction dto); // hcState update for hypnosis, be sure to update HcState as well.


    // ---- Callbacks for Kinkster Light Storage Updates.
    Task Callback_KinksterNewGagData(KinksterNewGagData dto);
    Task Callback_KinksterNewRestrictionData(KinksterNewRestrictionData dto);
    Task Callback_KinksterNewRestraintData(KinksterNewRestraintData dto);
    Task Callback_KinksterNewCollarData(KinksterNewCollarData dto);
    Task Callback_KinksterNewLootData(KinksterNewLootData dto);
    Task Callback_KinksterNewPatternData(KinksterNewPatternData dto);
    Task Callback_KinksterNewAlarmData(KinksterNewAlarmData dto);
    Task Callback_KinksterNewTriggerData(KinksterNewTriggerData dto);
    Task Callback_KinksterNewAllowances(KinksterNewAllowances dto);

    // Generics
    Task Callback_ChatMessageGlobal(ChatMessageGlobal dto);
    Task Callback_KinksterOffline(KinksterBase dto);
    Task Callback_KinksterOnline(OnlineKinkster dto);
    Task Callback_ProfileUpdated(KinksterBase dto);
    Task Callback_ShowVerification(VerificationCode dto);

    // ---- Callbacks for Vibe Rooms
    Task Callback_RoomJoin(RoomParticipant dto);
    Task Callback_RoomLeave(UserData user);
    Task Callback_RoomAddInvite(RoomInvite dto);
    Task Callback_RoomHostChanged(UserData newHost);
    Task Callback_RoomDeviceUpdate(UserData user, ToyInfo ToyInfo);
    Task Callback_RoomIncDataStream(ToyDataStreamResponse dataStream);
    Task Callback_RoomAccessGranted(UserData user);
    Task Callback_RoomAccessRevoked(UserData user);
    Task Callback_RoomChatMessage(UserData user, string message);
    #endregion Callbacks

    // ----- Retrievals ------
    /// <summary> Requested upon login, asking for the current Kinkster pairs online. </summary>
    Task<List<OnlineKinkster>> UserGetOnlinePairs();
    /// <summary> Requests a list of UserPair DTO's containing the client pairs  of the client caller </summary>
    Task<List<KinksterPair>> UserGetPairedClients();

    /// <summary> Requests the list of all current Kinkster Requests active for the caller. </summary>
    Task<ActiveRequests> UserGetActiveRequests();

    /// <summary> Called by a connected client who wishes to retrieve the profile of another user. </summary>
    Task<KinkPlateFull> UserGetKinkPlate(KinksterBase dto);

    // ------ ShareHubs ------
    /// <summary> Uploads your pattern to the server. </summary>
    Task<HubResponse> UploadPattern(PatternUpload dto);
    /// <summary> Uploads your a new Moodle to the server. </summary>
    Task<HubResponse> UploadMoodle(MoodleUpload dto);
    /// <summary> Downloads a pattern from the server. </summary>
    Task<HubResponse<string>> DownloadPattern(Guid patternId);
    /// <summary> Likes a pattern you see on the server. AddingLike==true means we liked it, false means we un-liked it. </summary>
    Task<HubResponse> LikePattern(Guid patternId);
    /// <summary> Likes a Moodle you see on the server. AddingLike==true means we liked it, false means we un-liked it. </summary>
    Task<HubResponse> LikeMoodle(Guid moodleId);
    /// <summary> Deletes a pattern from the server. </summary>
    Task<HubResponse> RemovePattern(Guid patternId);
    /// <summary> Deletes a moodle from the server. </summary>
    Task<HubResponse> RemoveMoodle(Guid moodleId);
    /// <summary> Grabs the search result of your specified query to the server. </summary>
    Task<HubResponse<List<ServerPatternInfo>>> SearchPatterns(PatternSearch dto);
    /// <summary> Grabs the search result of your specified query to the server. </summary>
    Task<HubResponse<List<ServerMoodleInfo>>> SearchMoodles(SearchBase dto);

    // ----- Client Vanity ------
    /// <summary> Sends a message to the gagspeak Global chat. </summary>
    Task<HubResponse> UserSendGlobalChat(ChatMessageGlobal dto);
    Task<HubResponse> UserUpdateAchievementData(AchievementsUpdate dto);
    Task<HubResponse> UserSetKinkPlateContent(KinkPlateInfo dto); // set profile content of own kinkplate.
    Task<HubResponse> UserSetKinkPlatePicture(KinkPlateImage dto); // set profile picture of own kinkplate.
    Task<HubResponse> UserReportKinkPlate(KinkPlateReport KinksterBase); // hopefully this is never used x-x...

    // ----- Personal Interactions ------
    Task<HubResponse> UserPushIpcData(PushIpcFull dto);
    Task<HubResponse> UserPushIpcDataLight(PushIpcLight dto);
    Task<HubResponse> UserPushIpcModManips(PushIpcModManips dto);
    Task<HubResponse> UserPushIpcGlamourer(PushIpcGlamourer dto);
    Task<HubResponse> UserPushMoodlesFull(PushMoodlesFull dto);
    Task<HubResponse> UserPushMoodlesSM(PushMoodlesSM dto);
    Task<HubResponse> UserPushMoodlesStatuses(PushMoodlesStatuses dto);
    Task<HubResponse> UserPushMoodlesPresets(PushMoodlesPresets dto);

    Task<HubResponse> UserPushActiveData(PushClientCompositeUpdate dto);
    Task<HubResponse<ActiveGagSlot>> UserPushActiveGags(PushClientActiveGagSlot dto);
    Task<HubResponse<ActiveRestriction>> UserPushActiveRestrictions(PushClientActiveRestriction dto);
    Task<HubResponse<CharaActiveRestraint>> UserPushActiveRestraint(PushClientActiveRestraint dto);
    Task<HubResponse> UserPushActiveCollar(PushClientActiveCollar dto);
    Task<HubResponse<Guid>> UserPushActiveLoot(PushClientActiveLoot dto);
    Task<HubResponse> UserPushAliasGlobalUpdate(PushClientAliasGlobalUpdate dto);
    Task<HubResponse> UserPushAliasUniqueUpdate(PushClientAliasUniqueUpdate dto);
    Task<HubResponse> UserPushValidToys(PushClientValidToys dto);
    Task<HubResponse> UserPushActivePattern(PushClientActivePattern dto);
    Task<HubResponse> UserPushActiveAlarms(PushClientActiveAlarms dto);
    Task<HubResponse> UserPushActiveTriggers(PushClientActiveTriggers dto);

    Task<HubResponse> UserPushNewGagData(PushClientDataChangeGag dto);
    Task<HubResponse> UserPushNewRestrictionData(PushClientDataChangeRestriction dto);
    Task<HubResponse> UserPushNewRestraintData(PushClientDataChangeRestraint dto);
    Task<HubResponse> UserPushNewCollarData(PushClientDataChangeCollar dto);
    Task<HubResponse> UserPushNewLootData(PushClientDataChangeLoot dto);
    Task<HubResponse> UserPushNewPatternData(PushClientDataChangePattern dto);
    Task<HubResponse> UserPushNewAlarmData(PushClientDataChangeAlarm dto);
    Task<HubResponse> UserPushNewTriggerData(PushClientDataChangeTrigger dto);
    Task<HubResponse> UserPushNewAllowances(PushClientAllowances dto);

    // Can only be called by the kinkster themselves, and only used for safeword action.
    Task<HubResponse<ClientGlobals>> UserBulkChangeGlobal(BulkChangeGlobal dto);
    Task<HubResponse> UserBulkChangeUnique(BulkChangeUnique dto);
    Task<HubResponse> UserChangeOwnGlobalPerm(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeOwnPairPerm(SingleChangeUnique dto);
    Task<HubResponse> UserChangeOwnPairPermAccess(SingleChangeAccess dto);
    Task<HubResponse<HardcoreState>> UserHardcoreAttributeExpired(HardcoreAttributeExpired dto);
    Task<HubResponse> UserDelete();


    // ----- Kinkster Interactions -----
    Task<HubResponse> UserSendKinksterRequest(CreateKinksterRequest requestDto);
    Task<HubResponse> UserCancelKinksterRequest(KinksterBase user);
    Task<HubResponse> UserAcceptKinksterRequest(KinksterBase user);
    Task<HubResponse> UserRejectKinksterRequest(KinksterBase user);
    Task<HubResponse> UserSendCollarRequest(CreateCollarRequest requestDto);
    Task<HubResponse> UserCancelCollarRequest(KinksterBase user);
    Task<HubResponse> UserAcceptCollarRequest(AcceptCollarRequest dto);
    Task<HubResponse> UserRejectCollarRequest(KinksterBase user);
    Task<HubResponse> UserRemoveKinkster(KinksterBase KinksterBase);

    Task<HubResponse> UserChangeKinksterActiveGag(PushKinksterActiveGagSlot dto);
    Task<HubResponse> UserChangeKinksterActiveRestriction(PushKinksterActiveRestriction dto);
    Task<HubResponse> UserChangeKinksterActiveRestraint(PushKinksterActiveRestraint dto);
    Task<HubResponse> UserChangeKinksterActiveCollar(PushKinksterActiveCollar dto);
    Task<HubResponse> UserChangeKinksterActivePattern(PushKinksterActivePattern dto);
    Task<HubResponse> UserChangeKinksterActiveAlarms(PushKinksterActiveAlarms dto);
    Task<HubResponse> UserChangeKinksterActiveTriggers(PushKinksterActiveTriggers dto);
    Task<HubResponse> UserSendNameToKinkster(KinksterBase recipient, string listenerName);

    // ------ Permission & State Changes ------
    Task<HubResponse> UserChangeOtherGlobalPerm(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeOtherPairPerm(SingleChangeUnique dto);
    Task<HubResponse> UserChangeOtherHardcoreState(HardcoreStateChange dto);

    // ---- IPC / External API Interactions ----
    Task<HubResponse> UserApplyMoodlesByGuid(MoodlesApplierById dto);
    Task<HubResponse> UserApplyMoodlesByStatus(MoodlesApplierByStatus dto);
    Task<HubResponse> UserRemoveMoodles(MoodlesRemoval dto);
    Task<HubResponse> UserClearMoodles(KinksterBase dto);
    Task<HubResponse> UserShockKinkster(ShockCollarAction dto); // Sends a shock instruction.
    Task<HubResponse> UserHypnotizeKinkster(HypnoticAction dto); // Applies a hypnosis state to another Kinkster. (special toggle)

    // ----- Vibe Rooms ------
    Task<HubResponse<List<RoomListing>>> SearchForRooms(SearchBase dto); //
    Task<HubResponse> RoomCreate(RoomCreateRequest dto); // 
    Task<HubResponse> SendRoomInvite(RoomInvite dto); // 
    Task<HubResponse> ChangeRoomHost(string name, KinksterBase newHost);
    Task<HubResponse> ChangeRoomPassword(string name, string newPass);
    Task<HubResponse<List<RoomParticipant>>> RoomJoin(string name, string pass, RoomParticipant dto); //
    Task<HubResponse> RoomLeave(); //
    Task<HubResponse> RoomGrantAccess(KinksterBase dto); //
    Task<HubResponse> RoomRevokeAccess(KinksterBase dto); //
    Task<HubResponse> RoomPushDeviceUpdate(ToyInfo dto);
    Task<HubResponse> RoomSendDataStream(ToyDataStream streamDto);
    Task<HubResponse> RoomSendChat(ChatMessageVibeRoom chatMessage); //
}
