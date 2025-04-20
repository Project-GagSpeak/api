namespace GagspeakAPI;

/// <summary>
/// Container for all globally used strings across client and server.
/// </summary>
public static class Globals
{
    public const int MaxGagSlots = 3;
    public const int MaxRestrictionSlots = 5;
    public const int MaxRestraintLayers = 5;
    public const int MaxRadioOptionCount = 2;

    /// <summary>
    /// Used to denote if an action was applied by the client and not another pair.
    /// </summary>
    public const string SelfApplied = "SelfApplied";

    /// <summary>
    /// Used to denote that the permission can only be unlocked by the applierUID defined to the left of the |
    /// </summary>
    public const string DevotedString = "|pairlocked";

    // Stuff used for tag things? If they are ever used for anything i guess?
    public const string CustomAllTag = "Gagspeak_All";
    public const string CustomOfflineTag = "Gagspeak_Offline";
    public const string CustomOnlineTag = "Gagspeak_Online";
    public const string CustomVisibleTag = "Gagspeak_Visible";

    public static readonly string[] ServerTagFolderNames =
    {
        CustomAllTag,
        CustomOfflineTag,
        CustomOnlineTag,
        CustomVisibleTag
    };
}
