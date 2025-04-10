using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SchedulePageManager : MonoBehaviour
{
    [Header("References")]
    public GameManager gameManager;
    public LeagueManager leagueManager;
    [Header("League Table")]
    public GameObject leagueTableContainer;
    private GameObject tableRow1Text;
    private GameObject tableRow2Text;
    private GameObject tableRow3Text;
    private GameObject tableRow4Text;
    private GameObject tableRow5Text;
    private GameObject tableRow6Text;
    private GameObject tableRow7Text;
    private GameObject tableRow8Text;
    public List<GameObject> tableRows = new List<GameObject>();
    public GameObject[] tableRowContainers;
    
    [Header("Result Table")]
    public GameObject resultTableContainer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        leagueManager = GameObject.Find("LeagueManager").GetComponent<LeagueManager>();

        tableRowContainers = GameObject.FindGameObjectsWithTag("TableRow");

    }

    // Update is called once per frame
    void Update()
    {
        List<Team> leagueTable = leagueManager.sortedTeams;
        for (int i = 0; i < tableRowContainers.Length && i < leagueTable.Count; i++)
        {
            GameObject row = tableRowContainers[i];
            int position = i + 1;
            TMP_Text leaguePositionText = row.transform.GetChild(0).GetComponent<TMP_Text>();
            TMP_Text teamNameText = row.transform.GetChild(1).GetComponent<TMP_Text>();
            TMP_Text teamWinsText = row.transform.GetChild(2).GetComponent<TMP_Text>();
            TMP_Text teamLossesText = row.transform.GetChild(3).GetComponent<TMP_Text>();
            
            if (leaguePositionText != null && teamNameText != null && teamWinsText != null && teamLossesText != null)
            {
                Team team = leagueTable[i];
                leaguePositionText.text = position.ToString();
                teamNameText.text = team.teamName;
                teamWinsText.text = team.wins.ToString();
                teamLossesText.text = team.losses.ToString();
            }
        }
    }
}
