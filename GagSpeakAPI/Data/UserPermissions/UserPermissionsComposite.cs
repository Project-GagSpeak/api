namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class UserPermissionsComposite
{
    public UserPermissionsGeneral General { get; set; } = new();
    public UserPermissionsWardrobe Wardrobe { get; set; } = new();
    public UserPermissionsPuppeteer Puppeteer { get; set; } = new();
    public UserPermissionsMoodles Moodles { get; set; } = new();
    public UserPermissionsToybox Toybox { get; set; } = new();
    public UserPermissionsHardcore Hardcore { get; set; } = new();
}