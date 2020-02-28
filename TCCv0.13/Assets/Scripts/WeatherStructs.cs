using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Coord {
	public string lon;
	public string lat;
}

[System.Serializable]
public class Weather {
	public int id;
	public string main;
	public string description;
	public string icon;
}

[System.Serializable]
public class Main {
	public float temp;
	public int pressure;
	public int humidity;
	public float temp_min;
	public float temp_max;
	public int sea_level;
	public int grnd_level;
}

[System.Serializable]
public class Wind {
	public float speed;
	public float deg;
}

[System.Serializable]
public class Clouds {
	public int all;
}

[System.Serializable]
public class Rain {
	public float oneH;
	public float threeH;
}

[System.Serializable]
public class Snow {
	public float oneH;
	public float threeH;
}

[System.Serializable]
public class Sys {
	public int type;
	public int id;
	public string message;
	public string country;
	public string sunrise;
	public string sunset;
}

[System.Serializable]
public class WeatherRaiz {
	public Coord coord;
	public List<Weather> weather;
	public string @base;
	public Main main;
	public int visibility;
	public Wind wind;
	public Clouds clouds;
	public Rain rain;
	public Snow snow;
	public int dt;
	public Sys sys;
	public string timezone;
	public int id;
	public string name;
	public int cod;
}