using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    [Header("Bio")]
    public string firstName;
    public string lasteName;

    public string gender;
    [System.Serializable]
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public Position position;
    private string positionString;
    [System.Serializable]
    public enum Position
    {
        Chaser,
        Beater,
        Keeper,
        Seeker
    }

    public string currentTeam = "Free Agent";
    public List<string> pastTeams = new List<string>();

    [Header("Base Stats")]
    public int stamina;
    public int armPower;
    public int vision;
    public int reactions;
    public int topSpeed;
    public int toughness;

    public int rating;


    public void SetFirstName(string name)
    {
        firstName = name;
    }
    public void SetLastName(string name)
    {
        lasteName = name;
    }

    public void SetStats(int newStamina, int newArmPower, int newVision, int newReactions, int newTopSpeed, int newToughness)
    {
        stamina = newStamina;
        armPower = newArmPower;
        vision = newVision;
        reactions = newReactions;
        topSpeed = newTopSpeed;
        toughness = newToughness;   
    }

    internal string GetCurrentTeam()
    {
        return currentTeam;
    }

    public void SetPosition(string newPosition)
    {
        positionString = newPosition;
        switch (newPosition)
        {
            case "Keeper":
                position = Position.Keeper;
                break;
            case "Seeker":
                position = Position.Seeker;
                break;
            case "Chaser":
                position = Position.Chaser;
                break;
            case "Beater":
                position = Position.Beater;
                break;
            default:
                Debug.Log("Default case");
                break;
        }
    }
    public string GetPosition()
    {
        return positionString;
    }

    internal string PositionToString()
    {
        if (position == Position.Chaser)
        {
            return "Chaser";
        }
        else if (position == Position.Beater)
        {
            return "Beater";
        }
        else if (position == Position.Keeper)
        {
            return "Keeper";
        }
        else if (position == Position.Seeker)
        {
            return "Seeker";
        }
        else
        {
            return "Unknown";
        }
    }
    public void CalculateRating()
    {
        rating = (stamina + armPower + vision + reactions + topSpeed + toughness) / 6;
    }
    
}