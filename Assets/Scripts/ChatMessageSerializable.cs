using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChatMessageSerializable
{
    int id;
    int[] nextIds;
    bool sent;
    string text;
    string summary;
    bool available;
    ChatResponseSerializable[] responses;
    string photo;

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
        photo = message.photo.name;
    }
}
