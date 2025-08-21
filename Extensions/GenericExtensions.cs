using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;

// Idk why this exists but too lazy to fix it.
public static class GenericExtensions
{
    public static HcAttribute ToHcAttribute(this InteractionType type)
        => type switch
        {
            InteractionType.LockedFollow => HcAttribute.Follow,
            InteractionType.LockedEmoteState => HcAttribute.EmoteState,
            InteractionType.Confinement => HcAttribute.Confinement,
            InteractionType.Imprisonment => HcAttribute.Imprisonment,
            InteractionType.ChatBoxHiding => HcAttribute.HiddenChatBox,
            InteractionType.ChatInputHiding => HcAttribute.HiddenChatInput,
            InteractionType.ChatInputBlocking => HcAttribute.BlockedChatInput,
            InteractionType.HypnosisEffect => HcAttribute.HypnoticEffect,
            _ => HcAttribute.Unknown
        };
}
