using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{

    //General Variables for all achievements
    public Animator anim;
    public Text[] text;
    public int howManyAchievementsAreThereCurrently = 1;
    public string[] hasThePlayerSeenThisKeyBefore;
    public bool[] bAchievementsUnlocked;
    public bool isTrue = false;
    public AudioSource SoundSource;
    public AudioClip Achievement;



    //Achievement 1 variables
    void AchievementDisplay()
    {

       // anim.SetBool("isHidden", !isTrue);

    }

    void start()
    {
        for (int i = 0; i < howManyAchievementsAreThereCurrently; i++)
        {
            if (PlayerPrefs.HasKey(hasThePlayerSeenThisKeyBefore[i]))
            {
                bAchievementsUnlocked[i] = true;
            }
            else
            {
                bAchievementsUnlocked[i] = false;

                PlayerPrefs.SetString(hasThePlayerSeenThisKeyBefore[i], "false");

            }
        }
        //achievementUnlocked[0] = PlayerPrefs.GetInt(gameStarted.ToString(), 0) != 0;
    }


    // Achievement 1 variables
    void checkAchievement()
    {
        if (PlayerPrefs.HasKey("Chicken Dinner"))
        {
            // Displays achievement animation       
            if (bAchievementsUnlocked[0] == false)
            {

                SoundSource.clip = Achievement;
                SoundSource.Play();

                GameObject textforTitle = GameObject.Find("AchievementTitle");
                text[0] = textforTitle.GetComponent<Text>();
                text[0].text = "Chicken Dinner!";


                GameObject textforDesc = GameObject.Find("AchievementDesc");
                text[1] = textforDesc.GetComponent<Text>();
                text[1].text = PlayerPrefs.GetString("Chicken Dinner"); /* + " at " /*+  Time.time.ToString()*/
                AchievementDisplay();
                // Plays achievement sound effect 
                PlayerPrefs.SetString(hasThePlayerSeenThisKeyBefore[0], "true");

                Invoke("AchievementDisplay", 5.0f);
            }
        }

    }





    //Achievement 1 variables

    // Update is called once per frame
    void Update()
    {
        checkAchievement();
    }
}