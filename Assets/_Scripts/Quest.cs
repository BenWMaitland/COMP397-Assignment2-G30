using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string description;
    public int heartReward;
    public string completeMessage;

    public QuestGoal goal;

    public void Complete()
    {
        completeMessage = "Quest completed: " + title;
        isActive = false;
        Debug.Log("title of quest:" + title + " is completed");

    }
}
