using GagspeakAPI.Extensions;
using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record UserGlobalPermissions
{
    public int ChatGarblerChannelsBitfield { get; set; } = 0;   // bitfield for liveChatGarblerChannels. Can be set by Hardcore.
    public bool ChatGarblerActive { get; set; } = false;        // if the live chat garbler is active
    public bool ChatGarblerLocked { get; set; } = false;        // if the live chat garbler is locked in an active state.

    // wardrobe global modifiable permissions
    public bool WardrobeEnabled { get; set; } = false;          // PROFILE VIEWABLE OPT-IN || If the user's wardrobe component is active
    public bool GagVisuals { get; set; } = false;               // Determines if any visual alterations of gags are applied.
    public bool RestrictionVisuals { get; set; } = false;       // Determines if any visual alterations of restrictions are applied.
    public bool RestraintSetVisuals { get; set; } = false;      // Determines if any visual alterations of restraint sets are applied.


    // global puppeteer modifiable permissions.
    public bool PuppeteerEnabled { get; set; } = false;         // PROFILE VIEWABLE OPT-IN || If the user's puppeteer component is active
    public string GlobalTriggerPhrase { get; set; } = "";       // PROFILE VIEWABLE OPT-IN || Global trigger phrase for the user
    public bool GlobalSitRequests { get; set; } = false;        // PROFILE VIEWABLE OPT-IN || If user allows sit requests
    public bool GlobalMotionRequests { get; set; } = false;     // PROFILE VIEWABLE OPT-IN || If the user allows motion requests
    public bool GlobalAliasRequests { get; set; } = false;      // PROFILE VIEWABLE OPT-IN || READONLY || If the user allows alias requests
    public bool GlobalAllRequests { get; set; } = false;        // PROFILE VIEWABLE OPT-IN || READONLY || If the user allows all requests

    // global toybox modifiable permissions
    public bool ToyboxEnabled { get; set; } = false;            // PROFILE VIEWABLE OPT-IN || If the user's toybox component is active
    public bool LockToyboxUI { get; set; } = false;             // Prevents the user from interfacing with their connected toys.
    public bool ToysAreActive { get; set; } = false;            // True if any toy is connected and set to active in the interface.
    public bool ToysAreInUse { get; set; } = false;             // True if connected to any remote / vibe room.
    public bool SpatialAudio { get; set; } = false;             // if the user's toybox local audio is active

    // global hardcore permissions (readonly for everyone)
    // Contains the UID who applied it when active. If Devotional, will have    |pairlocked    appended.
    public string ForcedFollow { get; set; } = string.Empty;
    public string ForcedEmoteState { get; set; } = string.Empty;
    public string ForcedStay { get; set; } = string.Empty;
    public string ChatBoxesHidden { get; set; } = string.Empty;
    public string ChatInputHidden { get; set; } = string.Empty;
    public string ChatInputBlocked { get; set; } = string.Empty;

    // Global PiShock Permissions & Helpers.
    public string GlobalShockShareCode { get; set; } = "";
    public bool AllowShocks { get; set; } = false;
    public bool AllowVibrations { get; set; } = false;
    public bool AllowBeeps { get; set; } = false;
    public int MaxIntensity { get; set; } = -1;
    public int MaxDuration { get; set; } = -1;
    public TimeSpan GlobalShockVibrateDuration { get; set; } = TimeSpan.Zero;

    public bool HasValidShareCode() => !GlobalShockShareCode.NullOrEmpty() && MaxDuration > 0;
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

    public void PuppetPerms(out bool canSit, out bool canEmote, out bool canAlias, out bool canAll)
    {
        canSit = GlobalSitRequests;
        canEmote = GlobalMotionRequests;
        canAlias = GlobalAliasRequests;
        canAll = GlobalAllRequests;
    }

}
