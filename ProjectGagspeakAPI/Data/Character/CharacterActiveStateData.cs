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
    public string Padlock { get; set; } = "None"; // Type of padlock used to lock the set.
    public string Password { get; set; } = ""; // password bound to the set's lock type.
    public DateTimeOffset Timer { get; set; } = DateTimeOffset.UtcNow; // timer placed on the set's lock
    public string Assigner { get; set; } = ""; // UID that locked the set.

	/* User's ToyboxData state references */
	public Guid ToyboxActivePatternName { get; set; } = Guid.Empty; // the name of the user's actively running pattern
}
