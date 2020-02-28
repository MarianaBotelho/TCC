using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherImage : MonoBehaviour
{
	public Sprite d01;
	public Sprite n01;
	public Sprite d02;
	public Sprite n02;
	public Sprite d03;
	public Sprite n03;
	public Sprite d04;
	public Sprite n04;
	public Sprite d09;
	public Sprite n09;
	public Sprite d10;
	public Sprite n10;
	public Sprite d11;
	public Sprite n11;
	public Sprite d13;
	public Sprite n13;
	public Sprite d50;
	public Sprite n50;

    public GameObject botaoClima;

    public void AtualizaIconeClima(string icone)
    {
        //Debug.Log("icone: " + icone);
        if (icone == "01d")
        {
            botaoClima.GetComponent<Image>().sprite = d01;
        }
        else if (icone == "01n")
        {
            botaoClima.GetComponent<Image>().sprite = n01;
        }
        else if (icone == "02d")
        {
            botaoClima.GetComponent<Image>().sprite = d02;
        }
        else if (icone == "02n")
        {
            botaoClima.GetComponent<Image>().sprite = n02;
        }
        else if (icone == "03d")
        {
            botaoClima.GetComponent<Image>().sprite = d03;
        }
        else if (icone == "03n")
        {
            botaoClima.GetComponent<Image>().sprite = n03;
        }
        else if (icone == "04d")
        {
            botaoClima.GetComponent<Image>().sprite = d04;
        }
        else if (icone == "04n")
        {
            botaoClima.GetComponent<Image>().sprite = n04;
        }
        else if (icone == "09d")
        {
            botaoClima.GetComponent<Image>().sprite = d09;
        }
        else if (icone == "09n")
        {
            botaoClima.GetComponent<Image>().sprite = n09;
        }
        else if (icone == "10d")
        {
            botaoClima.GetComponent<Image>().sprite = d10;
        }
        else if (icone == "10n")
        {
            botaoClima.GetComponent<Image>().sprite = n10;
        }
        else if (icone == "11d")
        {
            botaoClima.GetComponent<Image>().sprite = d11;
        }
        else if (icone == "11n")
        {
            botaoClima.GetComponent<Image>().sprite = n11;
        }
        else if (icone == "13d")
        {
            botaoClima.GetComponent<Image>().sprite = d13;
        }
        else if (icone == "13n")
        {
            botaoClima.GetComponent<Image>().sprite = n13;
        }
        else if (icone == "50d")
        {
            botaoClima.GetComponent<Image>().sprite = d50;
        }
        else if (icone == "50n")
        {
            botaoClima.GetComponent<Image>().sprite = n50;
        }
    }
}
