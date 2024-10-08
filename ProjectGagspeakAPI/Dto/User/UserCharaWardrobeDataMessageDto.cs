﻿using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// DTO for handling the updating of our own data to our online user pairs.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaWardrobeDataMessageDto(List<UserData> Recipients, CharacterWardrobeData WardrobeData, DataUpdateKind UpdateKind);
