using GagspeakAPI.Network;
using MessagePack;
using System.Numerics;

namespace GagspeakAPI.Data.Permissions;

/// <summary>
///     a secondary set of 'Global Permissions' for a kinksters Hardcore state. <para />
///     This became nessisary as Hardcore's functionality grew.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record HardcoreState : IReadOnlyHardcoreState
{
    // Locked Following
    public string LockedFollowing { get; set; } = string.Empty;

    // Emote State
    public string LockedEmoteState { get; set; } = string.Empty;
    public DateTimeOffset EmoteExpireTime { get; set; } = DateTimeOffset.MinValue;
    public ushort EmoteId { get; set; } = 0;
    public byte EmoteCyclePose { get; set; } = 0;

    // Confinement
    public string IndoorConfinement { get; set; } = string.Empty;
    public DateTimeOffset ConfinementTimer { get; set; } = DateTimeOffset.MinValue;
    public int ConfinedWorld { get; set; } = 0;
    public int ConfinedCity { get; set; } = 0;
    public int ConfinedWard { get; set; } = 0;
    public int ConfinedPlaceId { get; set; } = 0; // Can represent House Plot ID, or Apartment ID.
    public bool ConfinedInApartment { get; set; } = false;
    public bool ConfinedInSubdivision { get; set; } = false;

    // Imprisonment
    public string Imprisonment { get; set; } = string.Empty;
    public DateTimeOffset ImprisonmentTimer { get; set; } = DateTimeOffset.MinValue;
    public short ImprisonedTerritory { get; set; } = 0; // useful for relogs and stuff.
    public SerializableVector3 ImprisonedPos { get; set; } = Vector3.Zero;
    public float ImprisonedRadius { get; set; } = 1.0f;

    // Chat Boxes
    public string ChatBoxesHidden { get; set; } = string.Empty;
    public DateTimeOffset ChatBoxesHiddenTimer { get; set; } = DateTimeOffset.MinValue;

    // Chat Input
    public string ChatInputHidden { get; set; } = string.Empty;
    public DateTimeOffset ChatInputHiddenTimer { get; set; } = DateTimeOffset.MinValue;

    // Chat Input Blocked
    public string ChatInputBlocked { get; set; } = string.Empty;
    public DateTimeOffset ChatInputBlockedTimer { get; set; } = DateTimeOffset.MinValue;

    // Hypnotic Effect
    public string         HypnoticEffect    { get; set; } = string.Empty;
    public DateTimeOffset HypnoticEffectTimer { get; set; } = DateTimeOffset.MinValue;
}
