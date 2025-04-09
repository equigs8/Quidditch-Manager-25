using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class LineupPageManager : MonoBehaviour
{
    public TeamDatabaseManager teamDatabaseManager;
    public GameObject textContainer;
    public TMP_Text headerText;
    public List<TMP_Text> containerElements = new List<TMP_Text>();
    public List<TMP_Text> playerPositions = new List<TMP_Text>();
    public List<TMP_Text> playerRatings = new List<TMP_Text>();
    [SerializeField] private GameObject[] slotsGameObjects;
    public PlayerCard[] playerCards;
    public PlayerCard selectedPlayerCard;
    public Slot hoveredPlayerCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textContainer = gameObject;
        headerText = textContainer.transform.GetChild(0).GetComponent<TMP_Text>();

        slotsGameObjects = GameObject.FindGameObjectsWithTag("Slot");

        foreach (GameObject slot in slotsGameObjects)
        {
            //Debug.LogWarning("Slot in slotsGameObjects: " + slot.name);
            containerElements.Add(slot.transform.GetChild(0).Find("NameText").GetComponent<TMP_Text>());
            //Debug.LogWarning("PlayerName: " + slot.transform.GetChild(0).Find("NameText").GetComponent<TMP_Text>().text);
            playerPositions.Add(slot.transform.GetChild(1).Find("PositionText").GetComponent<TMP_Text>());
            //Debug.LogWarning("PlayerPosition: " + slot.transform.GetChild(1).Find("PositionText").GetComponent<TMP_Text>().text);
            playerRatings.Add(slot.transform.GetChild(2).Find("RatingText").GetComponent<TMP_Text>());
            //Debug.LogWarning("PlayerRating: " + slot.transform.GetChild(2).Find("RatingText").GetComponent<TMP_Text>().text);
        }

        bool isWhite = true;
        //alternate the color of the slot image. From white to grey.
        foreach (GameObject slotGameObject in slotsGameObjects)
        {
            if (isWhite)
            {
                slotGameObject.GetComponent<Image>().color = Color.white;
            }
            else
            {
                slotGameObject.GetComponent<Image>().color = Color.grey;
            }
            isWhite = !isWhite;
        }


        playerCards = GetComponentsInChildren<PlayerCard>();

        foreach (PlayerCard playerCard in playerCards)
        {
            //Debug.Log("Adding Listeners");
            //playerCard.BeginDragEvent.AddListener(BeginDrag);
            //playerCard.EndDragEvent.AddListener(EndDrag);
            
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
                    if (containerElements[i].GetComponentInParent<PlayerCard>() == null)
                    {
                        Debug.LogError("containerElements[" + i + "].GetComponent<PlayerCard>() is null");
                    }else
                    {
                        containerElements[i].GetComponentInParent<PlayerCard>().playerData = playerList[i];
                    }
                    
                    playerPositions[i].text = playerList[i].PositionToString();
                    playerRatings[i].text = playerList[i].rating.ToString();
                }
                else
                {
                    Debug.LogError("playerList[" + i + "] is null");
                }
            }



        }
    }
    public void SetPlayerPositionAndRatingText(Slot slot, Player player)
    {
        TMP_Text positionText = slotsGameObjects[GetCurrentSlotIndex(slot)].transform.GetChild(1).Find("PositionText").GetComponent<TMP_Text>();
        TMP_Text ratingText = slotsGameObjects[GetCurrentSlotIndex(slot)].transform.GetChild(2).Find("RatingText").GetComponent<TMP_Text>();
        positionText.text = player.PositionToString();
        ratingText.text = player.rating.ToString();
    }
    public int GetCurrentSlotIndex(Slot slot)
    {
        return Array.IndexOf(slotsGameObjects, slot.gameObject);
    }
}
