using UnityEngine;
using System.IO;
using System.Collections.Generic;



[System.Serializable]
public class SaveAndLoad : MonoBehaviour
{
    public string playerDataBasePath;
    public TextAsset jsonFile;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDataBasePath = Application.persistentDataPath + playerDataBasePath;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool FilesExist()
    {
        if (File.Exists(playerDataBasePath))
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

    public List<Player> LoadPlayerData()
    {
        if (FilesExist())
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

}
