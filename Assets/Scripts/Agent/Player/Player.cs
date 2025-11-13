using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    public PlayerController PlayerController { get; set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        if(Instance != this)
        {
            Destroy(this);
        }
        PlayerController = GetComponent<PlayerController>();
    }
}
