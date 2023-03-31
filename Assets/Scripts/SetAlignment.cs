using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SetAlignment : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.alignment = IsInteger() ? TextAlignmentOptions.Top : TextAlignmentOptions.Center;
    }

    private bool IsInteger()
    {
        if(int.TryParse(ReturnStringWithoutPercentChar(), out int i))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private string ReturnStringWithoutPercentChar()
    {
        string[] splitString = _text.text.Split('%');
        string newString = "";
        foreach(var s in splitString)
        {
            newString += s;
        }
        return newString;
    }
}
