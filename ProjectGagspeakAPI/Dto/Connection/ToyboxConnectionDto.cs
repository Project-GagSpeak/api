using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Dto.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// Much more simpler connection dto for the toybox server.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ToyboxConnectionDto(UserData User)
{
    public int ServerVersion { get; set; } // version of the gagspeak API
}
