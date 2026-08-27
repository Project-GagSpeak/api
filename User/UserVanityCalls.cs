using MessagePack;

namespace GagspeakAPI.User;

/// <summary>
///   Updates the UserData's customizable data. <br/>
///   Aliases can be changed by everyone, but all other
///   fields are supporter-only.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserDataUpdate(string? NewAlias, string? VanityName, uint? NameColor, uint? NameGlowColor);
