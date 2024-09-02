namespace GagspeakAPI.Data.Enum;
public enum PresetName : byte
{
    Owner = 1,                // The highest rank, signifies complete control.
    Mistress = 2,
    Master = 3,
    Dominant = 4,
    /* --- Divide Between Submissive & Dominant --- */
    Brat = 5,                // give no permissions, but allow light punishment.
    RopeBunny = 6,           // Perfect for those looking to have some fun getting tied and gagged.
    Submissive = 7,          // Perfect for light play or one night stands.
    Slut = 8,                // Grants pair no access perms, but opens up general range of fun.
    Pet = 9,                 // Grants pair no access perms, opens short locks and some actions.
    Slave = 10,              // Grants pair no access perms, opens long locks and most actions.
    MistressesSlut = 11,
    MistressesPet = 12,
    MistressesSlave = 13,
    OwnersSlut = 14,
    OwnersPet = 15,
    OwnersSlave = 16
};
