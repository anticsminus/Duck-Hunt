using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager: MonoBehaviour
{

    public static AudioManager instance = null;
    public GameObject MainCamera;
    public ScenesManager SceneScript;
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

    private void FixedUpdate()
    {
        if(SceneScript.GetCurentScene() != "Main Menu")
        MainCamera.GetComponent<AudioListener>().enabled = false;
        else
        MainCamera.GetComponent<AudioListener>().enabled = true;
    }
}
