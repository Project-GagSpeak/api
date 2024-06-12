using MessagePack;

namespace Gagspeak.API.Data;

/// <summary>
/// Stores a list of alias triggers. This is intended to be applied once for each player in your whitelist.
/// </summary>
public class AliasTrigger
{
     // the list stores the searched for input command on the left, and the output command on the right
     public bool _enabled;
     public string _inputCommand;
     public string _outputCommand;
     // potentially store subset commands that can chain with eachother like psuedo-macros, but for now just single.

     public AliasTrigger()
     {
          _enabled = false;
          _inputCommand = string.Empty;
          _outputCommand = string.Empty;
     }
}