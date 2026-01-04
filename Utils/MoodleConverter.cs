namespace GagspeakAPI.Util;
public static class MoodleConverter
{
    // For converting Collar Moodles.
    public static MoodlesStatusInfo FromValues(Guid id, int iconId, string title, string desc, StatusType type, string fxPath)
    {
        return new MoodlesStatusInfo
        {
            GUID = id,
            IconID = iconId,
            Title = title,
            Description = desc,
            CustomVFXPath = fxPath,
            ExpireTicks = -1,
            Type = type,
            Permanent = true
        };
    }
}
