using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Findables : MonoBehaviour
{
    // to determine if something is selected or not
    public bool IsSelected { get; set; }

    public StateControl stateControl;

    private Touch touch;

    private Vector2 touchPosition;

    private float initialDistance;

    private Vector3 initialScale;

    private Vector3 initialPosition;

    private Quaternion initialRotation;

    private float rotationSpeed = 0.001f;

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
                //Touch Referenz
                touch = Input.GetTouch(0);

                //Rotation des Objekts
                if (touch.phase == TouchPhase.Moved)
                {
                    float XaxisRotation = touch.deltaPosition.x * rotationSpeed;
                    float YaxisRotation = touch.deltaPosition.y * rotationSpeed;

                    transform.RotateAround(Vector3.down, XaxisRotation);
                    transform.RotateAround(Vector3.right, YaxisRotation);
                }
            } // Zoomen:
            else if (Input.touchCount == 2)
            {
                // Referenzen für die beiden Touches
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);

                //falls man wieder los lässt, nichts machen
                if (
                    touchZero.phase == TouchPhase.Ended ||
                    touchZero.phase == TouchPhase.Canceled ||
                    touchOne.phase == TouchPhase.Ended ||
                    touchOne.phase == TouchPhase.Canceled
                )
                {
                    return;
                }

                if (
                    touchZero.phase == TouchPhase.Began ||
                    touchOne.phase == TouchPhase.Began
                )
                {
                    initialDistance =
                        Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = transform.localScale;
                    Debug
                        .Log("Initial distance " +
                        initialDistance +
                        initialScale);
                } //wenn man beide Finger bewegt:
                else
                {
                    var currentDistance =
                        Vector2.Distance(touchZero.position, touchOne.position);

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
            transform.SetParent(null);
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
            stateControl.FoundObject (id);
        }
    }
}
