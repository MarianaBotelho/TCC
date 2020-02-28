using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class WeatherAPI : MonoBehaviour
{
	private string[] clima;
    //private WeatherRaiz weather
    //private GetLocation api;

    //private string lat = "-22.43";
    //private string lon = "-42.97";
    private string lat;
    private string lon;

    public string apiKey = "";

	//OpenWeatherMap
	private string urlInicialOpen = "http://api.openweathermap.org/data/2.5/weather?lat=";
	//API Key: 73fe20ef57b05534cc5d787d6a8959e7
	//API Key 2: bce5460d5e0ca97f07062f19b6ee7f4e
	
	public string[] RetornaClima(Action<string[]> callback)
	{
        lat = PegaLocalizacao.Instance.latitude.ToString();
        lon = PegaLocalizacao.Instance.longitude.ToString();
        //Debug.Log("lat: " + lat);
        //Debug.Log("lon: " + lon);

        clima = new string[26];
		StartCoroutine(PuxaClima(callback));
		return clima;
	}
	
    public IEnumerator PuxaClima(Action<string[]> callback)
	{
        string urlOpen = "";
        urlOpen = urlInicialOpen + lat + "&lon=" + lon + "&units=metric&APPID=" + apiKey;

        UnityWebRequest request = UnityWebRequest.Get(urlOpen);
        yield return request.SendWebRequest();
        if (request.error == null || request.error == "")
		{
            string jsonString = request.downloadHandler.text;
			//Debug.Log("Resposta: " + jsonString);
			//weather = JsonUtility.FromJson<WeatherRaiz>(jsonString);
			WeatherRaiz weather = setWeatherAttributes(jsonString);
			//clima[0] = weather.weather[0].icon;
			//clima[1] = weather.weather[0].main;
            //clima[2] = weather.sys.sunrise;
            //clima[3] = weather.sys.sunset;
            clima = ViraString(weather);
            callback(clima);
		}
		else
		{
			Debug.Log("Error: " + request.error);
			callback(null);
			//Outra API?
		}
    }

    private WeatherRaiz setWeatherAttributes(string jsonString)
    {
        WeatherRaiz weatherJson = JsonUtility.FromJson<WeatherRaiz>(jsonString);
        //Debug.Log(weatherJson.coord.lat);
        //Debug.Log(weatherJson.weather[0].icon);
        return weatherJson;
    }

    private string[] ViraString(WeatherRaiz weather)
    {
        string[] aux = new string[26];
        aux[0] = weather.weather[0].icon;
        aux[1] = weather.weather[0].main;
        aux[2] = weather.sys.sunrise;
        aux[3] = weather.sys.sunset;
        aux[4] = weather.coord.lat;
        aux[5] = weather.coord.lon;
        aux[6] = weather.main.temp.ToString();
        aux[7] = weather.main.pressure.ToString();
        aux[8] = weather.main.humidity.ToString();
        aux[9] = weather.main.temp_min.ToString();
        aux[10] = weather.main.temp_max.ToString();
        aux[11] = weather.visibility.ToString();
        aux[12] = weather.weather[0].id.ToString();
        aux[13] = weather.weather[0].description;
        aux[14] = weather.wind.speed.ToString();
        aux[15] = weather.wind.deg.ToString();
        aux[16] = weather.clouds.all.ToString();
        aux[17] = weather.sys.country;
        aux[18] = weather.name;
        aux[19] = weather.timezone;
        aux[20] = weather.sys.id.ToString();
        aux[21] = weather.sys.type.ToString();
        aux[22] = weather.cod.ToString();
        aux[23] = weather.id.ToString();
        aux[24] = weather.dt.ToString();
        //aux[25] = weather.base;
        return aux;
    }
}
