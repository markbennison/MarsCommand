using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AtmosphericDataGrabber : JsonGrabber
{
    [SerializeField]
    TextMeshProUGUI temperatureText, pressureText, humidityText;

    float timer = 0f;

    AtmosphericData data;

    void Start()
    {
        //uri = GameManager.Instance.trilobots[0].GetAtmosphericURL();

    }

    override protected void UpdateRunning()
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
        data = new AtmosphericData(json);

        temperatureText.text = data.GetTemperatureString();
        pressureText.text = data.GetPressureString();
        humidityText.text = data.GetHumidityString();
    }
}

[System.Serializable]
public class AtmosphericData
{
    public float humidity;
    public string humidityUnits;
    public float pressure;
    public string pressureUnits;
    public float temperature;
    public string temperatureUnits;

    public AtmosphericData(string jsonString)
    {
        AtmosphericData data = CreateFromJSON(jsonString);

        //Debug.Log(data.humidity + " | " + data.pressure + " | " + data.temperature);

        humidity = data.humidity;
        humidityUnits = data.humidityUnits;
        pressure = data.pressure;
        pressureUnits = data.pressureUnits;
        temperature = data.temperature;
        temperatureUnits = data.temperatureUnits;

    }

    public static AtmosphericData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<AtmosphericData>(jsonString);
    }

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
