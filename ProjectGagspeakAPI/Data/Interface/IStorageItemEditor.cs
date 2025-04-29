using System.Diagnostics.CodeAnalysis;

namespace GagspeakAPI.Data;

/// <summary> Signifies that this item can be used in an editor interface when inside a storage container. </summary>
public interface IEditableStorageItem<T> where T : class
{
    /// <summary> Clones the item, creating a new instance of the item with the same values. </summary>
    /// <remarks> KeepIdentifier allows you to choose if the GUID is copied or not. </remarks>
    /// <returns> The new instance of the cloned item. </returns>
    T Clone(bool keepId = false);

    /// <summary> Applies the changes made to the item to the original source item. </summary>
    /// <remarks> This will keep the source item as a reference, and only updates internals. </remarks>
    void ApplyChanges(T changedItem);
}

/// <summary> Handles the editing of items which are referenced storage items. </summary>
/// <remarks> Finished edits apply updates to the object source without replacing the object itself. </remarks>
/// <typeparam name="T"> An editable storage item that can clone and apply changes. </typeparam>
public class StorageItemEditor<T> where T : class, IEditableStorageItem<T>
{
    /// <summary> The item that references the original class we are editing. </summary>
    private T? SourceItem = null;

    /// <summary> A cloned local copy of the source item that does not reference the original. </summary>
    public T? ItemInEditor { get; set; } = null;

    /// <summary> Begin the editing process, making a clone of the item we want to edit. </summary>
    /// <param name="itemSource"> The item to edit. </param>
    /// <remarks> This will clone the item and set it to the ItemInEditor. </remarks>
    public void StartEditing(T itemSource)
    {
        if (itemSource is null || ItemInEditor is not null)
            return;

        SourceItem = itemSource;
        ItemInEditor = itemSource.Clone(true);
    }

    /// <summary> Cancel the editing process without updating the source. </summary>
    public void QuitEditing()
    {
        ItemInEditor = default;
        SourceItem = default;
    }

    /// <summary> Apply all changed done to the activeItem to the source item. </summary>
    /// <remarks> This does so without updating the reference of the original. </remarks>
    public bool SaveAndQuitEditing([NotNullWhen(true)] out T? source)
    {
        if (ItemInEditor is null || SourceItem is null)
        {
            source = null;
            return false;
        }

        SourceItem.ApplyChanges(ItemInEditor);
        source = SourceItem;

        ItemInEditor = null;
        SourceItem = null;
        return true;
    }
}
