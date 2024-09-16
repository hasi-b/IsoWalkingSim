using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string QuestTitle;
    
    public Sprite  Icon;

    public string QuestTask;
}
