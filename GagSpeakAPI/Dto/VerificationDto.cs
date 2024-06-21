using MessagePack;

namespace Gagspeak.API.Dto;

// The datatransfer object that tracks the current number of connected online users on the server.
[MessagePackObject(keyAsPropertyName: true)]
public record VerificationDto
{
    public string VerificationCode { get; set; } // the verification code for a user
}