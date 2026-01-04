using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data.Permissions;

[MessagePackObject(keyAsPropertyName: true)]
public record PairPermAccess
{
    public bool ChatGarblerActiveAllowed            { get; set; } = false; // Global
    public bool ChatGarblerLockedAllowed            { get; set; } = false; // Global
    public bool GaggedNameplateAllowed              { get; set; } = false; // Global

    public bool WardrobeEnabledAllowed              { get; set; } = false; // Global
    public bool GagVisualsAllowed                   { get; set; } = false; // Global
    public bool RestrictionVisualsAllowed           { get; set; } = false; // Global
    public bool RestraintSetVisualsAllowed          { get; set; } = false; // Global

    public bool PermanentLocksAllowed               { get; set; } = false;
    public bool OwnerLocksAllowed                   { get; set; } = false;
    public bool DevotionalLocksAllowed              { get; set; } = false;

    public bool ApplyGagsAllowed                    { get; set; } = false;
    public bool LockGagsAllowed                     { get; set; } = false;
    public bool MaxGagTimeAllowed                   { get; set; } = false;
    public bool UnlockGagsAllowed                   { get; set; } = false;
    public bool RemoveGagsAllowed                   { get; set; } = false;

    public bool ApplyRestrictionsAllowed            { get; set; } = false;
    public bool LockRestrictionsAllowed             { get; set; } = false;
    public bool MaxRestrictionTimeAllowed           { get; set; } = false;
    public bool UnlockRestrictionsAllowed           { get; set; } = false;
    public bool RemoveRestrictionsAllowed           { get; set; } = false;

    public bool ApplyRestraintSetsAllowed           { get; set; } = false;
    public bool ApplyLayersAllowed                  { get; set; } = false;
    public bool ApplyLayersWhileLockedAllowed       { get; set; } = false;
    public bool LockRestraintSetsAllowed            { get; set; } = false;
    public bool MaxRestraintTimeAllowed             { get; set; } = false;
    public bool UnlockRestraintSetsAllowed          { get; set; } = false;
    public bool RemoveLayersAllowed                 { get; set; } = false;
    public bool RemoveLayersWhileLockedAllowed      { get; set; } = false;
    public bool RemoveRestraintSetsAllowed          { get; set; } = false;

    // unique permissions for the puppeteer
    public bool PuppeteerEnabledAllowed             { get; set; } = false; // Global
    public PuppetPerms PuppetPermsAllowed           { get; set; } = PuppetPerms.None;

    // Moodles
    public bool MoodlesEnabledAllowed               { get; set; } = false; // Global
    public MoodleAccess MoodlePermsAllowed           { get; set; } = MoodleAccess.None;
    public bool MaxMoodleTimeAllowed                { get; set; } = false;

    public bool HypnosisMaxTimeAllowed              { get; set; } = false;
    public bool HypnosisSendingAllowed              { get; set; } = false;

    // unique permissions for the toybox
    public bool SpatialAudioAllowed                 { get; set; } = false; // Global
    public bool ExecutePatternsAllowed              { get; set; } = false;
    public bool StopPatternsAllowed                 { get; set; } = false;
    public bool ToggleAlarmsAllowed                 { get; set; } = false;
    public bool ToggleTriggersAllowed               { get; set; } = false;
}
