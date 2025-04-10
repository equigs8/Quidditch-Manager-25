using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lineup : MonoBehaviour, IDropHandler
{
    public Player chaser1, chaser2, chaser3, beater1, beater2, keeper1, seeker1;
    public Slot chaser1Slot, chaser2Slot, chaser3Slot, beater1Slot, beater2Slot, keeper1Slot, seeker1Slot;

    public TeamDatabaseManager teamDatabaseManager;
    public GameManager gameManager;
    public Player[] startingLineup = new Player[8];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        teamDatabaseManager = GameObject.Find("TeamDatabase").GetComponent<TeamDatabaseManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        chaser1Slot.OnDropEvent.AddListener(ReloadLineup);
        chaser2Slot.OnDropEvent.AddListener(ReloadLineup);
        chaser3Slot.OnDropEvent.AddListener(ReloadLineup);
        beater1Slot.OnDropEvent.AddListener(ReloadLineup);
        beater2Slot.OnDropEvent.AddListener(ReloadLineup);
        keeper1Slot.OnDropEvent.AddListener(ReloadLineup);
        seeker1Slot.OnDropEvent.AddListener(ReloadLineup);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("onDrop in Lineup");
        //ReloadLineup();
    }

   
    void LoadChaser1()
    {
        Debug.LogWarning("LoadChaser1");
        if (chaser1Slot.playerCard != null)
        {
            chaser1 = chaser1Slot.playerCard.playerData;
        }
    }
    void ReloadLineup()
    {
        
        Debug.LogWarning("ReloadLineup");
        Debug.LogWarning(chaser1Slot.playerCard);
        startingLineup = new Player[8];
        Debug.LogWarning(startingLineup);
        if (chaser1Slot.playerCard != null)
        {
            startingLineup[0] = chaser1Slot.playerCard.playerData;
            
        }
        if (chaser2Slot.playerCard != null)
        {
            startingLineup[1] = chaser2Slot.playerCard.playerData;
        }
        if (chaser3Slot.playerCard != null)
        {
            startingLineup[2] = chaser3Slot.playerCard.playerData;
        }
        if (beater1Slot.playerCard != null)
        {
            startingLineup[3] = beater1Slot.playerCard.playerData;
        }
        if (beater2Slot.playerCard != null)
        {
            startingLineup[4] = beater2Slot.playerCard.playerData;
        }
        if (keeper1Slot.playerCard != null)
        {
            startingLineup[5] = keeper1Slot.playerCard.playerData;
        }
        if (seeker1Slot.playerCard != null)
        {
            startingLineup[6] = seeker1Slot.playerCard.playerData;
        }
        

        //AddToStartingLineup();


        teamDatabaseManager.UpdateStartingLineup(startingLineup.ToList(), gameManager.userTeam);
    }


    
}
       
