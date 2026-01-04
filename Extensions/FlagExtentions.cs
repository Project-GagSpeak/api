using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;

// We handle this through individual cases because its more efficient 
public static class FlagEx
{
    // we avoid doing generic types here because it actually increases the processing time in the compiler if we convert to ambiguous types.
    public static bool HasAny(this Traits flags, Traits check) => (flags & check) != 0;
    public static bool HasAny(this ToyMotor flags, ToyMotor check) => (flags & check) != 0;
    public static bool HasAny(this RestraintFlags flags, RestraintFlags check) => (flags & check) != 0;
    public static bool HasAny(this RestraintLayer flags, RestraintLayer check) => (flags & check) != 0;
    public static bool HasAny(this CollarAccess flags, CollarAccess check) => (flags & check) != 0;
    public static bool HasAny(this MoodleAccess flags, MoodleAccess check) => (flags & check) != 0;
    public static bool HasAny(this Modifiers flags, Modifiers check) => (flags & check) != 0;
    public static bool HasAny(this StatusType flags, StatusType check) => (flags & check) != 0;

    /// <returns> If only one flag in a flag enum is set. </returns>
    public static bool IsSingleFlagSet(byte value)
        => value != 0 && (value & (value - 1)) == 0;
}
