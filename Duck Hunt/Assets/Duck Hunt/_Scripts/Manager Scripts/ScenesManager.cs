using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance = null;
    private Animator anim;
    private Image fadeImage;
    public GameObject fadeOverlay, LoadingUI, ReturnToMain, SettingButton, StartGameButton, AchievementsButton, LeaderboardButton;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        anim = GameObject.Find("FadeOutImage").GetComponent<Animator>();
        fadeImage = GameObject.Find("FadeOutImage").GetComponent<Image>();
        fadeImage.enabled = false;
        LoadingUI.SetActive(false);
    }

    public IEnumerator LoadArea(string sceneName)
    {
        if (anim == null)
            anim = GameObject.Find("FadeOutImage").GetComponent<Animator>();
        if (fadeImage == null)
            fadeImage = GameObject.Find("FadeOutImage").GetComponent<Image>();

        //get references to animator and image component 
        fadeImage.enabled = true;
        //turn control UI off and loading UI on
        //ControlUI.SetActive(false);
        LoadingUI.SetActive(true);

        //set FadeOut to true on the animator so our image will fade out
        anim.SetBool("FadeOut", true);

        //wait until the fade image is entirely black (alpha=1) then load next scene
        yield return new WaitUntil(() => fadeImage.color.a == 1);

        SceneManager.LoadScene(sceneName);

        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == sceneName);

        Debug.Log("loading scene:" + SceneManager.GetActiveScene());

        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);
        LoadingUI.SetActive(false);
        //set FadeOUt to false on the animator so our image will fade back in 
        anim.SetBool("FadeOut", false);

        //wait until the fade image is completely transparent (alpha = 0) and then turn loading UI off and control UI back on
        yield return new WaitUntil(() => fadeImage.color.a == 0);
        fadeImage.enabled = false;

        StopCoroutine(LoadArea(sceneName));

        //if we have not destroyed the control UI, set it to active

    }

    public void FixedUpdate()
    {
        checkButtons();
    }

    public void checkButtons()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            if (StartGameButton == null)
            {
                StartGameButton = GameObject.Find("Start");
                StartGameButton.GetComponent<Button>().onClick.AddListener(StartGame);
            }
            if (AchievementsButton == null)
            {
                AchievementsButton = GameObject.Find("Achievements");
                AchievementsButton.GetComponent<Button>().onClick.AddListener(Achievements);
            }
            if (LeaderboardButton == null)
            {
                LeaderboardButton = GameObject.Find("Leaderboard");
                LeaderboardButton.GetComponent<Button>().onClick.AddListener(Leaderboard);
            }
        }
    }

    public string GetCurentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void loadScene(string levelName)
    {
        StartCoroutine(LoadArea(levelName));
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        StartCoroutine(LoadArea("Main Menu"));
    }

    public void StartGame()
    {
        StartCoroutine(LoadArea("Main Level"));
    }

    public void Achievements()
    {
        StartCoroutine(LoadArea("Achievements"));
    }

    public void Leaderboard()
    {
        StartCoroutine(LoadArea("Leaderboard"));
    }

}