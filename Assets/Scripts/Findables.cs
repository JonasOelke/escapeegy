using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findables : MonoBehaviour
{
    // to determine if something is selected or not
    public bool IsSelected { get; set; }
    
    private Touch touch;

    private Vector2 touchPosition;

    private float initialDistance;

    private Vector3 initialScale;

    private Vector3 initialPosition;

    private Quaternion initialRotation;

    private float rotationSpeed = 0.001f;
    private GameObject mainMenuUI;

    [SerializeField]
    public int id;

    // Kamera
    [SerializeField]
    private Camera arCamera;

    void Awake()
    {
        // initiale Werte des Objekts speichern
        initialScale = transform.localScale;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        mainMenuUI = GameObject.Find("MainMenuUI");
    }

    //Update is called once per frame
    void Update()
    {
        // wenn Objekt ausgewäglt wird
        if (IsSelected)
        {
            transform.parent = arCamera.transform;
            transform.localPosition = Vector3.forward;

            // wenn einmal getouched wird
            if (Input.touchCount == 1)
            {
                Debug.Log("AAAAAAAAAAAA,"+gameObject.name);
                //Hier Speicher Button erscheinen lassen
                mainMenuUI.GetComponent<MainMenuController>().SetDisplayCollectedButton(true);
                mainMenuUI.GetComponent<MainMenuController>().SetCollectedButtonAction(() => {
                    StateControl.SaveFoundObject(gameObject.name);
                   // mainMenuUI.GetComponent<MainMenuController>().SetDisplayCollectedButton(false);
                });
                 
                //Touch Referenz
                touch = Input.GetTouch(0);

                //Rotation des Objekts
                if (touch.phase == TouchPhase.Moved)
                {
                    float XaxisRotation = touch.deltaPosition.x * rotationSpeed;

                    transform.RotateAround(Vector3.down, XaxisRotation);
                }
            } // Zoomen:
            else if (Input.touchCount == 2)
            {
                // Referenzen für die beiden Touches
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);

                //falls man wieder los lässt, nichts machen
                if (
                    touchZero.phase == TouchPhase.Ended
                    || touchZero.phase == TouchPhase.Canceled
                    || touchOne.phase == TouchPhase.Ended
                    || touchOne.phase == TouchPhase.Canceled
                )
                {
                    return;
                }

                if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = transform.localScale;
                    Debug.Log("Initial distance " + initialDistance + initialScale);
                } //wenn man beide Finger bewegt:
                else
                {
                    var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                    // if accidentally touched or pinchmovement very small
                    if (Mathf.Approximately(initialDistance, 0))
                    {
                        return; //when initial distance very close to 0
                    }

                    var factor = currentDistance / initialDistance;
                    transform.localScale = initialScale * factor;
                }
            }
        }
        else
        {
            // Zurücksetzen der Werte
            transform.SetParent(GameObject.Find("Findables").transform);
            transform.localScale = initialScale;
            transform.rotation = initialRotation;

            // zum Entwählen der Objekte - verfällt mit der Funktionalität sie ins Inventar zu legen
            transform.position = initialPosition;
        }
    }

    public void saveObject()
    {
        if (IsSelected)
        {
            StateControl.SaveFoundObject(gameObject.name);
        }
    }
}
