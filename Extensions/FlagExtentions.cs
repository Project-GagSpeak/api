using GagspeakAPI.Attributes;
using GagspeakAPI.Data;

namespace GagspeakAPI.Extensions;

// We handle this through individual cases because its more efficient 
public static class FlagEx
{
    // we avoid doing generic types here because it actually increases the processing time in the compiler if we convert to ambiguous types.
    public static bool HasAny(this Traits flags, Traits check) => (flags & check) != 0;
    public static bool HasAny(this RestraintFlags flags, RestraintFlags check) => (flags & check) != 0;
}
