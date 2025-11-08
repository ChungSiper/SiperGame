using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IDropHandler, IEndDragHandler
{
    private bool _isDrag;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _isDrag = false;
            transform.localPosition = Vector2.zero;
        } 
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(!_isDrag)
        {
            return;
        }
        transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDrag = true;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDrag = true;
    }

}