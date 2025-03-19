using System;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [Header("Team Info")]
    public int teamRating;

    [Header("Players")]
    public List<PlayerObject> players;

    [Header("Tactics")]
    public string strategy;
    public ChaserStrategy chaserStrategy;
    public enum ChaserStrategy
    {
        Attacking,
        Balanced,
        Defending
    }

    public List<Player> startingLineup;
    void Start()
    {
        switch (chaserStrategy)
        {
            case ChaserStrategy.Attacking:
                strategy = "Attacking";
                break;
            case ChaserStrategy.Balanced:
                strategy = "Balanced";
                break;
            case ChaserStrategy.Defending:
                strategy = "Defending";
                break;
            default:
                break;
        }
        CheckStartingLineup();
        UpdateStartingLineup();
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
            }else if (player.GetPosition() == "Seeker")
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
