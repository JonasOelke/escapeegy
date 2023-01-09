using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Detected");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Left Detection");
    }
}
