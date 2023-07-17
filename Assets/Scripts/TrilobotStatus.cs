using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrilobotStatus : JsonGrabber
{
    Underlighting underlighting;

    [SerializeField]
    TextMeshProUGUI idTextObject;

    [SerializeField]
    TextMeshProUGUI nameTextObject;

    float timer = 0f;
    bool initialised = false;

    override protected void UpdateRunning()
    {
		if (!initialised)
		{
			StartCoroutine(GetText(uri + "/"));
			initialised = true;
			underlighting.Initiate(uri);
		}
	}

	private void Start()
	{
        underlighting = GetComponent<Underlighting>();
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