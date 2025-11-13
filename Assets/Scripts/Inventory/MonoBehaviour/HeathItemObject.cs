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
    
}