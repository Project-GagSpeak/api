using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// Message DTO Holds the list of triggers that the sender has set for the recipient user.
/// </summary>
/// <param name="RecipientUser"> The User receiving this updated information. </param>
/// <param name="AliasData"> Contains the alias list of triggers that the sender has set for the recipient user. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaAliasDataMessageDto(UserData RecipientUser, CharacterAliasData AliasData);
