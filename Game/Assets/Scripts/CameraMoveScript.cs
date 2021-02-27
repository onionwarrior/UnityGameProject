using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private int Width;
    private int Height;
    private float StartYOffset;
    [SerializeField] private float CameraMoveSpeed;
    [SerializeField] private int EdgeDistance = 10;
    float GetStartYOffset()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        float yDelta = 0.0f;
        if (Physics.Raycast(ray, out RaycastHit GroundBelowCamera))
        {
            yDelta = GroundBelowCamera.distance;
        }
        return yDelta;
    }
    void Start()
    {
        Width = Screen.width;
        Height = Screen.height;
        StartYOffset = transform.position.y;
    }
    void FixedUpdate()
    {
        Vector3 MousePosition = Input.mousePosition;
        Vector3 CurrentPosition = Vector3.zero;
        if (MousePosition.x > Width - EdgeDistance||Input.GetKey(KeyCode.RightArrow))
        {
            CurrentPosition.x += CameraMoveSpeed * Time.fixedDeltaTime ;
        }
        if (Input.mousePosition.x < EdgeDistance || Input.GetKey(KeyCode.LeftArrow))
        {
            CurrentPosition.x -= CameraMoveSpeed * Time.fixedDeltaTime ;
        }   
        if (Input.mousePosition.y > Height - EdgeDistance || Input.GetKey(KeyCode.UpArrow))
        {
            CurrentPosition.z += CameraMoveSpeed * Time.fixedDeltaTime;
        }
        if (Input.mousePosition.y < EdgeDistance || Input.GetKey(KeyCode.DownArrow))
        {
            CurrentPosition.z -= CameraMoveSpeed * Time.fixedDeltaTime ;
        }
        transform.Translate(CurrentPosition);
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit GroundBelowCamera))
        {
            Vector3 NewCoord = transform.position;
            NewCoord.y = GroundBelowCamera.point.y + StartYOffset;
            transform.position = NewCoord;
        }
    }
}
