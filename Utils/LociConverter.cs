using GagspeakAPI.Data;

namespace GagspeakAPI.Util;

// Maybe expand this, the API is a bit of an organizational mess right now.
public static class LociConverter
{
    // For converting Collar Locis.
    public static LociStatusStruct FromValues(Guid id, uint iconId, string title, string desc, byte type, string fxPath)
        => new LociStatusStruct
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
