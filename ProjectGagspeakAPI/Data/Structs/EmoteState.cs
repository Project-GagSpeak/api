namespace GagspeakAPI.Data.Struct;

public struct EmoteState
{
    public string UID { get; init; }
    public ushort EmoteID { get; init; }
    public byte CyclePoseByte { get; init; }
    public bool Devotional { get; init; }

    public EmoteState()
    {
        UID = string.Empty;
        EmoteID = 0;
        CyclePoseByte = 0;
        Devotional = false;
    }

    public EmoteState(string uid, ushort emoteId, byte cyclePoseByte, bool devotional)
    {
        UID = uid;
        EmoteID = emoteId;
        CyclePoseByte = cyclePoseByte;
        Devotional = devotional;
    }
}
