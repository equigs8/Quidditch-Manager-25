using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class PlayerCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{

    public bool isDragging;
    public GameObject currentSlot;
    public GameObject slotOver;

    //public Image slotImage;

    public UnityEvent<PlayerCard> DragEnterEvent;
    public UnityEvent<PlayerCard> BeginDragEvent;
    public UnityEvent<PlayerCard> EndDragEvent;
    public UnityEvent<PlayerCard> PointerEnterEvent;
    public UnityEvent<PlayerCard> PointerExitEvent;

    void Start()
    {
        currentSlot = gameObject.transform.parent.gameObject;
    }


    void Update()
    {
        
        if (isDragging)
        {
            transform.position = Input.mousePosition;
        }else
        {
            if (slotOver != null && slotOver.transform.childCount == 0)
            {
                currentSlot = slotOver;
                transform.position = slotOver.transform.position;
            }else
            {
                this.transform.SetParent(slotOver.transform);
                transform.position = currentSlot.transform.position;
            }
            
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        BeginDragEvent.Invoke(this);
        Debug.Log("Begin drag");
        isDragging = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        EndDragEvent.Invoke(this);
        //Debug.Log("End Drag");
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        PointerEnterEvent.Invoke(this);
        Debug.Log("Cursor Entering " + name + " GameObject");
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        PointerExitEvent.Invoke(this);
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }

    public void SetSlotOver(GameObject slot)
    {
        slotOver = slot; 
    }
}
