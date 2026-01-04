using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> 
///     KinkPlate™ Content stored in a Kinksters profile, storing the selected cosmetic info.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinkPlateContent
{
    public bool           IsPublic          { get; set; } = false;
    public bool           Flagged           { get; set; } = false;
    public bool           Disabled          { get; set; } = false;
    public PublicityScope AvatarVis         { get; set; } = PublicityScope.Private;
    public PublicityScope DescriptionVis    { get; set; } = PublicityScope.Private;
    public PublicityScope DecorationVis     { get; set; } = PublicityScope.Private;
    public string         Description       { get; set; } = string.Empty;
    public int            CompletedTotal    { get; set; } = 0; // How many achievements earned.
    public int            ChosenTitleId     { get; set; } = 0;
    
    // Collar Specific variables.
    public List<string> CollarOwners    { get; set; } = new();
    public string       CollarWriting   { get; set; } = string.Empty;

    // S - T - Y - L - E
    public KinkPlateBG      PlateBG             { get; set; } = KinkPlateBG.Default;
    public KinkPlateBorder  PlateBorder         { get; set; } = KinkPlateBorder.Default;
    
    public KinkPlateBG      PlateLightBG        { get; set; } = KinkPlateBG.Default;
    public KinkPlateBorder  PlateLightBorder    { get; set; } = KinkPlateBorder.Default;

    public KinkPlateBorder  AvatarBorder        { get; set; } = KinkPlateBorder.Default;
    public KinkPlateOverlay AvatarOverlay       { get; set; } = KinkPlateOverlay.Default;

    public KinkPlateBG      DescriptionBG       { get; set; } = KinkPlateBG.Default;
    public KinkPlateBorder  DescriptionBorder   { get; set; } = KinkPlateBorder.Default;
    public KinkPlateOverlay DescriptionOverlay  { get; set; } = KinkPlateOverlay.Default;

    public KinkPlateBG      GagSlotBG           { get; set; } = KinkPlateBG.Default;
    public KinkPlateBorder  GagSlotBorder       { get; set; } = KinkPlateBorder.Default;
    public KinkPlateOverlay GagSlotOverlay      { get; set; } = KinkPlateOverlay.Default;

    public KinkPlateBG      PadlockBG           { get; set; } = KinkPlateBG.Default;
    public KinkPlateBorder  PadlockBorder       { get; set; } = KinkPlateBorder.Default;
    public KinkPlateOverlay PadlockOverlay      { get; set; } = KinkPlateOverlay.Default;

    public KinkPlateBG      BlockedSlotsBG      { get; set; } = KinkPlateBG.Default;
    public KinkPlateBorder  BlockedSlotsBorder  { get; set; } = KinkPlateBorder.Default;
    public KinkPlateOverlay BlockedSlotsOverlay { get; set; } = KinkPlateOverlay.Default;

    public KinkPlateBorder  BlockedSlotBorder   { get; set; } = KinkPlateBorder.Default;
    public KinkPlateOverlay BlockedSlotOverlay  { get; set; } = KinkPlateOverlay.Default;
}
