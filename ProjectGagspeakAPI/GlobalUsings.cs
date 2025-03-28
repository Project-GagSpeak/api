
// A global tuple statement for moodle status info.
global using MoodlesStatusInfo = (
    System.Guid GUID,
    int IconID,
    string Title,
    string Description,
    GagspeakAPI.Enums.StatusType Type,
    string Applier,
    bool Dispelable,
    int Stacks,
    bool Persistent,
    int Days,
    int Hours,
    int Minutes,
    int Seconds,
    bool NoExpire,
    bool AsPermanent,
    System.Guid StatusOnDispell,
    string CustomVFXPath,
    bool StackOnReapply,
    int StacksIncOnReapply
);

global using MoodlePresetInfo = (
    System.Guid GUID,
    System.Collections.Generic.List<System.Guid> Statuses,
    GagspeakAPI.Enums.PresetApplicationType ApplicationType,
    string Title
);

global using IPCProfileDataTuple = (
    System.Guid UniqueId,
    string Name,
    string VirtualPath,
    System.Collections.Generic.List<(string Name, ushort WorldId, byte CharacterType, ushort CharacterSubType)> Characters,
    int Priority,
    bool IsEnabled);

// if we want to ever use a more direct transfer with our light storage of worn equip items, use this.
// Do note that if we do this, it may get around needing to resolve the information, but we will be transferring more data.

