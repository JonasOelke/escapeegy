using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class storedObject
{
    int[] collectedObjects;
	int[] sentMessages;
	int[] questionMarks;
    float spentTime;

    public storedObject(
        int[] collectedObjects,
	    int[] sentMessages,
	    int[] questionMarks,
        float spentTime
    )
    {
        this.collectedObjects = collectedObjects;
        this.sentMessages = sentMessages;
        this.questionMarks = questionMarks;
        this.spentTime = spentTime;
    }
}
