using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaHistoria : MonoBehaviour
{
    private float tempo = 2f; //2 segundos
    private float ultimaTimestamp;
    public bool isOpen = true;
    public GameObject primeiraCaixa;

    // Start is called before the first frame update
    void Start()
    {
        ultimaTimestamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - ultimaTimestamp >= tempo)
        {
            //primeiraCaixa.gameObject.SetActive(true);
            Debug.Log("puxa a caixa de dialogo?");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

/*
Nossos animais correm perigo
    Muitos desastres ambientais vem ocorrendo ultimamente
    É seu trabalho resgatá-los
    Ajude a todos lobinho
    Nos ajude.....
*/