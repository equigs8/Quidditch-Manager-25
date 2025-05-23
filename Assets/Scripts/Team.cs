using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Team
{
    [Header("Team Info")]
    public string teamName;
    public int teamRating;
    public Lineup lineup;

    public int wins = 0;
    public int losses = 0;

    [Header("Players")]
    public List<Player> players;
    public bool isPlayerTeam = false;
    public List<Player> startingLineup;
    GameManager gameManager;
    public int points;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public void WinGame()
    {
        Debug.LogWarning("WinGame");
       
        wins += 1;
        points += 3;
        
    }

    public void LoseGame()
    {
        Debug.LogWarning("LoseGame");
        
        losses += 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal List<Player> GetPlayers()
    {
        return players;
    }

    internal void AddPlayer(Player player)
    {
        players.Add(player);
    }

    internal void GenerateTeamRating()
    {
        foreach (Player player in players)
        {
            teamRating += player.rating;
        }
        if (players.Count > 0)
        {
            teamRating /= players.Count;
        }
        
    }

    internal string GetTeamRecordString()
    {
        return wins + " - " + losses;
    }

    /*
     public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(Match))
        {
            return false;
        }
        else
        {
            Match comparingMatch = (Match)obj;
            return comparingMatch.matchNumber == matchNumber && comparingMatch.weekNumber == weekNumber;
        }
    }
    */
}
