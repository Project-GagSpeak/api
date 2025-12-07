using MessagePack;

namespace GagspeakAPI.Dto.Sharehub;

/// <summary>
///     The Moodle we are attempting to upload.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodleUpload(string AuthorName, HashSet<string> Tags, MoodlesStatusInfo MoodleInfo);
