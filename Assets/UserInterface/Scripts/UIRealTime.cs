using System;
using TMPro;
using UnityEngine;

public class UIRealTime : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI TimeTMP;

    void Update()
    {
        TimeTMP.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
