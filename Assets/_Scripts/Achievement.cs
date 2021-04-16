using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public bool isAchieved;
    public string title;
    public string completionText;
    public int requiredAmount;

    public Achievement() { }

    public Achievement(string title, string completionText, int requiredAmount)
    {
        this.title = title;
        this.completionText = "Achievement: " + completionText;
        this.requiredAmount = requiredAmount;
    }
}
