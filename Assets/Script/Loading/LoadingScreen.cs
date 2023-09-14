using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject fade;

    private Animator fadeAnimator;

    [SerializeField]
    private GameObject loadingBar;

    private Slider loadingSlider;

    private AsyncOperation operation;

    private YieldInstruction waitAnimation = new WaitForSeconds(0.3f);
    private CustomYieldInstruction loadComplete;
    private CustomYieldInstruction progressUpdatePeriod = new WaitForSecondsRealtime(0.05f);
    private Coroutine loadScene = null;

    private string titleSceneName = "TitleScene";
    private string gameSceneName = "GameScene";

    private void Awake()
    {
        fadeAnimator = fade.GetComponent<Animator>();
        loadingSlider = loadingBar.GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        loadComplete = new WaitUntil(() => { return operation.isDone; });
    }

    public void StartLoading()
    {
        if (null == loadScene)
        {
            loadScene = StartCoroutine(LoadStart());
        }
    }

    private IEnumerator LoadStart()
    {
        string scenename = SceneManager.GetActiveScene().name == titleSceneName ? gameSceneName : titleSceneName;
        fadeAnimator.Play("FadeOut");
        yield return waitAnimation;
        loadingBar.SetActive(true);
        operation = SceneManager.LoadSceneAsync(scenename);
        //operation.allowSceneActivation = false;
        StartCoroutine(LoadingProgressUpdate());

        operation.completed += LoadCompleted;
    }

    private IEnumerator LoadingProgressUpdate()
    {
        while(true)
        {
            loadingSlider.value = operation.progress;
            yield return progressUpdatePeriod;
        }    
    }

    private void LoadCompleted(AsyncOperation oper)
    {
        loadingBar.SetActive(false);
        fadeAnimator.Play("FadeIn");
        loadScene = null;
        GameManager.Instance.UpdateRewardList();
        GameManager.Instance.SetRewardList();
    }
}
