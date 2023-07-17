using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Underlighting : MonoBehaviour
{
    //Trilobot trilobot;

    string url = "";

    float red = 0;
	float green = 0;
	float blue = 0;

    [SerializeField]
    Slider RedSlider;

    [SerializeField]
    Slider GreenSlider;

    [SerializeField]
    Slider BlueSlider;

	[SerializeField]
	Image trilobotImage;

	[SerializeField]
	Image underlightImage;

    public void Initiate(string uri)
    {
        this.url = uri;
    }

    public void ColorSliderChange()
	{
        red = RedSlider.value;
        green = GreenSlider.value;
        blue = BlueSlider.value;
    }

    public void SendUnderlighting()
    {
        if (url == "")
        {
            Debug.Log("No URL for Underlighting");
            return;
        }

		StartCoroutine(GetRequest(url + "/colour/" + red + "/" + green + "/" + blue));

        if(red == 0 && green == 0 && blue == 0)
        {
			underlightImage.color = new Color(0,0,0,0);
            return;
		}

		float normalisedRed = red / 255f;
		float normalisedGreen = green / 255f;
		float normalisedBlue = blue / 255f;

		underlightImage.color = new Color(normalisedRed, normalisedGreen, normalisedBlue);
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
