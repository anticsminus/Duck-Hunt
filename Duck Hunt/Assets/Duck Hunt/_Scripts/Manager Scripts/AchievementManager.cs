using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class AchievementManager : MonoBehaviour
{
    public GameObject[] lockedImages, unlockedImages;
    public GameObject AchievementInfoPanel;
    public TextMeshProUGUI AchievementTitle, AchievementDescription;

    void Start()
    {
        PlayerPrefs.SetInt("Chicken Dinner", 1);
        try
        {
            int i = 0;

            if (AchievementTitle == null)
                AchievementTitle = GameObject.Find("Achievement Title").GetComponent<TextMeshProUGUI>();

            if (AchievementDescription == null)
                AchievementDescription = GameObject.Find("Achievement Details").GetComponent<TextMeshProUGUI>();

            if (AchievementInfoPanel == null)
                AchievementInfoPanel = GameObject.Find("Achievement Information");

            AchievementInfoPanel.SetActive(false);

            /* Locked images array setter 
             * Checks to see if array is not set
             * Resizes and finds the array -> casted to a var and assigned
             */

            if (lockedImages.Length == 0)
            {
                Array.Resize(ref lockedImages, 10);

                var findLockedImages = GameObject.FindGameObjectsWithTag("Locked").Cast<GameObject>().ToArray();

                foreach (var go in findLockedImages)
                {
                    //Debug.Log(go.name); 
                    lockedImages[i] = findLockedImages[i]; i++;
                }
            } i = 0;

            /* Locked images array setter 
            * Checks to see if array is not set
            * Resizes and finds the array -> casted to a var and assigned
            */

            if (unlockedImages.Length == 0)
            {
                Array.Resize(ref unlockedImages, 10);

                var findUnlockedImages = GameObject.FindGameObjectsWithTag("Unlocked").Cast<GameObject>().ToArray();

                foreach (var go in findUnlockedImages)
                {
                    //Debug.Log(go.name); -> var for reading names 
                    unlockedImages[i] = findUnlockedImages[i];

                    //TODO: write an actual achievement manager script that parses through player/ preferences
                    //Need to study achievement types from gameplay, this is just a simple UI setup for our game scenes 
                    unlockedImages[i].SetActive(false);

                    i++;
                }
            } i = 0;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        //Example on how to check if achievement has been unlocked and then displaying the correct icon / value dependant on the achievement unlocked
        if (PlayerPrefs.GetInt("Chicken Dinner") == 1) 
        {
            lockedImages[1].SetActive(false);
            unlockedImages[1].SetActive(true);
        }
    }

    /* Achievement displayer:
     * 10 achievements in total
     * TODO: List achievements here -> must be researched first
     * Default: Not unlocked
     * 1-10 will be listed
     */

    public void displayAchievement(int index)
    {
        AchievementInfoPanel.SetActive(true);
        switch (index)
        {
            default:
                AchievementTitle.SetText("LOCKED ACHIEVEMENT!");
                AchievementDescription.SetText("Unlock this achievement to learn more details about it, come back later to see your progress!");
                break;

            case 1:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 2:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 3:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 4:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 5:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 6:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 7:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;
            case 8:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 9:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;

            case 10:
                AchievementTitle.SetText("Chicken Dinner!");
                AchievementDescription.SetText("Win your first game, congratulations at eliminating all the ducks!");

                break;
        }
    }
}
