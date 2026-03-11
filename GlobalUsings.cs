global using System;
global using System.Linq;
global using System.Threading.Tasks;
global using System.Collections.Generic;

// New, For current use
global using LociStatusInfo = (
    int Version,
    System.Guid GUID,
    int IconID,
    string Title,
    string Description,
    string CustomVFXPath,               // What VFX to show on application.
    long ExpireTicks,                   // Permanent if -1, referred to as 'NoExpire' in LociStatus
    GagspeakAPI.StatusType Type,        // Loci StatusType enum.
    int Stacks,                         // Usually 1 when no stacks are used.
    int StackSteps,                     // How many stacks to add per reapplication.
    int StackToChain,                   // Used for chaining on set stacks
    GagspeakAPI.Modifiers Modifiers,    // What can be customized, casted to uint from Modifiers (Dalamud IPC Rules)
    System.Guid ChainedGUID,            // What status is chained to this one.
    GagspeakAPI.ChainType ChainType,    // What type of chaining is this for.
    GagspeakAPI.ChainTrigger ChainTrigger, // What triggers the chained status.
    string Applier,                     // Who applied the status.
    string Dispeller                    // When set, only this person can dispel your loci.
);

global using LociPresetInfo = (
    System.Guid GUID,
    System.Collections.Generic.List<System.Guid> Statuses,
    byte ApplicationType,
    string Title,
    string Description
);


// Remove later...
//global using LociStatusInfo = (
//    int Version,
//    System.Guid GUID,
//    int IconID,
//    string Title,
//    string Description,
//    string CustomVFXPath,               // What VFX to show on application.
//    long ExpireTicks,                   // Permanent if -1, referred to as 'NoExpire' in LociStatus
//    GagspeakAPI.StatusType Type,        // Locis StatusType enum.
//    int Stacks,                         // Usually 1 when no stacks are used.
//    int StackSteps,                     // How many stacks to add per reapplication.
//    GagspeakAPI.Modifiers Modifiers,    // What can be customized, casted to uint from Modifiers (Dalamud IPC Rules)
//    System.Guid ChainedStatus,          // What status is chained to this one.
//    GagspeakAPI.ChainTrigger ChainTrigger,                  // What triggers the chained status.
//    string Applier,                     // Who applied the loci.
//    string Dispeller,                   // When set, only this person can dispel your loci.
//    bool Permanent                      // Referred to as 'Sticky' in the Locis UI
//);

//global using LociPresetInfo = (
//    System.Guid GUID,
//    System.Collections.Generic.List<System.Guid> Statuses,
//    GagspeakAPI.PresetApplyType ApplicationType,
//    string Title
//    );
