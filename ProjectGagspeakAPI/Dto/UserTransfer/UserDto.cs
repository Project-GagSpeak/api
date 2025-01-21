using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);