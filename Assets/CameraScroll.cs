using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    // Start is called before the first frame update
    Camera MainCam;
    void Start()
    {
        MainCam = Camera.main;
        print(MainCam.orthographicSize);
    }

    public float zoomSpeed = 20;
    void Update()
    {
        var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (mouseScroll != 0)
        {
            MainCam.orthographicSize = Mathf.Clamp(MainCam.orthographicSize-mouseScroll, 5.0f,15.0f);
        }
       
    }

}
