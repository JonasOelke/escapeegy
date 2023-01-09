using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;

public class StoredObject
{
    public bool firstOpened = true;
    public int state;
    public List<string> collectedObjects = new List<string>();
    public List<ChatMessage> sentMessages = new List<ChatMessage>();

    public StoredObject(List<string> collectedObjects)
    {
        collectedObjects.Add("Bildschnipsel1");
        collectedObjects.Add("Bildschnipsel2");
        collectedObjects.Add("Bildschnipsel3");
        collectedObjects.Add("Bildschnipsel4");
        collectedObjects.Add("Lochkarte");
        collectedObjects.Add("InteressantesPapier");
        collectedObjects.Add("ElliesBrief1");
        collectedObjects.Add("BriefVerschluesselt");
        collectedObjects.Add("Grundriss");

        this.collectedObjects = collectedObjects;
    }

    public StoredObject(StoredObjectSerializable storedObjectSerializable)
    {
        this.firstOpened = storedObjectSerializable.firstOpened;
        this.collectedObjects = storedObjectSerializable.collectedObjects.ToList();
        this.sentMessages = new List<ChatMessage>();
        foreach (
            ChatMessageSerializable chatMessageSerializable in storedObjectSerializable.sentMessages
        )
        {
            sentMessages.Add(new ChatMessage(chatMessageSerializable));
        }
    }

    public void setOpened(bool opened)
    {
        this.firstOpened = opened;
    }

    public void setState(int state)
    {
        this.state = state;
    }
}
