using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AtmosphericDataGrabber : JsonGrabber
{
    string uri;

    [SerializeField]
    TextMeshProUGUI temperatureText, pressureText, humidityText;

    string units = "";

    float value = 0f;
    float timer = 0f;

    AtmosphericData data;

    void Start()
    {
        uri = GameManager.Instance.trilobots[0].GetAtmosphericURL();

    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 2f;
            StartCoroutine(base.GetText(uri));
        }
    }

    override protected void JsonRetrieved()
    {
        //data = JsonUtility.FromJson<AtmosphericData>(json);
        data = AtmosphericData.CreateFromJSON(json);

        Debug.Log(data + " ||| " + json);

        temperatureText.text = data.GetTemperatureString();
        pressureText.text = data.GetPressureString();
        humidityText.text = data.GetHumidityString();


        //json = json.Remove(0, 8);

        //int index = json.IndexOf(",");
        //if (index >= 0)
        //{
        //    json = json.Substring(0, index);
        //}
        //else
        //{
        //    json = "0";
        //}

        //float.TryParse(json, out value);

        //textObject.text = value.ToString() + " " + units;

    }
}

public class AtmosphericData
{
    float humidity;
    string humidityUnits;
    float pressure;
    string pressureUnits;
    float temperature;
    string temperatureUnits;

    public static AtmosphericData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<AtmosphericData>(jsonString);
    }

    //public AtmosphericData(float humidity, string humidityUnits, float pressure,string pressureUnits, float temperature,string temperatureUnits)
    //{
    //    this.humidity = humidity;
    //    this.humidityUnits = humidityUnits;
    //    this.pressure = pressure;
    //    this.pressureUnits = pressureUnits;
    //    this.temperature = temperature;
    //    this.temperatureUnits = temperatureUnits;
    //}

    public string GetHumidityString()
    {
        return humidity.ToString() + " " + humidityUnits;
    }

    public string GetPressureString()
	{
        return pressure.ToString() + " " + pressureUnits;
    }
    public string GetTemperatureString()
    {
        return temperature.ToString() + " " + temperatureUnits;
    }
}
