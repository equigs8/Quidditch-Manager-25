using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeagueManager : MonoBehaviour
{

    public List<Team> leagueTeams = new List<Team>();
    public TeamDatabaseManager teamDatabaseManager;
    public List<Team> sortedTeams = new List<Team>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teamDatabaseManager = GameObject.Find("TeamDatabase").GetComponent<TeamDatabaseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        leagueTeams = teamDatabaseManager.teams;
        SortLeagueTeamsByRecord();
    }

    void SortLeagueTeamsByRecord()
    {
        sortedTeams = leagueTeams.OrderByDescending(team => team.points).ToList();
       
        //Debug.LogWarning("Sorted Teams: " + sortedTeams);
    }
}
