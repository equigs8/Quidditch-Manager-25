using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NextMatchMenuPage : MonoBehaviour
{
    [Header("General")]
    public GameManager gameManager;
    public NavigationManager navigationManager;
    public Match currentPlayerMatch;

    [Header("Teams Container")]
    public GameObject teamsContainer;
     public TMP_Text team1NameText;
    public TMP_Text team2NameText;

    [Header("Match Week Container")]
    public GameObject matchWeekContainer;
    public TMP_Text matchWeekText;

    [Header("Team Record Container")]
    public GameObject teamRecordContainer;
    public TMP_Text teamNameText;
    public TMP_Text teamRecordText;


    [Header("Result Popup")]
    public GameObject resultPopup;
    public bool resultPopupHasBeenShown = false;
    public bool canShowResultPopup = false;

    [Header("Buttons Container")]
    public Button playMatchButton;


    

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       navigationManager = GameObject.Find("NavigationManager").GetComponent<NavigationManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (matchWeekContainer != null)
        {
            matchWeekText = matchWeekContainer.GetComponentInChildren<TMP_Text>();
            if (matchWeekText != null)
            {
               int currentWeek = gameManager.GetCurrentWeek();
               matchWeekText.text = "Matchweek " + currentWeek.ToString(); 
               //Debug.LogWarning("Matchweek " + currentWeek.ToString());
            }
            
        }
        if (teamsContainer != null) 
        {
            
            team1NameText = teamsContainer.GetComponentsInChildren<TMP_Text>()[0];
            team2NameText = teamsContainer.GetComponentsInChildren<TMP_Text>()[2];
        }
        

        if(gameManager.scheduleGenerated && gameManager.userTeam != null)
        {
            Match nextMach = gameManager.GetMatchByWeek(gameManager.GetCurrentWeek(), gameManager.userTeam);
            
            if(nextMach != null && team1NameText != null && team2NameText != null)
            {
                team1NameText.text = nextMach.homeTeam.teamName;
                team2NameText.text = nextMach.awayTeam.teamName;
            }
            if (playMatchButton != null)
            {
                if (nextMach.played)
                {
                    playMatchButton.interactable = false;
                    
                    if(resultPopupHasBeenShown == false)
                    {
                        canShowResultPopup = true;
                    }        

                }else
                {
                    playMatchButton.interactable = true;
                    canShowResultPopup = false;
                }
            }
            Match lastMatch = gameManager.GetLastMatch(gameManager.userTeam);
            if (lastMatch != null)
            {
                 // Always update the team record based on the latest stats
                 if (teamRecordContainer != null)
                 {
                    teamNameText = teamRecordContainer.GetComponentsInChildren<TMP_Text>()[0];
                    teamRecordText = teamRecordContainer.GetComponentsInChildren<TMP_Text>()[1];
                    if (teamNameText != null) teamNameText.text = gameManager.userTeam.teamName;
                    if (teamRecordText != null) teamRecordText.text = gameManager.userTeam.GetTeamRecordString();
                 }

                // Show the result popup for the last match if it was played and popup hasn't been shown yet
                if (canShowResultPopup && resultPopupHasBeenShown == false)
                {
                    ResultPopup(nextMach); // Pass the specific match whose result needs showing
                }
            }
        
        }
    }

    void ResultPopup(Match matchToShow)
    {
        
        if (resultPopup != null && matchToShow != null)
        {
            TMP_Text resultText = resultPopup.GetComponentInChildren<TMP_Text>();
            if(resultText != null)
            {
                resultText.text = matchToShow.GetMatchResult(); // Use the result from the passed match
            }
            resultPopup.SetActive(true);
        }
        resultPopupHasBeenShown = true;
    }
    public void CloseResultPopup()
    {
        
        resultPopup.SetActive(false);
        canShowResultPopup = false;
    }

    public void PrepareForNextMatch()
    {
        resultPopupHasBeenShown = false;
        resultPopup.SetActive(false);
    }
}
