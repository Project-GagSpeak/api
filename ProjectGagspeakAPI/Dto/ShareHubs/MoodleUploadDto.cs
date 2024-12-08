using GagspeakAPI.Dto.User;
using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.Patterns;

/// <summary>
/// Uploads a pattern to the server.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodleUploadDto(UserData Publisher, ServerMoodleInfo MoodleInfo) : UserDto(Publisher);
