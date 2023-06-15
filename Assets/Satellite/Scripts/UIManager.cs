using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject Satellite0View, Satellite1View;

    private void Start()
    {
        Satellite0View.SetActive(true);
        Satellite1View.SetActive(false);
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
