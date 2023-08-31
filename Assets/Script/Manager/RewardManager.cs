using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField]
    private RewardList rewardList;

    [SerializeField]
    private List<Reward> lowLevelRewards;

    [SerializeField]
    private List<Reward> middleLevelRewards;

    [SerializeField]
    private List<Reward> highLevelRewards;

    [SerializeField]
    private GameObject leftReward;

    [SerializeField]
    private GameObject middleReward;

    [SerializeField]
    private GameObject rightReward;

    private StringBuilder sb = new StringBuilder();

    private List<GameObject> rewardCards = new List<GameObject>();

private void Awake()
    {
        lowLevelRewards = new List<Reward>();
        middleLevelRewards = new List<Reward>();
        highLevelRewards = new List<Reward>();


        rewardCards.Add(leftReward);
        rewardCards.Add(middleReward);
        rewardCards.Add(rightReward);
    }

    public void GetRewardList(List<Reward> list, int grade)
    {
        switch(grade)
        {
            case 0:
                lowLevelRewards = list;
                break;
            case 1:
                middleLevelRewards = list;
                break;
            case 2:
                highLevelRewards = list;
                break;
            default:
                break;
        }
    }

    public void ShowReward()
    {
        //Debug.Log("ShowReward");

        List<Reward> list = new List<Reward>();

        int leftgrade = Random.Range(0, 3);
        int middlegrade = Random.Range(0, 3);
        int rightgrade = Random.Range(0, 3);

        int[] grades = { leftgrade, middlegrade, rightgrade };
        
        for(int index=0; index < grades.Length; index++)
        {
            switch (grades[index])
            {
                case 0:
                    list = lowLevelRewards;
                    break;
                case 1:
                    list = middleLevelRewards;
                    break;
                case 2:
                    list = highLevelRewards;
                    break;
            }

            int random = Random.Range(0, list.Count);

            rewardCards[index].GetComponentInChildren<RewardCard>().GetReward(list[random]);
        }
       
    }
}
