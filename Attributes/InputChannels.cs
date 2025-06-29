namespace GagspeakAPI.Attributes;

/// <summary> Determines the channels that we can send garbled messages to. </summary>
/// <remarks> This does not reflect accurately the real chatChannelID, refer to extentions. </remarks>
[Flags]
public enum InptChannel : int
{
    None = 0,
    Tell_In = 1 << 0,
    Say = 1 << 1,
    Party = 1 << 2,
    Alliance = 1 << 3,
    Yell = 1 << 4,
    Shout = 1 << 5,
    FreeCompany = 1 << 6,
    NoviceNetwork = 1 << 8,

    CWL1 = 1 << 9,
    CWL2 = 1 << 10,
    CWL3 = 1 << 11,
    CWL4 = 1 << 12,
    CWL5 = 1 << 13,
    CWL6 = 1 << 14,
    CWL7 = 1 << 15,
    CWL8 = 1 << 16,

    Tell = 1 << 17,

    LS1 = 1 << 19,
    LS2 = 1 << 20,
    LS3 = 1 << 21,
    LS4 = 1 << 22,
    LS5 = 1 << 23,
    LS6 = 1 << 24,
    LS7 = 1 << 25,
    LS8 = 1 << 26,
}

public static class InputChannelExtensions
{
    /// <summary>
    /// Determines if a channel index is allowed by the given flag set.
    /// </summary>
    public static bool IsActiveChannel(this InptChannel flags, int channel)
    {
        // Optional: Prevent bitshifting into undefined territory.
        if (channel < 0 || channel > 31)
            return false;

        return (flags & (InptChannel)(1 << channel)) != 0;
    }

    /// <summary> Sets or clears a specific input channel flag. </summary>
    /// <param name="flags">The current flag set.</param>
    /// <param name="channelIdx">The specific channel to modify.</param>
    /// <param name="enabled">Whether the channel should be enabled (true) or disabled (false).</param>
    /// <returns>The updated flag set.</returns>
    public static InptChannel SetChannelState(this InptChannel flags, int channelIdx, bool enabled)
    {
        if (channelIdx < 0 || channelIdx > 31)
            return flags;

        var channelFlag = (InptChannel)(1 << channelIdx);
        return enabled ? flags | channelFlag : flags & ~channelFlag;
    }
}

