using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject SpindCodeUI;

    [SerializeField]
    private GameObject ColliderObject;

    [SerializeField]
    private GameObject ChatUI;

    [SerializeField]
    private GameObject InventoryUI;

    // Kamera
    [SerializeField]
    private Camera arCamera;

    //TODO: Wert muss aus Speicherdatei geholt werden
    public bool active;

    private Touch touch;

    private Vector2 touchPosition = default;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Wert muss aus Speicherdatei geholt werden
        active = true;
        ColliderObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !ChatUI.activeSelf && !InventoryUI.activeSelf)
        {
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
                        if (
                            hitObject.collider.gameObject.name ==
                            ColliderObject.name
                        )
                        {
                            SpindCodeUI.SetActive(true);
                        }
                    }
                }
            }
        }
    }
}
