using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpindCodeController : MonoBehaviour
{
    private string[] display = { "0", "0", "0", "0" };

    private int digitPosition = 0;

    private String joinedString;

    private String solution = "2405";

    public GameObject SpindCodeUI;

    public GameObject SpindCollider;

    public GameObject gameObject1;

    public GameObject gameObject2;

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

    private Button _back;

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
        _back = root.Q<Button>("BackButton");

        _0.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("0");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _1.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("1");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _2.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("2");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _3.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("3");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _4.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("4");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _5.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("5");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _6.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("6");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _7.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("7");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _8.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("8");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _9.clicked += () =>
        {
            if (CheckDigitPosition())
            {
                EnterNumber("9");
                ConvertDigitArrayToString();
                digitPosition += 1;
            }
        };
        _OK.clicked += () =>
        {
            Debug.Log("Input: " + joinedString);
            Debug.Log("Lösungswort: " + solution);
            if (joinedString == solution)
            {
                Destroy (SpindCollider);
                gameObject1.SetActive(true);
                gameObject2.SetActive(true);
                SpindCodeUI.SetActive(false);
            }
            else
            {
                CodeAufräumen();
            }
        };
        _back.clicked += () =>
        {
            CodeAufräumen();
            SpindCodeUI.SetActive(false);
        };
    }

    public void EnterNumber(string enteredNumber)
    {
        if (digitPosition <= 3)
        {
            display[digitPosition] = enteredNumber;
        }
    }

    public void ConvertDigitArrayToString()
    {
        joinedString = string.Join("", display);
        Digits.text = joinedString;
    }

    public bool CheckDigitPosition()
    {
        return digitPosition < 4;
    }

    private void CodeAufräumen()
    {
        digitPosition = 0;
        for (int i = 0; i < 4; i++)
        {
            display[i] = "0";
        }
        ConvertDigitArrayToString();
    }
}
