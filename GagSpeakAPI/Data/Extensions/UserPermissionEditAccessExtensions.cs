namespace GagSpeak.API.Data.Enum;

/// <summary>
/// A flag based enum that determines if a user has allowed another user to modify a certain
/// </summary>

public static class UserPermissionEditAccessExtensions
{
    #region GeneralFlags
    public static bool CanEditCommandsFromFriends(this UserPermissionGeneralEditAccess perm)
    {
        return perm.HasFlag(UserPermissionGeneralEditAccess.CommandsFromFriends);
    }

    public static bool CanEditCommandsFromParty(this UserPermissionGeneralEditAccess perm)
    {
        return perm.HasFlag(UserPermissionGeneralEditAccess.CommandsFromParty);
    }

    public static bool CanEditLiveChatGarblerState(this UserPermissionGeneralEditAccess perm)
    {
        return perm.HasFlag(UserPermissionGeneralEditAccess.LiveChatGarblerState);
    }

    public static bool CanEditLiveChatGarblerLocked(this UserPermissionGeneralEditAccess perm)
    {
        return perm.HasFlag(UserPermissionGeneralEditAccess.LiveChatGarblerLocked);
    }

    public static bool CanEditExtendedLockTimes(this UserPermissionGeneralEditAccess perm)
    {
        return perm.HasFlag(UserPermissionGeneralEditAccess.ExtendedLockTimes);
    }

    public static bool CanEditMaxLockTime(this UserPermissionGeneralEditAccess perm)
    {
        return perm.HasFlag(UserPermissionGeneralEditAccess.MaxLockTime);
    }

    public static void SetAccessCommandsFromFriends(this UserPermissionGeneralEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionGeneralEditAccess.CommandsFromFriends;
        else perm &= ~UserPermissionGeneralEditAccess.CommandsFromFriends;
    }

    public static void SetAccessCommandsFromParty(this UserPermissionGeneralEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionGeneralEditAccess.CommandsFromParty;
        else perm &= ~UserPermissionGeneralEditAccess.CommandsFromParty;
    }

    public static void SetAccessLiveChatGarblerState(this UserPermissionGeneralEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionGeneralEditAccess.LiveChatGarblerState;
        else perm &= ~UserPermissionGeneralEditAccess.LiveChatGarblerState;
    }

    public static void SetAccessLiveChatGarblerLocked(this UserPermissionGeneralEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionGeneralEditAccess.LiveChatGarblerLocked;
        else perm &= ~UserPermissionGeneralEditAccess.LiveChatGarblerLocked;
    }

    public static void SetAccessExtendedLockTimes(this UserPermissionGeneralEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionGeneralEditAccess.ExtendedLockTimes;
        else perm &= ~UserPermissionGeneralEditAccess.ExtendedLockTimes;
    }

    public static void SetAccessMaxLockTime(this UserPermissionGeneralEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionGeneralEditAccess.MaxLockTime;
        else perm &= ~UserPermissionGeneralEditAccess.MaxLockTime;
    }
    #endregion GeneralFlags

    #region WardrobeFlags
    public static bool CanEditWardrobeEnabled(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.WardrobeEnabled);
    }

    public static bool CanEditItemAutoEquip(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.ItemAutoEquip);
    }

    public static bool CanEditRestraintSetAutoEquip(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.RestraintSetAutoEquip);
    }

    public static bool CanEditLockGagStorageOnGagLock(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.LockGagStorageOnGagLock);
    }

    public static bool CanEditApplyRestraintSets(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.ApplyRestraintSets);
    }

    public static bool CanEditLockRestraintSets(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.LockRestraintSets);
    }

    public static bool CanEditMaxAllowedRestraintTime(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.MaxAllowedRestraintTime);
    }

    public static bool CanEditRemoveRestraintSets(this UserPermissionWardrobeEditAccess perm)
    {
        return perm.HasFlag(UserPermissionWardrobeEditAccess.RemoveRestraintSets);
    }

    public static void SetAccessWardrobeEnabled(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.WardrobeEnabled;
        else perm &= ~UserPermissionWardrobeEditAccess.WardrobeEnabled;
    }

    public static void SetAccessItemAutoEquip(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.ItemAutoEquip;
        else perm &= ~UserPermissionWardrobeEditAccess.ItemAutoEquip;
    }

    public static void SetAccessRestraintSetAutoEquip(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.RestraintSetAutoEquip;
        else perm &= ~UserPermissionWardrobeEditAccess.RestraintSetAutoEquip;
    }

    public static void SetAccessLockGagStorageOnGagLock(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.LockGagStorageOnGagLock;
        else perm &= ~UserPermissionWardrobeEditAccess.LockGagStorageOnGagLock;
    }

    public static void SetAccessApplyRestraintSets(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.ApplyRestraintSets;
        else perm &= ~UserPermissionWardrobeEditAccess.ApplyRestraintSets;
    }

    public static void SetAccessLockRestraintSets(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.LockRestraintSets;
        else perm &= ~UserPermissionWardrobeEditAccess.LockRestraintSets;
    }

    public static void SetAccessMaxAllowedRestraintTime(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.MaxAllowedRestraintTime;
        else perm &= ~UserPermissionWardrobeEditAccess.MaxAllowedRestraintTime;
    }

    public static void SetAccessRemoveRestraintSets(this UserPermissionWardrobeEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionWardrobeEditAccess.RemoveRestraintSets;
        else perm &= ~UserPermissionWardrobeEditAccess.RemoveRestraintSets;
    }
    #endregion WardrobeFlags

    #region PuppeteerFlags
    public static bool CanEditPuppeteerEnabled(this UserPermissionPuppeteerEditAccess perm)
    {
        return perm.HasFlag(UserPermissionPuppeteerEditAccess.PuppeteerEnabled);
    }

    public static bool CanEditAllowSitRequests(this UserPermissionPuppeteerEditAccess perm)
    {
        return perm.HasFlag(UserPermissionPuppeteerEditAccess.AllowSitRequests);
    }

    public static bool CanEditAllowMotionRequests(this UserPermissionPuppeteerEditAccess perm)
    {
        return perm.HasFlag(UserPermissionPuppeteerEditAccess.AllowMotionRequests);
    }

    public static bool CanEditAllowAllRequests(this UserPermissionPuppeteerEditAccess perm)
    {
        return perm.HasFlag(UserPermissionPuppeteerEditAccess.AllowAllRequests);
    }

    public static void SetAccessPuppeteerEnabled(this UserPermissionPuppeteerEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionPuppeteerEditAccess.PuppeteerEnabled;
        else perm &= ~UserPermissionPuppeteerEditAccess.PuppeteerEnabled;
    }

    public static void SetAccessAllowSitRequests(this UserPermissionPuppeteerEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionPuppeteerEditAccess.AllowSitRequests;
        else perm &= ~UserPermissionPuppeteerEditAccess.AllowSitRequests;
    }

    public static void SetAccessAllowMotionRequests(this UserPermissionPuppeteerEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionPuppeteerEditAccess.AllowMotionRequests;
        else perm &= ~UserPermissionPuppeteerEditAccess.AllowMotionRequests;
    }

    public static void SetAccessAllowAllRequests(this UserPermissionPuppeteerEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionPuppeteerEditAccess.AllowAllRequests;
        else perm &= ~UserPermissionPuppeteerEditAccess.AllowAllRequests;
    }
    #endregion PuppeteerFlags

    #region MoodlesFlags
    public static bool CanEditMoodlesEnabled(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.MoodlesEnabled);
    }

    public static bool CanEditAllowPositiveStatusTypes(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.AllowPositiveStatusTypes);
    }

    public static bool CanEditAllowNegativeStatusTypes(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.AllowNegativeStatusTypes);
    }

    public static bool CanEditAllowSpecialStatusTypes(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.AllowSpecialStatusTypes);
    }

    public static bool CanEditPairCanApplyOwnMoodlesToYou(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.PairCanApplyOwnMoodlesToYou);
    }

    public static bool CanEditPairCanApplyYourMoodlesToYou(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.PairCanApplyYourMoodlesToYou);
    }

    public static bool CanEditMaxMoodleTime(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.MaxMoodleTime);
    }

    public static bool CanEditAllowPermanentMoodles(this UserPermissionMoodlesEditAccess perm)
    {
        return perm.HasFlag(UserPermissionMoodlesEditAccess.AllowPermanentMoodles);
    }

    public static void SetAccessMoodlesEnabled(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.MoodlesEnabled;
        else perm &= ~UserPermissionMoodlesEditAccess.MoodlesEnabled;
    }

    public static void SetAccessAllowPositiveStatusTypes(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.AllowPositiveStatusTypes;
        else perm &= ~UserPermissionMoodlesEditAccess.AllowPositiveStatusTypes;
    }

    public static void SetAccessAllowNegativeStatusTypes(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.AllowNegativeStatusTypes;
        else perm &= ~UserPermissionMoodlesEditAccess.AllowNegativeStatusTypes;
    }

    public static void SetAccessAllowSpecialStatusTypes(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.AllowSpecialStatusTypes;
        else perm &= ~UserPermissionMoodlesEditAccess.AllowSpecialStatusTypes;
    }

    public static void SetAccessPairCanApplyOwnMoodlesToYou(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.PairCanApplyOwnMoodlesToYou;
        else perm &= ~UserPermissionMoodlesEditAccess.PairCanApplyOwnMoodlesToYou;
    }

    public static void SetAccessPairCanApplyYourMoodlesToYou(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.PairCanApplyYourMoodlesToYou;
        else perm &= ~UserPermissionMoodlesEditAccess.PairCanApplyYourMoodlesToYou;
    }

    public static void SetAccessMaxMoodleTime(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.MaxMoodleTime;
        else perm &= ~UserPermissionMoodlesEditAccess.MaxMoodleTime;
    }

    public static void SetAccessAllowPermanentMoodles(this UserPermissionMoodlesEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionMoodlesEditAccess.AllowPermanentMoodles;
        else perm &= ~UserPermissionMoodlesEditAccess.AllowPermanentMoodles;
    }
    #endregion MoodlesFlags

    #region ToyboxFlags
    public static bool CanEditToyboxEnabled(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.ToyboxEnabled);
    }

    public static bool CanEditLockToyboxUI(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.LockToyboxUI);
    }

    public static bool CanEditToyIsActive(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.ToyIsActive);
    }

    public static bool CanEditSpatialVibratorAudio(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.SpatialVibratorAudio);
    }

    public static bool CanEditChangeToyState(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.ChangeToyState);
    }

    public static bool CanEditCanControlIntensity(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.CanControlIntensity);
    }

    public static bool CanEditVibratorAlarms(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.VibratorAlarms);
    }

    public static bool CanEditCanUseRealtimeVibeRemote(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.CanUseRealtimeVibeRemote);
    }

    public static bool CanEditCanExecutePatterns(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.CanExecutePatterns);
    }

    public static bool CanEditCanExecuteTriggers(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.CanExecuteTriggers);
    }

    public static bool CanEditCanCreateTriggers(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.CanCreateTriggers);
    }

    public static bool CanEditCanSendTriggers(this UserPermissionToyboxEditAccess perm)
    {
        return perm.HasFlag(UserPermissionToyboxEditAccess.CanSendTriggers);
    }

    public static void SetAccessToyboxEnabled(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.ToyboxEnabled;
        else perm &= ~UserPermissionToyboxEditAccess.ToyboxEnabled;
    }

    public static void SetAccessLockToyboxUI(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.LockToyboxUI;
        else perm &= ~UserPermissionToyboxEditAccess.LockToyboxUI;
    }

    public static void SetAccessToyIsActive(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.ToyIsActive;
        else perm &= ~UserPermissionToyboxEditAccess.ToyIsActive;
    }

    public static void SetAccessSpatialVibratorAudio(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.SpatialVibratorAudio;
        else perm &= ~UserPermissionToyboxEditAccess.SpatialVibratorAudio;
    }

    public static void SetAccessChangeToyState(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.ChangeToyState;
        else perm &= ~UserPermissionToyboxEditAccess.ChangeToyState;
    }

    public static void SetAccessCanControlIntensity(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.CanControlIntensity;
        else perm &= ~UserPermissionToyboxEditAccess.CanControlIntensity;
    }

    public static void SetAccessVibratorAlarms(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.VibratorAlarms;
        else perm &= ~UserPermissionToyboxEditAccess.VibratorAlarms;
    }

    public static void SetAccessCanUseRealtimeVibeRemote(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.CanUseRealtimeVibeRemote;
        else perm &= ~UserPermissionToyboxEditAccess.CanUseRealtimeVibeRemote;
    }

    public static void SetAccessCanExecutePatterns(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.CanExecutePatterns;
        else perm &= ~UserPermissionToyboxEditAccess.CanExecutePatterns;
    }

    public static void SetAccessCanExecuteTriggers(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.CanExecuteTriggers;
        else perm &= ~UserPermissionToyboxEditAccess.CanExecuteTriggers;
    }

    public static void SetAccessCanCreateTriggers(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.CanCreateTriggers;
        else perm &= ~UserPermissionToyboxEditAccess.CanCreateTriggers;
    }

    public static void SetAccessCanSendTriggers(this UserPermissionToyboxEditAccess perm, bool set)
    {
        if (set) perm |= UserPermissionToyboxEditAccess.CanSendTriggers;
        else perm &= ~UserPermissionToyboxEditAccess.CanSendTriggers;
    }
    #endregion ToyboxFlags
}