using GagspeakAPI.Data;
using GagspeakAPI.Dto;
using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.IPC;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.Sharehub;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Dto.UserPair;
using GagspeakAPI.Dto.VibeRoom;
using GagspeakAPI.Enums;

namespace GagspeakAPI.SignalR;

/// <summary> 
/// The interface for the GagspeakHub
/// <para> This interface is the server end of the SignalR calls made by the client. </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 13;
    const string Path = "/gagspeak";

    Task<bool> CheckMainClientHealth();
    Task<ConnectionDto> GetConnectionDto();

    #region Callbacks
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message); /* General Server message that is sent to client with various severities */
    Task Client_ReceiveHardReconnectMessage(MessageSeverity messageSeverity, string message, ServerState state);
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo); /* Updates the client with the servers current system information */

    Task Client_UserAddClientPair(UserPairDto dto); /* sends to a connected user to add the specified user to their pair list */
    Task Client_UserRemoveClientPair(UserDto dto); /* sends to a connected user to remove the specified user from their pair list */
    Task Client_UserAddPairRequest(UserPairRequestDto dto); /* Can be either incoming or outgoing when called, direction depends on which UserData is us. */
    Task Client_UserRemovePairRequest(UserPairRequestDto dto); /* Can be either incoming or outgoing when called, direction depends on which UserData is us.  */

    /// <summary> Callbacks to update moodles. </summary>
    Task Client_UserApplyMoodlesByGuid(ApplyMoodlesByGuidDto dto);
    Task Client_UserApplyMoodlesByStatus(ApplyMoodlesByStatusDto dto);
    Task Client_UserRemoveMoodles(RemoveMoodlesDto dto);
    Task Client_UserClearMoodles(UserDto dto);

    /// <summary> Callbacks to update permissions. </summary>
    Task Client_UserUpdateAllPerms(BulkUpdatePermsAllDto dto);
    Task Client_UserUpdateAllGlobalPerms(BulkUpdatePermsGlobalDto dto);
    Task Client_UserUpdateAllUniquePerms(BulkUpdatePermsUniqueDto dto);
    Task Client_UserUpdateGlobalPerm(UserGlobalPermChangeDto dto);
    Task Client_UserUpdateUniquePerm(UserPairPermChangeDto dto);
    Task Client_UserUpdatePermAccess(UserPairAccessChangeDto dto);

    /// <summary> Callbacks to update own or pair data. </summary>
    Task Client_UserReceiveDataComposite(OnlineUserCompositeDataDto dto);
    Task Client_UserReceiveDataIpc(CallbackIpcDataDto dto);
    Task Client_UserReceiveDataGags(CallbackGagDataDto dto);
    Task Client_UserReceiveDataRestrictions(CallbackRestrictionDataDto dto);
    Task Client_UserReceiveDataRestraint(CallbackRestraintDataDto dto);
    Task Client_UserReceiveDataCursedLoot(CallbackCursedLootDto dto);
    Task Client_UserReceiveDataToybox(CallbackToyboxDataDto dto);
    Task Client_UserReceiveAliasGlobalUpdate(CallbackAliasGlobalUpdateDto dto);
    Task Client_UserReceiveAliasPairUpdate(CallbackAliasPairUpdateDto dto);
    Task Client_UserReceiveListenerName(UserData user, string name);
    Task Client_UserReceiveLightStorage(CallbackLightStorageDto dto);

    Task Client_UserReceiveShockInstruction(ShockCollarAction dto); /* Receive a shock instruction from the server */

    Task Client_RoomJoin(VibeRoomKinksterFullDto user); /* Callback for when a user joins a room. */
    Task Client_RoomLeave(VibeRoomKinksterFullDto user); /* Callback for when a user leaves a room. */
    Task Client_RoomReceiveDeviceUpdate(UserData user, DeviceInfo deviceInfo); /* Receives device update (e.g., battery level, motor settings) for a device in the room. */
    Task Client_RoomReceiveDataStream(SexToyDataStreamCallbackDto dataStream); /* Receives data stream (vibration/rotation data) to play to your toys. */
    Task Client_RoomUserAccessGranted(UserData user); /* Callback containing a user that granted you access to use their toys. */
    Task Client_RoomUserAccessRevoked(UserData user); /* Callback containing a user that revoked your access to use their toys. */
    Task Client_RoomReceiveChatMessage(UserData user, string message); /* Receives a chat message from a user in the room. */

    Task Client_GlobalChatMessage(GlobalChatMessageDto dto); /* Obtain global chat message from server */
    Task Client_UserSendOffline(UserDto dto); /* Sent to client who should be informed of another paired user's logout */
    Task Client_UserSendOnline(OnlineUserIdentDto dto); /* inform client of a paired user's login to servers. No CharacterData attached */
    Task Client_UserUpdateProfile(UserDto dto); /* informs a client that a connected user has updated their profile */
    Task Client_DisplayVerificationPopup(VerificationDto dto); /* Displays a verification popup to this client. Triggered by discord bot */
    #endregion Callbacks

    #region Client Pairs & Profile Management
    // --------- Pair Management --------- //
    Task UserSendPairRequest(UserPairSendRequestDto sendRequestDto);
    Task UserCancelPairRequest(UserDto user);
    Task UserAcceptIncPairRequest(UserDto user);
    Task UserRejectIncPairRequest(UserDto user);
    Task UserRemovePair(UserDto userDto);
    Task UserDelete();
    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs();
    Task<List<UserPairDto>> UserGetPairedClients();
    Task<List<UserPairRequestDto>> UserGetPairRequests();


    // --------- Profile & Misc --------- //
    Task SendGlobalChat(GlobalChatMessageDto dto);
    Task UserShockActionOnPair(ShockCollarAction dto);
    Task<UserKinkPlateDto> UserGetKinkPlate(UserDto dto); // get the profile of a user
    Task UserReportKinkPlate(UserKinkPlateReportDto userDto); // hopefully this is never used x-x...
    Task UserSetKinkPlateContent(UserKinkPlateContentDto kinkPlateContentDto); // set profile content of own kinkplate.
    Task UserSetKinkPlatePicture(UserKinkPlatePictureDto kinkPlatePictureDto); // set profile picture of own kinkplate.
    Task<bool> UserUpdateAchievementData(UserAchievementsDto userAchievementData);
    #endregion Client Pairs & Profile Management


    // -------- Share Hub Methods -------- //
    Task<bool> UploadPattern(PatternUploadDto dto);
    Task<bool> UploadMoodle(MoodleUploadDto dto);
    Task<string> DownloadPattern(Guid patternId);
    Task<bool> LikePattern(Guid patternId);
    Task<bool> LikeMoodle(Guid moodleId);
    Task<bool> RemovePattern(Guid patternId);
    Task<bool> RemoveMoodle(Guid moodleId);
    Task<List<ServerPatternInfo>> SearchPatterns(PatternSearchDto patternSearchDto);
    Task<List<ServerMoodleInfo>> SearchMoodles(MoodleSearchDto moodleSearchDto);
    Task<HashSet<string>> FetchSearchTags();


    // -------- IPC Transfer Handles -------- //
    Task<bool> UserApplyMoodlesByGuid(ApplyMoodlesByGuidDto dto);
    Task<bool> UserApplyMoodlesByStatus(ApplyMoodlesByStatusDto dto);
    Task<bool> UserRemoveMoodles(RemoveMoodlesDto dto);
    Task<bool> UserClearMoodles(UserDto dto);

    // -------- Vibe Server Rooms -------- //
    /// <summary> Attempts to create a room with the specified room name. </summary>
    /// <remarks> Will return false if the room name already exists or if it failed to create. </remarks>
    Task<GsApiVibeErrorCodes> RoomCreate(string roomName, string password); // Was bool

    /// <summary> Sends an invite to a user to join a room. </summary>
    Task<GsApiVibeErrorCodes> SendRoomInvite(VibeRoomInviteDto dto); // Was bool

    /// <summary> Changes the password of an existing room. </summary>
    Task<GsApiVibeErrorCodes> ChangeRoomPassword(string roomName, string newPassword); // Was bool

    /// <summary> Allows a user to join the room. </summary>
    Task<List<VibeRoomKinksterFullDto>> RoomJoin(string roomName, string password, VibeRoomKinkster dto);

    /// <summary> Allows a user to leave the room. </summary>
    Task<GsApiVibeErrorCodes> RoomLeave(); // Was bool

    /// <summary> Grants access to a user in the room. </summary>
    Task<GsApiVibeErrorCodes> RoomGrantAccess(UserDto allowedUser); // Was bool

    /// <summary> Revokes access from a user in the room. </summary>
    Task<GsApiVibeErrorCodes> RoomRevokeAccess(UserDto allowedUser); // Was bool

    /// <summary> Pushes device update (e.g., for battery level, motor settings) to the room. </summary>
    Task<GsApiVibeErrorCodes> RoomPushDeviceUpdate(DeviceInfo deviceInfo);

    /// <summary> Sends a data stream (vibration/rotation data) to users in the room. </summary>
    Task<GsApiVibeErrorCodes> RoomSendDataStream(SexToyDataStreamDto dataStream);

    /// <summary> Sends a chat message to the room. </summary>
    Task<GsApiVibeErrorCodes> RoomSendChat(string roomName, string message);


    #region Data & Permission Changes
    // -------- Client Change Own Data >> Update to Pairs (Bool returns help with InvokableActions -------- //
    Task<GsApiErrorCodes> UserPushData(PushCompositeDataMessageDto dto);
    Task UserPushDataIpc(PushIpcDataUpdateDto dto);
    Task<GsApiErrorCodes> UserPushDataGags(PushGagDataUpdateDto dto);
    Task<GsApiErrorCodes> UserPushDataRestrictions(PushRestrictionDataUpdateDto dto);
    Task<GsApiErrorCodes> UserPushDataRestraint(PushRestraintDataUpdateDto dto);
    Task<GsApiErrorCodes> UserPushDataCursedLoot(PushCursedLootDataUpdateDto dto);
    Task<GsApiErrorCodes> UserPushDataToybox(PushToyboxDataUpdateDto dto);
    Task<GsApiErrorCodes> UserPushAliasGlobalUpdate(PushAliasGlobalUpdateDto dto);
    Task<GsApiErrorCodes> UserPushAliasPairUpdate(PushAliasPairUpdateDto dto);
    Task<GsApiErrorCodes> UserPushDataLightStorage(PushLightStorageMessageDto dto);


    // ------ Client Change Pair Data >> Update to Pairs ------ //
    Task<GsApiPairErrorCodes> UserPushPairDataGags(PushPairGagDataUpdateDto dto);
    Task<GsApiPairErrorCodes> UserPushPairDataRestrictions(PushPairRestrictionDataUpdateDto dto);
    Task<GsApiPairErrorCodes> UserPushPairDataRestraint(PushPairRestraintDataUpdateDto dto);
    Task<GsApiPairErrorCodes> UserPushPairDataToybox(PushPairToyboxDataUpdateDto dto);
    Task<GsApiPairErrorCodes> UserPushPairListenerName(UserDto recipient, string listenerName);


    // ------ Permission Updates ------ // 
    Task UserPushAllGlobalPerms(BulkUpdatePermsGlobalDto dto);
    Task UserPushAllUniquePerms(BulkUpdatePermsUniqueDto dto);
    Task UserUpdateOwnGlobalPerm(UserGlobalPermChangeDto dto);
    Task UserUpdateOwnPairPerm(UserPairPermChangeDto dto);
    Task UserUpdateOwnPairPermAccess(UserPairAccessChangeDto dto);

    /// <summary> Push an update you made to another pairs GlobalPermissions to the server. </summary>
    /// <remarks> If you are not given explicit access to edit this, it will be rejected. </remarks>
    Task UserUpdateOtherGlobalPerm(UserGlobalPermChangeDto dto);

    /// <summary> Push an update you made to another pairs PairPermissions to the server. </summary>
    /// <remarks> If you are not given explicit access to edit this, it will be rejected. </remarks>
    Task UserUpdateOtherPairPerm(UserPairPermChangeDto dto);
    #endregion Data & Permission Changes
}
