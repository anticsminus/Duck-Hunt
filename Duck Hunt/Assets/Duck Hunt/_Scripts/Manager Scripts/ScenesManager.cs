using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance = null;
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
    }

    public void loadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
