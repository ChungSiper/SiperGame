using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemDataSO ItemDataSO;
    public HeathItemDataSO HeathItemDataSO;
    public Item(ItemDataSO itemDataSO)
    {
        ItemDataSO = itemDataSO;
    }
    public Item(HeathItemDataSO heathItemDataSO)
    {
        HeathItemDataSO = heathItemDataSO;
    }
}
