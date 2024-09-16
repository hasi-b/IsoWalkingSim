using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void AddQuest(Quest quest)
    {
        if (!quests.Contains(quest))
        {
            quests.Add(quest);
        }
    }

    public void RemoveQuest(Quest quest)
    {
        if (quests.Contains(quest))
        {
            quests.Remove(quest);
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (quests.Contains(quest))
        {
            quests.Remove(quest);
            // Add code to give player rewards or do other actions upon completing quest
        }
    }
}
