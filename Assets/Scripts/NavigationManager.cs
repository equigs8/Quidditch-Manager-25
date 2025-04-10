using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public List<GameObject> pages;
    public GameObject activePage;
    void Start()
    {
        if (activePage == null)
        {
            activePage = pages[0];
        }
        ChangePage(activePage.name);
    }
    public void ChangePage(string pageName)
    {
        foreach (GameObject page in pages)
        {
            if(page.activeSelf){
                page.SetActive(false);
            }
            if (page.name == pageName)
            {
                page.SetActive(true);
                activePage = page;
            }
        }
    }

    public void ResetResultsPopup()
    {
        
        NextMatchMenuPage nextMatchMenuPage = activePage.GetComponent<NextMatchMenuPage>();
        nextMatchMenuPage.PrepareForNextMatch();
        
    }
}
