using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public UnityEvent<Slot> PointerEnterEvent;
    public UnityEvent<Slot> PointerExitEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped on " + name + " GameObject");
        GameObject dropped = eventData.pointerDrag;
        PlayerCard playerCard = dropped.GetComponent<PlayerCard>();
        playerCard.parentAfterDrag = transform;
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        PointerEnterEvent.Invoke(this);
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        PointerExitEvent.Invoke(this);
        Debug.Log("Cursor Entering " + name + " GameObject");
    }
}
