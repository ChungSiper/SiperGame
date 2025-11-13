using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthItemData", menuName = "Data/HealthItemData")]
public class HeathItemDataSO : MonoBehaviour
{   
    public string Name;
    public Sprite Image;
    public int MaxStackSize;
    public string Description;
}