using GagspeakAPI.Enums;
using GagspeakAPI.Data.Interfaces;
using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterWardrobeData : IPadlockable
{
	// Properties specific to wardrobe data (subject to change my brain hurts)
	public List<string> OutfitNames { get; set; } = new(); // the list of restraint sets names a user has.

	public string ActiveSetName { get; set; } = string.Empty;
	public string ActiveSetDescription { get; set; } = string.Empty;
	public string ActiveSetEnabledBy { get; set; } = string.Empty;
    public string Padlock { get; set; } = Padlocks.None.ToName(); // Type of padlock used to lock the set.
	public string Password { get; set; } = ""; // password bound to the set's lock type.
	public DateTimeOffset Timer { get; set; } = DateTimeOffset.UtcNow; // timer placed on the set's lock
	public string Assigner { get; set; } = "SelfApplied"; // UID that locked the set.
}
