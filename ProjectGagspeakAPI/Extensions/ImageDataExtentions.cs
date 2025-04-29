using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using System.Text.RegularExpressions;

namespace GagspeakAPI.Enums;

/// <summary> What Kind of image is being handled by GS. </summary>
public enum ImageDataType
{
    None,
    Restrictions,
    Restraints,
    Blindfolds,
    Hypnosis,
    // Pulsating effect is done via VFX, not via overlay.
}

public static class ImageDataEx
{
    // Anything needed here we can do when the time comes.
}
