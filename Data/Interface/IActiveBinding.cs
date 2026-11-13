namespace GagspeakAPI.Data;

/// <summary>
///   Shared properties for an actively applied bondage item.
/// </summary>
public interface IActiveBinding
{
    /// <summary> Optional item features to invoke alongside the base item when applied. </summary>
    ApplyModifiers Modifiers { get; set; }

    /// <summary>
    ///   The snugness of the binding (0-100). Acts as a dynamic state that depletes the more a binding stretches or tears. <para/>
    ///   <item>
    ///     <term>Higher Values</term>
    ///     <description>
    ///       Restricts leverage, lowers success chance of struggling, and keeps the wearer away from the slip threshold.
    ///       (Hitting <c>0</c> garentees slip-out success)
    ///     </description>
    ///   </item><br/>
    ///   <item>
    ///     <term>Lower Values</term>
    ///     <description>Increase leverage, allowing larger stretches per hit. Dropping below <c>T_slip</c> enables the slip-out chance</description>
    ///   </item>
    /// </summary>
    /// <remarks>
    ///   Mathamatically, Tightness controls struggle hit chance (<c>P_str</c>), physical leverage (<c>Lev = 1 - 0.65 * Tightness</c>),
    ///   and if slip-out rolling is blocked (<c>Tightness &lt; T_slip</c>).
    /// </remarks>
    byte Tightness { get; set; }

    /// <summary>
    ///   The durability of the binding (0-100). Acts as a dynamic state that depletes when damaged by struggling. <para/>
    ///   <item>
    ///     <term>Higher Values</term>
    ///     <description>Helps maintain <see cref="Rigidity"/> against stretching (Grip), and helps prevent tear acceleration.</description>
    ///   </item><br/>
    ///   <item>
    ///     <term>Lower Values</term>
    ///     <description>Weakens grip (letting rigid bindings stretch) and accelerates tearing. Hitting <c>0</c> frees you immediately.</description>
    ///   </item>
    /// </summary>
    /// <remarks>
    ///   Mathamatically, Integrity factors into Grip (<c>Grip = Rigidity * Integrity</c>)
    ///   and the Tear Cascade Multiplier (<c>M_tear = 1 + 3 * Fragility * (1 - Integrity)</c>).
    /// </remarks>
    byte Integrity { get; set; }

    /// <summary>
    ///   A static value (0-100) representing the binding's material resistance to stretching while <see cref="Integrity"/> holds. <para/>
    ///   <item>
    ///     <term>Higher Values (e.g., tape, metal)</term>
    ///     <description>
    ///       Keeps Grip high, blocking (ΔT_stretch) and lowering struggle hit chance.
    ///       However, any tear (<c>ΔI</c>) releases a larger burst of slack (ΔT_tear).
    ///     </description>
    ///   </item><br/>
    ///   <item>
    ///     <term>Lower Values (e.g., rope)</term>
    ///     <description>Keeps Grip low, even at 100% <see cref="Integrity"/>, allowing the binding to stretch (ΔT_stretch) without damaging it.</description>
    ///   </item>
    /// </summary>
    /// <remarks>
    ///   Mathamatically, Rigidity factors into the Grip (<c>Grip = Rigidity * Integrity</c>), 
    ///   stretch resistance (<c>ΔT_stretch = Power * Lev * (1 - Grip)</c>), and tension released per tear (<c>ΔT_tear = 0.5 * ΔI * Rigidity</c>).
    /// </remarks>
    byte Rigidity { get; set; }

    /// <summary>
    ///   A static value (0-100) defining how easily the binding frays and tears under struggle force. <para/>
    ///   <item>
    ///     <term>Higher Values (e.g., tape)</term>
    ///     <description>Causes heavier <see cref="Integrity"/> damage per hit, compounding via M_tear as <see cref="Integrity"/> drops, favoring break escapes.</description>
    ///   </item><br/>
    ///   <item>
    ///     <term>Lower Values (e.g., leather, rope, steel)</term>
    ///     <description>Resists damage from struggle hits, forcing escape to rely on stretching. (<c>0</c> makes the item unbreakable).</description>
    ///   </item>
    /// </summary>
    /// <remarks>
    ///   Mathamatically, Fragility scales durability loss (<c>ΔI = Power * Lev * M_tear</c>)
    ///   and the Tear Cascade Multiplier (<c>M_tear = 1 + 3 * Fragility * (1 - Integrity)</c>).
    /// </remarks>
    byte Fragility { get; set; }

    /// <summary>
    ///   A static value (0-100) indicating the intricacy of the binding. <para/>
    ///   <item>
    ///     <term>Higher Values (e.g., box ties, straitjackets)</term>
    ///     <description>Lowers the Slip Threshold, forcing <see cref="Tightness"/> to loosen more before slip-out rolls begin.</description>
    ///   </item><br/>
    ///   <item>
    ///     <term>Lower Values (e.g., wrist ties, cuffs)</term>
    ///     <description>Raise the Slip Threshold, allowing slip-out chance at higher <see cref="Tightness"/>.</description>
    ///   </item>
    /// </summary>
    /// <remarks>
    ///   Complexity impacts the Slip Threshold (<c>T_slip = 75 - 0.55 * Complexity</c>), and scales slip-out probability (<c>P_slip</c>).
    /// </remarks>
    byte Complexity { get; set; }
}