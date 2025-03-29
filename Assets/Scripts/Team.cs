using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Team
{
    [Header("Team Info")]
    public string teamName;
    public int teamRating;

    [Header("Players")]
    public List<Player> players;
    public bool isPlayerTeam = false;

    void Start()
    {
        
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
}
