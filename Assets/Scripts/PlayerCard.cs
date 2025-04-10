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
    public Player playerData;
    
    public Vector3 spacingOffset;

    //transform.rotation *= new Quaternion(0f, 0f, 1f, MouseVel().x*tiltSpeed);

    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        playerName = GetComponentInChildren<TMP_Text>();
        spacingOffset = new Vector3(-204f, 0f, 0f);
    }

    void Update()
    {
        if (isDragging)
        {
            // 1. Calculate Mouse Delta
            Vector3 mouseDelta = (Vector3)Input.mousePosition - movementDelta; // 'movementDelta' now stores the previous mouse position

            // 2. Smoothly Move the Card
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, 15f * Time.deltaTime);

            // 3. Calculate Rotation from Mouse Delta
            float rotation = Mathf.Clamp(-mouseDelta.x * rotationAmount, -60, 60); // Negate mouseDelta.x to rotate correctly
            rotationDelta.z = Mathf.Lerp(rotationDelta.z, rotation, rotationSpeed * Time.deltaTime * 0.1f); // Smooth rotation

            // 4. Apply Rotation
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationDelta.z);

            // 5. Store Current Mouse Position for Next Delta
            movementDelta = Input.mousePosition;
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
        movementDelta = Input.mousePosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Dragging");
        isDragging = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("End Drag");
        EndDragEvent.Invoke(this);
        transform.SetParent(parentAfterDrag);
        //Set position to 0,0,0 relative to parent
        transform.localPosition = Vector3.zero;
        transform.localPosition = spacingOffset;
        image.raycastTarget = true;
        playerName.raycastTarget = true;
        isDragging = false;
        //rotationDelta = Vector3.zero; // Reset rotationDelta
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, Vector3.zero, rotationSpeed * Time.deltaTime);
    }
}
