namespace GagspeakAPI.Extensions;

// Idk why this exists but too lazy to fix it.
public static class GenericExtensions
{
    public static bool IsEmptyGuid(this Guid item) => item == Guid.Empty;
    public static bool NullOrEmpty(this string s) => string.IsNullOrEmpty(s);
}
