using GagSpeak.API.Data.Enum;

namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// a composite collection of all editaccess permissions of a user
/// </summary>
public class UserPermissionsEditAccessComposite
{
    public UserPermissionGeneralEditAccess GeneralAccess { get; set; } = new();
    public UserPermissionWardrobeEditAccess WardrobeAccess { get; set; } = new();
    public UserPermissionPuppeteerEditAccess PuppeteerAccess { get; set; } = new();
    public UserPermissionMoodlesEditAccess MoodlesAccess { get; set; } = new();
    public UserPermissionToyboxEditAccess ToyboxAccess { get; set; } = new();
}