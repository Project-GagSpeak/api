using Gagspeak.API.Data;
using GagSpeak.API.Data.Character;
using GagSpeak.API.Data.Permissions;
using GagSpeak.API.Dto.Permissions;
using MessagePack;

namespace GagSpeak.API.Dto.Connection;

/// <summary>
/// Much more simpler connection dto for the toybox server.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ToyboxConnectionDto(UserData User)
{
    public int ServerVersion { get; set; } // version of the gagspeak API
}
