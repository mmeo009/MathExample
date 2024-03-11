using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class Calculator : MonoBehaviour
{

    public float leftValue;
    public float rightValue;
    public int opType;

    public bool isLeft;
    public TMP_InputField input;
    public const string CLEAR = "c";

    public void InputText(string txt)
    {
        float result = 0.0f;
        if (txt == "+")
        {
            opType = 1;
        }
        else if (txt == "-")
        {
            opType = 2;
        }
        else if (txt == "*")
        {
            opType = 3;
        }
        else if (txt == "/")
        {
            opType = 4;
        }
        else if (txt == CLEAR)
        {
            opType = 0;
            leftValue = 0;
            rightValue = 0;
            isLeft = false;
            result = 0;
            input.text = result.ToString();
        }
        else
        {
            if(!isLeft)
            {
                isLeft = true;
                leftValue = float.Parse(txt);
            }
            else
            {
                rightValue = float.Parse(txt);

                result = 0.0f;

                switch (opType)
                {
                    case 1:
                        result = Addition(leftValue, rightValue);
                        break;
                    case 2:
                        result = Subtraction(leftValue, rightValue);
                        break;
                    case 3:
                        result = Multiplication(leftValue, rightValue);
                        break;
                    case 4:
                        result = Division(leftValue, rightValue);
                        break;
                    case 5:
                        leftValue = 0;
                        rightValue = 0;
                        isLeft = false;
                        result = 0;
                        break;
                }

                input.text = result.ToString();
                opType = 0;
            }
        }
    }

    private float Addition(float a, float b)
    {
        return a + b;
    }
    private float Subtraction(float a, float b)
    {
        return a - b;
    }
    private float Multiplication(float a, float b)
    {
        return a * b;
    }
    private float Division(float a, float b)
    {
        if(b == 0)
        {
            return 0;
        }
        return a / b;
    }
}
