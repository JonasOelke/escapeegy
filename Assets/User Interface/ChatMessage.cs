using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class ChatMessage
{
    public int id;
    public int[] nextIds;
    bool sent = false;
    public string text;
    public string summary;
    bool available = false;
    public ChatResponse[] responses;
    public Sprite photo;

    public ChatMessage(
        int id,
        int[] nextIds,
        string text,
        string summary,
        ChatResponse[] responses,
        Sprite photo = null
    )
    {
        this.id = id;
        this.nextIds = nextIds;
        this.text = text;
        this.summary = summary;
        this.responses = responses;
        this.photo = photo;
    }
}
