namespace GagspeakAPI.Enums;


/// <summary>
///     Can rearrange the order these are listed in the folder 
///     to adjust sort priority.
/// </summary>
public enum FolderSortFilter
{
    Rendered,       // Rendered kinksters first.
    Online,         // Online kinksters first.
    Favorite,       // Favorite kinksters first.
    Alphabetical,   // Default behavior.
    DateAdded,      // When the pair was established.
}
