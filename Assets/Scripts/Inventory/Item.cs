using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemDataSO ItemDataSO;
    public Item(ItemDataSO itemDataSO)
    {
        ItemDataSO = itemDataSO;
    }
}
