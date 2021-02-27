using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour
{
    private Camera MyCamera;
    [SerializeField] private float ZoomSpeedModifier = 2;
    private void Start()
    {
        MyCamera = Camera.main;
    }
    void Update()
    {
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (MouseScroll != 0)
            MyCamera.orthographicSize = Mathf.Clamp(MyCamera.orthographicSize-MouseScroll*ZoomSpeedModifier, 7.0f,17.0f);
    }
}
