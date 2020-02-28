using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}
