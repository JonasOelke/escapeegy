using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptForClickingBall : MonoBehaviour
{
    [SerializeField]
    // Liste an in der Welt plazierten objekten mit denen interagiert werden soll
    private PlacementObject[] placedObject;

    // Farben
    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;

    // Kamera
    [SerializeField]
    private Camera arCamera;

    //Position wo der Finger touched
    private Vector2 touchPosition = default;

    private int ScreenWidth = Screen.width / 2;

    private int ScreenHeight = Screen.height / 2;

    private Vector3 oldPosition;

    void Awake()
    {
        ChangeSelectedObject(placedObject[0]);
    }

    void Update()
    {
        // checkt ob Screen getouched wird
        if (Input.touchCount > 0)
        {
            // Referenz für den Touch
            Touch touch = Input.GetTouch(0);

            // Position wo getouched wurde
            touchPosition = touch.position;

            // touch.phase beschreibt die Phase des Touches in der wir grade sind
            if (touch.phase == TouchPhase.Began)
            {
                // Erstellt einen Strahl, der von der Kamera durch touch-punkt geht
                Ray ray = arCamera.ScreenPointToRay(touch.position);

                // RaycastHit: Gets information from a raycast (z.B. RaycastHit.collider)
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    //Wir gucken, ob das getroffene Object das PlacementObject - Script attached hat
                    PlacementObject placementObject =
                        hitObject.transform.GetComponent<PlacementObject>();

                    oldPosition = hitObject.transform.position;

                    // Get the transform of the hit object
                    var ball = hitObject.transform;

                    // make it a child of the camera
                    ball.parent = arCamera.transform;

                    // place it behind the camera
                    ball.localPosition = Vector3.forward;

                    // wenn es das Script hat dann...
                    if (placementObject != null)
                    {
                        // ...ruf ich die Farb-Funktion auf
                        ChangeSelectedObject (placementObject);
                    }
                }
            }
        }
    }

    void ChangeSelectedObject(PlacementObject selected)
    {
        foreach (PlacementObject current in placedObject)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
            {
                current.IsSelected = false;
                meshRenderer.material.color = inactiveColor;
            }
            else
            {
                current.IsSelected = true;
                meshRenderer.material.color = activeColor;
            }
        }
    }
}
