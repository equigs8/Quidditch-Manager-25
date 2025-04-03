using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using TMPro;

public class PlayerCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler //,IPointerEnterHandler, IPointerExitHandler
{

    private float tiltSpeed = .02f;
    public UnityEngine.UI.Image image;
    public TMP_Text playerName;
    public Transform parentAfterDrag;
    //public Image slotImage;

    public UnityEvent<PlayerCard> DragEnterEvent;
    public UnityEvent<PlayerCard> BeginDragEvent;
    public UnityEvent<PlayerCard> EndDragEvent;
    public UnityEvent<PlayerCard> PointerEnterEvent;
    public UnityEvent<PlayerCard> PointerExitEvent;

    //transform.rotation *= new Quaternion(0f, 0f, 1f, MouseVel().x*tiltSpeed);

    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        playerName = GetComponentInChildren<TMP_Text>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        BeginDragEvent.Invoke(this);
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        playerName.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        //Set position to 0,0,0 relative to parent
        transform.localPosition = Vector3.zero;
        image.raycastTarget = true;
        playerName.raycastTarget = true;
    }
}
