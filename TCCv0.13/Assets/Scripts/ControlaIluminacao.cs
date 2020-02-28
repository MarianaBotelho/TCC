using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class ControlaIluminacao : MonoBehaviour
{
    //public static PegaLocalizacao Instance { set; get; }

    public GameObject bolaAmarelaLuz;
    public GameObject luzGlobal;
    public GameObject corujaNPC;
    public GameObject crocodiloNPC;
    public GameObject macaco1NPC;
    public GameObject macaco2NPC;

    public void AtualizaLuz(bool eDia)
    {
        //Debug.Log("AtualizaLuz");
        AlteraIluminacao(eDia);
    }

    private void AlteraIluminacao(bool eDia) 
    {
        //Mudar para só colocar quem ainda não tem a missão completada
        //Debug.Log("AlteraIluminacao");
        if (eDia == false) //Entao é noite
        {
            luzGlobal.gameObject.SetActive(false);
            bolaAmarelaLuz.GetComponent<Light2D>().enabled = true;
            macaco1NPC.gameObject.SetActive(false);
            macaco2NPC.gameObject.SetActive(false);

            if (GameManager.instance.verificaMissao(8) == false)
            {
                corujaNPC.gameObject.SetActive(true);
            }
            if (GameManager.instance.verificaMissao(13) == false)
            {
                crocodiloNPC.gameObject.SetActive(true);
            }
        }
        else //Entao é dia
        {
            luzGlobal.gameObject.SetActive(true);
            bolaAmarelaLuz.GetComponent<Light2D>().enabled = false;
            corujaNPC.gameObject.SetActive(false);
            crocodiloNPC.gameObject.SetActive(false);

            if (GameManager.instance.verificaMissao(4) == false)
            {
                macaco1NPC.gameObject.SetActive(true);
            }
            if (GameManager.instance.verificaMissao(11) == false)
            {
                macaco2NPC.gameObject.SetActive(true);
            }
        }
    }
}
