using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private List<InventorySlot> _ItemSlots = new();
    void Awake()
    {
        _ItemSlots.AddRange(GetComponentsInChildren<InventorySlot>());
    }
    public void InitiaLize(PlayerInventory playerInventory)
    {
        playerInventory.OnItemAdded += AddItem;
    }
    public void AddItem(Item item)
    {
        var slot = _ItemSlots.FirstOrDefault(s => s.Name == item.ItemDataSO.Name && 
                                                        s.CanBeStack);
        if (slot != null)
        {
            slot.StackUP(); 
        }
        else
        {
            var freeSlot = _ItemSlots.FirstOrDefault(s => s.IsAvailable);
            if (freeSlot != null)
            {
                freeSlot.Initialize(item);
                freeSlot.IsAvailable = false;

            }
        }

    }
    public void RemoveItem(InventorySlot slot)
    {
        slot.FreeSlot();
    }
}