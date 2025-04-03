using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class WindowManager : MonoBehaviour
{
    public TeamDatabaseManager teamDatabaseManager;
    public GameObject textContainer;
    public TMP_Text headerText;
    public List<TMP_Text> containerElements;
    private GameObject[] slotsGameObjects;
    public List<Slot> slots = new List<Slot>();
    public PlayerCard[] playerCards;
    public PlayerCard selectedPlayerCard;
    public Slot hoveredPlayerCard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textContainer = gameObject;
        headerText = textContainer.transform.GetChild(0).GetComponent<TMP_Text>();

        containerElements = new List<TMP_Text>(textContainer.transform.GetChild(1).GetComponentsInChildren<TMP_Text>());

        slotsGameObjects = GameObject.FindGameObjectsWithTag("Slot");

        foreach(GameObject slot in slotsGameObjects)
        {
            slots.Add(slot.GetComponent<Slot>());
        }


        playerCards = GetComponentsInChildren<PlayerCard>();

        foreach (PlayerCard playerCard in playerCards)
        {
            Debug.Log("Adding Listeners");
            //playerCard.BeginDragEvent.AddListener(BeginDrag);
            //playerCard.EndDragEvent.AddListener(EndDrag);
            
            
        }

        foreach (Slot slot in slots)
        {
            //slot.PointerEnterEvent.AddListener(PlayerCardPointerEnter);
            //slot.PointerExitEvent.AddListener(PlayerCardPointerExit);
        }
    
    }


    // Update is called once per frame
    void Update()
    {
        if (teamDatabaseManager == null)
        {
            Debug.LogError("teamDatabaseManager is NULL!");
            return; // Stop execution to prevent further errors
        }
        if (teamDatabaseManager.GetPlayerTeam() == null)
        {
            Debug.Log("Team name is Null");
        }
        if (teamDatabaseManager.GetPlayerTeam() != null)
        {
            Team team = teamDatabaseManager.GetPlayerTeam();
            headerText.text = team.teamName;
            List<Player> playerList = team.GetPlayers();


            if (team == null)
            {
                Debug.LogError("GetPlayerTeam() returned NULL!");
                return; // Stop execution
            }

            if (headerText == null)
            {
                Debug.LogError("headerText is NULL!");
            }

            if (containerElements == null)
            {
                Debug.LogError("containerElements is NULL!");
            }

            for (int i = 0; i < containerElements.Count && i < playerList.Count; i++)
            {
                if (playerList[i] != null)
                {
                    containerElements[i].text = playerList[i].firstName + " " + playerList[i].lasteName;
                }
                else
                {
                    Debug.LogError("playerList[" + i + "] is null");
                }
            }

        }
    }
}
