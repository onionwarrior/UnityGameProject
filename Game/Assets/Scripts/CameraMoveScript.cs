using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    private int Width;
    private int Height;
    [SerializeField] private float CameraMoveSpeed;
    [SerializeField] private int EdgeDistance = 10;
    void Start()
    {
        Width = Screen.width;
        Height = Screen.height;
    }
    void FixedUpdate()
    {
        Vector3 MousePosition = Input.mousePosition;
        Vector3 CurrentPosition = Vector3.zero;
        if (MousePosition.x > Width - EdgeDistance||Input.GetKey(KeyCode.RightArrow))
        {
            CurrentPosition.x += CameraMoveSpeed * Time.fixedDeltaTime;
        }
        if (Input.mousePosition.x < EdgeDistance || Input.GetKey(KeyCode.LeftArrow))
        {
            CurrentPosition.x -= CameraMoveSpeed * Time.fixedDeltaTime;
        }
        if (Input.mousePosition.y > Height - EdgeDistance || Input.GetKey(KeyCode.UpArrow))
        {
            CurrentPosition.y += CameraMoveSpeed * Time.fixedDeltaTime;
        }
        if (Input.mousePosition.y < EdgeDistance || Input.GetKey(KeyCode.DownArrow))
        {
            CurrentPosition.y -= CameraMoveSpeed *Time.fixedDeltaTime;
        }
        transform.Translate(CurrentPosition);
    }
}
