using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPanelManager : MonoBehaviour
{
	//[SerializeField] Behaviour coreScript;

	protected string uri;
	protected bool started = false;

	public void Initiate(string uri)
	{
		this.uri = uri;
		started = true;

		Debug.Log("(" + started + ") STARTED: " + uri);
	}

	private void Awake()
	{
		//if (coreScript != null)
		//{
		//	coreScript.enabled = false;
		//}
	}

	private void Update()
	{
		if (started)
		{
			UpdateRunning();
		}
	}

	virtual protected void UpdateRunning()
	{

	}

}
