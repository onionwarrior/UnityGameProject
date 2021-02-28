using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D BadCursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Start()
    {
        BadCursorTexture = Resources.Load<Texture2D>("bad_cursor");
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, Mathf.Infinity,(1<<9)))
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        else
            Cursor.SetCursor(BadCursorTexture, Vector2.zero, cursorMode);

    }
}
