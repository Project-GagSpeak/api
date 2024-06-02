using Gagspeak.API.Data;
using MessagePack;

namespace Gagspeak.API.Dto;

/// <summary>
/// The datatransfer object storing the relavent information of the connected user.
/// <para> UserData used as input, which indicates the permission levels of a spesified user </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionDto(UserData User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0); // The current version of the client
    public int ServerVersion { get; set; }                            // The version of the gagspeak server
}
