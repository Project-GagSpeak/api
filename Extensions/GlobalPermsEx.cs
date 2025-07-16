using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.Extensions;

public static class GlobalPermsEx
{
    private static readonly string[] SitIdList = { "50", "95", "96", "254", "255" };
    private static readonly string[] GroundSitIdList = { "52", "97", "98", "117" };
    private static readonly string[] AnySitIdList = SitIdList.Concat(GroundSitIdList).ToArray();

    private static bool IsDevotional(string s) => s.EndsWith(Constants.DevotedString);
    private static string PermEnactor(string s) => s.Replace(Constants.DevotedString, string.Empty);

    public static bool HcFollowState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ForcedFollow);
    public static string HcFollowEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.ForcedFollow);
    public static bool HcFollowIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.ForcedFollow);
    public static bool CanChangeHcFollow(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ForcedFollow) || !IsDevotional(p.ForcedFollow)) return true;
        return kinksterUid.Equals(PermEnactor(p.ForcedFollow));
    }

    public static bool HcEmoteIsGroundSitting(this IReadOnlyGlobalPerms p) => p.ForcedEmoteState.Split('|') is { Length: >= 2 } pt && GroundSitIdList.Contains(pt[1]);
    public static bool HcEmoteIsSitting(this IReadOnlyGlobalPerms p) => p.ForcedEmoteState.Split('|') is { Length: >= 2 } pt && SitIdList.Contains(pt[1]);
    public static bool HcEmoteIsAnySitting(this IReadOnlyGlobalPerms p) => p.ForcedEmoteState.Split('|') is { Length: >= 2 } pt && AnySitIdList.Contains(pt[1]); 
    public static bool HcEmoteState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ForcedEmoteState);
    public static string HcEmoteEnactor(this IReadOnlyGlobalPerms p) => p.ForcedEmoteState.Split('|')[0];
    public static bool HcEmoteIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.ForcedEmoteState);
    public static bool CanChangeHcEmote(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ForcedEmoteState) || !IsDevotional(p.ForcedEmoteState)) return true;
        return kinksterUid.Equals(p.ForcedEmoteState.Split('|')[0]);
    }

    public static bool HcStayState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ForcedStay);
    public static string HcStayEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.ForcedStay);
    public static bool HcStayIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.ForcedStay);
    public static bool CanChangeHcStay(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ForcedStay) || !IsDevotional(p.ForcedStay)) return true;
        return kinksterUid.Equals(PermEnactor(p.ForcedStay));
    }

    public static bool HcChatVisState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ChatBoxesHidden);
    public static string HcChatVisEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.ForcedFollow);
    public static bool HcChatVisIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.ChatBoxesHidden);
    public static bool CanChangeHcChatVis(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ChatBoxesHidden) || !IsDevotional(p.ChatBoxesHidden)) return true;
        return kinksterUid.Equals(PermEnactor(p.ChatBoxesHidden));
    }

    public static bool HcChatInputVisState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ChatInputHidden);
    public static string HcChatInputVisEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.ChatInputHidden);
    public static bool HcChatInputVisIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.ChatInputHidden);
    public static bool CanChangeHcChatInputVis(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ChatInputHidden) || !IsDevotional(p.ChatInputHidden)) return true;
        return kinksterUid.Equals(PermEnactor(p.ChatInputHidden));
    }

    public static bool HcBlockChatInputState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ChatInputBlocked);
    public static string HcBlockChatInputEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.ChatInputBlocked);
    public static bool HcBlockChatInputDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.ChatInputBlocked);
    public static bool CanChangeHcBlockChatInput(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ChatInputBlocked) || !IsDevotional(p.ChatInputBlocked)) return true;
        return kinksterUid.Equals(PermEnactor(p.ChatInputBlocked));
    }

    public static bool HcHypnoState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.HypnosisCustomEffect);
    public static string HcHypnoEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.HypnosisCustomEffect);
    public static bool HcHypnoDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.HypnosisCustomEffect);
    public static bool CanChangeHcHypno(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.HypnosisCustomEffect) || !IsDevotional(p.HypnosisCustomEffect)) return true;
        return kinksterUid.Equals(PermEnactor(p.HypnosisCustomEffect));
    }
}
