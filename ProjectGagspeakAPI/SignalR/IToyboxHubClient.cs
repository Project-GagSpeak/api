using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.Connection;
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
    void OnPrivateRoomJoined(Action<RoomInfoDto> act); // whenever you joined a room.
    void OnPrivateRoomOtherUserJoined(Action<RoomParticipantDto> act); // Recieved when another user joins the room.
    void OnPrivateRoomOtherUserLeft(Action<RoomParticipantDto> act); // Recieved when another user leaves the room.
    void OnPrivateRoomUpdateUser(Action<RoomParticipantDto> act);
    void OnPrivateRoomMessage(Action<RoomMessageDto> act); // Recieves a message from another user in the room.
    void OnPrivateRoomReceiveUserDevice(Action<UserCharaDeviceInfoMessageDto> act); // Receives device info from another connected user.
    void OnPrivateRoomDeviceUpdate(Action<UpdateDeviceDto> act); // Updates the clients device with the new update.
    void OnPrivateRoomClosed(Action<string> act); // Informs the client that the room has been closed.
}
