using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RewardList : MonoBehaviour
{
    [SerializeField]
    private List<Reward> lowLevelRewards = new List<Reward>();

    [SerializeField]
    private List<Reward> middleLevelRewards = new List<Reward>();

    [SerializeField]
    private List<Reward> highLevelRewards = new List<Reward>();

    private void Awake()
    {
        SetRewardList();
    }

    private void SetRewardList()
    {
        SetLowLevelRewardList();
        SetMiddleLevelRewardList();
        SetHighLevelRewardList();
    }

    public void UpdateList()
    {
        GameManager.Instance.GetRewardManager().GetRewardList(lowLevelRewards, 0);
        GameManager.Instance.GetRewardManager().GetRewardList(middleLevelRewards, 1);
        GameManager.Instance.GetRewardManager().GetRewardList(highLevelRewards, 2);
    }


    private void SetLowLevelRewardList()
    {
        lowLevelRewards.Add(new Reward("Attack Up!", "Damage + 5", 1, new RewardStatus(5, 0, 0f,0)));
        lowLevelRewards.Add(new Reward("Faster Attack", "FasterCoolTime - 0.2s", 1, new RewardStatus(0, 0, 0.2f, 0)));
        lowLevelRewards.Add(new Reward("HP Plus", "HP + 30", 1, new RewardStatus(0, 30, 0f, 0)));
        lowLevelRewards.Add(new Reward("Pierce Up!", "Enemy Pierce + 1", 1 ,new RewardStatus(0, 0, 0, 1)));
    }

    private void SetMiddleLevelRewardList()
    {
        middleLevelRewards.Add(new Reward("Attack Double", "Damage + 10", 2, new RewardStatus(10, 0, 0f, 0)));
    }

    private void SetHighLevelRewardList()
    {
        highLevelRewards.Add(new Reward("High HP Up", "HP + 200", 3, new RewardStatus(0, 200, 0f, 0)));
        highLevelRewards.Add(new Reward("Super Pierce", "Pierce Infinity", 3, new RewardStatus(0, 0, 0f, 999)));
    }

    public List<Reward> GetRewardCardList(int grade)
    {
        switch(grade)
        {
            case 0:
                return lowLevelRewards;
            case 1:
                return middleLevelRewards;
            case 2:
                return highLevelRewards;
            default:
                return null;
        }
    }
}
