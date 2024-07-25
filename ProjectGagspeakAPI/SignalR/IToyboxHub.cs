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
    Task Client_UserJoinedRoom(RoomInviteDto dto); // recieved when a user joins your room.
    Task Client_UserRecievedRoomMessage(RoomMessageDto dto); // Recieves a message from another user in the room.
    Task Client_UserDeviceInfo(DeviceInfoDto dto); // Receives device info from another connected user.
    Task Client_UserDeviceUpdate(UpdateDeviceDto dto); // Updates the clients device with the new update.

    /************** CALLERS **********/
    Task UserCreateNewRoom(RoomCreateDto dto); // Creates a new room with the given name.
    Task UserRoomInvite(RoomInviteDto dto); // Sends an invite to a room to the given user.
    Task UserJoinRoom(string roomName); // Joins the user to the given room.
    Task UserSendMessageToRoom(RoomMessageDto dto); // Sends a message to the room.
    Task UserRequestDeviceInfo(UserDto dto); // Requests the device info of the given user.
    Task UserUpdateDevice(UpdateDeviceDto dto); // Updates the device of the user.
    Task UserLeaveRoom(); // Leaves the room they are in.
}
