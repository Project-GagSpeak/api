using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterWardrobeData
{
	// Properties specific to wardrobe data (subject to change my brain hurts)
	public List<string> OutfitNames { get; set; } = new(); // the list of restraint sets names a user has.

	public string ActiveSetName { get; set; } = string.Empty;
	public string ActiveSetDescription { get; set; } = string.Empty;
	public string ActiveSetEnabledBy { get; set; } = string.Empty;
	public string WardrobeActiveSetPadLock { get; set; } = "None"; // Type of padlock used to lock the set.
	public string WardrobeActiveSetPassword { get; set; } = ""; // password bound to the set's lock type.
	public DateTimeOffset WardrobeActiveSetLockTime { get; set; } = DateTimeOffset.UtcNow; // timer placed on the set's lock
	public string WardrobeActiveSetLockAssigner { get; set; } = ""; // UID that locked the set.
}