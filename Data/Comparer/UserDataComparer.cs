namespace GagspeakAPI.Data.Comparer;
#pragma warning disable IDE1006 // Naming Styles

public class UserDataComparer : IEqualityComparer<UserData>
{
    private static UserDataComparer _instance = new();

    private UserDataComparer()
    { }

    public static UserDataComparer Instance => _instance;

    public bool Equals(UserData? x, UserData? y)
    {
        if (x is null || y is null) return false;
        return x.UID.Equals(y.UID, StringComparison.Ordinal);
    }

    public int GetHashCode(UserData obj)
    {
        return obj.UID.GetHashCode();
    }
}
#pragma warning restore IDE1006 // Naming Styles
