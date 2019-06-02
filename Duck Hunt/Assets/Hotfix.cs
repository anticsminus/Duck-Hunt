using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotfix : MonoBehaviour
{
    public ScenesManager scenesScript;
    // Start is called before the first frame update
    void Start()
    {
        scenesScript = GameObject.Find("Scene Manager").GetComponent<ScenesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallCoroutine()
    {
        scenesScript.loadScene("Main Menu");
    }
}
