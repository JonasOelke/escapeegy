using System.Collections.Generic;

[System.Serializable]
public class StoredObjectSerializable
{
    public bool firstOpened = true;
    public string[] collectedObjects;
    public ChatMessageSerializable[] sentMessages;

    public StoredObjectSerializable(StoredObject storedObject)
    {
        firstOpened = storedObject.firstOpened;
        collectedObjects = storedObject.collectedObjects.ToArray();
        sentMessages = new ChatMessageSerializable[storedObject.sentMessages.Count];
        for (int i = 0; i < storedObject.sentMessages.Count; i++)
        {
            sentMessages[i] = new ChatMessageSerializable(storedObject.sentMessages[i]);
        }
    }
}
