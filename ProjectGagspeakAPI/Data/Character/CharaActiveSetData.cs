using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data.Character;

[MessagePackObject(keyAsPropertyName: true)]
public record CharaActiveSetData : IPadlockable
{
    public Guid ActiveSetId { get; set; } = Guid.Empty; // the ID of the user's active outfit
	public string ActiveSetEnabler { get; set; } = string.Empty; // person who Enabled the set.
    public string Padlock { get; set; } = Padlocks.None.ToName(); // Type of padlock used to lock the set.
    public string Password { get; set; } = string.Empty; // password bound to the set's lock type.
    public DateTimeOffset Timer { get; set; } = DateTimeOffset.MinValue; // timer placed on the set's lock
    public string Assigner { get; set; } = string.Empty; // UID that locked the set.

    public bool IsLocked() => Padlock != Padlocks.None.ToName();
    public bool HasTimerExpired() => Timer < DateTimeOffset.UtcNow;

    public override string ToString()
    {
        return $"ActiveId = {ActiveSetId}, EnabledBy = {ActiveSetEnabler}, " +
            $"Padlock = {Padlock}, Password = {Password}, Timer = {Timer}, Assigner = {Assigner}";
    }

    public CharaActiveSetData DeepCloneData()
    {
        var clone = new CharaActiveSetData
        {
            ActiveSetId = ActiveSetId,
            ActiveSetEnabler = ActiveSetEnabler,
            Padlock = Padlock,
            Password = Password,
            Timer = Timer,
            Assigner = Assigner,
        };
        return clone;
    }
}
