using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public QuestGoal(GoalType goalType, int requiredAmount)
    {
        this.goalType = goalType;
        this.requiredAmount = requiredAmount;
        this.currentAmount = 0;
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
        }
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Heart)
        {
            currentAmount++;
        }
        if (goalType == GoalType.Chip)
        {
            currentAmount++;
        }
        if (goalType == GoalType.Battery)
        {
            currentAmount++;
        }
    }

    public void LevelCompleted()
    {
        if (goalType == GoalType.Win)
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
    Heart,
    Chip,
    Battery,
    Win
}
