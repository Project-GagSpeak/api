namespace GagspeakAPI.Profiles;

public sealed class ColoredTag : IEquatable<ColoredTag>
{
    public string Text { get; set; } = string.Empty;
    public uint Color { get; set; } = 0xFF787878;

    public bool Equals(ColoredTag? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Text == other.Text && Color == other.Color;
    }

    public override bool Equals(object? obj)
        => Equals(obj as ColoredTag);

    public override int GetHashCode()
        => HashCode.Combine(Text, Color);
}