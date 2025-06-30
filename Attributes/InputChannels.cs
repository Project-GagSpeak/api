namespace GagspeakAPI.Attributes;

/// <summary> Determines the channels that we can send garbled messages to. </summary>
/// <remarks> This does not reflect accurately the real chatChannelID, refer to extentions. </remarks>
[Flags]
public enum InptChannel : long
{
    None = 0,
    Tell_In = 1L << 0,
    Say = 1L << 1,
    Party = 1L << 2,
    Alliance = 1L << 3,
    Yell = 1L << 4,
    Shout = 1L << 5,
    FreeCompany = 1L << 6,
    NoviceNetwork = 1L << 8,

    CWL1 = 1L << 9,
    CWL2 = 1L << 10,
    CWL3 = 1L << 11,
    CWL4 = 1L << 12,
    CWL5 = 1L << 13,
    CWL6 = 1L << 14,
    CWL7 = 1L << 15,
    CWL8 = 1L << 16,

    Tell = 1L << 17,

    LS1 = 1L << 19,
    LS2 = 1L << 20,
    LS3 = 1L << 21,
    LS4 = 1L << 22,
    LS5 = 1L << 23,
    LS6 = 1L << 24,
    LS7 = 1L << 25,
    LS8 = 1L << 26,

    Echo = 1L << 56,
}

public static class InputChannelExtensions
{
    /// <summary>
    /// Determines if a channel index is allowed by the given flag set.
    /// </summary>
    public static bool IsActiveChannel(this InptChannel flags, int channel)
    {
        // Optional: Prevent bitshifting into undefined territory.
        if (channel < 0 || channel > 63)
            return false;

        return (flags & (InptChannel)(1L << channel)) != 0;
    }

    /// <summary> Sets or clears a specific input channel flag. </summary>
    /// <param name="flags">The current flag set.</param>
    /// <param name="channelIdx">The specific channel to modify.</param>
    /// <param name="enabled">Whether the channel should be enabled (true) or disabled (false).</param>
    /// <returns>The updated flag set.</returns>
    public static InptChannel SetChannelState(this InptChannel flags, int channelIdx, bool enabled)
    {
        if (channelIdx < 0 || channelIdx > 63)
            return flags;

        var channelFlag = (InptChannel)(1L << channelIdx);
        return enabled ? flags | channelFlag : flags & ~channelFlag;
    }
}

