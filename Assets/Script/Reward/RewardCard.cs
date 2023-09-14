using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardCard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI rewardName;

    [SerializeField]
    private TextMeshProUGUI rewardOption;

    private RewardStatus rewardStatus = null;

    private Color rewardColor = Color.white;

    [SerializeField]
    private RewardPosition rewardPosition;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        GameManager.Instance.GetRewardManager().SetRewardPosition(gameObject, rewardPosition);
    }

    public void GetReward(Reward reward)
    {
        rewardName.text = reward.GetTitle();
        rewardOption.text = reward.GetRewardText();
        rewardStatus = reward.GetStatus();

        switch(reward.GetGrade())
        {
            case 1:
                rewardColor = Color.white;
                break;
            case 2:
                rewardColor = Color.cyan;
                break;
            case 3:
                rewardColor = Color.yellow;
                break;
        }
        image.color = rewardColor;
    }

    public void TakeReward()
    {
        GameManager.Instance.GetPlayer().PlayerGetReward(rewardStatus);
    }

}
