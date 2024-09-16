using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIManager : MonoBehaviour
{
    public TMP_Text QuestTitleText;

    //public Image iconImage;

    //private bool isDisplayingTitle = true;

    //public void DisplayQuest(Quest quest)
    //{
    //    QuestTitleText.text = quest.QuestTitle;

    //    iconImage.sprite = quest.Icon;

    //}

    //public void ChangeDisplayText()
    //{
    //    isDisplayingTitle = !isDisplayingTitle;
    //    if (isDisplayingTitle)
    //    {
    //        QuestTitleText.text ="complete";
    //        iconImage.gameObject.SetActive(false);


    //    }
    //    else
    //    {
    //        QuestTitleText.text = "complete";
    //        iconImage.gameObject.SetActive(false);


    //    }
    //}

    private void Update()
    {

        if(SceneManagerUI.counter > 3)
        {
            QuestTitleText.text = "Leave the Park";

            return;
        }

        else if (DialogueManager.instance.ShowCurrentQuest()!=null) {



            Debug.Log(DialogueManager.instance.ShowCurrentQuest().quest.QuestTask);
            QuestTitleText.text = DialogueManager.instance.ShowCurrentQuest().quest.QuestTask;
        }
        else
        {
            QuestTitleText.text = "No Quest Active";
            
        }
    }
}

