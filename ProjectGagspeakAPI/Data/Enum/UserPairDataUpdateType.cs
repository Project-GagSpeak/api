namespace GagspeakAPI.Data.Enum;

/// <summary>
/// <b>Very important Enumerator that determines the type of modification being
/// made to a user's character data.</b>
/// <para>
/// This allows us to scope directly to what we need to modify, instead of
/// changing the whole table-row every update.
/// </para>
/// <b>IMPORTANT: </b> This allows us to verify permission access server-side, 
/// and throw error if the user is trying to modify something they shouldn't be.
/// <para> 
/// This effectively prevents modified client-side forks from exploiting
/// changes to other user's where they shouldnt be able to.
/// </para>
/// </summary>
public enum DataUpdateKind
{
    /* Used to know when a dummy enum is passed in */
    None,
    /* ------------------------------ */
    FullDataUpdate, // called during initializations and sign-offs
    /* ------------------------------ */
    AppearanceGagAppliedLayerOne,
    AppearanceGagAppliedLayerTwo,
    AppearanceGagAppliedLayerThree,

    AppearanceGagLockedLayerOne,
    AppearanceGagLockedLayerTwo,
    AppearanceGagLockedLayerThree,
    
    AppearanceGagUnlockedLayerOne,
    AppearanceGagUnlockedLayerTwo,
    AppearanceGagUnlockedLayerThree,
    
    AppearanceGagRemovedLayerOne,
    AppearanceGagRemovedLayerTwo,
    AppearanceGagRemovedLayerThree,
    
    /* ------------------------------ */
    WardrobeRestraintOutfitsUpdated, // Only allow Client owning Data to modify this.
    WardrobeRestraintApplied,
    WardrobeRestraintLocked,
    WardrobeRestraintUnlocked,
    WardrobeRestraintDisabled, // Wording is weird. Removed means taken off, not Deleted.
    
    /* ------------------------------ */
    PuppeteerPlayerNameRegistered, // Only allow Client owning Data to modify this.
    PuppeteerAliasListUpdated, // Only allow Client owning Data to modify this.
    
    /* ------------------------------ */
    IpcUpdateVisible, // Only allow Client owning Data to modify this.

    IpcMoodlesStatusManagerChanged,
    IpcMoodlesStatusesUpdated,
    IpcMoodlesPresetsUpdated,   
    IpcMoodlesCleared,

    /* ------------------------------ */
    ToyboxPatternListUpdated,
    ToyboxPatternActivated,
    ToyboxPatternDeactivated,

    ToyboxAlarmListUpdated, // Only allow Client owning Data to modify this.
    ToyboxAlarmToggled,

    ToyboxTriggerListUpdated, // Only allow Client owning Data to modify this.
    ToyboxTriggerActiveStatusChanged, // when any trigger in the trigger list is activated or deactivated.
}
