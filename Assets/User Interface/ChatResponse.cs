using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatResponse
{
    public string photo;
    public string text;

    GameObject GetMessage()
    {
        return null;
    }

    public ChatResponse(string text,string photo)
    {
        this.text = text;
        this.photo =photo;
    }
}
