using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementBehaviour : MonoBehaviour
{
    [Header("TextObject")]
    public Text completionText;

    public static int slimesKilled;
    public static int batteriesCollected;
    public static int heartsCollected;
    public static int chipsCollected;
    public List<Achievement> achievements;


    // Start is called before the first frame update
    void Start()
    {
        Achievement killOneSlime = new Achievement("Defeat one slime", "Defeat your first slime!", 1);
        achievements.Add(killOneSlime);
        Achievement killAllSlimes = new Achievement("Defeat all slimes", "Defeat all slimes!", 3);
        achievements.Add(killAllSlimes);
        Achievement collectAllItems = new Achievement("Collect all items", "Collect all items!", 1);
        achievements.Add(collectAllItems);

    }

    public void UpdateSlimeKills()
    {
        slimesKilled++;
        // killOneSlimeAchievement
        if (!achievements[0].isAchieved && slimesKilled >= achievements[0].requiredAmount)
        {
            CompleteAchievement(achievements[0]);
        }
        if (!achievements[1].isAchieved && slimesKilled >= achievements[1].requiredAmount)
        {
            CompleteAchievement(achievements[1]);
        }
    }

    public void UpdateItemCollected(string itemName)
    {
        if (itemName == "heart")
        {
            heartsCollected++;
        }
        else if (itemName == "chip")
        {
            chipsCollected++;
        }
        else if (itemName == "battery")
        {
            batteriesCollected++;
        }

        if (!achievements[2].isAchieved)
        {
            if (heartsCollected >= achievements[2].requiredAmount && chipsCollected >= achievements[2].requiredAmount && batteriesCollected >= achievements[2].requiredAmount)
            {
                CompleteAchievement(achievements[2]);
            }
        }
    }

    public void CompleteAchievement(Achievement achievement)
    {
        achievement.isAchieved = true;
        completionText.text = achievement.completionText;
        completionText.enabled = true;
        Invoke("RemoveText", 5);
    }

    private void RemoveText()
    {
        completionText.enabled = false;
    }
}
