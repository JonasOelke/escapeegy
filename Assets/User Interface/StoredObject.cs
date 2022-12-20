using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class StoredObject
{
    public int[] collectedObjects;
	public int[] sentMessages;
	public int[] questionMarks;

	float spentTime;

    public StoredObject(
        int[] collectedObjects,
	    int[] sentMessages,
	    int[] questionMarks,

	    float spentTime
    )
    {
        this.collectedObjects= collectedObjects;
        this.sentMessages=sentMessages;
        this.questionMarks=questionMarks;
        this.spentTime=spentTime;
    }
   
}
