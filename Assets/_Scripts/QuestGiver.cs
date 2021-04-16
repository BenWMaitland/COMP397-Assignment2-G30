using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{

    public Quest quest;

    public PlayerCollision player;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text achievementText;
    public Text questCompleteText;
    public RawImage questImage;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;

        player.quest = quest;
    }
}
