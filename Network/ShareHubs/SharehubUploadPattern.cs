using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.Sharehub;

/// <summary>
///     The Pattern we are attempting to upload.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record SharehubUploadPattern(SharehubPattern PatternInfo, string PatternDataBase64);
