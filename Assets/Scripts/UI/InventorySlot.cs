using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _nameText;
    [SerializeField] private TMPro.TMP_Text _stackText;
    [SerializeField] private Image _thumbnail;
    public string Name => _nameText.text;
    public bool IsAvailable = true;
    private int _currenStackSize;
    private Item _item;  
    public bool CanBeStack => _currenStackSize < _item.ItemDataSO.MacStackSize;
    public void Initialize(Item item)
    {
        _item = item;
        _nameText.text = item.ItemDataSO.Name;
        _thumbnail.sprite = item.ItemDataSO.Image;
        _thumbnail.color = Color.white;
        StackUP();
    }
    public void StackUP()
    {
        _currenStackSize++;
        UpdateStackText();
    }
    public void StackDown()
    {
        _currenStackSize--;
        UpdateStackText();
    }
    public void UpdateStackText()
    {
        _stackText.text = _currenStackSize > 1 ? _currenStackSize.ToString() : "";
    }
    public void FreeSlot()
    {
        // Remove one item from the slot. If the slot is empty after removal, clear the slot.
        if (_item == null && _currenStackSize <= 0)
        {
            ClearSlot();
            return;
        }
        if (_currenStackSize > 1)
        {
            _currenStackSize--;
            IsAvailable = false;
            UpdateStackText();
        }
        else
        {
            ClearSlot();
        }

    }
    public void ClearSlot()
    {
        _item = null;
        _currenStackSize = 0;
        _nameText.text = "";
        _thumbnail.sprite = null;
        _thumbnail.color = Color.clear;
        IsAvailable = true;
        UpdateStackText();
    }

}
