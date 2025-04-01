using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class PlayerCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    public bool isDragging;
    public GameObject currentSlot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }
}
