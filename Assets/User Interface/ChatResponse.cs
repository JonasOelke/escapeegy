using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatResponse
{
    public Sprite photo;
    public string text;

    public ChatResponse(string text, string test, Sprite photo = null)
    {
        this.text = text;
        this.photo = photo;
    }

    public ChatResponse(ChatResponseSerializable chatResponseSerializable)
    {
        text = chatResponseSerializable.text;
        photo = Resources.Load<Sprite>("InventoryPictures/" + chatResponseSerializable.photo);
    }
}
