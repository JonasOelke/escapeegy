using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChatResponseSerializable
{
    public string photo;
    public string text;

    public ChatResponseSerializable(ChatResponse chatResponse)
    {
        photo = chatResponse.photo ? chatResponse.photo.name : "";
        text = chatResponse.text;
    }
}
