using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class ChatMessage
{
    public int id;
    public int[] nextIds;
    public bool sent = false;
    public string text;
    public string summary;
    public bool available = false;
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

    public ChatMessage(ChatMessageSerializable chatMessageSerializable)
    {
        id = chatMessageSerializable.id;
        nextIds = chatMessageSerializable.nextIds;
        sent = chatMessageSerializable.sent;
        text = chatMessageSerializable.text;
        summary = chatMessageSerializable.summary;
        responses = new ChatResponse[chatMessageSerializable.responses.Length];

        for (int i = 0; i < chatMessageSerializable.responses.Length; i++)
        {
            responses[i] = new ChatResponse(chatMessageSerializable.responses[i]);
        }

        if (!chatMessageSerializable.photo.Equals(""))
        {
            try
            {
                Sprite sprite = Resources.Load<Sprite>(
                    "InventoryPictures/" + chatMessageSerializable.photo
                );
                photo = sprite;
            }
            catch (Exception e)
            {
                Debug.Log(
                    e + "\n this probably means, that there is no photo defined for this message"
                );
                photo = null;
            }
        }
    }
}
