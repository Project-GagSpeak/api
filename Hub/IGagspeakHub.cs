using GagspeakAPI.Chat;
using GagspeakAPI.Connection;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Dto.Sharehub;
using GagspeakAPI.Dto.VibeRoom;
using GagspeakAPI.Enums;
using GagspeakAPI.Network;
using GagspeakAPI.Reporting;
using GagspeakAPI.User;

namespace GagspeakAPI.Hub;

/// <summary> 
/// The interface for the GagspeakHub
/// <para> This interface is the server end of the SignalR calls made by the client. </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 17;
    const string Path = "/gagspeak";

    Task<bool> HealthCheck();
    Task<ConnectionResponse> GetConnectionResponse();
    Task<LobbyAndHubInfoResponse> GetShareHubAndLobbyInfo();

    #region CALLBACKS

    #region Callbacks (Connection Responses)
    Task Callback_ServerMessage(MessageSeverity severity, string message);
    Task Callback_HardReconnectMessage(MessageSeverity severity, string message, ServerState state);
    Task Callback_UserFlaggedForReport(ReportKind kind, string flaggedUID);
    Task Callback_ReputationInfo(UserReputation reputation, string message);
    /// <summary> Gets total online users. </summary>
    Task Callback_ServerInfo(ServerInfoResponse info);
    #endregion

    #region Callbacks (Pairs/Requests)
    Task Callback_AddPair(KinksterPair dto);
    Task Callback_RemovePair(UserDto dto);
    Task Callback_PersistPair(UserDto dto);
    /// <summary> Occurs upon recieving a pair request from someone else. </summary>
    /// <remarks> This is not called in responce to your own sent requests. </remarks>
    Task Callback_AddPairRequest(KinksterRequest dto);
    /// <summary> When a pending request was rejected, or pending request was canceled. </summary>
    /// <remarks> This is not called in responce to your own sent requests. </remarks>
    Task Callback_RemovePairRequest(KinksterRequest dto);
    Task Callback_AddCollarRequest(CollarRequest dto);
    Task Callback_RemoveCollarRequest(CollarRequest dto);
    #endregion 

    #region Callbacks (Locis)
    Task Callback_LociDataUpdated(LociDataUpdate dto);
    Task Callback_LociStatusesUpdate(LociStatusesUpdate dto);
    Task Callback_LociPresetsUpdate(LociPresetsUpdate dto);
    Task Callback_LociStatusModified(LociStatusModified dto);
    Task Callback_LociPresetModified(LociPresetModified dto);
    Task Callback_LociApplyDataById(ApplyLociDataById dto);
    Task Callback_LociApplyStatus(ApplyLociStatus dto);
    Task Callback_LociRemoveData(RemoveLociData dto);
    Task Callback_LociClearData(UserDto dto);
    #endregion

    #region Callbacks (Permissions)
    Task Callback_BulkChangeGlobal(BulkChangeGlobal dto);
    Task Callback_BulkChangeUnique(BulkChangeUnique dto);
    Task Callback_SingleChangeGlobal(SingleChangeGlobal dto);
    Task Callback_SingleChangeUnique(SingleChangeUnique dto);
    Task Callback_SingleChangeAccess(SingleChangeAccess dto);
    Task Callback_StateChangeHardcore(HardcoreStateChange dto); // reject if for hypnosis, too much data for DB.
    #endregion

    // ---- Callbacks for Kinkster Active State updates.
    #region Callbacks (Data Updates)
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
    #endregion

    #region Callbacks (Light Storage Updates)
    Task Callback_KinksterNewGagData(KinksterNewGagData dto);
    Task Callback_KinksterNewRestrictionData(KinksterNewRestrictionData dto);
    Task Callback_KinksterNewRestraintData(KinksterNewRestraintData dto);
    Task Callback_KinksterNewCollarData(KinksterNewCollarData dto);
    Task Callback_KinksterNewLootData(KinksterNewLootData dto);
    Task Callback_KinksterNewAliasData(KinksterNewAliasData dto);
    Task Callback_KinksterNewPatternData(KinksterNewPatternData dto);
    Task Callback_KinksterNewAlarmData(KinksterNewAlarmData dto);
    Task Callback_KinksterNewTriggerData(KinksterNewTriggerData dto);
    #endregion

    #region Callbacks (UserState / Misc.)
    /// <summary> Whenever one of our Sundesmo connects to Sundouleia. </summary>
    Task Callback_KinksterOnline(OnlineKinkster dto);
    /// <summary> Whenever one of our Sundesmo disconnects from Sundouleia. </summary>
    Task Callback_KinksterOffline(UserDto dto);
    /// <summary> Enforce a refresh on all vanity status for the kinkster. </summary>
    Task Callback_UserVanityUpdated(UserDto dto);
    /// <summary> Another user, paired or not, has a profile update. </summary>
    /// <remarks> If we received this, reload their profile in the cache </remarks>
    Task Callback_UserProfileUpdated(UserDto dto);
    /// <summary>
    ///   When verifying your account via the discord bot, this will pass in
    ///   the code that displays in-game for you to respond to the bot with.
    /// </summary>
    Task Callback_ShowVerification(VerificationCode dto);
    /// <summary> Sent by GlobalChat or a private DM. </summary>
    Task Callback_ChatMessageReceived(ChatlogMessage dto);
    #endregion

    // ---- Callbacks for Vibe Rooms
    #region VibeRooms
    Task Callback_RoomJoin(RoomParticipant dto);
    Task Callback_RoomLeave(UserData user);
    Task Callback_RoomAddInvite(RoomInvite dto);
    Task Callback_RoomHostChanged(UserData newHost);
    Task Callback_RoomDeviceUpdate(UserData user, ToyInfo ToyInfo);
    Task Callback_RoomIncDataStream(ToyDataStreamResponse dataStream);
    Task Callback_RoomAccessGranted(UserData user);
    Task Callback_RoomAccessRevoked(UserData user);
    Task Callback_RoomChatMessage(UserData user, string message);
    #endregion

    #endregion CALLBACKS

    #region SERVER_CALLS

    #region Data Retrievals
    /// <summary> Requests a list of UserPair DTO's containing the client pairs  of the client caller </summary>
    Task<List<KinksterPair>> GetAllKinksterPairs();
    /// <summary> Requested upon login, asking for the current Kinkster pairs online. </summary>
    Task<List<OnlineKinkster>> GetOnlineKinksters();
    /// <summary> Requests the list of all current Kinkster Requests active for the caller. </summary>
    Task<ActiveRequests> GetRequests();
    Task<ChatHistoryResult> GetChatHistory(ChatHistoryRequest dto);
    /// <summary> Retrieve the ProfileData for a User. </summary>
    Task<KinkPlateFull> GetKinkplate(UserDto user);
    /// <summary> Retrieves the profileData for a list of users. </summary>
    Task<List<KinkPlateFull>> GetKinkplates(UserListDto users);
    #endregion

    #region Sharehubs
    /// <summary> Uploads your pattern to the server. </summary>
    Task<HubResponse> UploadPattern(SharehubUploadPattern dto);
    /// <summary> Uploads your a new Loci Status to the server. </summary>
    Task<HubResponse> UploadLociStatus(SharehubUploadLociStatus dto);
    /// <summary> Downloads a pattern from the server. </summary>
    Task<HubResponse<string>> DownloadPattern(Guid patternId);
    /// <summary> Likes a pattern you see on the server. AddingLike==true means we liked it, false means we un-liked it. </summary>
    Task<HubResponse> LikePattern(Guid patternId);
    /// <summary> Likes a Loci Status you see on the server. AddingLike==true means we liked it, false means we un-liked it. </summary>
    Task<HubResponse> LikeLociStatus(Guid statusId);
    /// <summary> Deletes a pattern from the server. </summary>
    Task<HubResponse> DelistPattern(Guid patternId);
    /// <summary> Deletes a loci from the server. </summary>
    Task<HubResponse> DelistLociStatus(Guid statusId);
    /// <summary> Grabs the search result of your specified query to the server. </summary>
    Task<HubResponse<List<SharehubPattern>>> SearchPatterns(SearchPattern dto);
    /// <summary> Grabs the search result of your specified query to the server. </summary>
    Task<HubResponse<List<SharehubLociStatus>>> SearchLociData(SearchBase dto);
    #endregion

    #region Vanity & Cosmetics
    /// <summary>
    ///   Allows anyone to freely update their UserData alias. <br/>
    ///   All other fields aside from Alias are supporter only.
    /// </summary>
    Task<HubResponse> UserUpdateData(UserDataUpdate dto);
    /// <summary> Update the image contents of your ProfileData, check image validity server-side. </summary>
    Task<HubResponse> UserSetKinkPlatePicture(KinkPlateImage dto);
    /// <summary> Update the contents of your ProfileData. </summary>
    Task<HubResponse> UserSetKinkPlateContent(KinkPlateInfo dto);
    /// <summary> Updates the achievement data for the user.  </summary>
    Task<HubResponse> UserUpdateAchievementData(AchievementsUpdate dto);
    /// <summary> Generic DTO to send a chat message from any source. </summary>
    Task<HubResponse> UserSendChat(SentMessage message);
    #endregion

    #region Push ActiveData
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
    // Only called by the client, cannot be invoked by another.
    Task<HubResponse<ClientGlobals>> UserBulkChangeGlobal(BulkChangeGlobal dto);
    Task<HubResponse> UserBulkChangeUnique(BulkChangeUnique dto);
    Task<HubResponse> UserChangeOwnGlobalPerm(SingleChangeGlobal dto);
    Task<HubResponse> UserChangeOwnPairPerm(SingleChangeUnique dto);
    Task<HubResponse> UserChangeOwnPairPermAccess(SingleChangeAccess dto);
    Task<HubResponse<HardcoreState>> UserHardcoreAttributeExpired(HardcoreAttributeExpired dto);
    #endregion

    #region StoredData Changes
    Task<HubResponse> UserPushNewGagData(PushClientDataChangeGag dto);
    Task<HubResponse> UserPushNewRestrictionData(PushClientDataChangeRestriction dto);
    Task<HubResponse> UserPushNewRestraintData(PushClientDataChangeRestraint dto);
    Task<HubResponse> UserPushNewCollarData(PushClientDataChangeCollar dto);
    Task<HubResponse> UserPushNewLootData(PushClientDataChangeLoot dto);
    Task<HubResponse> UserPushNewAliasData(PushClientDataChangeAlias dto);
    Task<HubResponse> UserPushNewPatternData(PushClientDataChangePattern dto);
    Task<HubResponse> UserPushNewAlarmData(PushClientDataChangeAlarm dto);
    Task<HubResponse> UserPushNewTriggerData(PushClientDataChangeTrigger dto);
    #endregion

    #region Change OtherUser
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
    #endregion

    #region Loci
    Task<HubResponse> UserPushLociData(PushLociData dto);         // Share all data with allowed sundesmos.
    Task<HubResponse> UserPushLociStatuses(PushLociStatuses dto); // Share all Statuses data.
    Task<HubResponse> UserPushLociPresets(PushLociPresets dto);   // Share all Presets data.
    Task<HubResponse> UserPushStatusModified(PushStatusModified dto);   // A LociStatus was modified, created, or deleted.
    Task<HubResponse> UserPushPresetModified(PushPresetModified dto);   // A LociPreset was modified, created, or deleted.

    Task<HubResponse> UserApplyLociData(ApplyLociDataById dto);
    Task<HubResponse> UserApplyLociStatusTuples(ApplyLociStatus dto);
    Task<HubResponse> UserRemoveLociData(RemoveLociData dto);
    Task<HubResponse> UserClearLociData(UserDto dto);
    #endregion

    #region PersonalInfo Exchange
    Task<HubResponse> UserSendNameToKinkster(SendNameAction dto);
    Task<HubResponse> UserShockKinkster(ShockCollarAction dto); // Sends a shock instruction.
    Task<HubResponse> UserHypnotizeKinkster(HypnoticAction dto); // Applies a hypnosis state to another Kinkster. (special toggle)
    #endregion

    #region Requesting
    Task<HubResponse<KinksterRequest>> UserCreatePairRequest(CreateRequest dto);
    /// <remarks> If successful, remove the request they wished to cancel. </remarks>
    Task<HubResponse> UserCancelRequest(UserDto user);
    /// <remarks> If successful, remove all requests they wished to cancel. </remarks>
    Task<HubResponse> UserCancelRequests(UserListDto users);
    /// <remarks> If EC "AlreadyPaired" is returned, remove the request from your pending list. </remarks>
    /// <returns> The new UserPair to add, if the request was properly accepted.</returns>
    Task<HubResponse<AddedKinksterPair>> UserAcceptRequest(RequestResponse response);
    /// <remarks> If successful, remove all requests for users passed in, regardless of outcome. </remarks>
    Task<HubResponse<List<AddedKinksterPair>>> UserAcceptRequests(RequestResponses responses);
    /// <remarks> Remove the request if successful. </remarks>
    Task<HubResponse> UserRejectRequest(UserDto user);
    /// <remarks> Remove the requests for all users passed in if successful. </remarks>
    Task<HubResponse> UserRejectRequests(UserListDto users);
    /// <summary> Converts a temporary pair to a permanent one. (Can only be done by the accepter) </summary>
    Task<HubResponse> UserPersistKinkster(UserDto user);
    /// <remarks> Remove pair if result is successful. </remarks>
    Task<HubResponse> UserRemoveKinkster(UserDto user);
    /// <remarks> Remove pairs for all users passed in if result is successful. </remarks>
    Task<HubResponse> UserRemoveKinksters(UserListDto users);

    //Task<HubResponse> UserSendCollarRequest(CreateCollarRequest requestDto);
    //Task<HubResponse> UserCancelCollarRequest(UserDto user);
    //Task<HubResponse> UserAcceptCollarRequest(CollarResponse dto);
    //Task<HubResponse> UserRejectCollarRequest(UserDto user);

    /// <summary> Explodes your logged in user from the Database, and all associated data with it. </summary>
    /// <remarks> Removing your primary profile deletes all other profiles linked to your account. </remarks>
    Task<HubResponse> UserDelete();
    #endregion

    #region Reports
    Task<HubResponse> UserReportProfile(ProfileReport dto);
    Task<HubResponse> UserReportChat(ChatReport dto);
    #endregion

    #region VibeRooms
    Task<HubResponse<List<RoomListing>>> SearchForRooms(SearchBase dto); //
    Task<HubResponse> RoomCreate(RoomCreateRequest dto); // 
    Task<HubResponse> SendRoomInvite(RoomInvite dto); // 
    Task<HubResponse> ChangeRoomHost(string name, UserDto newHost);
    Task<HubResponse> ChangeRoomPassword(string name, string newPass);
    Task<HubResponse<List<RoomParticipant>>> RoomJoin(string name, string pass, RoomParticipant dto); //
    Task<HubResponse> RoomLeave(); //
    Task<HubResponse> RoomGrantAccess(UserDto dto); //
    Task<HubResponse> RoomRevokeAccess(UserDto dto); //
    Task<HubResponse> RoomPushDeviceUpdate(ToyInfo dto);
    Task<HubResponse> RoomSendDataStream(ToyDataStream streamDto);
    Task<HubResponse> RoomSendChat(ChatlogMessage messageDto); //
    #endregion
    #endregion
}
