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

    //private float tiltSpeed = .02f;
    public UnityEngine.UI.Image image;
    public TMP_Text playerName;
    public Transform parentAfterDrag;
    //public Image slotImage;

    [HideInInspector] public UnityEvent<PlayerCard> DragEnterEvent;
    [HideInInspector] public UnityEvent<PlayerCard> BeginDragEvent;
    [HideInInspector] public UnityEvent<PlayerCard> EndDragEvent;
    [HideInInspector] public UnityEvent<PlayerCard> PointerEnterEvent;
    [HideInInspector] public UnityEvent<PlayerCard> PointerExitEvent;

    public bool isDragging = false;
    private Vector3 rotationDelta;
    private Vector3 movementDelta;
    private float rotationSpeed = 20f;
    private float rotationAmount = 20f;

    //transform.rotation *= new Quaternion(0f, 0f, 1f, MouseVel().x*tiltSpeed);

    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        playerName = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        if (isDragging)
        {
            //transform.position = Input.mousePosition;
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, 15f * Time.deltaTime);
            
            Vector3 movement = transform.position;
            movementDelta = Vector3.Lerp(movementDelta, movement, 25 * Time.deltaTime);
            Vector3 movementRotation = movement * rotationAmount;
            rotationDelta = Vector3.Lerp(rotationDelta, movementRotation, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(rotationDelta.x, -60, 60));  
        }
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("Begin Drag");
        BeginDragEvent.Invoke(this);
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        playerName.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag");
        transform.SetParent(parentAfterDrag);
        //Set position to 0,0,0 relative to parent
        transform.localPosition = Vector3.zero;
        image.raycastTarget = true;
        playerName.raycastTarget = true;
        isDragging = false;
    }
}
