global using System;
global using System.Linq;
global using System.Threading.Tasks;
global using System.Collections.Generic;

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
    bool IsEnabled
    );

global using AddressBookEntryTuple = (
    string Name,
    int World,
    int City,
    int Ward,
    int PropertyType,
    int Plot,
    int Apartment,
    bool ApartmentSubdivision,
    bool AliasEnabled,
    string Alias
    );
