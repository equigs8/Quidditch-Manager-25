using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;



[System.Serializable]
public class SaveAndLoad : MonoBehaviour
{
    public TextAsset teamFileAsString;
    public TextAsset playerFileAsString;
    public string playerDataBasePath;
    public string teamDataBasePath;
    public TextAsset jsonFile;

    public TextAsset firstNamesFile;
    public TextAsset lastNamesFile;

    private List<string> firstNames = new List<string>();
    private List<string> lastNames = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerDataBasePath = Application.persistentDataPath + playerDataBasePath;
        //teamDataBasePath = Application.persistentDataPath + teamDataBasePath;

        
        //AddDefaultTeamSaveFile();
        //AddDefaultPlayerSaveFile();

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
        Team team5 = new Team();
        team5.teamName = "Germany";
        Team team6 = new Team();
        team6.teamName = "Italy";
        Team team7 = new Team();
        team7.teamName = "Scotland";

        teamList.Add(team1);
        teamList.Add(team2);
        teamList.Add(team3);
        teamList.Add(team4);
        teamList.Add(team5);
        teamList.Add(team6);
        teamList.Add(team7);

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
        player1.SetStats(100, 100, 100, 100, 100, 100);

        Player player2 = new Player();
        player2.firstName = "Will";
        player2.lasteName = "Quigley";
        player2.position = Player.Position.Seeker;
        player2.currentTeam = "England";
        player2.SetStats(100, 100, 100, 100, 100, 100);
        Player player3 = new Player();
        player3.firstName = "Richard";
        player3.lasteName = "Quigley";
        player3.position = Player.Position.Chaser;
        player3.currentTeam = "England";
        player3.SetStats(100, 100, 100, 100, 100, 100);
        Player player4 = new Player();
        player4.firstName = "Charlotte";
        player4.lasteName = "Nahley";
        player4.position = Player.Position.Beater;
        player4.currentTeam = "England";
        player4.SetStats(100, 100, 100, 100, 100, 100);
        playerList.Add(player1);
        playerList.Add(player2);
        playerList.Add(player3);
        playerList.Add(player4);

        for (int i = 0; i < 100; i++)
        {
            playerList.Add( GenerateRandomPlayer());
        }


        SaveToJSON(playerList);
    }

    public Player GenerateRandomPlayer()
    {
        ReadNamesFromFiles();

        Player player = new Player();
        player.firstName = firstNames[UnityEngine.Random.Range(0, firstNames.Count)];
        player.lasteName = lastNames[UnityEngine.Random.Range(0, lastNames.Count)];
        int position = UnityEngine.Random.Range(0, 4);
        switch (position)
        {
            case 0:
                player.position = Player.Position.Chaser;
                break;
            case 1:
                player.position = Player.Position.Beater;
                break;
            
            case 2:
                player.position = Player.Position.Keeper;
                break;
            case 3:
                player.position = Player.Position.Seeker;
                break;
            
        }
        int stamina = UnityEngine.Random.Range(50, 100);
        int armPower = UnityEngine.Random.Range(50, 100);
        int vision = UnityEngine.Random.Range(50, 100);
        int reactions = UnityEngine.Random.Range(50, 100);
        int topSpeed = UnityEngine.Random.Range(50, 100);
        int toughness = UnityEngine.Random.Range(50, 100);
        player.SetStats(stamina, armPower, vision, reactions, topSpeed, toughness);
        int teamNumber = UnityEngine.Random.Range(0, 7);
        switch (teamNumber)
        {
            case 0:
                player.currentTeam = "England";
                break;
            case 1:
                player.currentTeam = "France";
                break;
            case 2:
                player.currentTeam = "Irland";
                break;
            case 3:
                player.currentTeam = "Spain";
                break;
            case 4:
                player.currentTeam = "Germany";
                break;
            case 5:
                player.currentTeam = "Italy";
                break;
            case 6:
                player.currentTeam = "Scotland";
                break;
        }
        return player;
    }

    private void ReadNamesFromFiles()
    {
        if (firstNamesFile == null || lastNamesFile == null)
        {
            Debug.LogError("First or last names TextAssets are not assigned in the inspector.");
            return;
        }

        using (StringReader reader = new StringReader(firstNamesFile.text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim(); // Remove leading/trailing whitespace
                if (!string.IsNullOrEmpty(line))
                {
                    firstNames.Add(line);
                }
            }
        }

        // Read last names
        using (StringReader reader = new StringReader(lastNamesFile.text))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (!string.IsNullOrEmpty(line))
                {
                    lastNames.Add(line);
                }
            }
        }

        if (firstNames.Count > 0 && lastNames.Count > 0)
        {
            Debug.Log("Names read successfully.");
        }
        else
        {
            Debug.LogWarning("One or both name lists are empty after reading.");
        }
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
        }else if(playerFileAsString != null)
        {
            if (PlayerPrefs.HasKey("playerDataSave"))
            {
                string json = PlayerPrefs.GetString("playerDataSave");
                if (!string.IsNullOrEmpty(json))
                {
                    Debug.Log("Loading saved player data from PlayerPrefs.");
                    Wrapper<Player> wrapper = JsonUtility.FromJson<Wrapper<Player>>(json);
                    return wrapper.items;
                }
            }
            if (playerFileAsString != null)
            {
                Debug.Log("Loading default player data from TextAsset.");
                string json = playerFileAsString.text;
                Wrapper<Player> wrapper = JsonUtility.FromJson<Wrapper<Player>>(json);
                return wrapper.items;
            }

            Debug.LogWarning("No saved player data found and no default player data TextAsset assigned.");
            return new List<Player>();
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
        else if (teamFileAsString != null)
        {
            if (PlayerPrefs.HasKey("teamDataSave"))
            {
                string json = PlayerPrefs.GetString("teamDataSave");
                if (!string.IsNullOrEmpty(json))
                {
                    Debug.Log("Loading saved team data from PlayerPrefs.");
                    Wrapper<Team> wrapper = JsonUtility.FromJson<Wrapper<Team>>(json);
                    return wrapper.items;
                }
            }

            // Fallback: Load default data
            if (teamFileAsString != null)
            {
                Debug.Log("Loading default team data from TextAsset.");
                string json = teamFileAsString.text;
                Wrapper<Team> wrapper = JsonUtility.FromJson<Wrapper<Team>>(json);
                return wrapper.items;
            }

            Debug.LogWarning("No saved team data found and no default team data TextAsset assigned.");
            return new List<Team>(); // Return empty list or handle error
        }
        return null;
    }

}
