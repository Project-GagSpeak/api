using MessagePack;

namespace GagspeakAPI.Dto.Connection;

// The datatransfer object that tracks the current number of connected online users on the server.
[MessagePackObject(keyAsPropertyName: true)]
public record VerificationDto(string VerificationCode = "");
