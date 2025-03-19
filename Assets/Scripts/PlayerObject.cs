using UnityEngine;

[CreateAssetMenu(fileName = "PlayerObject", menuName = "Scriptable Objects/PlayerObject")]

public class PlayerObject : ScriptableObject
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
    [System.Serializable]
    public enum Position
    {
        Chaser,
        Beater,
        Keeper,
        Seeker
    }

    [Header("Base Stats")]
    public int stamina;
    public int armPower;
    public int vision;
    public int reactions;
    public int topSpeed;
    public int toughness;

    [Header("Unity Utility")]
    public Sprite playerImage;

}
