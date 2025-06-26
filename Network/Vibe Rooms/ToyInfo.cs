using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

// Maybe Change this to some common shared Data object for device properties.
[MessagePackObject(keyAsPropertyName: true)]
public record ToyInfo(string Name, int DeviceIdx, Motor[] VibeMotors, Motor[] RotMotors);
