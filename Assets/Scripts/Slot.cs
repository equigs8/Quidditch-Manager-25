using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public UnityEvent<Slot> PointerEnterEvent;
    public UnityEvent<Slot> PointerExitEvent;

    public bool isOccupied;
    public bool isPositionLockedSlot = false;
    public string slotPosition = "";
    public PlayerCard playerInPlayerCardSlot;

    public PlayerCard playerCard;
    public TMP_Text positionText;
    public TMP_Text ratingText;
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
        Debug.LogWarning("OnDrop " + eventData.pointerDrag.GetComponent<PlayerCard>().playerData.firstName + " is Player");
        Debug.Log("Dropped on " + name + " GameObject");
        PlayerCard draggedCard = eventData.pointerDrag.GetComponent<PlayerCard>();
        playerInPlayerCardSlot = draggedCard;
        if (isPositionLockedSlot)
        {
            
            if (draggedCard.playerData.PositionToString() == slotPosition)
            {
                if (!isOccupied)
                {
                    GameObject dropped = eventData.pointerDrag;
                    PlayerCard playerCard = dropped.GetComponent<PlayerCard>();
                    playerCard.parentAfterDrag = transform;
                    playerCard.spacingOffset = Vector3.zero;
                } 
            }
        }else if (!isPositionLockedSlot)
        {
            GameObject dropped = eventData.pointerDrag;
            PlayerCard playerCard = dropped.GetComponent<PlayerCard>();
            playerCard.parentAfterDrag = transform;
            playerCard.spacingOffset = new Vector3(-204f, 0f, 0f);

            positionText.text = playerCard.playerData.PositionToString();
            ratingText.text = playerCard.playerData.rating.ToString();
        }
        


        
    }

    public void EndDrag(PlayerCard playerCard)
    {
        
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
