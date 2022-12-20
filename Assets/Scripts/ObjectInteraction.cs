using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField]
    // Liste an in der Welt plazierten objekten mit denen interagiert werden soll
    private Findables[] placedObject;

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
        //ChangeSelectedObject(placedObject[0]);
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
                    //Wir gucken, ob das getroffene Object das Findables - Script attached hat
                    Findables findables =
                        hitObject.transform.GetComponent<Findables>();

                    // make it a child of the camera
                    hitObject.transform.parent = arCamera.transform;

                    // place it behind the camera
                    hitObject.transform.localPosition = Vector3.forward;

                    // wenn das getroffene Objekt das Script hat dann...
                    if (findables != null)
                    {
                        // ...ruf ich die Farb-Funktion auf
                        ChangeSelectedObject (findables);
                    }
                }
            }
        }
    }

    void ChangeSelectedObject(Findables selected)
    {
        foreach (Findables current in placedObject)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
            {
                print("Ich wurde gefunden" + selected);
            }
            else
            {
                print("Ich wurde nicht gefunden");
            }
        }
    }
}
