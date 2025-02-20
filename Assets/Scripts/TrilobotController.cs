using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class RoverController : SubPanelManager
{
    PlayerInput userInput;

	//Trilobot trilobot;

    void Start()
    {
		// A correct website page.
		//StartCoroutine(GetRequest("https://www.example.com"));

		// A non-existing page.
		//StartCoroutine(GetRequest("https://error.html"));

		userInput = GetComponent<PlayerInput>();

	}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(userInput.actions["Move"].ReadValue<Vector2>().ToString() + " ||| " + MotorPower(userInput.actions["Move"].ReadValue<Vector2>()));
    }

    public void ControlForward()
	{
        //Debug.Log("http://192.168.8.104:5001/move/0.5/0.5");
		//trilobot = GameManager.Instance.trilobots[0];
        //Debug.Log(trilobot.GetURL() + ":5001/move/0.5/0.5");
        
        StartCoroutine(GetRequest(uri + "/move/0.5/0.5"));
        
        //Application.OpenURL("192.168.8.104:5001/move/1/1");
    }

	public void ControlForward_Full()
	{
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/move/1/1"));
		//Application.OpenURL("192.168.8.104:5001/move/1/1");
	}

	public void ControlBackward()
    {
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri +  "/move/-0.5/-0.5"));
    }

	public void ControlBackward_Full()
	{
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/move/-1/-1"));
	}

	public void ControlRight()
    {
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/move/0.5/-0.5"));
    }

	public void ControlRight_Full()
	{
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/move/1/-1"));
	}

	public void ControlLeft()
    {
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/move/-0.5/0.5"));
    }
	public void ControlLeft_Full()
	{
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/move/-1/1"));
	}

	public void ControlStop()
    {
		//trilobot = GameManager.Instance.trilobots[0];
		StartCoroutine(GetRequest(uri + "/stop"));
    }


	Vector2 MotorPower(Vector2 xy)
    {
        float xSq = xy.x * xy.x;
        float ySq = xy.y * xy.y;
        float magnitude = Mathf.Sqrt(xSq + ySq);
		float angle = Mathf.Atan2(xy.y, xy.x);

        angle -= Mathf.Deg2Rad*45;

        float x = Mathf.Cos(angle) * magnitude;
        float y = Mathf.Sin(angle) * magnitude;

        x = Mathf.Round(x * 100) / 100;
		y = Mathf.Round(y * 100) / 100;

        //      if(xy.x >= 0 && xy.y >= 0)
        //      {
        //	//Top-right quadrant
        //	x = Mathf.Sqrt(xSq + ySq);
        //	y = (ySq - xSq) / x;
        //}
        //      else if (xy.x <= 0 && xy.y >= 0)
        //{
        //	//Top-left quadrant
        //}
        //else if (xy.x >= 0 && xy.y <= 0)
        //{
        //	//Bottom-right quadrant
        //}
        //else if (xy.x <= 0 && xy.y <= 0)
        //{
        //	//Bottom-left quadrant
        //}

        //x = xSq + ySq;
        //      y = (ySq - xSq) / x;

        if (xy.y >= 0)
        {
            return new Vector2(x, y);
        }
        else
        {
            return new Vector2(y, x);
        }
    }


    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
