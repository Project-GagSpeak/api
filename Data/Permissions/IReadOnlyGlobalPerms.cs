using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;
using GagspeakAPI.Extensions;

namespace GagspeakAPI.Data.Permissions;

public interface IReadOnlyGlobalPerms
{
    /// <summary> Bitfield for liveChatGarblerChannels. Can be set by Hardcore. </summary>
    InptChannel AllowedGarblerChannels      { get; }

    /// <summary> If the live chat garbler is active. </summary>
    bool        ChatGarblerActive           { get; }

    /// <summary> If the live chat garbler is locked in an active state. </summary>
    bool        ChatGarblerLocked           { get; }

    /// <summary> Shows GagSpeak gagged & gag-speaking icons on nameplate while gagged. </summary>
    bool        GaggedNameplate             { get; }

    // wardrobe global modifiable permissions
    /// <summary> PROFILE VIEWABLE OPT-IN || If the user's wardrobe component is active. </summary>
    bool        WardrobeEnabled             { get; }

    /// <summary> Determines if any visual alterations of gags are applied. </summary>
    bool        GagVisuals                  { get; }

    /// <summary> Determines if any visual alterations of restrictions are applied. </summary>
    bool        RestrictionVisuals          { get; }

    /// <summary> Determines if any visual alterations of restraint sets are applied. </summary>
    bool        RestraintSetVisuals         { get; }


    // --------- Global Puppeteer Modifiable Permissions ---------

    /// <summary> PROFILE VIEWABLE OPT-IN || If the user's puppeteer component is active. </summary>
    bool        PuppeteerEnabled            { get; }

    /// <summary> PROFILE VIEWABLE OPT-IN || Global trigger phrase for the user. </summary>
    string      TriggerPhrase               { get; }

    /// <summary> Global puppeteer permissions. </summary>
    PuppetPerms PuppetPerms                 { get; }


    // --------- Global Toybox Modifiable Permissions ---------

    /// <summary> PROFILE VIEWABLE OPT-IN || If the user's toybox component is active. </summary>
    bool        ToyboxEnabled               { get; }

    /// <summary> If any devices are currently interactable. </summary>
    bool        ToysAreInteractable         { get; }

    /// <summary> If the user is in a vibe room. When true, other remote actions are blocked. </summary>
    bool        InVibeRoom                  { get; }

    /// <summary> If the user's toybox local audio is active. </summary>
    bool        SpatialAudio                { get; }


    // --------- Global Hardcore Permissions (readonly for everyone) ---------
    // Contains the UID who applied it when active. If Devotional, will have |pairlocked| appended.

    /// <summary> When in ForceFollow mode, this contains the UID of the player you are following. </summary>
    string      LockedFollowing             { get; }

    /// <summary> When in LockedEmoteState mode, this contains the emote state you are forced into, and the kinkster who did it. </summary>
    string      LockedEmoteState            { get; }

    /// <summary> When in ForcedStay mode, this contains the UID of the player you are forced to stay with. </summary>
    string      IndoorConfinement           { get; }

    /// <summary> Cannot stray too far from a spesified location when set. </summary>
    string      Imprisonment                { get; }

    /// <summary> Contains the UID of the player who hid your chatboxes. </summary>
    string      ChatBoxesHidden             { get; }

    /// <summary> Contains the UID of the player who hid your chat input. </summary>
    string      ChatInputHidden             { get; }

    /// <summary> Contains the UID of the player who blocked your chat input. </summary>
    string      ChatInputBlocked            { get; }

    /// <summary> Contains the UID that put you in your active Hypnosis effect. Can be yourself, if from a restriction or cursed loot. </summary>
    string      HypnosisCustomEffect        { get; }


    // --------- Global PiShock Permissions & Helpers ---------
    
    /// <summary> The share code for the PiShock, used to connect to the PiShock server. </summary>
    string      GlobalShockShareCode        { get; }

    /// <summary> If the Kinkster is allowed to receive shocks. Parsed from PiShockPermissions tuple via ShareCode. </summary>
    bool        AllowShocks                 { get; }

    /// <summary> If the Kinkster is allowed to receive vibrations. Parsed from PiShockPermissions tuple via ShareCode. </summary>
    bool        AllowVibrations             { get; }

    /// <summary> If the Kinkster is allowed to receive beeps. Parsed from PiShockPermissions tuple via ShareCode. </summary>
    bool        AllowBeeps                  { get; }

    /// <summary> The maximum intensity of the shock that can be sent to the Kinkster. </summary>
    int         MaxIntensity                { get; }

    /// <summary> The maximum duration of the shock that can be sent to the Kinkster, in milliseconds or seconds. </summary>
    int         MaxDuration                 { get; }

    /// <summary> The duration of the shock vibration, used for the PiShock, can be manually set. Limited to maxduration. </summary>
    TimeSpan    ShockVibrateDuration        { get; }

    /// <summary> If the Kinkster has a valid share code for the PiShock. </summary>
    public bool HasValidShareCode() => !GlobalShockShareCode.NullOrEmpty() && MaxDuration > 0;

    /// <summary> Gets the maximum duration of the shock in a TimeSpan format, based on the MaxDuration value. </summary>
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
