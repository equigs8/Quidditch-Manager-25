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
        Player player = new Player();
        player.SetFirstName("Test");
        player.SetLastName("Player");
        player.SetPosition("Keeper");
        player.SetStats(10,10,10,10,10);

        SaveToJSON(player);
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

    public void SaveToJSON(Player objectToSave)
    {
        string jsonString = JsonUtility.ToJson(objectToSave);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerDataBase.json", jsonString);
    }



    public void LoadPlayerData()
    {
        if (FilesExist())
        {
            string json = File.ReadAllText(playerDataBasePath);
             Players playersInJSON = JsonUtility.FromJson<Players>(json);
            
            foreach (Player player in playersInJSON.players)
            {
                Debug.Log("Found Player, " + player);
            }
        }
    }

}
