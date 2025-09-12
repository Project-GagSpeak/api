using GagspeakAPI.Network;

namespace GagspeakAPI.Data.Comparer;
#pragma warning disable IDE1006 // Naming Styles
public class CollarRequestComparer : IEqualityComparer<CollarRequest>
{
    private static readonly CollarRequestComparer _instance = new();

    private CollarRequestComparer()
    { }

    public static CollarRequestComparer Instance => _instance;

    public bool Equals(CollarRequest? x, CollarRequest? y)
    {
        if (x is null || y is null) return false;
        return x.User.UID.Equals(y.User.UID, StringComparison.Ordinal)
            && x.Target.UID.Equals(y.Target.UID, StringComparison.Ordinal);
    }

    public int GetHashCode(CollarRequest obj)
    {
        return HashCode.Combine(obj.User.UID, obj.Target.UID);
    }
}
#pragma warning restore IDE1006 // Naming Styles
