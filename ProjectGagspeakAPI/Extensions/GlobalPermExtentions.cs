using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.Extensions;

public static class GlobalPermExtentions
{
    public static bool IsFollowing(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ForcedFollow);
    public static bool IsFollowDevotional(this UserGlobalPermissions p) => p.ForcedFollow.EndsWith(Globals.DevotedString);
    public static string FollowUID(this UserGlobalPermissions p) => p.ForcedFollow.Replace(Globals.DevotedString, string.Empty);
    public static bool CanToggleFollow(this UserGlobalPermissions p, string uid)
    {
        if (p.ForcedFollow == string.Empty || !p.ForcedFollow.EndsWith(Globals.DevotedString))
            return true;
        else
            return p.FollowUID() == uid;
    }

    public static bool IsSitting(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ForcedSit) || !string.IsNullOrEmpty(p.ForcedGroundsit);
    public static bool IsNormalSitting(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ForcedSit);
    public static bool IsGroundSitting(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ForcedGroundsit);
    public static bool IsSitDevotional(this UserGlobalPermissions p) => p.ForcedSit.EndsWith(Globals.DevotedString) || p.ForcedGroundsit.EndsWith(Globals.DevotedString);
    public static string SitUID(this UserGlobalPermissions p)
    {
        if (!string.IsNullOrEmpty(p.ForcedSit))
            return p.ForcedSit.Replace(Globals.DevotedString, string.Empty);
        else
            return p.ForcedGroundsit.Replace(Globals.DevotedString, string.Empty);
    }
    public static bool CanToggleSit(this UserGlobalPermissions p, string uid)
    {
        if (string.IsNullOrEmpty(p.ForcedSit) && string.IsNullOrEmpty(p.ForcedGroundsit))
            return true;
        else if (!string.IsNullOrEmpty(p.ForcedSit))
            return p.SitUID() == uid;
        else
            return p.SitUID() == uid;
    }

    public static bool IsStaying(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ForcedStay);
    public static bool IsStayDevotional(this UserGlobalPermissions p) => p.ForcedStay.EndsWith(Globals.DevotedString);
    public static string StayUID(this UserGlobalPermissions p) => p.ForcedStay.Replace(Globals.DevotedString, string.Empty);
    public static bool CanToggleStay(this UserGlobalPermissions p, string uid)
    {
        if (string.IsNullOrEmpty(p.ForcedStay)|| !p.ForcedStay.EndsWith(Globals.DevotedString))
            return true;
        else
            return p.StayUID() == uid;
    }

    public static bool IsBlindfolded(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ForcedBlindfold);
    public static bool IsBlindfoldDevotional(this UserGlobalPermissions p) => p.ForcedBlindfold.EndsWith(Globals.DevotedString);
    public static string BlindfoldUID(this UserGlobalPermissions p) => p.ForcedBlindfold.Replace(Globals.DevotedString, string.Empty);
    public static bool CanToggleBlindfold(this UserGlobalPermissions p, string uid)
    {
        if (string.IsNullOrEmpty(p.ForcedBlindfold) || !p.ForcedBlindfold.EndsWith(Globals.DevotedString))
            return true;
        else
            return p.BlindfoldUID() == uid;
    }

    public static bool IsChatHidden(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ChatboxesHidden);
    public static bool IsChatHiddenDevotional(this UserGlobalPermissions p) => p.ChatboxesHidden.EndsWith(Globals.DevotedString);
    public static string ChatHiddenUID(this UserGlobalPermissions p) => p.ChatboxesHidden.Replace(Globals.DevotedString, string.Empty);
    public static bool CanToggleChatHidden(this UserGlobalPermissions p, string uid)
    {
        if (string.IsNullOrEmpty(p.ChatboxesHidden) || !p.ChatboxesHidden.EndsWith(Globals.DevotedString))
            return true;
        else
            return p.ChatHiddenUID() == uid;
    }

    public static bool IsChatInputHidden(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ChatInputHidden);
    public static bool IsChatInputHiddenDevotional(this UserGlobalPermissions p) => p.ChatInputHidden.EndsWith(Globals.DevotedString);
    public static string ChatInputHiddenUID(this UserGlobalPermissions p) => p.ChatInputHidden.Replace(Globals.DevotedString, string.Empty);
    public static bool CanToggleChatInputHidden(this UserGlobalPermissions p, string uid)
    {
        if (string.IsNullOrEmpty(p.ChatInputHidden) || !p.ChatInputHidden.EndsWith(Globals.DevotedString))
            return true;
        else
            return p.ChatInputHiddenUID() == uid;
    }

    public static bool IsChatInputBlocked(this UserGlobalPermissions p) => !string.IsNullOrEmpty(p.ChatInputBlocked);
    public static bool IsChatInputBlockedDevotional(this UserGlobalPermissions p) => p.ChatInputBlocked.EndsWith(Globals.DevotedString);
    public static string ChatInputBlockedUID(this UserGlobalPermissions p) => p.ChatInputBlocked.Replace(Globals.DevotedString, string.Empty);
    public static bool CanToggleChatInputBlocked(this UserGlobalPermissions p, string uid)
    {
        if (string.IsNullOrEmpty(p.ChatInputBlocked) || !p.ChatInputBlocked.EndsWith(Globals.DevotedString))
            return true;
        else
            return p.ChatInputBlockedUID() == uid;
    }
}
