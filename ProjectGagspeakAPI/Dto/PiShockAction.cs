using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto;

/// <summary> Updates devices of all users in a group that is not the caller. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PiShockAction(UserData User, int OpCode, int Intensity, int Duration);
