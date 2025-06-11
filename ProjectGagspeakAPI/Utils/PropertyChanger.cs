using System.Diagnostics.CodeAnalysis;

namespace GagspeakAPI.Util;
public static class PropertyChanger
{
    /// <summary>
    ///    Attempts to set a property on the target object with the given property name and raw value.
    /// </summary>
    /// <typeparam name="T"> The type of the target object.</typeparam>
    /// <param name="target"> The target object on which to set the property.</param>
    /// <param name="propertyName"> The name of the property to set.</param>
    /// <param name="rawValue"> The raw value to set the property to. This can be of any type.</param>
    /// <param name="convertedValue"> The new value after conversion and setting.
    public static bool TrySetProperty<T>(T target, string propertyName, object? rawValue, [NotNullWhen(true)] out object? convertedValue)
    {
        // Initially assume the converted value is null.
        convertedValue = null;
        // Get the underlying property and see if we can even write there.
        System.Reflection.PropertyInfo? prop = typeof(T).GetProperty(propertyName);
        if (prop is null || !prop.CanWrite)
            return false;

        // Attempt to convert the value to the correct type.
        convertedValue = ConvertValue(prop.PropertyType, rawValue);
        if (convertedValue is null)
            return false;

        // Update the value.
        prop.SetValue(target, convertedValue);
        return true;
    }

    /// <summary>
    ///     Converts a value type to its proper handle, correcting what it got changed to on the server's end.
    /// </summary>
    /// <param name="type"> The type to convert to.</param>
    /// <param name="rawValue"> The raw value to convert.</param>
    /// <returns> The correctly handled object type we need. </returns>
    private static object? ConvertValue(Type type, object? rawValue)
    {
        return type switch
        {
            // Condition to correctly extract the right Enum.
            { IsEnum: true } => rawValue?.GetType() == Enum.GetUnderlyingType(type)
                ? Enum.ToObject(type, rawValue)
                : Convert.ChangeType(rawValue, type), // If newValue type matches enum underlying type, convert it directly.

            // Condition where TimeSpan struct is passed with a rawValue of ulong instead.
            _ when type == typeof(TimeSpan) && rawValue is ulong u =>
                TimeSpan.FromTicks((long)u),

            // Condition to handle cases where the expected type is a char but the raw value is a byte.
            _ when type == typeof(char) && rawValue is byte b =>
                Convert.ToChar(b),

            // Condition to handle nullable types
            _ => rawValue is null ? null : Convert.ChangeType(rawValue, type)
        };
    }
}
