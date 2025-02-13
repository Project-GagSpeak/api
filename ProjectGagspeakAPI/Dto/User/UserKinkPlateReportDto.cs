using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserKinkPlateReportDto(UserData User, string ProfileReport) : UserDto(User);
