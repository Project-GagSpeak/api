using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Loci we are attempting to upload.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SharehubUploadLociStatus(string AuthorName, HashSet<string> Tags, LociStatusStruct Status);

// Allow for presets and events down the line here.
