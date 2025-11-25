using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public Player player;
    public InventoryPanel inventoryPanel;
    private Coroutine _changeSceneCoroutine;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        var inventory = player.GetComponent<PlayerInventory>();
        inventoryPanel.InitiaLize(inventory);
    }
    public void ChangeScece(string scenceName)
    {
        if (_changeSceneCoroutine != null)
        {
            StopCoroutine(_changeSceneCoroutine);
            _changeSceneCoroutine = null;
        }
        _changeSceneCoroutine = StartCoroutine(ChangeScenceCoroutine(scenceName));
    }


    private IEnumerator ChangeScenceCoroutine(string scenceName)
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(scenceName);

        yield return new WaitForSeconds(0.5f);

        var spawnPoint = GetSpawnPosition();
        if(spawnPoint != Vector3.zero)
        {
            Player.Instance.SpawnAtPosition(spawnPoint);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        var ponts = FindObjectsByType<CheckPoint>(FindObjectsSortMode.None);
        foreach (var point in ponts)
        {
            if (point.CheckPointType == CheckPointType.Enter)
            {
                return point.Position;
            }
        }
        return Vector3.zero;
    }
}