using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
        }
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
        {
            currentAmount++;
        }
    }

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
}

public enum GoalType
{
    Kill,
    Gathering
}
