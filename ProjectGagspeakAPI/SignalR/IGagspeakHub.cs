using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.UserPair;
using GagspeakAPI.Enums;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Dto.Toybox;
using GagspeakAPI.Dto.IPC;
using GagspeakAPI.Dto.Patterns;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.SignalR;

/// <summary> 
/// The interface for the GagspeakHub
/// <para> This interface is the server end of the SignalR calls made by the client. </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 12;
    const string Path = "/gagspeak";

    Task<bool> CheckMainClientHealth();

    /* ----------------- Task methods called upon by server and sent to clients ----------------- */
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message); /* General Server message that is sent to client with various severities */
    Task Client_ReceiveHardReconnectMessage(MessageSeverity messageSeverity, string message, ServerState state);
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo); /* Updates the client with the servers current system information */
    Task Client_UserAddClientPair(UserPairDto dto); /* sends to a connected user to add the specified user to their pair list */
    Task Client_UserRemoveClientPair(UserDto dto); /* sends to a connected user to remove the specified user from their pair list */

    /// <summary> Callbacks in regards to Kinkster Pairing Requests. </summary>
    Task Client_UserAddPairRequest(UserPairRequestDto dto); /* Can be either incoming or outgoing when called, direction depends on which UserData is us. */
    Task Client_UserRemovePairRequest(UserPairRequestDto dto); /* Can be either incoming or outgoing when called, direction depends on which UserData is us.  */

    /// <summary> Callbacks to update moodles. </summary>
    Task Client_UserApplyMoodlesByGuid(ApplyMoodlesByGuidDto dto);
    Task Client_UserApplyMoodlesByStatus(ApplyMoodlesByStatusDto dto);
    Task Client_UserRemoveMoodles(RemoveMoodlesDto dto);
    Task Client_UserClearMoodles(UserDto dto);


    /// <summary> Callbacks to update permissions. </summary>
    Task Client_UserUpdateAllPerms(UserPairUpdateAllPermsDto dto);
    Task Client_UserUpdateAllGlobalPerms(UserPairUpdateAllGlobalPermsDto dto);
    Task Client_UserUpdateAllUniquePerms(UserPairUpdateAllUniqueDto dto);
    Task Client_UserUpdatePairPermsGlobal(UserGlobalPermChangeDto dto);
    Task Client_UserUpdatePairPerms(UserPairPermChangeDto dto);
    Task Client_UserUpdatePairPermAccess(UserPairAccessChangeDto dto);

    /// <summary> Callbacks to update own or pair data. </summary>
    Task Client_UserReceiveDataComposite(OnlineUserCompositeDataDto dto);
    Task Client_UserReceiveDataIpc(OnlineUserCharaIpcDataDto dto);
    Task Client_UserReceiveDataAppearance(OnlineUserCharaAppearanceDataDto dto);
    Task Client_UserReceiveDataWardrobe(OnlineUserCharaWardrobeDataDto dto);
    Task Client_UserReceiveDataOrders(OnlineUserCharaOrdersDataDto dto);
    Task Client_UserReceiveDataAlias(OnlineUserCharaAliasDataDto dto);
    Task Client_UserReceiveDataToybox(OnlineUserCharaToyboxDataDto dto);
    Task Client_UserReceiveLightStorage(OnlineUserStorageUpdateDto dto);

    #region Generic Callbacks
    Task Client_UserReceiveShockInstruction(ShockCollarActionDto dto); /* Receive a shock instruction from the server */
    Task Client_GlobalChatMessage(GlobalChatMessageDto dto); /* Obtain global chat message from server */
    Task Client_UserSendOffline(UserDto dto); /* Sent to client who should be informed of another paired user's logout */
    Task Client_UserSendOnline(OnlineUserIdentDto dto); /* inform client of a paired user's login to servers. No CharacterData attached */
    Task Client_UserUpdateProfile(UserDto dto); /* informs a client that a connected user has updated their profile */
    Task Client_DisplayVerificationPopup(VerificationDto dto); /* Displays a verification popup to this client. Triggered by discord bot */
    #endregion Generic Callbacks

    Task<ConnectionDto> GetConnectionDto(); // Get the connection details of the client to the serve

    #region Generic Interactions
    Task UserSendPairRequest(UserPairSendRequestDto sendRequestDto); // Sends a pairing request to another Kinkster, creating a new entry.
    Task UserCancelPairRequest(UserDto user); // The UserDto of the User we wish to cancel the pair request to.
    Task UserAcceptIncPairRequest(UserDto user); // Accepts a Kinkster Pairing Request offered by another Kinkster.
    Task UserRejectIncPairRequest(UserDto user); // Rejects a Kinkster Pairing Request offered by another Kinkster.

    Task UserRemovePair(UserDto userDto); // remove a user from the paired list of the client
    Task UserDelete(); // delete this users account from the servers database
    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs(); // get the current online users paired with this client
    Task<List<UserPairDto>> UserGetPairedClients(); // get the current paired users of this client
    Task<List<UserPairRequestDto>> UserGetPairRequests(); // Grab the initial pair Requests that are both outgoing from us and incoming.

    Task SendGlobalChat(GlobalChatMessageDto dto); // Sends a message to the GagspeakGlobalChat.
    Task<bool> UploadPattern(PatternUploadDto dto);
    Task<bool> UploadMoodle(MoodleUploadDto dto);
    Task<string> DownloadPattern(Guid patternId);
    // no need to download moodles here.
    Task<bool> LikePattern(Guid patternId);
    Task<bool> LikeMoodle(Guid moodleId);
    Task<bool> RemovePattern(Guid patternId);
    Task<bool> RemoveMoodle(Guid moodleId);
    Task<List<ServerPatternInfo>> SearchPatterns(PatternSearchDto patternSearchDto);
    Task<List<ServerMoodleInfo>> SearchMoodles(MoodleSearchDto moodleSearchDto);
    Task<HashSet<string>> FetchSearchTags(); // Grab all current search tags stored in the share hubs.

    Task UserShockActionOnPair(ShockCollarActionDto dto); // send a shock action to a paired user
    Task UserUpdateAchievementData(UserAchievementsDto userAchievementData); // Provides the latest achievement data to the server
    Task<UserKinkPlateDto> UserGetKinkPlate(UserDto dto); // get the profile of a user
    Task UserReportKinkPlate(UserKinkPlateReportDto userDto); // hopefully this is never used x-x...
    Task UserSetKinkPlateContent(UserKinkPlateContentDto kinkPlateContentDto); // set profile content of own kinkplate.
    Task UserSetKinkPlatePicture(UserKinkPlatePictureDto kinkPlatePictureDto); // set profile picture of own kinkplate.
    #endregion Generic Interactions

    #region IPCTransfer
    /// <summary> Applies the specified moodles to the pair's Status Manager. </summary>
    Task<bool> UserApplyMoodlesByGuid(ApplyMoodlesByGuidDto dto); // this doesnt need to be bool anymore.

    /// <summary> Applies the specified moodles to the pair's Status Manager from our own. </summary>
    Task<bool> UserApplyMoodlesByStatus(ApplyMoodlesByStatusDto dto);

    /// <summary> Removes the specified moodles from the pair's Status Manager. </summary>
    Task<bool> UserRemoveMoodles(RemoveMoodlesDto dto);

    /// <summary> Clears all Statuses in the pairs Status Manager for them. </summary>
    Task<bool> UserClearMoodles(UserDto dto);
    #endregion IPCTransfer

    #region Client Push Own Data Updates
    /// <summary>
    /// Pushes the compiled information from all other modules DTO at once.
    /// <para> Meant for a bulk send in a send online push for initial updates. </para>
    /// </summary>
    Task UserPushData(UserCharaCompositeDataMessageDto dto);

    Task UserPushDataIpc(UserCharaIpcDataMessageDto dto);
    Task UserPushDataAppearance(UserCharaAppearanceDataMessageDto dto);
    Task UserPushDataWardrobe(UserCharaWardrobeDataMessageDto dto);
    Task UserPushDataOrders(UserCharaOrdersDataMessageDto dto);
    Task UserPushDataAlias(UserCharaAliasDataMessageDto dto);
    Task UserPushDataToybox(UserCharaToyboxDataMessageDto dto);
    Task UserPushDataLightStorage(UserCharaLightStorageMessageDto dto);


    #endregion Client Push Own Data Updates

    #region Client Update Other UserPair Data
    /// <summary>
    /// Pushes an updated state of the pair's appearance data after we made modifications to it, to the server.
    /// <para> Once server handles update, it is pushed to all pairs of the pair, including us. </para>
    /// <para><b> Of Note: Because timers are in DateTimeOffsetUTC format, we will not need to worry update data messing up timers. </b></para>
    /// </summary>
    Task UserPushPairDataAppearanceUpdate(OnlineUserCharaAppearanceDataDto dto);

    /// <summary>
    /// Pushes an updated version of a pair's Wardrobe DTO.
    /// <para>
    /// In no way should this ever modify the list of names. The only thing updated via this call 
    /// should be the labels about the active sets, and the active set information.
    /// </para>
    /// </summary>
    Task UserPushPairDataWardrobeUpdate(OnlineUserCharaWardrobeDataDto dto);

    /// <summary> Should ONLY ever be used and accepted for a name registration call. </summary>
    Task UserPushPairDataAliasStorageUpdate(OnlineUserCharaAliasDataDto dto);

    /// <summary>
    /// Pushes an updated version of a pair's Toybox DTO.
    /// <para> Pushes an updated version of the information from a pairs toybox data. </para>
    /// <para> This is called whenever we toggle a pairs trigger, alarm, or pattern. </para>
    /// </summary>
    Task UserPushPairDataToyboxUpdate(OnlineUserCharaToyboxDataDto dto);

    #endregion Client Update Other UserPair Data

    #region Permission Updates
    Task UserPushAllGlobalPerms(UserPairUpdateAllGlobalPermsDto dto);
    Task UserPushAllUniquePerms(UserPairUpdateAllUniqueDto dto);

    /// <summary>
    /// Push an update of your own global permissions to the server, and update other pairs with your change.
    /// </summary>
    Task UserUpdateOwnGlobalPerm(UserGlobalPermChangeDto dto);

    /// <summary>
    /// Push an update of your own unique permissions for a specific pair to the server. 
    /// </summary>
    Task UserUpdateOwnPairPerm(UserPairPermChangeDto dto);

    /// <summary>
    /// Push an update of your own access permissions for a specific pair to the server.
    /// </summary>
    Task UserUpdateOwnPairPermAccess(UserPairAccessChangeDto dto);

    /// <summary>
    /// Push an update you made to another pairs global permissions to the server.
    /// <para> 
    /// You must be granted access to make this change in order to make it.
    /// So if it is pushed, we assume you had access. 
    /// </para>
    /// <para> 
    /// Additionally, once this change is applied to the pair, it will be reflected 
    /// back to all pairs of that affected pair (including us). Allowing us to update it properly.
    /// </para>
    /// </summary>
    Task UserUpdateOtherGlobalPerm(UserGlobalPermChangeDto dto);

    /// <summary>
    /// Push an update you made to another pairs unique permissions to the server.
    /// <para>
    /// You must be granted access to make this change in order to make it.
    /// So if it is pushed, we assume you had access.
    /// </para>
    /// <para>
    /// Additionally, once this change is applied to the pair, it will be reflected
    /// back to all pairs of that affected pair (including us). Allowing us to update it properly.
    /// </para>
    /// </summary>
    Task UserUpdateOtherPairPerm(UserPairPermChangeDto dto);
    #endregion Permission Updates
}
