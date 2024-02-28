using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public Button[] levelButtons;
    public int unlockLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        if (levelButtons.Length > 0)
        {
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i].interactable = false;
            }

            for (int i = 0; i < PlayerPrefs.GetInt("unlockedLevels", 1); i++)
            {
                levelButtons[i].interactable |= true;
            }
        }
    }

    public void MoreLevels()
    {
        if (unlockLevel > PlayerPrefs.GetInt("unlockedLevels", 1))
        {
            PlayerPrefs.SetInt("unlockedLevels", unlockLevel);
        }
    }

    void Update()
    {
        
    }
}
