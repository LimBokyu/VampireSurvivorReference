using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    private PlayerController player = null;

    [SerializeField]
    private TimeManager timeManager;

    [SerializeField]
    private RewardManager rewardManager;

    [SerializeField]
    private OptionManager optionManager;

    [SerializeField]
    private GameObject levelUpUI;

    [SerializeField]
    private RewardList rewardList;

    private int round = 1;

    private int[] killCounts = new int[] { 0,0,0,0 };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionManager.ShowOptions();
        }
    }

    public void SetTimeManager(TimeManager timeManager)
    {
        this.timeManager = timeManager;
    }

    public void SetPlayerController(PlayerController player)
    {
        this.player = player;
    }

    public PlayerController GetPlayer()
    {
        return player;
    }

    public void SetLevelUpUI(GameObject obj)
    {
        levelUpUI = obj;
    }

    public void SetRewardList()
    {
        rewardManager.RewardListSetting();
    }

    public void UpdateRewardList()
    {
        rewardList.UpdateList();
    }


    public void TimeControll(bool stopTime)
    {
        timeManager.SetTimeScale(stopTime);
    }

    public void ShowLevelUpReward()
    {
        levelUpUI.SetActive(true);
        rewardManager.ShowReward();
    }

    public RewardManager GetRewardManager()
    {
        return rewardManager;
    }

    public void RewardSelect()
    {
        levelUpUI.SetActive(false);
        timeManager.SetTimeScale(false);
    }

    public int GetRound()
    {
        return round;
    }

    public void NextRound()
    {
        round++;
    }

    public void InCreaseKillCount(int typeNum)
    {
        killCounts[typeNum]++;
    }
}
