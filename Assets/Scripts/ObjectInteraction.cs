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

    [SerializeField]
    private GameObject ChatUI;

    [SerializeField]
    private GameObject InventoryUI;

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
        if (!ChatUI.activeSelf && !InventoryUI.activeSelf)
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
                    print("Touched!");

                    // Erstellt einen Strahl, der von der Kamera durch touch-punkt geht
                    Ray ray = arCamera.ScreenPointToRay(touch.position);

                    // RaycastHit: Gets information from a raycast (z.B. RaycastHit.collider)
                    RaycastHit hitObject;
                    if (Physics.Raycast(ray, out hitObject))
                    {
                        //Wir gucken, ob das getroffene Object das Findables - Script attached hat
                        Findables findable =
                            hitObject.transform.GetComponent<Findables>();

                        //Wenn nicht, schauen ob das Parent Element das Skript hat
                        if (findable == null)
                        {
                            findable =
                                hitObject
                                    .collider
                                    .gameObject
                                    .transform
                                    .parent
                                    .GetComponent<Findables>();
                        }

                        // wenn das getroffene Objekt/oder das Parent das Script hat dann...
                        if (findable != null)
                        {
                            // ...ruf ich die Interaktions-Funktion auf
                            ChangeSelectedObject (findable);
                        }
                        else
                        {
                            print("Object is not a findable " +
                            hitObject.transform);
                        }
                    }
                }
            }
        }
    }

    void ChangeSelectedObject(Findables selected)
    {
        foreach (Findables current in placedObject)
        {
            if (selected != current)
            {
                current.IsSelected = false;
            }
            else
            {
                current.IsSelected = true;
                //current.saveObject();
            }
        }
    }
}
