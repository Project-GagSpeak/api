using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.VibeRoom;

[MessagePackObject(keyAsPropertyName: true)]
public record VibeRoomKinkster(UserData User, string DisplayName);

[MessagePackObject(keyAsPropertyName: true)]
public record VibeRoomKinksterFullDto(UserData User, string DisplayName) : VibeRoomKinkster(User, DisplayName)
{
    public bool IsHost { get; init; } = false;
    public List<VibeRoomKinkster> AllowedKinksters { get; set; } = new List<VibeRoomKinkster>();
    public List<DeviceInfo> Devices { get; set; } = new List<DeviceInfo>();
}

[MessagePackObject]
public record struct DeviceInfo(string DeviceName, int DeviceIndex)
{
    [Key(0)] public string DeviceName { get; init; } = DeviceName;
    [Key(1)] public int DeviceIndex { get; init; } = DeviceIndex;
    [Key(2)] public List<Motor> VibrateMotors { get; set; }
    [Key(3)] public List<Motor> RotateMotors { get; set; }
    [Key(4)] public double BatteryLevel { get; set; }
}

[MessagePackObject]
public record struct Motor(int MotorIndex, int StepCount)
{
    [Key(0)] public int MotorIndex { get; init; } = MotorIndex;
    [Key(1)] public int StepCount { get; init; } = StepCount;
    [Key(2)] public double Interval => StepCount > 0 ? 1.0 / StepCount : 0;
}
