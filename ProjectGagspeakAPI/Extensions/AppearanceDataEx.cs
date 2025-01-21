using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;

/// <summary>
/// An extention class for available helper methods with gag data.
/// </summary>
public static class GagDataEx
{
    /// <summary> Determines if any gag is currently equipped in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to check.</param>
    /// <returns>True if any gag is equipped; otherwise, false.</returns>
    public static bool IsGagged(this CharaGagData gagData) => gagData.GagSlots.Any(x => x.GagType != GagType.None.GagName());

    /// <summary> Calculates the total number of gags currently equipped in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to evaluate.</param>
    /// <returns>The total count of equipped gags.</returns>
    public static int TotalGagsEquipped(this CharaGagData gagData) => gagData.GagSlots.Count(x => x.GagType != GagType.None.GagName());

    /// <summary> Checks if any gag is actively equipped in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to check.</param>
    /// <returns>True if any gag is actively equipped; otherwise, false.</returns>
    public static bool AnyGagActive(this CharaGagData gagData) => gagData.GagSlots.Any(x => x.GagType != GagType.None.GagName());

    /// <summary> Checks if any gag is locked in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to check.</param>
    /// <returns>True if any gag is locked; otherwise, false.</returns>
    public static bool AnyGagLocked(this CharaGagData gagData) => gagData.GagSlots.Any(x => x.Padlock != Padlocks.None.ToName());

    /// <summary> Retrieves a list of the names of all currently equipped gags in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to query.</param>
    /// <returns>A list of names of the currently equipped gags.</returns>
    public static List<string> CurrentGagNames(this CharaGagData gagData) => gagData.GagSlots.Select(gag => gag.GagType).ToList();

    /// <summary>
    /// Tracking keys use the format: ((GagLayer)i).ToString() + '_' + gagType.GagName()
    /// </summary>
    /// <returns> The list of tracking keys for all active gags. </returns>
    public static List<string> ActiveGagTrackingKeys(this CharaGagData gagData)
    {
        // return a list of the gagSlots that have GagTypes which are not GagType.None, and return a string of (GagLayer)i.tostring() + gagType.GagName()
        var trackingKeys = new List<string>();

        // Iterate through each gag slot in gagData using an index
        for (int i = 0; i < gagData.GagSlots.Length; i++)
        {
            var gagSlot = gagData.GagSlots[i];

            // Check if the GagType is not GagType.None
            if (gagSlot.GagType.ToGagType() is not GagType.None)
            {
                string trackingKey = ((GagLayer)i).ToString() + '_' + gagSlot.GagType;

                // Add the generated tracking key to the list
                trackingKeys.Add(trackingKey);
            }
        }

        // Return the list of tracking keys
        return trackingKeys;
    }

    /// <summary> Finds the index of the first unoccupied gag slot in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to search.</param>
    /// <returns>The index of the first unoccupied slot, or -1 if no slots are available.</returns>
    public static int FindFirstUnused(this CharaGagData gagData)
    {
        for (var i = 0; i < gagData.GagSlots.Length; i++)
        {
            if (gagData.GagSlots[i].GagType == GagType.None.GagName())
                return i;
        }
        return -1;
    }

    /// <summary> Finds the index of the outermost active gag slot in the character's appearance data. </summary>
    /// <param name="gagData">The character appearance data to search.</param>
    /// <returns>The index of the outermost active slot, or -1 if no active slots are found.</returns>
    public static int FindOutermostActive(this CharaGagData gagData)
    {
        for (var i = gagData.GagSlots.Length - 1; i >= 0; i--)
        {
            if (gagData.GagSlots[i].GagType != GagType.None.GagName())
                return i;
        }
        return -1;
    }

    /// <summary> Finds the index of the outermost active gag slot in the character's appearance data that matches the specified gag type. </summary>
    /// <param name="gagData">The character appearance data to search.</param>
    /// <param name="match">The gag type to match.</param>
    /// <returns>The index of the outermost active slot that matches the specified gag type, or -1 if no matching slots are found.</returns>
    public static int FindOutermostActive(this CharaGagData gagData, GagType match)
    {
        for (var i = gagData.GagSlots.Length - 1; i >= 0; i--)
        {
            if (gagData.GagSlots[i].GagType == match.GagName())
                return i;
        }
        return -1;
    }
}
