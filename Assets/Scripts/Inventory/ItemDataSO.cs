using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Desription;
}
