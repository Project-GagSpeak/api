using GagspeakAPI.Data;
using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.Permissions;
using GagspeakAPI.Dto.Toybox;
using GagspeakAPI.Dto.UserPair;

namespace GagspeakAPI.SignalR;

/// <summary> The interface for the ToyboxHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IToyboxHub
{
    const string Path = "/toybox";       // Path to the API on the hosted server

    Task<bool> CheckToyboxClientHealth(); // REQUIRED to stay connected on redi's AKA maintain a connection.

    Task<ToyboxConnectionDto> GetToyboxConnectionDto(); // Get the connection details of the client to the serve
    
    /************ CALLBACKS ***************/
    Task Client_ReceiveToyboxServerMessage(MessageSeverity messageSeverity, string message);
    Task Client_UserReceiveRoomInvite(RoomInviteDto dto); // Receives a room invite from another user.
    Task Client_UserJoinedRoom(RoomInfoDto dto); // whenever you joined a room.
    Task Client_OtherUserJoinedRoom(RoomParticipantDto dto); // Recieved when another user joins the room.
    Task Client_OtherUserLeftRoom(RoomParticipantDto dto); // Recieved when another user leaves the room.
    Task Client_UserReceiveRoomMessage(RoomMessageDto dto); // Recieves a message from another user in the room.
    Task Client_UserReceiveDeviceInfo(UserCharaDeviceInfoMessageDto dto); // Receives device info from another connected user.
    Task Client_UserDeviceUpdate(UpdateDeviceDto dto); // Updates the clients device with the new update.
    Task Client_ReceiveRoomClosedMessage(string roomName); // Informs the client that the room has been closed.

    /************** CALLERS **********/
    Task UserCreateNewRoom(RoomCreateDto dto); // Creates a new room with the given name.
    Task UserRoomInvite(RoomInviteDto dto); // Sends an invite to a room to the given user.
    Task UserJoinRoom(RoomParticipantDto dto); // Joins the user to the given room.
    Task UserSendMessageToRoom(RoomMessageDto dto); // Sends a message to the room.
    Task UserPushDeviceInfo(UserCharaDeviceInfoMessageDto dto); // Requests the device info of the given user.
    Task UserUpdateDevice(UpdateDeviceDto dto); // Updates the device of the user.
    Task UserUpdateGroupDevices(UpdateDeviceDto dto); // Updates the devices of the group.
    Task UserLeaveRoom(); // Leaves the room they are in.
}
