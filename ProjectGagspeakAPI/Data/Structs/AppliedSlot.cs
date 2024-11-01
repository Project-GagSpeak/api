using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.IPC;

namespace GagspeakAPI.Data.Struct;
public readonly struct AppliedSlot
{
    public byte Slot { get; init; }
    public ulong CustomItemId { get; init; }
    public AppliedSlot(byte slot, ulong customItemId)
    {
        Slot = slot;
        CustomItemId = customItemId;
    }
}
