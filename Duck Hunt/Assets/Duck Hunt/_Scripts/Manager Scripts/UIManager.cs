using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance = null;

    [Header("Pause Menu Assignment")]
    [Tooltip("Assign the pause menu prefab here to toggle/untoggle the pause menu based upon pressing escape")]
    public GameObject PauseMenu;
    private bool Paused;
    private float CurentTime;
    // Start is called before the first frame update
    void Awake()
    {
        Paused = false;
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

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Paused = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        CurentTime = Time.time;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused = !Paused;
            PauseMenu.SetActive(Paused);
        }
        if (Paused == true || PauseMenu.active == true)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }
}
