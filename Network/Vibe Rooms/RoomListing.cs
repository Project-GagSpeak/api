using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     A listing for a public room that can be joined if space is available.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomListing(string Name, int MaxParticipants)
{
    public int CurrentParticipants { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public string[] Tags { get; init; } = [];
}
