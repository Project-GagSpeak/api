using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Data.Struct;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;

public static class GlobalPermExtensions
{
    public static readonly string[] StandIdleList = { "0", "91", "92", "107", "108", "218", "219" };
    public static readonly string[] SitIdList = { "50", "95", "96", "254", "255" };
    public static readonly string[] GroundSitIdList = { "52", "97", "98", "117" };
    public static readonly string[] AnySitIdList = SitIdList.Concat(GroundSitIdList).ToArray();

    public static bool IsPermDevotional(this string hardcorePermString) => hardcorePermString.EndsWith(Constants.DevotedString);
    public static string HardcorePermUID(this string hardcorePermString) => hardcorePermString.Replace(Constants.DevotedString, string.Empty);

    public static bool IsFollowing(this UserGlobalPermissions p) => !p.ForcedFollow.NullOrEmpty();
    public static bool CanToggleFollow(this UserGlobalPermissions p, string uid)
    {
        if (p.ForcedFollow.NullOrEmpty() || !p.ForcedFollow.IsPermDevotional()) return true;
        return p.ForcedFollow.HardcorePermUID() == uid; // Check because it's PairLocked
    }

    public static bool IsGroundSitting(this UserGlobalPermissions p) => !p.ForcedEmoteState.NullOrEmpty() &&
        p.ForcedEmoteState.Split('|') is { Length: >= 2 } parts && GroundSitIdList.Contains(parts[1]);
    public static bool IsSitting(this UserGlobalPermissions p) =>
        p.ForcedEmoteState.Split('|') is { Length: >= 2 } parts && SitIdList.Contains(parts[1]);
    public static bool IsAnySitting(this UserGlobalPermissions p) =>
        p.ForcedEmoteState.Split('|') is { Length: >= 2 } parts && AnySitIdList.Contains(parts[1]);
    public static string EmoteStateUID(this UserGlobalPermissions p) => p.ForcedEmoteState.Split('|')[0];
    public static bool CanToggleEmoteState(this UserGlobalPermissions p, string uid)
    {
        if (p.ForcedEmoteState.NullOrEmpty() || !p.ForcedEmoteState.IsPermDevotional()) return true;
        return p.ForcedEmoteState.HardcorePermUID() == uid;
    }
    public static EmoteState ExtractEmoteState(this UserGlobalPermissions p)
    {
        // Handle empty case.
        if (string.IsNullOrEmpty(p.ForcedEmoteState))
            return new EmoteState();

        // Handle valid case.
        var parts = p.ForcedEmoteState.Split('|');
        return new EmoteState(parts[0], ushort.Parse(parts[1]), byte.Parse(parts[2]), parts.Length > 3);
    }


    public static bool IsStaying(this UserGlobalPermissions p) => !p.ForcedStay.NullOrEmpty();
    public static bool CanToggleStay(this UserGlobalPermissions p, string uid)
    {
        if (p.ForcedStay.NullOrEmpty() || !p.ForcedStay.IsPermDevotional()) return true;
        return p.ForcedStay.HardcorePermUID() == uid;
    }

    public static bool IsChatHidden(this UserGlobalPermissions p) => !p.ChatBoxesHidden.NullOrEmpty();
    public static bool CanToggleChatHidden(this UserGlobalPermissions p, string uid)
    {
        if (p.ChatBoxesHidden.NullOrEmpty() || !p.ChatBoxesHidden.IsPermDevotional()) return true;
        return p.ChatBoxesHidden.HardcorePermUID() == uid;
    }

    public static bool IsChatInputHidden(this UserGlobalPermissions p) => !p.ChatInputHidden.NullOrEmpty();
    public static bool CanToggleChatInputHidden(this UserGlobalPermissions p, string uid)
    {
        if (p.ChatInputHidden.NullOrEmpty() || !p.ChatInputHidden.IsPermDevotional()) return true;
        return p.ChatInputHidden.HardcorePermUID() == uid;
    }

    public static bool IsChatInputBlocked(this UserGlobalPermissions p) => !p.ChatInputBlocked.NullOrEmpty();
    public static bool CanToggleChatInputBlocked(this UserGlobalPermissions p, string uid)
    {
        if (p.ChatInputBlocked.NullOrEmpty() || !p.ChatInputBlocked.IsPermDevotional()) return true;
        return p.ChatInputBlocked.HardcorePermUID() == uid;
    }

    public static InteractionType PermChangeType(this UserGlobalPermissions p, string propertyName, string newValue)
    {
        return propertyName switch
        {
            nameof(UserGlobalPermissions.ForcedFollow) => p.ForcedFollow != newValue ? InteractionType.ForcedFollow : InteractionType.None,
            nameof(UserGlobalPermissions.ForcedEmoteState) => p.ForcedEmoteState != newValue ? InteractionType.ForcedEmoteState : InteractionType.None,
            nameof(UserGlobalPermissions.ForcedStay) => p.ForcedStay != newValue ? InteractionType.ForcedStay : InteractionType.None,
            nameof(UserGlobalPermissions.ChatBoxesHidden) => p.ChatBoxesHidden != newValue ? InteractionType.ForcedChatVisibility : InteractionType.None,
            nameof(UserGlobalPermissions.ChatInputHidden) => p.ChatInputHidden != newValue ? InteractionType.ForcedChatInputVisibility : InteractionType.None,
            nameof(UserGlobalPermissions.ChatInputBlocked) => p.ChatInputBlocked != newValue ? InteractionType.ForcedChatInputBlock : InteractionType.None,
            _ => InteractionType.ForcedPermChange,
        };
    }
}
