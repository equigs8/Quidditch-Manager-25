using Unity.VisualScripting;
using UnityEngine;

public class NavMenuButton : MonoBehaviour
{
    public NavigationManager navigationManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(GameObject pageName)
    {
        navigationManager.ChangePage(pageName.name);
    }
}
