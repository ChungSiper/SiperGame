using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _nameText;
    [SerializeField] private Image _thumbnail;
    public bool IsAvailable = true;
    public void Initialize(Item item)
    {
        _nameText.text = item.ItemDataSO.Name;
        _thumbnail.sprite = item.ItemDataSO.Image;
        _thumbnail.color = Color.white;
    }

}
