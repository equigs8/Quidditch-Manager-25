using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDatabaseManager : MonoBehaviour
{
    public SaveAndLoad saveAndLoadManager;
    public List<Player> playerList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerList.Count <= 0)
        {
            playerList = saveAndLoadManager.LoadPlayerData();

            foreach (Player player in playerList)
            {
                Debug.Log(player.firstName);
            }
            Debug.Log("Loaded playerList");
        } 
    }

    internal List<Player> GetPlayerList()
    {
        return playerList;
    }
}
