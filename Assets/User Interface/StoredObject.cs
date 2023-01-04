using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

[System.Serializable]
public class StoredObject
{
    public bool firstOpened = true;
    public List<int> collectedObjects = new List<int>();
    public List<int> sentMessages = new List<int>();

    public StoredObject(List<int> collectedObjects)
    {
        this.collectedObjects = collectedObjects;
    }

    public void setOpened(bool opened)
    {
        this.firstOpened = opened;
    }
}
