using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SingleValueGrabber : JsonGrabber
{
    [SerializeField]
    TextMeshProUGUI textObject;

    [SerializeField]
    string uri = "http://192.168.8.104:5000/temperature";

    [SerializeField]
    string units = "";

    float value = 0f;
    float timer = 0f;

    void Start()
    {
        
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
        json = json.Remove(0, 8);

        int index = json.IndexOf(",");
        if (index >= 0)
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
}
