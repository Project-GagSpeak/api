using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.Extensions;

public static class GlobalPermsEx
{
    private static bool IsDevotional(string s) => s.EndsWith(Constants.DevotedString);
    private static string PermEnactor(string s) => s.Replace(Constants.DevotedString, string.Empty);

    public static bool HcFollowState(this GlobalPerms p) => !string.IsNullOrEmpty(p.ForcedFollow);
    public static string HcFollowEnactor(this GlobalPerms p) => PermEnactor(p.ForcedFollow);
    public static bool HcFollowIsDevotional(this GlobalPerms p) => IsDevotional(p.ForcedFollow);
    public static bool CanChangeHcFollow(this GlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ForcedFollow) || !IsDevotional(p.ForcedFollow)) return true;
        return kinksterUid.Equals(PermEnactor(p.ForcedFollow));
    }

    public static bool HcEmoteState(this GlobalPerms p) => !string.IsNullOrEmpty(p.ForcedEmoteState);
    public static string HcEmoteEnactor(this GlobalPerms p) => p.ForcedEmoteState.Split('|')[0];
    public static bool HcEmoteIsDevotional(this GlobalPerms p) => IsDevotional(p.ForcedEmoteState);
    public static bool CanChangeHcEmote(this GlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ForcedEmoteState) || !IsDevotional(p.ForcedEmoteState)) return true;
        return kinksterUid.Equals(p.ForcedEmoteState.Split('|')[0]);
    }

    public static bool HcStayState(this GlobalPerms p) => !string.IsNullOrEmpty(p.ForcedStay);
    public static string HcStayEnactor(this GlobalPerms p) => PermEnactor(p.ForcedStay);
    public static bool HcStayIsDevotional(this GlobalPerms p) => IsDevotional(p.ForcedStay);
    public static bool CanChangeHcStay(this GlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ForcedStay) || !IsDevotional(p.ForcedStay)) return true;
        return kinksterUid.Equals(PermEnactor(p.ForcedStay));
    }

    public static bool HcChatVisState(this GlobalPerms p) => !string.IsNullOrEmpty(p.ChatBoxesHidden);
    public static string HcChatVisEnactor(this GlobalPerms p) => PermEnactor(p.ForcedFollow);
    public static bool HcChatVisIsDevotional(this GlobalPerms p) => IsDevotional(p.ChatBoxesHidden);
    public static bool CanChangeHcChatVis(this GlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ChatBoxesHidden) || !IsDevotional(p.ChatBoxesHidden)) return true;
        return kinksterUid.Equals(PermEnactor(p.ChatBoxesHidden));
    }

    public static bool HcChatInputVisState(this GlobalPerms p) => !string.IsNullOrEmpty(p.ChatInputHidden);
    public static string HcChatInputVisEnactor(this GlobalPerms p) => PermEnactor(p.ChatInputHidden);
    public static bool HcChatInputVisIsDevotional(this GlobalPerms p) => IsDevotional(p.ChatInputHidden);
    public static bool CanChangeHcChatInputVis(this GlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ChatInputHidden) || !IsDevotional(p.ChatInputHidden)) return true;
        return kinksterUid.Equals(PermEnactor(p.ChatInputHidden));
    }

    public static bool HcBlockChatInput(this GlobalPerms p) => !string.IsNullOrEmpty(p.ChatInputBlocked);
    public static string HcBlockChatInputEnactor(this GlobalPerms p) => PermEnactor(p.ChatInputBlocked);
    public static bool HcBlockChatInputDevotional(this GlobalPerms p) => IsDevotional(p.ChatInputBlocked);
    public static bool CanChangeHcBlockChatInput(this GlobalPerms p, string kinksterUid)
    {
        if (string.IsNullOrEmpty(p.ChatInputBlocked) || !IsDevotional(p.ChatInputBlocked)) return true;
        return kinksterUid.Equals(PermEnactor(p.ChatInputBlocked));
    }
}
