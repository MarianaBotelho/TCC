using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimaMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool menuIsOpened = false;
    public GameObject climaMenuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        climaMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        menuIsOpened = false;
    }

    public void Pause()
    {
        climaMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        menuIsOpened = true;
    }

    public bool IsClimaMenuOpened()
    {
        return menuIsOpened;
    }

}
