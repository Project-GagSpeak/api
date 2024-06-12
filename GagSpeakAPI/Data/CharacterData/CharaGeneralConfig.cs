using Gagspeak.API.Data.Enum;

namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// Stores general config options for a character unrelated to any particular module.
/// </summary>
public class CharaGeneralConfig
{
     public string Safeword { get; set; }           // the user's safeword
     public bool SafewordUsed { get; set; }         // if the safeword has been used
     public bool CmdsFromFriends { get; set; }      // if commands can be sent from friends (will likely need a full rework)
     public bool CmdsFromParty { get; set; }        // if commands can be sent from party members (will likely need a full rework)
     public bool DirectChatGarblerActive { get; set; } // if the user has direct chat garbler active
     public bool DirectChatGarblerLocked { get; set; } // if the user has direct chat garbler locked
     public bool LiveGarblerZoneChangeWarn { get; set; } // if user wants to be warned about the live chat garbler on zone change
     public RevertStyle RevertStyle { get; set; }   // how the user wants to revert their settings (can store locally?)
}