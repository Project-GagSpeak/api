namespace GagspeakAPI.Data.Permissions;
public interface IReadOnlyHardcoreState
{
    /// <summary>
    ///     The current state of LockedFollow for Hardcore mode. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string LockedFollowing { get; }

    /// <summary>
    ///     The current state of LockedFollow for Hardcore mode. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string LockedEmoteState { get; }

    /// <summary>
    ///     The time when the locked emote performance will auto-expire. <para />
    ///     If this is <c> DateTimeOffset.MinValue</c>, it remains active indefinitely.
    /// </summary>
    public DateTimeOffset EmoteExpireTime { get; }

    /// <summary>
    ///     The emoteId to force. If this emote is not unlocked, it will not play.
    /// </summary>
    public ushort EmoteId { get; }

    /// <summary>
    ///     The Cycle Pose value to swap to when forcing groundsit or sit commands.
    /// </summary>
    public byte EmoteCyclePose { get; }


    /// <summary>
    ///     The current Confinement state. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string IndoorConfinement { get; }

    /// <summary>
    ///    The time when the confinement will auto-expire. <para />
    ///    If this is <c>DateTimeOffset.MinValue</c>, it remains active indefinitely.
    /// </summary>
    public DateTimeOffset ConfinementTimer { get; }

    /// <summary>
    ///     The world that the kinkster is confined to.
    /// </summary>
    public int ConfinedWorld { get; }

    /// <summary>
    ///     The city that the kinkster is confined to.
    /// </summary>
    public int ConfinedCity { get; }

    /// <summary>
    ///     The ward that the kinkster is confined to.
    /// </summary>
    public int ConfinedWard { get; }

    /// <summary>
    ///     The plot number or apartment number the kinkster is confined to. <para />
    ///     Can represent House Plot ID, or Apartment ID.
    /// </summary>
    public int ConfinedPlaceId { get; }

    /// <summary>
    ///     If the confinement is taking place in a house or an apartment. <para />
    /// </summary>
    public bool ConfinedInApartment { get; }

    /// <summary>
    ///     If the confinement is taking place in a ward subdivision. <para />
    /// </summary>
    public bool ConfinedInSubdivision { get; }

    /// <summary>
    ///     The current Imprisonment state. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string Imprisonment { get; }

    /// <summary>
    ///    The time when the confinement will auto-expire. <para />
    ///    If this is <c>DateTimeOffset.MinValue</c>, it remains active indefinitely.
    /// </summary>
    public DateTimeOffset ImprisonmentTimer { get; }

    /// <summary>
    ///     The territory ID that the kinkster is imprisoned in. <para />
    ///     This is useful for relogs and other checks.
    /// </summary>
    public short ImprisonedTerritory { get; }
    // public SerializableVector3 ImprisonedPos { get; } <-- Do not include this, but 3 floats in the DB instead.
    
    /// <summary>
    ///     How far this kinkster can stray from their imprisoned position.
    /// </summary>
    public float ImprisonedRadius { get; }

    /// <summary>
    ///     The current visibility state of this kinkster's chat boxes. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string ChatBoxesHidden { get; }

    /// <summary>
    ///     The time to wait until chat boxes become visible again. <para />
    ///     If this is <c>DateTimeOffset.MinValue</c>, it remains hidden indefinitely.
    /// </summary>
    public DateTimeOffset ChatBoxesHiddenTimer { get; }

    /// <summary>
    ///     The current visibility state of this kinkster's chat input. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string ChatInputHidden { get; }

    /// <summary>
    ///     The time to wait until chat input becomes visible again. <para />
    ///     If this is <c>DateTimeOffset.MinValue</c>, it remains hidden indefinitely.
    /// </summary>
    public DateTimeOffset ChatInputHiddenTimer { get; }

    /// <summary>
    ///     The current state of this kinkster's chat input being blocked. <para />
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional.
    /// </summary>
    public string ChatInputBlocked { get; }

    /// <summary>
    ///     The time to wait until chat input becomes accessible again. <para />
    ///     If this is <c>DateTimeOffset.MinValue</c>, it remains blocked indefinitely.
    /// </summary>
    public DateTimeOffset ChatInputBlockedTimer { get; }

    /// <summary>
    ///     The current state of this kinkster's active hypnotic effect. <para />
    ///     
    ///     Contains the UID of the enactor when active, and <c>|pairlocked</c>
    ///     at the end if the lock is devotional. <para />
    ///     
    ///     If the enactor is the same as the Kinkster that this belongs to, 
    ///     it is self-enacted, and should not be replaced.
    /// </summary>
    public string HypnoticEffect { get; }

    /// <summary>
    ///     How long the hypnotic effect should last until it expires.
    /// </summary>
    public DateTimeOffset HypnoticEffectTimer { get; }

    /// Note aside, hypno effect data is stored clientside, to not bloat the 
    /// DB with custom images and large wordbanks.
}
