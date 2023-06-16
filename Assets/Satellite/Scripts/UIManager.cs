using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI TimeTMP;

	[SerializeField]
	GameObject Satellite0View, Satellite1View;

	private void Start()
    {
        Satellite0View.SetActive(true);
        Satellite1View.SetActive(false);
    }

    private void Update()
    {
        TimeTMP.text = DateTime.Now.ToString("HH:mm:ss");

	}

    public void SatelliteSelection(int index)
    {
        switch (index)
        {
            case 0:
                Satellite0View.SetActive(true);
                Satellite1View.SetActive(false);
                break;
            case 1:
                Satellite0View.SetActive(false);
                Satellite1View.SetActive(true);
                break;
        }
    }
}
