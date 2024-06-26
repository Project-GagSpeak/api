namespace Gagspeak.API.Data.Enum;

/// <summary> The defined role of another paired user in a dynamic 
/// <para>
/// Unsure if this will serve any purpose once dynamic tiers are removed. 
/// Could serve as a permission preset filter.
/// </para>
/// </summary>
public enum RoleLean
{
     None = 0,
     AbsoluteSlave = 1,
     Slave = 2,
     Pet = 3,
     Submissive = 4,
     Dominant = 5,
     Mistress = 6,
     Master = 7,
     Owner = 8,
     AbsoluteOwner = 9,
}