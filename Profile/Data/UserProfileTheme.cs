using System.Numerics;

namespace GagspeakAPI.Profiles;

public sealed class UserProfileTheme : IEquatable<UserProfileTheme>
{
    // Could be used for expanding to show kinks on hover ext.
    public bool CanExpand { get; set; } = false;

    // Profile Window & Ruleset
    public uint BorderColor { get; set; } = 0xFFAAAAAA;
    public uint BorderFade { get; set; } = 0xFF000000;
    public uint BorderFadeInner { get; set; } = 0x44111111;
    public float FadeDistance { get; set; } = 5f;
    public DirectionFlags FadeDirections { get; set; } = DirectionFlags.All;
    public uint BgColor { get; set; } = 0xFF000000;

    // Text Styles
    public PfpTextStyle StaticButtons { get; set; } = new();
    public PfpTextStyle MainText { get; set; } = new();
    public PfpTextStyle PillText { get; set; } = new();
    public PfpTextStyle BioText { get; set; } = new();

    // Layout & Bounding Boxes
    public Vector2 NamePos { get; set; } = new Vector2(20);
    public Alignment NameAlignment { get; set; } = Alignment.Left;
    public bool NameMoveWithExpand { get; set; } = false;

    public Vector2 SubNamePos { get; set; } = new Vector2(20, 40);
    public Alignment SubNameAlignment { get; set; } = Alignment.Left;
    public bool SubNameMoveWithExpand { get; set; } = false;

    public Vector2 InterestsMin { get; set; } = new Vector2(20, 400);
    public Vector2 InterestsMax { get; set; } = new Vector2(380, 500);
    public bool InterestsMoveWithExpand { get; set; } = true;

    public Vector2 BioMin { get; set; } = new Vector2(20, 540);
    public Vector2 BioMax { get; set; } = new Vector2(380, 650);
    public bool BioMoveWithExpand { get; set; } = true;

    public Vector2 VanityPos { get; set; } = new Vector2(20);
    public float VanitySize { get; set; } = 48f; 
    public bool VanityMoveWithExpand { get; set; } = false;
    public float VanityAlpha { get; set; } = 1.0f;

    // Text Fonts
    public TextFont NameFont { get; set; } = TextFont.Header;
    public TextFont SubNameFont { get; set; } = TextFont.Default;
    public TextFont InterestLabelFont { get; set; } = TextFont.Default;
    public TextFont InterestsFonts { get; set; } = TextFont.Default;
    public TextFont BioFont { get; set; } = TextFont.Default;


    // Pill Shapes & Behaviors
    public uint PillColor { get; set; } = 0xFF787878;
    public uint PillBorder { get; set; } = uint.MinValue;
    public float PillPadding { get; set; } = 0f;
    public float PillRounding { get; set; } = 90f;
    public float PillGapX { get; set; } = 4f;
    public float PillGapY { get; set; } = 4f;
    public Alignment PillAlignment { get; set; } = Alignment.Left;
    public bool ShowInterestText { get; set; } = true;

    // UNLIMITED SHAPES
    public List<IPrimativeShape> Shapes { get; set; } = [];

    public bool Equals(UserProfileTheme? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return CanExpand == other.CanExpand &&
               FadeDistance == other.FadeDistance &&
               FadeDirections == other.FadeDirections &&
               BorderColor == other.BorderColor &&
               BorderFade == other.BorderFade &&
               BgColor == other.BgColor &&
               NameMoveWithExpand == other.NameMoveWithExpand &&
               SubNameMoveWithExpand == other.SubNameMoveWithExpand &&
               InterestsMoveWithExpand == other.InterestsMoveWithExpand &&
               BioMoveWithExpand == other.BioMoveWithExpand &&
               VanityMoveWithExpand == other.VanityMoveWithExpand &&
               PillColor == other.PillColor &&
               PillBorder == other.PillBorder &&
               PillPadding == other.PillPadding &&
               PillRounding == other.PillRounding &&
               VanitySize == other.VanitySize &&
               NameAlignment == other.NameAlignment &&
               SubNameAlignment == other.SubNameAlignment &&
               PillAlignment == other.PillAlignment &&
               VanityAlpha == other.VanityAlpha &&
               ShowInterestText == other.ShowInterestText &&
               NamePos.Equals(other.NamePos) &&
               SubNamePos.Equals(other.SubNamePos) &&
               InterestsMin.Equals(other.InterestsMin) &&
               InterestsMax.Equals(other.InterestsMax) &&
               BioMin.Equals(other.BioMin) &&
               BioMax.Equals(other.BioMax) &&
               VanityPos.Equals(other.VanityPos) &&
               StaticButtons.Equals(other.StaticButtons) &&
               MainText.Equals(other.MainText) &&
               PillText.Equals(other.PillText) &&
               BioText.Equals(other.BioText) &&
               Shapes.SequenceEqual(other.Shapes);
    }

    public override bool Equals(object? obj)
        => Equals(obj as UserProfileTheme);

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(CanExpand);
        hash.Add(BorderColor);
        hash.Add(NamePos);
        hash.Add(MainText);
        hash.Add(Shapes.Count);
        return hash.ToHashCode();
    }
}