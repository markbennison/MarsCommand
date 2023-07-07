using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Underlighting : MonoBehaviour
{
    Trilobot trilobot;

    int red = 0;
    int green = 0;
    int blue = 0;

    [SerializeField]
    Slider RedSlider;

    [SerializeField]
    Slider GreenSlider;

    [SerializeField]
    Slider BlueSlider;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSliderChange()
	{
        red = (int)RedSlider.value;
        green = (int)GreenSlider.value;
        blue = (int)BlueSlider.value;
    }

    public void SendUnderlighting()
    {
        trilobot = GameManager.Instance.trilobots[0];
        StartCoroutine(GetRequest(trilobot.GetURL() + ":5001/colour/" + red + "/" + green + "/" + blue));
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
