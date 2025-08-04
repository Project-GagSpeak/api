using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;
using GagspeakAPI.Extensions;
using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalPerms : IReadOnlyGlobalPerms
{
    public InptChannel AllowedGarblerChannels      { get; set; } = 0;
    public bool        ChatGarblerActive           { get; set; } = false;
    public bool        ChatGarblerLocked           { get; set; } = false;
    public bool        GaggedNameplate             { get; set; } = false;

    // wardrobe global modifiable permissions
    public bool        WardrobeEnabled             { get; set; } = false;
    public bool        GagVisuals                  { get; set; } = false;
    public bool        RestrictionVisuals          { get; set; } = false;
    public bool        RestraintSetVisuals         { get; set; } = false;


    // global puppeteer modifiable permissions.
    public bool        PuppeteerEnabled            { get; set; } = false;
    public string      TriggerPhrase               { get; set; } = string.Empty;
    public PuppetPerms PuppetPerms                 { get; set; } = 0;

    // global toybox modifiable permissions
    public bool        ToyboxEnabled               { get; set; } = false;
    public bool        ToysAreInteractable         { get; set; } = false;
    public bool        InVibeRoom                  { get; set; } = false;
    public bool        SpatialAudio                { get; set; } = false;

    /// <summary> The UID of the applier on the hypnosis effect. </summary>
    public string      HypnosisCustomEffect        { get; set; } = string.Empty;

    // global hardcore permissions (readonly for everyone)
    // Contains the UID who applied it when active. If Devotional, will have    |pairlocked    appended.
    public string      LockedFollowing             { get; set; } = string.Empty;
    public string      LockedEmoteState            { get; set; } = string.Empty;
    public string      IndoorConfinement           { get; set; } = string.Empty;
    public string      Imprisonment                { get; set; } = string.Empty;
    public string      ChatBoxesHidden             { get; set; } = string.Empty;
    public string      ChatInputHidden             { get; set; } = string.Empty;
    public string      ChatInputBlocked            { get; set; } = string.Empty;

    // Global PiShock Permissions & Helpers.
    public string      GlobalShockShareCode        { get; set; } = string.Empty;
    public bool        AllowShocks                 { get; set; } = false;
    public bool        AllowVibrations             { get; set; } = false;
    public bool        AllowBeeps                  { get; set; } = false;
    public int         MaxIntensity                { get; set; } = -1;
    public int         MaxDuration                 { get; set; } = -1;
    public TimeSpan    ShockVibrateDuration        { get; set; } = TimeSpan.Zero;

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
}
