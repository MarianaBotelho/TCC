using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NomeClima : MonoBehaviour
{
    public Text textoClima;

    public void AtualizaNomeClima(string nome)
    {
        textoClima.text = nome;
        //Debug.Log("nome: " + nome);
    }
}
