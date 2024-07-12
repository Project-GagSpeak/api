using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterWardrobeData
{
    // Properties specific to wardrobe data (subject to change my brain hurts)
    public List<string> OutfitNames { get; set; } = new(); // the list of restraint sets names a user has.

    public string ActiveSetName { get; set; } = string.Empty;
    public string ActiveSetDescription { get; set; } = string.Empty;
    public string ActiveSetEnabledBy { get; set; } = string.Empty;
    public bool ActiveSetIsLocked { get; set; } = false;
    public string ActiveSetLockedBy { get; set; } = string.Empty;
    public DateTimeOffset ActiveSetLockTime { get; set; } = DateTimeOffset.Now;
}