using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeFloor : MonoBehaviour
{
    [SerializeField]
    private ARSession session;

    [SerializeField]
    private ARSessionOrigin sessionOrigin;

    public void FloorChange(string currentFloor, string chosenFloor)
    {
        // Reset position and rotation of ARSession
        // TODO Check for Rotation? Does it work?
        session.Reset();

        if (currentFloor.Equals("EG"))
        {
            if (chosenFloor.Equals("2OG"))
            {
                sessionOrigin.transform.position += new Vector3(0, 2, 0);
            } else
            {
                sessionOrigin.transform.position += new Vector3(0, 2, 0);
            }
        }
        if (currentFloor.Equals("2OG"))
        {
            if (chosenFloor.Equals("DG"))
            {
                sessionOrigin.transform.position += new Vector3(0, 2, 0);
            } else
            {
                sessionOrigin.transform.position += new Vector3(0, 2, 0);
            }
        }
        if (currentFloor.Equals("DG"))
        {
            if (chosenFloor.Equals("EG"))
            {
                sessionOrigin.transform.position += new Vector3(0, 2, 0);
            } else
            {
                sessionOrigin.transform.position += new Vector3(0, 2, 0);
            }
           
        }
       
    }
}
