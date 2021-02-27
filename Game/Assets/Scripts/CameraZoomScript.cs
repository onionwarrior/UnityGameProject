using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour
{
    [SerializeField] private float ZoomSpeedModifier = 2;
    void Update()
    {
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (MouseScroll != 0)
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize-MouseScroll*ZoomSpeedModifier, 7.0f,17.0f);
    }
}
