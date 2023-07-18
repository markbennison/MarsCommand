using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPNumberController : MonoBehaviour
{
    string IP;

    [SerializeField] MultipleDigitSelector IP_Number1;
    [SerializeField] MultipleDigitSelector IP_Number2;
    [SerializeField] MultipleDigitSelector IP_Number3;
    [SerializeField] MultipleDigitSelector IP_Number4;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public string GetIP()
    {
        IP = IP_Number1.GetValue().ToString() + ".";
        IP += IP_Number2.GetValue() + ".";
        IP += IP_Number3.GetValue() + ".";
        IP += IP_Number4.GetValue();

        return IP;
    }

    public int GetNumber1()
	{
        return IP_Number1.GetValue();
    }

    public int GetNumber2()
    {
        return IP_Number2.GetValue();
    }

    public int GetNumber3()
    {
        return IP_Number3.GetValue();
    }

    public int GetNumber4()
    {
        return IP_Number4.GetValue();
    }

    public void SetIP(int value1, int value2, int value3, int value4)
    {
        IP_Number1.SetValue(value1);
        IP_Number2.SetValue(value2);
        IP_Number3.SetValue(value3);
        IP_Number4.SetValue(value4);
    }
}
