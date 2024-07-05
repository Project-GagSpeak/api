using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace GagSpeak.API.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record UserPairPermissions
{
    // unique permissions stored here:
    public bool IsPaused { get; set; } = false;  // if the pair is paused, a unique unmodifiable permission by other pairs.
    public bool ExtendedLockTimes { get; set; } = false;  // if user allowed extended lock times for this paired user
    public TimeSpan MaxLockTime { get; set; } = TimeSpan.Zero;    // the max lock time for this paired user
    public bool InHardcore { get; set; } = false;         // if the user is in hardcore mode with this paired user

    // unique permissions for the wardrobe
    public bool ApplyRestraintSets { get; set; } = false; // if the client pair can apply your restraint sets.
    public bool LockRestraintSets { get; set; } = false;  // if the client pair can lock your restraint sets
    public TimeSpan MaxAllowedRestraintTime { get; set; } = TimeSpan.Zero; // the max time the client pair can lock your restraint sets
    public bool RemoveRestraintSets { get; set; } = false; // if the client pair can remove your restraint sets.

    // unique permissions for the puppeteer
    public string TriggerPhrase { get; set; } = "";    // the end char that is the right enclosing bracket character for commands.
    public char StartChar { get; set; } = '(';          // the start char that is the left enclosing bracket character for commands.
    public char EndChar { get; set; } = ')';            // the end char that is the right enclosing bracket character for commands.
    public bool AllowSitRequests { get; set; } = false;   // if the client pair can request to sit on you.
    public bool AllowMotionRequests { get; set; } = false; // if the client pair can request to move you.
    public bool AllowAllRequests { get; set; } = false;   // if the client pair can request to do anything.

    // unique Moodles permissions
    public bool AllowPositiveStatusTypes { get; set; } = false; // if the client pair can give you positive moodles
    public bool AllowNegativeStatusTypes { get; set; } = false; // if the client pair can give you negative moodles
    public bool AllowSpecialStatusTypes { get; set; } = false;  // if the client pair can give you neutral moodles
    public bool PairCanApplyOwnMoodlesToYou { get; set; } = false; // if the client pair can apply their moodles to you
    public bool PairCanApplyYourMoodlesToYou { get; set; } = false; // if the client pair can apply your moodles
    public TimeSpan MaxMoodleTime { get; set; } = TimeSpan.Zero; // the max time the client pair can apply moodles to you
    public bool AllowPermanentMoodles { get; set; } = false; // if the client pair can apply permanent moodles to you

    // unique permissions for the toybox
    public bool ChangeToyState { get; set; } = false;   // if the client pair can turn your toy on and off.
    public bool CanControlIntensity { get; set; } = false;    // if the client pair can control the intensity of your toy.
    public bool VibratorAlarms { get; set; } = false; // if the client pair can set alarms on your toy.
    public bool CanUseRealtimeVibeRemote { get; set; } = false; // if the client pair can use the real-time vibe remote on your toy.
    public bool CanExecutePatterns { get; set; } = false;      // if the client pair can use patterns on your toy.
    public bool CanExecuteTriggers { get; set; } = false;      // if the client pair can use triggers on your toy.
    public bool CanCreateTriggers { get; set; } = false;       // if the client pair can create triggers on your toy.
    public bool CanSendTriggers { get; set; } = false;         // if the client pair can send triggers to your toy.

    // unique hardcore permissions.
    public bool AllowForcedFollow { get; set; } = false;     // if you give player permission
    public bool IsForcedToFollow { get; set; } = false;      // if the player has activated it
    public bool AllowForcedSit { get; set; } = false;        // if you give player permission
    public bool IsForcedToSit { get; set; } = false;         // if the player has activated it 
    public bool AllowForcedToStay { get; set; } = false;     // if you give player permission
    public bool IsForcedToStay { get; set; } = false;        // if the player has activated it
    public bool AllowBlindfold { get; set; } = false;       // if you give player permission
    public bool ForceLockFirstPerson { get; set; } = false; // if you force first person view
    public bool IsBlindfolded { get; set; } = false;      // if the player has activated it
}