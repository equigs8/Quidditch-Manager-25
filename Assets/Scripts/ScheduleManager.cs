using System.Collections.Generic;
using UnityEngine;

public class ScheduleManager : MonoBehaviour
{
    public Dictionary<string, Dictionary<string, Match>> GenerateSchedule(List<Team> teams)
    {
        Dictionary<string, Dictionary<string, Match>> schedule = new Dictionary<string, Dictionary<string, Match>>();
        
        int weeks = 12;
        int matchesPerWeek = 4;
        for (int week = 0; week < weeks; week++)
        {
            Dictionary<string, Match> matchWeek = new Dictionary<string, Match>();
            List<Team> teamsLeftToPlay = new List<Team>(teams);

            for(int match = 0; match <= matchesPerWeek; match++)
            {
                if (teamsLeftToPlay.Count > 1)
                {
                    Team homeTeam = teamsLeftToPlay[Random.Range(0, teamsLeftToPlay.Count)];
                    teamsLeftToPlay.Remove(homeTeam);
                    Team awayTeam = teamsLeftToPlay[Random.Range(0, teamsLeftToPlay.Count)];
                    teamsLeftToPlay.Remove(awayTeam);
                    Match newMatch = new Match();
                    newMatch.homeTeam = homeTeam;
                    newMatch.awayTeam = awayTeam;
                    matchWeek.Add("Match" + match, newMatch);
                }
            }
            schedule.Add("Week" + week, matchWeek);
            
        }

        string scheduleString = "";
        foreach (KeyValuePair<string, Dictionary<string, Match>> week in schedule)
        {
            foreach (KeyValuePair<string, Match> match in week.Value)
            {
                scheduleString +=  week.Key + " " + match.Key + " " + match.Value.homeTeam.teamName + " vs " + match.Value.awayTeam.teamName + "\n";
            }
        }
        Debug.LogWarning(scheduleString);
        return schedule;
    }


}
