using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private float tempo = 10f; //três minutos = 180f
	private float ultimaTimestampClima;

    private string[] clima;
	private string[] climaDebug;
	private WeatherAPI api;
    private GerenciaClima gerenciaClima;

    public static GameManager instance = null;
	
	private bool[] missoesCompletadas;
    private int totalCompletadas = 0;
		
    // Start is called before the first frame update
    void Awake()
    {
		//Debug.Log("Game manager");
        if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		
		clima = new string[26];
		
		//clima padrao
		clima[0] = "01d";
		clima[1] = "Clear";
        clima[2] = "1574667261";
        clima[3] = "1574630853";
        clima[4] = "-22";
        clima[5] = "-42";
        clima[6] = "26";
        clima[12] = "800";

        missoesCompletadas = new bool[14]; //todo mundo tem que ser falso; um a mais para não ter que começar do zero
        for(int i = 0; i < 5; i++)
        {
            missoesCompletadas[i] = false;
        }
		
		DontDestroyOnLoad(gameObject);
		
    }

    // Update is called once per frame
    void Update()
    {
		//ver quanto tempo passou para buscar o clima novamente
		if (Time.time - ultimaTimestampClima >= tempo)
		{
			ChamaClima();
            //Debug.Log("Espera pra chamar o clima de novo");

            gerenciaClima = GameObject.Find("Weather").GetComponent<GerenciaClima>();
            gerenciaClima.GerenciaClimaMain(clima);
        }
    }
	
	void ChamaClima()
	{
		api = GameObject.Find("Weather").GetComponent<WeatherAPI>();
		ultimaTimestampClima = Time.time;
		climaDebug = api.RetornaClima((e)=>{ //Lambda
			if (e!=null)
			{
				clima = e;
				//Debug.Log("lambda " + clima[0]);
			}
		});
	}

    public void registraMissao(int numeroMissao)
    {
        missoesCompletadas[numeroMissao] = true;
        totalCompletadas += 1;

        if(numeroMissao == 3)
        {
            Debug.Log("retira as outras galinhas");
        }
        if (numeroMissao == 7)
        {
            Debug.Log("retira as outras araras");
        }

        if (totalCompletadas == 13)
        {
            Debug.Log("fim de jogo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public bool verificaMissao(int numeroMissao)
    {
        if(missoesCompletadas[numeroMissao] == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
