using GagspeakAPI.Network;

namespace GagspeakAPI.Data.Comparer;

/// <summary>
/// Compares two KinksterBase objects based on their UID.
/// </summary>
public class KinksterBaseComparer : IEqualityComparer<KinksterBase>
{
     private static KinksterBaseComparer _instance = new();

     private KinksterBaseComparer() { }

     public static KinksterBaseComparer Instance => _instance;

     /// <summary>
     /// Method determines if the KinksterBase objects are equal based on their UID.
     /// </summary>
     /// <param name="x"></param>
     /// <param name="y"></param>
     /// <returns></returns>
     public bool Equals(KinksterBase? x, KinksterBase? y)
     {
          if (x is null || y is null) return false;
          return x.User.UID.Equals(y.User.UID, StringComparison.Ordinal);
     }

     /// <summary>
     /// Gets the has code of the KinksterBase
     /// </summary>
     public int GetHashCode(KinksterBase obj)
     {
          return obj.User.UID.GetHashCode();
     }
}
