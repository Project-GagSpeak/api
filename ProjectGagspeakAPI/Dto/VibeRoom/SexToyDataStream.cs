using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.VibeRoom;

// Recieving datastream from server
[MessagePackObject(keyAsPropertyName: true)]
public record SexToyDataStreamCallbackDto(MotorStream[] DeviceMotorData, long Timestamp);


// For sending the same vibration data to multiple users.
[MessagePackObject(keyAsPropertyName: true)]
public record SexToyDataStreamDto(UserDeviceStream[] DataStream, long Timestamp);


[MessagePackObject(keyAsPropertyName: true)]
public record UserDeviceStream(UserData User, MotorStream[] MotorData);


// Contains the data stream of 2 seconds of data.
[MessagePackObject(keyAsPropertyName: true)]
public record MotorStream(int DeviceIdx, MotorType Type, int MotorIdx, byte[] DataStream);
public enum MotorType { Vibrate, Rotate }

