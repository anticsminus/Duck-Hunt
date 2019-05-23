using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Achievement 1: Chicken Dinner (First win)
 * 
 */
public class UnlockedAchievements : MonoBehaviour
{
    public Image[] Locked;
    public Sprite[] Unlocked;
    private int AchievementsUnlocked = 0;
    void Update()
    {
        checkAchievementUnlocked();
        //PlayerPrefs.GetString(Time.time.ToString(), "Waste Memory"); just an example as getting the time when the achievement was unlocked
    }

    void checkAchievementUnlocked()
    {
        if (PlayerPrefs.HasKey("Chicken Dinner"))
        {
            AchievementsUnlocked += 1;
            Locked[0].sprite = Unlocked[0];
        }

        // "Achievements remaining to unlock = " Locked.Size() - AchievementsUnlocked
    }
}

