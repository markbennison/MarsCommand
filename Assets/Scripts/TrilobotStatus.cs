using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrilobotStatus : JsonGrabber
{
    [SerializeField]
    TextMeshProUGUI idTextObject;

    [SerializeField]
    TextMeshProUGUI nameTextObject;

    [SerializeField]
    string uri = "http://192.168.8.104:5001/";

    float timer = 0f;

    void Start()
    {
        StartCoroutine(base.GetText(uri));
    }

    void Update()
    {
        //timer -= Time.deltaTime;

        //if (timer <= 0)
        //{
        //    timer = 2f;
        //    StartCoroutine(base.GetText(uri));
        //}
    }

    override protected void JsonRetrieved()
    {
        TrilobotIdentification thisTrilobot = JsonUtility.FromJson<TrilobotIdentification>(json);

        idTextObject.text = thisTrilobot.id.ToString();
        nameTextObject.text = thisTrilobot.name;
    }
}


public class TrilobotIdentification
{
    public int id;
    public string name;

    public TrilobotIdentification(int id, string name)
	{
        this.id = id;
        this.name = name;
	}
}