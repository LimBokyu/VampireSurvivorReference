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
    private SoundManager soundManager;

    [SerializeField]
    private GameObject levelUpUI;

    [SerializeField]
    private LoadingScreen loadingScreen;

    [SerializeField]
    private RewardList rewardList;

    [SerializeField]
    private GameObject quitBox;

    private int round = 1;

    private int[] killCounts = new int[] { 0, 0, 0, 0 };

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionManager.ShowOptions();
        }
    }

    public void GameOver()
    {

    }

    public void SetTimeManager(TimeManager timeManager)
    {
        this.timeManager = timeManager;
    }

    public void SetPlayerController(PlayerController player)
    {
        this.player = player;
    }

    public void SetSFXVolume()
    {
        soundManager.SetSFXVolumeValue();
    }

    public void StartGameButtonClicked()
    {
        loadingScreen.StartLoading();
    }

    public PlayerController GetPlayer()
    {
        return player;
    }

    public OptionManager GetOptionManager()
    {
        return optionManager;
    }

    public void ClickedExitButton()
    {
        quitBox.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
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

    public SoundManager GetSoundManager()
    {
        return soundManager;
    }

    
}
