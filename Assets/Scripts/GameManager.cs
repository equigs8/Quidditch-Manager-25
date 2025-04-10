using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public Team userTeam;

    public TeamDatabaseManager teamDatabaseManager;

    public ScheduleManager scheduleManager;
    public NavigationManager navigationManager;
    public LeagueManager leagueManager;
    public bool scheduleGenerated = false;

    public int week = 0;

    public Dictionary<string, Dictionary<string, Match>> schedule;
    public UnityEvent<Team> teamWinsEvent = new UnityEvent<Team>();
    public UnityEvent<Team> teamLosesEvent = new UnityEvent<Team>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teamDatabaseManager = GameObject.Find("TeamDatabase").GetComponent<TeamDatabaseManager>();
        scheduleManager = GameObject.Find("ScheduleManager").GetComponent<ScheduleManager>();
        navigationManager = GameObject.Find("NavigationManager").GetComponent<NavigationManager>();
        leagueManager = GameObject.Find("LeagueManager").GetComponent<LeagueManager>();


        
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
           
            //Debug.Log("Match " + match.Value.homeTeam.teamName + " vs " + match.Value.awayTeam.teamName);
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
            match.Value.played = true;
            //Debug.LogWarning(match.Value.matchResult);
        }

        
        navigationManager.ResetResultsPopup();
    }

    public void NextWeek()
    {
        navigationManager.ResetResultsPopup();
        week += 1;
    }

    public Match GetNextPlayerMatch()
    {
        if (scheduleGenerated)
        {
            foreach (KeyValuePair<string, Match> match in schedule["Week" + week])
            {
                if (match.Value.homeTeam.teamName == userTeam.teamName || match.Value.awayTeam.teamName == userTeam.teamName)
                {
                    return match.Value;
                }
            }
            return null;
        }
        else
        {
            return null;
        }
    }

    public int GetCurrentWeek()
    {
        return week;
    }


    internal Match GetMatchByWeek(int inputWeek, Team userTeam)
    {
        foreach (KeyValuePair<string, Match> match in schedule["Week" + inputWeek])
        {
            if (match.Value.homeTeam.teamName == userTeam.teamName || match.Value.awayTeam.teamName == userTeam.teamName)
            {
                return match.Value;
            }
        }
        return null;
    }

    internal Match GetLastMatch(Team team)
    {
        foreach (KeyValuePair<string, Match> match in schedule["Week" + (week - 1)])
        {
            if (match.Value.homeTeam.teamName == team.teamName || match.Value.awayTeam.teamName == team.teamName)
            {
                return match.Value;
            }
        }
        return null;
    }

    internal List<Team> GetLeagueTable()
    {
        return leagueManager.leagueTeams;
    }
}
