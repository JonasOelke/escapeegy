using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatResponse
{
    public GameObject photo;
    public string text;

    GameObject GetMessage()
    {
        return null;
    }

    public ChatResponse(string text)
    {
        this.text = text;
    }
}
