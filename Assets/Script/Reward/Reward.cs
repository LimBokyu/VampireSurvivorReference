using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward
{
    private string title;
    private string rewardText;
    private int grade;
    private RewardStatus status;

    public Reward(string name, string rewardText, int grade, RewardStatus status)
    {
        this.title = name; 
        this.rewardText = rewardText; 
        this.grade = grade;
        this.status = status;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetRewardText()
    {
        return rewardText;
    }

    public int GetGrade()
    {
        return grade;
    }

    public RewardStatus GetStatus()
    {
        return status;
    }
}
