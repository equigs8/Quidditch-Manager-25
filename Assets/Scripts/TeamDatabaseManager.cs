using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamDatabaseManager : MonoBehaviour
{
    public SaveAndLoad saveAndLoadManager;
    public PlayerDatabaseManager playerDatabase;
    public List<Team> teams = new List<Team>();
    public List<Player> startingLineup;

    [SerializeField] private bool teamDataLoaded = false;
    [SerializeField] private bool playersLoadedIntoTeam = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(teams.Count);
        //Debug.Log(teams);
        
        if (teams.Count <= 0)
        {
            teams = saveAndLoadManager.LoadTeamData();

            foreach (Team team in teams)
            {
                Debug.Log(team.teamName);
            }
            Debug.Log("Loaded team List");
            teamDataLoaded = true;
        }
        if (teamDataLoaded && !playersLoadedIntoTeam)
        { 
            LoadPlayersIntoTeams();
        }
    }

    private void LoadPlayersIntoTeams()
    {
        Debug.Log("LoadPlayersInToTeams Started");
        List<Player> playerList = playerDatabase.GetPlayerList();
        foreach (Player player in playerList)
        {
            Debug.Log("Player Name = " + player.firstName);
            string playerTeamName = player.GetCurrentTeam();
            Debug.Log("Players team name = " + playerTeamName);
            foreach (Team team in teams)
            {
                Debug.Log("Team Name = " + team.teamName);
                Debug.Log("Player team name = Team Name " + playerTeamName == team.teamName);
                if (playerTeamName == team.teamName)
                {
                    team.AddPlayer(player);
                }
            }
        }
        playersLoadedIntoTeam = true;
    }

    public void CheckStartingLineup()
    {
        int maxChaserCounter = 3;
        int chaserCounter = 0;
        int maxBeaterCounter = 2;
        int beaterCounter = 0;
        int maxKeeperCounter = 1;
        int keeperCounter = 0;
        int maxSeekerCounter = 1;
        int seekerCounter = 0;

        foreach (Player player in startingLineup)
        {
            if (player.GetPosition() == "Chaser")
            {
                chaserCounter++;
            }
            else if (player.GetPosition() == "Beater")
            {
                beaterCounter++;
            }
            else if (player.GetPosition() == "Keeper")
            {
                keeperCounter++;
            }
            else if (player.GetPosition() == "Seeker")
            {
                seekerCounter++;
            }



        }
        if (startingLineup.Count > 7)
        {
            Debug.Log("To many Players in starting lineup");
        }
        if (chaserCounter > maxChaserCounter)
        {
            Debug.Log("To many Chasers in starting lineup");
        }
        if (beaterCounter > maxBeaterCounter)
        {
            Debug.Log("To many Beaters in starting lineup");
        }
        if (keeperCounter > maxKeeperCounter)
        {
            Debug.Log("To many Keepers in starting lineup");
        }
        if (seekerCounter > maxSeekerCounter)
        {
            Debug.Log("To many Seekers in starting lineup");
        }
    }

    public void UpdateStartingLineup()
    {
        throw new NotImplementedException();
    }
}
