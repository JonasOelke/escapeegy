using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpindCodeController : MonoBehaviour
{
    string[] display = { "0", "0", "0", "0" };

    int digitPosition = 1;

    String joinedString;

    String solution = "2405";

    private Button _0;

    private Button _1;

    private Button _2;

    private Button _3;

    private Button _4;

    private Button _5;

    private Button _6;

    private Button _7;

    private Button _8;

    private Button _9;

    private Button _OK;

    private Label Digits;

    private void Start()
    {
        //gameObject1.SetActive(false);
        //gameObject1.SetActive(false)
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _0 = root.Q<Button>("0");
        _1 = root.Q<Button>("1");
        _2 = root.Q<Button>("2");
        _3 = root.Q<Button>("3");
        _4 = root.Q<Button>("4");
        _5 = root.Q<Button>("5");
        _6 = root.Q<Button>("6");
        _7 = root.Q<Button>("7");
        _8 = root.Q<Button>("8");
        _9 = root.Q<Button>("9");
        _OK = root.Q<Button>("OK");
        Digits = root.Q<Label>("Digits");

        _0.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("0");
                ConvertDigitArrayToString();
            }
        };
        _1.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("1");
                ConvertDigitArrayToString();
            }
        };
        _2.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("2");
                ConvertDigitArrayToString();
            }
        };
        _3.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("3");
                ConvertDigitArrayToString();
            }
        };
        _4.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("4");
                ConvertDigitArrayToString();
            }
        };
        _5.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("5");
                ConvertDigitArrayToString();
            }
        };
        _6.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("6");
                ConvertDigitArrayToString();
            }
        };
        _7.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("7");
                ConvertDigitArrayToString();
            }
        };
        _8.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("8");
                ConvertDigitArrayToString();
            }
        };
        _9.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("9");
                ConvertDigitArrayToString();
            }
        };
        _OK.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                Debug.Log("Damn you're right");
                // gameObject1.SetActive(true)
                // gameObject2.SetActive(true)
                // View disablen
            }
            else
            {
                Debug.Log("Nööööööt wrong code");
                CodeAufräumen();
            }
        };
    }

    public void EnterNumber(string enteredNumber)
    {
        if (digitPosition <= 4)
        {
            display[digitPosition] = enteredNumber;
        }
    }

    public void ConvertDigitArrayToString()
    {
        joinedString = string.Join(" ", display);
        Digits.text = joinedString;
    }

    public bool CheckDigitPosition()
    {
        return digitPosition < 5;
    }

    private void CodeAufräumen()
    {
        digitPosition = 1;
        joinedString = "0000";
        for (int i = 0; i < 5; i++)
        {
            display[i] = "0";
        }
    }
}
