using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class ChatMessage
{
    public int id;
    int[] nextIds;
    bool sent = false;
    public string text;
    bool available = false;
    public ChatResponse[] responses;
    public GameObject photo;

    public ChatMessage(
        int id,
        int[] nextIds,
        string text,
        ChatResponse[] responses,
        GameObject photo = null
    )
    {
        this.id = id;
        this.nextIds = nextIds;
        this.text = text;
        this.responses = responses;
        this.photo = photo;
    }
}
