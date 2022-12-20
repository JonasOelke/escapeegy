using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class StoredObject : MonoBehaviour
{   
    bool opened=false;
    public int[] collectedObjects;
	public int[] sentMessages;

    public StoredObject(
        int[] collectedObjects,
	    int[] sentMessages
    )
    {
        this.collectedObjects= collectedObjects;
        this.sentMessages=sentMessages;
    }

    public void setOpened(bool opened){
        this.opened=opened;
    }
   
}
