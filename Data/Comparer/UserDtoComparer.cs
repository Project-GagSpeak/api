using GagspeakAPI.User;

namespace GagspeakAPI.Data.Comparer;

/// <summary>
/// Compares two UserDto objects based on their UID.
/// </summary>
public class KinksterBaseComparer : IEqualityComparer<UserDto>
{
     private static KinksterBaseComparer _instance = new();

     private KinksterBaseComparer() { }

     public static KinksterBaseComparer Instance => _instance;

     /// <summary>
     /// Method determines if the UserDto objects are equal based on their UID.
     /// </summary>
     /// <param name="x"></param>
     /// <param name="y"></param>
     /// <returns></returns>
     public bool Equals(UserDto? x, UserDto? y)
     {
          if (x is null || y is null) return false;
          return x.User.UID.Equals(y.User.UID, StringComparison.Ordinal);
     }

     /// <summary>
     /// Gets the has code of the UserDto
     /// </summary>
     public int GetHashCode(UserDto obj)
     {
          return obj.User.UID.GetHashCode();
     }
}
