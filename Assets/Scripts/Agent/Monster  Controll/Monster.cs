using UnityEngine;

public class Monster : MonoBehaviour
{
    public static Monster Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void GetDamage(float damage)
    {
        Destroy(gameObject);
    }
}
