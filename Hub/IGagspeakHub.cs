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
    const int ApiVersion = 16;
    const string Path = "/gagspeak";

    Task<bool> HealthCheck();
    Task<ConnectionResponse> GetConnectionResponse();
    Task<LobbyAndHubInfoResponse> GetShareHubAndLobbyInfo();

    #region Callbacks
    Task Callback_ServerMessage(MessageSeverity messageSeverity, string message);
    Task Callback_HardReconnectMessage(MessageSeverity messageSeverity, string message, ServerState state);
    Task Callback_ServerInfo(ServerInfoResponse info);

    // sends to a connected user to add the specified user to their pair list
    Task Callback_AddClientPair(KinksterPair dto);
    Task Callback_RemoveClientPair(KinksterBase dto);
    Task Callback_AddPairRequest(KinksterRequest dto);
    Task Callback_RemovePairRequest(KinksterRequest dto);
    Task Callback_AddCollarRequest(CollarRequest dto);
    Task Callback_RemoveCollarRequest(CollarRequest dto);

    // ---- Callbacks to update IPC.
    Task Callback_LociDataUpdated(LociDataUpdate dto);
    Task Callback_LociStatusesUpdate(LociStatusesUpdate dto);
    Task Callback_LociPresetsUpdate(LociPresetsUpdate dto);
    Task Callback_LociStatusModified(LociStatusModified dto);
    Task Callback_LociPresetModified(LociPresetModified dto);
    Task Callback_LociApplyDataById(ApplyLociDataById dto);
    Task Callback_LociApplyStatus(ApplyLociStatus dto);
    Task Callback_LociRemoveData(RemoveLociData dto);
    Task Callback_LociClearData(KinksterBase dto);

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
    Task Callback_KinksterChangeEnabledItem(KinksterChangeEnabledItem dto);
    Task Callback_KinksterChangeEnabledGag(KinksterChangeEnabledGag dto);
    Task Callback_KinksterChangeEnabledToy(KinksterChangeEnabledToy dto);
    Task Callback_KinksterChangeEnabledItems(KinksterChangeEnabledItems dto);
    Task Callback_KinksterChangeEnabledGags(KinksterChangeEnabledGags dto);
    Task Callback_KinksterChangeEnabledToys(KinksterChangeEnabledToys dto);
    Task Callback_ListenerName(SendNameAction dto);
    Task Callback_ShockInstruction(ShockCollarAction dto);
    Task Callback_HypnoticEffect(HypnoticAction dto); // hcState update for hypnosis, be sure to update HcState as well.


    // ---- Callbacks for Kinkster Light Storage Updates.
    Task Callback_KinksterNewGagData(KinksterNewGagData dto);
    Task Callback_KinksterNewRestrictionData(KinksterNewRestrictionData dto);
    Task Callback_KinksterNewRestraintData(KinksterNewRestraintData dto);
    Task Callback_KinksterNewCollarData(KinksterNewCollarData dto);
    Task Callback_KinksterNewLootData(KinksterNewLootData dto);
    Task Callback_KinksterNewAliasData(KinksterNewAliasData dto);
    Task Callback_KinksterNewPatternData(KinksterNewPatternData dto);
    Task Callback_KinksterNewAlarmData(KinksterNewAlarmData dto);
    Task Callback_KinksterNewTriggerData(KinksterNewTriggerData dto);

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
    /// <summary> Uploads your a new Loci Status to the server. </summary>
    Task<HubResponse> UploadLociStatus(LociStatusUpload dto);
    /// <summary> Downloads a pattern from the server. </summary>
    Task<HubResponse<string>> DownloadPattern(Guid patternId);
    /// <summary> Likes a pattern you see on the server. AddingLike==true means we liked it, false means we un-liked it. </summary>
    Task<HubResponse> LikePattern(Guid patternId);
    /// <summary> Likes a Loci Status you see on the server. AddingLike==true means we liked it, false means we un-liked it. </summary>
    Task<HubResponse> LikeLociData(Guid lociId);
    /// <summary> Deletes a pattern from the server. </summary>
    Task<HubResponse> DelistPattern(Guid patternId);
    /// <summary> Deletes a loci from the server. </summary>
    Task<HubResponse> DelistLociData(Guid lociId);
    /// <summary> Grabs the search result of your specified query to the server. </summary>
    Task<HubResponse<List<ServerPatternInfo>>> SearchPatterns(PatternSearch dto);
    /// <summary> Grabs the search result of your specified query to the server. </summary>
    Task<HubResponse<List<ServerLociInfo>>> SearchLociData(SearchBase dto);

    // ----- Client Vanity ------
    /// <summary> Sends a message to the gagspeak Global chat. </summary>
    Task<HubResponse> UserSendGlobalChat(ChatMessageGlobal dto);
    Task<HubResponse> UserUpdateAchievementData(AchievementsUpdate dto);
    Task<HubResponse> UserSetKinkPlateContent(KinkPlateInfo dto); // set profile content of own kinkplate.
    Task<HubResponse> UserSetKinkPlatePicture(KinkPlateImage dto); // set profile picture of own kinkplate.

    // ----- Reportings -----
    Task<HubResponse> UserReportProfile(ProfileReport dto);
    Task<HubResponse> UserReportChat(ChatReport dto);


    // ----- Personal Interactions ------
    Task<HubResponse> UserPushLociData(PushLociData dto);         // Share all data with allowed sundesmos.
    Task<HubResponse> UserPushLociStatuses(PushLociStatuses dto); // Share all Statuses data.
    Task<HubResponse> UserPushLociPresets(PushLociPresets dto);   // Share all Presets data.
    Task<HubResponse> UserPushStatusModified(PushStatusModified dto);   // A LociStatus was modified, created, or deleted.
    Task<HubResponse> UserPushPresetModified(PushPresetModified dto);   // A LociPreset was modified, created, or deleted.

    Task<HubResponse> UserPushActiveData(PushClientCompositeUpdate dto);
    Task<HubResponse<ActiveGagSlot>> UserPushActiveGags(PushClientActiveGagSlot dto);
    Task<HubResponse<ActiveRestriction>> UserPushActiveRestrictions(PushClientActiveRestriction dto);
    Task<HubResponse<CharaActiveRestraint>> UserPushActiveRestraint(PushClientActiveRestraint dto);
    Task<HubResponse<CharaActiveCollar>> UserPushActiveCollar(PushClientActiveCollar dto);
    Task<HubResponse<AppliedCursedItem>> UserPushActiveLoot(PushClientActiveLoot dto);
    Task<HubResponse> UserPushItemEnabledState(PushItemEnabledState dto);
    Task<HubResponse> UserPushGagEnabledState(PushGagEnabledState dto);
    Task<HubResponse> UserPushToyEnabledState(PushToyEnabledState dto);
    Task<HubResponse> UserPushItemEnabledStates(PushItemEnabledStates dto);
    Task<HubResponse> UserPushGagEnabledStates(PushGagEnabledStates dto);
    Task<HubResponse> UserPushToyEnabledStates(PushToyEnabledStates dto);

    Task<HubResponse> UserPushNewGagData(PushClientDataChangeGag dto);
    Task<HubResponse> UserPushNewRestrictionData(PushClientDataChangeRestriction dto);
    Task<HubResponse> UserPushNewRestraintData(PushClientDataChangeRestraint dto);
    Task<HubResponse> UserPushNewCollarData(PushClientDataChangeCollar dto);
    Task<HubResponse> UserPushNewLootData(PushClientDataChangeLoot dto);
    Task<HubResponse> UserPushNewAliasData(PushClientDataChangeAlias dto);
    Task<HubResponse> UserPushNewPatternData(PushClientDataChangePattern dto);
    Task<HubResponse> UserPushNewAlarmData(PushClientDataChangeAlarm dto);
    Task<HubResponse> UserPushNewTriggerData(PushClientDataChangeTrigger dto);

    // Can only be called by the kinkster themselves, and only used for safeword action.
    Task<HubResponse<ClientGlobals>> UserBulkChangeGlobal(BulkChangeGlobal dto);
    Task<HubResponse> UserBulkChangeUnique(BulkChangeUnique dto);
    Task<HubResponse> UserChangeOwnGlobalPerm(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeOwnPairPerm(SingleChangeUnique dto);
    Task<HubResponse> UserChangeOwnPairPermAccess(SingleChangeAccess dto);
    Task<HubResponse<HardcoreStatus>> UserHardcoreAttributeExpired(HardcoreAttributeExpired dto);
    Task<HubResponse> UserDelete();

    // ----- Kinkster Interactions -----
    Task<HubResponse<KinksterRequest>> UserSendKinksterRequest(CreateKinksterRequest requestDto);
    Task<HubResponse> UserCancelKinksterRequest(KinksterBase user);
    Task<HubResponse<AddedKinksterPair>> UserAcceptKinksterRequest(KinksterBase user);
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
    Task<HubResponse> UserChangeKinksterPatternState(PushKinksterEnabledState dto);
    Task<HubResponse> UserChangeKinksterAlarmState(PushKinksterEnabledState dto);
    Task<HubResponse> UserChangeKinksterTriggerState(PushKinksterEnabledState dto);

    // ------ Permission & State Changes ------
    Task<HubResponse> UserChangeOtherGlobalPerm(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeOtherPairPerm(SingleChangeUnique dto);
    Task<HubResponse> UserChangeOtherHardcoreState(HardcoreStateChange dto);

    // ---- IPC / External API Interactions ----
    Task<HubResponse> UserApplyLociData(ApplyLociDataById dto);
    Task<HubResponse> UserApplyLociStatusTuples(ApplyLociStatus dto);
    Task<HubResponse> UserRemoveLociData(RemoveLociData dto);
    Task<HubResponse> UserClearLociData(KinksterBase dto);
    Task<HubResponse> UserSendNameToKinkster(SendNameAction dto);
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
