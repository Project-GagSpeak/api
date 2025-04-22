using GagspeakAPI.Data;
using GagspeakAPI.Data.Interfaces;
using MessagePack;

namespace GagspeakAPI.Dto;

/// <summary> Contains Info about how a hypnotic action should be executed. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record HypnoticAction(UserData User, int Duration, HypnoticEffect Effect);
