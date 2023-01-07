using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

[System.Serializable]
public class StoredObject
{
    public bool firstOpened = true;
    public int state;
    public List<string> collectedObjects = new List<string>();
    public List<int> sentMessages = new List<int>();

    public StoredObject(List<string> collectedObjects)
    {
        collectedObjects.Add("Bildschnipsel1");
        collectedObjects.Add("Bildschnipsel2");
        collectedObjects.Add("Bildschnipsel3");
        collectedObjects.Add("Bildschnipsel4");
        collectedObjects.Add("Lochkarte");
        collectedObjects.Add("InteressantesPapier");

        this.collectedObjects = collectedObjects;
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
