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
	public bool WardrobeActiveSetLocked { get; set; } = false; // the lock status of the user's active outfit
	public string WardrobeActiveSetLockAssigner { get; set; } = ""; // person who Locked the set.
	public DateTimeOffset WardrobeActiveSetLockTime { get; set; } = DateTimeOffset.MinValue; // when the locked set will expire

	/* User's ToyboxData state references */
	public string ToyboxActivePatternName { get; set; } = ""; // the name of the user's actively running pattern
}