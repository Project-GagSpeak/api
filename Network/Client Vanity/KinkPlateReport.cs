using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record KinkPlateReport(UserData User, string ReportReason) : KinksterBase(User);
