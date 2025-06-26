using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated Toybox Data after an affected Identifier made changes to it.
/// </summary>
/// <param name="Recipients"> the Kinkster this unique alias was for. </param>
/// <param name="LatestActiveItems"> The latest active items in the toybox prior to the change. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientToyboxUpdate(List<UserData> Recipients, CharaToyboxData LatestActiveItems, DataUpdateType Type)
{
    public Guid AffectedIdentifier { get; init; } = Guid.Empty;
}
