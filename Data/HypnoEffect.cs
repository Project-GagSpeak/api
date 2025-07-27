using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
///     Contains all properties for a hypnotic effect.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class HypnoticEffect
{
    /// <summary>
    ///     The Attributes associated with the Hypnotic effect.
    /// </summary>
    public HypnoAttributes Attributes { get; set; } = HypnoAttributes.Default;

    /// <summary>
    ///     The image rotation speed. 
    ///     Ranges between 0.1x and 5.0x.
    /// </summary>
    /// <remarks> Can be impacted by <see cref="HypnoAttributes.SpeedUpOnCycle"/></remarks>
    public float SpinSpeed { get; set; } = 1f;

    /// <summary> 
    ///     The Color tint applied to the Image. 
    ///     Will not affect transparent areas.
    /// </summary>
    /// <remarks> Image Color can also be impacted by <see cref="HypnoAttributes.TransposeColors"/></remarks>
    public uint ImageColor = 0xFFFFFFFF;

    /// <summary>
    ///     The zoom depth of the displayed image.
    ///     Ranges between 0.25x and 3.50x.
    /// </summary>
    /// <remarks> 0.5x is the default zoom, not 1.0x </remarks>
    public float ZoomDepth = 0.5f;

    /// <summary> 
    ///     Total milliseconds to fade from <see cref="ImageColor"/> to its inverted color.<para/>
    ///     Ranges between 250ms and 10000ms.
    /// </summary>
    /// <remarks> Only in affect when <see cref="HypnoAttributes.TransposeColors"/> is active. </remarks>
    public int TransposeTime { get; set; } = 1000;

    /// <summary>
    ///     All <b>Displayed Messages</b> are contained in this array.
    ///     If empty, no text is displayed.
    /// </summary>
    /// <remarks>
    ///     Text display order is determined by <see cref="HypnoAttributes.TextDisplayMask"/><para/>
    ///     Text fade can be enabled with <see cref="HypnoAttributes.TextFade"/>
    /// </remarks>
    public string[] DisplayMessages { get; set; } = [];

    /// <summary> 
    ///     Color of the DisplayText. Defaults to White.
    /// </summary>
    /// <remarks> Color can be impacted by <see cref="HypnoAttributes.TransposeColors"/></remarks>
    public uint TextColor { get; set; } = 0xFFFFFFFF;

    /// <summary> 
    ///     Color of the DisplayText's stroke. Defaults to Black.
    /// </summary>
    /// <remarks> Color can be impacted by <see cref="HypnoAttributes.TransposeColors"/></remarks>
    public uint StrokeColor { get; set; } = 0xFF000000;

    /// <summary>
    ///     The font size for the display text.
    ///     Ranges between 150px and 500px.
    /// </summary>
    /// <remarks> Baked font size is 300px, straying ~150px from this can make text less sharp. </remarks>
    public int TextFontSize { get; set; } = 300;

    /// <summary>
    ///     The thickness of the stroke around the text.<para/>
    ///     Ranges between 0px and 16px.
    /// </summary>
    public int StrokeThickness { get; set; } = 8;

    /// <summary> 
    ///     Total milliseconds that each message from <see cref="DisplayMessages"/> is shown.
    ///     Ranges between 250ms and 10000ms.
    /// </summary>
    /// <remarks> Can be impacted by <see cref="HypnoAttributes.ArousalScalesSpeed"/> when active. </remarks>
    public int TextDisplayTime { get; set; } = 1000;

    /// <summary> 
    ///     The Duration in milliseconds to ease-in <see cref="DisplayMessages"/> Opacity.<para/>
    ///     Ranges between 0ms and half of <see cref="TextDisplayTime"/>'s value.
    /// </summary>
    public int TextFadeInTime { get; set; } = 0;

    /// <summary> 
    ///     The Duration in milliseconds to ease-in <see cref="DisplayMessages"/> Opacity.<para/>
    ///     Ranges between 0ms and half of <see cref="TextDisplayTime"/>'s value.
    /// </summary>
    public int TextFadeOutTime { get; set; } = 0;


    /// <summary>
    ///     The time in milliseconds to accelerate the text display speed between displays.<para/>
    ///     Ranges between 50ms and 500ms.
    /// </summary>
    /// <remarks> Only ever used if <see cref="HypnoAttributes.SpeedUpOnCycle"/> is active. </remarks>
    public int SpeedupTime { get; set; } = 50;


    public HypnoticEffect()
    { }
    public HypnoticEffect(HypnoticEffect other)
    {
        Attributes = other.Attributes;
        SpinSpeed = other.SpinSpeed;
        ImageColor = other.ImageColor;
        ZoomDepth = other.ZoomDepth;
        TransposeTime = other.TransposeTime;
        DisplayMessages = (string[])other.DisplayMessages.Clone();
        TextColor = other.TextColor;
        StrokeColor = other.StrokeColor;
        TextFontSize = other.TextFontSize;
        StrokeThickness = other.StrokeThickness;
        TextDisplayTime = other.TextDisplayTime;
        TextFadeInTime = other.TextFadeInTime;
        TextFadeOutTime = other.TextFadeOutTime;
        SpeedupTime = other.SpeedupTime;
    }

    public override string ToString()
    {
        return $"HypnoticEffect(" +
               $"Attributes: {Attributes}, " +
               $"SpinSpeed: {SpinSpeed:F2}, " +
               $"ImageColor: 0x{ImageColor:X8}, " +
               $"ZoomDepth: {ZoomDepth:F2}, " +
               $"TransposeTime: {TransposeTime}ms, " +
               $"Messages: {DisplayMessages.Length}, " +
               $"TextColor: 0x{TextColor:X8}, " +
               $"FontSize: {TextFontSize}px, " +
               $"DisplayTime: {TextDisplayTime}ms, " +
               $"FadeIn: {TextFadeInTime}ms, " +
               $"FadeOut: {TextFadeOutTime}ms)";
    }
}
