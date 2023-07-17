using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Text LoadingPercentge;
    public Image LoadingImage;
    private Animator componentAnimator;

    private static SceneTransition instance;
    private static bool shouldPlayAnim = false;
    private AsyncOperation loadSceneAsync;

    void Start()
    {
        instance = this;
        componentAnimator = GetComponent<Animator>();

        if (shouldPlayAnim) componentAnimator.SetTrigger("Scene End");
    }
    private void Update()
    {
        if (loadSceneAsync != null)
        {
            LoadingPercentge.text = Mathf.RoundToInt(loadSceneAsync.progress * 100) + "%";
            LoadingImage.fillAmount = loadSceneAsync.progress;
        }
    }

    public static void SwithToScene(string sceneName)
    {

            instance.componentAnimator.SetTrigger("Scene Start");

            instance.loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);
            instance.loadSceneAsync.allowSceneActivation = false;
        
    }

    public void OnAnymationOver()
    {
        loadSceneAsync.allowSceneActivation = true;
        shouldPlayAnim = true;
    }
}
