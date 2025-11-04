using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public InventoryPanel inventoryPanel;
    void Awake()
    {
        var inventory = player.GetComponent<PlayerInventory>();
        inventoryPanel.InitiaLize(inventory);
    }

}