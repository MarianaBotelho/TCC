using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class GerenciaClima : MonoBehaviour
{

    private ControlaIluminacao iluminacao;
    private MostraLocalizacao locali;
    private ClimaAtual climaAtual;
    private WeatherImage iconeClima;
    private GameObject jogador;
    private GameObject luzGlobal;
    private GameObject objetoClima;
    private GameObject objetoChuvaParticulas;

    public GameObject mapaNevoa;
    public GameObject poucasNuvens;
    public GameObject medioNuvens;
    public GameObject muitasNuvens;

    private ParticleSystem sistemaParticulas;
    private ParticleSystem.EmissionModule moduloEmissao;

    private string[] clima;
    private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    private bool eDia;
    private DateTime horarioAtual = DateTime.Now;
    private DateTime horarioNascer;
    private DateTime horarioPor;
    private string anterior;

    void Start()
    {
        clima = new string[26];

        anterior = "800";
    }

    public void GerenciaClimaMain(string[] climaAux)
    {
        //Debug.Log("GerenciaClimaMain");

        jogador = GameObject.Find("Lobo");
        luzGlobal = GameObject.Find("GlobalLight2D");
        objetoClima = GameObject.Find("Weather");
        objetoChuvaParticulas = GameObject.Find("ChuvaParticulas");

        clima = climaAux;
        eDia = EDia();
        horarioNascer = RetornaSunrise();
        horarioPor = RetornaSunset();

        ChamaLuz();
        ChamaIconeClima();
        //ChamaMostraLocalizacao();
        //ChamaMostraClimaAtual();

        AlteraClimaGeral();
    }

    void ChamaLuz()
    {
        //Debug.Log("ChamaLuz");
        iluminacao = GameObject.Find("Weather").GetComponent<ControlaIluminacao>();
        //iluminacao.AtualizaLuz(RetornaSunrise(), RetornaSunset());
        iluminacao.AtualizaLuz(eDia);
    }

    void ChamaIconeClima()
    {
        //Debug.Log("ChamaIconeClima");
        iconeClima = GameObject.Find("BotaoClima").GetComponent<WeatherImage>();
        iconeClima.AtualizaIconeClima(clima[0]);
    }

    /*void ChamaMostraLocalizacao()
    {
        //locali = GetComponent<MostraLocalizacao>(); //LatitudeLongitude
        locali = GameObject.Find("LatitudeLongitude").GetComponent<MostraLocalizacao>();
        locali.mostraLocali(clima[4], clima[5]);
    }*/

    void ChamaMostraClimaAtual()
    {
        //Debug.Log("ChamaMostraClimaAtual");
        climaAtual = GameObject.Find("ClimaAtual").GetComponent<ClimaAtual>();
        climaAtual.gerenteClimaAtual(clima, RetornaSunrise(), RetornaSunset());
    }

    void AlteraClimaGeral()
    {
        //Debug.Log("AlteraClimaGeral");

        sistemaParticulas = objetoChuvaParticulas.GetComponent<ParticleSystem>();
        moduloEmissao = sistemaParticulas.emission;

        if (anterior != clima[12])
        {
            //Debug.Log("mudou");

            mapaNevoa.gameObject.SetActive(false);
            poucasNuvens.gameObject.SetActive(false);
            medioNuvens.gameObject.SetActive(false);
            muitasNuvens.gameObject.SetActive(false);
            sistemaParticulas.GetComponent<ParticleSystem>().Stop();
            //Altera pela id
            if (clima[12] == "200" || clima[12] == "201" || clima[12] == "202" || clima[12] == "210" || clima[12] == "211" || clima[12] == "212" || clima[12] == "221" || clima[12] == "230" || clima[12] == "231" || clima[12] == "232") //thunderstorm
            {
                //Debug.Log("faz alguma coisa aqui pra tempestade");

                jogador.GetComponent<PlayerController>().speed = 3;
                if (eDia == true)
                {
                    luzGlobal.GetComponent<Light2D>().intensity = 0.8f;
                }

                muitasNuvens.gameObject.SetActive(true);

                moduloEmissao.rateOverTime = new ParticleSystem.MinMaxCurve(500f);
                objetoChuvaParticulas.GetComponent<ParticleSystem>().Play();
            }
            else if (clima[12] == "300" || clima[12] == "301" || clima[12] == "302" || clima[12] == "310" || clima[12] == "311" || clima[12] == "312" || clima[12] == "313" || clima[12] == "314" || clima[12] == "321") //drizzle
            {
                //Debug.Log("faz alguma coisa aqui pra chuva fraca");

                poucasNuvens.gameObject.SetActive(true);

                moduloEmissao.rateOverTime = new ParticleSystem.MinMaxCurve(100f);
                objetoChuvaParticulas.GetComponent<ParticleSystem>().Play();
            }
            else if (clima[12] == "500" || clima[12] == "501" || clima[12] == "502" || clima[12] == "503" || clima[12] == "504" || clima[12] == "511" || clima[12] == "520" || clima[12] == "521" || clima[12] == "522" || clima[12] == "531") //rain
            {
                //Debug.Log("faz alguma coisa aqui pra chuva");

                jogador.GetComponent<PlayerController>().speed = 4.5f;
                if (eDia == true)
                {
                    luzGlobal.GetComponent<Light2D>().intensity = 0.9f;
                }

                medioNuvens.gameObject.SetActive(true);

                moduloEmissao.rateOverTime = new ParticleSystem.MinMaxCurve(250f);
                objetoChuvaParticulas.GetComponent<ParticleSystem>().Play();
            }
            else if (clima[12] == "600" || clima[12] == "601" || clima[12] == "602" || clima[12] == "611" || clima[12] == "612" || clima[12] == "613" || clima[12] == "615" || clima[12] == "616" || clima[12] == "620" || clima[12] == "621" || clima[12] == "622")
            { //snow
                //Debug.Log("faz alguma coisa aqui pra neve?");
                jogador.GetComponent<PlayerController>().speed = 2;
                if (eDia == true)
                {
                    luzGlobal.GetComponent<Light2D>().intensity = 0.6f;
                }

                moduloEmissao.rateOverTime = new ParticleSystem.MinMaxCurve(200f);
                objetoChuvaParticulas.GetComponent<ParticleSystem>().Play();
            }
            else if (clima[12] == "701" || clima[12] == "711" || clima[12] == "721" || clima[12] == "731" || clima[12] == "741" || clima[12] == "751" || clima[12] == "761" || clima[12] == "762" || clima[12] == "771" || clima[12] == "781") //mist
            {
                //Debug.Log("faz alguma coisa aqui pra névoa");
                if (eDia == true)
                {
                    luzGlobal.GetComponent<Light2D>().intensity = 0.3f;
                }

                mapaNevoa.gameObject.SetActive(true);
                jogador.GetComponent<PlayerController>().speed = 4.5f;
                objetoChuvaParticulas.GetComponent<ParticleSystem>().Stop();
            }
            else if (clima[12] == "801" || clima[12] == "802" || clima[12] == "803" || clima[12] == "804") //clouds
            {
                //Debug.Log("faz alguma coisa aqui pra nuvens");

                objetoChuvaParticulas.GetComponent<ParticleSystem>().Stop();
                if (clima[12] == "804")
                {
                    if (eDia == true)
                    {
                        luzGlobal.GetComponent<Light2D>().intensity = 0.5f;
                    }

                    muitasNuvens.gameObject.SetActive(true);
                }
                else if (clima[12] == "803")
                {
                    if (eDia == true)
                    {
                        luzGlobal.GetComponent<Light2D>().intensity = 0.6f;
                    }
                    medioNuvens.gameObject.SetActive(true);
                }
                else if (clima[12] == "802")
                {
                    poucasNuvens.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("sem nuvens. aspas");
                }

            }
            /*else //clear
            {
                Debug.Log("faz nada pq é o padrão");
                //mapaNevoa.gameObject.SetActive(false);
                //poucasNuvens.gameObject.SetActive(false);
                //medioNuvens.gameObject.SetActive(false);
                //muitasNuvens.gameObject.SetActive(false);
                //objetoChuvaParticulas.GetComponent<ParticleSystem>().Stop();
            }*/
            anterior = clima[12];
        }
        /*else
        {
            Debug.Log("clima nao mudou");
        }*/
    }



    private DateTime RetornaSunrise()
    {
        long aux = Convert.ToInt64(clima[2]);
        return FromUnixTime(aux).ToLocalTime();
    }

    private DateTime RetornaSunset()
    {
        long aux = Convert.ToInt64(clima[3]);
        return FromUnixTime(aux).ToLocalTime();
    }

    private DateTime FromUnixTime(long unixTime)
    {
        return epoch.AddSeconds(unixTime);
    }

    private bool EDia()
    {
        int horaA = horarioAtual.Hour;
        int horaP = horarioPor.Hour;
        int horaN = horarioNascer.Hour;

        if (horaA <= horaP && horaA >= horaN)
        {
            //Debug.Log("E dia");
            return true;
        }
        else
        {
            //Debug.Log("Nao e dia");
            return false;
        }
    }
}
