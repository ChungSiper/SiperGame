using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _nameText;
    [SerializeField] private TMPro.TMP_Text _stackText;
    [SerializeField] private Image _thumbnail;

    private Button _button;
    public string Name => _nameText.text;
    public bool IsAvailable = true;
    private int _currenStackSize;
    private Item _item;  
    public Item Item => _item;
    private float _lastClickTime;
    private const float DoubleClickThreshold = 0.3f; // seconds
    public bool CanBeStack => _currenStackSize < _item.ItemDataSO.MacStackSize;
    public void Initialize(Item item)
    {
        _item = item;
        _nameText.text = item.ItemDataSO.Name;
        _thumbnail.sprite = item.ItemDataSO.Image;
        _thumbnail.color = Color.white;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        StackUP();
    }

    private void OnClick()
    {
        if (Time.time < _lastClickTime + DoubleClickThreshold)
        {
            // Double-click detected
            UseItem();
        }
        _lastClickTime = Time.time;
    }

    private void UseItem()
    {
        _item.ItemDataSO.ItemEffect.ApplyEffect();
        StackDown();
        if(_currenStackSize <= 0)
        {
            FreeSlot();
        }
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
