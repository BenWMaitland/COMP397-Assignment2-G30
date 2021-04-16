using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public List<Quest> questList;

    public PlayerCollision player;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text achievementText;
    public Text questCompleteText;
    public RawImage questImage;

    public static int questIndex = 0;

    public void Start()
    {
        questWindow.SetActive(false);
        questList = new List<Quest>();
        Quest newQuest = new Quest("Defeat 1 slime", "Reward: Heart", GoalType.Kill, 1);
        questList.Add(newQuest);
        newQuest = new Quest("Collect 1 heart", "", GoalType.Heart, 1);
        questList.Add(newQuest);
        newQuest = new Quest("Collect 1 microchip", "", GoalType.Chip, 1);
        questList.Add(newQuest);
        newQuest = new Quest("Collect 1 battery", "", GoalType.Battery, 1);
        questList.Add(newQuest);
        newQuest = new Quest("Reach the satellite", "", GoalType.Win, 1);
        questList.Add(newQuest);
        quest = questList[questIndex];
        OpenQuestWindow();
    }

    public void StartQuest()
    {
        quest = questList[questIndex];
        Invoke("OpenQuestWindow", 5);
    }

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

    public void CompleteQuest()
    {
        quest.Complete();
        questCompleteText.text = quest.completeMessage;
        questCompleteText.enabled = true;
        Invoke("RemoveText", 5);
        questIndex++;
        if (questIndex < questList.Count)
        {
            StartQuest();
        }
    }

    private void RemoveText()
    {
        questCompleteText.enabled = false;
    }
}
