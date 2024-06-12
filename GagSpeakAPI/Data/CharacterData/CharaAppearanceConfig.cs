namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// Stores the appearance information of a character in the scope of gagspeak.
/// </summary>
public class CharaAppearanceConfig
{
     public string SlotOneGagType { get; set; } // the type of the user's first gag
     public string SlotOneGagPadlock { get; set; } // the padlock of the user's first gag
     public string SlotOneGagPassword { get; set; } // the password of the user's first gag
     public DateTimeOffset SlotOneGagTimer { get; set; } // the timer of the user's first gag
     public string SlotOneGagAssigner { get; set; } // the assigner of the user's first gag

     public string SlotTwoGagType { get; set; } // the type of the user's second gag
     public string SlotTwoGagPadlock { get; set; } // the padlock of the user's second gag
     public string SlotTwoGagPassword { get; set; } // the password of the user's second gag
     public DateTimeOffset SlotTwoGagTimer { get; set; } // the timer of the user's second gag
     public string SlotTwoGagAssigner { get; set; } // the assigner of the user's second gag

     public string SlotThreeGagType { get; set; } // the type of the user's third gag
     public string SlotThreeGagPadlock { get; set; } // the padlock of the user's third gag
     public string SlotThreeGagPassword { get; set; } // the password of the user's third gag
     public DateTimeOffset SlotThreeGagTimer { get; set; } // the timer of the user's third gag
     public string SlotThreeGagAssigner { get; set; } // the assigner of the user's third gag

     // constructor to set all values to default maybe later yeet
}