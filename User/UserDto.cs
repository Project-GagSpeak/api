using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserDto(UserData User);

[MessagePackObject(keyAsPropertyName: true)]
public record UserListDto(List<UserData> Users);
