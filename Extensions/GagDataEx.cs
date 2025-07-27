using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using GagspeakAPI.Util;

namespace GagspeakAPI.Extensions;

/// <summary> 
///     An extention class for available helper methods with gag data.
/// </summary>
public static class GagDataEx
{
    /// <summary> Determines if any gag is currently equipped in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to check.</param>
    /// <returns>True if any gag is equipped; otherwise, false.</returns>
    public static bool IsGagged(this CharaActiveGags gagData) => gagData.GagSlots.Any(x => x.GagItem is not GagType.None);

    /// <summary> Calculates the total number of gags currently equipped in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to evaluate.</param>
    /// <returns>The total count of equipped gags.</returns>
    public static int TotalGagsEquipped(this CharaActiveGags gagData) => gagData.GagSlots.Count(x => x.GagItem is not GagType.None);

    /// <summary> Checks if any gag is actively equipped in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to check.</param>
    /// <returns>True if any gag is actively equipped; otherwise, false.</returns>
    public static bool AnyGagActive(this CharaActiveGags gagData) => gagData.GagSlots.Any(x => x.GagItem is not GagType.None);

    /// <summary> Checks if any gag is locked in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to check.</param>
    /// <returns>True if any gag is locked; otherwise, false.</returns>
    public static bool AnyGagLocked(this CharaActiveGags gagData) => gagData.GagSlots.Any(x => x.Padlock is not Padlocks.None);

    /// <summary> Retrieves a list of the names of all currently equipped gags in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to query.</param>
    /// <returns>A list of names of the currently equipped gags.</returns>
    public static List<string> CurrentGagNames(this CharaActiveGags gagData) 
        => gagData.GagSlots.Select(gag => gag.GagItem.GagName()).ToList();

    /// <summary>
    /// Tracking keys use the format: ((int)i).ToString() + '_' + gagType.GagName()
    /// </summary>
    /// <returns> The list of tracking keys for all active gags. </returns>
    public static List<string> ActiveGagTrackingKeys(this CharaActiveGags gagData)
    {
        var trackingKeys = new List<string>();

        for (var i = 0; i < gagData.GagSlots.Length; i++)
            if (gagData.GagSlots[i].GagItem is not GagType.None)
                trackingKeys.Add(i + '_' + gagData.GagSlots[i].GagItem.GagName());

        return trackingKeys;
    }

    /// <summary> Finds the index of the first unoccupied gag slot in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to search.</param>
    /// <returns>The index of the first unoccupied slot, or -1 if no slots are available.</returns>
    public static int FindFirstUnused(this CharaActiveGags gagData)
    {
        for (var i = 0; i < gagData.GagSlots.Length; i++)
            if (gagData.GagSlots[i].GagItem is GagType.None)
                return i;

        return -1;
    }

    public static int FindFirstUnlocked(this CharaActiveGags gagData)
    {
        for (var i = 0; i < gagData.GagSlots.Length; i++)
            if (gagData.GagSlots[i].IsLocked() is false)
                return i;

        return -1;
    }


    /// <summary> Finds the index of the outermost active gag slot in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to search.</param>
    /// <returns>The index of the outermost active slot, or -1 if no active slots are found.</returns>
    public static int FindOutermostActive(this CharaActiveGags gagData)
    {
        for (var i = gagData.GagSlots.Length - 1; i >= 0; i--)
            if (gagData.GagSlots[i].GagItem is not GagType.None && gagData.GagSlots[i].IsLocked() is false)
                return i;
        return -1;
    }

    /// <summary> Finds the index of the outermost active gag slot in the character's appearance data that matches the specified gag type. </summary>
    /// <param name="gagData">The character appearance data to search.</param>
    /// <param name="match">The gag type to match.</param>
    /// <returns>The index of the outermost active slot that matches the specified gag type, or -1 if no matching slots are found.</returns>
    public static int FindOutermostActive(this CharaActiveGags gagData, GagType match)
    {
        for (var i = gagData.GagSlots.Length - 1; i >= 0; i--)
            if (gagData.GagSlots[i].GagItem == match && gagData.GagSlots[i].IsLocked() is false)
                return i;

        return -1;
    }

    public static int FindOutermostLocked(this CharaActiveGags gagData)
    {
        for (var i = gagData.GagSlots.Length - 1; i >= 0; i--)
            if (gagData.GagSlots[i].IsLocked())
                return i;

        return -1;
    }

    public static int FindOutermostLocked(this CharaActiveGags gagData, GagType match)
    {
        for (var i = gagData.GagSlots.Length - 1; i >= 0; i--)
            if (gagData.GagSlots[i].GagItem == match)
                return i;

        return -1;
    }


    public static int FindOutermostActiveUnlocked(this CharaActiveRestrictions restrictions)
    {
        for (var i = restrictions.Restrictions.Length - 1; i >= 0; i--)
            if (restrictions.Restrictions[i].IsLocked() is false && restrictions.Restrictions[i].Identifier != Guid.Empty)
                return i;

        return -1;
    }
}
