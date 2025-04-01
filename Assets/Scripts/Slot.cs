using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [HideInInspector] public UnityEvent<Slot> PointerEnterEvent;
    [HideInInspector] public UnityEvent<Slot> PointerExitEvent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointEnter(PointerEventData pointerEventData)
    {
        pointerEventData.Invoke(this);
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        pointerEventData.Invoke(this);
        Debug.Log("Cursor Entering " + name + " GameObject");
    }
}
