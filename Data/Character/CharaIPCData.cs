using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> 
///     Only sent to people once when they login, or after a safeword. 
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaIpcDataFull
{
    // Until we manage pcp's inside of collections, it won't be worth enforcing this.
    // public string? ModManips { get; set; } = null;
    public string? GlamourerBase64 { get; set; } = null; // only for player currently.
    public string? CustomizeProfile { get; set; } = null; // currently only for player.
    public string? HeelsOffset { get; set; } = null;
    public string? HonorificTitle { get; set; } = null;
    public string? PetNicknames { get; set; } = null;

    public void UpdateNonNull(CharaIpcDataFull other)
    {
        if (other.CustomizeProfile != null) CustomizeProfile = other.CustomizeProfile;
        if (other.GlamourerBase64 != null) GlamourerBase64 = other.GlamourerBase64;
        if (other.HeelsOffset != null) HeelsOffset = other.HeelsOffset;
        if (other.HonorificTitle != null) HonorificTitle = other.HonorificTitle;
        if (other.PetNicknames != null) PetNicknames = other.PetNicknames;
    }

    public void UpdateNewData(DataSyncKind type, string newData)
    {
        switch (type)
        {
            case DataSyncKind.Glamourer: GlamourerBase64 = newData; break;
            case DataSyncKind.CPlus: CustomizeProfile = newData; break;
            case DataSyncKind.Heels: HeelsOffset = newData; break;
            case DataSyncKind.Honorific: HonorificTitle = newData; break;
            case DataSyncKind.PetNames: PetNicknames = newData; break;
            default: break;
        }
    }

    public bool IsEmpty()
        => GlamourerBase64 == null && CustomizeProfile == null && HeelsOffset == null && HonorificTitle == null && PetNicknames == null;
}
