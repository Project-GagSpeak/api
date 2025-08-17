using GagspeakAPI.Enums;

namespace GagspeakAPI.Util;
public static class MoodleConverter
{
    public static MoodlesStatusInfo FromValues(
        Guid id, int iconId, string title, string description, byte type, string fxPath)
    {
        return new MoodlesStatusInfo
        {
            GUID = id,
            IconID = iconId,
            Title = title,
            Description = description,
            Type = (StatusType)type,
            Dispelable = false,
            Persistent = true,
            NoExpire = true,
            AsPermanent = true,
            CustomVFXPath = fxPath,
        };
    }
}
