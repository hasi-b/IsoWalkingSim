using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
   
    Quest_Class.QuestState currentState;
    public bool isQuestActive;


    public bool oldLadyQuestDone;
    public NPC_Class.NpcState oldLadyCurrentState;

    public bool singleMomQuestDone;
   public NPC_Class.NpcState singleMomCurrentState;


    public bool rockStarQuestDone;
   public NPC_Class.NpcState rockStarCurrentState;

    


    
    




    public  PlayerData(NPC.NPC_Name npc,bool isQuestDone,NPC_Class.NpcState npcState)
    {

        isQuestActive = Quest_Class.instance.isQuestActive;
        currentState = Quest_Class.instance.CurrentState;

        switch (npc)
        {
            case NPC.NPC_Name.Fuli:
                singleMomQuestDone = isQuestDone;
                singleMomCurrentState = npcState;
                break;
            case NPC.NPC_Name.OldLady:
                oldLadyQuestDone = isQuestDone;
                oldLadyCurrentState = npcState;
                break;
            case NPC.NPC_Name.RockStar:
                rockStarQuestDone = isQuestDone;
                rockStarCurrentState = npcState;
                break;
          
        }



    }

 



}
