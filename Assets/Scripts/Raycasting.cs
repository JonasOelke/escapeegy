using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARRaycasting : MonoBehaviour
{
    public ARRaycastManager raycastManager;

    public GameObject objectToPlacePrefab;

    public Camera raycastCamera;

    private GameObject objectInstance;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Update is called once per frame
    void Update()
    {
        if (raycastManager == null)
        {
            return;
        }

        if (raycastCamera == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                Pose pose = hits[0].pose;
                if (objectInstance == null)
                {
                    objectInstance = Instantiate<GameObject>(objectToPlacePrefab, pose.position, pose.rotation);
                }
                else
                {
                    objectInstance.transform.SetPositionAndRotation(pose.position, pose.rotation);
                }
            }
        }
    }
}
