namespace GagspeakAPI.Data;

/// <summary>
///   Represents a single-item active binding on a specific layer with dual-channel dyes and a single Penumbra mod preset.
/// </summary>
public interface ISingleItemBinding : IActiveBinding
{
    /// <summary>Gets or sets the first dye identifier.</summary>
    /// <remarks>Used for the primary Glamourer dye slot.</remarks>
    byte Dye1 { get; set; }
    /// <summary> The Secondary Dye for Glamourer </summary>
    byte Dye2 { get; set; }

    /// <summary> Only set if any ModPreset is defined. </summary>
    string ModDirectory { get; set; }
    /// <summary> Only set if any ModPreset is defined. </summary>
    string ModName { get; set; }
    /// <summary> Defines what Penumbra ModPreset to apply. </summary>
    /// <remarks> If <see cref="Guid.Empty"/> with a Directory and Name, it uses default mod settings. </remarks>
    Guid ModPreset { get; set; }
}