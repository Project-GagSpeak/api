using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.Sharehub;

[MessagePackObject(keyAsPropertyName: true)]
public record MoodleUploadDto(string AuthorName, HashSet<string> Tags, MoodlesStatusInfo MoodleInfo);


[MessagePackObject(keyAsPropertyName: true)]
public record PatternUploadDto(ServerPatternInfo patternInfo, string base64PatternData);
