using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RoverController : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("https://www.example.com"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlForward()
	{
        StartCoroutine(GetRequest("http://192.168.8.104:5001/move/1/1"));
        //Application.OpenURL("192.168.8.104:5001/move/1/1");
    }

    public void ControlBackward()
    {
        StartCoroutine(GetRequest("http://192.168.8.104:5001/move/-1/-1"));
    }
    public void ControlRight()
    {
        StartCoroutine(GetRequest("http://192.168.8.104:5001/move/1/-1"));
    }
    public void ControlLeft()
    {
        StartCoroutine(GetRequest("http://192.168.8.104:5001/move/-1/1"));
    }
    public void ControlStop()
    {
        StartCoroutine(GetRequest("http://192.168.8.104:5001/stop"));
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
