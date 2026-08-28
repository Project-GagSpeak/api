using GagspeakAPI.Attributes;
using GagspeakAPI.Chat;
using GagspeakAPI.Enums;

namespace GagspeakAPI;

// We handle this through individual cases because its more efficient 
public static class FlagEx
{
    public static bool HasAny(this Traits flags, Traits check) => (flags & check) != 0;
    public static bool HasAny(this ToyMotor flags, ToyMotor check) => (flags & check) != 0;
    public static bool HasAny(this RestraintFlags flags, RestraintFlags check) => (flags & check) != 0;
    public static bool HasAny(this RestraintLayer flags, RestraintLayer check) => (flags & check) != 0;
    public static bool HasAny(this CollarAccess flags, CollarAccess check) => (flags & check) != 0;
    public static bool HasAny(this LociAccess flags, LociAccess check) => (flags & check) != 0;
    public static bool HasAny(this ChatFlags flags, ChatFlags check) => (flags & check) != 0;

    public static bool HasAll(this ChatFlags flags, ChatFlags check) => (flags & check) == check;

    /// <returns> If only one flag in a flag enum is set. </returns>
    public static bool IsSingleFlagSet(byte value)
        => value != 0 && (value & (value - 1)) == 0;
}
