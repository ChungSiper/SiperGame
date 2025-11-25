using System.Collections;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private CheckPointType checkPointType;
    [SerializeField] private string _tagetSceceName;

    public CheckPointType CheckPointType => checkPointType;
    public Vector2 Position => transform.position;
    private bool _canBeTriggered = true;
    private Collider _collider;

    void Awake()
    {
        _collider = GetComponent<Collider>();
        var playerController = Physics2D.OverlapBox(_collider.bounds.center, _collider.bounds.size, 0, LayerMask.GetMask("Player"));
        if (playerController != null)
        {
            _canBeTriggered = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_canBeTriggered) return;
        _canBeTriggered = false;
        GameManager.Instance.ChangeScece(_tagetSceceName);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _canBeTriggered = true;
    }
}