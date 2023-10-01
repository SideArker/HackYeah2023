using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CodeInput : MonoBehaviour
{
    [SerializeField] GameObject screen;
    private Code code;



    public string number;

    private void Start()
    {
        code = screen.GetComponent<Code>();
    }

    public void ButtonClick()
    {
        if (code.enteredCode == code.generatedCode)
        {
            code.onDoorOpen.Invoke();
        }

        if (code.enteredCode.Length < 4)
        {
            code.enteredCode += number;

        }
        else
        {
            code.enteredCode = "";

        }
    }

  
}
