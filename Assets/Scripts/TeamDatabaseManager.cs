using System.Collections.Generic;
using UnityEngine;

public class TeamDatabaseManager : MonoBehaviour
{
    public SaveAndLoad saveAndLoadManager;
    public List<Team> teams = new List<Team>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(teams.Count);
        Debug.Log(teams);
        
        if (teams.Count <= 0)
        {
            teams = saveAndLoadManager.LoadTeamData();

            foreach (Team team in teams)
            {
                Debug.Log(team.teamName);
            }
            Debug.Log("Loaded team List");
        } 
    }
}
