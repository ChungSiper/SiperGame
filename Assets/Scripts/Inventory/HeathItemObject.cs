using System.Collections;
using UnityEngine;

public class HeathItemObject : MonoBehaviour
{
    [SerializeField] private HeathItemDataSO _heathItemData;
    public Item _item;
    void Awake()
    {
        _item = new Item(_heathItemData);
    }
    void OnValidate()
    {
        gameObject.name = "HeathItem_" + _heathItemData.Name;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        if(collider.TryGetComponent<PlayerInventory>(out PlayerInventory playerInventory))
        {
            playerInventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
}