using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Class : MonoBehaviour
{
   public enum NpcState
    {
        NpcBeforeQuest,
        NpcAmidQuest,
        NpcCompleteQuest,
        NpcAfterQuest
    }

    public NpcState CurrentNpcState;
    public bool isQuestDone = false;

    private void Awake()
    {
        CurrentNpcState = NpcState.NpcBeforeQuest;
    }



}
