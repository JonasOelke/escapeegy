using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

[System.Serializable]
public class StoredObject
{
    public bool firstOpened = true;
    public List<string> collectedObjects = new List<string>();
    public List<int> sentMessages = new List<int>();

    public StoredObject(List<string> collectedObjects)
    {
        this.collectedObjects = collectedObjects;
    }

    public void setOpened(bool opened)
    {
        this.firstOpened = opened;
    }
    
    
}
