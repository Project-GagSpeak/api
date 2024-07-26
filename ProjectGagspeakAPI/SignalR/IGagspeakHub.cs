using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.UserPair;
using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.User;

namespace GagspeakAPI.SignalR;

/// <summary> The interface for the GagspeakHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IGagspeakHub
{
    const int ApiVersion = 3;               // First version of the API
    const string Path = "/gagspeak";       // Path to the API on the hosted server

    Task<bool> CheckMainClientHealth();         // Check if the client is healthy

    /* ----------------- Task methods called upon by server and sent to clients ----------------- */
    Task Client_ReceiveServerMessage(MessageSeverity messageSeverity, string message); /* General Server message that is sent to client with various severities */
    Task Client_ReceiveHardReconnectMessage(MessageSeverity messageSeverity, string message, ServerState state);
    Task Client_UpdateSystemInfo(SystemInfoDto systemInfo); /* Updates the client with the servers current system information */
    Task Client_UserAddClientPair(UserPairDto dto); /* sends to a connected user to add the specified user to their pair list */
    Task Client_UserRemoveClientPair(UserDto dto); /* sends to a connected user to remove the specified user from their pair list */
    Task Client_UpdateUserIndividualPairStatusDto(UserIndividualPairStatusDto dto); /* informs a client of a paired user's updated individual pair status */

    // sends a message to client informing them to update their pair permissions (composite) [ See variants for smaller updates ]
    /* Client_UserUpdateSelf == The callback returned from server to the client caller. Will contain UID of person's perms to update if successful.*/
    Task Client_UserUpdateSelfPairPermsGlobal(UserGlobalPermChangeDto dto);
    Task Client_UserUpdateSelfPairPerms(UserPairPermChangeDto dto);
    Task Client_UserUpdateSelfPairPermAccess(UserPairAccessChangeDto dto);
    /* Client_UserUpdateOther == Callback returned from server to the other user who should update their permissions. */
    Task Client_UserUpdateOtherAllPairPerms(UserPairUpdateAllPermsDto dto); /* special case for updating all permissions at once */
    Task Client_UserUpdateOtherPairPermsGlobal(UserGlobalPermChangeDto dto);// this can update either the user self, or another paired user. It's all based on the UserData in the Dto
    Task Client_UserUpdateOtherPairPerms(UserPairPermChangeDto dto);        // read above
    Task Client_UserUpdateOtherPairPermAccess(UserPairAccessChangeDto dto); // read above

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    Task Client_UserReceiveCharacterDataComposite(OnlineUserCharaCompositeDataDto dto); /* informs a client of a users login, sending latest data (COMPOSITE) */
    Task Client_UserReceiveCharacterDataIpc(OnlineUserCharaIpcDataDto dto); /* informs a client of a users login, sending latest data (IPC ONLY) */
    Task Client_UserReceiveCharacterDataAppearance(OnlineUserCharaAppearanceDataDto dto); /* informs a client of a users login, sending latest data (APPEARANCE ONLY) */
    Task Client_UserReceiveCharacterDataWardrobe(OnlineUserCharaWardrobeDataDto dto); /* informs a client of a users login, sending latest data (WARDROBE ONLY) */
    Task Client_UserReceiveCharacterDataAlias(OnlineUserCharaAliasDataDto dto); /* informs a client of a users login, sending latest data (ALIAS ONLY) */
    Task Client_UserReceiveCharacterDataPattern(OnlineUserCharaPatternDataDto dto); /* informs a client of a users login, sending latest data (PATTERN ONLY) */
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    Task Client_UserSendOffline(UserDto dto); /* Sent to client who should be informed of another paired user's logout */
    Task Client_UserSendOnline(OnlineUserIdentDto dto); /* inform client of a paired user's login to servers. No CharacterData attached */
    Task Client_UserUpdateProfile(UserDto dto); /* informs a client that a connected user has updated their profile */
    Task Client_DisplayVerificationPopup(VerificationDto dto); /* Displays a verification popup to this client. Triggered by discord bot */


    /* ----------------- Task for grabbing a users current connectionDto ----------------- */
    Task<ConnectionDto> GetConnectionDto(); // Get the connection details of the client to the serve

    /* ----------------- Task methods called upon by clients and sent to the server ----------------- */
    Task UserAddPair(UserDto user); // add another user as a pair to the users paired list
    Task UserRemovePair(UserDto userDto); // remove a user from the paired list of the client
    Task UserDelete(); // delete this users account from the servers database
    Task<List<OnlineUserIdentDto>> UserGetOnlinePairs(); // get the current online users paired with this client
    Task<List<UserPairDto>> UserGetPairedClients(); // get the current paired users of this client
    Task<UserProfileDto> UserGetProfile(UserDto dto); // get the profile of a user
    Task UserSetProfile(UserProfileDto userMiniProfile); // set the profile of the client

    /* ***************** PERMISSION SENDING SECTION ***************** */
    Task UserPushData(UserCharaCompositeDataMessageDto dto); // push clients data to the server, updating self & paired online clients (composite)
    Task UserPushDataIpc(UserCharaIpcDataMessageDto dto); // push clients data to the server, updating self & paired online clients (ipc ONLY)
    Task UserPushDataAppearance(UserCharaAppearanceDataMessageDto dto); // push clients data to the server, updating self & paired online clients (appearance ONLY)
    Task UserPushDataWardrobe(UserCharaWardrobeDataMessageDto dto); // push clients data to the server, updating self & paired online clients (wardrobe ONLY)
    Task UserPushDataAlias(UserCharaAliasDataMessageDto dto); // push clients data to the server, updating self & paired online clients (alias ONLY)
    Task UserPushDataPattern(UserCharaPatternDataMessageDto dto); // push clients data to the server, updating self & paired online clients (pattern ONLY)

    // for now, i will generalize the permissions into 3 sections, but if this becomes a problem later,
    // split them into subsections like we tried before.
    Task UserUpdateOwnGlobalPerm(UserGlobalPermChangeDto dto); // update a global permission of the client caller (UserData == UserUID)
    Task UserUpdateOwnPairPerm(UserPairPermChangeDto dto); // update a pair permission of the client caller (UserData == UserUID)
    Task UserUpdateOwnPairPermAccess(UserPairAccessChangeDto dto); // updates an edit access permission of the client caller. Caller must equal User affected.
    Task UserUpdateOtherGlobalPerm(UserGlobalPermChangeDto dto); // update a global permission of another paired user (UserData == paired user)
    Task UserUpdateOtherPairPerm(UserPairPermChangeDto dto); // update a pair permission of another paired user (UserData == paired user)

}
