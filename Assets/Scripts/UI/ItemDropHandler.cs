using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class ItemDropHandler : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            if(!RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition))
            {
                var slot = eventData.pointerDrag.GetComponentInParent<InventorySlot>();
                if(slot == null)
                {
                    return;
                }
                //var item = slot.Item;
                if (TryGetComponent<InventoryPanel>(out var inventoryPanel))
                {
                    inventoryPanel.RemoveItem(slot);
                }
            }
        }
    }
}