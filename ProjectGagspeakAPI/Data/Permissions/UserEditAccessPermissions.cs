using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record UserEditAccessPermissions
{
    // unique permissions stored here:
    public bool ChatGarblerActiveAllowed { get; set; } = false; // Global
    public bool ChatGarblerLockedAllowed { get; set; } = false; // Global

    public bool PermanentLocksAllowed { get; set; } = false;
    public bool OwnerLocksAllowed { get; set; } = false;
    public bool DevotionalLocksAllowed { get; set; } = false;

    public bool ApplyGagsAllowed { get; set; } = false;
    public bool LockGagsAllowed { get; set; } = false;
    public bool MaxGagTimeAllowed { get; set; } = false;
    public bool UnlockGagsAllowed { get; set; } = false;
    public bool RemoveGagsAllowed { get; set; } = false;

    // unique permissions for the wardrobe
    public bool WardrobeEnabledAllowed { get; set; } = false; // Global
    public bool GagVisualsAllowed { get; set; } = false; // Global
    public bool RestrictionVisualsAllowed { get; set; } = false; // Global
    public bool RestraintSetVisualsAllowed { get; set; } = false; // Global

    public bool ApplyRestrictionsAllowed { get; set; } = false;
    public bool LockRestrictionsAllowed { get; set; } = false;
    public bool MaxRestrictionTimeAllowed { get; set; } = false;
    public bool UnlockRestrictionsAllowed { get; set; } = false;
    public bool RemoveRestrictionsAllowed { get; set; } = false;

    public bool ApplyRestraintSetsAllowed { get; set; } = false;
    public bool LockRestraintSetsAllowed { get; set; } = false;
    public bool MaxRestraintTimeAllowed { get; set; } = false;
    public bool UnlockRestraintSetsAllowed { get; set; } = false;
    public bool RemoveRestraintSetsAllowed { get; set; } = false;

    // unique permissions for the puppeteer
    public bool PuppeteerEnabledAllowed { get; set; } = false; // Global
    public bool SitRequestsAllowed { get; set; } = false;
    public bool MotionRequestsAllowed { get; set; } = false;
    public bool AliasRequestsAllowed { get; set; } = false;
    public bool AllRequestsAllowed { get; set; } = false;

    // Moodles
    public bool MoodlesEnabledAllowed { get; set; } = false; // Global
    public bool PositiveStatusTypesAllowed { get; set; } = false;
    public bool NegativeStatusTypesAllowed { get; set; } = false;
    public bool SpecialStatusTypesAllowed { get; set; } = false;
    public bool PairCanApplyOwnMoodlesToYouAllowed { get; set; } = false;
    public bool PairCanApplyYourMoodlesToYouAllowed { get; set; } = false;
    public bool MaxMoodleTimeAllowed { get; set; } = false;
    public bool PermanentMoodlesAllowed { get; set; } = false;
    public bool RemovingMoodlesAllowed { get; set; } = false;

    // unique permissions for the toybox
    public bool ToyboxEnabledAllowed { get; set; } = false; // Global
    public bool LockToyboxUIAllowed { get; set; } = false; // Global
    public bool SpatialAudioAllowed { get; set; } = false; // Global
    public bool CanToggleToyStateAllowed { get; set; } = false;
    public bool CanUseRemoteOnToysAllowed { get; set; } = false;
    public bool CanExecutePatternsAllowed { get; set; } = false;
    public bool CanStopPatternsAllowed { get; set; } = false;
    public bool CanToggleAlarmsAllowed { get; set; } = false;
    public bool CanToggleTriggersAllowed { get; set; } = false;
}
