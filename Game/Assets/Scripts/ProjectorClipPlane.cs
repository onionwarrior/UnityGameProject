using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Projector))]
public class ProjectorClipPlane : MonoBehaviour
{
    private Projector AttachedProjector;
    void Start()
    {
        AttachedProjector = GetComponent<Projector>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray,out RaycastHit FloorHit))
        {
            AttachedProjector.farClipPlane = Vector3.Distance(transform.position, FloorHit.point)*1.001f;
        }
    }
}
