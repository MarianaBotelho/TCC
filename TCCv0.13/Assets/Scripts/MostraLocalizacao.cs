using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostraLocalizacao : MonoBehaviour
{
    public Text textoLocalizacao;

    public void mostraLocali(string lat, string longi)
    {
        textoLocalizacao.text = "Latitude GPS: " + PegaLocalizacao.Instance.latitude.ToString() + " Longitude GPS: " + PegaLocalizacao.Instance.longitude.ToString() + "Latitude OWM: " + lat + "Longitude OWM: " + longi;
    }
}
