using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonGrabber : MonoBehaviour
{
	public string json;
	void Start()
	{
		StartCoroutine(GetText());
	}

	IEnumerator GetText()
	{
		using (UnityWebRequest www = UnityWebRequest.Get("http://www.my-server.com"))
		{
			yield return www.Send();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				// Show results as text
				json = www.downloadHandler.text;

				// Or retrieve results as binary data
				byte[] results = www.downloadHandler.data;
			}
		}
	}
}