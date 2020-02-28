﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
	public GameObject pauseMenuUi;

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
		pauseMenuUi.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}
	
	public void Pause()
	{
		pauseMenuUi.SetActive(true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
	
	public void VoltarMainMenu()
	{
		SceneManager.LoadScene(0);
		Debug.Log("Main menu");
	}
	
	public void QuitGame()
	{
		Debug.Log("Saindo");
		Application.Quit();
	}
}
