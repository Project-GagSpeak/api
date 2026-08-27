using GagspeakAPI.Profiles;

namespace GagspeakAPI.User;

public class ShapeComparer : IEqualityComparer<IPrimativeShape>
{
    private static readonly ShapeComparer _instance = new();

    private ShapeComparer()
    { }

    public static ShapeComparer Instance => _instance;

    public bool Equals(IPrimativeShape? x, IPrimativeShape? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;
        return x.Id == y.Id && x.Type == y.Type;
    }

    public int GetHashCode(IPrimativeShape obj)
    {
        return HashCode.Combine(obj.Id, obj.Type);
    }
}