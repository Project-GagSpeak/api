using MessagePack;

namespace GagspeakAPI.Dto.Sharehub;

/// <summary>
///     The Loci we are attempting to upload.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record LociStatusUpload(string AuthorName, HashSet<string> Tags, LociStatusInfo LociInfo);
