
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

  

    internal int PlayMatch()
    {
        int randomNumber = Random.Range(-30, 31);
        int gameResult = 0;
        gameResult = homeTeam.teamRating - awayTeam.teamRating + randomNumber;
        

        

        if (gameResult > 0)
        {
            matchResult = homeTeam.teamName + "Wins";
            
        }
        else if (gameResult < 0)
        {
            matchResult = awayTeam.teamName + "Wins";
            
        }  
        else
        {
            this.PlayMatch();
        }
        Debug.LogWarning(homeTeam.teamName + " vs " + awayTeam.teamName + "\n" + homeTeam.teamRating + " vs " + awayTeam.teamRating + "\n" + randomNumber + "\n" + gameResult);
        return gameResult;
    }


        

    int ToNeg(int value)
    {
        if (value < 0)
            return value * -1;
        else
            return value;
    }
        
}
