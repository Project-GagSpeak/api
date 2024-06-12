using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using MessagePack;

/*                  Summary provided by AI to help me understand this
 * 
 * The UserIndividualPairStatusDto is designed to encapsulate data about a user and their individual 
 * pair status in a single, serializable object. 
 * 
 * This makes it easier to transfer this specific set of data between different parts of the application 
 * or across network calls, especially when using APIs.
 * 
 * The use of MessagePack for serialization suggests a focus on performance and efficiency, likely because 
 * this data needs to be transmitted frequently or in large volumes.
 */

namespace Gagspeak.API.Dto.User;

[MessagePackObject(keyAsPropertyName: true)]
public record UserIndividualPairStatusDto(UserData User, IndividualPairStatus IndividualPairStatus) : UserDto(User);