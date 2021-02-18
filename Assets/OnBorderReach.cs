using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBorderReach : MonoBehaviour
{
    // Start is called before the first frame update
    private int Width;
    private int Height;
    public int CameraMoveSpeed = 5;
    public int EdgeDistance = 10;
    void Start()
    {
        Width = Screen.width;
        Height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePosition = Input.mousePosition;
        Vector3 CurrentPosition = Vector3.zero;
        if (MousePosition.x > Width - EdgeDistance||Input.GetKey(KeyCode.RightArrow))
        {
            CurrentPosition.x += CameraMoveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x < EdgeDistance || Input.GetKey(KeyCode.LeftArrow))
        {
            CurrentPosition.x -= CameraMoveSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y > Height - EdgeDistance || Input.GetKey(KeyCode.UpArrow))
        {
            CurrentPosition.y += CameraMoveSpeed * Time.deltaTime;
        }
            
        if (Input.mousePosition.y < EdgeDistance || Input.GetKey(KeyCode.DownArrow))
        {
            CurrentPosition.y -= CameraMoveSpeed * Time.deltaTime;
        }
        transform.Translate(CurrentPosition);
    }
}
