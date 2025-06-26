using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.VibeRoom;

// Not going to bother organizing this since it will all be changed soon anyways.

// Recieving datastream from server
[MessagePackObject(keyAsPropertyName: true)]
public record ToyDataStreamResponse(MotorStream[] DeviceMotorData, long Timestamp);


// For sending the same vibration data to multiple users.
[MessagePackObject(keyAsPropertyName: true)]
public record ToyDataStream(UserDeviceStream[] DataStream, long Timestamp);


[MessagePackObject(keyAsPropertyName: true)]
public record UserDeviceStream(UserData User, MotorStream[] MotorData);


// Contains the data stream of 2 seconds of data.
[MessagePackObject(keyAsPropertyName: true)]
public record MotorStream(int DeviceIdx, MotorType Type, int MotorIdx, byte[] DataStream);

public enum MotorType
{
    Vibrate,
    Rotate
}

