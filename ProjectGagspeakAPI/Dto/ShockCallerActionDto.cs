using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto;

/// <summary>
/// Updates devices of all users in a group that is not the caller.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ShockCollarActionDto(UserData User, int OpCode, int Intensity, int Duration);
