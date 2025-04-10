
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Match
{
    public Team homeTeam;
    public Team awayTeam;

    public int weekNumber;
    public int matchNumber;

    public string matchResult;

    public bool played = false;

    public string record;
    public Team winner;
    public Team loser;


    internal bool HasBeenPlayed()
    {
        return played;
    }

    internal int PlayMatch()
    {
        int randomNumber = Random.Range(-30, 31);
        int gameResult = 0;
        gameResult = homeTeam.teamRating - awayTeam.teamRating + randomNumber;
        

        

        if (gameResult > 0)
        {
            matchResult = homeTeam.teamName + " Wins";
            winner = homeTeam;
            loser = awayTeam;
            
        }
        else if (gameResult < 0)
        {
            matchResult = awayTeam.teamName + " Wins";
            winner = awayTeam;
            loser = homeTeam;
            
        }  
        else
        {
            this.PlayMatch();
        }
        //Debug.LogWarning(homeTeam.teamName + " vs " + awayTeam.teamName + "\n" + homeTeam.teamRating + " vs " + awayTeam.teamRating + "\n" + randomNumber + "\n" + gameResult);
        return gameResult;
    }

    public Team GetWinner()
    {
        return winner;
    }

    public string GetMatchResult()
    {
        return matchResult;
    }

    int ToNeg(int value)
    {
        if (value < 0)
            return value * -1;
        else
            return value;
    }

   
}
