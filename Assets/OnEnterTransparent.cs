using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterTransparent : MonoBehaviour
{
    public float Alpha = 0.3f;
    private Renderer Renderer;
    private Color CurrentColor;
 
    private void Start()
    {
        Renderer = this.gameObject.transform.GetChild(0).GetComponent<Renderer>();
        CurrentColor = Renderer.material.color;
        CurrentColor.a = 1;
        Renderer.material.color = CurrentColor;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player has entered the trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentColor.a = Alpha;
            Renderer.material.color = CurrentColor;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has exited the trigger");
        if (other.gameObject.CompareTag("Player"))
        {
            CurrentColor.a = 1;
            Renderer.material.color = CurrentColor;
        }
    }
}
