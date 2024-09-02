using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CharacterActiveStateData
{
	public string WardrobeActiveSetName { get; set; } = ""; // the name of the user's active outfit
	public string WardrobeActiveSetAssigner { get; set; } = ""; // person who Enabled the set.
    public string WardrobeActiveSetPadLock { get; set; } = "None"; // Type of padlock used to lock the set.
    public string WardrobeActiveSetPassword { get; set; } = ""; // password bound to the set's lock type.
    public DateTimeOffset WardrobeActiveSetLockTime { get; set; } = DateTimeOffset.UtcNow; // timer placed on the set's lock
    public string WardrobeActiveSetLockAssigner { get; set; } = ""; // UID that locked the set.

	/* User's ToyboxData state references */
	public string ToyboxActivePatternName { get; set; } = ""; // the name of the user's actively running pattern
}