namespace GagspeakAPI.Profiles;

public sealed class PfpTextStyle : IEquatable<PfpTextStyle>
{
    public uint Color { get; set; } = uint.MaxValue;
    public uint Shadow { get; set; } = 0xFF000000;
    public float ShadowOffset { get; set; } = 1f;
    public float ShadowRadius { get; set; } = 1.5f;

    public bool Equals(PfpTextStyle? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return Color == other.Color
            && Shadow == other.Shadow
            && ShadowOffset == other.ShadowOffset
            && ShadowRadius == other.ShadowRadius;
    }

    public override bool Equals(object? obj) => Equals(obj as PfpTextStyle);
    public override int GetHashCode() => HashCode.Combine(Color, Shadow, ShadowOffset, ShadowRadius);
}
