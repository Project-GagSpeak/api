using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record ChatReport(UserData User, string ReportReason, string ChatCompressed) : KinksterBase(User);
