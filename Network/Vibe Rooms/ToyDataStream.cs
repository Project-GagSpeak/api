using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.VibeRoom;

// Recieving datastream from server
[MessagePackObject(keyAsPropertyName: true)]
public record ToyDataStreamResponse(MotorStream[] DeviceMotorData, long Timestamp);


// For sending the same vibration data to multiple users.
[MessagePackObject(keyAsPropertyName: true)]
public record ToyDataStream(UserDeviceStream[] DataStream, long Timestamp);


[MessagePackObject(keyAsPropertyName: true)]
public record UserDeviceStream(UserData User, MotorStream[] MotorData);


// Might not need the Motor enum with the Idx?
[MessagePackObject(keyAsPropertyName: true)]
public record MotorStream(ToyBrandName Toy, ToyMotor Motor, int MotorIdx, double[] Stream);
