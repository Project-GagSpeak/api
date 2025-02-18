using GagspeakAPI.Enums;
using GagspeakAPI.Extensions;
using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairPermissions
{
    public bool IsPaused { get; set; } = false;  // if the pair is paused, a unique unmodifiable permission by other pairs.

    // Advanced Lock Permissions
    public bool PermanentLocks { get; set; } = false; // if the client pair can apply permanent gags to you.
    public bool OwnerLocks { get; set; } = false; // if the pair can use OwnerPadlocks & Timer variants. Only the others with this permission can remove them.
    public bool DevotionalLocks { get; set; } = false; // if the pair can use Devotional Padlocks & Timer variants. Only the assigner of these locks can remove them.

    // Gag Permissions
    public bool ApplyGags { get; set; } = false; // if the client pair can apply gags to you.
    public bool LockGags { get; set; } = false; // if the client pair can lock gags on you.
    public TimeSpan MaxGagTime { get; set; } = TimeSpan.Zero; // the max time the client pair can lock gags on you.
    public bool UnlockGags { get; set; } = false; // if the client pair can unlock gags from you.
    public bool RemoveGags { get; set; } = false; // if the client pair can remove gags from you.

    // Restriction Permissions
    public bool ApplyRestrictions { get; set; } = false; // if the client pair can apply restrictions to you.
    public bool LockRestrictions { get; set; } = false; // if the client pair can lock restrictions on you.
    public TimeSpan MaxRestrictionTime { get; set; } = TimeSpan.Zero; // the max time the client pair can lock restrictions on you.
    public bool UnlockRestrictions { get; set; } = false; // if the client pair can unlock restrictions from you.
    public bool RemoveRestrictions { get; set; } = false; // if the client pair can remove restrictions from you.

    // unique permissions for the wardrobe
    public bool ApplyRestraintSets { get; set; } = false; // if the client pair can apply your restraint sets.
    public bool LockRestraintSets { get; set; } = false;  // if the client pair can lock your restraint sets
    public TimeSpan MaxRestraintTime { get; set; } = TimeSpan.Zero; // the max time the client pair can lock your restraint sets
    public bool UnlockRestraintSets { get; set; } = false; // if the client pair can unlock your restraint sets
    public bool RemoveRestraintSets { get; set; } = false; // if the client pair can remove your restraint sets.

    // unique permissions for the puppeteer
    public string TriggerPhrase { get; set; } = "";    // the end char that is the right enclosing bracket character for commands.
    public char StartChar { get; set; } = '(';          // the start char that is the left enclosing bracket character for commands.
    public char EndChar { get; set; } = ')';            // the end char that is the right enclosing bracket character for commands.
    public PuppeteerPerms PuppetPerms { get; set; } = 0;

    // unique Moodles permissions
    public bool AllowPositiveStatusTypes { get; set; } = false; // if the client pair can give you positive moodles
    public bool AllowNegativeStatusTypes { get; set; } = false; // if the client pair can give you negative moodles
    public bool AllowSpecialStatusTypes { get; set; } = false;  // if the client pair can give you neutral moodles
    public bool PairCanApplyOwnMoodlesToYou { get; set; } = false; // if the client pair can apply their moodles to you
    public bool PairCanApplyYourMoodlesToYou { get; set; } = false; // if the client pair can apply your moodles
    public TimeSpan MaxMoodleTime { get; set; } = TimeSpan.Zero; // the max time the client pair can apply moodles to you
    public bool AllowPermanentMoodles { get; set; } = false; // if the client pair can apply permanent moodles to you
    public bool AllowRemovingMoodles { get; set; } = false; // if the client pair can remove moodles from you

    // unique permissions for the toybox
    public bool CanToggleToyState { get; set; } = false;   // If True, this pair can toggle your toys states.
    public bool CanUseRemoteOnToys { get; set; } = false;  // If True, this pair can connect a remote to your toys.
    public bool CanExecutePatterns { get; set; } = false;  // if the client pair can use patterns on your toy.
    public bool CanStopPatterns { get; set; } = false;     // if the client pair can stop patterns on your toy.
    public bool CanToggleAlarms { get; set; } = false;     // if the client pair can toggle alarms on your toy.
    public bool CanToggleTriggers { get; set; } = false;   // if the client pair can use triggers on your toy.

    // unique hardcore permissions. (only allow the ALLOW permissions to be set by the user).
    public bool InHardcore { get; set; } = false; // if the user is in hardcore mode with this paired user
    public bool DevotionalStatesForPair { get; set; } = false; // Treats any State toggled by this pair like a Devotional Padlock.
    public bool AllowForcedFollow { get; set; } = false;
    public bool AllowForcedSit { get; set; } = false;
    public bool AllowForcedEmote { get; set; } = false;
    public bool AllowForcedToStay { get; set; } = false;
    public bool AllowGarbleChannelEditing { get; set; } = false;
    public bool AllowHidingChatBoxes { get; set; } = false;
    public bool AllowHidingChatInput { get; set; } = false;
    public bool AllowChatInputBlocking { get; set; } = false;

    public string ShockCollarShareCode { get; set; } = ""; // the share Code for the shock collar unique to this user.
    public bool AllowShocks { get; set; } = false; // If we allow shocks from this pair.
    public bool AllowVibrations { get; set; } = false; // If we allow vibrations from this pair.
    public bool AllowBeeps { get; set; } = false; // If we allow beeps from this pair.
    public int MaxIntensity { get; set; } = -1; // the max intensity of the shock, vibration, or beep.
    public int MaxDuration { get; set; } = -1; // the max duration of the shock, vibration, or beep.
    public TimeSpan MaxVibrateDuration { get; set; } = TimeSpan.Zero; // separate value since vibrations have diff limits.

    // member helper for PiShock functions.
    public bool HasValidShareCode() => !ShockCollarShareCode.NullOrEmpty() && MaxDuration > 0;
    public TimeSpan GetTimespanFromDuration()
    {
        if (MaxDuration > 15 && MaxDuration < 100)
        {
            return TimeSpan.Zero; // invalid range.
        }
        else if (MaxDuration >= 100 && MaxDuration <= 15000)
        {
            return TimeSpan.FromMilliseconds(MaxDuration); // convert to milliseconds
        }
        else
        {
            return TimeSpan.FromSeconds(MaxDuration); // convert to seconds
        }
    }
}
