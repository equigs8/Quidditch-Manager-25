using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public UnityEvent<Slot> PointerEnterEvent;
    public UnityEvent<Slot> PointerExitEvent;

    private bool isOccupied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if slot is occupied
        if (gameObject.transform.childCount > 0)
        {
            isOccupied = true;
        }else
        {
            isOccupied = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped on " + name + " GameObject");
        
        if (!isOccupied)
        {
            GameObject dropped = eventData.pointerDrag;
            PlayerCard playerCard = dropped.GetComponent<PlayerCard>();
            playerCard.parentAfterDrag = transform;
        }else
        {
            //Swap the player cards
            
        }
        
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
