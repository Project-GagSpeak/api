﻿using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.Enum;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// DTO for handling the updating of our own data to our online user pairs.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaAppearanceDataMessageDto(List<UserData> Recipients, CharacterAppearanceData AppearanceData, DataUpdateKind UpdateKind);
