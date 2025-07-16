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
public record UserDeviceStream(UserData User, DeviceStream[] devices);

[MessagePackObject(keyAsPropertyName: true)]
public record DeviceStream(ToyBrandName Toy, MotorStream[] MotorData);

[MessagePackObject(keyAsPropertyName: true)]
public record MotorStream(ToyMotor Motor, uint MotorIdx, double[] Stream);
