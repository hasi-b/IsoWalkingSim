using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, IInteractable
{

    [SerializeField]NPC_Class npcCurrentState;

    private void Awake()
    {
        npcCurrentState =  transform.parent.gameObject.GetComponent<NPC_Class>();
    }
    
    public void NPCAction()
    {
        npcCurrentState.CurrentNpcState = NPC_Class.NpcState.NpcCompleteQuest;
        Quest_Class.instance.CurrentState = Quest_Class.QuestState.QuestFetched;
        Destroy(this.gameObject);
    }


}
