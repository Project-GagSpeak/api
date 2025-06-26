using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> Contains Info about how a hypnotic action should be executed. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record HypnoticAction(UserData User, int Duration, HypnoticEffect Effect);
