using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapZoomController : MonoBehaviour
{
    // source: https://stackoverflow.com/questions/59030399/zooming-in-unity-mobile

    float MouseZoomSpeed = 15.0f;
    float TouchZoomSpeed = 0.1f;
    float ZoomMinBound = 2.0f;
    float ZoomMaxBound = 25.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {
                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Vector3 scale = GetComponent<RectTransform>().localScale;
                Vector3 offset =
                    new Vector3(deltaDistance, deltaDistance, deltaDistance) * TouchZoomSpeed;
                scale -= offset;
                if (scale.x > ZoomMinBound && scale.x < ZoomMaxBound)
                {
                    GetComponent<RectTransform>().localScale = scale;
                }
            }
        }
        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 scale = GetComponent<RectTransform>().localScale;
            Vector3 offset = new Vector3(scroll, scroll, scroll) * MouseZoomSpeed;
            scale += offset;
            if (scale.x > ZoomMinBound && scale.x < ZoomMaxBound)
            {
                GetComponent<RectTransform>().localScale = scale;
            }
        }
    }
}
