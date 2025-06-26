using System.Diagnostics.CodeAnalysis;

namespace GagspeakAPI.Data;

#pragma warning disable IDE1006 // Naming Styles

public interface IEditableStorage<T> where T : class, IEditableStorageItem<T>
{

    /// <summary> Replace the original item with a new one (used for abstract type changes). </summary>
    /// <param name="oldItem"> The item to be replaced. </param>
    /// <param name="newItem"> The new item to replace the old one with. </param>
    /// <returns> True if the item was replaced, false if it was not. </returns>
    public virtual T? ReplaceSource(T oldItem, T newItem) => null;

    /// <summary> Apply changes from changedItem to the original source item (in-place update). </summary>
    /// <remarks> This will keep the source item as a reference, and only updates internals. </remarks>
    public bool TryApplyChanges(T sourceItem, T changedItem);
}
 


/// <summary> Signifies that this item can be used in an editor interface when inside a storage container. </summary>
public interface IEditableStorageItem<T> where T : class
{
    /// <summary> Clones the item, creating a new instance of the item with the same values. </summary>
    /// <remarks> KeepIdentifier allows you to choose if the GUID is copied or not. </remarks>
    /// <returns> The new instance of the cloned item. </returns>
    T Clone(bool keepId = false);

    /// <summary> Apply changes from another item to this one (in-place update). </summary>
    /// <remarks> This will keep the source item as a reference, and only updates internals. </remarks>
    void ApplyChanges(T changedItem);
}

/// <summary> Handles the editing of items which are referenced storage items. </summary>
/// <remarks> Finished edits apply updates to the object source without replacing the object itself. </remarks>
/// <typeparam name="T"> An editable storage item that can clone and apply changes. </typeparam>
public sealed class StorageItemEditor<T> where T : class, IEditableStorageItem<T>
{
    /// <summary> The storage that contains the item we are editing. </summary>
    private IEditableStorage<T>? Storage = null;

    /// <summary> The item that references the original class we are editing. </summary>
    private T? SourceItem = null;

    /// <summary> A cloned local copy of the source item that does not reference the original. </summary>
    public T? ItemInEditor { get; set; } = null;


    /// <summary> Begin the editing process, making a clone of the item we want to edit. </summary>
    /// <param name="itemSource"> The item to edit. </param>
    /// <remarks> This will clone the item and set it to the ItemInEditor. </remarks>
    public void StartEditing(IEditableStorage<T> storage, T source)
    {
        if (storage is null || source is null || ItemInEditor is not null)
            return;

        Storage = storage;
        SourceItem = source;
        ItemInEditor = source.Clone(true);
    }

    /// <summary> Cancel the editing process without updating the source. </summary>
    public void QuitEditing() 
        => ClearRefs();


    /// <summary> Sets the references to null. </summary>
    public void ClearRefs()
    {
        ItemInEditor = null;
        SourceItem = null;
        Storage = null;
    }

    /// <summary> Apply all changed done to the activeItem to the source item. </summary>
    /// <remarks> This does so without updating the reference of the original. </remarks>
    public bool SaveAndQuitEditing([NotNullWhen(true)] out T? source)
    {
        source = null;

        if (ItemInEditor is null || SourceItem is null || Storage is null)
            return false;

        // Handle case with abstract types (Until we decide to use wrappers if REALLY nessisary).
        if (ItemInEditor.GetType() != SourceItem.GetType())
        {
            // If successful, update the out source.
            if (Storage.ReplaceSource(SourceItem, ItemInEditor) is T newRef)
            {
                source = newRef;
                ClearRefs();
                return true;
            }
        }
        else
        {
            // Try applying the changes (in-place update).
            if (Storage.TryApplyChanges(SourceItem, ItemInEditor))
            {
                source = SourceItem;
                ClearRefs();
                return true;
            }
        }

        // If we get here, we failed to apply the changes.
        ClearRefs();
        return false;
    }
}
#pragma warning restore IDE1006 // Naming Styles

