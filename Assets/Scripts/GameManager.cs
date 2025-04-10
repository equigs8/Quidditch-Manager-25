using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public Team userTeam;

    public TeamDatabaseManager teamDatabaseManager;

    public ScheduleManager scheduleManager;
    private bool scheduleGenerated = false;

    public int week = 0;

    public Dictionary<string, Dictionary<string, Match>> schedule;
    public UnityEvent<Team> teamWinsEvent = new UnityEvent<Team>();
    public UnityEvent<Team> teamLosesEvent = new UnityEvent<Team>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teamDatabaseManager = GameObject.Find("TeamDatabase").GetComponent<TeamDatabaseManager>();
        scheduleManager = GameObject.Find("ScheduleManager").GetComponent<ScheduleManager>();


        
    }

    // Update is called once per frame
    void Update()
    {
        if (teamDatabaseManager.teams.Count == 8 && !scheduleGenerated)
        {
            //Debug.LogWarning(teamDatabaseManager.teams);
            schedule = scheduleManager.GenerateSchedule(teamDatabaseManager.teams);
            scheduleGenerated = true;
            //Debug.LogWarning("Schedule Generated");
        }
        if (teamDatabaseManager.GetPlayerTeam() != null)
        {
            userTeam = teamDatabaseManager.GetPlayerTeam();
        }

    }

    public void PlayNextWeeksGames()
    {
        

        foreach (KeyValuePair<string, Match> match in schedule["Week" + week])
        {
           
            Debug.Log("Match " + match.Value.homeTeam.teamName + " vs " + match.Value.awayTeam.teamName);
            int matchResult = match.Value.PlayMatch();
            if (matchResult > 0)
            {
                match.Value.homeTeam.WinGame();
                match.Value.awayTeam.LoseGame();
            }
            else if (matchResult < 0)
            {
                match.Value.homeTeam.LoseGame();
                match.Value.awayTeam.WinGame();
            }
            Debug.LogWarning(match.Value.matchResult);
        }

        week++;
        
    }

}
