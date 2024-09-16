using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestItemUI : MonoBehaviour
{
    public TMP_Text QuestTitleText;

    public Image iconImage;

    public void UpdateUI(Quest quest)
    {
        QuestTitleText.text = quest.QuestTitle;

        iconImage.sprite = quest.Icon;
    }
}
