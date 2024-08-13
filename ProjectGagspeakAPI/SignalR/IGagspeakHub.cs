using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.UserPair;
using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Dto.Toybox;

namespace GagspeakAPI.SignalR;

/// <summary> 
/// The interface for the GagspeakHub
/// <para> This interface is the server end of the SignalR calls made by the client. </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 5;
    const string Path = "/gagspeak";

    Task<bool> CheckMainClientHealth();

    /* ----------------- Task methods called upon by server and sent to clients ----------------- */
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message); /* General Server message that is sent to client with various severities */
    Task Client_ReceiveHardReconnectMessage(MessageSeverity messageSeverity, string message, ServerState state);
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo); /* Updates the client with the servers current system information */
    Task Client_UserAddClientPair(UserPairDto dto); /* sends to a connected user to add the specified user to their pair list */
    Task Client_UserRemoveClientPair(UserDto dto); /* sends to a connected user to remove the specified user from their pair list */
    Task Client_UpdateUserIndividualPairStatusDto(UserIndividualPairStatusDto dto); /* informs a client of a paired user's updated individual pair status */

    #region Permission Callbacks
    /// <summary> Receive callback to update all of the userPair's global permissions. </summary>
    Task Client_UserUpdateSelfPairPermsGlobal(UserGlobalPermChangeDto dto);

    /// <summary> Receive callback to update all of the userPair's permissions. </summary>
    Task Client_UserUpdateSelfPairPerms(UserPairPermChangeDto dto);

    /// <summary> Receive callback to update all of the userPair's access permissions. </summary>
    Task Client_UserUpdateSelfPairPermAccess(UserPairAccessChangeDto dto);

    /// <summary> Receive callback to update all of the userPair's permissions. </summary>
    Task Client_UserUpdateOtherAllPairPerms(UserPairUpdateAllPermsDto dto);
    
    /// <summary> Receive callback to update another userPair's global permissions. </summary>
    Task Client_UserUpdateOtherPairPermsGlobal(UserGlobalPermChangeDto dto);
    
    /// <summary> Receive callback to update another userPair's unique permissions. </summary>
    Task Client_UserUpdateOtherPairPerms(UserPairPermChangeDto dto);
    
    /// <summary> Receive callback to update another userPair's access permissions. </summary>
    Task Client_UserUpdateOtherPairPermAccess(UserPairAccessChangeDto dto);
    #endregion Permission Callbacks

    #region CharacterData Update Callbacks
    /// <summary> Push composite data to all paired users when you first go online. </summary>
    Task Client_UserReceiveCharacterDataComposite(OnlineUserCompositeDataDto dto);


    /// <summary> Callback to forcefully update Client's own IPC data. </summary>
    Task Client_UserReceiveOwnDataIpc(OnlineUserCharaIpcDataDto dto);

    /// <summary> Callback to forcefully update a paired user's IPC data. </summary>
    Task Client_UserReceiveOtherDataIpc(OnlineUserCharaIpcDataDto dto);



    /// <summary> Callback to forcefully update Client's own Appearance data. </summary>
    Task Client_UserReceiveOwnDataAppearance(OnlineUserCharaAppearanceDataDto dto);

    /// <summary> Callback to forcefully update a paired user's Appearance data. </summary>
    Task Client_UserReceiveOtherDataAppearance(OnlineUserCharaAppearanceDataDto dto);



    /// <summary> Callback to forcefully update Client's own Wardrobe data. </summary>
    Task Client_UserReceiveOwnDataWardrobe(OnlineUserCharaWardrobeDataDto dto);

    /// <summary> Callback to forcefully update a paired user's Wardrobe data. </summary>
    Task Client_UserReceiveOtherDataWardrobe(OnlineUserCharaWardrobeDataDto dto);



    /// <summary> Callback to update Client's own Alias data. (should only be re </summary>
    Task Client_UserReceiveOwnDataAlias(OnlineUserCharaAliasDataDto dto);

    /// <summary> Callback to forcefully update another pair's alias data. </summary>
    Task Client_UserReceiveOtherDataAlias(OnlineUserCharaAliasDataDto dto);



    /// <summary> Callback to forcefully update Client's own Toybox data. </summary>
    Task Client_UserReceiveOwnDataToybox(OnlineUserCharaToyboxDataDto dto);

    /// <summary> Callback to forcefully update a paired user's Toybox data. </summary>
    Task Client_UserReceiveOtherDataToybox(OnlineUserCharaToyboxDataDto dto);
    #endregion CharacterData Update Callbacks

    #region Generic Callbacks
    Task Client_GlobalChatMessage(GlobalChatMessageDto dto); /* Obtain global chat message from server */
    Task Client_UserSendOffline(UserDto dto); /* Sent to client who should be informed of another paired user's logout */
    Task Client_UserSendOnline(OnlineUserIdentDto dto); /* inform client of a paired user's login to servers. No CharacterData attached */
    Task Client_UserUpdateProfile(UserDto dto); /* informs a client that a connected user has updated their profile */
    Task Client_DisplayVerificationPopup(VerificationDto dto); /* Displays a verification popup to this client. Triggered by discord bot */
    #endregion Generic Callbacks

    Task<ConnectionDto> GetConnectionDto(); // Get the connection details of the client to the serve

    #region Generic Interactions
    Task SendGlobalChat(GlobalChatMessageDto dto); // Sends a message to the GagspeakGlobalChat.
    Task UserAddPair(UserDto user); // add another user as a pair to the users paired list
    Task UserRemovePair(UserDto userDto); // remove a user from the paired list of the client
    Task UserDelete(); // delete this users account from the servers database
    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs(); // get the current online users paired with this client
    Task<List<UserPairDto>> UserGetPairedClients(); // get the current paired users of this client
    Task<UserProfileDto> UserGetProfile(UserDto dto); // get the profile of a user
    Task UserReportProfile(UserProfileReportDto userDto); // hopefully this is never used x-x...
    Task UserSetProfile(UserProfileDto userMiniProfile); // set the profile of the client
    #endregion Generic Interactions

    #region Client Push Own Data Updates
    /// <summary>
    /// Pushes the compiled information from all other modules DTO at once.
    /// <para> Meant for a bulk send in a send online push for initial updates. </para>
    /// </summary>
    Task UserPushData(UserCharaCompositeDataMessageDto dto);

    /// <summary>
    /// pushes IPC data to the server, updating paired online clients
    /// <para> Currently only includes the moodles IPC string, as C+ is stored locally. </para>
    /// </summary>
    Task UserPushDataIpc(UserCharaIpcDataMessageDto dto);
    
    /// <summary>
    /// Pushes a player's appearance data to the server, updating paired online clients.
    /// <para>
    /// Information pushed includes info about current gags, locks, passwords, timers, and assigners 
    /// </para>
    /// <para><b> Of Note: Because timers are in DateTimeOffsetUTC format, we will not need to worry update data messing up timers. </b></para>
    /// </summary>
    Task UserPushDataAppearance(UserCharaAppearanceDataMessageDto dto);

    /// <summary>
    /// Pushes a player's wardrobe data to the server, updating paired online clients.
    /// <para> 
    /// Information pushed includes the list of restraint sets by name, and info about the active set. 
    /// </para>
    /// <para>
    /// <b> For another client pair to update someone else's restraint set, the following must be true: </b>
    /// <list type="bullet">
    /// <item> Cannot activate a set if a set is currently active. </item>
    /// <item> Cannot lock a set if it is not the currently active set. </item>
    /// <item> Cannot unlock a set if you were not the one who locked it. (maybe add exceptions to this later idk) </item>
    /// <item> Time To lock cannot exceed the player's set max allowed lock time. </item>
    /// </list>
    /// If any of these are violated, do not push update to server.
    /// </para>
    /// <para><b> Be Careful that you do not introduce feedback loops when updating changes. </b></para>
    /// </summary>
    Task UserPushDataWardrobe(UserCharaWardrobeDataMessageDto dto);

    /// <summary>
    /// Pushes a player's alias data to the server, updating the userpair of the client that should be updated.
    /// <para> Information pushed includes the list of triggers the client has set for the corresponding user. </para>
    /// <para> The information is pushed to the recipient user whenever the clients trigger list is modified in any way, keeping them up to date. </para>
    /// </summary>
    Task UserPushDataAlias(UserCharaAliasDataMessageDto dto);

    /// <summary>
    /// Pushes data relevant to the toybox module to the server, updating other paired clients.
    /// <para> Pushes generic summarized data about the list of patterns, triggers, and alarms. </para>
    /// </summary>
    Task UserPushDataToybox(UserCharaToyboxDataMessageDto dto);
    #endregion Client Push Own Data Updates

    #region Client Update Other UserPair Data
    /// <summary>
    /// Pushes an updated version of the pair's current IPC data to the server.
    /// <para> Once server handles update, it is pushed to all pairs of the pair, including us. </para>
    /// <para> (Mainly for injecting new modifications from stored data) </para>
    /// </summary>
    Task UserPushPairDataIpcUpdate(OnlineUserCharaIpcDataDto dto);

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

    /* ----- Yes there is intentionally no PushAliasData here. Nobody except the client of the Alias List should be able to modify it. ----- */

    /// <summary>
    /// Pushes an updated version of a pair's Toybox DTO.
    /// <para> Pushes an updated version of the information from a pairs toybox data. </para>
    /// <para> This is called whenever we toggle a pairs trigger, alarm, or pattern. </para>
    /// </summary>
    Task UserPushPairDataToyboxUpdate(OnlineUserCharaToyboxDataDto dto);
    #endregion Client Update Other UserPair Data

    #region Permission Updates
    /// <summary>
    /// Pushes the collective permissions of edit access, unique pair perms, and global perms to another pair.
    /// <para> 
    /// This should only be called upon setting a preset for a player, to avoid spamming the server.
    /// </para>
    /// </summary>
    Task UserPushAllPerms(UserPairUpdateAllPermsDto dto);

    /// <summary>
    /// Push an update of your own global permissions to the server, and update other pairs with your change.
    /// <para> Manages the synchronization of pairs viewing on one another permissions that are set. </para>
    /// </summary>
    Task UserUpdateOwnGlobalPerm(UserGlobalPermChangeDto dto);

    /// <summary>
    /// Push an update of your own unique permissions for a specific pair to the server. 
    /// <para> This change is also pushed to the pair you made it for. </para>
    /// </summary>
    Task UserUpdateOwnPairPerm(UserPairPermChangeDto dto);

    /// <summary>
    /// Push an update of your own access permissions for a specific pair to the server.
    /// <para> This change is also pushed to the pair you made it for. </para>
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
