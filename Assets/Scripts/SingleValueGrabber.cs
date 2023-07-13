using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleValueGrabber : JsonGrabber
{
    [SerializeField]
    TextMeshProUGUI textObject;

    string uri = "http://192.168.8.104:5000/temperature";
    string units = "";

    float value = 0f;
    float timer = 0f;

    public ValueTypeOption valueType;

    List<ValueType> valueTypes = new List<ValueType>();



    void Start()
    {
        valueTypes.Add(new ValueType(ValueTypeOption.Temperature, "°C", "/temperature"));
        valueTypes.Add(new ValueType(ValueTypeOption.Humidity, "%RH", "/humidity"));
        valueTypes.Add(new ValueType(ValueTypeOption.Pressure, "hPa", "/pressure"));

        InitialiseValues();
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
        //JsonUtility.FromJson
        Debug.Log("json: "  + json);
        json = json.Remove(0, 8);

        int index = json.IndexOf(",");
        Debug.Log("index: " + index + "   | " + json);
        if (index == -1)
        {
            return;
        }
        else if (index >= 0)
        {
            json = json.Substring(0, index);
        }
        else
        {
            json = "0";
        }

        float.TryParse(json, out value);

        textObject.text = value.ToString() + " " + units;

    }

    void InitialiseValues()
	{
        uri = GameManager.Instance.trilobots[0].GetAtmosphericURL();

        switch (valueType)
		{
            case ValueTypeOption.Temperature:
                uri += valueTypes[0].UrlSuffix;
                units = valueTypes[0].Units;
                break;
            case ValueTypeOption.Humidity:
                uri += valueTypes[1].UrlSuffix;
                units = valueTypes[1].Units;
                break;
            case ValueTypeOption.Pressure:
                uri += valueTypes[2].UrlSuffix;
                units = valueTypes[2].Units;
                break;
            default:
                uri = "";
                break;
        }
	}


}

public enum ValueTypeOption
{
    Temperature,
    Humidity,
    Pressure
}

public class ValueType
{
    public ValueTypeOption ValueTypeOption { get; set; }
    public string Units { get; set; }
    public string UrlSuffix { get; set; }

    public ValueType(ValueTypeOption valueTypeOption, string units, string urlSuffix)
	{
        ValueTypeOption = valueTypeOption;
        Units = units;
        UrlSuffix = urlSuffix;
	}
}
