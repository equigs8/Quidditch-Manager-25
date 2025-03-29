using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;



[System.Serializable]
public class SaveAndLoad : MonoBehaviour
{
    public string playerDataBasePath;
    public string teamDataBasePath;
    public TextAsset jsonFile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDataBasePath = Application.persistentDataPath + playerDataBasePath;
        teamDataBasePath = Application.persistentDataPath + teamDataBasePath;

        
        AddDefaultTeamSaveFile();
        AddDefaultPlayerSaveFile();

    }

    void AddDefaultTeamSaveFile()
    {
        List<Team> teamList = new List<Team>();

        Team team1 = new Team();
        team1.teamName = "England";
        team1.isPlayerTeam = true;
        

        Team team2 = new Team();
        team2.teamName = "France";

        Team team3 = new Team();
        team3.teamName = "Irland";
        Team team4 = new Team();
        team4.teamName = "Spain";


        teamList.Add(team1);
        teamList.Add(team2);
        teamList.Add(team3);
        teamList.Add(team4);

        TeamSaveToJSON(teamList);
    }

    void AddDefaultPlayerSaveFile()
    {
        List<Player> playerList = new List<Player>();

        Player player1 = new Player();
        player1.firstName = "Ethan";
        player1.lasteName = "Quigley";
        player1.position = Player.Position.Chaser;
        player1.currentTeam = "England";

        Player player2 = new Player();
        player2.firstName = "Will";
        player2.lasteName = "Quigley";
        player2.position = Player.Position.Seeker;
        player2.currentTeam = "England";
        Player player3 = new Player();
        player3.firstName = "Richard";
        player3.lasteName = "Quigley";
        player3.position = Player.Position.Chaser;
        player3.currentTeam = "England";
        playerList.Add(player1);
        playerList.Add(player2);
        playerList.Add(player3);

        SaveToJSON(playerList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool FileExist(string filePath)
    {
        if (File.Exists(filePath))
        {
            return true;
        }

        return false;
    }


    public void SaveToJSON(List<Player> playersToSave)
    {
        string json = JsonUtility.ToJson(new Wrapper<Player>(playersToSave));
        File.WriteAllText(playerDataBasePath, json);
    }
     public void TeamSaveToJSON(List<Team> teamsToSave)
    {
        string json = JsonUtility.ToJson(new Wrapper<Team>(teamsToSave));
        File.WriteAllText(teamDataBasePath, json);
    }

    public List<Player> LoadPlayerData()
    {
        if (FileExist(playerDataBasePath))
        {


            string json = File.ReadAllText(playerDataBasePath);
            Wrapper<Player> wrapper = JsonUtility.FromJson<Wrapper<Player>>(json);
            List<Player> playersList = wrapper.items;

            foreach (Player player in playersList)
            {
                //Debug.Log("Found Player, " + player.firstName);
            }
            return playersList;
        }
        return null;
    }
    public List<Team> LoadTeamData()
    {
        if (FileExist(teamDataBasePath))
        {
            string json = File.ReadAllText(teamDataBasePath);
            Wrapper<Team> wrapper = JsonUtility.FromJson<Wrapper<Team>>(json);
            List<Team> teamsList = wrapper.items;

            foreach (Team team in teamsList)
            {
                Debug.Log("Found Team, " + team.teamName);
            }

            return teamsList;
        }
        return null;
    }

}
