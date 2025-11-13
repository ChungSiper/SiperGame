using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemDataSO _itemData;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _positionSpeed = 2f;
    private Item _item;
    void Awake()
    {
        _item = new Item(_itemData);
    }
    private void Update()
    {
        transform.Rotate(0f, _rotationSpeed * Time.deltaTime, 0f);
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin( _positionSpeed * Time.time) * Time.deltaTime, transform.position.z);

    }
    void OnValidate()
    {
        gameObject.name = "Item_" + _itemData.Name;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        if(collider.TryGetComponent<PlayerInventory>(out PlayerInventory playerInventory))
        {
            playerInventory.AddItem(_item);
            Destroy(gameObject);
        }
    }
    
}
