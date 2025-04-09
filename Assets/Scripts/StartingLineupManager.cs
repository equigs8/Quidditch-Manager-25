using System;
using System.Collections.Generic;
using UnityEngine;

public class StartingLineupManager : MonoBehaviour
{
    public TeamDatabaseManager teamDatabaseManager;
    public List<Slot> chaserSlots = new List<Slot>();
    public List<Slot> beaterSlots = new List<Slot>();
    public List<Slot> keeperSlots = new List<Slot>();
    public List<Slot> seekerSlots = new List<Slot>();
    //Starting line up size is 7 and the chasers ocuppy the slot indexes [0],[1],[2], beaters [3],[4], keeper [5], seeker [6]
    public List<Player> startingLineup;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckStartingLineupSize();

        ChaserSlotCheck();
        BeaterSlotCheck();
        KeeperSlotCheck();
        SeekerSlotCheck();

        
    }

    private void ChaserSlotCheck()
    {
        for (int i = 0; i < chaserSlots.Count; i++)
        {
            if (chaserSlots[i].isOccupied && startingLineup[i] == null)
            {
                startingLineup.Insert(i, chaserSlots[i].playerInPlayerCardSlot.playerData);
            }
        }
    }
    private void BeaterSlotCheck()
    {
        for (int i = 3; i < beaterSlots.Count + 3; i++)
        {
            if (beaterSlots[i - 3].isOccupied && startingLineup[i] == null)
            {
                startingLineup.Insert(i, beaterSlots[i - 3].playerInPlayerCardSlot.playerData);
            }
        }
    }
    private void KeeperSlotCheck()
    {
        for (int i = 5; i < keeperSlots.Count + 5; i++)
        {
            if (keeperSlots[i - 5].isOccupied && startingLineup[i] == null)
            {
                startingLineup.Insert(i, keeperSlots[i - 5].playerInPlayerCardSlot.playerData);
            }
        }
    }
    private void SeekerSlotCheck()
    {
        for (int i = 6; i < seekerSlots.Count + 6; i++)
        {
            if (seekerSlots[i - 6].isOccupied && startingLineup[i] == null)
            {
                startingLineup.Insert(i, seekerSlots[i - 6].playerInPlayerCardSlot.playerData);
            }
        }
    }


    public void RemovePlayerFromStartingLineup(Player playerToRemove)
    {
        startingLineup.Remove(playerToRemove);
    }

    void CheckStartingLineupSize()
    {
        if (startingLineup.Count > 7)
        {
            Debug.Log("Starting lineup is full!");
        }
    }
}
