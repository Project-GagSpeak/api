using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record ProfileReport(UserData User, string ReportReason) : KinksterBase(User);
