using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChatMessageSerializable
{
    public int id;
    public int[] nextIds;
    public bool sent;
    public string text;
    public string summary;
    public bool available;
    public ChatResponseSerializable[] responses;
    public string photo;

    public ChatMessageSerializable(ChatMessage message)
    {
        id = message.id;
        nextIds = message.nextIds;
        text = message.text;
        sent = message.sent;
        summary = message.summary;
        available = message.available;
        responses = new ChatResponseSerializable[message.responses.Length];
        for (int i = 0; i < message.responses.Length; i++)
        {
            responses[i] = new ChatResponseSerializable(message.responses[i]);
        }
        photo = message.photo ? message.photo.name : "";
    }
}
