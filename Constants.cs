namespace GagspeakAPI;

/// <summary> Constants used across GagSpeak. </summary>
public static class Constants
{
    /// <summary>
    ///     The Maximum number of Garbler Restriction Slots.
    /// </summary>
    public const int MaxGagSlots = 3;

    /// <summary>
    ///    The Maximum number of Generic Restriction Slots.
    /// </summary>
    public const int MaxRestrictionSlots = 5;

    /// <summary>
    ///     The Maximum number of Restraint Layers.
    /// </summary>
    public const int MaxRestraintLayers = 5;

    /// <summary>
    ///     Denotes if an action was applied by the client and not another pair.
    /// </summary>
    public const string SelfApplied = "SelfApplied";

    /// <summary>
    ///     Denote that the permission can only be unlocked by the applierUID defined to the left of the |pairlocked
    /// </summary>
    public const string DevotedString = "|pairlocked";

    // Stuff used for tag things? If they are ever used for anything i guess?
    public const string CustomAllTag = "Gagspeak_All";
    public const string CustomOfflineTag = "Gagspeak_Offline";
    public const string CustomOnlineTag = "Gagspeak_Online";
    public const string CustomVisibleTag = "Gagspeak_Visible";
    public const string DefaultHypnoPath = "Hypno Spiral.png";
    public const string DefaultBlindfoldPath = "Blindfold Light.png";
}
