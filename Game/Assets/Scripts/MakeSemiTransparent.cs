using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class MakeSemiTransparent : MonoBehaviour
{
    private static List<GameObject> TransparentObjects = new List<GameObject>();
    private Transform myCamera;
    private NavMeshAgent PlayerAgent;
    void Start()
    {
        PlayerAgent = transform.GetComponent<NavMeshAgent>();
        myCamera = Camera.main.transform;
    }
    void Update()
    {
        Vector3 Target = PlayerAgent.transform.position;
        Ray ray = new Ray(myCamera.position, Target - myCamera.position);
        GameObject HitGameObject = null;
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~(1 << 9)))
        {
            if (hit.transform.gameObject != PlayerAgent.gameObject)
            {
                HitGameObject = hit.transform.gameObject;
                Renderer HitObjectRenderer = HitGameObject.GetComponent<Renderer>();
                if (HitObjectRenderer != null)
                {
                    if (!TransparentObjects.Contains(hit.transform.gameObject))
                    {
                        TransparentObjects.Add(hit.transform.gameObject);
                    }
                    Color CurrentColor = HitObjectRenderer.material.color;
                    CurrentColor.a = 0.5f;
                    HitObjectRenderer.material.color = CurrentColor;
                    //HitObjectRenderer.enabled = false;
                }
            }
        }
        List<GameObject> CopyList = new List<GameObject>();
        CopyList.AddRange(TransparentObjects);
        foreach (GameObject TransparentObject in CopyList)
        {
            if (TransparentObject != HitGameObject)
            {
                Renderer ThisObjectRenderer = TransparentObject.GetComponent<Renderer>();
                Color CurrentColor = ThisObjectRenderer.material.color;
                CurrentColor.a = 1.0f;
                ThisObjectRenderer.material.color = CurrentColor;
                TransparentObjects.Remove(TransparentObject);
                //ThisObjectRenderer.enabled = true;
            }
        }
    }

}
