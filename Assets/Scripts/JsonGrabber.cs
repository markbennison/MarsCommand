using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class JsonGrabber : MonoBehaviour
{
	protected string json;
	//void Start()
	//{
		//StartCoroutine(GetText());
	//}

	protected IEnumerator GetText(string uri)
	{
		Debug.Log("1");
		using (UnityWebRequest www = UnityWebRequest.Get(uri))
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
				JsonRetrieved();
				// Or retrieve results as binary data
				//byte[] results = www.downloadHandler.data;
			}
		}
	}

	virtual protected void JsonRetrieved()
	{

	}

}