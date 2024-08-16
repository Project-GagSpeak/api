using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;


/// <summary>
/// Online notifier for bidirectionally paired users who have puppeteer enabled that go online.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserPuppeteerDto(UserData User, string CharaInfo) : UserDto(User);
