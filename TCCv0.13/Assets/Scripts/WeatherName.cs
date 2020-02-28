using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherName : MonoBehaviour
{
	public Text weatherText;
	
    public void AtualizaNomeClima(string nome)
    {
        weatherText.text = nome;
        //Debug.Log("nome: " + nome);
    }
}
