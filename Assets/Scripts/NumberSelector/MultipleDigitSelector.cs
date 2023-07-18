using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleDigitSelector : MonoBehaviour
{
    int value;

    [SerializeField] List<DigitSelector> digits;

    void Start()
    {

    }

    void Update()
    {

    }


    public int GetValue()
    {
        value = 0;
        string stringValue = "";

        if (digits.Count > 0)
		{
            foreach(DigitSelector digit in digits)
			{
                stringValue += digit.GetValue().ToString();
			}

            int.TryParse(stringValue, out value);
		}

        return value;
    }

    public void SetValue(int value)
    {
        string stringFormat = "";
        for (int n = 0; n < digits.Count; n++)
        {
            stringFormat += "0";
        }
        
        string stringValue = value.ToString(stringFormat);
        stringValue = stringValue.Substring(stringValue.Length - digits.Count, digits.Count);

        for (int i = 0; i < digits.Count; i++)
		{
            digits[i].SetValue(stringValue[i]);
        }
        
    }
}
