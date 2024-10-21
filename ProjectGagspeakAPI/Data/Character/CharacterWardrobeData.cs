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
	public List<RestraintDto> Outfits { get; set; } = new(); // the list of restraint sets names a user has.

    public Guid ActiveSetId { get; set; } = Guid.Empty;
	public string ActiveSetName { get; set; } = string.Empty;
	public string ActiveSetEnabledBy { get; set; } = string.Empty;
    public string Padlock { get; set; } = Padlocks.None.ToName(); // Type of padlock used to lock the set.
	public string Password { get; set; } = ""; // password bound to the set's lock type.
	public DateTimeOffset Timer { get; set; } = DateTimeOffset.UtcNow; // timer placed on the set's lock
	public string Assigner { get; set; } = Globals.SelfApplied; // UID that locked the set.

    // override the toString command.
    public override string ToString()
    {
        return $"ActiveId = {ActiveSetId}, Name = {ActiveSetName}, EnabledBy = {ActiveSetEnabledBy}, " +
            $"Padlock = {Padlock}, Password = {Password}, Timer = {Timer}, Assigner = {Assigner}";
    }
}

[MessagePackObject(keyAsPropertyName: true)]
public record RestraintDto
{
    /// <summary>
    /// The Identifier of the restraint set. 
    /// (Persists across namechanges to prevent confusion in stored data)
    /// </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary>
    /// The name given to the restraint set.
    /// </summary>
    public string Name = string.Empty;
}
