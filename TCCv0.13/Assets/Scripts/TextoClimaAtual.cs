using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoClimaAtual : MonoBehaviour
{
    public Text textoClimaAtual;

    public void mostraClimaAtual(string[] clima, DateTime nascer, DateTime por)
    {
        textoClimaAtual.text = "Nascer do sol: " + nascer + " Por do sol: " + por;
    }
}
