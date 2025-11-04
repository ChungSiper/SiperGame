using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private List<InventorySlot> _inventorySlots = new();
    void Awake()
    {
        _inventorySlots.AddRange(GetComponentsInChildren<InventorySlot>());
    }
    public void InitiaLize(PlayerInventory playerInventory)
    {
        playerInventory.OnItemAdded += AddItem;
    }
    public void AddItem(Item item)
    {
        var slot = _inventorySlots.FirstOrDefault(s => s.IsAvailable);
        if (slot != null)
        {
            slot.Initialize(item);
            slot.IsAvailable = false;
        }
    }
}