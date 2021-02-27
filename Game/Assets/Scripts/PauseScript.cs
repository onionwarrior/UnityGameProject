using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    private bool IsOnPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsOnPause)
                Time.timeScale = 0.0f;
            else
                Time.timeScale = 1.0f;
            IsOnPause = !IsOnPause;
        }
    }
}
