using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimaAtual : MonoBehaviour
{
    public Text textoNascerPor;
    public Text textoLocalizacaoAtual;
    public Text textoTemperaturaAtual;

    public void gerenteClimaAtual(string[] clima, DateTime nascerDoSol, DateTime porDoSol)
    {
        TextoNascerPor(nascerDoSol, porDoSol);
        TextoLocalizacaoAtual(clima[4], clima[5]);
        TextoTemperaturaAtual(clima[6]);
    }

    private void TextoNascerPor(DateTime nascer, DateTime por)
    {
        textoNascerPor.text = "Nascer do sol: " + nascer + " Por do sol: " + por;
    }

    private void TextoLocalizacaoAtual(string lat, string lon)
    {
        textoLocalizacaoAtual.text = "Latitude: " + lat + " Longitude: " + lon;
    }

    private void TextoTemperaturaAtual(string temp)
    {
        textoTemperaturaAtual.text = "Temperatura: " + temp;
    }
}
