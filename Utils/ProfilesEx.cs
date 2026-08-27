using GagspeakAPI.Profiles;
using System.Numerics;

namespace GagspeakAPI;
#nullable enable

public enum ValidationError
{
    Valid,
    NamePos,
    PronounsPos,
    InterestsRectOutside,
    DescriptionRectOutside,
    RectOverlap,
    BadColorOpacity,
    BadShapes,
    EmptyWhitespace,
    TooManyShapes,
    InvalidPath,
    OtherError,
    DuplicateIcons,
}

// NOTE TO SELF:
// - SAMPLEPLUGIN -> Lookup "Select Icon" and "Icon Picker" to extract better selectors for these.

public static class ProfilesEx
{
    public const int MAX_DISPLAYNAME_LEN = 20;
    public const int MAX_PRONOUNS_LEN = 20;
    public const int MAX_DESCRIPTION_LEN = 800;
    public const int MAX_SHAPES = 50;

    // For UI
    public const float BASE_WIDTH = 400f;
    public const float BASE_HEIGHT = 711f;
    public const float ICON_WIDTH = 256f;

    // Raw ImageSize
    public static readonly Vector2 MaxIconSize = new Vector2(256, 256);
    public static readonly Vector2 MaxUserBackgroundSize = new Vector2(1080, 1920); // Base Factor 0.37x (400x711 -> 1080x1920)

    public static ValidationError RunValidation(UserProfileV1 up, float borderSize)
    {
        var profileSize = new Vector2(BASE_WIDTH, BASE_HEIGHT);
        var frameSize = new Vector2(borderSize);
        var infoMin = frameSize;
        var infoMax = profileSize - frameSize;

        if (up.Theme.Shapes.Count > MAX_SHAPES)
            return ValidationError.TooManyShapes;

        if (up.DisplayName.Length > 0 && string.IsNullOrWhiteSpace(up.DisplayName))
            return ValidationError.EmptyWhitespace;

        if (up.Pronouns.Length > 0 && string.IsNullOrWhiteSpace(up.Pronouns))
            return ValidationError.EmptyWhitespace;

        if (up.Description.Length > 0 && string.IsNullOrWhiteSpace(up.Description))
            return ValidationError.EmptyWhitespace;

        if (up.Theme.Shapes.Count(s => s.Type is PrimShapeType.Icon) > 1)
            return ValidationError.DuplicateIcons;

        if (OutOfBounds(up.Theme.NamePos))
            return ValidationError.NamePos;

        if (OutOfBounds(up.Theme.SubNamePos))
            return ValidationError.PronounsPos;

        if (OutOfBounds(up.Theme.InterestsMin) || OutOfBounds(up.Theme.InterestsMax))
            return ValidationError.InterestsRectOutside;

        if (OutOfBounds(up.Theme.BioMin) || OutOfBounds(up.Theme.BioMax))
            return ValidationError.DescriptionRectOutside;

        // Insure that the rect of the activities and description don't overlap.
        if (up.Theme.InterestsMin.X < up.Theme.BioMax.X && up.Theme.InterestsMax.X > up.Theme.BioMin.X &&
            up.Theme.InterestsMin.Y < up.Theme.BioMax.Y && up.Theme.InterestsMax.Y > up.Theme.BioMin.Y)
            return ValidationError.RectOverlap;

        // Should also validate colors.
        if (!IsOpaque(up.Theme.StaticButtons.Color)
         || !IsOpaque(up.Theme.BgColor) 
         || !IsOpaque(up.Theme.BorderColor)
         || !IsOpaque(up.Theme.MainText.Color)
         || !IsOpaque(up.Theme.PillText.Color) 
         || !IsOpaque(up.Theme.BioText.Color))
        {
            return ValidationError.BadColorOpacity;
        }

        if (up.Theme.Shapes.Any(s => s is PrimativePath path && path.Nodes.Count > 25))
            return ValidationError.InvalidPath;

        // We could do a check to see if the full shape is out of bounds though.
        return ValidationError.Valid;

        bool OutOfBounds(Vector2 pos)
            => pos.X < infoMin.X || pos.Y < infoMin.Y || pos.X > infoMax.X || pos.Y > infoMax.Y;
    }

    private static bool IsOpaque(uint color)
        => (color >> 24) == 0xFF;
}
#nullable disable