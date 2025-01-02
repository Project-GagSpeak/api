using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;

public static class PermChangeIdentifier
{
    public static InteractionType GetHardcoreChange(this UserGlobalPermissions currentPermissions, string changedPermission, object changedValue)
    {
        switch (changedPermission)
        {
            case nameof(UserGlobalPermissions.ForcedFollow):
                return currentPermissions.ForcedFollow != (string)changedValue ?
                       InteractionType.ForcedFollow: InteractionType.None;
            case nameof(UserGlobalPermissions.ForcedEmoteState):
                return currentPermissions.ForcedEmoteState != (string)changedValue ?
                       InteractionType.ForcedEmoteState : InteractionType.None;
            case nameof(UserGlobalPermissions.ForcedStay):
                return currentPermissions.ForcedStay != (string)changedValue ?
                       InteractionType.ForcedStay : InteractionType.None;
            case nameof(UserGlobalPermissions.ForcedBlindfold):
                return currentPermissions.ForcedBlindfold != (string)changedValue ?
                       InteractionType.ForcedBlindfold : InteractionType.None;
            case nameof(UserGlobalPermissions.ChatBoxesHidden):
                return currentPermissions.ChatBoxesHidden != (string)changedValue ?
                       InteractionType.ForcedChatVisibility : InteractionType.None;
            case nameof(UserGlobalPermissions.ChatInputHidden):
                return currentPermissions.ChatInputHidden != (string)changedValue ?
                       InteractionType.ForcedChatInputVisibility : InteractionType.None;
            case nameof(UserGlobalPermissions.ChatInputBlocked):
                return currentPermissions.ChatInputBlocked != (string)changedValue ?
                       InteractionType.ForcedChatInputBlock : InteractionType.None;
            default:
                return InteractionType.None;
        }
    }


}
