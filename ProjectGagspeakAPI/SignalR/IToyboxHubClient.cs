using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.Toybox;
using GagspeakAPI.Dto.User;

namespace GagspeakAPI.SignalR;

/// <summary> The interface for the ToyboxHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IToyboxHubClient : IToyboxHub
{
    void OnReceiveToyboxServerMessage(Action<MessageSeverity, string> act); // send message to client
    void OnUserReceiveRoomInvite(Action<RoomInviteDto> act); // Receives a room invite from another user.
    void OnUserJoinedRoom(Action<RoomInfoDto> act); // whenever you joined a room.
    void OnOtherUserJoinedRoom(Action<UserDto> act); // Recieved when another user joins the room.
    void OnOtherUserLeftRoom(Action<UserDto> act); // Recieved when another user leaves the room.
    void OnUserReceiveRoomMessage(Action<RoomMessageDto> act); // Recieves a message from another user in the room.
    void OnUserReceiveDeviceInfo(Action<UserCharaDeviceInfoMessageDto> act); // Receives device info from another connected user.
    void OnUserDeviceUpdate(Action<UpdateDeviceDto> act); // Updates the clients device with the new update.
    void OnReceiveRoomClosedMessage(Action<string> act); // Informs the client that the room has been closed.
}