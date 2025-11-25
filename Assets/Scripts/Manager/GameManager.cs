using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public Player Player;
    public InventoryPanel InventoryPanel;
    private Coroutine _changeSceneCoroutine;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        var inventory = Player.GetComponent<PlayerInventory>(); 
        InventoryPanel.InitiaLize(inventory);
        Initialize();
    }
    public void ChangeScece(string scenceName)
    {
        //if (_changeSceneCoroutine != null)
        //{
        //    StopCoroutine(_changeSceneCoroutine);
        //    _changeSceneCoroutine = null;
        //}
        StartCoroutine(ChangeScenceCoroutine(scenceName));
    }

    void Initialize()
    {
        Player = FindAnyObjectByType<Player>();
        InventoryPanel = FindAnyObjectByType<InventoryPanel>();
        var invetory = Player.GetComponent<PlayerInventory>();
        InventoryPanel.InitiaLize(invetory);
    }
    private IEnumerator ChangeScenceCoroutine(string scenceName)
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scenceName);

        yield return new WaitForSeconds(0.5f);

        var spawnPoint = GetSpawnPosition();
        if(spawnPoint != null)
        {
            Player.Instance.SpawnAtPosition(spawnPoint);
        }
    }

    private CheckPoint GetSpawnPosition()
    {
        var ponts = FindObjectsByType<CheckPoint>(FindObjectsSortMode.None);
        foreach (var point in ponts)
        {
            if (point.CheckPointType == CheckPointType.Enter)
            {
                point.CanbeTrigger = false;
                return point;
            }
        }
        return null;
    }
}