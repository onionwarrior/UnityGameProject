using UnityEngine;
using System.Collections;
using System;
using UnityEngine.AI;
public class ClickToMove : MonoBehaviour
{
    private Vector3 DestinationPosition;
    private float DestinationDistance;
    private NavMeshAgent CharacterMoveAgent;
    private GameObject ProjectorGameObject;
    private Camera MyCamera;
    private Vector3 TargetPoint;
    private Ray MoveRay;
    Vector3 GetProjectorCoord(Vector3 TargetCoordinates)
    {
        Vector3 ReturnValue = TargetCoordinates;
        ReturnValue.y += 10.0f;
        return ReturnValue;
    }
    void Start()
    {
        CharacterMoveAgent= GetComponent<NavMeshAgent>();
        DestinationPosition = transform.position;
        TargetPoint = DestinationPosition;
        ProjectorGameObject = GameObject.Find("ProjectorDummy");
        MyCamera = Camera.main;
    }

    void Update()
    {
        DestinationDistance = Vector3.Distance(DestinationPosition, transform.position);
        bool PressedButton = false;
        if (Input.GetMouseButtonDown(0))
        {
            MoveRay = MyCamera.ScreenPointToRay(Input.mousePosition);
            PressedButton = true;
           
        }
        if (PressedButton && !Physics.Raycast(MoveRay, Mathf.Infinity, 1 << 9 | 1<<10))
        {
            if (Physics.Raycast(MoveRay, out RaycastHit OnClickHit, Mathf.Infinity, 1 << 8))
            {
                TargetPoint = OnClickHit.point;
                DestinationPosition = TargetPoint;
                ProjectorGameObject.transform.position = GetProjectorCoord(DestinationPosition);
            }
        }
		if (DestinationDistance > .5f )
            CharacterMoveAgent.SetDestination(TargetPoint);
	}

}
