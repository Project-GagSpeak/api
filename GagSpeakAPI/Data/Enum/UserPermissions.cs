namespace Gagspeak.API.Data.Enum;

[Flags] // remove this later, im just temp adding it so code doesnt throw me errors.
public enum UserPermissions
{
    NoneSet = 0,
    Paused = 1,
    DisableAnimations = 2,
    DisableSounds = 4,
    DisableVFX = 8,
    Sticky = 16,
}