using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeFloor : MonoBehaviour
{
    [SerializeField]
    ARSession session;

    [SerializeField]
    ARSessionOrigin sessionOrigin;

    public void FloorChange(string currentFloor, string chosenFloor)
    {
        // Reset position and rotation of ARSession
        // TODO Check for Rotation? Does it work?
        session.Reset();

        if (currentFloor.Equals("EG"))
        {
            if (chosenFloor.Equals("2OG"))
            {
                sessionOrigin.transform.position += new Vector3(150, 0, 0);
            } 
            if (chosenFloor.Equals("DG"))
            {
                sessionOrigin.transform.position += new Vector3(300, 0, 0);
            } else
            {
                return;
            }
        }
        if (currentFloor.Equals("2OG"))
        {
            if (chosenFloor.Equals("EG"))
            {
                sessionOrigin.transform.position -= new Vector3(150, 0, 0);
            }
            if (chosenFloor.Equals("DG"))
            {
                sessionOrigin.transform.position += new Vector3(150, 0, 0);
            } else
            {
                return;
            }
        }
        if (currentFloor.Equals("DG"))
        {
            if (chosenFloor.Equals("EG"))
            {
                sessionOrigin.transform.position -= new Vector3(300, 0, 0);
            } 
            if (chosenFloor.Equals("2OG"))
            {
                sessionOrigin.transform.position -= new Vector3(150, 0, 0);
            } else
            {
                return;
            }
           
        }
       
    }
}
