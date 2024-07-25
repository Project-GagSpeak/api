using GagspeakAPI.Data.Enum;
using GagspeakAPI.Dto.Connection;
using GagspeakAPI.Dto.Toybox;

namespace GagspeakAPI.SignalR;

/// <summary> The interface for the ToyboxHub
/// <para>
/// This interface is the server end of the SignalR calls made by the client.
/// </para>
/// </summary>
public interface IToyboxHubClient : IToyboxHub
{
    void OnReceiveToyboxServerMessage(Action<MessageSeverity, string> act); // send message to client
    void OnReceiveToyboxServerMessage(MessageSeverity messageSeverity, string message);
    void OnUserReceiveRoomInvite(Action<RoomInviteDto> act);
    void OnUserJoinedRoom(Action<RoomInviteDto> act);
    void OnUserRecievedRoomMessage(Action<RoomMessageDto> act);
    void OnUserDeviceInfo(Action<DeviceInfoDto> act);
    void OnUserDeviceUpdate(Action<UpdateDeviceDto> act);
}
