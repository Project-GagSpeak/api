namespace GagspeakAPI.Util;
public static class LociConverter
{
    // For converting Collar Locis.
    public static LociStatusInfo FromValues(Guid id, int iconId, string title, string desc, StatusType type, string fxPath)
    {
        return new LociStatusInfo
        {
            GUID = id,
            IconID = iconId,
            Title = title,
            Description = desc,
            CustomVFXPath = fxPath,
            ExpireTicks = -1,
            Type = type,
        };
    }
}
