using GagspeakAPI.Attributes;
using GagspeakAPI.Data.Permissions;

namespace GagspeakAPI.Extensions;

public static class HardcoreStateEx
{
    private static readonly string[] SitIdList = { "50", "95", "96", "254", "255" };
    private static readonly string[] GroundSitIdList = { "52", "97", "98", "117" };
    private static readonly string[] AnySitIdList = SitIdList.Concat(GroundSitIdList).ToArray();

    /// <summary>
    ///     If this kinkster is anchored to confinement or imprisonment. <para />
    ///     This is not useful if you are validating any one permission. 
    ///     Rather it is meant to define when either of these can be enabled.
    /// </summary>
    public static bool IsKinksterAnchored(this IReadOnlyHardcoreState hs)
        => string.IsNullOrEmpty(hs.IndoorConfinement) || string.IsNullOrEmpty(hs.Imprisonment);

    /// <summary>
    ///     If the hardcore state for <paramref name="attribute"/> is enabled.
    /// </summary>
    /// <param name="attribute"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static bool IsEnabled(this IReadOnlyHardcoreState? hs, HcAttribute attribute)
        => hs is null ? false : attribute switch
        {
            HcAttribute.Follow => !string.IsNullOrEmpty(hs.LockedFollowing),
            HcAttribute.EmoteState => !string.IsNullOrEmpty(hs.LockedEmoteState),
            HcAttribute.Confinement => !string.IsNullOrEmpty(hs.IndoorConfinement),
            HcAttribute.Imprisonment => !string.IsNullOrEmpty(hs.Imprisonment),
            HcAttribute.HiddenChatBox => !string.IsNullOrEmpty(hs.ChatBoxesHidden),
            HcAttribute.HiddenChatInput => !string.IsNullOrEmpty(hs.ChatInputHidden),
            HcAttribute.BlockedChatInput => !string.IsNullOrEmpty(hs.ChatInputBlocked),
            HcAttribute.HypnoticEffect => !string.IsNullOrEmpty(hs.HypnoticEffect),
            _ => throw new NotImplementedException(),
        };

    /// <summary>
    ///     The enactor of <paramref name="attribute"/>.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public static string Enactor(this IReadOnlyHardcoreState hs, HcAttribute attribute)
        => hs is not null ? attribute switch
        {
            HcAttribute.Follow => hs.LockedFollowing.Split('|')[0],
            HcAttribute.EmoteState => hs.LockedEmoteState.Split('|')[0],
            HcAttribute.Confinement => hs.IndoorConfinement.Split('|')[0],
            HcAttribute.Imprisonment => hs.Imprisonment.Split('|')[0],
            HcAttribute.HiddenChatBox => hs.ChatBoxesHidden.Split('|')[0],
            HcAttribute.HiddenChatInput => hs.ChatInputHidden.Split('|')[0],
            HcAttribute.BlockedChatInput => hs.ChatInputBlocked.Split('|')[0],
            HcAttribute.HypnoticEffect => hs.HypnoticEffect.Split('|')[0],
            _ => throw new NotImplementedException(),
        };

    /// <summary>
    ///     If the attribute is devotionally locked.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public static bool IsDevotional(this IReadOnlyHardcoreState? hs, HcAttribute attribute)
        => hs is null ? false : attribute switch
        {
            HcAttribute.Follow => hs.LockedFollowing.EndsWith(Constants.DevotedString),
            HcAttribute.EmoteState => hs.LockedEmoteState.EndsWith(Constants.DevotedString),
            HcAttribute.Confinement => hs.IndoorConfinement.EndsWith(Constants.DevotedString),
            HcAttribute.Imprisonment => hs.Imprisonment.EndsWith(Constants.DevotedString),
            HcAttribute.HiddenChatBox => hs.ChatBoxesHidden.EndsWith(Constants.DevotedString),
            HcAttribute.HiddenChatInput => hs.ChatInputHidden.EndsWith(Constants.DevotedString),
            HcAttribute.BlockedChatInput => hs.ChatInputBlocked.EndsWith(Constants.DevotedString),
            HcAttribute.HypnoticEffect => hs.HypnoticEffect.EndsWith(Constants.DevotedString),
            _ => throw new NotImplementedException(),
        };

    public static bool IsChatManipulated(this IReadOnlyHardcoreState? hs)
        => hs is not null && (hs.ChatBoxesHidden.Length > 0 || hs.ChatInputHidden.Length > 0 || hs.ChatInputBlocked.Length > 0);

    /// <summary>
    ///     If the kinkster is able to change the hardcore state for <paramref name="attribute"/>.
    /// </summary>
    public static bool CanChange(this IReadOnlyHardcoreState? hs, HcAttribute attribute, string kinksterUid)
    {
        if (hs is null)
            return false;

        var curState = attribute switch
        {
            HcAttribute.Follow => hs.LockedFollowing,
            HcAttribute.EmoteState => hs.LockedEmoteState,
            HcAttribute.Confinement => hs.IndoorConfinement,
            HcAttribute.Imprisonment => hs.Imprisonment,
            HcAttribute.HiddenChatBox => hs.ChatBoxesHidden,
            HcAttribute.HiddenChatInput => hs.ChatInputHidden,
            HcAttribute.BlockedChatInput => hs.ChatInputBlocked,
            HcAttribute.HypnoticEffect => hs.HypnoticEffect,
            _ => throw new NotImplementedException(),
        };
        // ret the state
        return curState.EndsWith(Constants.DevotedString) ? curState.Split('|')[0].Equals(kinksterUid) : true;
    }

    public static bool InGroundSitEmote(this IReadOnlyHardcoreState? hs)
        => hs is null ? false : hs.LockedEmoteState.Split('|') is { Length: >= 2 } pt && GroundSitIdList.Contains(pt[1]);
    public static bool InSitEmote(this IReadOnlyHardcoreState? hs)
        => hs is null ? false : hs.LockedEmoteState.Split('|') is { Length: >= 2 } pt && SitIdList.Contains(pt[1]);
    public static bool InAnySitEmote(this IReadOnlyHardcoreState? hs)
        => hs is null ? false : hs.LockedEmoteState.Split('|') is { Length: >= 2 } pt && AnySitIdList.Contains(pt[1]);
}
