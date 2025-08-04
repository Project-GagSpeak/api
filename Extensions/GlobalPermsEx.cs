using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.Extensions;

public static class GlobalPermsEx
{
    private static readonly string[] SitIdList = { "50", "95", "96", "254", "255" };
    private static readonly string[] GroundSitIdList = { "52", "97", "98", "117" };
    private static readonly string[] AnySitIdList = SitIdList.Concat(GroundSitIdList).ToArray();

    public static bool IsDevotional(string s) => s.EndsWith(Constants.DevotedString);
    public static string PermEnactor(string s) => s.Replace(Constants.DevotedString, string.Empty);

    /// <summary> 
    ///     If the owner of these global perms is in IndoorConfinement or Imprisonment. <para />
    ///     AKA tells us if we should prevent them from leaving the area. 
    /// </summary>
    public static bool IsAnchored(this IReadOnlyGlobalPerms p) => string.IsNullOrEmpty(p.IndoorConfinement) || string.IsNullOrEmpty(p.Imprisonment);

    public static bool HcFollowState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.LockedFollowing);
    public static string HcFollowEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.LockedFollowing);
    public static bool HcFollowIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.LockedFollowing);
    public static bool CanChangeHcFollow(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.LockedFollowing) || !IsDevotional(p.LockedFollowing)) return true;
        return kinksterUid.Equals(PermEnactor(p.LockedFollowing));
    }

    public static bool HcEmoteIsGroundSitting(this IReadOnlyGlobalPerms p) => p.LockedEmoteState.Split('|') is { Length: >= 2 } pt && GroundSitIdList.Contains(pt[1]);
    public static bool HcEmoteIsSitting(this IReadOnlyGlobalPerms p) => p.LockedEmoteState.Split('|') is { Length: >= 2 } pt && SitIdList.Contains(pt[1]);
    public static bool HcEmoteIsAnySitting(this IReadOnlyGlobalPerms p) => p.LockedEmoteState.Split('|') is { Length: >= 2 } pt && AnySitIdList.Contains(pt[1]); 
    public static bool HcEmoteState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.LockedEmoteState);
    public static string HcEmoteEnactor(this IReadOnlyGlobalPerms p) => p.LockedEmoteState.Split('|')[0];
    public static bool HcEmoteIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.LockedEmoteState);
    public static bool CanChangeHcEmote(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.LockedEmoteState) || !IsDevotional(p.LockedEmoteState)) return true;
        return kinksterUid.Equals(p.LockedEmoteState.Split('|')[0]);
    }

    public static bool HcConfinedState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.IndoorConfinement);
    public static string HcConfinedEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.IndoorConfinement);
    public static bool HcConfinedIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.IndoorConfinement);
    public static bool CanChangeHcConfined(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.IndoorConfinement) || !IsDevotional(p.IndoorConfinement)) return true;
        return kinksterUid.Equals(PermEnactor(p.IndoorConfinement));
    }

    public static bool HcCageState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.Imprisonment);
    public static string HcCageEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.Imprisonment);
    public static bool HcCageIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.Imprisonment);
    public static bool CanChangeHcCage(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.Imprisonment) || !IsDevotional(p.Imprisonment)) return true;
        return kinksterUid.Equals(PermEnactor(p.Imprisonment));
    }

    public static bool HcChatVisState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.ChatBoxesHidden);
    public static string HcChatVisEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.LockedFollowing);
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

    public static bool HypnoState(this IReadOnlyGlobalPerms p) => !string.IsNullOrEmpty(p.HypnosisCustomEffect);
    public static string HypnoEnactor(this IReadOnlyGlobalPerms p) => PermEnactor(p.HypnosisCustomEffect);
    public static bool HypnoIsDevotional(this IReadOnlyGlobalPerms p) => IsDevotional(p.HypnosisCustomEffect);
    public static bool CanChangeHypno(this IReadOnlyGlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.HypnosisCustomEffect) || !IsDevotional(p.HypnosisCustomEffect)) return true;
        return kinksterUid.Equals(PermEnactor(p.HypnosisCustomEffect));
    }
}
